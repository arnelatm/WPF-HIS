using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using AATM.Accounts.BusinessLayer;
using AATM.Accounts.DataLayer.AdoNet;

// Run only through Test-MedicalFitnessSave.ps1 with a newly created LocalDB database.
public static class MedicalFitnessSaveChecks
{
    private const string GlucoseCode = "Item_L658_PropertyGroup__Property_Random Blood Glucose (RBS)";
    private static string connectionString;

    public static int Main(string[] args)
    {
        try
        {
            connectionString = ConfigurationManager.ConnectionStrings["ISPDATA"].ConnectionString;
            var target = new SqlConnectionStringBuilder(connectionString);
            if (target.DataSource != @"(localdb)\MSSQLLocalDB" ||
                !Regex.IsMatch(target.InitialCatalog, @"^MedicalFitnessSaveTest_[a-f0-9]{32}$"))
                throw new Exception("This check requires a disposable LocalDB database.");
            Run(args[0]);
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
            return 1;
        }
    }

    private static void Run(string root)
    {
        foreach (string table in new[] { "MedicalFitnessReportFormat", "MedicalFitnessReport",
            "MedicalFitnessReportTestResult", "MedicalFitnessReportLabTemplate",
            "MedicalFitnessReportExamTemplate", "MedicalFitnessReportFormatItem" })
        {
            string sql = File.ReadAllText(Path.Combine(root, "IspDataDb", "dbo", "Tables", table + ".sql"));
            // Recreate the deployed 50-character definition before applying the migration.
            if (table == "MedicalFitnessReportTestResult" || table == "MedicalFitnessReportLabTemplate")
                sql = Regex.Replace(sql, @"(\[TestCode\]\s+)NVARCHAR\s*\(255\)", "$1VARCHAR(50)");
            ExecuteScript(sql);
        }
        var dao = new MedicalFitnessReportDao();
        var report = Report(900001, "Original header", Row("VDRL", "Non-Reactive", 210));
        int originalId = dao.SaveReport(report);
        Assert(originalId > 0, "Baseline report saved");

        report.PatientName = "Changed header";
        report.Details.Add(Row(GlucoseCode.TrimEnd(), "124", 200));
        ExpectTruncation(() => dao.SaveReport(report));
        Assert(Convert.ToString(Scalar("SELECT PatientName FROM dbo.MedicalFitnessReport WHERE InvoiceNo=900001")) == "Original header" &&
            CountDetails(originalId) == 1, "60-character code fails against old schema and rolls back header and details");

        var newReport = Report(900002, "Failed new header", Row(GlucoseCode.TrimEnd(), "124", 200));
        ExpectTruncation(() => dao.SaveReport(newReport));
        Assert(newReport.IdNo == 0 && Convert.ToInt32(Scalar("SELECT COUNT(*) FROM dbo.MedicalFitnessReport WHERE InvoiceNo=900002")) == 0,
            "Failed new save leaves no header and publishes no ID");

        string migration = File.ReadAllText(Path.Combine(root, "DatabaseScripts", "WidenMedicalFitnessLabTestCode.sql"));
        ExecuteScript(migration);
        ExecuteScript(migration);
        Assert(Convert.ToInt32(Scalar("SELECT COUNT(*) FROM sys.columns WHERE object_id IN (OBJECT_ID('dbo.MedicalFitnessReportTestResult'), OBJECT_ID('dbo.MedicalFitnessReportLabTemplate')) AND name='TestCode' AND TYPE_NAME(system_type_id)='nvarchar' AND max_length=510")) == 2,
            "Migration widens both columns and can be repeated");

        Assert(dao.SaveReport(report) == originalId && CountDetails(originalId) == 2,
            "Existing report saves the full glucose code after migration");
        Assert(Convert.ToString(Scalar("SELECT TestCode FROM dbo.MedicalFitnessReportTestResult WHERE DisplayOrder=200")) == GlucoseCode.TrimEnd(),
            "Glucose code is preserved without shortening");
        var data = dao.GetReportPrintDataSet(900001);
        var glucose = data.Tables["MedicalFitnessReportTestResult"].Select("DisplayOrder=200");
        Assert(glucose.Length == 1 && Convert.ToString(glucose[0]["ResultText"]) == "124" &&
            Convert.ToString(glucose[0]["ResultStatus"]) == "F", "Glucose and its entry result reach the print dataset");
        report.Details[1].ResultText = null;
        dao.SaveReport(report);
        Assert(dao.GetReportPrintDataSet(900001).Tables["MedicalFitnessReportTestResult"].Select("DisplayOrder=200").Length == 1,
            "Automatic Fit glucose remains printable with an empty entry result");

        newReport.Details.Add(Row(new string('\u0633', 255), "Synthetic Unicode result", 220));
        dao.SaveReport(newReport);
        Assert(newReport.IdNo > 0 && CountDetails(newReport.IdNo) == 2,
            "New report saves full 255-character Unicode codes");
        Assert(Convert.ToString(Scalar("SELECT TestCode FROM dbo.MedicalFitnessReportTestResult WHERE DisplayOrder=220")) == new string('\u0633', 255),
            "Unicode code round-trips unchanged");

        ExecuteScript("INSERT dbo.MedicalFitnessReportLabTemplate(TestCode,TestNameEnglish,DisplayOrder) VALUES(REPLICATE(NCHAR(1587),255),N'Synthetic template',220);");
        bool duplicateRejected = false;
        try { ExecuteScript("INSERT dbo.MedicalFitnessReportLabTemplate(TestCode,TestNameEnglish,DisplayOrder) VALUES(REPLICATE(NCHAR(1587),255),N'Duplicate',221);"); }
        catch (SqlException ex) { duplicateRejected = ex.Number == 2627 || ex.Number == 2601; }
        Assert(duplicateRejected, "Template code uniqueness remains enforced");

        report.PatientName = "Must not persist";
        report.Details.Add(Row("InvalidUnit", "1", 230));
        report.Details[2].LabUnit = new string('x', 101);
        ExpectTruncation(() => dao.SaveReport(report));
        Assert(CountDetails(originalId) == 2 &&
            Convert.ToString(Scalar("SELECT PatientName FROM dbo.MedicalFitnessReport WHERE InvoiceNo=900001")) == "Changed header",
            "Failure after valid detail inserts preserves the previous saved report");

        var lookupReport = Report(900001, "Lookup must not persist", Row("InvalidUnit", "1", 230));
        lookupReport.Details[0].LabUnit = new string('x', 101);
        ExpectTruncation(() => dao.SaveReport(lookupReport));
        Assert(lookupReport.IdNo == 0 && CountDetails(originalId) == 2,
            "Invoice lookup also rolls back without publishing an ID");
        lookupReport.Details[0].LabUnit = "mg/dl";
        Assert(dao.SaveReport(lookupReport) == originalId && CountDetails(originalId) == 1,
            "Invoice lookup updates the existing header on success");
    }

    private static MedicalFitnessReport Report(int invoice, string name, params MedicalFitnessReportTestResult[] rows)
    {
        return new MedicalFitnessReport { InvoiceNo = invoice, ReportFormat = "STANDARD", PatientName = name,
            FinalResultStatus = "F", Details = new List<MedicalFitnessReportTestResult>(rows) };
    }
    private static MedicalFitnessReportTestResult Row(string code, string result, int sequence)
    {
        return new MedicalFitnessReportTestResult { TestCode = code, TestNameEnglish = "Synthetic lab test",
            TestNameArabic = "فحص تجريبي", SectionCode = "LAB", Sequence = sequence, ResultText = result,
            LabResult = result, LabUnit = "mg/dl", ResultStatus = "F", ResultStatusSource = "A" };
    }
    private static int CountDetails(int id)
    {
        return Convert.ToInt32(Scalar("SELECT COUNT(*) FROM dbo.MedicalFitnessReportTestResult WHERE MedicalFitnessReportIdNo=" + id));
    }
    private static object Scalar(string sql)
    {
        using (var connection = new SqlConnection(connectionString))
        using (var command = new SqlCommand(sql, connection))
        { connection.Open(); return command.ExecuteScalar(); }
    }
    private static void ExecuteScript(string script)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            foreach (string batch in Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase))
                if (!String.IsNullOrWhiteSpace(batch))
                    using (var command = new SqlCommand(batch, connection)) command.ExecuteNonQuery();
        }
    }
    private static void ExpectTruncation(Action action)
    {
        try { action(); }
        catch (SqlException ex) { if (ex.Number == 8152 || ex.Number == 2628) return; throw; }
        throw new Exception("Expected SQL truncation failure to reach the caller.");
    }
    private static void Assert(bool value, string message)
    {
        if (!value) throw new Exception(message);
        Console.WriteLine("PASS: " + message);
    }
}

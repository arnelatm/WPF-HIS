Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet

    Public Class MedicalFitnessReportDao
        Inherits CommonDao

        Private ReadOnly _ispDataDb As New Db("ISPDATA")
        Private ReadOnly _kizenDb As New Db("Kizen")

        Public Overrides Function GetDB()
            Return _ispDataDb
        End Function

        Public Function GetSavedReportByInvoiceNo(invoiceNo As Int32) As MedicalFitnessReport
            Dim sql As String =
                "SELECT IdNo,InvoiceNo,InvoiceDate,FileNo,PatientName,Gender,Age,Nationality,IdentityNo,DoctorName,BloodType,FinalResultStatus,Remarks " &
                "FROM MedicalFitnessReport " &
                "WHERE InvoiceNo = @InvoiceNo"

            Dim report = _ispDataDb.Read(sql, MakeReport, "@InvoiceNo", invoiceNo).FirstOrDefault()
            If report IsNot Nothing Then
                report.Details = GetReportDetails(report.IdNo)
            End If
            Return report
        End Function

        Public Function GetKizenInvoice(invoiceNo As Int32) As MedicalFitnessReport
            Dim sql As String =
                "SELECT TOP (1) " &
                "i.ID AS InvoiceNo, " &
                "i.Date AS InvoiceDate, " &
                "i.CustID AS FileNo, " &
                "i.CustName AS PatientName, " &
                "c.CustGender AS Gender, " &
                "dbo.DateToAge(c.CustBirthday, i.Date) AS Age, " &
                "i.CustNat AS Nationality, " &
                "i.CustIdentity AS IdentityNo, " &
                "i.DrName AS DoctorName " &
                "FROM dbo.A1_Invoces i " &
                "LEFT JOIN dbo.Customers c ON i.CustID = c.CustID " &
                "WHERE i.ID = @InvoiceNo"

            Return _kizenDb.Read(sql, MakeKizenInvoice, "@InvoiceNo", invoiceNo).FirstOrDefault()
        End Function

        Public Function GetKizenLabAnalyses(invoiceNo As Int32) As List(Of MedicalFitnessReportLabAnalysis)
            Dim sql As String =
                "WITH SourceRows AS (" &
                "SELECT r.ID, d.ID AS VisitAnalysesID, d.OrderID, " &
                "COALESCE(NULLIF(LTRIM(RTRIM(r.Code)), N''), N'KIZEN_' + CONVERT(nvarchar(20), r.ID)) AS TestCode, " &
                "COALESCE(NULLIF(LTRIM(RTRIM(r.Code)), N''), CONVERT(nvarchar(1000), LTRIM(RTRIM(r.Name)))) AS DuplicateKey, " &
                "CONVERT(nvarchar(1000), LTRIM(RTRIM(r.Name))) AS TestNameEnglish, " &
                "CONVERT(nvarchar(max), r.Data) AS ResultValue, " &
                "CONVERT(nvarchar(max), r.RV) AS ReferenceValue, " &
                "CONVERT(nvarchar(100), r.Unit) AS UnitValue, " &
                "CONVERT(nvarchar(1000), r.Parent) AS ParentCode, " &
                "CONVERT(nvarchar(1000), r.Code) AS ResultCode, " &
                "CONVERT(nvarchar(max), d.ReqNote) AS ReqNote " &
                "FROM dbo.VisitAnalysesData d " &
                "INNER JOIN dbo.VisitAnalysesResult r ON r.VisitAnalysesID = d.ID " &
                "WHERE d.OrderID = @InvoiceNo " &
                "AND NULLIF(CONVERT(nvarchar(1000), LTRIM(RTRIM(r.Name))), N'') IS NOT NULL " &
                "AND ISNULL(r.IsHide, 0) = 0), " &
                "MedicalReportOrders AS (" &
                "SELECT DISTINCT OrderID " &
                "FROM SourceRows " &
                "WHERE ParentCode LIKE N'Group[_]%' " &
                "AND TestNameEnglish LIKE N'Medical Report%'), " &
                "IncludedRows AS (" &
                "SELECT source.ID, source.VisitAnalysesID, source.TestCode, source.DuplicateKey, source.TestNameEnglish, " &
                "source.ResultValue, source.ReferenceValue, source.UnitValue, " &
                "source.ID AS RootID, 0 AS HierarchyOrder, " &
                "CASE WHEN CHARINDEX(source.TestNameEnglish, source.ReqNote) = 0 THEN 2147483647 " &
                "ELSE CHARINDEX(source.TestNameEnglish, source.ReqNote) END AS RequestedPosition " &
                "FROM SourceRows source " &
                "WHERE source.ParentCode LIKE N'Group[_]%' " &
                "UNION ALL " &
                "SELECT child.ID, child.VisitAnalysesID, child.TestCode, child.DuplicateKey, child.TestNameEnglish, " &
                "child.ResultValue, child.ReferenceValue, child.UnitValue, " &
                "root.ID AS RootID, 1 AS HierarchyOrder, " &
                "CASE WHEN CHARINDEX(root.TestNameEnglish, root.ReqNote) = 0 THEN 2147483647 " &
                "ELSE CHARINDEX(root.TestNameEnglish, root.ReqNote) END AS RequestedPosition " &
                "FROM SourceRows child " &
                "INNER JOIN SourceRows root ON root.VisitAnalysesID = child.VisitAnalysesID " &
                "INNER JOIN MedicalReportOrders medicalReport ON medicalReport.OrderID = child.OrderID " &
                "WHERE root.ParentCode LIKE N'Group[_]%' " &
                "AND (root.TestNameEnglish LIKE N'Medical Report%' OR root.TestNameEnglish = N'Lipids Profile') " &
                "AND LEFT(child.ParentCode, LEN(root.ResultCode) + 1) = root.ResultCode + N'_'), " &
                "InvoiceLabAnalyses AS (" &
                "SELECT included.*, " &
                "ROW_NUMBER() OVER (" &
                "PARTITION BY included.DuplicateKey " &
                "ORDER BY included.VisitAnalysesID DESC, included.RequestedPosition, included.RootID, included.HierarchyOrder, included.ID) AS DuplicateNumber " &
                "FROM IncludedRows included) " &
                "SELECT TestCode, TestNameEnglish, ResultValue, ReferenceValue, UnitValue " &
                "FROM InvoiceLabAnalyses " &
                "WHERE DuplicateNumber = 1 " &
                "ORDER BY VisitAnalysesID DESC, RequestedPosition, RootID, HierarchyOrder, ID"

            Return _kizenDb.Read(sql, MakeKizenLabAnalysis, "@InvoiceNo", invoiceNo).ToList()
        End Function

        Public Function GetActiveLabTemplates() As List(Of MedicalFitnessReportLabTemplate)
            Dim sql As String =
                "SELECT IdNo,TestCode,TestNameEnglish,TestNameArabic,DisplayOrder,Active " &
                "FROM MedicalFitnessReportLabTemplate " &
                "WHERE Active = 1 " &
                "ORDER BY DisplayOrder, TestNameEnglish"

            Return _ispDataDb.Read(sql, MakeLabTemplate).ToList()
        End Function

        Public Function SaveReport(report As MedicalFitnessReport) As Int32
            If report.IdNo = 0 Then
                Dim existingId = _ispDataDb.Scalar(
                    "SELECT IdNo FROM MedicalFitnessReport WHERE InvoiceNo = @InvoiceNo",
                    "@InvoiceNo", report.InvoiceNo)
                If existingId IsNot Nothing AndAlso Not IsDBNull(existingId) Then
                    report.IdNo = Convert.ToInt32(existingId)
                End If
            End If

            If report.IdNo = 0 Then
                report.IdNo = InsertReport(report)
            Else
                UpdateReport(report)
            End If

            ReplaceDetails(report)
            Return report.IdNo
        End Function

        Public Sub DeleteReport(reportIdNo As Int32)
            Dim sql As String =
                "SET XACT_ABORT ON; " &
                "BEGIN TRANSACTION; " &
                "DELETE FROM MedicalFitnessReportTestResult WHERE MedicalFitnessReportIdNo = @IdNo; " &
                "DELETE FROM MedicalFitnessReport WHERE IdNo = @IdNo; " &
                "COMMIT TRANSACTION;"

            _ispDataDb.Update(sql, "@IdNo", reportIdNo)
        End Sub

        Private Function InsertReport(report As MedicalFitnessReport) As Int32
            Dim sql As String =
                "INSERT INTO MedicalFitnessReport " &
                "(InvoiceNo,InvoiceDate,FileNo,PatientName,Gender,Age,Nationality,IdentityNo,DoctorName,BloodType,FinalResultStatus,Remarks) " &
                "VALUES " &
                "(@InvoiceNo,@InvoiceDate,@FileNo,@PatientName,@Gender,@Age,@Nationality,@IdentityNo,@DoctorName,@BloodType,@FinalResultStatus,@Remarks); " &
                "SELECT CONVERT(int, SCOPE_IDENTITY());"

            Return Convert.ToInt32(_ispDataDb.Scalar(sql, TakeReport(report)))
        End Function

        Private Function UpdateReport(report As MedicalFitnessReport) As Int32
            Dim sql As String =
                "UPDATE MedicalFitnessReport SET " &
                "InvoiceNo = @InvoiceNo, " &
                "InvoiceDate = @InvoiceDate, " &
                "FileNo = @FileNo, " &
                "PatientName = @PatientName, " &
                "Gender = @Gender, " &
                "Age = @Age, " &
                "Nationality = @Nationality, " &
                "IdentityNo = @IdentityNo, " &
                "DoctorName = @DoctorName, " &
                "BloodType = @BloodType, " &
                "FinalResultStatus = @FinalResultStatus, " &
                "Remarks = @Remarks " &
                "WHERE IdNo = @IdNo"

            Dim params = TakeReport(report).ToList()
            params.AddRange({"@IdNo", report.IdNo})
            Return _ispDataDb.Update(sql, params.ToArray())
        End Function

        Private Sub ReplaceDetails(report As MedicalFitnessReport)
            _ispDataDb.Update("DELETE FROM MedicalFitnessReportTestResult WHERE MedicalFitnessReportIdNo = @IdNo", "@IdNo", report.IdNo)

            If report.Details Is Nothing Then
                Return
            End If

            For Each detail In report.Details
                detail.MedicalFitnessReportIdNo = report.IdNo
                InsertDetail(detail)
            Next
        End Sub

        Private Function InsertDetail(detail As MedicalFitnessReportTestResult) As Int32
            Dim sql As String =
                "INSERT INTO MedicalFitnessReportTestResult " &
                "(MedicalFitnessReportIdNo,SectionCode,TestCode,TestNameEnglish,TestNameArabic,DisplayOrder,ResultStatus,ResultText," &
                "LabResult,LabReferenceValue,LabUnit,LabAssessment,ResultStatusSource,Remarks) " &
                "VALUES " &
                "(@MedicalFitnessReportIdNo,@SectionCode,@TestCode,@TestNameEnglish,@TestNameArabic,@Sequence,@ResultStatus,@ResultText," &
                "@LabResult,@LabReferenceValue,@LabUnit,@LabAssessment,@ResultStatusSource,@Remarks); " &
                "SELECT CONVERT(int, SCOPE_IDENTITY());"

            Return Convert.ToInt32(_ispDataDb.Scalar(sql, TakeDetail(detail)))
        End Function

        Private Function GetReportDetails(reportIdNo As Int32) As List(Of MedicalFitnessReportTestResult)
            Dim sql As String =
                "SELECT IdNo,MedicalFitnessReportIdNo,SectionCode,TestCode,TestNameEnglish,TestNameArabic,DisplayOrder AS Sequence," &
                "ResultStatus,ResultText,LabResult,LabReferenceValue,LabUnit,LabAssessment,ResultStatusSource,Remarks " &
                "FROM MedicalFitnessReportTestResult " &
                "WHERE MedicalFitnessReportIdNo = @MedicalFitnessReportIdNo " &
                "ORDER BY DisplayOrder, IdNo"

            Return _ispDataDb.Read(sql, MakeDetail, "@MedicalFitnessReportIdNo", reportIdNo).ToList()
        End Function

        Private Shared Function DbValue(value As Object) As Object
            If value Is Nothing Then
                Return DBNull.Value
            End If
            Return value
        End Function

        Private Shared Function TakeReport(report As MedicalFitnessReport) As Object()
            Return New Object() {
                "@InvoiceNo", report.InvoiceNo,
                "@InvoiceDate", DbValue(report.InvoiceDate),
                "@FileNo", DbValue(report.FileNo),
                "@PatientName", DbValue(report.PatientName),
                "@Gender", DbValue(report.Gender),
                "@Age", DbValue(report.Age),
                "@Nationality", DbValue(report.Nationality),
                "@IdentityNo", DbValue(report.IdentityNo),
                "@DoctorName", DbValue(report.DoctorName),
                "@BloodType", DbValue(report.BloodType),
                "@FinalResultStatus", DbValue(report.FinalResultStatus),
                "@Remarks", DbValue(report.Remarks)}
        End Function

        Private Shared Function TakeDetail(detail As MedicalFitnessReportTestResult) As Object()
            Return New Object() {
                "@MedicalFitnessReportIdNo", detail.MedicalFitnessReportIdNo,
                "@SectionCode", detail.SectionCode,
                "@TestCode", detail.TestCode,
                "@TestNameEnglish", detail.TestNameEnglish,
                "@TestNameArabic", DbValue(detail.TestNameArabic),
                "@Sequence", detail.Sequence,
                "@ResultStatus", DbValue(detail.ResultStatus),
                "@ResultText", DbValue(detail.ResultText),
                "@LabResult", DbValue(detail.LabResult),
                "@LabReferenceValue", DbValue(detail.LabReferenceValue),
                "@LabUnit", DbValue(detail.LabUnit),
                "@LabAssessment", DbValue(detail.LabAssessment),
                "@ResultStatusSource", DbValue(detail.ResultStatusSource),
                "@Remarks", DbValue(detail.Remarks)}
        End Function

        Private Shared ReadOnly MakeReport As Func(Of IDataReader, MedicalFitnessReport) =
            Function(reader) New MedicalFitnessReport() With {
                .IdNo = Extensions.AsInt(Of Int32)(reader("IdNo")),
                .InvoiceNo = Extensions.AsInt(Of Int32)(reader("InvoiceNo")),
                .InvoiceDate = Extensions.AsNullable(Of DateTime?)(reader("InvoiceDate")),
                .FileNo = Extensions.AsNullable(Of Int32?)(reader("FileNo")),
                .PatientName = Extensions.AsString(reader("PatientName")),
                .Gender = Extensions.AsString(reader("Gender")),
                .Age = Extensions.AsString(reader("Age")),
                .Nationality = Extensions.AsString(reader("Nationality")),
                .IdentityNo = Extensions.AsString(reader("IdentityNo")),
                .DoctorName = Extensions.AsString(reader("DoctorName")),
                .BloodType = Extensions.AsString(reader("BloodType")),
                .FinalResultStatus = Extensions.AsString(reader("FinalResultStatus")),
                .Remarks = Extensions.AsString(reader("Remarks"))}

        Private Shared ReadOnly MakeKizenInvoice As Func(Of IDataReader, MedicalFitnessReport) =
            Function(reader) New MedicalFitnessReport() With {
                .InvoiceNo = Extensions.AsInt(Of Int32)(reader("InvoiceNo")),
                .InvoiceDate = Extensions.AsNullable(Of DateTime?)(reader("InvoiceDate")),
                .FileNo = Extensions.AsNullable(Of Int32?)(reader("FileNo")),
                .PatientName = Extensions.AsString(reader("PatientName")),
                .Gender = Extensions.AsString(reader("Gender")),
                .Age = Extensions.AsString(reader("Age")),
                .Nationality = Extensions.AsString(reader("Nationality")),
                .IdentityNo = Extensions.AsString(reader("IdentityNo")),
                .DoctorName = Extensions.AsString(reader("DoctorName"))}

        Private Shared ReadOnly MakeDetail As Func(Of IDataReader, MedicalFitnessReportTestResult) =
            Function(reader) New MedicalFitnessReportTestResult() With {
                .IdNo = Extensions.AsInt(Of Int32)(reader("IdNo")),
                .MedicalFitnessReportIdNo = Extensions.AsInt(Of Int32)(reader("MedicalFitnessReportIdNo")),
                .SectionCode = Extensions.AsString(reader("SectionCode")),
                .TestCode = Extensions.AsString(reader("TestCode")),
                .TestNameEnglish = Extensions.AsString(reader("TestNameEnglish")),
                .TestNameArabic = Extensions.AsString(reader("TestNameArabic")),
                .Sequence = Extensions.AsInt(Of Int32)(reader("Sequence")),
                .ResultStatus = Extensions.AsString(reader("ResultStatus")),
                .ResultText = Extensions.AsString(reader("ResultText")),
                .LabResult = Extensions.AsString(reader("LabResult")),
                .LabReferenceValue = Extensions.AsString(reader("LabReferenceValue")),
                .LabUnit = Extensions.AsString(reader("LabUnit")),
                .LabAssessment = Extensions.AsString(reader("LabAssessment")),
                .ResultStatusSource = Extensions.AsString(reader("ResultStatusSource")),
                .Remarks = Extensions.AsString(reader("Remarks"))}

        Private Shared ReadOnly MakeLabTemplate As Func(Of IDataReader, MedicalFitnessReportLabTemplate) =
            Function(reader) New MedicalFitnessReportLabTemplate() With {
                .IdNo = Extensions.AsInt(Of Int32)(reader("IdNo")),
                .TestCode = Extensions.AsString(reader("TestCode")),
                .TestNameEnglish = Extensions.AsString(reader("TestNameEnglish")),
                .TestNameArabic = Extensions.AsString(reader("TestNameArabic")),
                .DisplayOrder = Extensions.AsInt(Of Int32)(reader("DisplayOrder")),
                .Active = Convert.ToBoolean(reader("Active"))}

        Private Shared ReadOnly MakeKizenLabAnalysis As Func(Of IDataReader, MedicalFitnessReportLabAnalysis) =
            Function(reader) New MedicalFitnessReportLabAnalysis() With {
                .TestCode = Extensions.AsString(reader("TestCode")),
                .TestNameEnglish = Extensions.AsString(reader("TestNameEnglish")),
                .ResultValue = Extensions.AsString(reader("ResultValue")),
                .ReferenceValue = Extensions.AsString(reader("ReferenceValue")),
                .Unit = Extensions.AsString(reader("UnitValue"))}

    End Class

End Namespace

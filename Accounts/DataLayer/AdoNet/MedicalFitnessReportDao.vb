Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer.AdoNet
Imports System.Data

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
                "SELECT IdNo,InvoiceNo,ReportFormat,MedicalReportFormatIdNo,InvoiceDate,FileNo,PatientName,CompanyName,PassportNo,Gender,Age,Nationality,IdentityNo,DoctorName,BloodType," &
                "ExamTemperature,ExamBloodPressure,ExamPulse,ExamRespiratorySystem,ExamCardiovascularSystem,ExamNervousSystem," &
                "ExamAbdomen,ExamWeight,ExamHeight,ExamExtremities,ExamChestXRay,ExamRightEye,ExamLeftEye,ExamRightEar,ExamLeftEar," &
                "FinalResultStatus,Remarks " &
                "FROM MedicalFitnessReport " &
                "WHERE InvoiceNo = @InvoiceNo"

            Dim report = _ispDataDb.Read(sql, MakeReport, "@InvoiceNo", invoiceNo).FirstOrDefault()
            If report IsNot Nothing Then
                report.Details = GetReportDetails(report.IdNo)
            End If
            Return report
        End Function

        Public Function GetRecordByIdNo(idNo As Int32) As MedicalFitnessReport
            Dim sql As String =
                "SELECT IdNo,InvoiceNo,ReportFormat,MedicalReportFormatIdNo,InvoiceDate,FileNo,PatientName,CompanyName,PassportNo,Gender,Age,Nationality,IdentityNo,DoctorName,BloodType," &
                "ExamTemperature,ExamBloodPressure,ExamPulse,ExamRespiratorySystem,ExamCardiovascularSystem,ExamNervousSystem," &
                "ExamAbdomen,ExamWeight,ExamHeight,ExamExtremities,ExamChestXRay,ExamRightEye,ExamLeftEye,ExamRightEar,ExamLeftEar," &
                "FinalResultStatus,Remarks " &
                "FROM MedicalFitnessReport " &
                "WHERE IdNo = @IdNo"

            Dim report = _ispDataDb.Read(sql, MakeReport, "@IdNo", idNo).FirstOrDefault()
            If report IsNot Nothing Then
                report.Details = GetReportDetails(report.IdNo)
            End If
            Return report
        End Function

        Public Function GetReportPrintDataSet(invoiceNo As Int32) As DataSet
            Dim dataSet As New DataSet()

            Dim headerTable = _ispDataDb.SqlReadDataTable(
                "SELECT IdNo,InvoiceNo,ReportFormat,MedicalReportFormatIdNo,InvoiceDate,FileNo,PatientName,Gender,Age,Nationality,IdentityNo,DoctorName,BloodType," &
                "FinalResultStatus,Remarks,UserID,DateCreated,MachineID,ExamTemperature,ExamBloodPressure,ExamPulse," &
                "ExamRespiratorySystem,ExamCardiovascularSystem,ExamNervousSystem,ExamAbdomen,ExamWeight,ExamHeight," &
                "ExamExtremities,ExamChestXRay,ExamRightEye,ExamLeftEye,ExamRightEar,ExamLeftEar,CompanyName,PassportNo " &
                "FROM dbo.MedicalFitnessReport " &
                "WHERE InvoiceNo = @InvoiceNo",
                "@InvoiceNo", invoiceNo)
            headerTable.TableName = "MedicalFitnessReport"
            dataSet.Tables.Add(headerTable)

            Dim detailTable = _ispDataDb.SqlReadDataTable(
                "SELECT d.IdNo,d.MedicalFitnessReportIdNo,d.SectionCode,d.TestCode," &
                "CASE WHEN UPPER(LTRIM(RTRIM(d.SectionCode))) = 'LAB' THEN " &
                "COALESCE(NULLIF(LTRIM(RTRIM(li.EnglishNameOverride)),N'')," &
                "NULLIF(LTRIM(RTRIM(li.TestNameEnglish)),N''),d.TestNameEnglish) ELSE d.TestNameEnglish END AS TestNameEnglish," &
                "CASE WHEN UPPER(LTRIM(RTRIM(d.SectionCode))) = 'LAB' THEN " &
                "COALESCE(NULLIF(LTRIM(RTRIM(li.ArabicNameOverride)),N''),d.TestNameArabic) ELSE d.TestNameArabic END AS TestNameArabic," &
                "d.DisplayOrder,d.ResultStatus," &
                "d.ResultText AS ResultText," &
                "d.Remarks,d.[Sequence],d.LabResult,d.LabReferenceValue," &
                "d.LabUnit,d.LabAssessment,d.ResultStatusSource " &
                "FROM dbo.MedicalFitnessReportTestResult d " &
                "INNER JOIN dbo.MedicalFitnessReport h ON h.IdNo = d.MedicalFitnessReportIdNo " &
                "LEFT JOIN dbo.MedicalFitnessReportLabTemplate li ON " &
                "(UPPER(LTRIM(RTRIM(li.TestCode))) = UPPER(LTRIM(RTRIM(d.TestCode))) OR " &
                "UPPER(LTRIM(RTRIM(li.TestCode))) = UPPER(CASE " &
                "WHEN LTRIM(RTRIM(d.TestCode)) LIKE N'Item[_]%' " &
                "THEN SUBSTRING(LTRIM(RTRIM(d.TestCode)),6,1000) " &
                "ELSE N'Item_' + LTRIM(RTRIM(d.TestCode)) END)) " &
                "AND li.Active = 1 " &
                "WHERE h.InvoiceNo = @InvoiceNo " &
                "ORDER BY d.[Sequence],d.IdNo",
                "@InvoiceNo", invoiceNo)
            detailTable.TableName = "MedicalFitnessReportTestResult"
            dataSet.Tables.Add(detailTable)

            ' The standard Crystal report uses the exam-template table for the
            ' unit displayed beside a test name/result.  Keep the table in the
            ' in-memory dataset with the same name used by the .rpt file.
            Dim examTemplateTable = _ispDataDb.SqlReadDataTable(
                "SELECT IdNo,TestCode,TestNameEnglish,TestNameArabic,Unit,DisplayOrder,InputMode," &
                "IsRequired,Active,DefaultValue,SectionCode " &
                "FROM dbo.MedicalFitnessReportExamTemplate " &
                "WHERE Active = 1 " &
                "ORDER BY DisplayOrder,TestNameEnglish")
            examTemplateTable.TableName = "MedicalFitnessReportExamTemplate"
            dataSet.Tables.Add(examTemplateTable)

            ' The medical report must print saved Entry Results and explicit
            ' Fit/Unfit decisions, not analyzer/Kizen results.  Remove blank
            ' rows from this print-only DataSet so the behavior remains correct
            ' even when an older copy of the Crystal report is loaded by a
            ' client.
            Dim rowsToRemove As New List(Of DataRow)
            For Each detailRow As DataRow In detailTable.Rows
                Dim entryResult = If(detailRow.IsNull("ResultText"), "", Convert.ToString(detailRow("ResultText"))).Trim()
                Dim resultStatus = If(detailRow.IsNull("ResultStatus"), "", Convert.ToString(detailRow("ResultStatus"))).Trim().ToUpperInvariant()
                If entryResult = "" AndAlso resultStatus <> "F" AndAlso resultStatus <> "U" Then
                    rowsToRemove.Add(detailRow)
                    Continue For
                End If

                Dim sectionCode = If(detailRow.IsNull("SectionCode"), "", Convert.ToString(detailRow("SectionCode")))
                If String.Equals(sectionCode, "LAB", StringComparison.OrdinalIgnoreCase) Then
                    ' Prevent stale Crystal formulas from falling back to
                    ' Kizen result, reference value, or assessment columns.
                    ' LabUnit is display metadata and must remain available
                    ' when an Entry Result exists (for example, 87 mg/dL).
                    detailRow("LabResult") = If(entryResult = "", DBNull.Value, entryResult)
                    detailRow("LabReferenceValue") = DBNull.Value
                    detailRow("LabAssessment") = DBNull.Value
                End If
            Next
            For Each rowToRemove In rowsToRemove
                detailTable.Rows.Remove(rowToRemove)
            Next

            Return dataSet
        End Function

        Public Function GetKizenInvoice(invoiceNo As Int32) As MedicalFitnessReport
            Dim sql As String =
                "SELECT TOP (1) " &
                "i.ID AS InvoiceNo, " &
                "i.Date AS InvoiceDate, " &
                "i.CustID AS FileNo, " &
                "i.CustName AS PatientName, " &
                "(SELECT TOP (1) v.CompanyName FROM dbo.Invoices_View v " &
                " WHERE v.InvoiceNo = i.ID AND NULLIF(LTRIM(RTRIM(v.CompanyName)), N'') IS NOT NULL) AS CompanyName, " &
                "c.CustGender AS Gender, " &
                "c.CustBirthday AS BirthDate, " &
                "dbo.DateToAge(c.CustBirthday, i.Date) AS AgeLong, " &
                "i.CustNat AS Nationality, " &
                "i.CustIdentity AS IdentityNo, " &
                "i.DrName AS DoctorName, " &
                "vitalTemperature.Txt AS ExamTemperature, " &
                "vitalBloodPressure.Txt AS ExamBloodPressure, " &
                "vitalPulse.Txt AS ExamPulse, " &
                "vitalWeight.Txt AS ExamWeight, " &
                "vitalHeight.Txt AS ExamHeight " &
                "FROM dbo.A1_Invoces i " &
                "LEFT JOIN dbo.Customers c ON i.CustID = c.CustID " &
                "OUTER APPLY (" &
                " SELECT TOP (1) v.ID AS VisitID " &
                " FROM dbo.VisitData v " &
                " WHERE v.CustID = i.CustID " &
                " AND v.Date = CONVERT(date, i.Date) " &
                " AND EXISTS (" &
                "  SELECT 1 FROM dbo.VisitInput vitalInput " &
                "  INNER JOIN dbo.VisitType vitalType ON vitalType.ID = vitalInput.VisitTypeID " &
                "  WHERE vitalInput.VisitID = v.ID " &
                "  AND NULLIF(LTRIM(RTRIM(vitalInput.Txt)), N'') IS NOT NULL " &
                "  AND LOWER(LTRIM(RTRIM(vitalType.NameLatin))) IN " &
                "      (N'temperature', N'blood pressure', N'heart beat', N'heart beat rate', N'heart rate', N'pulse rate', N'weight', N'height', N'length')" &
                " ) " &
                " ORDER BY CASE WHEN v.DrID = i.DrID THEN 0 ELSE 1 END, " &
                " ABS(DATEDIFF(second, i.Date, CAST(v.Date AS datetime) + CAST(ISNULL(v.Time, CAST('00:00:00' AS time)) AS datetime))), " &
                " v.ID DESC" &
                ") vitalVisit " &
                "OUTER APPLY (" &
                " SELECT TOP (1) NULLIF(LTRIM(RTRIM(vi.Txt)), N'') AS Txt " &
                " FROM dbo.VisitInput vi INNER JOIN dbo.VisitType vt ON vt.ID = vi.VisitTypeID " &
                " WHERE vi.VisitID = vitalVisit.VisitID " &
                " AND LOWER(LTRIM(RTRIM(vt.NameLatin))) = N'temperature' " &
                " ORDER BY vi.ID DESC" &
                ") vitalTemperature " &
                "OUTER APPLY (" &
                " SELECT TOP (1) NULLIF(LTRIM(RTRIM(vi.Txt)), N'') AS Txt " &
                " FROM dbo.VisitInput vi INNER JOIN dbo.VisitType vt ON vt.ID = vi.VisitTypeID " &
                " WHERE vi.VisitID = vitalVisit.VisitID " &
                " AND LOWER(LTRIM(RTRIM(vt.NameLatin))) = N'blood pressure' " &
                " ORDER BY vi.ID DESC" &
                ") vitalBloodPressure " &
                "OUTER APPLY (" &
                " SELECT TOP (1) NULLIF(LTRIM(RTRIM(vi.Txt)), N'') AS Txt " &
                " FROM dbo.VisitInput vi INNER JOIN dbo.VisitType vt ON vt.ID = vi.VisitTypeID " &
                " WHERE vi.VisitID = vitalVisit.VisitID " &
                " AND LOWER(LTRIM(RTRIM(vt.NameLatin))) IN (N'heart beat', N'heart beat rate', N'heart rate', N'pulse rate') " &
                " ORDER BY vi.ID DESC" &
                ") vitalPulse " &
                "OUTER APPLY (" &
                " SELECT TOP (1) NULLIF(LTRIM(RTRIM(vi.Txt)), N'') AS Txt " &
                " FROM dbo.VisitInput vi INNER JOIN dbo.VisitType vt ON vt.ID = vi.VisitTypeID " &
                " WHERE vi.VisitID = vitalVisit.VisitID " &
                " AND LOWER(LTRIM(RTRIM(vt.NameLatin))) = N'weight' " &
                " ORDER BY vi.ID DESC" &
                ") vitalWeight " &
                "OUTER APPLY (" &
                " SELECT TOP (1) NULLIF(LTRIM(RTRIM(vi.Txt)), N'') AS Txt " &
                " FROM dbo.VisitInput vi INNER JOIN dbo.VisitType vt ON vt.ID = vi.VisitTypeID " &
                " WHERE vi.VisitID = vitalVisit.VisitID " &
                " AND LOWER(LTRIM(RTRIM(vt.NameLatin))) IN (N'height', N'length') " &
                " ORDER BY vi.ID DESC" &
                ") vitalHeight " &
                "WHERE i.ID = @InvoiceNo"

            Return _kizenDb.Read(sql, MakeKizenInvoice, "@InvoiceNo", invoiceNo).FirstOrDefault()
        End Function

        Public Function GetPatientInvoiceSearchResults(searchValue As String) As List(Of MedicalFitnessReportInvoiceSearchResult)
            If String.IsNullOrWhiteSpace(searchValue) Then
                Return New List(Of MedicalFitnessReportInvoiceSearchResult)()
            End If

            Dim sql As String =
                "SELECT i.ID AS InvoiceNo, i.Date AS InvoiceDate, " &
                "CONVERT(nvarchar(100), i.CustID) AS FileNo, " &
                "i.CustName AS PatientName, " &
                "CONVERT(nvarchar(100), i.CustIdentity) AS IdentityNo " &
                "FROM dbo.A1_Invoces i " &
                "WHERE LTRIM(RTRIM(CONVERT(nvarchar(100), i.CustID))) = LTRIM(RTRIM(@SearchValue)) " &
                "OR LTRIM(RTRIM(CONVERT(nvarchar(100), i.CustIdentity))) = LTRIM(RTRIM(@SearchValue)) " &
                "ORDER BY i.Date DESC, i.ID DESC"

            Return _kizenDb.Read(
                sql,
                MakePatientInvoiceSearchResult,
                "@SearchValue", searchValue.Trim()).ToList()
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

        ''' <summary>
        ''' Reads the selected analysis and all of its visible descendants directly from Kizen.
        ''' This method is intentionally read-only and never writes to the Kizen database.
        ''' </summary>
        Public Function GetKizenGroupedLabResults(invoiceNo As Int32, testCode As String) As List(Of MedicalFitnessGroupedLabResult)
            If invoiceNo = 0 OrElse String.IsNullOrWhiteSpace(testCode) Then
                Return New List(Of MedicalFitnessGroupedLabResult)()
            End If

            Dim sql As String =
                "WITH SourceRows AS (" &
                "SELECT d.ID AS VisitAnalysesID, r.ID, " &
                "COALESCE(NULLIF(CONVERT(nvarchar(1000), LTRIM(RTRIM(r.Code))), N''), N'KIZEN_' + CONVERT(nvarchar(20), r.ID)) AS TestCode, " &
                "CONVERT(nvarchar(1000), LTRIM(RTRIM(r.Code))) AS ResultCode, " &
                "CONVERT(nvarchar(1000), LTRIM(RTRIM(r.Parent))) AS ParentCode, " &
                "CONVERT(nvarchar(1000), LTRIM(RTRIM(r.Name))) AS TestName, " &
                "CONVERT(nvarchar(max), r.Data) AS ResultValue, " &
                "CONVERT(nvarchar(max), r.RV) AS ReferenceValue, " &
                "CONVERT(nvarchar(100), r.Unit) AS UnitValue " &
                "FROM dbo.VisitAnalysesData d " &
                "INNER JOIN dbo.VisitAnalysesResult r ON r.VisitAnalysesID = d.ID " &
                "WHERE d.OrderID = @InvoiceNo " &
                "AND ISNULL(r.IsHide, 0) = 0 " &
                "AND NULLIF(CONVERT(nvarchar(1000), LTRIM(RTRIM(r.Name))), N'') IS NOT NULL), " &
                "RankedRoots AS (" &
                "SELECT source.*, ROW_NUMBER() OVER (ORDER BY source.VisitAnalysesID DESC, source.ID DESC) AS RootNumber " &
                "FROM SourceRows source " &
                "WHERE UPPER(source.TestCode) = UPPER(LTRIM(RTRIM(@TestCode))) " &
                "OR UPPER(source.TestCode) = UPPER(CASE " &
                "WHEN LTRIM(RTRIM(@TestCode)) LIKE N'Item[_]%' " &
                "THEN SUBSTRING(LTRIM(RTRIM(@TestCode)), 6, 1000) " &
                "ELSE N'Item_' + LTRIM(RTRIM(@TestCode)) END)), " &
                "SelectedRoot AS (" &
                "SELECT * FROM RankedRoots WHERE RootNumber = 1), " &
                "ChildRows AS (" &
                "SELECT child.ID, child.TestCode, child.TestName, child.ResultValue, child.ReferenceValue, child.UnitValue, " &
                "CASE WHEN LEN(child.ParentCode) > LEN(root.ResultCode) + 1 " &
                "THEN REPLACE(REPLACE(SUBSTRING(child.ParentCode, LEN(root.ResultCode) + 2, 1000), N'PropertyGroup_', N''), N'_', N' ') " &
                "ELSE root.TestName END AS GroupName " &
                "FROM SourceRows child " &
                "INNER JOIN SelectedRoot root ON root.VisitAnalysesID = child.VisitAnalysesID " &
                "WHERE NULLIF(root.ResultCode, N'') IS NOT NULL " &
                "AND LEFT(child.ParentCode, LEN(root.ResultCode) + 1) = root.ResultCode + N'_'), " &
                "DisplayRows AS (" &
                "SELECT ID, TestCode, TestName, ResultValue, ReferenceValue, UnitValue, GroupName FROM ChildRows " &
                "UNION ALL " &
                "SELECT root.ID, root.TestCode, root.TestName, root.ResultValue, root.ReferenceValue, root.UnitValue, root.TestName " &
                "FROM SelectedRoot root WHERE NOT EXISTS (SELECT 1 FROM ChildRows)) " &
                "SELECT CONVERT(int, ROW_NUMBER() OVER (ORDER BY ID)) AS Sequence, " &
                "GroupName, TestCode, TestName, ResultValue, ReferenceValue, UnitValue " &
                "FROM DisplayRows ORDER BY ID"

            Return _kizenDb.Read(
                sql,
                MakeKizenGroupedLabResult,
                "@InvoiceNo", invoiceNo,
                "@TestCode", testCode.Trim()).ToList()
        End Function

        Public Function GetActiveLabTemplates() As List(Of MedicalFitnessReportLabTemplate)
            Return GetLabTemplates(False)
        End Function

        Public Function GetLabTemplates(Optional includeInactive As Boolean = False) As List(Of MedicalFitnessReportLabTemplate)
            Dim sql As String =
                "SELECT IdNo,TestCode,TestNameEnglish,TestNameArabic,EnglishNameOverride,ArabicNameOverride," &
                "COALESCE(NULLIF(LTRIM(RTRIM(EnglishNameOverride)),N'')," &
                "NULLIF(LTRIM(RTRIM(TestNameEnglish)),N''),TestCode) AS EffectiveTestNameEnglish," &
                "COALESCE(NULLIF(LTRIM(RTRIM(ArabicNameOverride)),N''),TestNameArabic) AS EffectiveTestNameArabic," &
                "DisplayOrder,CopyResultToEntry,Active " &
                "FROM MedicalFitnessReportLabTemplate " &
                "WHERE @IncludeInactive = 1 OR Active = 1 " &
                "ORDER BY DisplayOrder, TestNameEnglish"

            Return _ispDataDb.Read(sql, MakeLabTemplate,
                                   "@IncludeInactive", If(includeInactive, 1, 0)).ToList()
        End Function

        Public Function GetLabTemplateByCode(testCode As String) As MedicalFitnessReportLabTemplate
            If String.IsNullOrWhiteSpace(testCode) Then
                Return Nothing
            End If

            Dim sql As String =
                "SELECT TOP (1) IdNo,TestCode,TestNameEnglish,TestNameArabic,EnglishNameOverride,ArabicNameOverride," &
                "COALESCE(NULLIF(LTRIM(RTRIM(EnglishNameOverride)),N'')," &
                "NULLIF(LTRIM(RTRIM(TestNameEnglish)),N''),TestCode) AS EffectiveTestNameEnglish," &
                "COALESCE(NULLIF(LTRIM(RTRIM(ArabicNameOverride)),N''),TestNameArabic) AS EffectiveTestNameArabic," &
                "DisplayOrder,CopyResultToEntry,Active " &
                "FROM MedicalFitnessReportLabTemplate " &
                "WHERE UPPER(LTRIM(RTRIM(TestCode))) = UPPER(LTRIM(RTRIM(@TestCode)))"
            Return _ispDataDb.Read(sql, MakeLabTemplate, "@TestCode", testCode.Trim()).FirstOrDefault()
        End Function

        Public Function GetKizenLabItems() As List(Of MedicalFitnessReportKizenLabItem)
            Dim sql As String =
                "SELECT CONVERT(nvarchar(255), LTRIM(RTRIM(w.Code))) AS Code, " &
                "CONVERT(nvarchar(255), LTRIM(RTRIM(w.Name))) AS Name " &
                "FROM dbo.A1_Works w " &
                "WHERE LTRIM(RTRIM(CONVERT(nvarchar(max), w.[Group]))) = @LabGroup " &
                "AND NULLIF(LTRIM(RTRIM(CONVERT(nvarchar(255), w.Code))), N'') IS NOT NULL " &
                "AND NULLIF(LTRIM(RTRIM(CONVERT(nvarchar(255), w.Name))), N'') IS NOT NULL " &
                "ORDER BY w.Name, w.Code"

            Return _kizenDb.Read(
                sql,
                MakeKizenLabItem,
                "@LabGroup", "Laboratory تحاليل المختبر").ToList()
        End Function

        Public Function GetKizenLabTestName(testCode As String) As String
            If String.IsNullOrWhiteSpace(testCode) Then
                Return ""
            End If

            ' Kizen stores the laboratory item catalog in A1_Works.  Its
            ' catalog code is normally Lxxx, while result rows commonly use
            ' Item_Lxxx.  Read the catalog first, then fall back to a result
            ' row for installations where the catalog row is unavailable.
            Dim sql As String =
                "SELECT TOP (1) CONVERT(nvarchar(255), LTRIM(RTRIM(w.Name))) AS TestNameEnglish " &
                "FROM dbo.A1_Works w " &
                "WHERE (UPPER(LTRIM(RTRIM(CONVERT(nvarchar(255),w.Code)))) = UPPER(LTRIM(RTRIM(@TestCode))) " &
                "OR UPPER(LTRIM(RTRIM(CONVERT(nvarchar(255),w.Code)))) = UPPER(CASE " &
                "WHEN LTRIM(RTRIM(@TestCode)) LIKE N'Item[_]%' " &
                "THEN SUBSTRING(LTRIM(RTRIM(@TestCode)),6,255) " &
                "ELSE N'Item_' + LTRIM(RTRIM(@TestCode)) END)) " &
                "AND NULLIF(LTRIM(RTRIM(CONVERT(nvarchar(255),w.Name))),N'') IS NOT NULL " &
                "ORDER BY w.ID DESC"

            Dim name = _kizenDb.Read(sql,
                                     Function(reader) Extensions.AsString(reader("TestNameEnglish")),
                                     "@TestCode", testCode.Trim()).FirstOrDefault()
            If Not String.IsNullOrWhiteSpace(name) Then
                Return name
            End If

            sql =
                "SELECT TOP (1) CONVERT(nvarchar(255), LTRIM(RTRIM(r.Name))) AS TestNameEnglish " &
                "FROM dbo.VisitAnalysesResult r " &
                "WHERE (UPPER(LTRIM(RTRIM(CONVERT(nvarchar(1000),r.Code)))) = UPPER(LTRIM(RTRIM(@TestCode))) " &
                "OR UPPER(LTRIM(RTRIM(CONVERT(nvarchar(1000),r.Code)))) = UPPER(CASE " &
                "WHEN LTRIM(RTRIM(@TestCode)) LIKE N'Item[_]%' " &
                "THEN LTRIM(RTRIM(@TestCode)) " &
                "ELSE N'Item_' + LTRIM(RTRIM(@TestCode)) END)) " &
                "AND NULLIF(LTRIM(RTRIM(CONVERT(nvarchar(255),r.Name))),N'') IS NOT NULL " &
                "ORDER BY r.ID DESC"

            Return _kizenDb.Read(sql,
                                 Function(reader) Extensions.AsString(reader("TestNameEnglish")),
                                 "@TestCode", testCode.Trim()).FirstOrDefault()
        End Function

        Public Function SaveLabTemplate(template As MedicalFitnessReportLabTemplate) As Int32
            If template.IdNo = 0 Then
                Dim sql As String =
                    "INSERT INTO MedicalFitnessReportLabTemplate " &
                    "(TestCode,TestNameEnglish,TestNameArabic,EnglishNameOverride,ArabicNameOverride,DisplayOrder,CopyResultToEntry,Active) " &
                    "VALUES (@TestCode,@TestNameEnglish,@TestNameArabic,@EnglishNameOverride,@ArabicNameOverride,@DisplayOrder,@CopyResultToEntry,@Active); " &
                    "SELECT CONVERT(int,SCOPE_IDENTITY());"
                template.IdNo = Convert.ToInt32(_ispDataDb.Scalar(sql, TakeLabTemplate(template)))
            Else
                Dim sql As String =
                    "UPDATE MedicalFitnessReportLabTemplate SET " &
                    "TestCode=@TestCode,TestNameEnglish=@TestNameEnglish,TestNameArabic=@TestNameArabic," &
                    "EnglishNameOverride=@EnglishNameOverride,ArabicNameOverride=@ArabicNameOverride," &
                    "DisplayOrder=@DisplayOrder,CopyResultToEntry=@CopyResultToEntry,Active=@Active " &
                    "WHERE IdNo=@IdNo"
                Dim parameters = TakeLabTemplate(template).ToList()
                parameters.AddRange({"@IdNo", template.IdNo})
                _ispDataDb.Update(sql, parameters.ToArray())
            End If
            Return template.IdNo
        End Function

        Public Sub DeleteLabTemplate(templateIdNo As Int32)
            If templateIdNo <= 0 Then
                Return
            End If

            _ispDataDb.Update(
                "DELETE FROM MedicalFitnessReportLabTemplate WHERE IdNo=@IdNo",
                "@IdNo", templateIdNo)
        End Sub

        Public Function GetReportFormats(Optional includeInactive As Boolean = False) As List(Of MedicalFitnessReportFormat)
            Dim sql As String =
                "SELECT MRIdNo,FormatCode,TitleEnglish,TitleArabic,CrystalReportFileName,Active,DisplayOrder,IsDefault " &
                "FROM MedicalFitnessReportFormat " &
                "WHERE @IncludeInactive = 1 OR Active = 1 " &
                "ORDER BY DisplayOrder,TitleEnglish"
            Return _ispDataDb.Read(sql, MakeReportFormat,
                                   "@IncludeInactive", If(includeInactive, 1, 0)).ToList()
        End Function

        Public Function GetReportFormat(mrIdNo As Int32) As MedicalFitnessReportFormat
            Dim sql As String =
                "SELECT MRIdNo,FormatCode,TitleEnglish,TitleArabic,CrystalReportFileName,Active,DisplayOrder,IsDefault " &
                "FROM MedicalFitnessReportFormat WHERE MRIdNo = @MRIdNo"
            Return _ispDataDb.Read(sql, MakeReportFormat, "@MRIdNo", mrIdNo).FirstOrDefault()
        End Function

        Public Function GetReportFormatByCode(formatCode As String) As MedicalFitnessReportFormat
            Dim sql As String =
                "SELECT MRIdNo,FormatCode,TitleEnglish,TitleArabic,CrystalReportFileName,Active,DisplayOrder,IsDefault " &
                "FROM MedicalFitnessReportFormat WHERE FormatCode=@FormatCode"
            Return _ispDataDb.Read(sql, MakeReportFormat, "@FormatCode", formatCode).FirstOrDefault()
        End Function

        Public Function GetDefaultReportFormat() As MedicalFitnessReportFormat
            Dim sql As String =
                "SELECT TOP (1) MRIdNo,FormatCode,TitleEnglish,TitleArabic,CrystalReportFileName,Active,DisplayOrder,IsDefault " &
                "FROM MedicalFitnessReportFormat WHERE Active = 1 " &
                "ORDER BY IsDefault DESC,DisplayOrder,MRIdNo"
            Return _ispDataDb.Read(sql, MakeReportFormat).FirstOrDefault()
        End Function

        Public Function GetReportFormatForCompany(companyName As String) As MedicalFitnessReportFormat
            If String.IsNullOrWhiteSpace(companyName) Then
                Return Nothing
            End If

            Dim sql As String =
                "SELECT TOP (1) f.MRIdNo,f.FormatCode,f.TitleEnglish,f.TitleArabic,f.CrystalReportFileName," &
                "f.Active,f.DisplayOrder,f.IsDefault " &
                "FROM MedicalFitnessReportFormatAssignment a " &
                "INNER JOIN MedicalFitnessReportFormat f ON f.MRIdNo = a.MRIdNo " &
                "WHERE a.Active = 1 AND f.Active = 1 " &
                "AND UPPER(LTRIM(RTRIM(a.CompanyName))) = UPPER(LTRIM(RTRIM(@CompanyName)))"
            Return _ispDataDb.Read(sql, MakeReportFormat, "@CompanyName", companyName).FirstOrDefault()
        End Function

        Public Function SaveReportFormat(format As MedicalFitnessReportFormat) As Int32
            If format.MRIdNo = 0 Then
                Dim sql As String =
                    "INSERT INTO MedicalFitnessReportFormat " &
                    "(FormatCode,TitleEnglish,TitleArabic,CrystalReportFileName,Active,DisplayOrder,IsDefault) " &
                    "VALUES (@FormatCode,@TitleEnglish,@TitleArabic,@CrystalReportFileName,@Active,@DisplayOrder,@IsDefault); " &
                    "SELECT CONVERT(int,SCOPE_IDENTITY());"
                format.MRIdNo = Convert.ToInt32(_ispDataDb.Scalar(sql, TakeReportFormat(format)))
            Else
                Dim sql As String =
                    "UPDATE MedicalFitnessReportFormat SET " &
                    "FormatCode=@FormatCode,TitleEnglish=@TitleEnglish,TitleArabic=@TitleArabic," &
                    "CrystalReportFileName=@CrystalReportFileName,Active=@Active,DisplayOrder=@DisplayOrder," &
                    "IsDefault=@IsDefault WHERE MRIdNo=@MRIdNo"
                Dim parameters = TakeReportFormat(format).ToList()
                parameters.AddRange({"@MRIdNo", format.MRIdNo})
                _ispDataDb.Update(sql, parameters.ToArray())
            End If

            If format.IsDefault Then
                _ispDataDb.Update(
                    "UPDATE MedicalFitnessReportFormat SET IsDefault=0 WHERE MRIdNo<>@MRIdNo",
                    "@MRIdNo", format.MRIdNo)
            End If
            Return format.MRIdNo
        End Function

        Public Function GetExamTemplatesForReportFormat(mrIdNo As Int32) As List(Of MedicalFitnessReportExamTemplate)
            Dim sql As String =
                "SELECT t.IdNo,COALESCE(i.SectionCode,t.SectionCode) AS SectionCode,t.TestCode,t.TestNameEnglish," &
                "t.TestNameArabic,t.Unit,COALESCE(i.DefaultValue,t.DefaultValue) AS DefaultValue," &
                "COALESCE(i.DisplayOrder,t.DisplayOrder) AS DisplayOrder,COALESCE(i.InputMode,t.InputMode) AS InputMode," &
                "COALESCE(i.IsRequired,t.IsRequired) AS IsRequired,t.Active " &
                "FROM MedicalFitnessReportFormatItem i " &
                "INNER JOIN MedicalFitnessReportExamTemplate t ON t.IdNo=i.ExamTemplateIdNo " &
                "WHERE i.MRIdNo=@MRIdNo AND i.Active=1 AND t.Active=1 " &
                "ORDER BY COALESCE(i.SectionCode,t.SectionCode),COALESCE(i.DisplayOrder,t.DisplayOrder),t.TestNameEnglish"
            Return _ispDataDb.Read(sql, MakeClinicalExamTemplate, "@MRIdNo", mrIdNo).ToList()
        End Function

        Public Function GetReportFormatItems(mrIdNo As Int32) As List(Of MedicalFitnessReportFormatItem)
            Dim sql As String =
                "SELECT ISNULL(i.IdNo,0) AS IdNo,@MRIdNo AS MRIdNo,t.IdNo AS ExamTemplateIdNo,t.SectionCode," &
                "t.TestCode,t.TestNameEnglish,t.TestNameArabic,t.Unit," &
                "ISNULL(i.DefaultValue,t.DefaultValue) AS DefaultValue," &
                "ISNULL(i.DisplayOrder,t.DisplayOrder) AS DisplayOrder," &
                "ISNULL(i.InputMode,t.InputMode) AS InputMode," &
                "ISNULL(i.IsRequired,t.IsRequired) AS IsRequired,ISNULL(i.Active,0) AS Active " &
                "FROM MedicalFitnessReportExamTemplate t " &
                "LEFT JOIN MedicalFitnessReportFormatItem i ON i.ExamTemplateIdNo=t.IdNo AND i.MRIdNo=@MRIdNo " &
                "ORDER BY COALESCE(i.DisplayOrder,t.DisplayOrder),t.SectionCode,t.TestNameEnglish"
            Return _ispDataDb.Read(sql, MakeReportFormatItem, "@MRIdNo", mrIdNo).ToList()
        End Function

        Public Function SaveReportFormatItem(item As MedicalFitnessReportFormatItem) As Int32
            If item.IdNo = 0 Then
                Dim sql As String =
                    "INSERT INTO MedicalFitnessReportFormatItem " &
                    "(MRIdNo,ExamTemplateIdNo,SectionCode,DisplayOrder,DefaultValue,InputMode,IsRequired,Active) " &
                    "VALUES (@MRIdNo,@ExamTemplateIdNo,@SectionCode,@DisplayOrder,@DefaultValue,@InputMode,@IsRequired,@Active); " &
                    "SELECT CONVERT(int,SCOPE_IDENTITY());"
                item.IdNo = Convert.ToInt32(_ispDataDb.Scalar(sql, TakeReportFormatItem(item)))
            Else
                Dim sql As String =
                    "UPDATE MedicalFitnessReportFormatItem SET SectionCode=@SectionCode,DisplayOrder=@DisplayOrder," &
                    "DefaultValue=@DefaultValue,InputMode=@InputMode,IsRequired=@IsRequired,Active=@Active " &
                    "WHERE IdNo=@IdNo"
                Dim parameters = TakeReportFormatItem(item).ToList()
                parameters.AddRange({"@IdNo", item.IdNo})
                _ispDataDb.Update(sql, parameters.ToArray())
            End If
            Return item.IdNo
        End Function

        Public Function GetReportFormatAssignments() As List(Of MedicalFitnessReportFormatAssignment)
            Dim sql As String =
                "SELECT a.IdNo,a.CompanyName,a.MRIdNo,f.TitleEnglish AS FormatTitle,a.Active " &
                "FROM MedicalFitnessReportFormatAssignment a " &
                "LEFT JOIN MedicalFitnessReportFormat f ON f.MRIdNo=a.MRIdNo " &
                "ORDER BY a.CompanyName"
            Return _ispDataDb.Read(sql, MakeReportFormatAssignment).ToList()
        End Function

        Public Function SaveReportFormatAssignment(assignment As MedicalFitnessReportFormatAssignment) As Int32
            If assignment.IdNo = 0 Then
                Dim sql As String =
                    "INSERT INTO MedicalFitnessReportFormatAssignment (CompanyName,MRIdNo,Active) " &
                    "VALUES (@CompanyName,@MRIdNo,@Active); SELECT CONVERT(int,SCOPE_IDENTITY());"
                assignment.IdNo = Convert.ToInt32(_ispDataDb.Scalar(sql, TakeReportFormatAssignment(assignment)))
            Else
                Dim sql As String =
                    "UPDATE MedicalFitnessReportFormatAssignment SET CompanyName=@CompanyName,MRIdNo=@MRIdNo,Active=@Active " &
                    "WHERE IdNo=@IdNo"
                Dim parameters = TakeReportFormatAssignment(assignment).ToList()
                parameters.AddRange({"@IdNo", assignment.IdNo})
                _ispDataDb.Update(sql, parameters.ToArray())
            End If
            Return assignment.IdNo
        End Function

        Public Function GetClinicalExamTemplates(Optional includeInactive As Boolean = False) As List(Of MedicalFitnessReportExamTemplate)
            Return GetExamTemplates("CLINICAL", includeInactive)
        End Function

        Public Function GetXRayExamTemplates(Optional includeInactive As Boolean = False) As List(Of MedicalFitnessReportExamTemplate)
            Return GetExamTemplates("XRAY", includeInactive)
        End Function

        Public Function GetExamTemplates(sectionCode As String,
                                         Optional includeInactive As Boolean = False) As List(Of MedicalFitnessReportExamTemplate)
            Dim sql As String =
                "SELECT IdNo,SectionCode,TestCode,TestNameEnglish,TestNameArabic,Unit,DefaultValue,DisplayOrder,InputMode,IsRequired,Active " &
                "FROM MedicalFitnessReportExamTemplate " &
                "WHERE SectionCode = @SectionCode AND (@IncludeInactive = 1 OR Active = 1) " &
                "ORDER BY DisplayOrder, TestNameEnglish"

            Return _ispDataDb.Read(
                sql,
                MakeClinicalExamTemplate,
                "@SectionCode", sectionCode,
                "@IncludeInactive", If(includeInactive, 1, 0)).ToList()
        End Function

        Public Function SaveClinicalExamTemplate(template As MedicalFitnessReportExamTemplate) As Int32
            If template.IdNo = 0 Then
                Dim sql As String =
                    "INSERT INTO MedicalFitnessReportExamTemplate " &
                    "(SectionCode,TestCode,TestNameEnglish,TestNameArabic,Unit,DefaultValue,DisplayOrder,InputMode,IsRequired,Active) " &
                    "VALUES " &
                    "(@SectionCode,@TestCode,@TestNameEnglish,@TestNameArabic,@Unit,@DefaultValue,@DisplayOrder,@InputMode,@IsRequired,@Active); " &
                    "SELECT CONVERT(int, SCOPE_IDENTITY());"

                template.IdNo = Convert.ToInt32(_ispDataDb.Scalar(sql, TakeClinicalExamTemplate(template)))
            Else
                Dim sql As String =
                    "UPDATE MedicalFitnessReportExamTemplate SET " &
                    "SectionCode = @SectionCode, " &
                    "TestCode = @TestCode, " &
                    "TestNameEnglish = @TestNameEnglish, " &
                    "TestNameArabic = @TestNameArabic, " &
                    "Unit = @Unit, " &
                    "DefaultValue = @DefaultValue, " &
                    "DisplayOrder = @DisplayOrder, " &
                    "InputMode = @InputMode, " &
                    "IsRequired = @IsRequired, " &
                    "Active = @Active " &
                    "WHERE IdNo = @IdNo"

                Dim parameters = TakeClinicalExamTemplate(template).ToList()
                parameters.AddRange({"@IdNo", template.IdNo})
                _ispDataDb.Update(sql, parameters.ToArray())
            End If

            Return template.IdNo
        End Function

        Public Function DeleteExamTemplate(templateIdNo As Int32) As Int32
            If templateIdNo <= 0 Then
                Return 0
            End If

            Dim sql As String =
                "DELETE FROM MedicalFitnessReportExamTemplate " &
                "WHERE IdNo=@IdNo " &
                "AND NOT EXISTS (" &
                "SELECT 1 FROM MedicalFitnessReportFormatItem WHERE ExamTemplateIdNo=@IdNo)"
            Return _ispDataDb.Update(sql, "@IdNo", templateIdNo)
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
                "(InvoiceNo,ReportFormat,MedicalReportFormatIdNo,InvoiceDate,FileNo,PatientName,CompanyName,PassportNo,Gender,Age,Nationality,IdentityNo,DoctorName,BloodType," &
                "ExamTemperature,ExamBloodPressure,ExamPulse,ExamRespiratorySystem,ExamCardiovascularSystem,ExamNervousSystem," &
                "ExamAbdomen,ExamWeight,ExamHeight,ExamExtremities,ExamChestXRay,ExamRightEye,ExamLeftEye,ExamRightEar,ExamLeftEar," &
                "FinalResultStatus,Remarks) " &
                "VALUES " &
                "(@InvoiceNo,@ReportFormat,@MedicalReportFormatIdNo,@InvoiceDate,@FileNo,@PatientName,@CompanyName,@PassportNo,@Gender,@Age,@Nationality,@IdentityNo,@DoctorName,@BloodType," &
                "@ExamTemperature,@ExamBloodPressure,@ExamPulse,@ExamRespiratorySystem,@ExamCardiovascularSystem,@ExamNervousSystem," &
                "@ExamAbdomen,@ExamWeight,@ExamHeight,@ExamExtremities,@ExamChestXRay,@ExamRightEye,@ExamLeftEye,@ExamRightEar,@ExamLeftEar," &
                "@FinalResultStatus,@Remarks); " &
                "SELECT CONVERT(int, SCOPE_IDENTITY());"

            Return Convert.ToInt32(_ispDataDb.Scalar(sql, TakeReport(report)))
        End Function

        Private Function UpdateReport(report As MedicalFitnessReport) As Int32
            Dim sql As String =
                "UPDATE MedicalFitnessReport SET " &
                "InvoiceNo = @InvoiceNo, " &
                "ReportFormat = @ReportFormat, " &
                "MedicalReportFormatIdNo = @MedicalReportFormatIdNo, " &
                "InvoiceDate = @InvoiceDate, " &
                "FileNo = @FileNo, " &
                "PatientName = @PatientName, " &
                "CompanyName = @CompanyName, " &
                "PassportNo = @PassportNo, " &
                "Gender = @Gender, " &
                "Age = @Age, " &
                "Nationality = @Nationality, " &
                "IdentityNo = @IdentityNo, " &
                "DoctorName = @DoctorName, " &
                "BloodType = @BloodType, " &
                "ExamTemperature = @ExamTemperature, " &
                "ExamBloodPressure = @ExamBloodPressure, " &
                "ExamPulse = @ExamPulse, " &
                "ExamRespiratorySystem = @ExamRespiratorySystem, " &
                "ExamCardiovascularSystem = @ExamCardiovascularSystem, " &
                "ExamNervousSystem = @ExamNervousSystem, " &
                "ExamAbdomen = @ExamAbdomen, " &
                "ExamWeight = @ExamWeight, " &
                "ExamHeight = @ExamHeight, " &
                "ExamExtremities = @ExamExtremities, " &
                "ExamChestXRay = @ExamChestXRay, " &
                "ExamRightEye = @ExamRightEye, " &
                "ExamLeftEye = @ExamLeftEye, " &
                "ExamRightEar = @ExamRightEar, " &
                "ExamLeftEar = @ExamLeftEar, " &
                "FinalResultStatus = @FinalResultStatus, " &
                "Remarks = @Remarks " &
                "WHERE IdNo = @IdNo"

            Dim params = TakeReport(report).ToList()
            params.AddRange({"@IdNo", report.IdNo})
            Return _ispDataDb.Update(sql, params.ToArray())
        End Function

        Private Sub ReplaceDetails(report As MedicalFitnessReport)
            If report.Details Is Nothing Then
                _ispDataDb.Update("DELETE FROM MedicalFitnessReportTestResult WHERE MedicalFitnessReportIdNo = @IdNo", "@IdNo", report.IdNo)
                Return
            End If

            For Each detail In report.Details
                detail.MedicalFitnessReportIdNo = report.IdNo
                detail.SectionCode = GetRequiredSectionCode(detail)
                If String.IsNullOrWhiteSpace(detail.TestCode) Then
                    Throw New InvalidOperationException("A medical fitness result is missing its test code.")
                End If
                If String.IsNullOrWhiteSpace(detail.TestNameEnglish) Then
                    Throw New InvalidOperationException("A medical fitness result is missing its test name.")
                End If
            Next

            ' Validate and normalize every row before removing the saved details so
            ' invalid input cannot leave a report with all of its rows deleted.
            _ispDataDb.Update("DELETE FROM MedicalFitnessReportTestResult WHERE MedicalFitnessReportIdNo = @IdNo", "@IdNo", report.IdNo)

            For Each detail In report.Details
                InsertDetail(detail)
            Next
        End Sub

        Private Shared Function GetRequiredSectionCode(detail As MedicalFitnessReportTestResult) As String
            If Not String.IsNullOrWhiteSpace(detail.SectionCode) Then
                Return detail.SectionCode.Trim()
            End If

            Select Case If(detail.TestCode, "").Trim().ToUpperInvariant()
                Case "ECG", "AUDIOMETRY", "SPIROMETRY"
                    Return "DETAIL"
                Case Else
                    Dim hasLabData = detail.Sequence >= 200 OrElse
                                     Not String.IsNullOrWhiteSpace(detail.LabResult) OrElse
                                     Not String.IsNullOrWhiteSpace(detail.LabReferenceValue) OrElse
                                     Not String.IsNullOrWhiteSpace(detail.LabUnit)
                    Return If(hasLabData, "LAB", "CLINICAL")
            End Select
        End Function

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
                "@ReportFormat", If(String.IsNullOrWhiteSpace(report.ReportFormat), "STANDARD", report.ReportFormat),
                "@MedicalReportFormatIdNo", If(report.MedicalReportFormatIdNo = 0, DBNull.Value, report.MedicalReportFormatIdNo),
                "@InvoiceDate", DbValue(report.InvoiceDate),
                "@FileNo", DbValue(report.FileNo),
                "@PatientName", DbValue(report.PatientName),
                "@CompanyName", DbValue(report.CompanyName),
                "@PassportNo", DbValue(report.PassportNo),
                "@Gender", DbValue(report.Gender),
                "@Age", DbValue(report.Age),
                "@Nationality", DbValue(report.Nationality),
                "@IdentityNo", DbValue(report.IdentityNo),
                "@DoctorName", DbValue(report.DoctorName),
                "@BloodType", DbValue(report.BloodType),
                "@ExamTemperature", DbValue(report.ExamTemperature),
                "@ExamBloodPressure", DbValue(report.ExamBloodPressure),
                "@ExamPulse", DbValue(report.ExamPulse),
                "@ExamRespiratorySystem", DbValue(report.ExamRespiratorySystem),
                "@ExamCardiovascularSystem", DbValue(report.ExamCardiovascularSystem),
                "@ExamNervousSystem", DbValue(report.ExamNervousSystem),
                "@ExamAbdomen", DbValue(report.ExamAbdomen),
                "@ExamWeight", DbValue(report.ExamWeight),
                "@ExamHeight", DbValue(report.ExamHeight),
                "@ExamExtremities", DbValue(report.ExamExtremities),
                "@ExamChestXRay", DbValue(report.ExamChestXRay),
                "@ExamRightEye", DbValue(report.ExamRightEye),
                "@ExamLeftEye", DbValue(report.ExamLeftEye),
                "@ExamRightEar", DbValue(report.ExamRightEar),
                "@ExamLeftEar", DbValue(report.ExamLeftEar),
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

        Private Shared Function TakeReportFormat(format As MedicalFitnessReportFormat) As Object()
            Return New Object() {
                "@FormatCode", format.FormatCode,
                "@TitleEnglish", format.TitleEnglish,
                "@TitleArabic", DbValue(format.TitleArabic),
                "@CrystalReportFileName", format.CrystalReportFileName,
                "@Active", format.Active,
                "@DisplayOrder", format.DisplayOrder,
                "@IsDefault", format.IsDefault}
        End Function

        Private Shared Function TakeReportFormatItem(item As MedicalFitnessReportFormatItem) As Object()
            Return New Object() {
                "@MRIdNo", item.MRIdNo,
                "@ExamTemplateIdNo", item.ExamTemplateIdNo,
                "@SectionCode", item.SectionCode,
                "@DisplayOrder", If(item.DisplayOrder <= 0, DBNull.Value, item.DisplayOrder),
                "@DefaultValue", DbValue(item.DefaultValue),
                "@InputMode", DbValue(item.InputMode),
                "@IsRequired", item.IsRequired,
                "@Active", item.Active}
        End Function

        Private Shared Function TakeReportFormatAssignment(assignment As MedicalFitnessReportFormatAssignment) As Object()
            Return New Object() {
                "@CompanyName", assignment.CompanyName,
                "@MRIdNo", assignment.MRIdNo,
                "@Active", assignment.Active}
        End Function

        Private Shared Function TakeLabTemplate(template As MedicalFitnessReportLabTemplate) As Object()
            Return New Object() {
                "@TestCode", template.TestCode,
                "@TestNameEnglish", DbValue(template.TestNameEnglish),
                "@TestNameArabic", DbValue(template.TestNameArabic),
                "@EnglishNameOverride", DbValue(template.EnglishNameOverride),
                "@ArabicNameOverride", DbValue(template.ArabicNameOverride),
                "@DisplayOrder", template.DisplayOrder,
                "@CopyResultToEntry", template.CopyResultToEntry,
                "@Active", template.Active}
        End Function

        Private Shared ReadOnly MakeReportFormat As Func(Of IDataReader, MedicalFitnessReportFormat) =
            Function(reader) New MedicalFitnessReportFormat() With {
                .MRIdNo = Extensions.AsInt(Of Int32)(reader("MRIdNo")),
                .FormatCode = Extensions.AsString(reader("FormatCode")),
                .TitleEnglish = Extensions.AsString(reader("TitleEnglish")),
                .TitleArabic = Extensions.AsString(reader("TitleArabic")),
                .CrystalReportFileName = Extensions.AsString(reader("CrystalReportFileName")),
                .Active = Convert.ToBoolean(reader("Active")),
                .DisplayOrder = Extensions.AsInt(Of Int32)(reader("DisplayOrder")),
                .IsDefault = Convert.ToBoolean(reader("IsDefault"))}

        Private Shared ReadOnly MakeReportFormatItem As Func(Of IDataReader, MedicalFitnessReportFormatItem) =
            Function(reader) New MedicalFitnessReportFormatItem() With {
                .IdNo = Extensions.AsInt(Of Int32)(reader("IdNo")),
                .MRIdNo = Extensions.AsInt(Of Int32)(reader("MRIdNo")),
                .ExamTemplateIdNo = Extensions.AsInt(Of Int32)(reader("ExamTemplateIdNo")),
                .SectionCode = Extensions.AsString(reader("SectionCode")),
                .TestCode = Extensions.AsString(reader("TestCode")),
                .TestNameEnglish = Extensions.AsString(reader("TestNameEnglish")),
                .TestNameArabic = Extensions.AsString(reader("TestNameArabic")),
                .Unit = Extensions.AsString(reader("Unit")),
                .DefaultValue = Extensions.AsString(reader("DefaultValue")),
                .DisplayOrder = Extensions.AsInt(Of Int32)(reader("DisplayOrder")),
                .InputMode = Extensions.AsString(reader("InputMode")),
                .IsRequired = Convert.ToBoolean(reader("IsRequired")),
                .Active = Convert.ToBoolean(reader("Active"))}

        Private Shared ReadOnly MakeReportFormatAssignment As Func(Of IDataReader, MedicalFitnessReportFormatAssignment) =
            Function(reader) New MedicalFitnessReportFormatAssignment() With {
                .IdNo = Extensions.AsInt(Of Int32)(reader("IdNo")),
                .CompanyName = Extensions.AsString(reader("CompanyName")),
                .MRIdNo = Extensions.AsInt(Of Int32)(reader("MRIdNo")),
                .FormatTitle = Extensions.AsString(reader("FormatTitle")),
                .Active = Convert.ToBoolean(reader("Active"))}

        Private Shared ReadOnly MakeReport As Func(Of IDataReader, MedicalFitnessReport) =
            Function(reader) New MedicalFitnessReport() With {
                .IdNo = Extensions.AsInt(Of Int32)(reader("IdNo")),
                .InvoiceNo = Extensions.AsInt(Of Int32)(reader("InvoiceNo")),
                .ReportFormat = Extensions.AsString(reader("ReportFormat")),
                .MedicalReportFormatIdNo = Extensions.AsInt(Of Int32)(reader("MedicalReportFormatIdNo")),
                .InvoiceDate = Extensions.AsNullable(Of DateTime?)(reader("InvoiceDate")),
                .FileNo = Extensions.AsNullable(Of Int32?)(reader("FileNo")),
                .PatientName = Extensions.AsString(reader("PatientName")),
                .CompanyName = Extensions.AsString(reader("CompanyName")),
                .PassportNo = Extensions.AsString(reader("PassportNo")),
                .Gender = Extensions.AsString(reader("Gender")),
                .Age = Extensions.AsString(reader("Age")),
                .Nationality = Extensions.AsString(reader("Nationality")),
                .IdentityNo = Extensions.AsString(reader("IdentityNo")),
                .DoctorName = Extensions.AsString(reader("DoctorName")),
                .BloodType = Extensions.AsString(reader("BloodType")),
                .ExamTemperature = Extensions.AsString(reader("ExamTemperature")),
                .ExamBloodPressure = Extensions.AsString(reader("ExamBloodPressure")),
                .ExamPulse = Extensions.AsString(reader("ExamPulse")),
                .ExamRespiratorySystem = Extensions.AsString(reader("ExamRespiratorySystem")),
                .ExamCardiovascularSystem = Extensions.AsString(reader("ExamCardiovascularSystem")),
                .ExamNervousSystem = Extensions.AsString(reader("ExamNervousSystem")),
                .ExamAbdomen = Extensions.AsString(reader("ExamAbdomen")),
                .ExamWeight = Extensions.AsString(reader("ExamWeight")),
                .ExamHeight = Extensions.AsString(reader("ExamHeight")),
                .ExamExtremities = Extensions.AsString(reader("ExamExtremities")),
                .ExamChestXRay = Extensions.AsString(reader("ExamChestXRay")),
                .ExamRightEye = Extensions.AsString(reader("ExamRightEye")),
                .ExamLeftEye = Extensions.AsString(reader("ExamLeftEye")),
                .ExamRightEar = Extensions.AsString(reader("ExamRightEar")),
                .ExamLeftEar = Extensions.AsString(reader("ExamLeftEar")),
                .FinalResultStatus = Extensions.AsString(reader("FinalResultStatus")),
                .Remarks = Extensions.AsString(reader("Remarks"))}

        Private Shared ReadOnly MakeKizenInvoice As Func(Of IDataReader, MedicalFitnessReport) =
            Function(reader) New MedicalFitnessReport() With {
                .InvoiceNo = Extensions.AsInt(Of Int32)(reader("InvoiceNo")),
                .InvoiceDate = Extensions.AsNullable(Of DateTime?)(reader("InvoiceDate")),
                .FileNo = Extensions.AsNullable(Of Int32?)(reader("FileNo")),
                .PatientName = Extensions.AsString(reader("PatientName")),
                .CompanyName = Extensions.AsString(reader("CompanyName")),
                .Gender = Extensions.AsString(reader("Gender")),
                .Age = GetMedicalFitnessAge(reader),
                .Nationality = Extensions.AsString(reader("Nationality")),
                .IdentityNo = Extensions.AsString(reader("IdentityNo")),
                .DoctorName = Extensions.AsString(reader("DoctorName")),
                .ExamTemperature = Extensions.AsString(reader("ExamTemperature")),
                .ExamBloodPressure = Extensions.AsString(reader("ExamBloodPressure")),
                .ExamPulse = Extensions.AsString(reader("ExamPulse")),
                .ExamWeight = Extensions.AsString(reader("ExamWeight")),
                .ExamHeight = Extensions.AsString(reader("ExamHeight"))}

        Private Shared ReadOnly MakePatientInvoiceSearchResult As Func(Of IDataReader, MedicalFitnessReportInvoiceSearchResult) =
            Function(reader) New MedicalFitnessReportInvoiceSearchResult() With {
                .InvoiceNo = Extensions.AsInt(Of Int32)(reader("InvoiceNo")),
                .InvoiceDate = Extensions.AsNullable(Of DateTime?)(reader("InvoiceDate")),
                .FileNo = Extensions.AsString(reader("FileNo")),
                .PatientName = Extensions.AsString(reader("PatientName")),
                .IdentityNo = Extensions.AsString(reader("IdentityNo"))}

        Private Shared Function GetMedicalFitnessAge(reader As IDataReader) As String
            Dim birthDate = Extensions.AsNullable(Of DateTime?)(reader("BirthDate"))
            Dim invoiceDate = Extensions.AsNullable(Of DateTime?)(reader("InvoiceDate"))
            If Not birthDate.HasValue OrElse Not invoiceDate.HasValue Then
                Return Extensions.AsString(reader("AgeLong"))
            End If

            Dim born = birthDate.Value.Date
            Dim asOfDate = invoiceDate.Value.Date
            If asOfDate < born Then
                Return ""
            End If

            Dim completedYears = asOfDate.Year - born.Year
            If born.AddYears(completedYears) > asOfDate Then
                completedYears -= 1
            End If
            If completedYears >= 1 Then
                Return completedYears.ToString() & If(completedYears = 1, " year", " years")
            End If

            Dim completedMonths = ((asOfDate.Year - born.Year) * 12) + asOfDate.Month - born.Month
            If born.AddMonths(completedMonths) > asOfDate Then
                completedMonths -= 1
            End If
            If completedMonths >= 1 Then
                Return completedMonths.ToString() & If(completedMonths = 1, " month", " months")
            End If

            Dim completedDays = CInt((asOfDate - born).TotalDays)
            Return completedDays.ToString() & If(completedDays = 1, " day", " days")
        End Function

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
                .KizenTestNameEnglish = Extensions.AsString(reader("TestNameEnglish")),
                .EnglishNameOverride = Extensions.AsString(reader("EnglishNameOverride")),
                .ArabicNameOverride = Extensions.AsString(reader("ArabicNameOverride")),
                .TestNameEnglish = Extensions.AsString(reader("EffectiveTestNameEnglish")),
                .TestNameArabic = Extensions.AsString(reader("EffectiveTestNameArabic")),
                .DisplayOrder = Extensions.AsInt(Of Int32)(reader("DisplayOrder")),
                .CopyResultToEntry = Convert.ToBoolean(reader("CopyResultToEntry")),
                .Active = Convert.ToBoolean(reader("Active"))}

        Private Shared ReadOnly MakeClinicalExamTemplate As Func(Of IDataReader, MedicalFitnessReportExamTemplate) =
            Function(reader) New MedicalFitnessReportExamTemplate() With {
                .IdNo = Extensions.AsInt(Of Int32)(reader("IdNo")),
                .SectionCode = Extensions.AsString(reader("SectionCode")),
                .TestCode = Extensions.AsString(reader("TestCode")),
                .TestNameEnglish = Extensions.AsString(reader("TestNameEnglish")),
                .TestNameArabic = Extensions.AsString(reader("TestNameArabic")),
                .Unit = Extensions.AsString(reader("Unit")),
                .DefaultValue = Extensions.AsString(reader("DefaultValue")),
                .DisplayOrder = Extensions.AsInt(Of Int32)(reader("DisplayOrder")),
                .InputMode = Extensions.AsString(reader("InputMode")),
                .IsRequired = Convert.ToBoolean(reader("IsRequired")),
                .Active = Convert.ToBoolean(reader("Active"))}

        Private Shared Function TakeClinicalExamTemplate(template As MedicalFitnessReportExamTemplate) As Object()
            Return New Object() {
                "@SectionCode", template.SectionCode,
                "@TestCode", template.TestCode,
                "@TestNameEnglish", template.TestNameEnglish,
                "@TestNameArabic", DbValue(template.TestNameArabic),
                "@Unit", DbValue(template.Unit),
                "@DefaultValue", DbValue(template.DefaultValue),
                "@DisplayOrder", template.DisplayOrder,
                "@InputMode", template.InputMode,
                "@IsRequired", template.IsRequired,
                "@Active", template.Active}
        End Function

        Private Shared ReadOnly MakeKizenLabAnalysis As Func(Of IDataReader, MedicalFitnessReportLabAnalysis) =
            Function(reader) New MedicalFitnessReportLabAnalysis() With {
                .TestCode = Extensions.AsString(reader("TestCode")),
                .TestNameEnglish = Extensions.AsString(reader("TestNameEnglish")),
                .ResultValue = Extensions.AsString(reader("ResultValue")),
                .ReferenceValue = Extensions.AsString(reader("ReferenceValue")),
                .Unit = Extensions.AsString(reader("UnitValue"))}

        Private Shared ReadOnly MakeKizenLabItem As Func(Of IDataReader, MedicalFitnessReportKizenLabItem) =
            Function(reader) New MedicalFitnessReportKizenLabItem() With {
                .Code = Extensions.AsString(reader("Code")),
                .Name = Extensions.AsString(reader("Name"))}

        Private Shared ReadOnly MakeKizenGroupedLabResult As Func(Of IDataReader, MedicalFitnessGroupedLabResult) =
            Function(reader) New MedicalFitnessGroupedLabResult() With {
                .Sequence = Extensions.AsInt(Of Int32)(reader("Sequence")),
                .GroupName = Extensions.AsString(reader("GroupName")),
                .TestCode = Extensions.AsString(reader("TestCode")),
                .TestName = Extensions.AsString(reader("TestName")),
                .ResultValue = Extensions.AsString(reader("ResultValue")),
                .ReferenceValue = Extensions.AsString(reader("ReferenceValue")),
                .Unit = Extensions.AsString(reader("UnitValue"))}

    End Class

End Namespace

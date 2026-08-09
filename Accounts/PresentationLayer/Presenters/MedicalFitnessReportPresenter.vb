Imports System.ComponentModel
Imports System.Linq
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class MedicalFitnessReportPresenter(Of TM As New)
        Inherits CommonPresenter(Of IMedicalFitnessReportView, TM)

        Private ReadOnly _dao As New MedicalFitnessReportDao()

        Public Sub New()
        End Sub

        Public Sub New(view As IMedicalFitnessReportView)
            MyBase.New(view)
            Service = New AccountsService("MedicalFitnessReport")
            TableName = "MedicalFitnessReport"
            SortOrderKey = "IdNo"
            WithTreeView = False
            AddHandler View.RetrieveRequested, AddressOf RetrieveReport
            AddHandler View.SaveRequested, AddressOf SaveReport
        End Sub

        Private Sub RetrieveReport()
            If View.InvoiceNo = 0 Then
                MessageBox.Show("Please enter the invoice number.")
                Return
            End If

            Dim report = _dao.GetSavedReportByInvoiceNo(View.InvoiceNo)
            If report Is Nothing Then
                report = _dao.GetKizenInvoice(View.InvoiceNo)
                If report Is Nothing Then
                    MessageBox.Show("No invoice was found in Kizen for the entered invoice number.")
                    ClearView()
                    Return
                End If
                report.Details = CreateDefaultDetails(report.InvoiceNo)
            Else
                report.Details = SynchronizeLabDetails(report.Details, report.InvoiceNo)
            End If

            DisplayReport(report)
        End Sub

        Private Sub SaveReport()
            If View.InvoiceNo = 0 Then
                MessageBox.Show("Please retrieve an invoice before saving.")
                Return
            End If

            Dim report = ReadView()
            Dim idNo = _dao.SaveReport(report)
            View.ReportIdNo = idNo
            MessageBox.Show("Medical report saved.")
        End Sub

        Private Sub DisplayReport(report As MedicalFitnessReport)
            View.ReportIdNo = report.IdNo
            View.InvoiceNo = report.InvoiceNo
            View.InvoiceDate = report.InvoiceDate
            View.FileNo = report.FileNo
            View.PatientName = report.PatientName
            View.Gender = report.Gender
            View.Age = report.Age
            View.Nationality = report.Nationality
            View.IdentityNo = report.IdentityNo
            View.DoctorName = report.DoctorName
            View.BloodType = report.BloodType
            View.FinalResultStatus = report.FinalResultStatus
            View.Remarks = report.Remarks
            View.TestResults = ToViewRows(report.Details)
        End Sub

        Private Function ReadView() As MedicalFitnessReport
            Return New MedicalFitnessReport With {
                .IdNo = View.ReportIdNo,
                .InvoiceNo = View.InvoiceNo,
                .InvoiceDate = View.InvoiceDate,
                .FileNo = View.FileNo,
                .PatientName = View.PatientName,
                .Gender = View.Gender,
                .Age = View.Age,
                .Nationality = View.Nationality,
                .IdentityNo = View.IdentityNo,
                .DoctorName = View.DoctorName,
                .BloodType = View.BloodType,
                .FinalResultStatus = View.FinalResultStatus,
                .Remarks = View.Remarks,
                .Details = ToBusinessRows(View.TestResults)}
        End Function

        Private Sub ClearView()
            View.ReportIdNo = 0
            View.InvoiceDate = Nothing
            View.FileNo = Nothing
            View.PatientName = ""
            View.Gender = ""
            View.Age = ""
            View.Nationality = ""
            View.IdentityNo = ""
            View.DoctorName = ""
            View.BloodType = ""
            View.FinalResultStatus = Nothing
            View.Remarks = ""
            View.TestResults = New BindingList(Of MedicalFitnessReportTestResultView)()
        End Sub

        Private Function CreateDefaultDetails(invoiceNo As Int32) As List(Of MedicalFitnessReportTestResult)
            Dim rows As New List(Of MedicalFitnessReportTestResult)

            AddRow(rows, "CLINICAL", "HEIGHT", "Height", "قياس الطول", 10)
            AddRow(rows, "CLINICAL", "WEIGHT", "Weight", "قياس الوزن", 20)
            AddRow(rows, "CLINICAL", "VISION", "Vision", "النظر", 30)
            AddRow(rows, "CLINICAL", "HEARING", "Hearing", "السمع", 40)
            AddRow(rows, "CLINICAL", "BLOOD_PRESSURE_PULSE", "Blood Pressure / Pulse", "النبض و ضغط الدم", 50)
            AddRow(rows, "CLINICAL", "CHEST_HEART", "Chest / Heart", "القلب والصدر", 60)
            AddRow(rows, "CLINICAL", "ABDOMEN_DERMATOLOGICAL", "Abdomen/Dermatological", "الباطنية والجلدية والتناسلية", 70)
            AddRow(rows, "CLINICAL", "NEUROLOGICAL", "Neurological Disorder", "الامراض النفسية والعصبية", 80)
            AddRow(rows, "CHEST_XRAY", "CHEST_XRAY", "Chest X-Ray", "الأشعة على الصدر", 100)
            AddRow(rows, "ECG", "ECG", "ECG", "رسم القلب", 110)
            AddRow(rows, "AUDIOMETRY", "AUDIOMETRY", "Audiometry", "قياس السمع", 120)
            AddRow(rows, "SPIROMETRY", "SPIROMETRY", "Spirometry", "قياس التنفس", 130)

            Dim displayOrder = 200
            Dim analyses = _dao.GetKizenLabAnalyses(invoiceNo)
            If analyses.Count > 0 Then
                For Each analysis In analyses
                    AddRow(rows, "LAB", analysis.TestCode, analysis.TestNameEnglish, Nothing, displayOrder)
                    displayOrder += 10
                Next
            Else
                Dim templates = _dao.GetActiveLabTemplates()
                If templates.Count = 0 Then
                    AddRow(rows, "LAB", "RBS", "Random Blood Sugar", "السكر العشوائي", displayOrder)
                Else
                    For Each template In templates
                        AddRow(rows, "LAB", template.TestCode, template.TestNameEnglish, template.TestNameArabic, displayOrder)
                        displayOrder += 10
                    Next
                End If
            End If

            Return rows
        End Function

        Private Function SynchronizeLabDetails(rows As List(Of MedicalFitnessReportTestResult), invoiceNo As Int32) As List(Of MedicalFitnessReportTestResult)
            Dim analyses = _dao.GetKizenLabAnalyses(invoiceNo)
            If analyses.Count = 0 Then
                Return If(rows, New List(Of MedicalFitnessReportTestResult)())
            End If

            Dim existingRows = If(rows, New List(Of MedicalFitnessReportTestResult)())
            Dim synchronizedRows = existingRows.
                Where(Function(row) Not String.Equals(row.SectionCode, "LAB", StringComparison.OrdinalIgnoreCase)).
                ToList()
            Dim displayOrder = 200

            For Each analysis In analyses
                Dim matchingRow = existingRows.FirstOrDefault(
                    Function(row) String.Equals(row.SectionCode, "LAB", StringComparison.OrdinalIgnoreCase) AndAlso
                        (String.Equals(row.TestCode, analysis.TestCode, StringComparison.OrdinalIgnoreCase) OrElse
                         String.Equals(row.TestNameEnglish, analysis.TestNameEnglish, StringComparison.OrdinalIgnoreCase)))

                If matchingRow Is Nothing Then
                    matchingRow = New MedicalFitnessReportTestResult()
                End If

                matchingRow.SectionCode = "LAB"
                matchingRow.TestCode = analysis.TestCode
                matchingRow.TestNameEnglish = analysis.TestNameEnglish
                matchingRow.DisplayOrder = displayOrder
                synchronizedRows.Add(matchingRow)
                displayOrder += 10
            Next

            Return synchronizedRows.OrderBy(Function(row) row.DisplayOrder).ToList()
        End Function

        Private Shared Sub AddRow(rows As List(Of MedicalFitnessReportTestResult), sectionCode As String, testCode As String, testNameEnglish As String, testNameArabic As String, displayOrder As Int32)
            rows.Add(New MedicalFitnessReportTestResult With {
                .SectionCode = sectionCode,
                .TestCode = testCode,
                .TestNameEnglish = testNameEnglish,
                .TestNameArabic = testNameArabic,
                .DisplayOrder = displayOrder})
        End Sub

        Private Shared Function ToViewRows(rows As List(Of MedicalFitnessReportTestResult)) As BindingList(Of MedicalFitnessReportTestResultView)
            Dim list As New BindingList(Of MedicalFitnessReportTestResultView)
            If rows Is Nothing Then
                Return list
            End If

            For Each row In rows
                list.Add(New MedicalFitnessReportTestResultView With {
                    .IdNo = row.IdNo,
                    .MedicalFitnessReportIdNo = row.MedicalFitnessReportIdNo,
                    .SectionCode = row.SectionCode,
                    .TestCode = row.TestCode,
                    .TestNameEnglish = row.TestNameEnglish,
                    .TestNameArabic = row.TestNameArabic,
                    .DisplayOrder = row.DisplayOrder,
                    .ResultStatus = row.ResultStatus,
                    .ResultText = row.ResultText,
                    .Remarks = row.Remarks})
            Next

            Return list
        End Function

        Private Shared Function ToBusinessRows(rows As BindingList(Of MedicalFitnessReportTestResultView)) As List(Of MedicalFitnessReportTestResult)
            Dim list As New List(Of MedicalFitnessReportTestResult)
            If rows Is Nothing Then
                Return list
            End If

            For Each row In rows
                list.Add(New MedicalFitnessReportTestResult With {
                    .IdNo = row.IdNo,
                    .MedicalFitnessReportIdNo = row.MedicalFitnessReportIdNo,
                    .SectionCode = row.SectionCode,
                    .TestCode = row.TestCode,
                    .TestNameEnglish = row.TestNameEnglish,
                    .TestNameArabic = row.TestNameArabic,
                    .DisplayOrder = row.DisplayOrder,
                    .ResultStatus = row.ResultStatus,
                    .ResultText = row.ResultText,
                    .Remarks = row.Remarks})
            Next

            Return list
        End Function

    End Class

End Namespace

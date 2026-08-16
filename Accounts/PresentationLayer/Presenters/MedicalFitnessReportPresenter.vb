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
            AddHandler view.RetrieveRequested, AddressOf RetrieveReport
            AddHandler view.RefreshLabResultsRequested, AddressOf RefreshLabResults
            AddHandler view.ViewKizenResultsRequested, AddressOf ViewKizenResults
            AddHandler view.SaveRequested, AddressOf SaveReport
            AddHandler view.DeleteRequested, AddressOf DeleteReport
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
                ApplyNewReportDefaults(report)
            Else
                Dim kizenInvoice = _dao.GetKizenInvoice(report.InvoiceNo)
                If kizenInvoice IsNot Nothing Then
                    report.CompanyName = kizenInvoice.CompanyName
                    report.Age = kizenInvoice.Age
                End If
                report.Details = EnsureStandardDetailRows(report.Details)
                report.Details = SynchronizeLabDetails(report.Details, report.InvoiceNo)
            End If

            DisplayReport(report)
        End Sub

        Private Sub SaveReport()
            If View.InvoiceNo = 0 Then
                MessageBox.Show("Please retrieve an invoice before saving.")
                Return
            End If

            If Not View.ValidateRequiredEntries("saving") Then
                Return
            End If

            Dim report = ReadView()
            Dim idNo = _dao.SaveReport(report)
            View.ReportIdNo = idNo
            MessageBox.Show("Medical report saved.")
        End Sub

        Private Sub RefreshLabResults()
            If View.InvoiceNo = 0 Then
                MessageBox.Show("Please retrieve an invoice before refreshing the lab results.")
                Return
            End If

            Dim currentRows = ToBusinessRows(View.TestResults)
            Dim refreshedRows = SynchronizeLabDetails(currentRows, View.InvoiceNo, True)
            View.TestResults = ToViewRows(refreshedRows)
            MessageBox.Show("Lab results refreshed.")
        End Sub

        Private Sub ViewKizenResults()
            If View.InvoiceNo = 0 Then
                MessageBox.Show("Please retrieve an invoice before viewing Kizen results.")
                Return
            End If

            Dim selectedRow = View.SelectedTestResult
            If selectedRow Is Nothing OrElse
               Not String.Equals(selectedRow.SectionCode, "LAB", StringComparison.OrdinalIgnoreCase) Then
                MessageBox.Show("Please select a laboratory result.")
                Return
            End If

            If String.IsNullOrWhiteSpace(selectedRow.TestCode) Then
                MessageBox.Show("The selected laboratory result does not have a Kizen test code.")
                Return
            End If

            Try
                Dim details = _dao.GetKizenGroupedLabResults(View.InvoiceNo, selectedRow.TestCode)
                If details.Count = 0 Then
                    MessageBox.Show("No visible Kizen result details were found for the selected analysis.")
                    Return
                End If

                Dim displayRows As New BindingList(Of MedicalFitnessGroupedLabResultView)
                For Each detail In details.OrderBy(Function(item) item.Sequence)
                    Dim evaluation = MedicalFitnessLabResultEvaluator.Evaluate(detail.ResultValue, detail.ReferenceValue)
                    displayRows.Add(New MedicalFitnessGroupedLabResultView With {
                        .Sequence = detail.Sequence,
                        .GroupName = detail.GroupName,
                        .TestCode = detail.TestCode,
                        .TestName = detail.TestName,
                        .ResultValue = detail.ResultValue,
                        .ReferenceValue = detail.ReferenceValue,
                        .Unit = detail.Unit,
                        .Assessment = evaluation.Assessment})
                Next

                View.ShowKizenGroupedResults(selectedRow.TestNameEnglish, displayRows)
            Catch ex As Exception
                MessageBox.Show(
                    "Unable to read the selected results from Kizen." & Environment.NewLine & ex.Message,
                    "Kizen Results",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub DeleteReport()
            If View.ReportIdNo = 0 Then
                MessageBox.Show("There is no saved medical report to delete.")
                Return
            End If

            Dim confirmation = MessageBox.Show(
                "Delete the saved medical fitness report for invoice " & View.InvoiceNo & "?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)
            If confirmation <> DialogResult.Yes Then
                Return
            End If

            _dao.DeleteReport(View.ReportIdNo)
            ClearView()
            View.InvoiceNo = 0
            MessageBox.Show("Medical report deleted.")
        End Sub

        Private Sub DisplayReport(report As MedicalFitnessReport)
            View.ReportIdNo = report.IdNo
            View.InvoiceNo = report.InvoiceNo
            View.InvoiceDate = report.InvoiceDate
            View.FileNo = report.FileNo
            View.PatientName = report.PatientName
            View.CompanyName = report.CompanyName
            View.PassportNo = report.PassportNo
            View.Gender = report.Gender
            View.Age = report.Age
            View.Nationality = report.Nationality
            View.IdentityNo = report.IdentityNo
            View.DoctorName = report.DoctorName
            View.BloodType = report.BloodType
            View.ExamTemperature = report.ExamTemperature
            View.ExamBloodPressure = report.ExamBloodPressure
            View.ExamPulse = report.ExamPulse
            View.ExamRespiratorySystem = report.ExamRespiratorySystem
            View.ExamCardiovascularSystem = report.ExamCardiovascularSystem
            View.ExamNervousSystem = report.ExamNervousSystem
            View.ExamAbdomen = report.ExamAbdomen
            View.ExamWeight = report.ExamWeight
            View.ExamHeight = report.ExamHeight
            View.ExamExtremities = report.ExamExtremities
            View.ExamChestXRay = report.ExamChestXRay
            View.ExamRightEye = report.ExamRightEye
            View.ExamLeftEye = report.ExamLeftEye
            View.ExamRightEar = report.ExamRightEar
            View.ExamLeftEar = report.ExamLeftEar
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
                .CompanyName = View.CompanyName,
                .PassportNo = View.PassportNo,
                .Gender = View.Gender,
                .Age = View.Age,
                .Nationality = View.Nationality,
                .IdentityNo = View.IdentityNo,
                .DoctorName = View.DoctorName,
                .BloodType = View.BloodType,
                .ExamTemperature = View.ExamTemperature,
                .ExamBloodPressure = View.ExamBloodPressure,
                .ExamPulse = View.ExamPulse,
                .ExamRespiratorySystem = View.ExamRespiratorySystem,
                .ExamCardiovascularSystem = View.ExamCardiovascularSystem,
                .ExamNervousSystem = View.ExamNervousSystem,
                .ExamAbdomen = View.ExamAbdomen,
                .ExamWeight = View.ExamWeight,
                .ExamHeight = View.ExamHeight,
                .ExamExtremities = View.ExamExtremities,
                .ExamChestXRay = View.ExamChestXRay,
                .ExamRightEye = View.ExamRightEye,
                .ExamLeftEye = View.ExamLeftEye,
                .ExamRightEar = View.ExamRightEar,
                .ExamLeftEar = View.ExamLeftEar,
                .FinalResultStatus = View.FinalResultStatus,
                .Remarks = View.Remarks,
                .Details = ToBusinessRows(View.TestResults)}
        End Function

        Private Sub ClearView()
            View.ReportIdNo = 0
            View.InvoiceDate = Nothing
            View.FileNo = Nothing
            View.PatientName = ""
            View.CompanyName = ""
            View.PassportNo = ""
            View.Gender = ""
            View.Age = ""
            View.Nationality = ""
            View.IdentityNo = ""
            View.DoctorName = ""
            View.BloodType = ""
            View.ExamTemperature = ""
            View.ExamBloodPressure = ""
            View.ExamPulse = ""
            View.ExamRespiratorySystem = ""
            View.ExamCardiovascularSystem = ""
            View.ExamNervousSystem = ""
            View.ExamAbdomen = ""
            View.ExamWeight = ""
            View.ExamHeight = ""
            View.ExamExtremities = ""
            View.ExamChestXRay = ""
            View.ExamRightEye = ""
            View.ExamLeftEye = ""
            View.ExamRightEar = ""
            View.ExamLeftEar = ""
            View.FinalResultStatus = Nothing
            View.Remarks = ""
            View.TestResults = New BindingList(Of MedicalFitnessReportTestResultView)()
        End Sub

        Private Function CreateDefaultDetails(invoiceNo As Int32) As List(Of MedicalFitnessReportTestResult)
            Dim rows As New List(Of MedicalFitnessReportTestResult)

            AddRow(rows, "DETAIL", "ECG", "ECG", "رسم القلب", 110)
            AddRow(rows, "DETAIL", "AUDIOMETRY", "Audiometry", "قياس السمع", 120)
            AddRow(rows, "DETAIL", "SPIROMETRY", "Spirometry", "قياس التنفس", 130)

            Dim sequence = 200
            Dim analyses = _dao.GetKizenLabAnalyses(invoiceNo)
            If analyses.Count > 0 Then
                For Each analysis In analyses
                    AddLabRow(rows, analysis, sequence)
                    sequence += 10
                Next
            Else
                Dim templates = _dao.GetActiveLabTemplates()
                If templates.Count = 0 Then
                    AddRow(rows, "LAB", "RBS", "Random Blood Sugar", "السكر العشوائي", sequence)
                Else
                    For Each template In templates
                        AddRow(rows, "LAB", template.TestCode, template.TestNameEnglish, template.TestNameArabic, sequence)
                        sequence += 10
                    Next
                End If
            End If

            Return rows
        End Function

        Private Shared Sub ApplyNewReportDefaults(report As MedicalFitnessReport)
            report.ExamRespiratorySystem = "NAD"
            report.ExamCardiovascularSystem = "NAD"
            report.ExamNervousSystem = "NAD"
            report.ExamAbdomen = "NAD"
            report.ExamExtremities = "NAD"
            report.ExamChestXRay = "NORMAL"
            report.ExamRightEye = "NAD"
            report.ExamLeftEye = "NAD"
            report.ExamRightEar = "NAD"
            report.ExamLeftEar = "NAD"
        End Sub

        Private Shared Function EnsureStandardDetailRows(rows As List(Of MedicalFitnessReportTestResult)) As List(Of MedicalFitnessReportTestResult)
            Dim result = If(rows, New List(Of MedicalFitnessReportTestResult)())
            EnsureStandardDetailRow(result, "DETAIL", "ECG", "ECG", "رسم القلب", 110)
            EnsureStandardDetailRow(result, "DETAIL", "AUDIOMETRY", "Audiometry", "قياس السمع", 120)
            EnsureStandardDetailRow(result, "DETAIL", "SPIROMETRY", "Spirometry", "قياس التنفس", 130)
            Return result
        End Function

        Private Shared Sub EnsureStandardDetailRow(rows As List(Of MedicalFitnessReportTestResult),
                                                    sectionCode As String,
                                                    testCode As String,
                                                    testNameEnglish As String,
                                                    testNameArabic As String,
                                                    sequence As Int32)
            Dim existing = rows.FirstOrDefault(
                Function(row) String.Equals(row.TestCode, testCode, StringComparison.OrdinalIgnoreCase))
            If existing Is Nothing Then
                AddRow(rows, sectionCode, testCode, testNameEnglish, testNameArabic, sequence)
                Return
            End If

            existing.SectionCode = sectionCode
            If existing.Sequence <= 0 Then
                existing.Sequence = sequence
            End If
        End Sub

        Private Function SynchronizeLabDetails(rows As List(Of MedicalFitnessReportTestResult), invoiceNo As Int32, Optional removeMissingWhenEmpty As Boolean = False) As List(Of MedicalFitnessReportTestResult)
            Dim analyses = _dao.GetKizenLabAnalyses(invoiceNo)
            If analyses.Count = 0 Then
                Dim currentRows = If(rows, New List(Of MedicalFitnessReportTestResult)())
                If Not removeMissingWhenEmpty Then
                    Return currentRows
                End If

                Return currentRows.
                    Where(Function(row) Not String.Equals(row.SectionCode, "LAB", StringComparison.OrdinalIgnoreCase)).
                    OrderBy(Function(row) row.Sequence).
                    ThenBy(Function(row) row.IdNo).
                    ToList()
            End If

            Dim existingRows = If(rows, New List(Of MedicalFitnessReportTestResult)())
            Dim synchronizedRows = existingRows.
                Where(Function(row) Not String.Equals(row.SectionCode, "LAB", StringComparison.OrdinalIgnoreCase)).
                ToList()
            Dim nextSequence = If(existingRows.Count = 0,
                                  200,
                                  Math.Max(200, existingRows.Max(Function(row) row.Sequence) + 10))

            For Each analysis In analyses
                Dim matchingRow = existingRows.FirstOrDefault(
                    Function(row) String.Equals(row.SectionCode, "LAB", StringComparison.OrdinalIgnoreCase) AndAlso
                        (String.Equals(row.TestCode, analysis.TestCode, StringComparison.OrdinalIgnoreCase) OrElse
                         String.Equals(row.TestNameEnglish, analysis.TestNameEnglish, StringComparison.OrdinalIgnoreCase)))

                If matchingRow Is Nothing Then
                    matchingRow = New MedicalFitnessReportTestResult With {
                        .Sequence = nextSequence}
                    nextSequence += 10
                ElseIf matchingRow.Sequence <= 0 Then
                    matchingRow.Sequence = nextSequence
                    nextSequence += 10
                End If

                matchingRow.SectionCode = "LAB"
                matchingRow.TestCode = analysis.TestCode
                matchingRow.TestNameEnglish = analysis.TestNameEnglish
                ApplyLabAnalysis(matchingRow, analysis)
                synchronizedRows.Add(matchingRow)
            Next

            Return synchronizedRows.
                OrderBy(Function(row) row.Sequence).
                ThenBy(Function(row) row.IdNo).
                ToList()
        End Function

        Private Shared Sub AddRow(rows As List(Of MedicalFitnessReportTestResult), sectionCode As String, testCode As String, testNameEnglish As String, testNameArabic As String, sequence As Int32)
            rows.Add(New MedicalFitnessReportTestResult With {
                .SectionCode = sectionCode,
                .TestCode = testCode,
                .TestNameEnglish = testNameEnglish,
                .TestNameArabic = testNameArabic,
                .Sequence = sequence})
        End Sub

        Private Shared Sub AddLabRow(rows As List(Of MedicalFitnessReportTestResult), analysis As MedicalFitnessReportLabAnalysis, sequence As Int32)
            Dim row = New MedicalFitnessReportTestResult With {
                .SectionCode = "LAB",
                .TestCode = analysis.TestCode,
                .TestNameEnglish = analysis.TestNameEnglish,
                .Sequence = sequence}
            ApplyLabAnalysis(row, analysis)
            rows.Add(row)
        End Sub

        Private Shared Sub ApplyLabAnalysis(row As MedicalFitnessReportTestResult, analysis As MedicalFitnessReportLabAnalysis)
            row.LabResult = analysis.ResultValue
            row.LabReferenceValue = analysis.ReferenceValue
            row.LabUnit = analysis.Unit

            Dim evaluation = MedicalFitnessLabResultEvaluator.Evaluate(analysis.ResultValue, analysis.ReferenceValue)
            row.LabAssessment = evaluation.Assessment

            If String.IsNullOrWhiteSpace(row.ResultStatusSource) AndAlso
               Not String.IsNullOrWhiteSpace(row.ResultStatus) Then
                row.ResultStatusSource = "M"
            End If

            Dim mayApplySuggestion = String.Equals(row.ResultStatusSource, "A", StringComparison.OrdinalIgnoreCase) OrElse
                                     (String.IsNullOrWhiteSpace(row.ResultStatus) AndAlso
                                      Not String.Equals(row.ResultStatusSource, "M", StringComparison.OrdinalIgnoreCase))
            If Not mayApplySuggestion Then
                Return
            End If

            row.ResultStatus = evaluation.SuggestedStatus
            row.ResultStatusSource = If(String.IsNullOrWhiteSpace(evaluation.SuggestedStatus), Nothing, "A")
        End Sub

        Private Shared Function ToViewRows(rows As List(Of MedicalFitnessReportTestResult)) As BindingList(Of MedicalFitnessReportTestResultView)
            Dim list As New BindingList(Of MedicalFitnessReportTestResultView)
            If rows Is Nothing Then
                Return list
            End If

            For Each row In rows.OrderBy(Function(item) item.Sequence).ThenBy(Function(item) item.IdNo)
                list.Add(New MedicalFitnessReportTestResultView With {
                    .IdNo = row.IdNo,
                    .MedicalFitnessReportIdNo = row.MedicalFitnessReportIdNo,
                    .SectionCode = row.SectionCode,
                    .TestCode = row.TestCode,
                    .TestNameEnglish = row.TestNameEnglish,
                    .TestNameArabic = row.TestNameArabic,
                    .Sequence = row.Sequence,
                    .ResultStatus = row.ResultStatus,
                    .ResultText = row.ResultText,
                    .LabResult = row.LabResult,
                    .LabReferenceValue = row.LabReferenceValue,
                    .LabUnit = row.LabUnit,
                    .LabAssessment = row.LabAssessment,
                    .ResultStatusSource = row.ResultStatusSource,
                    .Remarks = row.Remarks})
            Next

            Return list
        End Function

        Private Shared Function ToBusinessRows(rows As BindingList(Of MedicalFitnessReportTestResultView)) As List(Of MedicalFitnessReportTestResult)
            Dim list As New List(Of MedicalFitnessReportTestResult)
            If rows Is Nothing Then
                Return list
            End If

            For Each row In rows.OrderBy(Function(item) item.Sequence).ThenBy(Function(item) item.IdNo)
                list.Add(New MedicalFitnessReportTestResult With {
                    .IdNo = row.IdNo,
                    .MedicalFitnessReportIdNo = row.MedicalFitnessReportIdNo,
                    .SectionCode = row.SectionCode,
                    .TestCode = row.TestCode,
                    .TestNameEnglish = row.TestNameEnglish,
                    .TestNameArabic = row.TestNameArabic,
                    .Sequence = row.Sequence,
                    .ResultStatus = row.ResultStatus,
                    .ResultText = row.ResultText,
                    .LabResult = row.LabResult,
                    .LabReferenceValue = row.LabReferenceValue,
                    .LabUnit = row.LabUnit,
                    .LabAssessment = row.LabAssessment,
                    .ResultStatusSource = row.ResultStatusSource,
                    .Remarks = row.Remarks})
            Next

            Return list
        End Function

    End Class

End Namespace

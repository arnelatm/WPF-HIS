Imports System.ComponentModel
Imports System.Collections.Generic
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

        Private Const ClinicalSectionCode As String = "CLINICAL"
        Private Const XRaySectionCode As String = "XRAY"
        Private Const LegacyReportFormat As String = "LEGACY"
        Private Const StandardReportFormat As String = "STANDARD"

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
            AddHandler view.PatientSearchRequested, AddressOf SearchPatientInvoices
            AddHandler view.RefreshLabResultsRequested, AddressOf RefreshLabResults
            AddHandler view.ReportFormatChangedRequested, AddressOf RefreshReportFormat
            AddHandler view.ViewKizenResultsRequested, AddressOf ViewKizenResults
            AddHandler view.SaveRequested, AddressOf SaveReport
            AddHandler view.DeleteRequested, AddressOf DeleteReport
        End Sub

        Private Sub SearchPatientInvoices(searchValue As String)
            If String.IsNullOrWhiteSpace(searchValue) Then
                MessageBox.Show("Enter the patient's ID number or file number.")
                Return
            End If

            Try
                Dim matches = _dao.GetPatientInvoiceSearchResults(searchValue)
                If matches.Count = 0 Then
                    MessageBox.Show("No invoices were found for the entered ID number or file number.")
                    Return
                End If

                Dim invoiceNo As Int32
                If matches.Count = 1 Then
                    invoiceNo = matches(0).InvoiceNo
                Else
                    invoiceNo = View.SelectPatientInvoice(matches)
                End If

                If invoiceNo = 0 Then
                    Return
                End If

                View.InvoiceNo = invoiceNo
                RetrieveReport()
            Catch ex As Exception
                MessageBox.Show(
                    "Unable to search for the patient's invoices." & Environment.NewLine & ex.Message,
                    "Medical Report Search",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub RetrieveReport()
            If View.InvoiceNo = 0 Then
                MessageBox.Show("Please enter the invoice number.")
                Return
            End If

            ' Remove the previous invoice rows before any database work so a
            ' failed lookup or a slow Kizen read cannot leave stale results in
            ' the grid.
            View.TestResults = New BindingList(Of MedicalFitnessReportTestResultView)()

            Dim report = _dao.GetSavedReportByInvoiceNo(View.InvoiceNo)
            If report Is Nothing Then
                report = _dao.GetKizenInvoice(View.InvoiceNo)
                If report Is Nothing Then
                    MessageBox.Show("No invoice was found in Kizen for the entered invoice number.")
                    ClearView()
                    Return
                End If
                Dim assignedFormat = _dao.GetReportFormatForCompany(report.CompanyName)
                If assignedFormat Is Nothing Then
                    assignedFormat = _dao.GetDefaultReportFormat()
                End If
                If assignedFormat IsNot Nothing Then
                    report.MedicalReportFormatIdNo = assignedFormat.MRIdNo
                    report.ReportFormat = assignedFormat.FormatCode
                End If
                report.Details = CreateDefaultDetails(report)
            Else
                Dim kizenInvoice = _dao.GetKizenInvoice(report.InvoiceNo)
                If kizenInvoice IsNot Nothing Then
                    report.CompanyName = kizenInvoice.CompanyName
                    report.Age = kizenInvoice.Age
                End If
                EnsureReportFormat(report)
                report.Details = SynchronizeClinicalDetails(report.Details, report)
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

        Private Sub RefreshReportFormat()
            If View.InvoiceNo = 0 OrElse View.MedicalReportFormatIdNo = 0 Then
                Return
            End If

            Dim report = ReadView()
            EnsureReportFormat(report)
            report.Details = SynchronizeClinicalDetails(report.Details, report)
            View.ReportFormat = report.ReportFormat
            View.TestResults = ToViewRows(report.Details)
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
            View.MedicalReportFormatIdNo = report.MedicalReportFormatIdNo
            View.ReportFormat = NormalizeReportFormat(report.ReportFormat)
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
            Dim report = New MedicalFitnessReport With {
                .IdNo = View.ReportIdNo,
                .InvoiceNo = View.InvoiceNo,
                .MedicalReportFormatIdNo = View.MedicalReportFormatIdNo,
                .ReportFormat = NormalizeReportFormat(View.ReportFormat),
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
            ApplyClinicalDetailsToLegacyFields(report)
            Return report
        End Function

        Private Shared Function NormalizeReportFormat(value As String) As String
            If String.IsNullOrWhiteSpace(value) Then
                Return StandardReportFormat
            End If
            Return value.Trim().ToUpperInvariant()
        End Function

        Private Shared Sub ApplyClinicalDetailsToLegacyFields(report As MedicalFitnessReport)
            For Each row In If(report.Details, New List(Of MedicalFitnessReportTestResult)()).Where(
                Function(item) String.Equals(item.SectionCode, ClinicalSectionCode, StringComparison.OrdinalIgnoreCase) OrElse
                              String.Equals(item.SectionCode, XRaySectionCode, StringComparison.OrdinalIgnoreCase))
                Dim value = If(String.IsNullOrWhiteSpace(row.ResultText),
                               If(row.ResultStatus = "F", "NAD", If(row.ResultStatus = "U", "ABNORMAL", "")),
                               row.ResultText)

                Select Case If(row.TestCode, "").Trim().ToUpperInvariant()
                    Case "TEMPERATURE"
                        report.ExamTemperature = value
                    Case "BLOOD_PRESSURE"
                        report.ExamBloodPressure = value
                    Case "PULSE"
                        report.ExamPulse = value
                    Case "RESPIRATORY_SYSTEM"
                        report.ExamRespiratorySystem = value
                    Case "CARDIOVASCULAR_SYSTEM"
                        report.ExamCardiovascularSystem = value
                    Case "ABDOMEN_DERMATOLOGICAL"
                        report.ExamAbdomen = value
                    Case "NEUROLOGICAL_DISORDER"
                        report.ExamNervousSystem = value
                    Case "PHYSICAL_DISABILITY"
                        report.ExamExtremities = value
                    Case "WEIGHT"
                        report.ExamWeight = value
                    Case "HEIGHT"
                        report.ExamHeight = value
                    Case "CHEST_XRAY", "XRAY"
                        report.ExamChestXRay = value
                    Case "RIGHT_EYE"
                        report.ExamRightEye = value
                    Case "LEFT_EYE"
                        report.ExamLeftEye = value
                    Case "RIGHT_EAR"
                        report.ExamRightEar = value
                    Case "LEFT_EAR"
                        report.ExamLeftEar = value
                End Select
            Next
        End Sub

        Private Sub ClearView()
            View.ReportIdNo = 0
            View.MedicalReportFormatIdNo = 0
            View.ReportFormat = StandardReportFormat
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

        Private Function CreateDefaultDetails(report As MedicalFitnessReport) As List(Of MedicalFitnessReportTestResult)
            Dim rows As New List(Of MedicalFitnessReportTestResult)

            EnsureReportFormat(report)
            For Each template In GetFormatTemplates(report.MedicalReportFormatIdNo)
                AddExamTemplateRow(rows, template, report)
            Next

            Dim sequence = 200
            Dim analyses = _dao.GetKizenLabAnalyses(report.InvoiceNo)
            Dim labTemplates = _dao.GetActiveLabTemplates().ToDictionary(
                Function(item) item.TestCode,
                StringComparer.OrdinalIgnoreCase)
            If analyses.Count > 0 Then
                For Each analysis In analyses
                    Dim template As MedicalFitnessReportLabTemplate = Nothing
                    If Not String.IsNullOrWhiteSpace(analysis.TestCode) Then
                        template = FindLabTemplate(labTemplates, analysis.TestCode)
                    End If
                    AddLabRow(rows, analysis, sequence, template)
                    sequence += 10
                Next
            End If

            Return rows
        End Function

        Private Function SynchronizeClinicalDetails(rows As List(Of MedicalFitnessReportTestResult),
                                                     report As MedicalFitnessReport) As List(Of MedicalFitnessReportTestResult)
            Dim sourceRows = If(rows, New List(Of MedicalFitnessReportTestResult)()).ToList()
            Dim result = sourceRows.
                Where(Function(row) Not String.Equals(row.SectionCode, "GENERAL", StringComparison.OrdinalIgnoreCase) AndAlso
                                  Not String.Equals(row.SectionCode, ClinicalSectionCode, StringComparison.OrdinalIgnoreCase) AndAlso
                                  Not String.Equals(row.SectionCode, XRaySectionCode, StringComparison.OrdinalIgnoreCase) AndAlso
                                  Not String.Equals(row.SectionCode, "DETAIL", StringComparison.OrdinalIgnoreCase)).
                ToList()

            EnsureReportFormat(report)
            Dim templates = GetFormatTemplates(report.MedicalReportFormatIdNo)
            For Each template In templates
                Dim existing = result.FirstOrDefault(
                    Function(row) String.Equals(row.SectionCode, GetTemplateSectionCode(template), StringComparison.OrdinalIgnoreCase) AndAlso
                        String.Equals(row.TestCode, template.TestCode, StringComparison.OrdinalIgnoreCase))

                If existing Is Nothing Then
                    existing = sourceRows.FirstOrDefault(
                        Function(row) (String.Equals(row.SectionCode, ClinicalSectionCode, StringComparison.OrdinalIgnoreCase) OrElse
                                       String.Equals(row.SectionCode, XRaySectionCode, StringComparison.OrdinalIgnoreCase) OrElse
                                       String.Equals(row.SectionCode, "DETAIL", StringComparison.OrdinalIgnoreCase)) AndAlso
                                   String.Equals(row.TestCode, template.TestCode, StringComparison.OrdinalIgnoreCase))
                    If existing IsNot Nothing Then
                        result.Add(existing)
                    End If
                End If

                If existing Is Nothing Then
                    AddExamTemplateRow(result, template, report)
                Else
                    If existing.Sequence <= 0 Then
                        existing.Sequence = template.DisplayOrder
                    End If
                    If String.IsNullOrWhiteSpace(existing.LabUnit) Then
                        existing.LabUnit = template.Unit
                    End If
                    existing.InputMode = template.InputMode
                    existing.IsRequired = template.IsRequired
                    If String.IsNullOrWhiteSpace(existing.ResultText) AndAlso
                       String.IsNullOrWhiteSpace(existing.ResultStatus) AndAlso
                       Not String.IsNullOrWhiteSpace(template.DefaultValue) Then
                        existing.ResultText = template.DefaultValue
                        existing.ResultStatus = GetLegacyResultStatus(template.DefaultValue)
                    End If
                End If
            Next

            Return result.
                OrderBy(Function(row) GetSectionSortOrder(row.SectionCode)).
                ThenBy(Function(row) row.Sequence).
                ThenBy(Function(row) row.IdNo).
                ToList()
        End Function

        Private Function GetFormatTemplates(mrIdNo As Int32) As List(Of MedicalFitnessReportExamTemplate)
            Dim templates = If(mrIdNo = 0,
                               New List(Of MedicalFitnessReportExamTemplate)(),
                               _dao.GetExamTemplatesForReportFormat(mrIdNo))
            If templates.Count = 0 Then
                templates = _dao.GetClinicalExamTemplates().
                    Concat(_dao.GetXRayExamTemplates()).
                    ToList()
            End If
            Return templates
        End Function

        Private Sub EnsureReportFormat(report As MedicalFitnessReport)
            Dim format As MedicalFitnessReportFormat = Nothing
            If report.MedicalReportFormatIdNo <> 0 Then
                format = _dao.GetReportFormat(report.MedicalReportFormatIdNo)
            End If
            If format Is Nothing AndAlso Not String.IsNullOrWhiteSpace(report.ReportFormat) Then
                format = _dao.GetReportFormatByCode(report.ReportFormat)
            End If
            If format Is Nothing Then
                format = _dao.GetDefaultReportFormat()
            End If
            If format IsNot Nothing Then
                report.MedicalReportFormatIdNo = format.MRIdNo
                report.ReportFormat = format.FormatCode
            End If
        End Sub

        Private Shared Function GetSectionSortOrder(sectionCode As String) As Int32
            Select Case If(sectionCode, "").Trim().ToUpperInvariant()
                Case ClinicalSectionCode, "GENERAL"
                    Return 10
                Case "DETAIL"
                    Return 20
                Case XRaySectionCode
                    Return 30
                Case "LAB"
                    Return 40
                Case Else
                    Return 50
            End Select
        End Function

        Private Shared Sub AddExamTemplateRow(rows As List(Of MedicalFitnessReportTestResult),
                                              template As MedicalFitnessReportExamTemplate,
                                              report As MedicalFitnessReport)
            Dim legacyValue = GetLegacyClinicalValue(report, template.TestCode)
            If String.IsNullOrWhiteSpace(legacyValue) Then
                legacyValue = GetClinicalDefaultValue(template)
            End If
            rows.Add(New MedicalFitnessReportTestResult With {
                .SectionCode = GetTemplateSectionCode(template),
                .TestCode = template.TestCode,
                .TestNameEnglish = template.TestNameEnglish,
                .TestNameArabic = template.TestNameArabic,
                .Sequence = template.DisplayOrder,
                .InputMode = template.InputMode,
                .IsRequired = template.IsRequired,
                .ResultStatus = GetLegacyResultStatus(legacyValue),
                .ResultText = legacyValue,
                .LabUnit = template.Unit})
        End Sub

        Private Shared Function GetTemplateSectionCode(template As MedicalFitnessReportExamTemplate) As String
            If template IsNot Nothing AndAlso
               String.Equals(template.SectionCode, XRaySectionCode, StringComparison.OrdinalIgnoreCase) Then
                Return XRaySectionCode
            End If
            Return ClinicalSectionCode
        End Function

        Private Shared Function GetLegacyClinicalValue(report As MedicalFitnessReport, testCode As String) As String
            If report Is Nothing Then
                Return Nothing
            End If

            Select Case If(testCode, "").Trim().ToUpperInvariant()
                Case "TEMPERATURE"
                    Return report.ExamTemperature
                Case "BLOOD_PRESSURE"
                    Return report.ExamBloodPressure
                Case "PULSE"
                    Return report.ExamPulse
                Case "RESPIRATORY_SYSTEM"
                    Return report.ExamRespiratorySystem
                Case "CARDIOVASCULAR_SYSTEM"
                    Return report.ExamCardiovascularSystem
                Case "ABDOMEN_DERMATOLOGICAL"
                    Return report.ExamAbdomen
                Case "NEUROLOGICAL_DISORDER"
                    Return report.ExamNervousSystem
                Case "PHYSICAL_DISABILITY"
                    Return report.ExamExtremities
                Case "WEIGHT"
                    Return report.ExamWeight
                Case "HEIGHT"
                    Return report.ExamHeight
                Case "CHEST_XRAY", "XRAY"
                    Return report.ExamChestXRay
                Case "RIGHT_EYE"
                    Return report.ExamRightEye
                Case "LEFT_EYE"
                    Return report.ExamLeftEye
                Case "RIGHT_EAR"
                    Return report.ExamRightEar
                Case "LEFT_EAR"
                    Return report.ExamLeftEar
                Case Else
                    Return Nothing
            End Select
        End Function

        Private Shared Function GetClinicalDefaultValue(template As MedicalFitnessReportExamTemplate) As String
            If template Is Nothing Then
                Return Nothing
            End If
            ' Use only the value configured in the examination-item master.
            ' Do not insert legacy NAD/NORMAL fallbacks for items whose
            ' DefaultValue is blank.
            Return template.DefaultValue
        End Function

        Private Shared Function GetLegacyResultStatus(value As String) As String
            Select Case If(value, "").Trim().ToUpperInvariant()
                Case "F", "FIT", "NAD", "NORMAL"
                    Return "F"
                Case "U", "UNFIT", "ABNORMAL"
                    Return "U"
                Case Else
                    Return Nothing
            End Select
        End Function

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
            Dim labTemplates = _dao.GetActiveLabTemplates().ToDictionary(
                Function(item) item.TestCode,
                StringComparer.OrdinalIgnoreCase)
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
                Dim configuredTemplate As MedicalFitnessReportLabTemplate = Nothing
                If Not String.IsNullOrWhiteSpace(analysis.TestCode) Then
                    configuredTemplate = FindLabTemplate(labTemplates, analysis.TestCode)
                End If
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

                If configuredTemplate IsNot Nothing AndAlso matchingRow.Sequence <= 0 Then
                    matchingRow.Sequence = Math.Max(200, configuredTemplate.DisplayOrder)
                End If

                matchingRow.SectionCode = "LAB"
                matchingRow.TestCode = analysis.TestCode
                ApplyLabAnalysis(matchingRow, analysis, configuredTemplate)
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

        Private Shared Sub AddLabRow(rows As List(Of MedicalFitnessReportTestResult),
                                     analysis As MedicalFitnessReportLabAnalysis,
                                     sequence As Int32,
                                     configuredTemplate As MedicalFitnessReportLabTemplate)
            Dim row = New MedicalFitnessReportTestResult With {
                .SectionCode = "LAB",
                .TestCode = analysis.TestCode,
                .TestNameEnglish = If(configuredTemplate Is Nothing, analysis.TestNameEnglish, GetLabEnglishName(configuredTemplate)),
                .TestNameArabic = If(configuredTemplate Is Nothing, Nothing, GetLabArabicName(configuredTemplate)),
                .Sequence = If(configuredTemplate Is Nothing OrElse configuredTemplate.DisplayOrder < 200,
                               sequence,
                               configuredTemplate.DisplayOrder)}
            ApplyLabAnalysis(row, analysis, configuredTemplate)
            rows.Add(row)
        End Sub

        Private Shared Sub ApplyLabAnalysis(row As MedicalFitnessReportTestResult,
                                            analysis As MedicalFitnessReportLabAnalysis,
                                            configuredTemplate As MedicalFitnessReportLabTemplate)
            If configuredTemplate Is Nothing Then
                row.TestNameEnglish = analysis.TestNameEnglish
                row.TestNameArabic = Nothing
            Else
                row.TestNameEnglish = GetLabEnglishName(configuredTemplate)
                row.TestNameArabic = GetLabArabicName(configuredTemplate)
                If configuredTemplate.CopyResultToEntry AndAlso
                   Not String.IsNullOrWhiteSpace(analysis.ResultValue) Then
                    row.ResultText = analysis.ResultValue
                End If
            End If

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

        Private Shared Function GetLabEnglishName(template As MedicalFitnessReportLabTemplate) As String
            If template Is Nothing Then
                Return ""
            End If
            If Not String.IsNullOrWhiteSpace(template.EnglishNameOverride) Then
                Return template.EnglishNameOverride.Trim()
            End If
            If Not String.IsNullOrWhiteSpace(template.TestNameEnglish) Then
                Return template.TestNameEnglish.Trim()
            End If
            Return template.TestCode
        End Function

        Private Shared Function FindLabTemplate(
            templates As IDictionary(Of String, MedicalFitnessReportLabTemplate),
            testCode As String) As MedicalFitnessReportLabTemplate
            If templates Is Nothing OrElse String.IsNullOrWhiteSpace(testCode) Then
                Return Nothing
            End If

            Dim template As MedicalFitnessReportLabTemplate = Nothing
            If templates.TryGetValue(testCode.Trim(), template) Then
                Return template
            End If

            Dim alternateCode As String
            If testCode.Trim().StartsWith("Item_", StringComparison.OrdinalIgnoreCase) Then
                alternateCode = testCode.Trim().Substring(5)
            Else
                alternateCode = "Item_" & testCode.Trim()
            End If

            If templates.TryGetValue(alternateCode, template) Then
                Return template
            End If

            Return Nothing
        End Function

        Private Shared Function GetLabArabicName(template As MedicalFitnessReportLabTemplate) As String
            If template Is Nothing Then
                Return Nothing
            End If
            If Not String.IsNullOrWhiteSpace(template.ArabicNameOverride) Then
                Return template.ArabicNameOverride.Trim()
            End If
            If Not String.IsNullOrWhiteSpace(template.TestNameArabic) Then
                Return template.TestNameArabic.Trim()
            End If
            Return Nothing
        End Function

        Private Shared Function ToViewRows(rows As List(Of MedicalFitnessReportTestResult)) As BindingList(Of MedicalFitnessReportTestResultView)
            Dim list As New BindingList(Of MedicalFitnessReportTestResultView)
            If rows Is Nothing Then
                Return list
            End If

            For Each row In rows.OrderBy(Function(item) GetSectionSortOrder(item.SectionCode)).
                         ThenBy(Function(item) item.Sequence).
                         ThenBy(Function(item) item.IdNo)
                list.Add(New MedicalFitnessReportTestResultView With {
                    .IdNo = row.IdNo,
                    .MedicalFitnessReportIdNo = row.MedicalFitnessReportIdNo,
                    .SectionCode = row.SectionCode,
                    .TestCode = row.TestCode,
                    .TestNameEnglish = row.TestNameEnglish,
                    .TestNameArabic = row.TestNameArabic,
                    .Sequence = row.Sequence,
                    .InputMode = row.InputMode,
                    .IsRequired = row.IsRequired,
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

            For Each row In rows.OrderBy(Function(item) GetSectionSortOrder(item.SectionCode)).
                         ThenBy(Function(item) item.Sequence).
                         ThenBy(Function(item) item.IdNo)
                list.Add(New MedicalFitnessReportTestResult With {
                    .IdNo = row.IdNo,
                    .MedicalFitnessReportIdNo = row.MedicalFitnessReportIdNo,
                    .SectionCode = row.SectionCode,
                    .TestCode = row.TestCode,
                    .TestNameEnglish = row.TestNameEnglish,
                    .TestNameArabic = row.TestNameArabic,
                    .Sequence = row.Sequence,
                    .InputMode = row.InputMode,
                    .IsRequired = row.IsRequired,
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

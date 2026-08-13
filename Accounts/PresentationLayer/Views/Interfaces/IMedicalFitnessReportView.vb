Imports System.ComponentModel
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IMedicalFitnessReportView
        Inherits IView

        Property ReportIdNo As Int32
        Property InvoiceNo As Int32
        Property InvoiceDate As Date?
        Property FileNo As Int32?
        Property PatientName As String
        Property Gender As String
        Property Age As String
        Property Nationality As String
        Property IdentityNo As String
        Property DoctorName As String
        Property BloodType As String
        Property FinalResultStatus As String
        Property Remarks As String
        Property TestResults As BindingList(Of MedicalFitnessReportTestResultView)
        ReadOnly Property SelectedTestResult As MedicalFitnessReportTestResultView

        Event RetrieveRequested()
        Event RefreshLabResultsRequested()
        Event ViewKizenResultsRequested()
        Event SaveRequested()
        Event DeleteRequested()

        Sub ShowKizenGroupedResults(testName As String, results As BindingList(Of MedicalFitnessGroupedLabResultView))

    End Interface

End Namespace

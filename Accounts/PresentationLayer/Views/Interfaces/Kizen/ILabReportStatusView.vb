Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ILabReportStatusView
        Inherits IView
        Property Age As String
        Property RequestedBy As String
        Property PatientName As String
        Property PatientNameMRN As String
        Property Gender As String
        Property InvoiceNo As Int32
        Property MRN As Int32
        Property Nationality As String
        Property CollectedBy As String
        Property CollectedDateTime As DateTime?
        Property Completed As Boolean?
        Property ProcessedBy As String
        Property ProcessedDateTime As DateTime?
        Property RequestedDateTime As String
        Property SampleNo As Int32
        Property ValidatedBy As String
        Property ValidatedDateTime As DateTime?

        Event LabReportStatusRequested(invoiceNo As Int32)

    End Interface

End Namespace
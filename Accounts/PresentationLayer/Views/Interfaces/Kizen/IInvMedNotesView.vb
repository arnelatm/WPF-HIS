Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IInvMedNotesView
        Inherits IView
        Property InvoiceDate As Date
        Property PatientName As String
        Property Gender As String
        Property Age As String
        Property InvoiceNo As Int32
        Property DoctorName As String
        Property InvMedNotesDetails As List(Of InvMedNotesDetailView)
        Property MRN As Integer
        Property Nationality As String

        Event InvMedNotesRequested(invoiceNo As Int32)
        Event InvMedNotesChanged(bindingSource As BindingSource)

    End Interface

    Public Interface IInvMedNotesDetailView
        Inherits IView

        Property IdNo As Int32
        Property Seq As Int32
        Property ItemCode As String
        Property ItemName As String
        Property Note As String
        Property MRN As Integer
    End Interface

End Namespace
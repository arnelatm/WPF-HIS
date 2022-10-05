Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPmrPatientDisplayView
        Inherits IView

        Property InvoiceDate As DateTime
        Property [Name] As String
        Property [Status] As Boolean
        Property [Token] As String
        Property PType As String
        Property FileNo As String
        Property InvType As String
        Property TransKey As Integer

    End Interface

End Namespace
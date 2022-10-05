Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Class PmrPatientDisplayView
        Implements IPmrPatientDisplayView

        Public Property Token As String Implements IPmrPatientDisplayView.Token
        Public Property Status As Boolean Implements IPmrPatientDisplayView.Status
        Public Property FileNo As String Implements IPmrPatientDisplayView.FileNo
        Public Property Name As String Implements IPmrPatientDisplayView.Name
        Public Property PType As String Implements IPmrPatientDisplayView.PType
        Public Property InvType As String Implements IPmrPatientDisplayView.InvType
        Public Property InvoiceDate As DateTime Implements IPmrPatientDisplayView.InvoiceDate
        Public Property TransKey As Int32 Implements IPmrPatientDisplayView.TransKey
        Public Property Errors As List(Of String) Implements IView.Errors

    End Class

End Namespace
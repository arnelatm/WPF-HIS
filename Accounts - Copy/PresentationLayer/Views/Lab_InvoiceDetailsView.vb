Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class Lab_InvoiceDetailsView
        Implements ILab_InvoiceDetailsView

        Public Property Errors As List(Of String) Implements IView.Errors

        Public Property Group_Key As Decimal Implements ILab_InvoiceDetailsView.Group_Key

        Public Property SlNo As Decimal Implements ILab_InvoiceDetailsView.SlNo

        Public Property Diagnosis1 As String Implements ILab_InvoiceDetailsView.Diagnosis1

        Public Property Result1 As String Implements ILab_InvoiceDetailsView.Result1

        Public Property Suffix1 As String Implements ILab_InvoiceDetailsView.Suffix1

    End Class

End Namespace
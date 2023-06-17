Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PrescriptionDetailView
        Implements IPrescriptionDetailView

        Public Property ItemNameEnglish As String Implements IPrescriptionDetailView.ItemNameEnglish
        Public Property DosageEnglish As String Implements IPrescriptionDetailView.DosageEnglish
        Public Property Duration As String Implements IPrescriptionDetailView.Duration
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property DataFilter As String Implements IView.DataFilter

    End Class

End Namespace
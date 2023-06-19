Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PrescriptionDetailView
        Implements IPrescriptionDetailView

        Public Property DataFilter As String Implements IView.DataFilter
        Public Property DosageEnglish As String Implements IPrescriptionDetailView.DosageEnglish
        Public Property Duration As String Implements IPrescriptionDetailView.Duration
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property Item_Code As String Implements IPrescriptionDetailView.Item_Code
        Public Property ItemNameEnglish As String Implements IPrescriptionDetailView.ItemNameEnglish
        Public Property RowNbr As Integer Implements IPrescriptionDetailView.RowNbr
        Public Property Trans_Key As Integer Implements IPrescriptionDetailView.Trans_Key
        Public Property Print As Boolean Implements IPrescriptionDetailView.Print

    End Class

End Namespace
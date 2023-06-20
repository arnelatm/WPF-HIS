Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PrescriptionDetailView
        Implements IPrescriptionDetailView

        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Dosage As String Implements IPrescriptionDetailView.Dosage
        Public Property Duration As String Implements IPrescriptionDetailView.Duration
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property ItemCode As String Implements IPrescriptionDetailView.ItemCode
        Public Property ItemName As String Implements IPrescriptionDetailView.ItemName
        Public Property RowNbr As Integer Implements IPrescriptionDetailView.RowNbr
        Public Property TransKey As Integer Implements IPrescriptionDetailView.TransKey
        Public Property Print As Boolean Implements IPrescriptionDetailView.Print

    End Class

End Namespace
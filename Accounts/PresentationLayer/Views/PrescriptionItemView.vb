Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PrescriptionItemView
        Implements IPrescriptionItemView

        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Dosage As String Implements IPrescriptionItemView.Dosage
        Public Property Duration As String Implements IPrescriptionItemView.Duration
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property GenericName As String Implements IPrescriptionItemView.GenericName
        Public Property ItemCode As String Implements IPrescriptionItemView.ItemCode
        Public Property ItemIdNo As Integer Implements IPrescriptionItemView.ItemIdNo
        Public Property ItemName As String Implements IPrescriptionItemView.ItemName
        Public Property LabelPrinted As Boolean Implements IPrescriptionItemView.LabelPrinted
        Public Property PrescriptionItemIdNo As Integer Implements IPrescriptionItemView.PrescriptionItemIdNo
        Public Property PrintLabel As Boolean Implements IPrescriptionItemView.PrintLabel
        Public Property RowNbr As Integer Implements IPrescriptionItemView.RowNbr
        Public Property TransKey As Integer Implements IPrescriptionItemView.TransKey

    End Class

    'Public Class PrescriptionDetailView
    '    Implements IPrescriptionDetailView

    '    Public Property DataFilter As String Implements IView.DataFilter
    '    Public Property Dosage As String Implements IPrescriptionDetailView.Dosage
    '    Public Property Duration As String Implements IPrescriptionDetailView.Duration
    '    Public Property Errors As List(Of String) Implements IView.Errors
    '    Public Property GenericName As String Implements IPrescriptionDetailView.GenericName
    '    Public Property ItemCode As String Implements IPrescriptionDetailView.ItemCode
    '    Public Property ItemIdNo As Int32 Implements IPrescriptionDetailView.ItemIdNo
    '    Public Property ItemName As String Implements IPrescriptionDetailView.ItemName
    '    Public Property LabelPrinted As Boolean Implements IPrescriptionDetailView.LabelPrinted
    '    Public Property PrescriptionItemIdNo As Integer Implements IPrescriptionDetailView.PrescriptionItemIdNo
    '    Public Property PrintLabel As Boolean Implements IPrescriptionDetailView.PrintLabel
    '    Public Property RowNbr As Integer Implements IPrescriptionDetailView.RowNbr
    '    Public Property TransKey As Integer Implements IPrescriptionDetailView.TransKey

    'End Class

End Namespace
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPrescriptionItemView
        Inherits IView

        Property Dosage As String
        Property Duration As String
        Property GenericName As String
        Property ItemCode As String
        Property ItemName As String
        Property LabelPrinted As Boolean
        Property PrescriptionItemIdNo As Int32
        Property PrintLabel As Boolean
        Property RowNbr As Int32
        Property TransKey As Int32

    End Interface

End Namespace
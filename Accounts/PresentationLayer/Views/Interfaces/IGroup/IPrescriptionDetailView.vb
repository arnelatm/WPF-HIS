Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPrescriptionDetailView
        Inherits IView

        Property ItemName As String
        Property Dosage As String
        Property Duration As String
        Property TransKey As Int32
        Property RowNbr As Int32
        Property ItemCode As String
        Property Print As Boolean
    End Interface

End Namespace
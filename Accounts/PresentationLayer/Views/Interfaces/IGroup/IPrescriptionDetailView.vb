Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPrescriptionDetailView
        Inherits IView

        Property ItemNameEnglish As String
        Property DosageEnglish As String
        Property Duration As String
        Property Trans_Key As Int32
        Property RowNbr As Int32
        Property Item_Code As String
        Property Print As Boolean
    End Interface

End Namespace
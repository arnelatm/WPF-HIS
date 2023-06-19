Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PrescriptionDetailModel

        Property ItemNameEnglish As String
        Property DosageEnglish As String
        Property Duration As String
        Property Item_Code As String
        Property Trans_Key As Int32
        Property RowNbr As Int32
        Property Print As Boolean

    End Class

End Namespace
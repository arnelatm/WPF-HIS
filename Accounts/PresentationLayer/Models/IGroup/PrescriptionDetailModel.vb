Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PrescriptionDetailModel

        Property ItemName As String
        Property Dosage As String
        Property Duration As String
        Property ItemCode As String
        Property TransKey As Int32
        Property RowNbr As Int32
        Property Print As Boolean

    End Class

End Namespace
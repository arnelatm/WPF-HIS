Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PrescriptionItemModel

        Property Dosage As String
        Property Duration As String
        Property GenericName As String
        Property ItemCode As String
        Property ItemIdNo As Int32
        Property ItemName As String
        Property LabelPrinted As Boolean
        Property PrescriptionItemIdNo As Int32
        Property PrintLabel As Boolean
        Property RowNbr As Int32
        Property TransKey As Int32

    End Class

End Namespace
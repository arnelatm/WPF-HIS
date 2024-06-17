Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PrescriptionItemModel

        Public Property Dosage As String
        Public Property Duration As String
        Public Property GenericName As String
        Public Property ItemCode As String
        Public Property ItemIdNo As Int32
        Public Property ItemName As String
        Public Property LabelPrinted As Boolean
        Public Property PrescriptionItemIdNo As Int32
        Public Property PrintLabel As Boolean
        Public Property RowNbr As Int32
        Public Property TransKey As Int32

    End Class

End Namespace
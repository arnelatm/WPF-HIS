Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DoctorsPatientModel

        Public Property InvoiceDate As String
        Public Property [Name] As String
        Public Property [Status] As Boolean
        Public Property [Token] As String
        Public Property PType As String
        Public Property FileNo As String
        Public Property InvType As String
        Public Property TransKey As Integer
        Public Property LastConsDate As String
        Public Property InvTime As Date
        Public Property PatientIdNo As Int32

    End Class

    Public Class PmrPatientDisplayModel

        Public Property InvoiceDate As String
        Public Property [Name] As String
        Public Property [Status] As Boolean
        Public Property [Token] As String
        Public Property PType As String
        Public Property FileNo As String
        Public Property InvType As String
        Public Property TransKey As Integer
        Public Property LastConsDate As String
        Public Property InvTime As Date

    End Class

End Namespace
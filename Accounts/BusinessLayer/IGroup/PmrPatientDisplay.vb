' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Namespace BusinessLayer

    Public Class PmrPatientDisplay
        Inherits AATM.BusinessLayer.BusinessObject

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
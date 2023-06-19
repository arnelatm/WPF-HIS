' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Namespace BusinessLayer

    Public Class DoctorsPatient
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
        Public Property PatientIdNo As Int32

    End Class

    Public Class Prescription

        Public Property PatientIdNo As Int32
        Public Property Series As String
        Public Property TransKey As Integer
        Public Property InvoiceDate As String
        Public Property PatientName As String
        Public Property [Status] As Boolean
        Public Property [Token] As String
        Public Property PType As String
        Public Property FileNo As String


        Public Property LastConsDate As String
        Public Property InvTime As Date


    End Class

End Namespace
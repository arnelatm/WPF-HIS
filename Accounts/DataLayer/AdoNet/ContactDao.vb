Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    Public Class ContactDao
        Inherits CommonDao
        Implements IDaoReadOnly(Of Contact)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As Contact Implements IDaoReadOnly(Of Contact).GetRecordByIdNo
            Const sql As String = "SELECT IdNo, ContactCode, ContactName, ContactNameAra, CSECode, CSEIdNo FROM dbo.Contact_View WHERE IdNo = @IdNo"
            Return Db.Read(sql, Make, {"@IdNo", idNo}).FirstOrDefault()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Contact) =
            Function(reader) New Contact() With {
                .IdNo = Extensions.AsInt(Of Int32)(reader("IdNo")),
                .ContactCode = Extensions.AsString(reader("ContactCode")),
                .ContactName = Extensions.AsString(reader("ContactName")),
                .ContactNameAra = Extensions.AsString(reader("ContactNameAra")),
                .CSECode = Extensions.AsString(reader("CSECode")),
                .CSEIdNo = Extensions.AsInt(Of Int32)(reader("CSEIdNo"))
            }
    End Class
End Namespace

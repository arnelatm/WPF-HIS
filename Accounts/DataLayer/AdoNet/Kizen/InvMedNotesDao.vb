Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class InvMedNotesDao
        Inherits CommonDao
        Implements IDaoParametrized(Of InvMedNotes), IDao(Of InvMedNotes)

        Private ReadOnly _db As New Db("Kizen")


        Private ReadOnly _fieldList As String = "Age," &
                                                "DoctorName," &
                                                "Gender," &
                                                "InvoiceDate," &
                                                "InvoiceNo," &
                                                "MRN," &
                                                "Nationality," &
                                                "PatientName"

        Public Overrides Function GetDB()
            Return _db
        End Function

        'Public Overrides Function GetPrimaryFieldName()
        '    Return "Trans_Key"
        'End Function

        Public Function GetRecordByIdNo(invoiceNo) As InvMedNotes Implements IDao(Of InvMedNotes).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " & _fieldList &
                    " FROM InvMedNotes_View" &
                    " WHERE InvoiceNo = @InvoiceNo"
            Dim params() As Object = {"@InvoiceNo", invoiceNo}

            Dim value As InvMedNotes = _db.Read(sql, Make, params).FirstOrDefault()
            Dim sql2 As String
            sql2 = $"SELECT Row_Number() Over (Order by IdNo) as Seq,IdNo,ItemCode,ItemName,Note from InvMedNotes_View where InvoiceNo = @InvoiceNo "
            If invoiceNo = 0 Then
                'value.InvMedNotesDetails = Nothing
            Else
                value.InvMedNotesDetails = _db.Read(sql2, MakeInvMedNotesDetails, params).ToList()
            End If
            Return value
        End Function

        Public Function GetParametrized(Of InvMedNotesModel)(parameter As Object, Optional sortExpression As String = Nothing) As InvMedNotes Implements IDaoParametrized(Of InvMedNotes).GetParametrized
            If parameter Is Nothing Then
                AATM.Libraries.MessagingLibrary.Messaging.Show("MsgDateCannotBeBlank")
                Return Nothing
            End If
            Dim invoiceNo As Int32 = parameter(0)
            Dim sql As String
            Dim data As New InvMedNotes
            Dim params() As Object = {"@InvoiceNo", invoiceNo}
            sql = $"SELECT Row_Number() Over (Order by IdNo) as Seq,IdNo,ItemCode,ItemName,Note from InvMedNotes_View where InvoiceNo = @InvoiceNo "
            data.InvMedNotesDetails = _db.Read(sql, MakeInvMedNotesDetails, params).ToList()
            Return data
        End Function


        Public Function AddRecord(ByRef recordData As InvMedNotes) As Integer Implements IDao(Of InvMedNotes).AddRecord
            Return 0
        End Function

        Public Function UpdateRecord(ByRef recordData As InvMedNotes) As Integer Implements IDao(Of InvMedNotes).UpdateRecord
            Return 0
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, InvMedNotes) = Function(reader) New InvMedNotes() With
        {
        .Age = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Age")),
        .DoctorName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DoctorName")),
        .Gender = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Gender")),
        .InvoiceDate = AATM.DataLayer.AdoNet.Extensions.AsString(reader("InvoiceDate")),
        .InvoiceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("InvoiceNo")),
        .MRN = AATM.DataLayer.AdoNet.Extensions.AsString(reader("MRN")),
        .Nationality = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Nationality")),
        .PatientName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PatientName"))}

        'Public Function UpdateInvMedNotesDetail(IdNo As Int32, urine As Boolean, stool As Boolean, rbs As Decimal)
        '    Dim sql As String =
        '            " UPDATE [InvMedNotesTaken] Set" &
        '            " Urine = @Urine," &
        '            " Stool = @Stool," &
        '            " Rbs = @Rbs" &
        '            " WHERE IdNo = @IdNo"
        '    Return _db.Update(sql, {"@Urine", urine, "@Stool", stool, "@Rbs", rbs})
        'End Function

        Private Shared ReadOnly MakeInvMedNotesDetails As Func(Of IDataReader, InvMedNotesDetail) = Function(reader) New InvMedNotesDetail() With
            {
            .Seq = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Seq")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .ItemCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemCode")),
            .ItemName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemName")),
            .Note = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Note"))
            }

    End Class


    Public Class InvMedNotesDetailDao
        Inherits AccountsDao

        Private ReadOnly _fieldList As String = "IdNo," &
                                                "ItemCode" &
                                                "ItemName," &
                                                "Seq," &
                                                "Note"


        Private ReadOnly _db As New Db()

        Public Sub New(connectionName As String)
            _db = New Db(connectionName)
        End Sub

        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Function UpdateRecord(idNo As Int32, note As String)
            Dim sql As String =
                    " UPDATE A1_OrderWorks Set" &
                    " Note = @Note " &
                    " WHERE Id = @IdNo"
            Return _db.Update(sql, {"@Note", note, "@IdNo", idNo})
        End Function

    End Class


End Namespace
Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class LabReportStatusDao
        Inherits CommonDao
        Implements IDaoParametrized(Of LabReportStatus), IDao(Of LabReportStatus)

        Private ReadOnly _db As New Db("Kizen")


        Private ReadOnly _fieldList As String = "Age," &
                                                "DoctorName," &
                                                "Gender," &
                                                "InvoiceDate," &
                                                "InvoiceNo," &
                                                "MRN," &
                                                "Nationality," &
                                                "CollectedBy," &
                                                "CollectedDateTime," &
                                                "ProcessedBy," &
                                                "ProcessedDateTime," &
                                                "ValidatedBy," &
                                                "ValidatedDateTime," &
                                                "Completed"

        Public Overrides Function GetDB()
            Return _db
        End Function

        'Public Overrides Function GetPrimaryFieldName()
        '    Return "Trans_Key"
        'End Function

        Public Function GetRecordByIdNo(invoiceNo) As LabReportStatus Implements IDao(Of LabReportStatus).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " & _fieldList &
                    " FROM LabReportStatus_View" &
                    " WHERE InvoiceNo = @InvoiceNo"
            Dim params() As Object = {"@InvoiceNo", invoiceNo}

            Dim value As LabReportStatus = _db.Read(sql, Make, params).FirstOrDefault()
            Dim sql2 As String
            sql2 = $"SELECT Row_Number() Over (Order by IdNo) as Seq,IdNo,ItemCode,ItemName,Note from LabReportStatus_View where InvoiceNo = @InvoiceNo "
            If invoiceNo = 0 Then
                'value.LabReportStatusDetails = Nothing
            Else
                value.LabReportStatusDetails = _db.Read(sql2, MakeLabReportStatusDetails, params).ToList()
            End If
            Return value
        End Function

        Public Function GetParametrized(Of LabReportStatusModel)(parameter As Object, Optional sortExpression As String = Nothing) As LabReportStatus Implements IDaoParametrized(Of LabReportStatus).GetParametrized
            If parameter Is Nothing Then
                AATM.Libraries.MessagingLibrary.Messaging.Show("MsgDateCannotBeBlank")
                Return Nothing
            End If
            Dim invoiceNo As Int32 = parameter(0)
            Dim sql As String
            Dim data As New LabReportStatus
            Dim params() As Object = {"@InvoiceNo", invoiceNo}
            sql = $"SELECT Row_Number() Over (Order by IdNo) as Seq,IdNo,ItemCode,ItemName,Note from LabReportStatus_View where InvoiceNo = @InvoiceNo "
            data.LabReportStatusDetails = _db.Read(sql, MakeLabReportStatusDetails, params).ToList()
            Return data
        End Function


        Public Function AddRecord(ByRef recordData As LabReportStatus) As Integer Implements IDao(Of LabReportStatus).AddRecord
            Return 0
        End Function

        Public Function UpdateRecord(ByRef recordData As LabReportStatus) As Integer Implements IDao(Of LabReportStatus).UpdateRecord
            Return 0
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, LabReportStatus) = Function(reader) New LabReportStatus() With
        {
        .Age = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Age")),
        .DoctorName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DoctorName")),
        .Gender = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Gender")),
        .InvoiceDate = AATM.DataLayer.AdoNet.Extensions.AsString(reader("InvoiceDate")),
        .InvoiceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("InvoiceNo")),
        .MRN = AATM.DataLayer.AdoNet.Extensions.AsString(reader("MRN")),
        .Nationality = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Nationality")),
        .PatientName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PatientName"))}

        'Public Function UpdateLabReportStatusDetail(IdNo As Int32, urine As Boolean, stool As Boolean, rbs As Decimal)
        '    Dim sql As String =
        '            " UPDATE [LabReportStatusTaken] Set" &
        '            " Urine = @Urine," &
        '            " Stool = @Stool," &
        '            " Rbs = @Rbs" &
        '            " WHERE IdNo = @IdNo"
        '    Return _db.Update(sql, {"@Urine", urine, "@Stool", stool, "@Rbs", rbs})
        'End Function

        Private Shared ReadOnly MakeLabReportStatusDetails As Func(Of IDataReader, LabReportStatusDetail) = Function(reader) New LabReportStatusDetail() With
            {
            .Seq = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Seq")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .ItemCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemCode")),
            .ItemName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemName")),
            .Note = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Note"))
            }

    End Class


    Public Class LabReportStatusDetailDao
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
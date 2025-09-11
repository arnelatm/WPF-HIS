Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class ClinicLabSampleDao
        Inherits CommonDao
        Implements IDaoParametrized(Of ClinicLabSample), IDao(Of ClinicLabSample)

        Private ReadOnly _db As New Db("IGROUPCLINIC")

        Public Overrides Function GetDB()
            Return _db
        End Function

        'Public Overrides Function GetPrimaryFieldName()
        '    Return "Trans_Key"
        'End Function

        Public Function GetRecordByIdNo(idNo) As ClinicLabSample Implements IDao(Of ClinicLabSample).GetRecordByIdNo
            Return Nothing
        End Function

        Public Function GetParametrized(Of ClinicLabSampleModel)(parameter As Object, Optional sortExpression As String = Nothing) As ClinicLabSample Implements IDaoParametrized(Of ClinicLabSample).GetParametrized
            If parameter(0) Is Nothing Then
                AATM.Libraries.Messaging.MessagingService.Show("MsgDateCannotBeBlank")
                Return Nothing
            End If
            Dim transactionDate As Date = parameter(0)
            Dim sql As String
            Dim data As New ClinicLabSample
            Dim transactionDateString As String = transactionDate.ToString("yyyy/MM/dd")
            data.TransactionDate = transactionDate
            Dim params() As Object = {"@TransactionDate", transactionDateString}
            sql = $"SELECT Row_Number() Over (Order by TakenTime) as 'Sequence',IdNo,TakenDate,TakenTime,LabNo,PatientNameEnglish,Age,ServiceNameEnglish,TakenBy from ClinicLabSampleCollectionServices_View where TransDateEnglish = @TransactionDate order by TakenTime"
            data.ClinicLabSampleDetails = _db.Read(sql, MakeClinicLabSampleDetails, params).ToList()
            Return data
        End Function


        Public Function AddRecord(ByRef recordData As ClinicLabSample) As Integer Implements IDao(Of ClinicLabSample).AddRecord
            Return 0
        End Function

        Public Function UpdateRecord(ByRef recordData As ClinicLabSample) As Integer Implements IDao(Of ClinicLabSample).UpdateRecord
            Return 0
        End Function

        Public Function UpdateClinicLabSampleDetail(IdNo As Int32, urine As Boolean, stool As Boolean, rbs As Decimal)
            Dim sql As String =
                    " UPDATE [ClinicLabSampleTaken] Set" &
                    " Urine = @Urine," &
                    " Stool = @Stool," &
                    " Rbs = @Rbs" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, {"@Urine", urine, "@Stool", stool, "@Rbs", rbs})
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, ClinicLabSample) = Function(reader) New ClinicLabSample() With
        {
        .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsString(reader("TransDateEnglish"))
        }

        Private Shared ReadOnly MakeClinicLabSampleDetails As Func(Of IDataReader, ClinicLabSampleDetail) = Function(reader) New ClinicLabSampleDetail() With
            {
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Sequence")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .IqamaNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Border_Iqama")),
            .TakenDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TakenDate")),
            .TakenTime = AATM.DataLayer.AdoNet.Extensions.AsTimeString(reader("TakenTime")),
            .LabNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("LabNo")),
            .PatientName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PatientNameEnglish")),
            .Age = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Age")),
            .DoctorName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DrNameShort")),
            .TakenBy = AATM.DataLayer.AdoNet.Extensions.AsString(reader("TakenBy")),
            .TestName = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("ServiceNameEnglish"))
            }

    End Class

End Namespace
Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class IbLabSampleDao
        Inherits CommonDao
        Implements IDaoParametrized(Of IbLabSample)

        Private ReadOnly _db As New Db("IGROUPCLINIC")

        Public Overrides Function GetDB()
            Return _db
        End Function

        'Public Overrides Function GetPrimaryFieldName()
        '    Return "Trans_Key"
        'End Function

        Public Function GetParametrized(Of IbLabSampleModel)(parameter As Object, Optional sortExpression As String = Nothing) As IbLabSample Implements IDaoParametrized(Of IbLabSample).GetParametrized
            If parameter(0) Is Nothing Then
                AATM.Libraries.MessagingLibrary.Messaging.Show("MsgDateCannotBeBlank")
                Return Nothing
            End If
            Dim transactionDate As Date = parameter(0)
            Dim sql As String
            Dim data As New IbLabSample
            Dim transactionDateString As String = transactionDate.ToString("yyyy/MM/dd")
            data.TransactionDate = transactionDate
            Dim params() As Object = {"@TransactionDate", transactionDateString}
            sql = $"SELECT Row_Number() Over (Order by TakenTime) as 'Sequence',IdNo,TakenDate,TakenTime,LabNo,Border_Iqama,PatientName,Age,CountryNameEng,Stool,Urine,RBS,TakenBy from IbLabSampleList_View where TransDateEnglish = @TransactionDate order by TakenTime"
            data.IbLabSampleDetails = _db.Read(sql, MakeIbLabSampleDetails, params).ToList()
            Return data
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, IbLabSample) = Function(reader) New IbLabSample() With
            {
            .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsString(reader("TransDateEnglish"))
            }

        Private Shared ReadOnly MakeIbLabSampleDetails As Func(Of IDataReader, IbLabSampleDetail) = Function(reader) New IbLabSampleDetail() With
            {
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Sequence")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .IqamaNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Border_Iqama")),
            .TakenDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TakenDate")),
            .TakenTime = AATM.DataLayer.AdoNet.Extensions.AsTimeString(reader("TakenTime")),
            .LabNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("LabNo")),
            .PatientName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PatientName")),
            .Age = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Age")),
            .Nationality = AATM.DataLayer.AdoNet.Extensions.AsString(reader("CountryNameEng")),
            .TakenBy = AATM.DataLayer.AdoNet.Extensions.AsString(reader("TakenBy")),
            .Urine = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Urine")),
            .Stool = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Stool")),
            .Rbs = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("RBS"))
            }

    End Class

End Namespace
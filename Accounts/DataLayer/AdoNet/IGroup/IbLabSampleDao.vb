Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class IbLabSampleDao
        Inherits CommonDao
        Implements IDaoParametrized(Of IbLabSample), IDao(Of IbLabSample)

        Private ReadOnly _db As New Db("IGROUPCLINIC")

        Public Overrides Function GetDB()
            Return _db
        End Function

        'Public Overrides Function GetPrimaryFieldName()
        '    Return "Trans_Key"
        'End Function

        Public Function GetRecordByIdNo(idNo) As IbLabSample Implements IDao(Of IbLabSample).GetRecordByIdNo
            Return Nothing
        End Function

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


        Public Function AddRecord(ByRef recordData As IbLabSample) As Integer Implements IDao(Of IbLabSample).AddRecord
            Return 0
        End Function

        Public Function UpdateRecord(ByRef recordData As IbLabSample) As Integer Implements IDao(Of IbLabSample).UpdateRecord
            Return 0
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, IbLabSample) = Function(reader) New IbLabSample() With
        {
        .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsString(reader("TransDateEnglish"))
        }

        'Public Function UpdateIbLabSampleDetail(IdNo As Int32, urine As Boolean, stool As Boolean, rbs As Decimal)
        '    Dim sql As String =
        '            " UPDATE [IbLabSampleTaken] Set" &
        '            " Urine = @Urine," &
        '            " Stool = @Stool," &
        '            " Rbs = @Rbs" &
        '            " WHERE IdNo = @IdNo"
        '    Return _db.Update(sql, {"@Urine", urine, "@Stool", stool, "@Rbs", rbs})
        'End Function

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

    Public Class IbLabResultDao
        Inherits CommonDao
        Implements IDaoParametrized(Of IbLabResult), IDao(Of IbLabResult)

        Private ReadOnly _db As New Db("IGROUPCLINIC")

        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Function GetRecordByIdNo(idNo) As IbLabResult Implements IDao(Of IbLabResult).GetRecordByIdNo
            Return Nothing
        End Function

        Public Function GetParametrized(Of IbLabResultModel)(parameter As Object, Optional sortExpression As String = Nothing) As IbLabResult Implements IDaoParametrized(Of IbLabResult).GetParametrized
            If parameter(0) Is Nothing Then
                AATM.Libraries.MessagingLibrary.Messaging.Show("MsgDateCannotBeBlank")
                Return Nothing
            End If
            Dim transactionDate As Date = parameter(0)
            Dim sql As String
            Dim data As New IbLabResult
            Dim transactionDateString As String = transactionDate.ToString("yyyy/MM/dd")
            data.TransactionDate = transactionDate
            Dim params() As Object = {"@TransactionDate", transactionDateString}
            sql = $"SELECT Row_Number() Over (Order by Trans_key) as 'Sequence',IdNo,Trans_Key,Sex,TransactionDate,LabNo,PatientName,CountryIOTA,PassportNumber,Profession,Border_Iqama,Clinical,XRay,TBSputum,HIVEliza,HCVEliza,HBSAgEliza,Malaria,VDRL,WIdal,Pregnancy,BilharziasisUrine,BilharziasisStool,SHigella,Cholera from IbLabResultList_View where TransactionDate = @TransactionDate order by Trans_key"
            data.IbLabResultDetails = _db.Read(sql, MakeIbLabResultDetails, params).ToList()
            Return data
        End Function


        Public Function AddRecord(ByRef recordData As IbLabResult) As Integer Implements IDao(Of IbLabResult).AddRecord
            Return 0
        End Function

        Public Function UpdateRecord(ByRef recordData As IbLabResult) As Integer Implements IDao(Of IbLabResult).UpdateRecord
            Return 0
        End Function



        Private Shared ReadOnly Make As Func(Of IDataReader, IbLabResult) = Function(reader) New IbLabResult() With
        {
        .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsString(reader("TransDateEnglish"))
        }

        'Public Function UpdateIbLabResultDetail(IdNo As Int32, passport As String, clinical As Boolean, Xray As Boolean, TBSputum As Boolean,
        '                                        hivEliza As Boolean, hcvEliza As Boolean, hbsagEliza As Boolean, malaria As Boolean, vdrl As Boolean,
        '                                        Widal As Boolean, pregnancy As Boolean, bilharziasisUrine As Boolean,
        '                                        bilharziasisStool As Boolean, shigella As Boolean, cholera As Boolean)
        '    Dim sql As String =
        '            " UPDATE [IbLabResultTaken] Set" &
        '            " Passport = @Passport," &
        '            " Clinical = @Clinical," &
        '            " Xray = @Xray," &
        '            " TBSputum = @TBSputum," &
        '            " HIVEliza = @HIVEliza," &
        '            " HCVEliza = @HCVEliza," &
        '            " HBSAgEliza = @HBSAgEliza," &
        '            " Malaria = @Malaria," &
        '            " VDRL = @VDRL," &
        '            " Widal = @Widal," &
        '            " Pregnancy = @Pregnancy," &
        '            " BilharziasisUrine = @BilharziasisUrine," &
        '            " BilharziasisStool = @BilharziasisUrStool," &
        '            " Shigella = @Shigella," &
        '            " Cholera = @Cholera" &
        '            " WHERE IdNo = @IdNo "
        '    Return _db.Update(sql, {"@Passport", passport, "@Clinical", clinical, "@Xray", Xray, "@TBSputum", TBSputum, "@HIVEliza", hivEliza,
        '            "@HCVEliza", hcvEliza, "@HBSAgEliza", hbsagEliza, "@Malaria", malaria, "@VDRL", vdrl, "@Widal", Widal, "@Pregnancy", pregnancy,
        '            "@BilharzizsisUrine", bilharziasisUrine, "@BilharzizsisStool", bilharziasisStool, "@Shigella", shigella, "@Cholera", cholera})
        'End Function

        Private Shared ReadOnly MakeIbLabResultDetails As Func(Of IDataReader, IbLabResultDetail) = Function(reader) New IbLabResultDetail() With
            {
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Sequence")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .TransKey = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Trans_key")),
            .Gender = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Char)(reader("Sex")),
            .LabNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("LabNo")),
            .PatientName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PatientName")),
            .Nationality = AATM.DataLayer.AdoNet.Extensions.AsString(reader("CountryIOTA")),
            .Profession = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Profession")),
            .PassportNumber = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PassportNumber")),
            .IqamaNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Border_Iqama")),
            .Clinical = SwitchValue(AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Boolean)(reader("Clinical"))),
            .XRay = SwitchValue(AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Boolean)(reader("Xray"))),
            .TBSputum = SwitchValue(AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Boolean)(reader("TBSputum"))),
            .HIVEliza = SwitchValue(AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Boolean)(reader("HIVEliza"))),
            .HCVEliza = SwitchValue(AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Boolean)(reader("HCVEliza"))),
            .HBSAgEliza = SwitchValue(AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Boolean)(reader("HBSAgEliza"))),
            .Malaria = SwitchValue(AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Boolean)(reader("Malaria"))),
            .VDRL = SwitchValue(AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Boolean)(reader("VDRL"))),
            .Widal = SwitchValue(AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Boolean)(reader("Widal"))),
            .Pregnancy = SwitchValue(AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Boolean)(reader("Pregnancy"))),
            .BilharziasisUrine = SwitchValue(AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Boolean)(reader("BilharziasisUrine"))),
            .BilharziasisStool = SwitchValue(AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Boolean)(reader("BilharziasisStool"))),
            .Shigella = SwitchValue(AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Boolean)(reader("Shigella"))),
            .Cholera = SwitchValue(AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Boolean)(reader("Cholera")))
            }

        Public Shared Function SwitchValue(value As Boolean?) As Boolean?
            ' reverse values - Null - True
            '                  False - Null
            '                  True - False
            If value.HasValue Then
                If value Then
                    Return True
                Else
                    Return Nothing
                End If
            Else
                Return False
            End If
        End Function
    End Class

End Namespace
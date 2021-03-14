Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Earning
    ' ** DAO Pattern

    Public Class EarningDao
        Implements IDao(Of Earning), IDaoAll(Of Earning), IDaoGetRecords(Of Earning), IDaoGetRecord(Of Earning)

        Private Const FieldList = "AccountIdNo," &
                                  "BasePaymentIdNo," &
                                  "CalculationType," &
                                  "DefaultQuantity," &
                                  "EarningCode," &
                                  "Summary," &
                                  "EarningName," &
                                  "EarningNameAra," &
                                  "EarningType," &
                                  "Frequency," &
                                  "IdNo," &
                                  "IncludeInEOS," &
                                  "Multiplier," &
                                  "MultiplierType," &
                                  "Notes," &
                                  "Rate," &
                                  "Taxable," &
                                  "Unit," &
                                  "UsePayGroups"

        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo) As Earning Implements IDao(Of Earning).GetRecordById
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [Earning]" &
                                " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            Dim peaDao = New PayrollEarnAccountDao()
            data.PayrollEarnAccounts = peaDao.GetRecordsWithGroupIdNo(idNo, "Sequence")
            Dim esDao = New EarningSummaryDao()
            data.EarningsSummary = esDao.GetRecordsWithGroupIdNo(idNo, "Sequence")
            Return data
        End Function

        Public Function UpdateRecord(ByRef earning As Earning) As Integer Implements IDao(Of Earning).UpdateRecord
            Dim sql As String = " UPDATE [Earning] Set" &
                    " AccountIdNo = @AccountIdNo," &
                    " BasePaymentIdNo = @BasePaymentIdNo," &
                    " CalculationType = @CalculationType," &
                    " DefaultQuantity = @DefaultQuantity," &
                    " EarningCode = @EarningCode," &
                    " Summary = @Summary," &
                    " EarningName = @EarningName," &
                    " EarningNameAra = @EarningNameAra," &
                    " EarningType = @EarningType," &
                    " Frequency = @Frequency," &
                    " IncludeInEos = @IncludeInEos," &
                    " Multiplier = @Multiplier," &
                    " MultiplierType = @MultiplierType," &
                    " Notes = @Notes," &
                    " Rate = @Rate," &
                    " Taxable = @Taxable," &
                    " Unit = @Unit," &
                    " UsePayGroups = @UsePayGroups" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(earning))
        End Function

        Public Function AddRecord(ByRef earning As Earning) As Integer Implements IDao(Of Earning).AddRecord
            Dim sql As String =
                    " INSERT INTO [Earning] " &
                    " (AccountIdNo,BasePaymentIdNo,CalculationType,DefaultQuantity,EarningCode,Summary,EarningName,EarningNameAra,EarningType,Frequency,IncludeInEos,Multiplier,MultiplierType,Notes,Rate,Taxable,Unit,UsePayGroups) " &
                    " VALUES (@AccountIdNo,@BasePaymentIdNo,@CalculationType,@DefaultQuantity,@EarningCode,@Summary,@EarningName,@EarningNameAra,@EarningType,@Frequency,@IncludeInEos,@Multiplier,@MultiplierType,@Notes,@Rate,@Taxable,@Unit,@UsePayGroups) "
            Return _db.Insert(sql, Take(earning))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Earning) =
                                    Function(reader) _
            New Earning() With {
            .AccountIdNo = Extensions.AsId(Of Int16)(reader("AccountIdNo")),
            .BasePaymentIdNo = Extensions.AsId(Of Int16)(reader("BasePaymentIdNo")),
            .CalculationType = Extensions.AsChar(reader("CalculationType")),
            .DefaultQuantity = Extensions.AsDecimal(reader("DefaultQuantity")),
            .EarningCode = Extensions.AsString(reader("EarningCode")),
            .Summary = Extensions.AsBool(reader("Summary")),
            .EarningName = Extensions.AsString(reader("EarningName")),
            .EarningNameAra = Extensions.AsString(reader("EarningNameAra")),
            .EarningType = Extensions.AsChar(reader("EarningType")),
            .Frequency = Extensions.AsChar(reader("Frequency")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .IncludeInEos = Extensions.AsBool(reader("IncludeInEos")),
            .Multiplier = Extensions.AsString(reader("Multiplier")),
            .MultiplierType = Extensions.AsString(reader("MultiplierType")),
            .Notes = Extensions.AsString(reader("Notes")),
            .Rate = Extensions.AsDouble(reader("Rate")),
            .Taxable = Extensions.AsBool(reader("Taxable")),
            .Unit = Extensions.AsChar(reader("Unit")),
            .UsePayGroups = Extensions.AsBool(reader("UsePayGroups"))
            }

        Private Function Take(earning As Earning) As Object()
            Return New Object() {
                                    "@AccountIdNo", earning.AccountIdNo,
                                    "@BasePaymentIdNo", earning.BasePaymentIdNo,
                                    "@CalculationType", earning.CalculationType,
                                    "@DefaultQuantity", earning.DefaultQuantity,
                                    "@EarningCode", earning.EarningCode,
                                    "@Summary", earning.Summary,
                                    "@EarningName", earning.EarningName,
                                    "@EarningNameAra", earning.EarningNameAra,
                                    "@EarningType", earning.EarningType,
                                    "@Frequency", earning.Frequency,
                                    "@IdNo", earning.IdNo,
                                    "@IncludeInEos", earning.IncludeInEos,
                                    "@Multiplier", earning.Multiplier,
                                    "@MultiplierType", earning.MultiplierType,
                                    "@Notes", earning.Notes,
                                    "@Rate", earning.Rate,
                                    "@Taxable", earning.Taxable,
                                    "@Unit", earning.Unit,
                                    "@UsePayGroups", earning.UsePayGroups
                                }
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Earning) Implements IDaoAll(Of Earning).GetAll
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "BasePaymentIdNo," &
                    "CalculationType," &
                    "DefaultQuantity," &
                    "EarningCode," &
                    "Summary," &
                    "EarningName," &
                    "EarningNameAra," &
                    "EarningType," &
                    "Frequency," &
                    "IdNo," &
                    "IncludeInEOS," &
                    "Multiplier," &
                    "MultiplierType," &
                    "Notes," &
                    "Rate," &
                    "Taxable," &
                    "Unit," &
                    "UsePayGroups" &
                    " FROM [Earning]"
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecords(Optional filter As String = Nothing) As List(Of Earning) Implements IDaoGetRecords(Of Earning).GetRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [Earning]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecord(Optional filter As String = Nothing) As Earning Implements IDaoGetRecord(Of Earning).GetRecord
            Dim sql As String = "SELECT Top 1 " &
                                FieldList &
                                " FROM [Earning]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return _db.Read(sql, Make).FirstOrDefault()
        End Function

    End Class

End Namespace
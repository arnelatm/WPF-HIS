Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Deduction
    ' ** DAO Pattern

    Public Class DeductionDao
        Implements IDao(Of Deduction), IDaoGetRecords(Of Deduction)

        Private ReadOnly _db As New Db()

        Const FieldList As String = "AccountIdNo," &
                                    "BasePaymentIdNo," &
                                    "CalculationType," &
                                    "DefaultQuantity," &
                                    "DeductionCode," &
                                    "DeductionName," &
                                    "DeductionNameAra," &
                                    "DeductionType," &
                                    "IdNo," &
                                    "Multiplier," &
                                    "MultiplierType," &
                                    "Notes," &
                                    "Rate," &
                                    "Unit," &
                                    "UsePayGroups"

        Public Function GetRecordById(idNo) As Deduction Implements IDao(Of Deduction).GetRecordById
            Dim sql As String = "SELECT " & FieldList &
                                " FROM [Deduction]" &
                                " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            Dim pdaDao = New PayrollDeductAccountDao()
            data.PayrollDeductAccounts = pdaDao.GetRecordsWithGroupIdNo(idNo, "Sequence")
            Return data
        End Function

        Public Function UpdateRecord(ByRef deduction As Deduction) As Integer Implements IDao(Of Deduction).UpdateRecord
            Dim sql As String = " UPDATE [Deduction] Set" &
                    " AccountIdNo = @AccountIdNo," &
                    " BasePaymentIdNo = @BasePaymentIdNo," &
                    " CalculationType = @CalculationType," &
                    " DefaultQuantity = @DefaultQuantity," &
                    " DeductionCode = @DeductionCode," &
                    " DeductionName = @DeductionName," &
                    " DeductionNameAra = @DeductionNameAra," &
                    " DeductionType = @DeductionType," &
                    " Multiplier = @Multiplier," &
                    " MultiplierType = @MultiplierType," &
                    " Notes = @Notes," &
                    " Rate = @Rate," &
                    " Unit = @Unit," &
                    " UsePayGroups = @UsePayGroups" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(deduction))
        End Function

        Public Function AddRecord(ByRef deduction As Deduction) As Integer Implements IDao(Of Deduction).AddRecord
            Dim sql As String =
                    " INSERT INTO [Deduction] " &
                    " (AccountIdNo,BasePaymentIdNo,CalculationType,DefaultQuantity,DeductionCode,DeductionName,DeductionNameAra,DeductionType,Multiplier,MultiplierType,Notes,Rate,Unit,UsePayGroups) " &
                    " VALUES (@AccountIdNo,@BasePaymentIdNo,@CalculationType,@DefaultQuantity,@DeductionCode,@DeductionName,@DeductionNameAra,@DeductionType,@Multiplier,@MultiplierType,@Notes,@Rate,@Unit,@UsePayGroups) "
            Return _db.Insert(sql, Take(deduction))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Deduction) =
                                    Function(reader) _
            New Deduction() With {
            .AccountIdNo = Extensions.AsId(Of Int16)(reader("AccountIdNo")),
            .BasePaymentIdNo = Extensions.AsId(Of Int16)(reader("BasePaymentIdNo")),
            .CalculationType = Extensions.AsChar(reader("CalculationType")),
            .DefaultQuantity = Extensions.AsDecimal(reader("DefaultQuantity")),
            .DeductionCode = Extensions.AsString(reader("DeductionCode")),
            .DeductionName = Extensions.AsString(reader("DeductionName")),
            .DeductionNameAra = Extensions.AsString(reader("DeductionNameAra")),
            .DeductionType = Extensions.AsChar(reader("DeductionType")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .Multiplier = Extensions.AsDouble(reader("Multiplier")),
            .MultiplierType = Extensions.AsString(reader("MultiplierType")),
            .Notes = Extensions.AsString(reader("Notes")),
            .Rate = Extensions.AsDouble(reader("Rate")),
            .Unit = Extensions.AsChar(reader("Unit")),
            .UsePayGroups = Extensions.AsBool(reader("UsePayGroups"))
            }

        Private Function Take(Deduction As Deduction) As Object()
            Return New Object() {
                                    "@AccountIdNo", Deduction.AccountIdNo,
                                    "@BasePaymentIdNo", Deduction.BasePaymentIdNo,
                                    "@CalculationType", Deduction.CalculationType,
                                    "@DefaultQuantity", Deduction.DefaultQuantity,
                                    "@DeductionCode", Deduction.DeductionCode,
                                    "@DeductionName", Deduction.DeductionName,
                                    "@DeductionNameAra", Deduction.DeductionNameAra,
                                    "@DeductionType", Deduction.DeductionType,
                                    "@IdNo", Deduction.IdNo,
                                    "@Multiplier", Deduction.Multiplier,
                                    "@MultiplierType", Deduction.MultiplierType,
                                    "@Notes", Deduction.Notes,
                                    "@Rate", Deduction.Rate,
                                    "@Unit", Deduction.Unit,
                                    "@UsePayGroups", Deduction.UsePayGroups
                                }
        End Function

        Public Function GetRecords(Optional filter As String = Nothing) As List(Of Deduction) Implements IDaoGetRecords(Of Deduction).GetRecords
            Dim sql As String = "SELECT " & FieldList &
                                " FROM [Deduction]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return _db.Read(sql, Make).ToList()
        End Function

    End Class

End Namespace
Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for InvTransType
    ' ** DAO Pattern

    Public Class InvTransTypeDao
        Inherits CommonDao
        Implements IDao(Of InvTransType)

        Private Const FieldList =
                          "Active," &
                          "AccountIdNo," &
                          "AddOrDeduct," &
                          "IdNo," &
                          "InvTransTypeCode," &
                          "InvTransTypeName," &
                          "InvTransTypeNameAra," &
                          "Notes"

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As InvTransType Implements IDao(Of InvTransType).GetRecordByIdNo
            Dim sql As String = " SELECT " & FieldList &
                    " FROM InvTransType" &
                    " WHERE IdNo = @IdNo and BranchIdNo = @BranchIdNo"
            Dim params() As Object = {"@IdNo", idNo, "@BranchIdNo", GlobalVariables.BranchIdNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            Return data
        End Function

        Public Function UpdateRecord(ByRef InvTransType As InvTransType) As Integer Implements IDao(Of InvTransType).UpdateRecord
            Dim sql As String = " UPDATE [InvTransType] Set" &
                    " Active = @Active," &
                    " AccountIdNo = @AccountIdNo," &
                    " AddOrDeduct = @AddOrDeduct," &
                    " InvTransTypeCode = @InvTransTypeCode," &
                    " InvTransTypeName = @InvTransTypeName," &
                    " InvTransTypeNameAra = @InvTransTypeNameAra," &
                    " Notes = @Notes" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(InvTransType))
        End Function

        Public Function AddRecord(ByRef InvTransType As InvTransType) As Integer Implements IDao(Of InvTransType).AddRecord
            Dim sql As String =
                    " INSERT INTO [InvTransType] " &
                    " (Active,AccountIdNo,AddOrDeduct,BranchIdNo,InvTransTypeCode,InvTransTypeName,InvTransTypeNameAra,Notes) " &
                    " VALUES (@Active,@AccountIdNo,@AddOrDeduct,@BranchIdNo,@InvTransTypeCode,@InvTransTypeName,@InvTransTypeNameAra,@Notes) "
            Return Db.Insert(sql, Take(InvTransType))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, InvTransType) =
                                    Function(reader) _
            New InvTransType() With {
            .Active = Extensions.AsBool(reader("Active")),
            .AccountIdNo = Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .AddOrDeduct = Extensions.AsString(reader("AddOrDeduct")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .InvTransTypeCode = Extensions.AsString(reader("InvTransTypeCode")),
            .InvTransTypeName = Extensions.AsString(reader("InvTransTypeName")),
            .InvTransTypeNameAra = Extensions.AsString(reader("InvTransTypeNameAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(InvTransType As InvTransType) As Object()
            Return New Object() {
                                    "@Active", InvTransType.Active,
                                    "@AccountIdNo", InvTransType.AccountIdNo,
                                    "@AddOrDeduct", InvTransType.AddOrDeduct,
                                    "@BranchIdNo", GlobalVariables.BranchIdNo,
                                    "@IdNo", InvTransType.IdNo,
                                    "@InvTransTypeCode", InvTransType.InvTransTypeCode,
                                    "@InvTransTypeName", InvTransType.InvTransTypeName,
                                    "@InvTransTypeNameAra", InvTransType.InvTransTypeNameAra,
                                    "@Notes", InvTransType.Notes
                                }
        End Function

    End Class

End Namespace

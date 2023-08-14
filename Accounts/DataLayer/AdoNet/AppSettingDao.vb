Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for AppSetting
    ' ** DAO Pattern

    Public Class AppSettingDao
        Inherits CommonDao
        Implements IDao(Of AppSetting)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As AppSetting Implements IDao(Of AppSetting).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, AppSettingGroupIdNo, Selector1IdNo, Selector2IdNo" &
                    "   FROM [AppSetting]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef AppSetting As AppSetting) As Integer Implements IDao(Of AppSetting).UpdateRecord
            Dim sql As String =
                    " UPDATE [AppSetting]" &
                    "    SET AppSettingGroupIdNo = @AppSettingGroupIdNo," &
                    "        Selector1IdNo = @Selector1IdNo," &
                    "        Selector2IdNo = @Selector2IdNo," &
                    "  WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(AppSetting))
        End Function

        Public Function AddRecord(ByRef AppSetting As AppSetting) As Integer Implements IDao(Of AppSetting).AddRecord
            Dim sql As String =
                    " INSERT INTO [AppSetting] " &
                    " (AppSettingGroupIdNo,Selector1IdNo,Selector2IdNo) " &
                    " VALUES (@AppSettingGroupIdNo,@Selector1IdNo,@Selector2IdNo) "
            Return Db.Insert(sql, Take(AppSetting))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, AppSetting) =
                                    Function(reader) _
            New AppSetting() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .AppSettingGroupIdNo = Extensions.AsString(reader("AppSettingGroupIdNo")),
            .Selector1IdNo = Extensions.AsInt(Of Int32)(reader("Selector1IdNo")),
            .Selector2IdNo = Extensions.AsInt(Of Int32)(reader("Selector2IdNo"))
            }

        Private Function Take(AppSetting As AppSetting) As Object()
            Return New Object() {
                                    "@IdNo", AppSetting.IdNo,
                                    "@AppSettingGroupIdNo", AppSetting.AppSettingGroupIdNo,
                                    "@Selector1IdNo", AppSetting.Selector1IdNo,
                                    "@Selector2IdNo", AppSetting.Selector2IdNo
                                }
        End Function

    End Class

End Namespace
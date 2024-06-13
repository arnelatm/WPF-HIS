Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for UserSecurity
    ' ** DAO Pattern

    Public Class UserSecurityDao
        Inherits BaseDao
        Implements IDao(Of UserSecurity), IDaoChild(Of UserAccess), IAutoCodeDao

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As UserSecurity Implements IDao(Of UserSecurity).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, UserName" &
                    "   FROM [UserSecurity]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            If data IsNot Nothing Then
                data.UserAccesses = GetRecordsWithGroupIdNo(idNo, "FullPathName")
            End If
            Return data
        End Function

        Public Function UpdateRecord(ByRef UserSecurity As UserSecurity) As Integer _
            Implements IDao(Of UserSecurity).UpdateRecord
            Dim sql As String =
                    " UPDATE [UserSecurity]" &
                    " Set UserName = @UserName," &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(UserSecurity))
        End Function

        Public Function AddRecord(ByRef UserSecurity As UserSecurity) As Integer _
            Implements IDao(Of UserSecurity).AddRecord
            Dim sql As String =
                    " INSERT INTO [User] " &
                    " (UserName)" &
                    " VALUES (@UserName)"
            Return Db.Insert(sql, Take(UserSecurity))
        End Function

        'Public Sub DeleteSecurityUser(UserSecurity As UserSecurity) Implements IDao(Of UserSecurity).DeleteSecurityUser
        '    Dim sql As String =
        '            " DELETE FROM [UserSecurity]" &
        '            "  WHERE IdNo = @IdNo"
        '    Db.Update(sql, Take(UserSecurity))
        'End Sub

        Private Shared ReadOnly Make As Func(Of IDataReader, UserSecurity) =
                                    Function(reader) _
            New UserSecurity() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .UserName = Extensions.AsString(reader("UserName"))}


        Private Function Take(UserSecurity As UserSecurity) As Object()
            Return New Object() {
                                    "@IdNo", UserSecurity.IdNo,
                                    "@UserName", UserSecurity.UserName}
        End Function

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) _
            As List(Of UserAccess) Implements IDaoChild(Of UserAccess).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "UserName"
            End If
            Dim sql As String =
                    "select b.IdNo , b.UserIdNo, a.IdNo as 'SecurityObjectIdNo', a.FullPathName as 'SecurityObjectName', b.Visible, b.Editable from SecurityObjectHierarchy_View a " &
                    "left join UserAccess b " &
                    "on a.IdNo = b.SecurityObjectIdNo  and b.UserIdNo = @UserIdNo " &
                    "Order By " & sortExpression & " ASC "
            Dim params() As Object = {"@UserIdNo", idNo}
            Return Db.Read(sql, MakeUserAccess, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, UserAccessIdNo As Int32) As Integer _
            Implements IDaoChild(Of UserAccess).DelUpdateTvp
            Return Db.DelUpdateTvp("dbo.UpdateUserAccessTVP", tvpTable, "@MParam", UserAccessIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of UserAccess).InsertTvp
            Return Db.InsertTvp("dbo.InsertUserAccessTVP", tvpTable)
        End Function

        Public Function GenerateCode(idNo As Integer) As String Implements IAutoCodeDao.GenerateCode
            Return UpdateCode("UserSecurity", "UserCode", "IdNo", idNo)
        End Function

        Private Shared ReadOnly MakeUserAccess As Func(Of IDataReader, UserAccess) =
                                    Function(reader) _
            New UserAccess() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .UserIdNo = Extensions.AsInt(Of Int16)(reader("UserIdNo")),
            .SecurityObjectIdNo = Extensions.AsInt(Of Int32)(reader("SecurityObjectIdNo")),
            .SecurityObjectName = Extensions.AsString(reader("SecurityObjectName")),
            .Visible = Extensions.AsBool(reader("Visible")),
            .Editable = Extensions.AsBool(reader("Editable"))
            }

        Private ReadOnly _makeSecurityObject As Func(Of IDataReader, SecurityObject) =
                             Function(reader) _
            New SecurityObject() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .SecurityObjectName = Extensions.AsString(reader("SecurityObjectName")),
            .SecurityObjectNameAra = Extensions.AsString(reader("SecurityObjectNameAra"))
            }

    End Class

End Namespace
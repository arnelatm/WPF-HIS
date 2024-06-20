Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for GroupAccess
    ' ** DAO Pattern

    Public Class UserAccessDao
        Inherits BaseDao
        Implements IDaoChild(Of UserAccess)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) _
            As List(Of UserAccess) Implements IDaoChild(Of UserAccess).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "IdNo"
            End If
            Dim sql As String =
                    "select UserAccess.IdNo , UserAccess.UserIdNo ,  SecurityObject.IdNo as 'SecurityObjectIdNo' , SecurityObject.SecurityObjectName, UserAccess.Visible, UserAccess.Editable from SecurityObject  " &
                    "left join UserAccess " &
                    "on SecurityObject.IdNo = UserAccess.SecurityObjectIdNo  and UserIdNo = @UserIdNo " &
                    "Order By " & sortExpression & " ASC "
            Dim params() As Object = {"@UserIdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, UserAccessIdNo As Int32) As Integer _
            Implements IDaoChild(Of UserAccess).DelUpdateTvp
            Return Db.DelUpdateTvp("dbo.UpdateUserAccessTVP", tvpTable, "@MParam", UserAccessIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of UserAccess).InsertTvp
            Return Db.InsertTvp("dbo.InsertUserAccessTVP", tvpTable)
        End Function

        ' creates an UserAccess object based on DataReader.
        Private Shared ReadOnly Make As Func(Of IDataReader, UserAccess) =
                                    Function(reader) _
            New UserAccess() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .UserIdNo = Extensions.AsInt(Of Int16?)(reader("UserIdNo")),
            .SecurityObjectIdNo = Extensions.AsInt(Of Int16?)(reader("SecurityObjectIdNo")),
            .SecurityObjectName = Extensions.AsString(reader("SecurityObjectName")),
            .Visible = Extensions.AsBool(reader("Visible")),
            .Editable = Extensions.AsBool(reader("Editable"))
            }

        ' creates a SecurityObject based on DataReader.
        Private ReadOnly _makeSecurityObject As Func(Of IDataReader, SecurityObject) =
                             Function(reader) _
            New SecurityObject() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .SecurityObjectName = Extensions.AsString(reader("SecurityObjectName")),
            .SecurityObjectNameAra = Extensions.AsString(reader("SecurityObjectNameAra"))
            }

        ' ReSharper disable once UnusedMember.Local
        Private Function Take(UserAccess As UserAccess) As Object()
            Return New Object() {
                                    "@IdNo", UserAccess.IdNo,
                                    "@UserIdNo", UserAccess.UserIdNo,
                                    "@SecurityObjectIdNo", UserAccess.SecurityObjectIdNo,
                                    "@SecurityObjectName", UserAccess.SecurityObjectName,
                                    "@Visible", UserAccess.Visible,
                                    "@Editable", UserAccess.Editable
                                }
        End Function

    End Class

End Namespace
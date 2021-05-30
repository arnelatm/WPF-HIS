Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for GroupAccess
    ' ** DAO Pattern

    Public Class GroupAccessDao
        Inherits BaseDao
        Implements IDaoChild(Of GroupAccess), IDaoAllOnly(Of SecurityObject)

        Private ReadOnly Db As New Db()

        'Public Sub New()
        '    DbCommon = Db
        'End Sub

        'Public Function GetRecordByIdNo(idNo) As GroupAccess Implements IDao(Of GroupAccess).GetRecordByIdNo
        '    Dim sql As String =
        '            " SELECT IdNo, SecurityGroupIdNo, SecurityObjectIdNo, Visible, Selectable, Viewable, Editable, SecurityObjectName" &
        '            "   FROM [GroupAccess_View] " &
        '            "  WHERE IdNo = @IdNo"

        '    Dim parms() As Object = {"@IdNo", idNo}
        '    Return Db.Read(sql, Make, parms).FirstOrDefault()
        'End Function

        Public Function GetSecurityObjects(Optional sortExpression As String = Nothing) As List(Of SecurityObject) Implements IDaoAllOnly(Of SecurityObject).GetAll
            If sortExpression = Nothing Then
                sortExpression = "FullPathName"
            End If
            Dim sql As String =
                    " SELECT IdNo, SecurityObjectName, SecurityObjectNameAra" &
                    " FROM [SecurityObject_View1] " & "order by " & sortExpression
            Return Db.Read(sql, _makeSecurityObject).ToList()
        End Function

        'Public Function GetRecordsById(idNo As Int32, Optional sortExpression As String = Nothing) As List(Of GroupAccess) Implements IDaoChild(Of GroupAccess).GetRecordsById
        '    If sortExpression Is Nothing Then
        '        sortExpression = "IdNo"
        '    End If
        '    Dim sql As String = "select GroupAccess.IdNo , GroupAccess.SecurityGroupIdNo ,  SecurityObject.IdNo as 'SecurityObjectIdNo' , SecurityObject.SecurityObjectName, GroupAccess.Visible, GroupAccess.Selectable, GroupAccess.Viewable, GroupAccess.Editable from SecurityObject  " &
        '                        "left join groupAccess " &
        '                        "on SecurityObject.IdNo = GroupAccess.SecurityObjectIdNo  and SecurityGroupIdNo = @SecurityGroupIdNo " &
        '                        "Order By " & sortExpression & " ASC "
        '    Dim params() As Object = {"@SecurityGroupIdNo", idNo}
        '    Return Db.Read(sql, Make, params).ToList()
        'End Function

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) _
            As List(Of GroupAccess) Implements IDaoChild(Of GroupAccess).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "IdNo"
            End If
            Dim sql As String =
                    "select GroupAccess.IdNo , GroupAccess.SecurityGroupIdNo ,  SecurityObject.IdNo as 'SecurityObjectIdNo' , SecurityObject.SecurityObjectName, GroupAccess.Visible, GroupAccess.Editable from SecurityObject  " &
                    "left join groupAccess " &
                    "on SecurityObject.IdNo = GroupAccess.SecurityObjectIdNo  and SecurityGroupIdNo = @SecurityGroupIdNo " &
                    "Order By " & sortExpression & " ASC "
            Dim params() As Object = {"@SecurityGroupIdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupAccessIdNo As Int32) As Integer _
            Implements IDaoChild(Of GroupAccess).DelUpdateTvp
            Return Db.DelUpdateTvp("dbo.UpdateGroupAccessTVP", tvpTable, "@MParam", groupAccessIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of GroupAccess).InsertTvp
            Return Db.InsertTvp("dbo.InsertGroupAccessTVP", tvpTable)
        End Function

        ' creates an GroupAccess object based on DataReader.
        Private Shared ReadOnly Make As Func(Of IDataReader, GroupAccess) =
                                    Function(reader) _
            New GroupAccess() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .SecurityGroupIdNo = Extensions.AsInt(Of Int16?)(reader("SecurityGroupIdNo")),
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
        Private Function Take(groupAccess As GroupAccess) As Object()
            Return New Object() {
                                    "@IdNo", groupAccess.IdNo,
                                    "@SecurityGroupIdNo", groupAccess.SecurityGroupIdNo,
                                    "@SecurityObjectIdNo", groupAccess.SecurityObjectIdNo,
                                    "@SecurityObjectName", groupAccess.SecurityObjectName,
                                    "@Visible", groupAccess.Visible,
                                    "@Editable", groupAccess.Editable
                                }
        End Function

    End Class

End Namespace
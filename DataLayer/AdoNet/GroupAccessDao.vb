Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for GroupAccess
    ' ** DAO Pattern

    Public Class GroupAccessDao
        Inherits BaseDao
        Implements IDaoChild(Of GroupAccess)

        Private ReadOnly Db As New Db()

        'Public Sub New()
        '    DbCommon = Db
        'End Sub

        'Public Function GetRecordById(idNo As Integer) As GroupAccess Implements IDao(Of GroupAccess).GetRecordById
        '    Dim sql As String =
        '            " SELECT IDNo, SecurityGroupIDNo, SecurityObjectIDNo, Visible, Selectable, Viewable, Editable, SecurityObjectName" &
        '            "   FROM [GroupAccess_View] " &
        '            "  WHERE IDNo = @IDNo"

        '    Dim parms() As Object = {"@IDNo", idNo}
        '    Return Db.Read(sql, Make, parms).FirstOrDefault()
        'End Function

        'Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of GroupAccess) Implements IDaoWithAll(Of GroupAccess).GetAll
        '    If sortExpression = Nothing THEN
        '        sortExpression = "IdNo"
        '    End If
        '    Dim sql As String =
        '            " SELECT IDNo, SecurityGroupIdNo,  " &
        '            "   FROM [GroupAccess_View] " & "order by " & sortExpression
        '    Return Db.Read(sql, Make).ToList()
        'End Function

        'Public Function GetRecordsById(idNo As Integer, Optional sortExpression As String = Nothing) As List(Of GroupAccess) Implements IDaoChild(Of GroupAccess).GetRecordsById
        '    If sortExpression Is Nothing Then
        '        sortExpression = "IdNo"
        '    End If
        '    Dim sql As String = "select GroupAccess.IdNo , GroupAccess.SecurityGroupIdNo ,  SecurityObject.IdNo as 'SecurityObjectIdNo' , SecurityObject.SecurityObjectName, GroupAccess.Visible, GroupAccess.Selectable, GroupAccess.Viewable, GroupAccess.Editable from SecurityObject  " &
        '                        "left join groupAccess " &
        '                        "on SecurityObject.IdNo = GroupAccess.SecurityObjectIDNo  and SecurityGroupIDNo = @SecurityGroupIdNo " &
        '                        "Order By " & sortExpression & " ASC "
        '    Dim params() As Object = {"@SecurityGroupIDNo", idNo}
        '    Return Db.Read(sql, Make, params).ToList()
        'End Function

        Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = Nothing) As List(Of GroupAccess) Implements IDaoChild(Of GroupAccess).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "IdNo"
            End If
            Dim sql As String = "select GroupAccess.IdNo , GroupAccess.SecurityGroupIdNo ,  SecurityObject.IdNo as 'SecurityObjectIdNo' , SecurityObject.SecurityObjectName, GroupAccess.Visible, GroupAccess.Selectable, GroupAccess.Viewable, GroupAccess.Editable from SecurityObject  " &
                                "left join groupAccess " &
                                "on SecurityObject.IdNo = GroupAccess.SecurityObjectIDNo  and SecurityGroupIDNo = @SecurityGroupIdNo " &
                                "Order By " & sortExpression & " ASC "
            Dim params() As Object = {"@SecurityGroupIDNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupAccessIdNo As Integer) As Integer Implements IDaoChild(Of GroupAccess).DelUpdateTvp
            Return Db.DelUpdateTvp("dbo.UpdateGroupAccessTVP", tvpTable, "@MParam", groupAccessIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of GroupAccess).InsertTvp
            Return Db.InsertTvp("dbo.InsertGroupAccessTVP", tvpTable, "@MParam")
        End Function

        ' creates an GroupAccess object based on DataReader.
        Private Shared ReadOnly Make As Func(Of IDataReader, GroupAccess) =
                                    Function(reader) _
            New GroupAccess() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .SecurityGroupIdNo = Extensions.AsInt(Of Integer?)(reader("SecurityGroupIDNo")),
            .SecurityObjectIdNo = Extensions.AsInt(Of Integer?)(reader("SecurityObjectIDNo")),
            .SecurityObjectName = Extensions.AsString(reader("SecurityObjectName")),
            .Visible = Extensions.AsBool(reader("Visible")),
            .Selectable = Extensions.AsBool(reader("Selectable")),
            .Viewable = Extensions.AsBool(reader("Viewable")),
            .Editable = Extensions.AsBool(reader("Editable"))
            }

        ' creates query parameters list from GroupAccess object

        ' ReSharper disable once UnusedMember.Local
        Private Function Take(groupAccess As GroupAccess) As Object()
            Return New Object() {
                                    "@IDNo", groupAccess.IdNo,
                                    "@SecurityGroupIDNo", groupAccess.SecurityGroupIdNo,
                                    "@SecurityObjectIDNo", groupAccess.SecurityObjectIdNo,
                                    "@SecurityObjectName", groupAccess.SecurityObjectName,
                                    "@Visible", groupAccess.Visible,
                                    "@Selectable", groupAccess.Selectable,
                                    "@Viewable", groupAccess.Viewable,
                                    "@Editable", groupAccess.Editable
                                }
        End Function

    End Class

End Namespace
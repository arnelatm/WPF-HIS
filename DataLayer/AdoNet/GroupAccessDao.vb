Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object for GroupAccess
    ' ** DAO Pattern

    Public Class GroupAccessDao
        Inherits CommonDao
        Implements IGroupAccessDao

        Private Shared ReadOnly Db As New Db()

        'Public Sub New()
        '    DbCommon = Db
        'End Sub

        Public Function GetRecordById(idNo As Integer) As GroupAccess _
            Implements IGroupAccessDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, SecurityGroupIDNo, SecurityObjectIDNo, Visible, Selectable, Viewable, Editable, SecurityObjectName" &
                    "   FROM [GroupAccess_View] " &
                    "  WHERE IDNo = @IDNo"

            Dim parms() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, parms).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "IdNo") As List(Of GroupAccess) _
            Implements IGroupAccessDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, SecurityGroupIdNo,  " &
                    "   FROM [GroupAccess_View] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = "IdNo") As List(Of GroupAccess)
            Dim sql As String = "select GroupAccess.IdNo , GroupAccess.SecurityGroupIdNo ,  SecurityObject.IdNo as 'SecurityObjectIdNo' , SecurityObject.SecurityObjectName, GroupAccess.Visible, GroupAccess.Selectable, GroupAccess.Viewable, GroupAccess.Editable from SecurityObject  " &
                                "left join groupAccess " &
                                "on SecurityObject.IdNo = GroupAccess.SecurityObjectIDNo  and SecurityGroupIDNo = @SecurityGroupIdNo " &
                                "Order By " & sortExpression & " ASC "
            Dim params() As Object = {"@SecurityGroupIDNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        'Public Function InsertGroupAccess(tvpTable As DataTable) As Integer Implements IGroupAccessDao.InsertGroupAccess
        '    Return Db.TVPInsert("dbo.InsertGroupAccessTVP", TVPTable, "@MParam")
        'End Function

        'Public Function UpdateGroupAccess(tvpTable As DataTable) As Integer Implements IGroupAccessDao.UpdateGroupAccess
        '    Return Db.TVPUpdate("dbo.UpdateGroupAccessTVP", TVPTable, "@MParam")
        'End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupAccessIdNo As Integer) As Integer _
            Implements IGroupAccessDao.DelUpdateTvp
            Return Db.TvpDelUpdate("dbo.UpdateGroupAccessTVP", tvpTable, "@MParam", groupAccessIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IGroupAccessDao.InsertTvp
            Return Db.TvpInsert("dbo.InsertGroupAccessTVP", tvpTable, "@MParam")
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
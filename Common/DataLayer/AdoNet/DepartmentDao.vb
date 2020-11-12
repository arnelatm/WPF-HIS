Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Department
    ' ** DAO Pattern

    Public Class DepartmentDao
        Inherits CommonDao
        Implements IDaoAll(Of Department)

        Private db As New Db()

        Public Function GetRecordById(idNo) As Department Implements IDaoAll(Of Department).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, DepartmentCode, DepartmentName, DepartmentNameAra, ParentIdNo, Notes, RevCostCenterIdNo, SortKey" &
                    "   FROM [Department_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim x = db.Read(sql, _make, params).FirstOrDefault()
            Return x
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Department) _
            Implements IDaoAll(Of Department).GetAll
            If sortExpression = Nothing Then
                sortExpression = "SortKey ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, DepartmentCode, DepartmentName, DepartmentNameAra, ParentIdNo, Notes, RevCostCenterIdNo, SortKey" &
                    "   FROM [Department_View] order by '" + sortExpression + "'"
            Return db.Read(sql, _make).ToList()
        End Function

        'Public Function GetAll(Optional ByVal sortExpression As String = "DepartmentName ASC") As List(Of Department) Implements IDaoAll(Of Department).GetAll
        '    Dim sql As String =
        '        " SELECT IdNo, DepartmentCode, DepartmentName, DepartmentNameAra, ParentIdNo, Notes, RevCostCenterIdNo, RevCostCenterIdNo" &
        '        "   FROM [Department_View] " & "order by sortKey"
        '    Return _db.Read(sql, _make).ToList()
        'End Function

        Public Function AddRecord(ByRef department As Department) As Integer Implements IDaoAll(Of Department).AddRecord
            Dim sql As String =
                    " INSERT INTO [Department] " &
                    " (DepartmentCode,DepartmentName,DepartmentNameAra,ParentIdNo,Notes,RevCostCenterIdNo,RevCostCenterIdNo) " &
                    " VALUES (@DepartmentCode,@DepartmentName,@DepartmentNameAra,@ParentIdNo,@Notes,@RevCostCenterIdNo) "
            Return db.Insert(sql, Take(department))
        End Function

        Public Function UpdateRecord(ByRef department As Department) As Integer _
            Implements IDaoAll(Of Department).UpdateRecord
            Dim sql As String =
                    " UPDATE [Department]" &
                    "    SET DepartmentCode = @DepartmentCode," &
                    "        DepartmentName = @DepartmentName," &
                    "        DepartmentNameAra = @DepartmentNameAra," &
                    "        ParentIdNo = @ParentIdNo," &
                    "        Notes = @Notes," &
                    "        RevCostCenterIdNo = @RevCostCenterIdNo" &
                    "  WHERE IdNo = @IdNo"

            Return db.Update(sql, Take(department))
        End Function

        Private Shared _make As Func(Of IDataReader, Department) =
                           Function(reader) _
            New Department() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .DepartmentCode = Extensions.AsString(reader("DepartmentCode")),
            .DepartmentName = Extensions.AsString(reader("DepartmentName")),
            .DepartmentNameAra = Extensions.AsString(reader("DepartmentNameAra")),
            .ParentIdNo = Extensions.AsNullable(Of Int32?)(reader("ParentIdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .RevCostCenterIdNo = Extensions.AsInt(Of Integer)(reader("RevCostCenterIdNo")),
            .SortKey = Extensions.AsString(reader("SortKey"))}

        Private Function Take(ByVal department As Department) As Object()
            Return New Object() {
                                    "@IdNo", department.IdNo,
                                    "@DepartmentCode", department.DepartmentCode,
                                    "@DepartmentName", department.DepartmentName,
                                    "@DepartmentNameAra", department.DepartmentNameAra,
                                    "@ParentIdNo", department.ParentIdNo,
                                    "@Notes", department.Notes,
                                    "@RevCostCenterIdNo", department.RevCostCenterIdNo,
                                    "@SortKey", department.SortKey}
        End Function

    End Class

End Namespace
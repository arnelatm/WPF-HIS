Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Department
    ' ** DAO Pattern

    Public Class DepartmentDao
        Inherits CommonDao
        Implements IDepartmentDao

        Private db As New Db()

        Public Function GetRecordById(idNo As Integer) As Department Implements IDepartmentDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, DepartmentCode, DepartmentName, DepartmentNameAra, ParentIdNo, Notes, ProfitCenterIdNo, CostCenterIdNo, SortKey" &
                    "   FROM [Department_View]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Dim x = db.Read(sql, _make, params).FirstOrDefault()
            Return x
        End Function

        Public Function GetAll(Optional sortExpression As String = "DepartmentName ASC") As List(Of Department) Implements IDepartmentDao.GetAll
            Dim sql As String =
                " SELECT IDNo, DepartmentCode, DepartmentName, DepartmentNameAra, ParentIdNo, Notes, ProfitCenterIdNo, CostCenterIdNo, SortKey" &
                "   FROM [Department_View] order by sortKey"
            Return db.Read(sql, _make).ToList()
        End Function

        'Public Function GetAll(Optional ByVal sortExpression As String = "DepartmentName ASC") As List(Of Department) Implements IDepartmentDao.GetAll
        '    Dim sql As String =
        '        " SELECT IDNo, DepartmentCode, DepartmentName, DepartmentNameAra, ParentIdNo, Notes, ProfitCenterIdNo, CostCenterIdNo" &
        '        "   FROM [Department_View] " & "order by sortKey"
        '    Return _db.Read(sql, _make).ToList()
        'End Function

        Public Function AddRecord(ByRef department As Department) As Integer Implements IDepartmentDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [Department] " &
                    " (DepartmentCode,DepartmentName,DepartmentNameAra,ParentIdNo,Notes,ProfitCenterIdNo,CostCenterIdNo) " &
                    " VALUES (@DepartmentCode,@DepartmentName,@DepartmentNameAra,@ParentIdNo,@Notes,@ProfitCenterIdNo,@CostCenterIdNo) "
            Return db.Insert(sql, Take(department))
        End Function

        Public Function UpdateRecord(ByRef department As Department) As Integer Implements IDepartmentDao.UpdateRecord
            Dim sql As String =
                " UPDATE [Department]" &
                "    SET DepartmentCode = @DepartmentCode," &
                "        DepartmentName = @DepartmentName," &
                "        DepartmentNameAra = @DepartmentNameAra," &
                "        ParentIdNo = @ParentIdNo," &
                "        Notes = @Notes," &
                "        ProfitCenterIdNo = @ProfitCenterIdNo," &
                "        CostCenterIdNo = @CostCenterIdNo" &
                "  WHERE IDNo = @IDNo"

            Return db.Update(sql, Take(department))
        End Function

        Private Shared _make As Func(Of IDataReader, Department) =
            Function(reader) _
                New Department() With {
                    .IdNo = Extensions.AsId(reader("IDNo")),
                    .DepartmentCode = Extensions.AsString(reader("DepartmentCode")),
                    .DepartmentName = Extensions.AsString(reader("DepartmentName")),
                    .DepartmentNameAra = Extensions.AsString(reader("DepartmentNameAra")),
                    .ParentIdNo = Extensions.AsNullableInt(Of Integer)(reader("ParentIdNo")),
                    .Notes = Extensions.AsString(reader("Notes")),
                    .ProfitCenterIdNo = Extensions.AsInt(Of Integer)(reader("ProfitCenterIdNo")),
                    .CostCenterIdNo = Extensions.AsInt(Of Integer)(reader("CostCenterIdNo")),
                    .SortKey = Extensions.AsString(reader("SortKey"))}

        Private Function Take(ByVal department As Department) As Object()
            Return New Object() {
                "@IDNo", department.IdNo,
                "@DepartmentCode", department.DepartmentCode,
                "@DepartmentName", department.DepartmentName,
                "@DepartmentNameAra", department.DepartmentNameAra,
                "@ParentIdNo", department.ParentIdNo,
                "@Notes", department.Notes,
                "@ProfitCenterIdNo", department.ProfitCenterIdNo,
                "@CostCenterIdNo", department.CostCenterIdNo,
                "@SortKey", department.SortKey}
        End Function

    End Class

End Namespace
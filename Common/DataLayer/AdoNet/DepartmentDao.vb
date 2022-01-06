Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Department
    ' ** DAO Pattern

    Public Class DepartmentDao
        Inherits CommonDao
        Implements iDao(Of Department)

        Private db As New Db()

        Public Function GetRecordByIdNo(idNo) As Department Implements iDao(Of Department).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, DepartmentCode, DepartmentName, DepartmentNameAra, ParentIdNo, Notes, RevCostCenterIdNo, SortKey" &
                    "   FROM [Department_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim x = db.Read(sql, _make, params).FirstOrDefault()
            Return x
        End Function

        Public Function AddRecord(ByRef department As Department) As Integer Implements iDao(Of Department).AddRecord
            Dim sql As String =
                    "INSERT INTO [Department] " &
                    "(DepartmentCode,DepartmentName,DepartmentNameAra,ParentIdNo,Notes,RevCostCenterIdNo) VALUES " &
                    "(@DepartmentCode,@DepartmentName,@DepartmentNameAra,@ParentIdNo,@Notes,@RevCostCenterIdNo)"
            Return db.Insert(sql, Take(department))
        End Function

        Public Function UpdateRecord(ByRef department As Department) As Integer _
            Implements iDao(Of Department).UpdateRecord
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
            .ParentIdNo = Extensions.AsNullable(Of Int16?)(reader("ParentIdNo")),
            .Notes = Extensions.AsString(reader("Notes")),
            .RevCostCenterIdNo = Extensions.AsInt(Of Int16)(reader("RevCostCenterIdNo")),
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
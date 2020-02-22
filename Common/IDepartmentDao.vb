Imports AATM.HIS.Common.BusinessLayer

Namespace DataLayer
    ' defines methods to access Departments.
    ' this is a database-independent interface. Implementations are database specific
    ' ** DAO Pattern

    Public Interface IDepartmentDao

        ' gets a specific Department
        Function GetRecordById(idNo As Integer) As Department

        ' gets a sorted list of all Departments
        Function GetAll(Optional ByVal sortExpression As String = "DepartmentName ASC") As List(Of Department)

        ' Add a Department
        Function AddRecord(ByRef department As Department) As Integer

        ' updates a Department
        Function UpdateRecord(ByRef department As Department) As Integer

    End Interface

End Namespace
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access Employees.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IEmployeeDao

        ' gets a specific Employee
        Function GetRecordById(idNo As Integer) As Employee

        ' gets a sorted list of all Employees
        Function GetAll(Optional ByVal sortExpression As String = "EmployeeName ASC") As List(Of Employee)

        ' Add a Employee
        Function AddRecord(ByRef employee As Employee) As Integer

        ' updates a Employee
        Function UpdateRecord(ByRef employee As Employee) As Integer

    End Interface
End NameSpace
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access Categories.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface ICashCodeDao

        ' gets a specific CashCode
        Function GetRecordById(idNo As Integer) As CashCode

        ' gets a sorted list of all Categories
        Function GetAll(Optional ByVal sortExpression As String = "CashName ASC") As List(Of CashCode)

        ' Add a CashCode
        Function AddRecord(ByRef cashCode As CashCode) As Integer

        ' updates a CashCode
        Function UpdateRecord(ByRef cashCode As CashCode) As Integer

    End Interface
End NameSpace
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access Banks.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IBankDao

        ' gets a specific Bank
        Function GetRecordById(idNo As Integer) As Bank

        ' gets a sorted list of all Banks
        Function GetAll(Optional ByVal sortExpression As String = "BankName ASC") As List(Of Bank)

        ' Add a Bank
        Function AddRecord(ByRef bank As Bank) As Integer

        ' updates a Bank
        Function UpdateRecord(ByRef bank As Bank) As Integer

    End Interface
End NameSpace
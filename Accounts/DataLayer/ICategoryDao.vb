Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access Categories.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface ICategoryDao

        ' gets a specific Category
        Function GetRecordById(idNo As Integer) As Category

        ' gets a sorted list of all Categories
        Function GetAll(Optional ByVal sortExpression As String = "CategoryName ASC") As List(Of Category)

        ' Add a Category
        Function AddRecord(ByRef category As Category) As Integer

        ' updates a Category
        Function UpdateRecord(ByRef category As Category) As Integer

    End Interface
End NameSpace
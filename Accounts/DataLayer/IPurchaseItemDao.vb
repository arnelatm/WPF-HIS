Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access Categories.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IPurchaseItemDao

        ' gets a specific PurchaseItem
        Function GetRecordById(idNo As Integer) As PurchaseItem

        ' gets a sorted list of all Categories
        Function GetAll(Optional ByVal sortExpression As String = "PurchaseItemName ASC") As List(Of PurchaseItem)

        ' Add a PurchaseItem
        Function AddRecord(ByRef purchaseItem As PurchaseItem) As Integer

        ' updates a PurchaseItem
        Function UpdateRecord(ByRef purchaseItem As PurchaseItem) As Integer

    End Interface
End NameSpace
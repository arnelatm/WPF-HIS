Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer

Namespace DataLayer

    Public Interface IAccountsDao
        Inherits ICommonDao

        Function UpdateVatNumber(vatNumber As String, idNo As Integer) As Integer

        Function GetAccountBalance(endDate As Date, accountIdNo As Short) As Decimal
        Function GetLastPurchaseCost(productIdNo As Integer) As Decimal
        Function GetLastPurchaseData(productIdNo As Integer) As Object
    End Interface

    Public Interface IDaoContacts(Of TBiz)

        Function UpdateOpeningBalance(ByRef bizObj As TBiz) As Integer

    End Interface

    Public Interface IDaoJournals(Of TBiz)

        Function UpdateGlReferenceNumber(ByRef bizObj As TBiz) As Integer

    End Interface

    Public Interface IDaoAutoReference(Of T)

        Function UpdateReferenceNumber(ByRef obj As T) As Integer

    End Interface

    Public Interface IDaoOpenInvoice(Of TBiz)

        Function AddRecord(ByRef openInvoice As TBiz) As Integer

    End Interface

    Public Interface IDaoAccount

        Function GetDetailAccounts(Optional sortExpression As String = Nothing) As List(Of Account)

    End Interface

    Public Interface IDaoAccountReconciliationItem(Of TM)

        Function GetAcctReconItems(accountIdNo As Int16, reconciliationDate As Date, Optional sortExpression As String = Nothing) As List(Of TM)

        Function GetGlItems(accountIdNo As Int16, reconciliationDate As Date, Optional sortExpression As String = Nothing) As List(Of TM)

        Function GetReconciledRecordsWithIdNo(reconciled As Boolean, idNo As Int32, Optional sortExpression As String = Nothing) As List(Of TM)

    End Interface

    Public Interface IDaoOiItem(Of TM)

        Function GetOpenInvoices(idNo As Int32) As List(Of TM)

    End Interface

    Public Interface IDaoAutoCode

        Function GenerateCode(idNo As Integer) As String

    End Interface

    Public Interface IDaoAutoCode2

        Function GenerateCode(idNo As Integer) As String

    End Interface

    Public Interface IDaoGetRecords(Of TM)

        Function GetDaoRecords(Optional filter As String = Nothing) As List(Of TM)

    End Interface

    Public Interface IDaoGetRecord(Of TM)

        Function GetDaoRecord(Optional filter As String = Nothing) As TM

    End Interface


    Public Interface IPurchaseDao
        Function GetPurchaseHistory(productIdNo As Integer) As List(Of PurchaseHistory)

    End Interface

    Public Interface IGetLastPurchaseCost
        Function GetLastPurchaseCost(productIdNo As Integer) As Decimal

    End Interface

    Public Interface IGetLastPurchaseData
        Function GetLastPurchaseData(productIdNo As Integer) As Object

    End Interface

    Public Interface IDaoPosting
        Function PostData(idNo As Int32) As Boolean

    End Interface

    'Public Interface IDaoAutoVatUpdate

    '    Function UpdateVatNumber(ByVal vatNumber As String, ByVal idNo As Integer) As Integer

    'End Interface

End Namespace
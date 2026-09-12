Imports System.Data
Imports System.Collections.Generic

Namespace DataLayer
    Public Interface ICashFlowDao
        Function GetAccounts() As DataTable
        Function GetAllAccounts() As DataTable
        Function GetLedger(beginningDate As Date, endingDate As Date) As DataTable
        Function GetAccountRules() As DataTable
        Function GetClassifications() As DataTable
        Function SaveAccountRule(accountIdNo As Short, classificationCode As String, categoryCode As String, isCashEquivalent As Boolean) As Integer
        Function GetApprovedAllocations() As DataTable
        Function GetTransaction(journalCode As String, journalIdNo As Integer, itemIdNo As Integer) As DataTable
    End Interface
End Namespace

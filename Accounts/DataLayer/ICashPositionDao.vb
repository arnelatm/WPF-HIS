Imports System.Collections.Generic
Imports System.Data

Namespace DataLayer
    Public Interface ICashPositionDao
        Function GetAccounts() As DataTable
        Function GetTransaction(journalCode As String, journalIdNo As Integer, itemIdNo As Integer) As DataTable
        Function GetPosition(beginningDate As Date, endingDate As Date, accountIds As List(Of Short)) As DataTable
    End Interface

    Public Interface IGeneralAccountPositionDao
        Function GetAllAccounts() As DataTable
        Function GetGeneralTransaction(journalCode As String, journalIdNo As Integer, itemIdNo As Integer) As DataTable
        Function GetGeneralPosition(beginningDate As Date, endingDate As Date, accountIds As List(Of Short), includeClosingEntries As Boolean) As DataTable
    End Interface
End Namespace

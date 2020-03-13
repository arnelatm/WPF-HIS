Imports AATM.Common.DataLayer
Imports AATM.DataLayer

Namespace DataLayer

    Public Interface IDaoAccounts
        Inherits ICommonDao

    End Interface

    Public Interface IDaoJournalItems

        Function DelUpdateTvp(ByRef tvpTable As DataTable, ByVal groupIdNo As Integer) As Integer

        Function GetRecordsWithIdNo(idNo As Integer, ByRef Optional sortKey As String = Nothing) As Object

        Function InsertTvp(ByRef tvpTable As DataTable) As Integer

    End Interface

    Public Interface IDaoJournals(Of TM)

        Function UpdateGlReferenceNumber(ByRef model As TM) As Integer

    End Interface

    Public Interface IDaoOpenInvoice

        Function AddInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

        Function RemoveInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

    End Interface

End Namespace
Imports System
Imports System.Collections.Generic

Namespace ServiceLayer
    Public Class KizenRevenueJournalBatch
        Public Sub New(startDate As DateTime, endDate As DateTime)
            SourcePeriodStart = startDate.Date
            SourcePeriodEnd = endDate.Date
            CostCenters = New List(Of KizenRevenueCostCenter)()
            Items = New List(Of KizenRevenueJournalItem)()
        End Sub
        Public ReadOnly Property SourcePeriodStart As DateTime
        Public ReadOnly Property SourcePeriodEnd As DateTime
        Public ReadOnly Property CostCenters As List(Of KizenRevenueCostCenter)
        Public ReadOnly Property Items As List(Of KizenRevenueJournalItem)
        Public Property ReceiptCount As Integer
        Public Property InvoiceCount As Integer
        Public Property Taxable As Decimal
        Public Property Exempt As Decimal
        Public Property ZeroRated As Decimal
        Public Property Vat As Decimal
        Public Property WithVat As Decimal
        Public Property RoundingAdjustment As Decimal
        Public Property TotalLineCount As Integer
    End Class

    Public Class KizenRevenueCostCenter
        Public Property RevCostCenterIdNo As Integer
        Public Property RevCostCenterCode As String
        Public Property RevCostCenterName As String
        Public Property DoctorCode As String
        Public Property Taxable As Decimal
        Public Property Exempt As Decimal
        Public Property ZeroRated As Decimal
        Public Property Vat As Decimal
        Public Property WithVat As Decimal
    End Class

    Public Class KizenRevenueJournalItem
        Public Property Sequence As Integer
        Public Property AccountIdNo As Integer
        Public Property Debit As Decimal
        Public Property Credit As Decimal
        Public Property RevCostCenterIdNo As Integer
        Public Property Notes As String
    End Class

    Public Class KizenRevenueJournalImportResult
        Public Property ReferenceNo As String
        Public Property JournalIdNo As Integer
        Public Property AlreadyImported As Boolean
    End Class
End Namespace

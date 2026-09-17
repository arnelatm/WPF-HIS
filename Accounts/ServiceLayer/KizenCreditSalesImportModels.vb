Imports System
Imports System.Collections.Generic

Namespace ServiceLayer
    Public Class KizenCreditSalesBatch
        Public Sub New(sourcePeriodStart As DateTime, sourcePeriodEnd As DateTime)
            Me.SourcePeriodStart = sourcePeriodStart.Date
            Me.SourcePeriodEnd = sourcePeriodEnd.Date
            Companies = New List(Of KizenCreditSalesCompany)()
        End Sub

        Public ReadOnly Property SourcePeriodStart As DateTime
        Public ReadOnly Property SourcePeriodEnd As DateTime
        Public Property SourceInvoiceCount As Integer
        Public Property SourceDetailCount As Integer
        Public Property SourceAmount As Decimal
        Public Property SourceVatAmount As Decimal
        Public ReadOnly Property Companies As List(Of KizenCreditSalesCompany)
        Public Property ReferenceNo As String

        Public ReadOnly Property JournalCount As Integer
            Get
                Return Companies.Count
            End Get
        End Property
    End Class

    Public Class KizenCreditSalesCompany
        Public Sub New()
            Items = New List(Of KizenCreditSalesItem)()
        End Sub

        Public Property BatchSequence As Integer
        Public Property CompanyCode As String
        Public Property CompanyName As String
        Public Property ZatcaNumber As String
        Public Property CustomerIdNo As Integer
        Public Property AccountIdNo As Integer
        Public Property DueDate As DateTime
        Public Property Amount As Decimal
        Public Property VatAmount As Decimal
        Public ReadOnly Property Items As List(Of KizenCreditSalesItem)
    End Class

    Public Class KizenCreditSalesItem
        Public Property Sequence As Integer
        Public Property AccountIdNo As Integer
        Public Property Debit As Decimal
        Public Property Credit As Decimal
        Public Property RevCostCenterIdNo As Integer
        Public Property Notes As String
    End Class

    Public Class KizenCreditSalesImportResult
        Public Property ReferenceNo As String
        Public Property JournalCount As Integer
        Public Property SourceInvoiceCount As Integer
        Public Property SourceDetailCount As Integer
        Public Property SourceAmount As Decimal
    End Class

    Friend Class KizenCustomerMapping
        Public Property CustomerIdNo As Integer
        Public Property PaymentDueDays As Integer
    End Class
End Namespace

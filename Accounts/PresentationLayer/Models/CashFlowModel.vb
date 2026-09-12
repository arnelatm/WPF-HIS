Imports System.Collections.Generic
Imports System.Globalization

Namespace PresentationLayer.Models
    Public Class CashFlowAccountModel
        Public Property IdNo As Short
        Public Property AccountCode As String
        Public Property AccountName As String
        Public Property AccountNameAra As String
        Public Property Active As Boolean
        Public ReadOnly Property DisplayName As String
            Get
                Dim name = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft AndAlso Not String.IsNullOrWhiteSpace(AccountNameAra), AccountNameAra, AccountName)
                Return AccountCode & " - " & name
            End Get
        End Property
    End Class

    Public Class CashFlowRuleModel
        Public Property AccountIdNo As Short
        Public Property AccountCode As String
        Public Property AccountName As String
        Public Property ClassificationCode As String
        Public Property CategoryCode As String
        Public Property IsCashEquivalent As Boolean
    End Class

    Public Class CashFlowLineModel
        Public Property Section As String
        Public Property Label As String
        Public Property LabelAra As String
        Public Property Amount As Decimal
        Public Property IsTotal As Boolean
        Public Property IsWarning As Boolean
        Public Property JournalLines As New List(Of CashFlowSourceLineModel)
    End Class

    Public Class CashFlowSourceLineModel
        Public Property JournalCode As String
        Public Property JournalIdNo As Integer
        Public Property ItemIdNo As Integer
        Public Property TransactionDate As Date
        Public Property AccountCode As String
        Public Property AccountName As String
        Public Property Debit As Decimal
        Public Property Credit As Decimal
        Public ReadOnly Property Amount As Decimal
            Get
                Return Debit - Credit
            End Get
        End Property
    End Class

    Public Class CashFlowModel
        Public Property BeginningDate As Date
        Public Property EndingDate As Date
        Public Property OpeningCash As Decimal
        Public Property ClosingCash As Decimal
        Public Property NetProfit As Decimal
        Public Property OperatingCashFlow As Decimal
        Public Property InvestingCashFlow As Decimal
        Public Property FinancingCashFlow As Decimal
        Public Property CalculatedClosingCash As Decimal
        Public Property ReconciliationDifference As Decimal
        Public Property Lines As New List(Of CashFlowLineModel)
        Public Property Accounts As New List(Of CashFlowAccountModel)
        Public Property ReviewMessages As New List(Of String)
    End Class
End Namespace

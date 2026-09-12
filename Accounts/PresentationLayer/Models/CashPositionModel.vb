Imports System.Collections.Generic
Imports System.Globalization

Namespace PresentationLayer.Models
    Public Class CashPositionTransactionModel
        Public Property JournalCode As String
        Public Property JournalIdNo As Integer
        Public Property SelectedItemIdNo As Integer
        Public Property TransactionDate As Date?
        Public Property ReferenceNo As String
        Public Property Notes As String
        Public Property Posted As Boolean?
        Public Property Approved As Boolean?
        Public Property Cancelled As Boolean?
        Public Property ClosingJournal As Boolean?
        Public Property Lines As New List(Of CashPositionTransactionLineModel)
    End Class

    Public Class CashPositionTransactionLineModel
        Public Property ItemIdNo As Integer
        Public Property Sequence As Short
        Public Property AccountIdNo As Short
        Public Property AccountCode As String
        Public Property AccountName As String
        Public Property AccountNameAra As String
        Public Property Debit As Decimal
        Public Property Credit As Decimal
        Public Property Notes As String
        Public Property Posted As Boolean?
        Public ReadOnly Property DisplayName As String
            Get
                Dim name = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft AndAlso
                              Not String.IsNullOrWhiteSpace(AccountNameAra), AccountNameAra, AccountName)
                Return If(String.IsNullOrWhiteSpace(AccountCode), AccountIdNo.ToString(), AccountCode) & " - " & name
            End Get
        End Property
    End Class

    Public Class CashPositionModel
        Public Property BeginningDate As Date
        Public Property EndingDate As Date
        Public Property Accounts As New List(Of CashPositionAccountModel)
        Public Property Lines As New List(Of CashPositionLineModel)
    End Class

    Public Class CashPositionAccountModel
        Public Property IdNo As Short
        Public Property AccountCode As String
        Public Property AccountName As String
        Public Property AccountNameAra As String
        Public Property Active As Boolean
        Public Property ParentIdNo As Short?
        Public Property DetailAccount As Boolean
        Public Property AccountGroup As String
        Public Property SortKey As String
        Public Property HasOpeningSnapshot As Boolean
        Public Property OpeningBalance As Decimal
        Public Property Debit As Decimal
        Public Property Credit As Decimal
        Public Property ClosingBalance As Decimal
        Public Property ClosingJournalLines As Integer
        Public Property PostingReviewLines As Integer

        Public ReadOnly Property DisplayName As String
            Get
                Dim caption = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft AndAlso
                                 Not String.IsNullOrWhiteSpace(AccountNameAra), AccountNameAra, AccountName)
                Return If(DetailAccount, "", "[Group] ") & AccountCode & " - " & caption
            End Get
        End Property
    End Class

    Public Class CashPositionLineModel
        Public Property AccountIdNo As Short
        Public Property JournalCode As String
        Public Property JournalIdNo As Integer
        Public Property ItemIdNo As Integer
        Public Property TransactionDate As Date
        Public Property ReferenceNo As String
        Public Property Notes As String
        Public Property HeaderPosted As Boolean?
        Public Property ItemPosted As Boolean?
        Public Property ClosingJournal As Boolean
        Public Property Debit As Decimal
        Public Property Credit As Decimal
    End Class
End Namespace

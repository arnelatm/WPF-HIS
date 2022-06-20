Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class SalesJournalItemsPresenter(Of TM As New)
        Inherits AccountsPresenterNew(Of IJournalItemsView, JournalItemModel)

        Public Sub New(view As IJournalItemsView)
            MyBase.New(view)
            Service = New AccountsService("JournalItem")
            TableName = "JournalItem"
            SortOrderKey = "Sequence"
        End Sub

        'Public Overloads Function DataIsValid(ByRef journalItems As List(Of JournalItemModel), ByVal paymentType As String)
        '    Dim retVal = True
        '    Dim paymentTypeEnum As String
        '    Dim itemPayeeType As String
        '    For Each item In journalItems
        '        paymentTypeEnum = CodeToEnum(Of PaymentTypeSelection)(paymentType)
        '        If item.Debit = 0 And item.Credit = 0 Then
        '            MessageBox.Show(Format("Error in line {0:N0}. Cannot save entries with zero debit and credit amount.", item.Sequence.ToString()))
        '            retVal = False
        '            Exit For
        '        ElseIf item.AccountIdNo = 0 Then
        '            MessageBox.Show(Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
        '            retVal = False
        '            Exit For
        '        ElseIf String.IsNullOrEmpty(paymentType) Then
        '            ' no need to check for accountTypes
        '        ElseIf CodeToEnum(Of SpecialAccountSelection)(item.SpecialAccount) = SpecialAccountSelection.AccountsPayable Then
        '            MessageBox.Show(String.Format("Error on line {0:N0}. Sorry Accounts Payable accounts not allowed for this entry!", item.Sequence))
        '            retVal = False
        '        ElseIf paymentTypeEnum = PaymentTypeSelection.Employee Then
        '            itemPayeeType = Model.GetRecordFieldWithKey(item.AccountIdNo, "Account", "IdNo", "PayeeType")
        '            If Not String.IsNullOrEmpty(itemPayeeType) AndAlso CodeToEnum(Of PayeeTypeSelection)(itemPayeeType) <> PayeeTypeSelection.Employee Then
        '                MessageBox.Show(String.Format("Error on line {0:N0}. Sorry only Employee Payee accounts allowed for this entry!", item.Sequence))
        '                retVal = False
        '            End If
        '        ElseIf paymentTypeEnum = PaymentTypeSelection.CustomerRefund Then
        '            itemPayeeType = Model.GetRecordFieldWithKey(item.AccountIdNo, "Account", "IdNo", "PayeeType")
        '            If Not String.IsNullOrEmpty(itemPayeeType) AndAlso CodeToEnum(Of PayeeTypeSelection)(itemPayeeType) <> PayeeTypeSelection.Customer Then
        '                MessageBox.Show(String.Format("Error on line {0:N0}. Sorry only Customer Payee accounts allowed for this entry!", item.Sequence))
        '                retVal = False
        '            End If
        '        ElseIf paymentTypeEnum = PaymentTypeSelection.Others Or paymentTypeEnum = PaymentTypeSelection.Supplier Then
        '            itemPayeeType = Model.GetRecordFieldWithKey(item.AccountIdNo, "Account", "IdNo", "PayeeType")
        '            If Not String.IsNullOrEmpty(itemPayeeType) Then
        '                MessageBox.Show(String.Format("Error on line {0:N0}. Sorry Customer, Supplier or Employee Payee accounts not allowed for this entry!", item.Sequence))
        '                retVal = False
        '            End If
        '        End If
        '    Next
        '    Return retVal
        'End Function

        ''' <summary>
        '''     Displays list of Cheque Disbursement Journal Items.
        ''' </summary>
        ''' <param name="journalIdNo">JournalIdNo id to display.</param>
        Public Shadows Sub Display(journalIdNo As Int32)
            View.JournalItems = Service.GetRecordsWithGroupIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Sub

        'Public Sub MakeJournalItems(ByVal idNo As Int32, ByVal AccountIdNo As Int16, ByVal totalSales As Decimal)
        '    Dim oldJournalItems = GetJournalItems(idNo)
        '    Dim counter As Integer = 0
        '    MakeSalesJournal(oldJournalItems, counter, AccountIdNo, 0, totalSales)
        '    For Each item As SalesDepositModel In bsSalesDeposits
        '        Dim cashCode = _cashCodesModel.Find(Function(c) c.CashCode.Trim() = item.CashCode.Trim())
        '        MakeSalesJournal(oldJournalItems, counter, cashCode.AccountIdNo, item.DepositAmount, 0)
        '        MakeSalesJournal(oldJournalItems, counter, cashCode.BankChargesAccountIdNo, item.ActualBankCharge, 0)
        '        MakeSalesJournal(oldJournalItems, counter, cashCode.BankChargesVatAccountIdNo, item.VatAmount, 0)
        '    Next
        '    UpdateTotals()
        'End Sub

        'Private Function MakeSalesJournal(ByRef oldJournalItems As List(Of JournalItemModel), ByRef counter As Integer,
        '                                  pAccountIdNo As Int16, debitAmount As Decimal, creditAmount As Decimal) As Integer
        '    If debitAmount <> 0 Or creditAmount <> 0 Then
        '        counter = counter + 1
        '        If counter <= oldJournalItems.Count() Then
        '            bsJournalItems.Item(counter - 1).AccountIdNo = pAccountIdNo
        '            bsJournalItems.Item(counter - 1).Debit = debitAmount
        '            bsJournalItems.Item(counter - 1).Credit = creditAmount
        '            bsJournalItems.Item(counter - 1).Sequence = counter
        '        Else
        '            Dim ji As New JournalItemModel With {
        '                    .AccountIdNo = pAccountIdNo,
        '                    .Credit = creditAmount,
        '                    .Debit = debitAmount,
        '                    .IdNo = 0,
        '                    .JournalIdNo = IdNo,
        '                    .Sequence = counter
        '                    }
        '            bsJournalItems.Add(ji)
        '        End If
        '    End If
        'End Function

    End Class

End Namespace
Imports System.Windows.Forms
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Presenters


    Public Class CashReceiptJournalItemsPresenter
        Inherits AccountsPresenter(Of IJournalItemsView, JournalItem, JournalItemModel)

        Public ParentViewList As List(Of JournalItemModel)

        Public Sub New(view As IJournalItemsView)
            MyBase.New(view)
            CurrentModel = New ModelCashReceiptJournalItem()
            TableName = "JournalItem"
            SortOrderKey = "Sequence"
            BizObject = New JournalItem
            DataModel = New JournalItemModel
        End Sub

        Public Property ChangesMadeInJournalItem As Boolean = False

        Public Overloads Function DataIsValid(ByRef journalItems As List(Of JournalItemModel), ByRef payorType As String)
            Dim retVal = True
            Dim receiptTypeEnum As String
            Dim itemPayorType As String
            For Each item In journalItems
                receiptTypeEnum = ReceiptTypeToEnum(payorType)
                If item.Debit = 0 And item.Credit = 0 Then
                    MessageBox.Show(Format("Error in line {0:N0}. Cannot save entries with zero debit and credit amount.", item.Sequence.ToString()))
                    retVal = False
                    Exit For
                ElseIf item.AccountIdNo = 0 Then
                    MessageBox.Show(Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
                    retVal = False
                    Exit For
                ElseIf String.IsNullOrEmpty(payorType) Then
                    ' no need to check for accountTypes
                ElseIf SpecialAccountToEnum(item.SpecialAccount) = SpecialAccountSelection.AccountsPayable Then
                    MessageBox.Show(String.Format("Error on line {0:N0}. Sorry Accounts Payable accounts not allowed for this entry!", item.Sequence))
                    retVal = False
                ElseIf receiptTypeEnum = ReceiptTypeSelection.Employee Then
                    itemPayorType = Model.GetRecordFieldWithKey(item.AccountIdNo, "Chart", "IdNo", "PayeeType")
                    If Not String.IsNullOrEmpty(itemPayorType) AndAlso PayeeTypeToEnum(itemPayorType) <> PayeeTypeSelection.Employee Then
                        MessageBox.Show(String.Format("Error on line {0:N0}. Sorry only Employee Payee accounts allowed for this entry!", item.Sequence))
                        retVal = False
                    End If
                ElseIf receiptTypeEnum = ReceiptTypeSelection.SupplierRefund Then
                    itemPayorType = Model.GetRecordFieldWithKey(item.AccountIdNo, "Chart", "IdNo", "PayeeType")
                    If Not String.IsNullOrEmpty(itemPayorType) AndAlso PayeeTypeToEnum(itemPayorType) <> PayeeTypeSelection.Customer Then
                        MessageBox.Show(String.Format("Error on line {0:N0}. Sorry only Customer Payee accounts allowed for this entry!", item.Sequence))
                        retVal = False
                    End If
                ElseIf receiptTypeEnum = ReceiptTypeSelection.Others Or receiptTypeEnum = ReceiptTypeSelection.Customer Then
                    itemPayorType = Model.GetRecordFieldWithKey(item.AccountIdNo, "Chart", "IdNo", "PayeeType")
                    If Not String.IsNullOrEmpty(itemPayorType) Then
                        MessageBox.Show(String.Format("Error on line {0:N0}. Sorry Customer, Supplier or Employee Payee accounts not allowed for this entry!", item.Sequence))
                        retVal = False
                    End If
                End If
            Next
            Return retVal
        End Function

        ''' <summary>
        '''     Displays list of Cash Receipt Journal Items.
        ''' </summary>
        ''' <param name="journalIdNo">JournalIDNo id to display.</param>
        Public Shadows Sub Display(journalIdNo As Integer, Optional ByVal undoMode As Boolean = False)
            View.JournalItems = Model.GetRecordsWithIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Sub

        Public Function GetJournalItems(journalIdNo As Integer) As List(Of JournalItemModel)
            Return Model.GetRecordsWithIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Function

        Public Function GetAdvancePaymentOpenInvoice(ByVal idNo As Integer)
            Return Model.GetRecordFieldWith2Key(idNo, "CR", "ArOpenInvoice", "JournalItemIdNo", "JournalCode", "IdNo")
        End Function

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       journalIdNo As Integer)
            Dim insertReturnValue
            Dim updateReturnValue
            Dim retVal
            updateReturnValue = Model.DelUpdateTvp(dtUpdate, journalIdNo)
            If updateReturnValue >= 0 AndAlso dtInsert.Rows.Count > 0 Then
                insertReturnValue = Model.InsertTvp(dtInsert)
                If insertReturnValue >= 0 Then
                    retVal = updateReturnValue + insertReturnValue
                Else
                    retVal = insertReturnValue
                End If
            Else
                retVal = updateReturnValue
            End If
            Return retVal
        End Function

    End Class
End NameSpace
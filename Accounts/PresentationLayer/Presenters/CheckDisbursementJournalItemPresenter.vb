Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class CheckDisbursementJournalItemsPresenter
        Inherits AccountsPresenter(Of IJournalItemsView, JournalItemModel)

        Public ParentViewList As List(Of JournalItemModel)

        Public Sub New(view As IJournalItemsView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("JournalItem")
            TableName = "JournalItem"
            SortOrderKey = "Sequence"
            DataModel = New JournalItemModel
        End Sub

        Public Property ChangesMadeInJournalItem As Boolean = False

        Public Overloads Function DataIsValid(ByRef journalItems As List(Of JournalItemModel), ByVal paymentType As String)
            Dim retVal = True
            Dim paymentTypeEnum As String
            Dim itemPayeeType As String
            For Each item In journalItems
                paymentTypeEnum = PaymentTypeToEnum(paymentType)
                If item.Debit = 0 And item.Credit = 0 Then
                    MessageBox.Show(Format("Error in line {0:N0}. Cannot save entries with zero debit and credit amount.", item.Sequence.ToString()))
                    retVal = False
                    Exit For
                ElseIf item.AccountIdNo = 0 Then
                    MessageBox.Show(Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
                    retVal = False
                    Exit For
                ElseIf String.IsNullOrEmpty(paymentType) Then
                    ' no need to check for accountTypes
                ElseIf SpecialAccountToEnum(item.SpecialAccount) = SpecialAccountSelection.AccountsPayable Then
                    MessageBox.Show(String.Format("Error on line {0:N0}. Sorry Accounts Payable accounts not allowed for this entry!", item.Sequence))
                    retVal = False
                ElseIf paymentTypeEnum = PaymentTypeSelection.Employee Then
                    itemPayeeType = Model.GetRecordFieldWithKey(item.AccountIdNo, "Chart", "IdNo", "PayeeType")
                    If Not String.IsNullOrEmpty(itemPayeeType) AndAlso PayeeTypeToEnum(itemPayeeType) <> PayeeTypeSelection.Employee Then
                        MessageBox.Show(String.Format("Error on line {0:N0}. Sorry only Employee Payee accounts allowed for this entry!", item.Sequence))
                        retVal = False
                    End If
                ElseIf paymentTypeEnum = PaymentTypeSelection.CustomerRefund Then
                    itemPayeeType = Model.GetRecordFieldWithKey(item.AccountIdNo, "Chart", "IdNo", "PayeeType")
                    If Not String.IsNullOrEmpty(itemPayeeType) AndAlso PayeeTypeToEnum(itemPayeeType) <> PayeeTypeSelection.Customer Then
                        MessageBox.Show(String.Format("Error on line {0:N0}. Sorry only Customer Payee accounts allowed for this entry!", item.Sequence))
                        retVal = False
                    End If
                    'ElseIf paymentTypeEnum = PaymentTypeSelection.Supplier Then
                    '    itemPayeeType = Model.GetRecordFieldWithKey(item.AccountIdNo, "Chart", "IdNo", "PayeeType")
                    '    If Not String.IsNullOrEmpty(itemPayeeType) AndAlso PayeeTypeToEnum(itemPayeeType) <> PayeeTypeSelection.Supplier Then
                    '        MessageBox.Show(String.Format("Error on line {0:n0}. Sorry only Supplier Payee accounts allowed for this entry!", item.Sequence))
                    '        retVal = False
                    '    End If
                ElseIf paymentTypeEnum = PaymentTypeSelection.Others Or paymentTypeEnum = PaymentTypeSelection.Supplier Then
                    itemPayeeType = Model.GetRecordFieldWithKey(item.AccountIdNo, "Chart", "IdNo", "PayeeType")
                    If Not String.IsNullOrEmpty(itemPayeeType) Then
                        MessageBox.Show(String.Format("Error on line {0:N0}. Sorry Customer, Supplier or Employee Payee accounts not allowed for this entry!", item.Sequence))
                        retVal = False
                    End If
                End If
            Next
            Return retVal
        End Function

        ''' <summary>
        '''     Displays list of Check Disbursement Journal Items.
        ''' </summary>
        ''' <param name="journalIdNo">JournalIDNo id to display.</param>
        Public Shadows Sub Display(journalIdNo As Int32)
            View.JournalItems = Model.GetRecordsWithIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Sub

        Public Function GetJournalItems(journalIdNo As Int32) As List(Of JournalItemModel)
            Return Model.GetRecordsWithIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Function

        Public Function GetAdvancePaymentOpenInvoice(ByVal idNo As Int32)
            Return Model.GetRecordFieldWith2Key(idNo, "CK", "ApOpenInvoice", "JournalItemIdNo", "JournalCode", "IdNo")
        End Function

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       journalIdNo As Int32)
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

End Namespace
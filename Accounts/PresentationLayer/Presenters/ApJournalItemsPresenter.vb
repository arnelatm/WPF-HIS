Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class ApJournalItemsPresenter
        Inherits AccountsPresenter(Of IJournalItemsView, JournalItemModel)

        'Private journalItems As List(Of JournalItemModel)

        Public Sub New(view As IJournalItemsView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("JournalItem")
            TableName = "JournalItem"
            SortOrderKey = "Sequence"
            OriginalModel = New List(Of JournalItemModel())
            DataModel = New JournalItemModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Property ChangesMadeInJournalItem As Boolean = False

        'Public Overloads Function DataIsValid(ByRef journalItems As List(Of JournalItemModel))
        '    Dim retVal = True
        '    Dim cPayeeType As String
        '    Dim cashAccount As String = EnumToSpecialAccount(SpecialAccountSelection.Bank) + "|" + EnumToSpecialAccount(SpecialAccountSelection.Cash) + "|" + EnumToSpecialAccount(SpecialAccountSelection.PettyCashAccount)
        '    Dim specialAccount As String
        '    Dim chart As ChartModel
        '    For Each item In journalItems
        '        chart = GetChart(item.AccountIdNo)
        '        specialAccount = chart.SpecialAccount
        '        If item.AccountIdNo = 0 Then
        '            MessageBox.Show(String.Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
        '            retVal = False
        '            Exit For
        '        ElseIf specialAccount IsNot Nothing AndAlso cashAccount.Contains(specialAccount) Then
        '            Dim lineNumber As String = item.Sequence.ToString()
        '            Dim caption = "Invalid Entry!"
        '            Dim message = Messaging.GetMessage(True, "MsgCashAccountsNotAllowed", "Error on line <{lineNumber}>. Cash accounts not allowed for AP Journal Entry.", "Invalid Entry")
        '            message = message.Interpolate(Function(x) lineNumber)
        '            Messaging.Show(message, caption)
        '            retVal = False
        '        Else
        '            cPayeeType = Model.GetRecordFieldWithKey(item.AccountIdNo, "Chart", "IdNo", "PayeeType")
        '            If Not String.IsNullOrEmpty(cPayeeType) AndAlso PayeeTypeToEnum(cPayeeType) <> PayeeTypeSelection.Supplier Then
        '                MessageBox.Show(String.Format("Error on line {0:N0}. Sorry only Supplier/Vendor accounts allowed for this entry!", item.Sequence))
        '                retVal = False
        '            End If
        '        End If
        '    Next
        '    Return retVal
        'End Function

        ''' <summary>
        '''     Displays list of Ap Journal Items.
        ''' </summary>
        ''' <param name="journalIdNo">JournalIDNo id to display.</param>
        Public Shadows Sub Display(journalIdNo As Integer)
            View.JournalItems = Model.GetRecordsWithIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Sub

        Public Function GetJournalItems(journalIdNo As Integer) As List(Of JournalItemModel)
            Return Model.GetRecordsWithIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Function

        'Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
        '                               journalIdNo As Integer)
        '    Dim insertReturnValue
        '    Dim updateReturnValue
        '    Dim retVal
        '    updateReturnValue = Model.DelUpdateTvp(dtUpdate, journalIdNo)
        '    If updateReturnValue >= 0 AndAlso dtInsert.Rows.Count > 0 Then
        '        insertReturnValue = Model.InsertTvp(dtInsert)
        '        If insertReturnValue >= 0 Then
        '            retVal = updateReturnValue + insertReturnValue
        '        Else
        '            retVal = insertReturnValue
        '        End If
        '    Else
        '        retVal = updateReturnValue
        '    End If
        '    Return retVal
        'End Function

    End Class

End Namespace
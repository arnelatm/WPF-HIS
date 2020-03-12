Imports System.Windows.Forms
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class GeneralJournalItemsPresenter
        Inherits AccountsPresenter(Of IJournalItemsView, JournalItemModel)

        Public Sub New(view As IJournalItemsView)
            MyBase.New(view)
            ModelPresenter = New ModelGeneralJournalItem()
            TableName = "JournalItem"
            SortOrderKey = "Sequence"
            DataBizObject = New JournalItem
            DataModel = New JournalItemModel
        End Sub

        Public Property ChangesMadeInJournalItem As Boolean = False

        Public Overloads Function DataIsValid(ByRef journalItems As List(Of JournalItemModel))
            Dim retVal = True
            For Each item In journalItems
                If item.Debit = 0 And item.Credit = 0 Then
                    MessageBox.Show(Format("Error in line {0:N0}. Cannot save entries with zero debit and credit amount. See line ", item.Sequence))
                    retVal = False
                    Exit For
                ElseIf item.AccountIdNo = 0 Then
                    MessageBox.Show(Format("Error in line {0:N0}. Cannot save entries with blank account id", item.Sequence))
                    retVal = False
                    Exit For
                Else
                    Dim cPayeeType = PayeeTypeToEnum(Model.GetRecordFieldWithKey(item.AccountIdNo, "Chart", "IdNo", "PayeeType"))
                    If cPayeeType = PayeeTypeSelection.Employee Or cPayeeType = PayeeTypeSelection.Customer Or cPayeeType = PayeeTypeSelection.Supplier Then
                        MessageBox.Show(String.Format("Error in line {0:N0} Sorry the account entered is either a Customer/Employee/Supplier Account. Such entries are not allowed for General Journal.", item.Sequence))
                        retVal = False
                    End If
                End If
            Next
            Return retVal
        End Function

        ''' <summary>
        '''     Displays list of  Journal Items.
        ''' </summary>
        ''' <param name="journalIdNo">JournalIDNo id to display.</param>
        Public Overloads Sub Display(journalIdNo As Integer, Optional ByVal undoMode As Boolean = False)
            View.JournalItems = Model.GetRecordsWithIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Sub

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

End Namespace
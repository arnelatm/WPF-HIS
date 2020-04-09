Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class ArJournalItemsPresenter
        Inherits AccountsPresenter(Of IJournalItemsView, JournalItemModel)

        'Private journalItems As List(Of JournalItemModel)

        Public Sub New(view As IJournalItemsView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("JournalItem")
            TableName = "JournalItem"
            SortOrderKey = "Sequence"
            DataModel = New JournalItemModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Property ChangesMadeInJournalItem As Boolean = False

        Public Overloads Function DataIsValid(ByRef journalItems As List(Of JournalItemModel))
            Dim retVal = True
            Dim cPayeeType As String
            For Each item In journalItems
                If item.AccountIdNo = 0 Then
                    MessageBox.Show(String.Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
                    retVal = False
                    Exit For
                Else
                    cPayeeType = Model.GetRecordFieldWithKey(item.AccountIdNo, "Chart", "IdNo", "PayeeType")
                    If Not String.IsNullOrEmpty(cPayeeType) AndAlso PayeeTypeToEnum(cPayeeType) <> PayeeTypeSelection.Customer Then
                        MessageBox.Show(String.Format("Error on line {0:N0}. Sorry only Customer accounts allowed for this entry!", item.Sequence))
                        retVal = False
                    End If
                End If
            Next
            Return retVal
        End Function

        ''' <summary>
        '''     Displays list of AR Journal Items.
        ''' </summary>
        ''' <param name="journalIdNo">JournalIDNo id to display.</param>
        Public Shadows Sub Display(journalIdNo As Integer)
            View.JournalItems = Model.GetRecordsWithIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Sub

        Public Function GetJournalItems(journalIdNo As Integer) As List(Of JournalItemModel)
            Return Model.GetRecordsWithIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
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

End Namespace
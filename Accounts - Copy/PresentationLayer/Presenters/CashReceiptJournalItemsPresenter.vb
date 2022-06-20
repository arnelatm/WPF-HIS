Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Presenters

    Public Class CashReceiptJournalItemsPresenter(Of TM As New)
        Inherits AccountsPresenterNew(Of IJournalItemsView, JournalItemModel)

        Public ParentViewList As List(Of JournalItemModel)

        Public Sub New(view As IJournalItemsView)
            MyBase.New(view)
            Service = New AccountsService("JournalItem")
            TableName = "JournalItem"
            SortOrderKey = "Sequence"
        End Sub

        Public Property ChangesMadeInJournalItem As Boolean = False

        ''' <summary>
        '''     Displays list of Cash Receipt Journal Items.
        ''' </summary>
        ''' <param name="journalIdNo">JournalIdNo id to display.</param>
        Public Shadows Sub Display(journalIdNo As Int32)
            View.JournalItems = Service.GetRecordsWithGroupIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Sub

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       journalIdNo As Int32)
            Dim insertReturnValue
            Dim updateReturnValue
            Dim retVal
            updateReturnValue = Service.DelUpdateTvp(dtUpdate, journalIdNo)
            If updateReturnValue >= 0 AndAlso dtInsert.Rows.Count > 0 Then
                insertReturnValue = Service.InsertTvp(dtInsert)
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
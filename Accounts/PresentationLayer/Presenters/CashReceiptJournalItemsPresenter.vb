Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Presenters

    Public Class CashReceiptJournalItemsPresenter(Of TM As New)
        Inherits AccountsPresenter(Of IJournalItemsView, JournalItemModel)

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
            RemoveZeroAmountItems(dtInsert)
            RemoveZeroAmountItems(dtUpdate)
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

        Private Shared Sub RemoveZeroAmountItems(items As DataTable)
            If items Is Nothing OrElse Not items.Columns.Contains("Debit") OrElse Not items.Columns.Contains("Credit") Then Return
            For rowIndex As Integer = items.Rows.Count - 1 To 0 Step -1
                Dim debit As Decimal = If(items.Rows(rowIndex).IsNull("Debit"), 0D, Convert.ToDecimal(items.Rows(rowIndex)("Debit")))
                Dim credit As Decimal = If(items.Rows(rowIndex).IsNull("Credit"), 0D, Convert.ToDecimal(items.Rows(rowIndex)("Credit")))
                If debit = 0D AndAlso credit = 0D Then items.Rows.RemoveAt(rowIndex)
            Next
        End Sub

    End Class

End Namespace

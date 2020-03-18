Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters


    Public Class SalesJournalPresenter
        Inherits AccountsPresenter(Of ISalesJournalView, SalesJournalModel)

        Public ParentViewList As List(Of SalesJournalModel)

        Public Sub New(view As ISalesJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("SalesJournal")
            TableName = "SalesJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New SalesJournalModel()
            DataModel = New SalesJournalModel
        End Sub

        Public Property JournalItemsPresenter As SalesJournalItemsPresenter
        Public Property SalesCashItemsPresenter As SalesCashItemsPresenter

        Public Overrides Function ChangesMade() As Boolean
            Dim salesJournalChangesMade As Boolean
            If ObjectsCompare(OriginalModel, View) Then
                If JournalItemsPresenter.ChangesMadeInJournalItem Then
                    salesJournalChangesMade = True
                ElseIf SalesCashItemsPresenter.ChangesMadeInSalesCashItem Then
                    salesJournalChangesMade = True
                Else
                    salesJournalChangesMade = False
                End If
            Else
                salesJournalChangesMade = True
            End If
            Return salesJournalChangesMade
        End Function

        Public Function UpdateGlReferenceNumber() As String
            GlobalVariables.Mapper.Map(View, DataModel)
            Return ModelPresenter.UpdateGlReferenceNumber(DataModel)
        End Function

    End Class
End NameSpace
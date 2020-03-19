Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class PurchaseJournalPresenter
        Inherits AccountsPresenter(Of IPurchaseJournalView, PurchaseJournalModel)

        Public ParentViewList As List(Of PurchaseJournalModel)

        Public Sub New(view As IPurchaseJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("PurchaseJournal")
            TableName = "PurchaseJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New PurchaseJournalModel()
            DataModel = New PurchaseJournalModel
        End Sub

        Public Property JournalItemsPresenter As PurchaseJournalItemsPresenter

        Public Overrides Function ChangesMade() As Boolean
            Dim purchaseJournalChangesMade As Boolean
            If ObjectsCompare(OriginalModel, View) Then
                If JournalItemsPresenter.ChangesMadeInJournalItem Then
                    purchaseJournalChangesMade = True
                Else
                    purchaseJournalChangesMade = False
                End If
            Else
                purchaseJournalChangesMade = True
            End If
            Return purchaseJournalChangesMade
        End Function

        'Public Overrides Function DataIsValid() As Boolean
        '    If MyBase.DataIsValid() Then
        '        DataModel = GlobalVariables.Mapper.Map(Of PurchaseJournalModel)(View)
        '        With JournalItemsPresenter.View
        '            DataModel.JournalItems = .JournalItems
        '        End With
        '        Return JournalItemsPresenter.DataIsValid(DataModel)
        '    Else
        '        Return False
        '    End If
        'End Function

        Public Shadows Sub Display(idNo As Integer, Optional ByVal undoMode As Boolean = False)
            Dim modelData As PurchaseJournalModel
            modelData = Model.GetRecordById(Of PurchaseJournalModel)(idNo)
            If modelData IsNot Nothing Then
                OriginalModel = modelData
                If idNo <> 0 Then
                    GlobalVariables.Mapper.Map(modelData, View)
                End If
            End If
        End Sub

        Public Function UpdateGlReferenceNumber() As String
            GlobalVariables.Mapper.Map(View, DataModel)
            Return ModelPresenter.UpdateGlReferenceNumber(DataModel)
        End Function

    End Class

End Namespace
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class PurchaseJournalPresenter
        Inherits AccountsPresenter(Of IPurchaseJournalView, PurchaseJournalModel)

        Public ParentViewList As List(Of PurchaseJournalModel)

        Public Sub New(view As IPurchaseJournalView)
            MyBase.New(view)
            ModelOfPresenter = New ModelAccounts("PurchaseJournal")
            TableName = "PurchaseJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New PurchaseJournalModel()
            DataModel = New PurchaseJournalModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
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

        'Protected Overrides Function DataIsValid() As Boolean
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

        Public Shadows Sub Display(idNo As Int32)
            Dim modelData As PurchaseJournalModel
            modelData = Model.GetRecordByIdNo(Of PurchaseJournalModel)(idNo)
            If modelData IsNot Nothing Then
                OriginalModel = modelData
                If idNo <> 0 Then
                    GlobalVariables.Mapper.Map(modelData, View)
                End If
            End If
        End Sub

        Public Function UpdateGlReferenceNumber() As String
            GlobalVariables.Mapper.Map(View, DataModel)
            Return ModelOfPresenter.UpdateGlReferenceNumber(DataModel)
        End Function

    End Class

End Namespace
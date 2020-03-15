Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Models
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Presenters


    Public Class PurchaseJournalPresenter
        Inherits AccountsPresenter(Of IPurchaseJournalView, PurchaseJournal, PurchaseJournalModel)

        Public ParentViewList As List(Of PurchaseJournalModel)

        Shared Sub New()
            ModelTblColProp = New ModelTblColProp
            ModelDefaultFieldValue = New ModelDefaultFieldValue
        End Sub

        Public Sub New(view As IPurchaseJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelPurchaseJournal()
            TableName = "PurchaseJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New PurchaseJournalModel()
            BizObject = New PurchaseJournal
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
            Dim retValue As String
            'DataModel = GlobalVariables.Mapper.Map(Of PurchaseJournalModel)(BizObject)
            retValue = Model.UpdateGlReferenceNumber(BizObject)
            Return retValue
        End Function

    End Class
End NameSpace
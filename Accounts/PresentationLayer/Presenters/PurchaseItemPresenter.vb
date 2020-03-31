Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class PurchaseItemPresenter
        Inherits AccountsPresenter(Of IPurchaseItemView, PurchaseItemModel)

        Public Sub New(view As IPurchaseItemView)
            MyBase.New(view)
            Initializer("PurchaseItem")
            'ModelPresenter = New ModelAccounts("PurchaseItem")
            'TableName = "PurchaseItem"
            'SortOrderKey = "IdNo"
            'TreeViewMainField = "PurchaseItemName"
            'TreeViewSecondaryField = "PurchaseItemCode"
            'TreeViewList = New List(Of PurchaseItemModel)
            'OriginalModel = New PurchaseItemModel()
            'DataModel = New PurchaseItemModel
        End Sub

        Public Overrides Function ChangesMade() As Boolean
            Dim purchaseItemChangesMade As Boolean
            If ObjectsCompare(OriginalModel, View) Then
                purchaseItemChangesMade = False
            Else
                purchaseItemChangesMade = True
            End If
            Return purchaseItemChangesMade
        End Function

        Public Shadows Sub Display(idNo As Integer)
            Dim modelData As PurchaseItemModel
            modelData = Model.GetRecordById(Of PurchaseItemModel)(idNo)
            If modelData IsNot Nothing Then
                OriginalModel = GlobalVariables.Mapper.Map(Of PurchaseItemModel)(modelData)
                GlobalVariables.Mapper.Map(modelData, View)
            End If
        End Sub

    End Class

End Namespace
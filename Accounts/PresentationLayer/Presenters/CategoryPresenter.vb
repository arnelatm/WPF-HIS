Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Presenters

    Public Class CategoryPresenter
        Inherits AccountsPresenter(Of ICategoryView, CategoryModel)

        Public ParentViewList As List(Of CategoryModel)

        Shared Sub New()
            ModelTblColProp = New ModelTblColProp
            ModelDefaultFieldValue = New ModelDefaultFieldValue
        End Sub

        Public Sub New(view As ICategoryView)
            MyBase.New(view)
            ModelPresenter = New ModelCategory()
            TableName = "Category"
            SortOrderKey = "IdNo"
            TreeViewMainField = "CategoryName"
            TreeViewSecondaryField = "CategoryCode"
            TreeViewList = New List(Of CategoryModel)
            OriginalModel = New CategoryModel()
            DataBizObject = New Category
            DataModel = New CategoryModel
        End Sub

        Public Overrides Function ChangesMade() As Boolean
            Dim CategoryChangesMade As Boolean
            If ObjectsCompare(OriginalModel, View) Then
                CategoryChangesMade = False
            Else
                CategoryChangesMade = True
            End If
            Return CategoryChangesMade
        End Function

        Public Shadows Sub Display(idNo As Integer, Optional ByVal undoMode As Boolean = False)
            Dim modelData As CategoryModel
            modelData = Model.GetRecordById(Of CategoryModel)(idNo)
            If modelData IsNot Nothing Then
                OriginalModel = GlobalVariables.Mapper.Map(Of CategoryModel)(modelData)
                GlobalVariables.Mapper.Map(modelData, View)
            End If
        End Sub

    End Class

End Namespace
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.PresentationLayer.Views.Forms
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class BranchPresenter
        Inherits CommonPresenter(Of IBranchView, BranchModel)

        Public Sub New(view As IBranchView)
            MyBase.New(view)

            ModelPresenter = New ModelCommon("Branch")
            TableName = "Branch"
            SortOrderKey = "BranchName"
            TreeViewMainField = "BranchName"
            TreeViewSecondaryField = "BranchCode"
            OriginalModel = New BranchModel()
            DataModel = New BranchModel
            TreeViewList = New List(Of BranchModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Function GetBranchList(Optional ByVal sortKey As String = "") As List(Of BranchModel)
            Dim xModel As New BranchModel
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of BranchModel)(sortKey, xModel)
            Dim modelData = Model.GetAll(Of BranchModel)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New BranchModel
                GlobalVariables.Mapper.Map(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

    End Class

End Namespace
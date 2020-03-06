Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class BranchPresenter
        Inherits CommonPresenter(Of IBranchView, BranchModel)

        Public Sub New(view As IBranchView)
            MyBase.New(view)
            CurrentModel = New ModelBranch
            TableName = "Branch"
            SortOrderKey = "BranchName"
            TreeViewMainField = "BranchName"
            TreeViewSecondaryField = "BranchCode"
            OriginalModel = New BranchModel()
            BizObject = New Branch
            DataModel = New BranchModel
            DbDataDao = New BranchDao
            TreeViewList = New List(Of BranchModel)
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
                GlobalSubs.MapObject(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

    End Class

End Namespace
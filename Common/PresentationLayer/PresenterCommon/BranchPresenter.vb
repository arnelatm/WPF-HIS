Imports System.Windows.Forms.VisualStyles
Imports AATM.Accounts.PresentationaLayer.Views
Imports AATM.HIS.Common.BusinessLayer
Imports AATM.HIS.Common.DataLayer.AdoNet
Imports AATM.HIS.Common.PresentationLayer.Models
Imports AATM.HIS.Common.PresentationLayer.Views
Imports AATM.HIS.Common.ServiceLayer.ActionService

Namespace PresentationLayer.Presenters

    Public Class BranchPresenter
        Inherits CommonPresenterOld(Of IBranchView, VisualStyleElement.TreeView.Branch, BranchModel)

        Public Sub New(view As IBranchView)
            MyBase.New(view)
            TableName = "Branch"
            SortOrderKey = "BranchName"
            TreeViewMainField = "BranchName"
            TreeViewSecondaryField = "BranchCode"
            OriginalModel = New BranchModel()
            BizObject = New VisualStyleElement.TreeView.Branch
            DataModel = New BranchModel
            DbDataDao = New BranchDao
            TreeViewList = New List(Of BranchModel)
            'Model = New Model()
            Model.SetService(New BranchService)
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
                MapObject(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

    End Class

End Namespace
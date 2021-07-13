Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class BranchPresenter
        Inherits PresenterNew(Of IBranchView, BranchModel)

        Public Sub New(view As IBranchView)
            MyBase.New(view)
            Service = New ModelCommon("Branch")
            TableName = "Branch"
            TreeViewMainField = "BranchName"
            TreeViewSecondaryField = "BranchCode"
            SortOrderKey = "BranchName"
        End Sub

    End Class

End Namespace
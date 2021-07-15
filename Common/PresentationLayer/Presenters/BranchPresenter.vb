Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer

Namespace PresentationLayer.Presenters

    Public Class BranchPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IBranchView, TM)

        Public Sub New(view As IBranchView)
            MyBase.New(view)
            Service = New ServiceCommon("Branch")
            TableName = "Branch"
            TreeViewMainField = "BranchName"
            TreeViewSecondaryField = "BranchCode"
            SortOrderKey = "BranchName"
        End Sub

    End Class

End Namespace
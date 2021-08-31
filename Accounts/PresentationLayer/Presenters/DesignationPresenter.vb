Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class DesignationPresenter(Of TM As New)
        Inherits AccountsPresenterNew(Of IDesignationView, TM)

        Public ParentViewList As List(Of DesignationModel)

        Public Sub New(view As IDesignationView)
            MyBase.New(view)
            TableName = "Designation"
            SortOrderKey = "DesignationName"
            TreeViewMainField = "DesignationName"
            TreeViewSecondaryField = "DesignationCode"
        End Sub

    End Class

End Namespace
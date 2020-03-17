Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class DesignationPresenter
        Inherits AccountsPresenter(Of IDesignationView, DesignationModel)

        Public ParentViewList As List(Of DesignationModel)

        Public Sub New(view As IDesignationView)
            MyBase.New(view)
            InitializerWithTv("Designation")
            'TableName = "Designation"
            'SortOrderKey = "DesignationName"
            'TreeViewMainField = "DesignationName"
            'TreeViewSecondaryField = "DesignationCode"
            'OriginalModel = New DesignationModel()
            'DataModel = New DesignationModel
            'TreeViewList = New List(Of DesignationModel)
            'ParentViewList = New List(Of DesignationModel)
        End Sub

    End Class

End Namespace
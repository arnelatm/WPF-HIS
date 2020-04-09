Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class DesignationPresenter
        Inherits AccountsPresenter(Of IDesignationView, DesignationModel)

        Public ParentViewList As List(Of DesignationModel)

        Public Sub New(view As IDesignationView)
            MyBase.New(view)
            InitializerWithTv("Designation")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
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
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters


    Public Class DesignationPresenter
        Inherits CommonPresenterOld(Of IDesignationView, Designation, DesignationModel)

        Public ParentViewList As List(Of DesignationModel)

        Public Sub New(view As IDesignationView)
            MyBase.New(view)
            TableName = "Designation"
            SortOrderKey = "DesignationName"
            TreeViewMainField = "DesignationName"
            TreeViewSecondaryField = "DesignationCode"
            OriginalModel = New DesignationModel()
            BizObject = New Designation
            DataModel = New DesignationModel
            DbDataDao = New DesignationDao
            TreeViewList = New List(Of DesignationModel)
            ParentViewList = New List(Of DesignationModel)
            Model.SetService(New DesignationService)
        End Sub

    End Class
End NameSpace
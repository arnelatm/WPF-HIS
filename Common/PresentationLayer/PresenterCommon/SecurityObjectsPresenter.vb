Imports AATM.HIS.Common.BusinessLayer
Imports AATM.HIS.Common.DataLayer.AdoNet
Imports AATM.HIS.Common.PresentationLayer.Models
Imports AATM.HIS.Common.PresentationLayer.Views
Imports AATM.HIS.Common.ServiceLayer.ActionService

Namespace PresentationLayer.Presenters

    ''' <summary>
    '''     SecurityObjects Presenter class.
    ''' </summary>
    ''' <remarks>
    '''     MV Patterns: MVP design pattern.
    ''' </remarks>
    Public Class SecurityObjectsPresenter
        Inherits CommonPresenterOld(Of ISecurityObjectsView, SecurityObject, SecurityObjectModel)

        Protected ViewObject As List(Of SecurityObjectModel)

        ''' <summary>
        '''     Constructor
        ''' </summary>
        ''' <param name="view">The view</param>
        Public Sub New(view As ISecurityObjectsView)
            MyBase.New(view)
            TableName = "SecurityObject"
            SortOrderKey = "SecurityObjectName"
            TreeViewMainField = "SecurityObjectName"
            TreeViewSecondaryField = ""
            OriginalModel = New SecurityObjectModel()
            BizObject = New SecurityObject
            DataModel = New SecurityObjectModel
            DbDataDao = New SecurityObjectDao
            Model.SetService(New SecurityObjectService)
        End Sub

        ''' <summary>
        '''     Displays list of General Journal Items.
        ''' </summary>
        ''' <param name="securityGroupIdNo">SecurityGroupIdNo id to display.</param>
        Public Overrides Sub Display(securityGroupIdNo As Integer, Optional ByVal undoMode As Boolean = False)
            View.SecurityObjects = Model.GetRecordsWithIdNo(Of SecurityObjectModel)(securityGroupIdNo, "Sequence")
        End Sub

        Public Shared Property ChangesMadeInDataGrid As Boolean = False
    End Class

End Namespace
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

''' <summary>
'''     SecurityObjects Presenter class.
''' </summary>
''' <remarks>
'''     MV Patterns: MVP design pattern.
''' </remarks>
Public Class SecurityObjectsPresenter
    Inherits Presenter(Of ISecurityObjectsView, SecurityObjectModel)

    Protected ViewObject As List(Of SecurityObjectModel)

    ''' <summary>
    '''     Constructor
    ''' </summary>
    ''' <param name="view">The view</param>
    Public Sub New(view As ISecurityObjectsView)
        MyBase.New(view)
        CurrentModel = New ModelSecurityObject
        TableName = "SecurityObject"
        SortOrderKey = "SecurityObjectName"
        TreeViewMainField = "SecurityObjectName"
        TreeViewSecondaryField = ""
        OriginalModel = New SecurityObjectModel()
        DataBizObject = New SecurityObject
        DataModel = New SecurityObjectModel
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
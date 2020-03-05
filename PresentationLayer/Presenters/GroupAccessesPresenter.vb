Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.DataLayer.AdoNet
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

''' <summary>
'''     GroupAccesses Presenter class.
''' </summary>
''' <remarks>
'''     MV Patterns: MVP design pattern.
''' </remarks>
Public Class GroupAccessesPresenter
    Inherits Presenter(Of IGroupAccessesView, GroupAccessModel)

    'Public Property SecurityObjects As IList(Of SecurityObjectModel)

    ''' <summary>
    '''     Constructor
    ''' </summary>
    ''' <param name="view">The view</param>
    Public Sub New(view As IGroupAccessesView)
        MyBase.New(view)
        CurrentModel = New ModelGroupAccesses
        TableName = "GroupAccess_View"
        SortOrderKey = "SecurityGroupIDNo"
        OriginalModel = New GroupAccessModel()
        BizObject = New GroupAccess
        DataModel = New GroupAccessModel
        DbDataDao = New GroupAccessDao
        'Model.SetService(New GroupAccessService)
        'Dim modelSecurityObject = New SecurityObjectDisplayModel()
        'SecurityObjects = modelSecurityObject.GetAll(Of SecurityObjectModel)("SecurityObjectName")

    End Sub

    ''' <summary>
    '''     Displays list of GroupAccesses.
    ''' </summary>
    ''' <param name="securityGroupIdNo">SecurityGroup id to display.</param>
    Public Overrides Sub Display(securityGroupIdNo As Integer, Optional ByVal undoMode As Boolean = False)
        View.GroupAccesses = Model.GetRecordsWithIdNo(Of GroupAccessModel)(securityGroupIdNo, "SecurityObjectName")
    End Sub

    Public Overrides Function ChangesMade() As Boolean
        Dim changeMade As Boolean
        Debugger.Break()
        changeMade = True 'DirectCast(View, PresentationLayer.Forms.SecurityGroupEntryTv).DataGridViewGroupAccesses.DataInGridChanged
        If changeMade Then
            Return True
        End If
        Return False
    End Function

    Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                   journalIdNo As Integer)
        Dim insertReturnValue As Int16
        Dim updateReturnValue As Int16
        Dim retVal As Int16
        updateReturnValue = Model.DelUpdateTvp(dtUpdate, journalIdNo)
        If updateReturnValue >= 0 AndAlso dtInsert.Rows.Count > 0 Then
            insertReturnValue = Model.InsertTvp(dtInsert)
            If insertReturnValue >= 0 Then
                retVal = updateReturnValue + insertReturnValue
            Else
                retVal = insertReturnValue
            End If
        Else
            retVal = updateReturnValue
        End If
        Return retVal
    End Function

End Class
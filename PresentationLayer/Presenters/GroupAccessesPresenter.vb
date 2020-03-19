Imports AATM.DataLayer.AdoNet
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views
Imports AATM.ServicesLayer.Services

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
        ModelPresenter = New ModelGroupAccess
        TableName = "GroupAccess_View"
        SortOrderKey = "SecurityGroupIDNo"
        OriginalModel = New GroupAccessModel()
        DataModel = New GroupAccessModel
        DbDataDao = New GroupAccessDao
        DataService = New ServiceGroupAccess
    End Sub

    ''' <summary>
    '''     Displays list of GroupAccesses.
    ''' </summary>
    ''' <param name="securityGroupIdNo">SecurityGroup id to display.</param>
    Public Overrides Sub Display(securityGroupIdNo As Integer, Optional ByVal undoMode As Boolean = False)
        View.GroupAccesses = Model.GetRecordsWithIdNo(Of GroupAccessModel)(securityGroupIdNo, "SecurityObjectName")
    End Sub

    'Public Overrides Function ChangesMade() As Boolean
    '    Dim changeMade As Boolean
    '    changeMade = DirectCast(view, AATM.PresentationLayer.Forms.SecurityGroupEntryTv).DataGridViewGroupAccesses.DataInGridChanged
    '    If changeMade Then
    '        Return True
    '    End If
    '    Return False

    '    'Dim changeMade As Boolean = False
    '    'Dim currentModel As New List(Of GroupAccessModel)
    '    'GlobalVariables.Mapper.Map(View.GroupAccesses, currentModel)
    '    'For I = 1 To currentModel.Count()
    '    '    If currentModel(I) = OriginalModel(I) Then
    '    '        changeMade = True
    '    '        Exit For
    '    '    End If
    '    'Next
    '    'Return changeMade

    '    'Dim Result As Boolean = False
    '    'myBindingSource.EndEdit()
    '    'Result = (CType(myBindingSource.DataSource, DataTable)).GetChanges(DataRowState.Modified) IsNot Nothing
    '    'Return Result

    'End Function

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
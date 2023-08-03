Imports AATM.Libraries
Imports AATM.Libraries.AatmInterfaces

Public Enum ButtonClicked
    [Add]
    [Delete]
    [Edit]
    [Find]
    [First]
    [Last]
    [Next]
    [Previous]
    [Quit]
    [Save]
    [Undo]
    [Print]
    [Filter]
    [Translate]
End Enum

Public Class AddModeChanged

    Public Sub New(ByVal addMode As Boolean)
        Me.AddMode = addMode
    End Sub

    Public Property AddMode As Boolean

End Class

Public Class EditModeChanged

    Public Sub New(ByVal editMode As Boolean)
        Me.EditMode = editMode
    End Sub

    Public Property EditMode As Boolean

End Class

Public Class InsertDgvLine

    Public Sub New(ByVal nRow As Int16, Optional dgvName As String = "")
        Me.BsRow = nRow
        Me.Name = dgvName
    End Sub

    Public Property BsRow
    Public Property Name

End Class

Public Class PassErrorList

    Public Sub New(ByRef errors As List(Of String))
        Me.Errors = errors
    End Sub

    Public Property Errors As List(Of String)

End Class

Public Class QuitView

    Public Sub New(ByRef quitView As Boolean)
        Me.QuitView = quitView
    End Sub

    Public Property QuitView As Boolean

End Class

Public Class BeforeAssignment

    Public Sub New(ByRef model)
        Me.Model = model
    End Sub

    Public Property Model
End Class

Public Class RecordPositionChanged

    Public Sub New(ByRef recPos As Integer)
        RecordPosition = recPos
    End Sub

    Public Property RecordPosition As Integer

End Class

Public Class RecordSaved

    Public Sub New(ByRef model)
        Me.Model = model
    End Sub

    Public Property Model

End Class

Public Class RecordDeleted

    Public Sub New(ByRef idNo As Int32)
        Me.IdNo = idNo
    End Sub

    Public Property IdNo As Int32

End Class

Public Class SelectedButton

    Public Sub New(ByVal clickedButton As ButtonClicked)
        Me.ClickedButton = clickedButton
    End Sub

    Public Property ClickedButton As ButtonClicked

End Class

Public Class ValidatingData

    Public Sub New(ByRef validated As Boolean)
        Me.Validated = validated
    End Sub

    Public Property Validated
End Class

'Public Class DataGridCellChanged

'    Public Sub New(ByVal index As Integer, ByVal columnName As String)
'        Me.Index = index
'        Me.ColumnName = columnName
'    End Sub

'    Public Property Index As Integer
'    Public Property ColumnName As String

'End Class

Public Class ViewButtonClicked

    Public Sub New(ByVal selectedButton As ButtonClicked)
        Me.SelectedButton = selectedButton
    End Sub

    Public Property SelectedButton As ButtonClicked

End Class

Public Class LogStatusChanged

    Public Sub New(ByVal controlSecurityKey As String)
        Me.ControlSecurityKey = controlSecurityKey
    End Sub

    Public Property ControlSecurityKey As String

End Class

Public Class GetDataSource

    Public Sub New(ByVal tableName As String, ByRef control As Control, Optional ByVal filter As String = Nothing)
        Me.TableName = tableName
        Me.Control = control
        Me.Filter = filter
    End Sub

    Public Sub New(ByVal tableName As String, ByRef control As Control, ByVal sortKey As String, Optional ByVal filter As String = Nothing)
        Me.TableName = tableName
        Me.Control = control
        Me.Filter = filter
        Me.SortKey = sortKey
    End Sub

    Public Sub New(ByVal tableName As String, ByRef control As Control, ByVal fields As String(), Optional ByVal filter As String = Nothing)
        Me.TableName = tableName
        Me.Control = control
        Me.Filter = filter
        Me.Fields = fields
    End Sub

    Public Sub New(ByVal tableName As String, ByRef control As Control, ByVal fields As String(), Optional ByVal sortKey As String = Nothing, Optional ByVal filter As String = Nothing)
        Me.TableName = tableName
        Me.Control = control
        Me.Filter = filter
        Me.Fields = fields
        Me.SortKey = sortKey
    End Sub

    Public Property TableName As String
    Public Property Control As Control
    Public Property Fields As String()
    Public Property SortKey As String
    Public Property Filter As String

End Class

Public Class GetDataSourceSpecial

    Public Sub New(ByVal tableName As String, ByRef control As Control, Optional ByVal filter As String = Nothing)
        Me.TableName = tableName
        Me.Control = control
        Me.Filter = filter
    End Sub

    Public Sub New(ByVal tableName As String, ByRef control As Control, ByVal sortKey As String, Optional ByVal filter As String = Nothing)
        Me.TableName = tableName
        Me.Control = control
        Me.Filter = filter
        Me.SortKey = sortKey
    End Sub

    Public Sub New(ByVal tableName As String, ByRef control As Control, ByVal fields As String(), Optional ByVal filter As String = Nothing)
        Me.TableName = tableName
        Me.Control = control
        Me.Filter = filter
        Me.Fields = fields
    End Sub

    Public Property TableName As String
    Public Property Control As Control
    Public Property Fields As String()
    Public Property SortKey As String
    Public Property Filter As String

End Class

Public Class GetLookupDataRequested

    'Public Sub New(ByVal tableName As String, ByRef view As Control, ByRef targetLookup As List(Of Lookup.LookupData), ByVal Optional filter As String = Nothing)
    '    Me.TableName = tableName
    '    Me.TargetProperty = TargetProperty
    '    Me.Filter = filter
    '    Me.View = view
    '    Me.TargetLookup = targetLookup
    'End Sub

    Public Sub New(ByVal targetSourceName As String)
        Me.TargetSourceName = targetSourceName
    End Sub

    Public Sub New(ByVal tableName As String, ByRef view As Control, targetProperty As String, ByVal Optional filter As String = Nothing)
        Me.TableName = tableName
        Me.TargetProperty = targetProperty
        Me.Filter = filter
        Me.View = view
    End Sub

    Public Sub New(ByVal tableName As String, ByRef view As Control, targetProperty As String, ByVal sortKey As String, ByVal Optional filter As String = Nothing)
        Me.TableName = tableName
        Me.TargetProperty = targetProperty
        Me.SortKey = sortKey
        Me.Filter = filter
        Me.View = view
    End Sub

    Public Sub New(ByVal tableName As String, ByRef view As Control, targetProperty As String, ByVal fields As String(), ByVal Optional filter As String = Nothing)
        Me.TableName = tableName
        Me.View = view
        Me.TargetProperty = targetProperty
        Me.Filter = filter
        Me.Fields = fields
    End Sub

    Public Sub New(ByVal tableName As String, ByRef view As Control, targetProperty As String, ByVal sortKey As String, ByVal fields As String(), ByVal Optional filter As String = Nothing)
        Me.TableName = tableName
        Me.View = view
        Me.TargetProperty = targetProperty
        Me.Filter = filter
        Me.SortKey = sortKey
        Me.Fields = fields
    End Sub

    Public Property TableName As String
    Public Property View As Control
    Public Property TargetProperty As String
    Public Property Fields As String()
    Public Property Filter As String
    Public Property SortKey As String
    Public Property TargetSourceName As String
    'Public Property TargetLookup As List(Of Lookup.LookupData)
End Class

Public Class GetLookupDataTableRequested

    'Public Sub New(ByVal tableName As String, ByRef view As Control, ByRef targetLookup As List(Of Lookup.LookupData), ByVal Optional filter As String = Nothing)
    '    Me.TableName = tableName
    '    Me.TargetProperty = TargetProperty
    '    Me.Filter = filter
    '    Me.View = view
    '    Me.TargetLookup = targetLookup
    'End Sub

    Public Sub New(ByVal targetSourceName As String)
        Me.TargetSourceName = targetSourceName
    End Sub

    Public Sub New(ByVal tableName As String, ByRef view As Control, targetProperty As String, ByVal Optional filter As String = Nothing)
        Me.TableName = tableName
        Me.TargetProperty = targetProperty
        Me.Filter = filter
        Me.View = view
    End Sub

    Public Sub New(ByVal tableName As String, ByRef view As Control, targetProperty As String, ByVal sortKey As String, ByVal Optional filter As String = Nothing)
        Me.TableName = tableName
        Me.TargetProperty = targetProperty
        Me.SortKey = sortKey
        Me.Filter = filter
        Me.View = view
    End Sub

    Public Sub New(ByVal tableName As String, ByRef view As Control, targetProperty As String, ByVal fields As String(), ByVal Optional filter As String = Nothing)
        Me.TableName = tableName
        Me.View = view
        Me.TargetProperty = targetProperty
        Me.Filter = filter
        Me.Fields = fields
    End Sub

    Public Sub New(ByVal tableName As String, ByRef view As Control, targetProperty As String, ByVal sortKey As String, ByVal fields As String(), ByVal Optional filter As String = Nothing)
        Me.TableName = tableName
        Me.View = view
        Me.TargetProperty = targetProperty
        Me.Filter = filter
        Me.SortKey = sortKey
        Me.Fields = fields
    End Sub

    Public Property TableName As String
    Public Property View As Control
    Public Property TargetProperty As String
    Public Property Fields As String()
    Public Property Filter As String
    Public Property SortKey As String
    Public Property TargetSourceName As String
    'Public Property TargetLookup As List(Of Lookup.LookupData)
End Class
Public Class GetEnumListRequested

    Public Sub New(ByRef enumList As Object, ByRef target As List(Of Lookup.LookupData))
        Me.Target = target
        Me.EnumList = enumList
    End Sub

    Public Property Target As List(Of Lookup.LookupData)
    Public Property EnumList As Object

End Class

Public Class GetEnumListRequestedNew(Of TE)

    Public Sub New(ByRef enumList As TE, ByRef target As List(Of Lookup.LookupData))
        Me.Target = target
        Me.EnumList = enumList
    End Sub

    Public Property Target As List(Of Lookup.LookupData)
    Public Property EnumList As TE

End Class

Public Class SaveDataRequested

    Public Sub New(ByVal viewControl As Control)
        Me.ViewControl = viewControl
    End Sub

    Public Property ViewControl As Control
    Public Property ValidData As Boolean

End Class

Public Class FindFieldRequested

    Public Sub New(ByVal findableControl As IFindableControl)
        Me.FindableControl = findableControl
    End Sub

    Public Property FindableControl As IFindableControl

End Class

Public Class ValidateViewRequested

    Public Sub New(ByRef viewControl As Control)
        Me.ViewControl = viewControl
    End Sub

    Public Property ViewControl As Control
    Public Property ValidView As Boolean

End Class

Public Class IdNoEventArgs
    Inherits EventArgs

    Private _idNo As Int32

    Public Sub New(ByVal idNo As Int32)
        _idNo = idNo
    End Sub

    Public Property IdNo As Int32
        Get
            Return _idNo
        End Get
        Set(ByVal value As Int32)
            _idNo = value
        End Set
    End Property

End Class

Public Class EntryFormLoaded

    Public Sub New(ByVal viewControl As Control)
        Me.ViewControl = viewControl
    End Sub

    Public Property ViewControl As Control

End Class

Public Class LanguageChanged

    Public Sub New(ByVal viewControl As Control)
        Me.ViewControl = viewControl
    End Sub

    Public Property ViewControl As Control

End Class

Public Class DgvItemsChanged

    Public Sub New(bindingSource As BindingSource, row As Int32, propertyName As String, elementName As String, enteredValue As Object)
        Me.BindingSource = bindingSource
        Me.Row = row
        Me.PropertyName = propertyName
        Me.ElementName = elementName
        Me.EnteredValue = enteredValue
    End Sub

    Public Property BindingSource As BindingSource
    Public Property Row As Int32
    Public Property PropertyName As String
    Public Property ElementName As String
    Public Property EnteredValue As Object

End Class

Public Class DgvItemsValidating

    Public Sub New(bindingSource As BindingSource, row As Int32, propertyName As String, elementName As String, enteredValue As Object)
        Me.BindingSource = bindingSource
        Me.Row = row
        Me.PropertyName = propertyName
        Me.ElementName = elementName
        Me.EnteredValue = enteredValue
    End Sub

    Public Property BindingSource As BindingSource
    Public Property Row As Int32
    Public Property PropertyName As String
    Public Property ElementName As String
    Public Property EnteredValue As Object

End Class

Public Class GetControlDataSource

    Public Sub New(tableName As String, control As Control)
        Me.TableName = tableName
        Me.Control = control
    End Sub

    Public Property TableName As String
    Public Property Control As Control

End Class

Public Class PrintCrEventArgs

    Public Sub New(ByVal fileName As String, ByVal dataBaseConnection As String, ByVal Args As Object, ByVal Copies As Integer)
        Me.FileName = fileName
        Me.DataBaseConnectionName = dataBaseConnection
        Me.Copies = Copies
        Me.Args = Args
    End Sub

    Public Property FileName As String
    Public Property DataBaseConnectionName As String
    Public Property Copies As Integer
    Public Property Args As Object

End Class
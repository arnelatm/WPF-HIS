Imports System.ComponentModel

'Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.GlobalResources
Imports AATM.Libraries.MessagingLibrary

Public Class CDataGridView
    Inherits DataGridView
    Implements IEntryControl, IFindableControl

    'Private _dgvInsertColumnIndex As Integer = -1
    Private _editingMode As Boolean
    Private _translatable As Boolean = True
    Private _firstEditableColumn As Integer = -1
    Private _firstVisibleColumn As Integer = -1
    Private _insertColumnAdded As Boolean = False
    Private _lastEditableColumn As Integer = -1
    Private _memoryCache As Cache
    Private ReadOnly _origEditMode As DataGridViewEditMode
    Private _columnNo As Integer

    Public Sub New()
        MyBase.New()
        DoubleBuffered = True
        Enabled = True
        BackColor = Drawing.SystemColors.ControlLight
        DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
        DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
        AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite
        ShowEditingIcon = True
        ShowCellErrors = True
        ShowRowErrors = True
        _origEditMode = EditMode

    End Sub

    Public Property Cached As Boolean = False

    Public Property DataFilter As String = Nothing

    Public Event ChangesMade As EventHandler

    Public Event DeletingRow(ByVal cancel As Boolean)

    Public Property DgvFooter As DgvFooter

    Public Property FieldsDictionary As Dictionary(Of String, Object)

    '<Bindable(True)>
    '<Category("Custom")>
    '<DefaultValue(GetType(Boolean))>
    '<Description("Set to True to specify that this control will display a footer.")>
    '<Browsable(True)>
    Public Property ShowFooter As Boolean

    <Bindable(True)>
    <Category("Custom")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is readonly.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean

    Public Property Ea As EventAggregator
    'Public Property FindDataType As DataTypeEnum
    'Public Property FindEnabled As Boolean
    'Public Property BegFindValue As Object
    'Public Property EndFindValue As Object
    'Public Property SearchPlace As SearchPlaceEnum
    'Public Property FieldName As String
    'Public Property FieldDescription As String
    'Public Property IgnoreCase As Boolean

    Private Sub DataGridView_DataSourceChanged(sender As Object, e As EventArgs) Handles Me.DataSourceChanged
        If Columns(SequenceColumn) IsNot Nothing Then
            CallByName(Columns(SequenceColumn), "DisplayOnly", CallType.Set, True)
            'Invoker.SetProperty(Columns(SequenceColumn), "DisplayOnly", True)
        End If
        If ShowFooter Then
            DgvFooter = New DgvFooter(Me) With {
                .AutoCalc = True
                }
        End If
    End Sub

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
            If DisplayOnly OrElse Not value Then
                DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                [ReadOnly] = True
            Else
                DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                [ReadOnly] = False
            End If
            For Each col In Columns
                If TypeOf col Is IEntryControl Then
                    col.EditingMode = value
                End If
            Next
            If ShowFooter Then
                If DgvFooter Is Nothing Then
                    DgvFooter = New DgvFooter(Me) With {
                        .AutoCalc = True
                        }
                End If
                DgvFooter.CalculateTotals()
            End If
        End Set
    End Property

    'Private Sub DataGridView_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Me.CellEnter
    '    If CurrentCell IsNot Nothing Then 'AndAlso TypeOf (CurrentCell) Is CDgvDtpCell Then
    '        EditMode = DataGridViewEditMode.EditOnEnter
    '    End If
    'End Sub

    'Private Sub dataGridView1_CellLeave(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Me.CellLeave
    '    If CurrentCell IsNot Nothing AndAlso TypeOf CurrentCell Is CtDgvDtpCell Then
    '        EditMode = _origEditMode
    '    End If
    'End Sub

    Public ReadOnly Property FirstEditableColumn As Integer
        Get
            Return GetFirstEditableColumn()
        End Get
    End Property

    Public Function GetColumnTotal(ByVal columnName As String)
        Return DgvFooter.GetColumnTotal(columnName)
    End Function

    <Bindable(True)>
    <Category("Custom")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that Deletion of first row is allowed.")>
    <Browsable(True)>
    Public Property FirstRowDeletionEnabled As Boolean = True

    <Bindable(True)>
    <Category("Custom")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that Insertion on first row not allowed.")>
    <Browsable(True)>
    Public Property FirstRowInsertionEnabled As Boolean = True

    Public ReadOnly Property FirstVisibleColumn As Integer
        Get
            Return GetFirstVisibleColumn()
        End Get
    End Property

    Public ReadOnly Property LastEditableColumn As Integer
        Get
            Return GetLastEditableColumn()
        End Get
    End Property

    <Bindable(True)>
    <Category("Custom")>
    <DefaultValue(GetType(String))>
    <Description("Enter here the property name for sequence column")>
    <Browsable(True)>
    Public Property SequenceColumn As String = "dgvSequence"

    <Bindable(True)>
    <Category("Custom")>
    <DefaultValue(GetType(String))>
    <Description("Enter here the field name for sequence column")>
    <Browsable(True)>
    Public Property SequenceFieldName As String = "Sequence"

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return True
        End Get
        Set
            _translatable = Value
        End Set
    End Property

    Public Property FindDataType As IFindableControl.DataTypeEnum Implements IFindableControl.FindDataType

    Public Property FindEnabled As Boolean Implements IFindableControl.FindEnabled

    Public Property BegFindValue As Object Implements IFindableControl.BegFindValue

    Public Property EndFindValue As Object Implements IFindableControl.EndFindValue

    Public Property SearchPlace As IFindableControl.SearchPlaceEnum Implements IFindableControl.SearchPlace

    Public Property FieldName As String Implements IFindableControl.FieldName

    Public ReadOnly Property FindDataSource As Object Implements IFindableControl.FindDataSource

    Public ReadOnly Property FindDisplayMember As String Implements IFindableControl.FindDisplayMember

    Public ReadOnly Property SearchMode As IFindableControl.SearchModeEnum Implements IFindableControl.SearchMode

    Public ReadOnly Property FindValueMember As String Implements IFindableControl.FindValueMember

    Public Property IgnoreCase As Boolean Implements IFindableControl.IgnoreCase

    Public Property FieldDescription As String Implements IFindableControl.FieldDescription

    'Public Sub AddInsertColumn()
    '    If Not DisplayOnly AndAlso Not Columns.Contains("dgvInsertColumn") Then
    '        With Columns
    '            Dim dgvInsColumn As New DataGridViewImageColumn
    '            .Insert(.Count, dgvInsColumn)
    '            dgvInsColumn.Image = Images.InsertRowImage
    '            dgvInsColumn.Width = 30
    '            dgvInsColumn.Name = "dgvInsertColumn"
    '            dgvInsColumn.HeaderText = Messaging.TranslateCaption("Ins.")
    '            _insertColumnAdded = True
    '            _dgvInsertColumnIndex = dgvInsColumn.Index
    '        End With
    '    End If
    'End Sub

    'Public Sub RemoveInsertColumn()
    '    With Columns
    '        If _insertColumnAdded Then
    '            .Remove("dgvInsertColumn")
    '            _insertColumnAdded = False
    '        End If
    '    End With
    'End Sub

    Public Sub ReSequenceDgvAfterDelete()
        If CurrentCell IsNot Nothing Then
            Dim i = CurrentCell.RowIndex()
            Dim myBindingSource = CType(DataSource, BindingSource)
            Try
                'If CallByName(myBindingSource.Current, SequenceFieldName, CallType.Get) IsNot Nothing Then
                If Invoker.GetProperty(myBindingSource.Current, SequenceFieldName) IsNot Nothing Then
                    For Each record In myBindingSource
                        Dim sequence = CallByName(record, SequenceFieldName, CallType.Get)
                        'Dim sequence = Invoker.GetProperty(record, SequenceFieldName)
                        If sequence > i + 1 Then
                            CallByName(record, SequenceFieldName, CallType.Set, sequence - 1)
                            'Dim sq = sequence - 1
                            'sequence = Invoker.GetProperty(record, SequenceFieldName)
                            'Dim y = record.GetType().InvokeMember("Sequence", Reflection.BindingFlags.GetProperty, Nothing, record, Nothing)
                            'Dim x = record.GetType().InvokeMember("Sequence", Reflection.BindingFlags.SetProperty, Nothing, record, Nothing)
                            'record.GetType().InvokeMember("Sequence", Reflection.BindingFlags.SetProperty Or Reflection.BindingFlags.Public Or Reflection.BindingFlags.SetField Or Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.IgnoreCase or Reflection.BindingFlags.Instance Or Reflection.BindingFlags.SetField, Nothing, record, New Object() { 1 })
                            'Dim x As New Form
                            'x.GetType().InvokeMember("Text", Reflection.BindingFlags.SetProperty, Nothing, x, New Object() { "MyText" })
                            ' (sName,  SetPublicNonPublicPropertyFieldFlags , Nothing, oObject, yArguments )
                            ' Invoker.SetPublicPropertyOnly(record, SequenceFieldName, new Object() { 1 })
                        End If
                    Next
                End If
            Catch ex As Exception
                ' missing member
                Dim x = ex
            End Try

        End If
    End Sub

    Public Sub ReSequenceDgvAfterInsert()
        Dim i = CurrentCell.RowIndex()
        Dim myBindingSource = CType(DataSource, BindingSource)
        Try
            'If CallByName(myBindingSource.Current, SequenceFieldName, CallType.Get) IsNot Nothing Then
            If Invoker.GetProperty(myBindingSource.Current, SequenceFieldName) IsNot Nothing Then
                For Each o In myBindingSource
                    If o IsNot Nothing Then
                        'Dim sequence = CallByName(o, SequenceFieldName, CallType.Get)
                        Dim sequence = Invoker.GetProperty(o, SequenceFieldName)
                        If sequence = 0 Then
                            CallByName(o, SequenceFieldName, CallType.Set, i)
                            'Invoker.SetProperty(o, SequenceFieldName, {i})
                        ElseIf sequence >= i Then
                            CallByName(o, SequenceFieldName, CallType.Set, sequence + 1)
                            'Invoker.SetProperty(o, SequenceFieldName, {sequence + 1})
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Public Property ErrorMessageKey As String = Nothing
    'Public Property ErrorMessageParameters As Array = Nothing

    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        ' handles
        ' Extract the key code from the key value.
        Dim key As Keys = keyData And Keys.KeyCode

        ' Handle the ENTER key as if it were a RIGHT ARROW key.
        If key = Keys.Enter Then
            Return MoveToNextCell(keyData)
        End If

        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Protected Overrides Function ProcessDataGridViewKey(ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean

        ' Handle the ENTER key as if it were a RIGHT ARROW key.
        If e.KeyCode = Keys.Enter Then
            Return MoveToNextCell(e.KeyData)
        ElseIf e.KeyCode = Keys.Insert Then
            If Me.CurrentRow.Selected Then
                InsertRow(CurrentRow.Index)
            End If
        End If
        Return MyBase.ProcessDataGridViewKey(e)
    End Function

    Private Function MoveToNextCell(keyData As Keys) As Boolean

        Dim currentColumnIndex As Int16
        currentColumnIndex = CurrentCell.ColumnIndex()
        If currentColumnIndex = LastEditableColumn And currentColumnIndex < ColumnCount() Then
            If CurrentCell.RowIndex() + 1 < RowCount() Then
                ' hack need next line because currentcell not changing properly dont know why.
                'ProcessTabKey(keyData)
                CurrentCell = Me(FirstEditableColumn, CurrentCell.RowIndex() + 1)
                Return (keyData)
            End If
        End If
        Return Me.ProcessTabKey(keyData)
    End Function

    'Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean ' Extract the key code from the key value.
    '    Dim key As Keys = keyData And Keys.KeyCode
    '    If key = Keys.Enter And CurrentCell IsNot Nothing Then
    '        Dim currentColumnIndex As Int16
    '        currentColumnIndex = CurrentCell.ColumnIndex()
    '        If currentColumnIndex = LastEditableColumn And currentColumnIndex < ColumnCount() Then
    '            If CurrentCell.RowIndex() + 1 < RowCount() Then
    '                CurrentCell = Me(FirstEditableColumn, CurrentCellAddress.Y + 1)
    '                Return True
    '            End If
    '        End If
    '        ProcessTabKey(keyData)
    '        If ErrorMessageKey IsNot Nothing Then
    '            If ErrorMessageParameters Is Nothing Then
    '                Messaging.Show(True, ErrorMessageKey)
    '            Else
    '                Messaging.ShowPmMessage(True, ErrorMessageKey, ErrorMessageParameters)
    '            End If
    '        End If
    '        ErrorMessageKey = Nothing
    '        Return True
    '        'Dim currentColumnIndex As Int16
    '        'currentColumnIndex = CurrentCell.ColumnIndex()
    '        'If currentColumnIndex < LastEditableColumn Then
    '        '    ' Handle the ENTER key as if it were a tab ARROW key
    '        '    Return ProcessTabKey(keyData)
    '        'ElseIf currentColumnIndex = LastEditableColumn Then
    '        '    ' go to next row on the first editable column
    '        '    If CurrentCell.RowIndex() >= RowCount() Then
    '        '        CurrentCell = Me(FirstEditableColumn, RowCount() - 1)
    '        '    Else
    '        '        Return ProcessTabKey(keyData)
    '        '    End If
    '        '    Return True
    '        'Else
    '        '    Return MyBase.ProcessDialogKey(keyData)
    '        'End If
    '    Else
    '        Return MyBase.ProcessDialogKey(keyData)
    '    End If
    'End Function

    Private Sub cDataGridView_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles Me.DefaultValuesNeeded
        If (SequenceColumn IsNot Nothing AndAlso SequenceColumn <> "") Then
            If Columns(SequenceColumn) IsNot Nothing Then
                Dim nRowColumn = Columns(SequenceColumn).Index()
                With e.Row
                    .Cells(nRowColumn).Value = RowCount()
                End With
            End If
        End If
    End Sub

    Private Sub CDataGridView_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles MyBase.UserDeletedRow
        ReSequenceDgvAfterDelete()
        RaiseEvent ChangesMade(Me, EventArgs.Empty)
    End Sub

    'Private Sub DataGridViewJournalItems_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles MyBase.RowsAdded
    '    Dim x = 1
    'End Sub

    Private Sub CDataGridView_UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles Me.UserDeletingRow
        If Not EditingMode Then
            Messaging.Show(True, "MsgRowDelNotAllowedInViewMode")
            e.Cancel = True
        End If
    End Sub

    'Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles MyBase.CellClick
    '    'Try
    '    '    If EditingMode And CurrentCell IsNot Nothing Then
    '    '        With CurrentCell
    '    '            Select Case .OwningColumn.Name.ToLower()
    '    '                Case $"dgvinsertcolumn"
    '    '                    'If (CurrentRow.Index() <> NewRowIndex()) Then
    '    '                    'If Ea IsNot Nothing Then
    '    '                    '    Ea.PublishEvent(New InsertDgvLine(CurrentRow.Index(), Name))
    '    '                    'End If
    '    '                    If .RowIndex() = NewRowIndex() Then
    '    '                        Beep()
    '    '                    ElseIf .RowIndex() > 0 Or (.RowIndex() = 0 And FirstRowInsertionEnabled) Then
    '    '                        Dim myBindingSource = CType(DataSource, BindingSource)
    '    '                        Dim dataList = myBindingSource.AddNew()
    '    '                        myBindingSource.RemoveAt(myBindingSource.Count() - 1)
    '    '                        myBindingSource.Position = .RowIndex
    '    '                        myBindingSource.Insert(.RowIndex(), dataList)
    '    '                        ReSequenceDgvAfterInsert()
    '    '                        CurrentCell = Me(FirstEditableColumn, If(CurrentRow.Index() > 0, CurrentRow.Index() - 1, 0))
    '    '                    Else
    '    '                        Messaging.Show(True, "MsgFirstRowInsertionNotAllowed")
    '    '                    End If
    '    '                    'End If

    '    '            End Select
    '    '        End With
    '    '    End If
    '    'Catch ex As Exception
    '    '    Windows.MessageBox.Show("error")
    '    'End Try
    'End Sub

    Private Sub InsertRow(rowIndex As Int16)
        If rowIndex = NewRowIndex() Then
            Beep()
        ElseIf rowIndex > 0 Or (rowIndex = 0 And FirstRowInsertionEnabled) Then
            Dim myBindingSource = CType(DataSource, BindingSource)
            Dim dataList = myBindingSource.AddNew()
            myBindingSource.RemoveAt(myBindingSource.Count() - 1)
            myBindingSource.Position = rowIndex
            myBindingSource.Insert(rowIndex, dataList)
            ReSequenceDgvAfterInsert()
            CurrentCell = Me(FirstEditableColumn, If(CurrentRow.Index() > 0, CurrentRow.Index() - 1, 0))
        Else
            Messaging.Show(True, "MsgFirstRowInsertionNotAllowed")
        End If
        'End If
    End Sub

    'Private Sub DataGridView_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellEnter
    '    Dim dgc As DataGridViewCell = Me.Item(e.ColumnIndex, e.RowIndex)
    '    If dgc IsNot Nothing AndAlso dgc.ReadOnly Then
    '        SendKeys.Send("{Tab}")
    '    End If
    'End Sub
    'Private Sub AddNewRow()
    '    Dim myBindingSource = CType(DataSource, BindingSource)
    '    If myBindingSource IsNot Nothing Then
    '        Dim row = CurrentRow.Index() + 1
    '        Try
    '            myBindingSource.AddNew()
    '        Catch ex As Exception

    '        End Try
    '        'myBindingSource.MoveLast()
    '        If CurrentRow IsNot Nothing AndAlso CurrentRow.DataBoundItem IsNot Nothing Then
    '            CallByName(CurrentRow.DataBoundItem, "Sequence", CallType.Set, row + 1)
    '            CurrentCell = Me(FirstEditableColumn, If(CurrentRow.Index() > 0, row - 1, 0))
    '        End If
    '        'If CurrentRow IsNot Nothing AndAlso CurrentRow.DataBoundItem IsNot Nothing Then
    '        '    CallByName(CurrentRow.DataBoundItem, "Sequence", CallType.Set, row + 1)
    '        '    CurrentCell = Me(FirstEditableColumn, If(CurrentRow.Index() > 0, row - 1, 0))
    '        'End If
    '    End If
    'End Sub

    'Private Sub DataGridView_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Me.CellValueChanged
    '    RaiseEvent ChangesMade(Me, EventArgs.Empty)
    '    CallByName(CurrentRow.Cells("dgvInsColumn"), "Image", CallType.Set, Images.InsertRowImage)
    'End Sub

    Private Sub DataGridView_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles Me.DataError

        'Try
        'Catch ex As Exception
        If (e.Context = DataGridViewDataErrorContexts.Formatting) OrElse (e.Context = DataGridViewDataErrorContexts.PreferredSize) OrElse (e.Context = DataGridViewDataErrorContexts.Display) OrElse (e.Context = DataGridViewDataErrorContexts.Display) Then
            'Debugger.Break()
            ' ignore error
        Else
            'Debugger.Break()
            'Forms.MessageBox.Show("Error happened " & e.Context.ToString())
            If e.Context.HasFlag(DataGridViewDataErrorContexts.Parsing) Then
                'Forms.MessageBox.Show("Error happened " & e.Context.ToString())

                Dim editControl As Object = Me.EditingControl
                If TypeOf (editControl) Is CDgvDtpEditingControl Then
                    Dim x As CDgvDtpEditingControl = DirectCast(editControl, CDgvDtpEditingControl)
                    x.InformUserOfInvalidDate()
                End If
            End If
            'If e.Context.HasFlag(DataGridViewDataErrorContexts.CurrentCellChange) Then
            '    Forms.MessageBox.Show("Cell change")
            'End If
            'If e.Context.HasFlag(DataGridViewDataErrorContexts.Parsing) Then
            '    Forms.MessageBox.Show("parsing error")
            'End If
            'If e.Context.HasFlag(DataGridViewDataErrorContexts.LeaveControl) Then
            '    Debugger.Break()
            '    Forms.MessageBox.Show("leave control error")
            'End If

            'If (TypeOf (e.Exception) Is ConstraintException) Then
            '    Debugger.Break()
            '    Dim view As DataGridView = CType(sender, DataGridView)
            '    view.Rows(e.RowIndex).ErrorText = "an error"
            '    view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
            '    e.ThrowException = False
            'End If
        End If
        'End Try
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles Me.RowHeaderMouseClick
        SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
        Rows(e.RowIndex).Selected = True
    End Sub

    '' Write the method to call the Event, and then use it as you want.
    'Protected Sub OnParentofGridChanged(ByVal e As EventArgs)
    '    Dim ParentofGridChangedHandler As EventHandler =
    '    CType(Me.Events("ParentofGridChangedEvent"), EventHandler)
    '    If (ParentofGridChangedHandler IsNot Nothing) Then
    '        ParentofGridChangedHandler.Invoke(Me, e)
    '    End If
    'End Sub

    'Private Sub DataGridViewGroupAccesses_CurrentCellChanged(sender As Object, e As EventArgs) Handles MyBase.CurrentCellChanged
    '    If _dgvInsertColumnIndex <= 0 Then Exit Sub
    '    If (CurrentRow IsNot Nothing) AndAlso EditingMode AndAlso (_dgvInsertColumnIndex >= 1) Then
    '        If Images.InsertRowImage <> CurrentRow.Cells(_dgvInsertColumnIndex).Value Then
    '            CurrentRow.Cells(_dgvInsertColumnIndex).Value = Images.InsertRowImage
    '        End If
    '    End If
    'End Sub

    Private Function GetFirstEditableColumn() As Integer
        If _firstEditableColumn < 0 Then
            Dim nColumnCount As Integer = ColumnCount()
            For i = 0 To nColumnCount - 1
                If Columns(i).Name = SequenceColumn Then
                    'ignore
                ElseIf (Not Columns(i).Visible) Or Columns(i).ReadOnly Then
                    ' ignore
                Else
                    _firstEditableColumn = i
                    Exit For
                End If
            Next
        End If
        Return _firstEditableColumn
    End Function

    Private Function GetFirstVisibleColumn() As Integer
        If _firstVisibleColumn < 0 Then
            For i = 0 To ColumnCount() - 1
                If Columns(i).Visible Then
                    _firstVisibleColumn = i
                    Exit For
                End If
            Next
        End If
        Return _firstVisibleColumn
    End Function

    Private Function GetLastEditableColumn() As Integer
        If _lastEditableColumn < 0 Then
            Dim nColumnCount As Integer = ColumnCount()
            For i = nColumnCount - 1 To 0 Step -1
                If (Not Columns(i).Visible) Or Columns(i).ReadOnly Then
                    ' ignore
                Else
                    _lastEditableColumn = i
                    Exit For
                End If
            Next
        End If
        Return _lastEditableColumn
    End Function

    'Public Function GetEditingValue(cCurrentCell As Object, Optional field As String = "")
    '    If cCurrentCell IsNot Nothing Then
    '        Dim dgvControl As Libraries.CBaseControlsLibrary.CDgvComboboxCell
    '        dgvControl = TryCast(cCurrentCell, Libraries.CBaseControlsLibrary.CDgvComboboxCell)
    '        If dgvControl IsNot Nothing Then
    '            If dgvControl.CellEditingControl.SelectedItem IsNot Nothing Then
    '                Select Case field.ToLower()
    '                    Case $"code"
    '                        Return DirectCast(DirectCast(cCurrentCell, Libraries.CBaseControlsLibrary.CDgvComboboxCell).CellEditingControl.SelectedItem, AATM.Libraries.Lookup.LookupData).Code
    '                    Case $"name"
    '                        Return DirectCast(DirectCast(cCurrentCell, Libraries.CBaseControlsLibrary.CDgvComboboxCell).CellEditingControl.SelectedItem, AATM.Libraries.Lookup.LookupData).Name
    '                    Case $"idno"
    '                        Return DirectCast(DirectCast(cCurrentCell, Libraries.CBaseControlsLibrary.CDgvComboboxCell).CellEditingControl.SelectedItem, AATM.Libraries.Lookup.LookupData).IdNo
    '                    Case Else
    '                        Return cCurrentCell.Value
    '                End Select
    '            Else
    '                Return cCurrentCell.Value
    '            End If
    '        End If
    '    End If
    '    Return Nothing
    'End Function

    Public Function GetEditingValue(Optional field As String = "")
        If CurrentCell IsNot Nothing Then
            Dim dgvControl As Libraries.CBaseControlsLibrary.CDgvComboBoxCell
            dgvControl = TryCast(CurrentCell, Libraries.CBaseControlsLibrary.CDgvComboBoxCell)
            If dgvControl IsNot Nothing Then
                If dgvControl.CellEditingControl.SelectedItem IsNot Nothing Then
                    Select Case field.ToLower()
                        Case $"code"
                            Return DirectCast(DirectCast(CurrentCell, Libraries.CBaseControlsLibrary.CDgvComboBoxCell).CellEditingControl.SelectedItem, AATM.Libraries.Lookup.LookupData).Code
                        Case $"name"
                            Return DirectCast(DirectCast(CurrentCell, Libraries.CBaseControlsLibrary.CDgvComboBoxCell).CellEditingControl.SelectedItem, AATM.Libraries.Lookup.LookupData).Name
                        Case $"idno"
                            Return DirectCast(DirectCast(CurrentCell, Libraries.CBaseControlsLibrary.CDgvComboBoxCell).CellEditingControl.SelectedItem, AATM.Libraries.Lookup.LookupData).IdNo
                        Case Else
                            Return CurrentCell.Value
                    End Select
                Else
                    Return CurrentCell.Value
                End If
            End If
        End If
        Return Nothing
    End Function

    'Public Sub AddDeleteColumn()
    '    With Columns
    '        Dim parentForm = FindForm()
    '        If GetPropertyValue(parentForm, "Presenter.EditMode") Or GetPropertyValue(parentForm, "Presenter.AddMode") Then
    '            Dim dgvDelColumn As New DataGridViewImageColumn
    '            .Insert(.Count, dgvDelColumn)
    '            dgvDelColumn.Name = "dgvDeleteColumn"
    '            dgvDelColumn.Image = GlobalResources.SharedResources.Images.DeleteImage
    '            dgvDelColumn.Width = 30
    '            dgvDelColumn.HeaderText = "Del."
    '            _deleteColumnAdded = True
    '        Else
    '            _deleteColumnAdded = False
    '        End If
    '    End With
    'End Sub
    'Public Sub RemoveDeleteColumn()
    '    With Columns
    '        If _deleteColumnAdded Then
    '            .Remove("dgvDeleteColumn")
    '            _deleteColumnAdded = False
    '        End If
    '    End With
    'End Sub
    'Private Overloads Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Me.CellEndEdit

    '    SendKeys.Send("{TAB}")
    '    SendKeys.Send("{UP}")
    'End Sub

    'Private Overloads Sub OnKeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
    '    Try
    '        If CurrentCell IsNot Nothing Then
    '            Dim iColumn As Integer = CurrentCell.ColumnIndex
    '            Dim iRow As Integer = Math.Min(CurrentCell.RowIndex, RowCount() - 1)
    '            Select Case e.KeyData
    '                Case Keys.Enter
    '                    SendKeys.Send("{TAB}")
    '                    e.Handled = True
    '                Case Keys.Tab
    '                    If EditingMode Then
    '                        If iColumn = Columns.Count() - 1 OrElse iColumn = LastEditableColumn() OrElse iColumn = Columns.IndexOf(Columns("dgvInsertColumn")) Then
    '                            ' if on the last editable column, move to the first editable column on the next row
    '                            Dim r = Math.Min(iRow + 1, RowCount() - 1)
    '                            Dim vc = FirstVisibleColumn
    '                            Dim ec = FirstEditableColumn
    '                            Dim c = If(ec > 0, ec, vc)
    '                            CurrentCell = Me(c, r)
    '                            e.Handled = True
    '                        End If
    '                    End If

    '                Case Else
    '                    e.Handled = False
    '            End Select
    '        End If
    '    Catch ex As Exception
    '        Forms.MessageBox.Show(ex.Message)
    '    End Try
    '    'Return
    'End Sub

    'Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, keyData As System.Windows.Forms.Keys) As Boolean
    '    If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    '        Return True
    '    End If
    '    Return MyBase.ProcessCmdKey(msg, keyData)
    'End Function

    'Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
    '    Dim icolumn As Integer = CurrentCell.ColumnIndex
    '    Dim irow As Integer = CurrentCell.RowIndex
    '    If keyData = Keys.Enter Then
    '        If icolumn = Columns.Count - 1 Then
    '            CurrentCell = Me(FirstVisibleColumn, Math.Min(irow, RowCount() - 1))
    '        Else
    '            Dim selected As Boolean = False
    '            For i = icolumn + 1 To Columns.Count() - 1
    '                If Me(i, irow).Visible AndAlso Not (Me(i, irow).OwningColumn.Name = "dgvInsertColumn") Then
    '                    CurrentCell = Me(i, irow)
    '                    selected = True
    '                    Exit For
    '                End If
    '            Next
    '            If Not selected Then
    '                If irow + 1 <= Rows.Count - 1 Then
    '                    For i = 0 To Columns.Count - 1
    '                        If Me(i, irow + 1).Visible AndAlso Not (Me(i, irow + 1).OwningColumn.DataPropertyName.ToLower() = "sequence") Then
    '                            CurrentCell = Me(i, irow + 1)
    '                            Exit For
    '                        End If
    '                    Next
    '                End If
    '            End If
    '        End If
    '        Return True
    '    Else
    '        If keyData = Keys.Down And irow = RowCount() - 1 Then
    '            Try
    '                CurrentCell = Me(FirstVisibleColumn, Math.Min(irow, RowCount() - 1))
    '                If CurrentCell.OwningColumn.DataPropertyName.ToLower() = "sequence" Then
    '                    CurrentCell.Value = RowCount()
    '                End If
    '            Catch ex As Exception

    '            End Try

    '        Else
    '            Return MyBase.ProcessCmdKey(msg, keyData)
    '        End If
    '    End If
    '    Return Nothing
    'End Function

    'Protected Overrides Function ProcessDataGridViewKey(ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean
    '    ' Handle the ENTER key as if it were a tab key.
    '    If e.KeyCode = Keys.Enter Then
    '        'Try
    '        Return Me.ProcessTabKey(e.KeyData)
    ''        'Catch ex As Exception

    ''        'End Try

    ''    End If
    ''    'Try
    ''        Return MyBase.ProcessDataGridViewKey(e)
    ''    'Catch ex As Exception

    ''    'End Try

    ''End Function
    ''Private Sub DataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellEndEdit

    'Private Sub DataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellEndEdit
    '    If Me.CurrentCell.RowIndex = RowCount Then 'Or Me.CurrentCell.RowIndex = LastEditableColumn Then
    '        Me.Rows.Add()
    '    End If
    'End Sub

    'Private Sub DataGridView_BeginEdit(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs) Handles Me.CellBeginEdit
    '    If Me.CurrentCell.RowIndex = RowCount() - 1 Then
    '        If Me.AllowUserToAddRows Then
    '            AddNewRow()
    '        End If
    '    End If
    'End Sub

    'Public Property GridParentChanged As Boolean
    '    Set(value As Boolean)
    '        _GridChangedParent = value
    '        If value = True Then
    '            RaiseEvent GridChangedParent()
    '        End If
    '    End Set
    '    Get
    '        Return _GridChangedParent
    '    End Get
    'End Property

    '<Bindable(True)>
    '<Category("Actions")>
    '<Description("Clear the data on the Grid View")>
    '<Browsable(True)>
    'Public Custom Event ParentofGridChanged As EventHandler
    '    AddHandler(ByVal value As EventHandler)
    '        ' Add the delegate to the Component's EventHandlerList Collection
    '        Me.Events.AddHandler("ParentofGridChangedEvent", value)
    '    End AddHandler

    '    RemoveHandler(ByVal value As EventHandler)
    '        ' Remove the delegate from the Component's EventHandlerList Collection
    '        Me.Events.RemoveHandler("ParentofGridChangedEvent", value)
    '    End RemoveHandler

    '    RaiseEvent(ByVal sender As Object, ByVal e As System.EventArgs)
    '        ' Raise the event.
    '        CType(Me.Events("ParentofGridChangedEvent"), EventHandler).Invoke(sender, e)
    '    End RaiseEvent
    'End Event

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles Me.EditingControlShowing
        '    'declare variable(cb) as a combobox
        '    Dim cb As CaComboBox
        '    'e represent the editing control in the datagridview
        '    'the condition is, if the type of e is combobox then set your code for autocomplete
        '    If TypeOf e.Control Is CaComboBox Then
        '        cb = e.Control
        '        'set the dropdown style of a combobox
        '        cb.DropDownStyle = ComboBoxStyle.DropDown
        '        'set the property of a combobox to autocomplete mode.
        '        cb.AutoCompleteMode = AutoCompleteMode.Suggest
        '        cb.AutoCompleteSource = AutoCompleteSource.ListItems
        '    End If
        'End Sub
        If TypeOf e.Control Is CaComboBox Then
            'declare variable(cb) as a caCombobox
            Dim cb As CaComboBox
            cb = e.Control
            'set the dropdown style of a combobox
            cb.DropDownStyle = ComboBoxStyle.DropDown
            'set the property of a combobox to autocomplete mode.
            cb.AutoCompleteMode = AutoCompleteMode.Suggest
            'cb.AutoCompleteSource = AutoCompleteSource.ListItems
            'cb.OverrideDropDownStyleList = False
            'cb.IntegralHeight = True
            'cb.AutoSize = False
            'cb.DropDownStyle = ComboBoxStyle.Simple
            'cb.MaxDropDownItems = 1
            ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            'cb.DropDownHeight = Height
        ElseIf TypeOf e.Control Is CCustomDateTimePicker Then
            Dim cDtp As CCustomDateTimePicker
            cDtp = e.Control
            e.CellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            e.CellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
        End If
    End Sub

    ' sample cellvalidating event handler
    'Private Sub CDataGridView_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles Me.CellValidating
    '    If e.FormattedValue = "error" Then
    '        Me.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "Negative Values not allowed"
    '        e.Cancel = False
    '    End If
    'End Sub

    'Public Sub MakeViewable(ViewableControl As Boolean) Implements IEntryControl.MakeViewable
    '    ' not applicable
    'End Sub

    'Public Sub MakeSelectable(selectableControl As Boolean) Implements IEntryControl.MakeSelectable
    '    Enabled = selectableControl
    'End Sub
    'Function Clone(Of T As ICloneable)(ByVal listToClone As IList(Of T)) As IList(Of T)
    '    Return listToClone.[Select](Function(item) CType(item.Clone(), T)).ToList()
    'End Function

    'Private Function ParseDataSource() As Boolean
    '    If DataSource Is Nothing Then
    '        Return False
    '    End If

    '    If DataSource.[GetType]().Equals(GetType(BindingSource)) Then
    '        'AssignEvent()
    '        Dim myBindingSource = CType(DataSource, BindingSource)

    '    End If

    '    Return True
    'End Function

    Private Sub CDataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Me.CellEndEdit
        Dim nIndex = CurrentRow.Index
        If DataSource IsNot Nothing Then
            If DataSource.[GetType]() Is GetType(BindingSource) Then
                'AssignEvent()
                Dim myBindingSource = CType(DataSource, BindingSource)
                Dim nDataCount = DataSource().Count()
                If CurrentRow.Index = NewRowIndex Then
                    Try
                        myBindingSource.AddNew()
                        ' adding a new row to the bindingsource adds a new empty row at the end with null values
                        ' therefore there is a need to remove that row because it causes errors when moving to that empty row
                        myBindingSource.RemoveAt(myBindingSource.Count - 1)
                    Catch

                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub On_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs) Handles Me.CellPainting
        SuspendLayout()

        If (e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0) Then
            If TypeOf Me.Columns(e.ColumnIndex) Is CDgvCheckBoxColumn Then
                Dim value = DirectCast(e.FormattedValue, Nullable(Of Boolean))
                If Not EditingMode Then
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not (DataGridViewPaintParts.ContentForeground))
                    Dim state = IIf((value.HasValue And value.Value), VisualStyles.CheckBoxState.CheckedDisabled, VisualStyles.CheckBoxState.UncheckedDisabled)
                    Dim size = RadioButtonRenderer.GetGlyphSize(e.Graphics, state)
                    Dim location = New Point((e.CellBounds.Width - size.Width) / 2, (e.CellBounds.Height - size.Height) / 2)
                    location.Offset(e.CellBounds.Location)
                    CheckBoxRenderer.DrawCheckBox(e.Graphics, location, state)
                    e.Handled = True
                End If
            End If
        End If
        ResumeLayout()
    End Sub

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String = ""

    'Private Sub Dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles Me.CellFormatting
    '    If e.Value IsNot Nothing AndAlso TypeOf Columns(e.ColumnIndex).CellTemplate Is DataGridViewCheckBoxCell Then
    '        If Me(e.ColumnIndex, e.RowIndex).ReadOnly Then
    '            Me(e.ColumnIndex, e.RowIndex).Style.BackColor = If(CType(e.Value, Boolean), Color.Yellow, Columns(e.ColumnIndex).DefaultCellStyle.BackColor)
    '        Else
    '            Me(e.ColumnIndex, e.RowIndex).Style.BackColor = If(CType(e.Value, Boolean), Color.White, Columns(e.ColumnIndex).DefaultCellStyle.BackColor)
    '        End If
    '    End If
    'End Sub

    'Public Function GetControlDescription(Optional defaultDescription As String = Nothing) Implements IEntryControl.GetControlDescription
    '    Dim description As String
    '    If LinkedLabel Is Nothing OrElse LinkedLabel.Text Is Nothing OrElse LinkedLabel.Text = "" Then
    '        description = If(defaultDescription Is Nothing OrElse defaultDescription = "", Name, defaultDescription)
    '    Else
    '        description = LinkedLabel.Text
    '    End If
    '    Return description
    'End Function

    'Ends Edit Mode So CellValueChanged Event Can Fire
    Private Sub EndEditMode(sender As System.Object, e As EventArgs) Handles MyBase.CurrentCellDirtyStateChanged
        'if current cell of grid is dirty, commits edit
        If Me.IsCurrentCellDirty Then
            If TypeOf CurrentCell Is DataGridViewCheckBoxCell Then
                CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        End If
    End Sub

    Public Property IsDirty As Boolean = False
    Private _previousColumnSearch As Short
    Private _previousSelectedRow As Integer
    Private _previousTextSearch As String
    Private _previousSearchPlace As IFindableControl.SearchPlaceEnum
    Private _previousBegDateSearch As Date
    Private _previousEndDateSearch As Date
    Private _previousBegValueSearch As Decimal?
    Private _previousEndValueSearch As Decimal?
    Private _existingFind As Boolean

    'Executes when Cell Value on a DataGridView changes
    Private Sub DataGridCellValueChanged(sender As DataGridView, e As DataGridViewCellEventArgs) Handles MyBase.CellValueChanged
        'check that row isn't -1, i.e. creating datagrid header
        If e.RowIndex = -1 Then Exit Sub
        'mark as dirty
        If TypeOf CurrentCell Is DataGridViewCheckBoxCell Then
            Dim cCell As DataGridViewCheckBoxCell = CurrentCell
            cCell.EditingCellValueChanged = True
            IsDirty = True
        End If
    End Sub

    Public Function SearchGrid(value As Object, searchField As String, Optional returnField As String = Nothing) As Object
        Dim retValue As Object = Nothing
        If value IsNot DBNull.Value Or value IsNot Nothing Then
            ClearSelection()
            For Each row As DataGridViewRow In Rows
                Dim x As Object = row.Cells(searchField).Value
                If x Is Nothing Or x Is DBNull.Value Then
                    ' nothing to do
                Else
                    If row.Cells(searchField).Value = value Then
                        If returnField IsNot Nothing Then
                            retValue = row.Cells(returnField).Value
                        End If
                        row.Selected = True
                        FirstDisplayedScrollingRowIndex = row.Index
                        CurrentCell = Rows(row.Index).Cells(0)
                        Exit For
                    End If
                End If
            Next
        End If
        Return retValue
    End Function

    Public Sub MakeDataRetrieverCache(table As String, columnList As String, connectionName As String, Optional sortKey As String = Nothing)
        Dim retriever As New DataRetriever(table, columnList, connectionName, DataFilter, sortKey)
        For Each column As DataColumn In retriever.Columns
            Columns.Add(column.ColumnName, column.ColumnName)
        Next
        _memoryCache = New Cache(retriever, 100)
        RowCount = retriever.RowCount
        AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
        If DgSearch IsNot Nothing Then
            DgSearch.Clear()
        End If
        Dim i As Integer = 0
        For Each item As DataColumn In retriever.Columns
            Me.Columns(i).ValueType = item.DataType
            Dim searchItem As New DataGridSearch(Me, i)
            DgSearch.Add(searchItem)
            i += 1
        Next
    End Sub

    Private Sub dataGridView_CellValueNeeded(ByVal sender As Object, ByVal e As DataGridViewCellValueEventArgs) Handles MyBase.CellValueNeeded
        If Cached Then
            e.Value = _memoryCache.RetrieveElement(e.RowIndex, e.ColumnIndex)
        End If
    End Sub

    Private Sub DataGridView_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        Dim hitTestInfo As DataGridView.HitTestInfo
        Dim continueSearch As Boolean = False
        Dim matchFound As Integer = -1
        If e.Button = MouseButtons.Right Then
            hitTestInfo = Me.HitTest(e.X, e.Y)

            If _existingFind Then
                If Messaging.Show(True, "AskContinueWithPreviousSearch",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Warning,
                                  MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    matchFound = ContinuePreviousSearch()
                    If matchFound >= 0 Then
                        continueSearch = True
                    Else
                        continueSearch = False
                    End If
                Else
                    continueSearch = False
                End If
            End If
            If Not continueSearch Then
                _existingFind = False
                _columnNo = hitTestInfo.ColumnIndex
                FindValue()
            End If
        End If
    End Sub


    Public Sub ValidateExpiryDate(ByRef e As DataGridViewCellValidatingEventArgs)
        Dim value As Date?
        'Validate the input using the editing format and the display format.
        e.Cancel = Not Date.TryParseExact(CStr(e.FormattedValue),
                                                      {"yyyyMM", "yyyy/MM", "yyyy-MM"},
                                                      Nothing,
                                                      DateTimeStyles.None,
                                                      value)
        If Not e.Cancel Then
            'Ensure data is displayed using the display format.
            EditingControl.Text = IIf(value Is Nothing, "", value.ToString("yyyy/MM"))
        Else
            Messaging.ShowPmMessage(True, "MsgInvalidDate", {"enteredDate", e.FormattedValue})
        End If
    End Sub

    'Private Property BegFindValue As Object
    'Private Property SearchPlace As String
    'Private Property IgnoreCase As Boolean

    Private Sub FindValue()
        Dim myForm = FindForm()
        Dim sw As Integer = 0
        Dim pnt As Point
        Dim dataTypeEnum As IFindableControl.DataTypeEnum

        'If TypeOf Columns(columnNo) Is IFindableControl Then
        ' Dim columnData As IFindableControl = Columns(columnNo)
        'columnData = Columns(columnNo)
        If _columnNo > 0 Then
            Dim columnDataType = Columns(_columnNo).ValueType
            _previousColumnSearch = _columnNo
            dataTypeEnum = GetObjectDataType(columnDataType)
            'columnData.FindDataType = dataTypeEnum

            'DgSearch(_columnNo).SearchMode = GetColumnSearchModeType(Columns(_columnNo))
            Dim searchForm As CDataGridFindForm
            searchForm = New CDataGridFindForm(Me, _columnNo)
            Dim screenRectangle As Rectangle
            Dim formLocation As Point
            searchForm.SetFieldDescription(Columns(_columnNo).HeaderText)
            screenRectangle = Screen.PrimaryScreen.WorkingArea
            searchForm.StartPosition = FormStartPosition.Manual
            pnt = myForm.PointToScreen(Location)
            If formLocation.Y + searchForm.Height > screenRectangle.Height Then
                formLocation.Y = pnt.Y - searchForm.Height + Height
            End If
            searchForm.Location = formLocation
            If searchForm.ShowDialog() = DialogResult.OK Then
                'Dim searchPlace As IFindableControl.SearchPlaceEnum
                'Dim ignoreCase As Boolean
                If Not _existingFind Then
                    _existingFind = True
                End If
                If dataTypeEnum = IFindableControl.SearchModeEnum.TextBox Then
                    DgSearch(_columnNo).BegFindValue = searchForm.txtBegValue.Text
                    'searchPlace = searchForm.SearchLocation
                    'ignoreCase = searchForm.chkIgnoreCase.Checked
                    If DgSearch(_columnNo).TextToSearch <> "" Then
                        SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        Try
                            ClearSelection()
                            For Each row As DataGridViewRow In Rows
                                If SearchPlace = IFindableControl.SearchPlaceEnum.AnywhereOnField Then
                                    ' search anywhere
                                    If IgnoreCase Then
                                        If row.Cells(_columnNo).Value IsNot Nothing AndAlso row.Cells(_columnNo).Value.ToString().ToLower().Contains(DgSearch(_columnNo).TextToSearch.ToLower()) Then
                                            row.Selected = True
                                            If sw = 0 Then
                                                'scroll and move to the first matching record
                                                FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
                                                sw = 1
                                                _previousSelectedRow = row.Index()
                                            End If
                                        End If
                                    Else
                                        If row.Cells(_columnNo).Value IsNot Nothing AndAlso row.Cells(_columnNo).Value.ToString().Contains(DgSearch(_columnNo).TextToSearch) Then
                                            row.Selected = True
                                            If sw = 0 Then
                                                'scroll and move to the first matching record
                                                FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
                                                sw = 1
                                                _previousSelectedRow = row.Index()
                                            End If
                                        End If
                                    End If
                                ElseIf SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue Then
                                    ' exact match
                                    If row.Cells(_columnNo).Value.ToString().Equals(DgSearch(_columnNo).TextToSearch) Then
                                        row.Selected = True
                                        If sw = 0 Then
                                            'scroll and move to the first matching record
                                            FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
                                            sw = 1
                                            _previousSelectedRow = row.Index()
                                        End If
                                    End If
                                Else
                                    ' start of text
                                    If IgnoreCase Then
                                        If row.Cells(_columnNo).Value.ToString().ToLower().StartsWith(DgSearch(_columnNo).TextToSearch.ToLower()) Then
                                            row.Selected = True
                                            If sw = 0 Then
                                                'scroll and move to the first matching record
                                                FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
                                                sw = 1
                                                _previousSelectedRow = row.Index()
                                            End If
                                        End If
                                    Else
                                        If row.Cells(_columnNo).Value.ToString().StartsWith(DgSearch(_columnNo).TextToSearch) Then
                                            row.Selected = True
                                            If sw = 0 Then
                                                'scroll and move to the first matching record
                                                FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
                                                sw = 1
                                                _previousSelectedRow = row.Index()
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            _previousTextSearch = DgSearch(_columnNo).TextToSearch
                            _previousSearchPlace = SearchPlace
                        Catch exc As Exception
                            MessageBox.Show(exc.Message)
                        End Try
                    End If
                End If
            End If
            searchForm.Dispose()
            If sw = 0 Then
                Messaging.Show(True, "MsgNoMatchingRecordFound")
                _existingFind = False
            End If
        End If
        '    ElseIf dataTypeEnum = IFindableControl.DataTypeEnum.Date Then
        '        Dim dBegDate As Date? = CallByName(columnData, "BegFindValue", CallType.Get)
        '        Dim dEndDate As Date? = CallByName(columnData, "EndFindValue", CallType.Get)
        '        Dim dBDate As Date
        '        Dim dEDate As Date

        '        If dBegDate Is Nothing Then
        '        Else
        '            If dEndDate Is Nothing Then
        '                dBDate = Convert.ToDateTime(dBegDate)
        '                dEDate = DateAndTime.DateAdd(DateInterval.Day, 1, dBDate)
        '                'searchString = fieldName & " >= '" & dBDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "' and " & fieldName & " < '" & dEDate.ToString("yyyMMdd", CultureInfo.InvariantCulture) & "'"
        '            Else
        '                dBDate = Convert.ToDateTime(dBegDate)
        '                dEDate = Convert.ToDateTime(dEndDate)
        '                'dEDate = DateAndTime.DateAdd(DateInterval.Day, 1, dEDate)
        '                'searchString = fieldName & " >= '" & dBDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "' and " & fieldName & " < '" & dEDate.ToString("yyyMMdd", CultureInfo.InvariantCulture) & "'"
        '            End If
        '        End If
        '        SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '        Try
        '            ClearSelection()
        '            For Each row As DataGridViewRow In Rows
        '                Dim colDate As Date = row.Cells(columnNo).Value
        '                If DateIsBetween(colDate, dBDate, dEDate) Then
        '                    'If DateIsBetween(colDate, dBegDate, dEndDate) Then
        '                    row.Selected = True
        '                    If sw = 0 Then
        '                        'scroll and move to the first matching record
        '                        FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
        '                        _previousSelectedRow = SelectedRows(0).Index
        '                        sw = 1
        '                    End If
        '                    'If colDate.ToString("yyyyMMdd") >= dBDate.ToString("yyyyMMdd") And colDate.ToString("yyyMMdd") < dEDate.ToString("yyyyMMdd") Then
        '                    'row.Selected = True
        '                    'If sw = 0 Then
        '                    '    'scroll and move to the first matching record
        '                    '    FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
        '                    '    _previousSelectedRow = SelectedRows(0).Index
        '                    '    sw = 1
        '                    'End If
        '                    'End If
        '                End If
        '            Next
        '            _previousBegDateSearch = dBDate
        '            _previousEndDateSearch = dEDate
        '        Catch exc As Exception
        '            MessageBox.Show(exc.Message)
        '        End Try
        '    ElseIf dataTypeEnum = IFindableControl.DataTypeEnum.Decimal Then
        '        Dim begValue = CallByName(columnData, "BegFindValue", CallType.Get)
        '        Dim endValue = CallByName(columnData, "EndFindValue", CallType.Get)
        '        Dim dBegValue As Decimal?
        '        Dim dEndValue As Decimal?
        '        If begValue Is Nothing Then
        '            dBegValue = Nothing
        '        Else
        '            dBegValue = Convert.ToDecimal(begValue)
        '        End If
        '        If endValue Is Nothing Then
        '            dEndValue = Nothing
        '        Else
        '            dEndValue = Convert.ToDecimal(endValue)
        '        End If
        '        SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '        Try
        '            ClearSelection()
        '            For Each row As DataGridViewRow In Rows
        '                Dim colValue As Decimal? = row.Cells(columnNo).Value
        '                If dBegValue Is Nothing AndAlso dEndValue Is Nothing Then
        '                    If colValue Is Nothing Then
        '                        row.Selected = True
        '                        If sw = 0 Then
        '                            'scroll and move to the first matching record
        '                            FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
        '                            sw = 1
        '                            _previousSelectedRow = row.Index()
        '                        End If
        '                    End If
        '                ElseIf dEndValue Is Nothing Then
        '                    If colValue >= dBegValue Then
        '                        row.Selected = True
        '                        If sw = 0 Then
        '                            'scroll and move to the first matching record
        '                            FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
        '                            _previousSelectedRow = row.Index()
        '                            sw = 1
        '                        End If
        '                    End If
        '                ElseIf dBegValue Is Nothing Then
        '                    If colValue <= dEndValue Then
        '                        row.Selected = True
        '                        If sw = 0 Then
        '                            'scroll and move to the first matching record
        '                            FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
        '                            _previousSelectedRow = row.Index()
        '                            sw = 1
        '                        End If
        '                    End If
        '                Else
        '                    If colValue >= dBegValue And colValue <= dEndValue Then
        '                        'If DateIsBetween(colDate, dBegValue, dEndValue) Then
        '                        row.Selected = True
        '                        If sw = 0 Then
        '                            'scroll and move to the first matching record
        '                            FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
        '                            _previousSelectedRow = row.Index()
        '                            sw = 1
        '                        End If
        '                    End If
        '                End If
        '            Next
        '            _previousBegValueSearch = dBegValue
        '            _previousEndValueSearch = dEndValue
        '        Catch exc As Exception
        '            MessageBox.Show(exc.Message)
        '        End Try
        '    ElseIf dataTypeEnum = IFindableControl.DataTypeEnum.Integer Then
        '        Dim begValue = CallByName(columnData, "BegFindValue", CallType.Get)
        '        Dim endValue = CallByName(columnData, "EndFindValue", CallType.Get)
        '        Dim dBegValue As Integer?
        '        Dim dEndValue As Integer?
        '        If begValue Is Nothing Then
        '            dBegValue = Nothing
        '        Else
        '            dBegValue = Convert.ToInt32(begValue)
        '        End If
        '        If endValue Is Nothing Then
        '            dEndValue = Nothing
        '        Else
        '            dEndValue = Convert.ToInt32(endValue)
        '        End If
        '        SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '        Try
        '            ClearSelection()
        '            For Each row As DataGridViewRow In Rows
        '                Dim colValue As Integer? = row.Cells(columnNo).Value
        '                If dBegValue Is Nothing AndAlso dEndValue Is Nothing Then
        '                    If colValue Is Nothing Then
        '                        row.Selected = True
        '                        If sw = 0 Then
        '                            'scroll and move to the first matching record
        '                            FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
        '                            sw = 1
        '                            _previousSelectedRow = row.Index()
        '                        End If
        '                    End If
        '                ElseIf dEndValue Is Nothing Then
        '                    If colValue >= dBegValue Then
        '                        row.Selected = True
        '                        If sw = 0 Then
        '                            'scroll and move to the first matching record
        '                            FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
        '                            _previousSelectedRow = row.Index()
        '                            sw = 1
        '                        End If
        '                    End If
        '                ElseIf dBegValue Is Nothing Then
        '                    If colValue <= dEndValue Then
        '                        row.Selected = True
        '                        If sw = 0 Then
        '                            'scroll and move to the first matching record
        '                            FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
        '                            _previousSelectedRow = row.Index()
        '                            sw = 1
        '                        End If
        '                    End If
        '                Else
        '                    If colValue >= dBegValue And colValue <= dEndValue Then
        '                        'If DateIsBetween(colDate, dBegValue, dEndValue) Then
        '                        row.Selected = True
        '                        If sw = 0 Then
        '                            'scroll and move to the first matching record
        '                            FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
        '                            _previousSelectedRow = row.Index()
        '                            sw = 1
        '                        End If
        '                    End If
        '                End If
        '            Next
        '            _previousBegValueSearch = dBegValue
        '            _previousEndValueSearch = dEndValue
        '        Catch exc As Exception
        '            MessageBox.Show(exc.Message)
        '        End Try
        '    ElseIf dataTypeEnum = IFindableControl.DataTypeEnum.Boolean Then
        '        Dim valueToSearch As Boolean = CallByName(columnData, "BegFindValue", CallType.Get)
        '        SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '        ClearSelection()
        '        For Each row As DataGridViewRow In Rows
        '            If row.Cells(columnNo).Value = valueToSearch Then
        '                row.Selected = True
        '                If sw = 0 Then
        '                    'scroll and move to the first matching record
        '                    FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
        '                    sw = 1
        '                    _previousSelectedRow = row.Index()
        '                End If
        '            End If
        '        Next
        '        _previousBegValueSearch = valueToSearch
        '    End If
        'End If
        'End If
    End Sub

    Private Function ContinuePreviousSearch() As Integer
        Dim matchSw As Integer = 0
        Dim myForm = FindForm()
        Dim columnNo = _previousColumnSearch
        Dim nMode As Int16
        Dim columnDataType = Columns(columnNo).ValueType
        If columnDataType = GetType(Date?) Or columnDataType = GetType(Date) Or columnDataType = GetType(DateTime) Then
            nMode = 2
        ElseIf columnDataType = GetType(String) Or columnDataType = GetType(Char) Then
            nMode = 0
        ElseIf columnDataType = GetType(Int16) Or columnDataType = GetType(Int32) Or columnDataType = GetType(Int64) Then
            nMode = 3
        ElseIf columnDataType = GetType(Decimal) Then
            nMode = 3
        ElseIf columnDataType = GetType(Boolean) Then
            nMode = 4
        End If
        If nMode = IFindableControl.SearchModeEnum.TextBox Then
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Try
                'ClearSelection()
                For Each row As DataGridViewRow In Rows
                    If _previousSearchPlace = IFindableControl.SearchPlaceEnum.AnywhereOnField Then
                        If row.Cells(columnNo).Value IsNot Nothing AndAlso row.Cells(columnNo).Value.ToString().Contains(_previousTextSearch) Then
                            row.Selected = True
                            If row.Index > _previousSelectedRow AndAlso Not Rows(row.Index).Displayed Then
                                FirstDisplayedScrollingRowIndex = row.Index
                                _previousSelectedRow = row.Index
                                matchSw = 1
                                Exit For
                            End If
                        End If
                    Else
                        If row.Cells(columnNo).Value IsNot Nothing AndAlso row.Cells(columnNo).Value.ToString().Equals(_previousTextSearch) Then
                            row.Selected = True
                            If Not Rows(row.Index).Displayed Then
                                FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
                                _previousSelectedRow = row.Index
                                matchSw = 1
                                Exit For
                            End If
                        End If
                    End If
                Next
            Catch exc As Exception
                MessageBox.Show(exc.Message)
            End Try
        ElseIf nMode = 2 Then
            Dim dBegDate As Date? = _previousBegDateSearch
            Dim dEndDate As Date? = _previousEndDateSearch
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Try
                ClearSelection()
                Dim firstRowMatchSw As Int16 = 0

                For Each row As DataGridViewRow In Rows
                    Dim colDate As Date = row.Cells(columnNo).Value
                    If DateIsBetween(colDate, dBegDate, dEndDate) Then
                        row.Selected = True
                        If firstRowMatchSw = 0 Then
                            FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
                            firstRowMatchSw = 1
                            _previousSelectedRow = row.Index
                        ElseIf row.Index > _previousSelectedRow And Not Rows(row.Index).Displayed Then
                            FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
                            _previousSelectedRow = row.Index
                        End If
                    End If
                Next
            Catch exc As Exception
                MessageBox.Show(exc.Message)
            End Try
        ElseIf nMode = 3 Then
            Dim dBegValue As Decimal? = _previousBegValueSearch
            Dim dEndValue As Decimal? = _previousEndValueSearch
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Try
                For Each row As DataGridViewRow In Rows
                    Dim colValue As Decimal = row.Cells(columnNo).Value
                    If colValue >= dBegValue AndAlso colValue <= dEndValue Then
                        row.Selected = True
                        If row.Index > _previousSelectedRow AndAlso Not Rows(row.Index).Displayed Then
                            FirstDisplayedScrollingRowIndex = row.Index
                            _previousSelectedRow = row.Index
                            matchSw = 1
                            Exit For
                        End If
                    End If
                Next
            Catch exc As Exception
                MessageBox.Show(exc.Message)
            End Try
        ElseIf nMode = 4 Then
            Dim dBegValue As Boolean = _previousBegValueSearch
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Try
                For Each row As DataGridViewRow In Rows
                    Dim colValue As Boolean = row.Cells(columnNo).Value
                    If colValue = dBegValue Then
                        row.Selected = True
                        If row.Index > _previousSelectedRow AndAlso Not Rows(row.Index).Displayed Then
                            FirstDisplayedScrollingRowIndex = row.Index
                            _previousSelectedRow = row.Index
                            matchSw = 1
                            Exit For
                        End If
                    End If
                Next
            Catch exc As Exception
                MessageBox.Show(exc.Message)
            End Try
        End If
        If matchSw = 0 Then
            If Messaging.Show(True, "AskLastRecordReachStartBeg",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                _previousSelectedRow = -1
                ContinuePreviousSearch()
            Else
                '' stay on the current record
            End If
        End If
        Return matchSw
    End Function

    Public Property DgSearch As New List(Of DataGridSearch)

    <[Serializable]>
    Public Class DataGridSearch
        Implements IFindableControl

        Public Sub New(dataGridView As CDataGridView, colNo As Integer)
            If TypeOf dataGridView.Columns(colNo).CellTemplate Is DataGridViewTextBoxCell Then
                SearchMode = IFindableControl.SearchModeEnum.TextBox
                'FindDataSource
            ElseIf TypeOf dataGridView.Columns(colNo).CellTemplate Is DataGridViewComboBoxCell Then
                SearchMode = IFindableControl.SearchModeEnum.ComboBox
            ElseIf TypeOf dataGridView.Columns(colNo).CellTemplate Is DataGridViewCheckBoxCell Then
                SearchMode = IFindableControl.SearchModeEnum.CheckBox
            Else
                SearchMode = IFindableControl.SearchModeEnum.Date
            End If

        End Sub

        Public Property FindDataType As IFindableControl.DataTypeEnum Implements IFindableControl.FindDataType
        Public Property FindEnabled As Boolean Implements IFindableControl.FindEnabled
        Public Property FieldName As String Implements IFindableControl.FieldName
        Public Property FieldDescription As String Implements IFindableControl.FieldDescription
        Public ReadOnly Property FindDataSource As Object Implements IFindableControl.FindDataSource
        Public ReadOnly Property FindDisplayMember As String Implements IFindableControl.FindDisplayMember
        Public ReadOnly Property SearchMode As IFindableControl.SearchModeEnum Implements IFindableControl.SearchMode
        Public ReadOnly Property FindValueMember As String Implements IFindableControl.FindValueMember
        Public Property BegFindValue As Object Implements IFindableControl.BegFindValue
        Public Property EndFindValue As Object Implements IFindableControl.EndFindValue
        Public Property SearchPlace As IFindableControl.SearchPlaceEnum Implements IFindableControl.SearchPlace
        Public Property IgnoreCase As Boolean Implements IFindableControl.IgnoreCase
        Public Property TextToSearch As String

    End Class

End Class

'Public Class DataRetriever
'    Implements IDataPageRetriever

'    Private ReadOnly _tableName As String
'    'Private ReadOnly _command As SqlCommand
'    Private ReadOnly _columnList As String
'    'Private ReadOnly _db

'    Public Sub New(tableName As String)
'        _tableName = tableName
'    End Sub

'    Public Sub New(tableName As String, Optional pColumnList As String = Nothing, Optional connectionName As String = Nothing)
'        _db = New Db(connectionName)
'        Dim connection As New SqlConnection(_db.GetConnectionString())
'        connection.Open()
'        _command = connection.CreateCommand()
'        Me._tableName = tableName
'        _columnList = pColumnList
'    End Sub

'    Private rowCountValue As Integer = -1

'    Public ReadOnly Property RowCount() As Integer
'        Get
'            ' Return the existing value if it has already been determined.
'            If Not rowCountValue = -1 Then
'                Return rowCountValue
'            End If

'            ' Retrieve the row count from the database.
'            _command.CommandText = "SELECT COUNT(*) FROM " & _tableName
'            rowCountValue = CInt(_command.ExecuteScalar())
'            Return rowCountValue
'        End Get
'    End Property

'    Private columnsValue As DataColumnCollection

'    Public ReadOnly Property Columns() As DataColumnCollection
'        Get
'            ' Return the existing value if it has already been determined.
'            If columnsValue IsNot Nothing Then
'                Return columnsValue
'            End If

'            ' Retrieve the column information from the database.
'            ' "Primary_Key,Item_Code,GTin,ItemNameEnglish,Price_Cash,Pack1,Pack2,Pack3"
'            _command.CommandText = "SELECT " & _columnList & " FROM " & _tableName
'            Dim adapter As New SqlDataAdapter()
'            adapter.SelectCommand = _command
'            Dim table As New DataTable()
'            table.Locale = System.Globalization.CultureInfo.InvariantCulture
'            adapter.FillSchema(table, SchemaType.Source)
'            columnsValue = table.Columns
'            Return columnsValue
'        End Get
'    End Property

'    Private commaSeparatedListOfColumnNamesValue As String = _columnList

'    Private ReadOnly Property CommaSeparatedListOfColumnNames() As String
'        Get
'            ' Return the existing value if it has already been determined.
'            If commaSeparatedListOfColumnNamesValue IsNot Nothing Then
'                Return commaSeparatedListOfColumnNamesValue
'            End If

'            ' Store a list of column names for use in the
'            ' SupplyPageOfData method.
'            Dim commaSeparatedColumnNames As New System.Text.StringBuilder()
'            Dim firstColumn As Boolean = True
'            For Each column As DataColumn In Columns
'                If Not firstColumn Then
'                    commaSeparatedColumnNames.Append(", ")
'                End If
'                If column.ColumnName.Contains(" ") Then
'                    commaSeparatedColumnNames.Append("[" & column.ColumnName & "]")
'                Else
'                    commaSeparatedColumnNames.Append(column.ColumnName)
'                End If

'                firstColumn = False
'            Next

'            commaSeparatedListOfColumnNamesValue =
'                commaSeparatedColumnNames.ToString()
'            Return commaSeparatedListOfColumnNamesValue
'        End Get
'    End Property

'    ' Declare variables to be reused by the SupplyPageOfData method.
'    Private columnToSortBy As String

'    Private adapter As New SqlDataAdapter()

'    Public Function SupplyPageOfData(ByVal lowerPageBoundary As Integer, ByVal rowsPerPage As Integer) As DataTable Implements IDataPageRetriever.SupplyPageOfData

'        ' Store the name of the ID column. This column must contain unique
'        ' values so the SQL below will work properly.
'        If columnToSortBy Is Nothing Then
'            columnToSortBy = Me.Columns(0).ColumnName
'        End If

'        'If Not Me.Columns(columnToSortBy).Unique Then
'        '    Throw New InvalidOperationException(String.Format(
'        '        "Column {0} must contain unique values.", columnToSortBy))
'        'End If

'        ' Retrieve the specified number of rows from the database, starting
'        ' with the row specified by the lowerPageBoundary parameter.
'        _command.CommandText = "Select Top " & rowsPerPage & " " &
'            CommaSeparatedListOfColumnNames & " From " & _tableName &
'            " WHERE [" & columnToSortBy & "] NOT IN (SELECT TOP " &
'            lowerPageBoundary & " [" & columnToSortBy & "] From " &
'            _tableName & " Order By [" & columnToSortBy &
'            "]) Order By [" & columnToSortBy & "]"
'        adapter.SelectCommand = _command

'        Dim table As New DataTable()
'        table.Locale = System.Globalization.CultureInfo.InvariantCulture
'        adapter.Fill(table)
'        Return table

'    End Function

'End Class
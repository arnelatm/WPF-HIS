Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.GlobalResources
Imports AATM.Libraries.MessagingLibrary

Public Class CDataGridView
    Inherits DataGridView
    Implements IEntryControl, IFindableControl

    Private _dgvInsertColumnIndex As Integer = -1
    Private _editingMode As Boolean
    Private _translatable As Boolean = True
    Private _firstEditableColumn As Integer = -1
    Private _firstVisibleColumn As Integer = -1
    Private _insertColumnAdded As Boolean = False
    Private _lastEditableColumn As Integer = -1
    Private _origEditMode As DataGridViewEditMode

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
            If value Then
                If ShowInsertColumnWhenEditing Then
                    AddInsertColumn()
                End If
            Else
                RemoveInsertColumn()
            End If
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

    Private Sub DataGridView_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Me.CellEnter
        If CurrentCell IsNot Nothing AndAlso TypeOf (CurrentCell) Is CDgvDtpCell Then
            EditMode = DataGridViewEditMode.EditOnEnter
        End If
    End Sub

    Private Sub dataGridView1_CellLeave(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Me.CellLeave
        If CurrentCell IsNot Nothing AndAlso TypeOf CurrentCell Is CDgvDtpCell Then
            EditMode = _origEditMode
        End If
    End Sub

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

    <Bindable(True)>
    <Category("Custom")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that insert column is visible when editing.")>
    <Browsable(True)>
    Public Property ShowInsertColumnWhenEditing As Boolean = True

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

    Public Sub AddInsertColumn()
        If Not DisplayOnly AndAlso Not Columns.Contains("dgvInsertColumn") Then
            With Columns
                Dim dgvInsColumn As New DataGridViewImageColumn
                .Insert(.Count, dgvInsColumn)
                dgvInsColumn.Image = Images.InsertRowImage
                dgvInsColumn.Width = 30
                dgvInsColumn.Name = "dgvInsertColumn"
                dgvInsColumn.HeaderText = Messaging.TranslateCaption("Ins.")
                _insertColumnAdded = True
                _dgvInsertColumnIndex = dgvInsColumn.Index
            End With
        End If
    End Sub

    Public Sub RemoveInsertColumn()
        With Columns
            If _insertColumnAdded Then
                .Remove("dgvInsertColumn")
                _insertColumnAdded = False
            End If
        End With
    End Sub

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
            'Dim currentColumnIndex As Int16
            'currentColumnIndex = CurrentCell.ColumnIndex()
            'If currentColumnIndex = LastEditableColumn And currentColumnIndex < ColumnCount() Then
            '    If CurrentCell.RowIndex() + 1 < RowCount() Then
            '        CurrentCell = Me(FirstEditableColumn, CurrentCellAddress.Y + 1)
            '        Return True
            '    End If
            'End If
            'Return Me.ProcessTabKey(e.KeyData)
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

    Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles MyBase.CellClick
        Try
            If EditingMode And CurrentCell IsNot Nothing Then
                With CurrentCell
                    Select Case .OwningColumn.Name.ToLower()
                        Case $"dgvinsertcolumn"
                            'If (CurrentRow.Index() <> NewRowIndex()) Then
                            'If Ea IsNot Nothing Then
                            '    Ea.PublishEvent(New InsertDgvLine(CurrentRow.Index(), Name))
                            'End If
                            If .RowIndex() = NewRowIndex() Then
                                Beep()
                            ElseIf .RowIndex() > 0 Or (.RowIndex() = 0 And FirstRowInsertionEnabled) Then
                                Dim myBindingSource = CType(DataSource, BindingSource)
                                Dim dataList = myBindingSource.AddNew()
                                myBindingSource.RemoveAt(myBindingSource.Count() - 1)
                                myBindingSource.Position = .RowIndex
                                myBindingSource.Insert(.RowIndex(), dataList)
                                ReSequenceDgvAfterInsert()
                                CurrentCell = Me(FirstEditableColumn, If(CurrentRow.Index() > 0, CurrentRow.Index() - 1, 0))
                            Else
                                Messaging.Show(True, "MsgFirstRowInsertionNotAllowed")
                            End If
                            'End If

                    End Select
                End With
            End If
        Catch ex As Exception
            Windows.MessageBox.Show("error")
        End Try
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
                If Columns(i).Name = "dgvInsertColumn" Then
                    'nLastEditableColumn = nLastEditableColumn - 1
                ElseIf Columns(i).Name = SequenceColumn Then
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
                If Columns(i).Name = "dgvInsertColumn" Then
                    'nLastEditableColumn = nLastEditableColumn - 1
                Else
                    If (Not Columns(i).Visible) Or Columns(i).ReadOnly Then
                        ' ignore
                    Else
                        _lastEditableColumn = i
                        Exit For
                    End If
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
        If value IsNot DBNull.Value Or value IsNot Nothing Or value <> "" Then
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

End Class
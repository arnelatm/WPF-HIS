Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.GlobalResources
Imports AATM.Libraries.MessagingLibrary

Public Class CDataGridView
    Inherits DataGridView
    Implements IEntryControl

    Private _dgvInsertColumnIndex As Integer = -1
    Private _editingMode As Boolean
    Private _firstEditableColumn As Integer = -1
    Private _firstVisibleColumn As Integer = -1
    Private _insertColumnAdded As Boolean = False
    Private _lastEditableColumn As Integer = -1

    Public Sub New()
        MyBase.New()
        DoubleBuffered = True
        Enabled = True
        EditMode = DataGridViewEditMode.EditOnKeystroke
        BackColor = Drawing.SystemColors.ControlLight
        DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
        DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
        AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite
        ShowEditingIcon = True
        ShowCellErrors = True
        ShowRowErrors = True
    End Sub

    Public Event ChangesMade As EventHandler

    Public Event DeletingRow(ByVal cancel As Boolean)

    Public Property DgvFooter As DgvFooter

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
    Public Property DisplayOnly As Boolean = False

    Public Property Ea As EventAggregator

    Private Sub DataGridView_DataSourceChanged(sender As Object, e As EventArgs) Handles Me.DataSourceChanged
        If Me.Columns(SequenceColumn) IsNot Nothing Then
            CallByName(Columns(SequenceColumn), "DisplayOnly", CallType.Set, True)
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
                Me.ReadOnly = True
            Else
                DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                Me.ReadOnly = False
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

    'Private Sub DataGridView_CellEnter(ByVal sender As Object,
    '                                    ByVal e As DataGridViewCellEventArgs) _
    '    Handles Me.CellEnter
    '    If Columns(SequenceColumn) IsNot Nothing Then
    '        If CurrentCell.ColumnIndex() = Columns(SequenceColumn).Index() Then
    '            SendKeys.Send("{TAB}")
    '        End If
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

    <Bindable(True)>
    <Category("Custom")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that insert column is visible when editing.")>
    <Browsable(True)>
    Public Property ShowInsertColumnWhenEditing As Boolean = True

    Public ReadOnly Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return True
        End Get
    End Property

    Public Sub AddInsertColumn()
        If Not DisplayOnly AndAlso Not Me.Columns.Contains("dgvInsertColumn") Then
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
                If CallByName(myBindingSource.Current, SequenceFieldName, CallType.Get) IsNot Nothing Then
                    For Each record In myBindingSource
                        Dim sequence = CallByName(record, SequenceFieldName, CallType.Get)
                        If sequence > i + 1 Then
                            CallByName(record, SequenceFieldName, CallType.Set, sequence - 1)
                        End If
                    Next
                End If
            Catch
                ' missing member
            End Try
        End If

    End Sub

    Public Sub ReSequenceDgvAfterInsert()
        Dim i = CurrentCell.RowIndex()
        Dim myBindingSource = CType(DataSource, BindingSource)
        Try
            If CallByName(myBindingSource.Current, SequenceFieldName, CallType.Get) IsNot Nothing Then
                For Each o In myBindingSource
                    If o IsNot Nothing Then
                        Dim sequence = CallByName(o, SequenceFieldName, CallType.Get)
                        If sequence = 0 Then
                            CallByName(o, SequenceFieldName, CallType.Set, i)
                        ElseIf sequence >= i Then
                            CallByName(o, SequenceFieldName, CallType.Set, sequence + 1)
                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean ' Extract the key code from the key value.
        Dim key As Keys = keyData And Keys.KeyCode
        If key = Keys.Enter And CurrentCell IsNot Nothing Then
            Dim currentColumnIndex As Int16
            currentColumnIndex = CurrentCell.ColumnIndex()
            If currentColumnIndex = LastEditableColumn And currentColumnIndex < ColumnCount() Then
                If CurrentCell.RowIndex() + 1 < RowCount() Then
                    CurrentCell = Me(FirstEditableColumn, CurrentCellAddress.Y + 1)
                    Return True
                End If
            End If
            Me.ProcessTabKey(keyData)
            Return True
            'Dim currentColumnIndex As Int16
            'currentColumnIndex = CurrentCell.ColumnIndex()
            'If currentColumnIndex < LastEditableColumn Then
            '    ' Handle the ENTER key as if it were a tab ARROW key
            '    Return ProcessTabKey(keyData)
            'ElseIf currentColumnIndex = LastEditableColumn Then
            '    ' go to next row on the first editable column
            '    If CurrentCell.RowIndex() >= RowCount() Then
            '        CurrentCell = Me(FirstEditableColumn, RowCount() - 1)
            '    Else
            '        Return ProcessTabKey(keyData)
            '    End If
            '    Return True
            'Else
            '    Return MyBase.ProcessDialogKey(keyData)
            'End If
        Else
            Return MyBase.ProcessDialogKey(keyData)
        End If
    End Function

    Private Sub cDataGridView_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles Me.DefaultValuesNeeded
        If EditMode And (SequenceColumn IsNot Nothing AndAlso SequenceColumn <> "") Then
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
            If EditingMode Then
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

        Try
        Catch ex As Exception
            If (e.Context = DataGridViewDataErrorContexts.Formatting) OrElse (e.Context = DataGridViewDataErrorContexts.PreferredSize) OrElse (e.Context = DataGridViewDataErrorContexts.Display) OrElse (e.Context = DataGridViewDataErrorContexts.Display) Then
                Debugger.Break()
                ' ignore error
            Else
                Debugger.Break()
                Forms.MessageBox.Show("Error happened " & e.Context.ToString())
                If (e.Context = DataGridViewDataErrorContexts.Commit) Then
                    Debugger.Break()
                    Forms.MessageBox.Show("Commit error")
                End If
                If (e.Context = DataGridViewDataErrorContexts.CurrentCellChange) Then
                    Forms.MessageBox.Show("Cell change")
                End If
                If (e.Context = DataGridViewDataErrorContexts.Parsing) Then
                    Forms.MessageBox.Show("parsing error")
                End If
                If (e.Context = DataGridViewDataErrorContexts.LeaveControl) Then
                    Debugger.Break()
                    Forms.MessageBox.Show("leave control error")
                End If

                If (TypeOf (e.Exception) Is ConstraintException) Then
                    Debugger.Break()
                    Dim view As DataGridView = CType(sender, DataGridView)
                    view.Rows(e.RowIndex).ErrorText = "an error"
                    view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
                    e.ThrowException = False
                End If
            End If
        End Try
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
    Private Sub DataGridViewGroupAccesses_CurrentCellChanged(sender As Object, e As EventArgs) Handles MyBase.CurrentCellChanged
        If _dgvInsertColumnIndex <= 0 Then Exit Sub
        If (CurrentRow IsNot Nothing) AndAlso EditingMode AndAlso (_dgvInsertColumnIndex >= 1) Then
            CurrentRow.Cells(_dgvInsertColumnIndex).Value = Images.InsertRowImage
        End If
    End Sub

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
    '        Dim dgvControl As Libraries.CBaseControlsLibrary.CaDgvComboboxCell
    '        dgvControl = TryCast(cCurrentCell, Libraries.CBaseControlsLibrary.CaDgvComboboxCell)
    '        If dgvControl IsNot Nothing Then
    '            If dgvControl.CellEditingControl.SelectedItem IsNot Nothing Then
    '                Select Case field.ToLower()
    '                    Case $"code"
    '                        Return DirectCast(DirectCast(cCurrentCell, Libraries.CBaseControlsLibrary.CaDgvComboboxCell).CellEditingControl.SelectedItem, AATM.Libraries.ClassesLibrary.LookupData).Code
    '                    Case $"name"
    '                        Return DirectCast(DirectCast(cCurrentCell, Libraries.CBaseControlsLibrary.CaDgvComboboxCell).CellEditingControl.SelectedItem, AATM.Libraries.ClassesLibrary.LookupData).Name
    '                    Case $"idno"
    '                        Return DirectCast(DirectCast(cCurrentCell, Libraries.CBaseControlsLibrary.CaDgvComboboxCell).CellEditingControl.SelectedItem, AATM.Libraries.ClassesLibrary.LookupData).IdNo
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
            Dim dgvControl As Libraries.CBaseControlsLibrary.CaDgvComboboxCell
            dgvControl = TryCast(CurrentCell, Libraries.CBaseControlsLibrary.CaDgvComboboxCell)
            If dgvControl IsNot Nothing Then
                If dgvControl.CellEditingControl.SelectedItem IsNot Nothing Then
                    Select Case field.ToLower()
                        Case $"code"
                            Return DirectCast(DirectCast(CurrentCell, Libraries.CBaseControlsLibrary.CaDgvComboboxCell).CellEditingControl.SelectedItem, AATM.Libraries.ClassesLibrary.LookupData).Code
                        Case $"name"
                            Return DirectCast(DirectCast(CurrentCell, Libraries.CBaseControlsLibrary.CaDgvComboboxCell).CellEditingControl.SelectedItem, AATM.Libraries.ClassesLibrary.LookupData).Name
                        Case $"idno"
                            Return DirectCast(DirectCast(CurrentCell, Libraries.CBaseControlsLibrary.CaDgvComboboxCell).CellEditingControl.SelectedItem, AATM.Libraries.ClassesLibrary.LookupData).IdNo
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
    '        If GetPropertyValue(parentForm, "PresenterObj.EditMode") Or GetPropertyValue(parentForm, "PresenterObj.AddMode") Then
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
    Private Overloads Sub OnKeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If CurrentCell IsNot Nothing Then
                Dim iColumn As Integer = CurrentCell.ColumnIndex
                Dim iRow As Integer = Math.Min(CurrentCell.RowIndex, RowCount() - 1)
                Select Case e.KeyData
                    Case Keys.Enter
                        SendKeys.Send("{TAB}")
                        e.Handled = True
                    Case Keys.Tab
                        If EditingMode Then
                            If iColumn = Columns.Count() - 1 OrElse iColumn = LastEditableColumn() OrElse iColumn = Columns.IndexOf(Columns("dgvInsertColumn")) Then
                                ' if on the last editable column, move to the first editable column on the next row
                                Dim r = Math.Min(iRow + 1, RowCount() - 1)
                                Dim vc = FirstVisibleColumn
                                Dim ec = FirstEditableColumn
                                Dim c = If(ec > 0, ec, vc)
                                CurrentCell = Me(c, r)
                                e.Handled = True
                            End If
                        End If

                    Case Else
                        e.Handled = False
                End Select
            End If
        Catch ex As Exception
            Forms.MessageBox.Show(ex.Message)
        End Try
        'Return
    End Sub

    'Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
    '    Dim icolumn As Integer = CurrentCell.ColumnIndex + 1
    '    Dim irow As Integer = CurrentCell.RowIndex + 1
    '    If keyData = Keys.Enter Then

    '        If icolumn = Columns.Count Then
    '            CurrentCell = Me(FirstVisibleColumn, Math.Min(irow, RowCount() - 1))
    '        Else
    '            CurrentCell = Me(icolumn, irow - 1)
    '        End If

    '        Return True
    '    Else
    '        If keyData = Keys.Down And irow = RowCount() - 1 Then
    '            Try
    '                CurrentCell = Me(FirstVisibleColumn, Math.Min(irow, RowCount() - 1))
    '                if CurrentCell.OwningColumn.DataPropertyName.ToLower() = "sequence" Then
    '                    CurrentCell.Value = RowCount()
    '                End If
    '            Catch ex As Exception

    '            End Try

    '        Else
    '            Return MyBase.ProcessCmdKey(msg, keyData)
    '        End If
    '    End If
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

    'Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles Me.EditingControlShowing
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
        Dim nIndex = Me.CurrentRow.Index
        If DataSource IsNot Nothing Then
            If DataSource.[GetType]() Is GetType(BindingSource) Then
                'AssignEvent()
                Dim myBindingSource = CType(DataSource, BindingSource)
                If Me.CurrentRow.Index = Me.NewRowIndex Then
                    myBindingSource.AddNew()
                    ' adding a new row to the bindingsource adds a new empty row at the end with null values
                    ' therefore there is a need to remove that row because it causes errors when moving to that empty row
                    myBindingSource.RemoveAt(myBindingSource.Count - 1)
                End If
            End If
        End If

    End Sub

End Class
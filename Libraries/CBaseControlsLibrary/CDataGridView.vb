Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.GlobalResources
Imports AATM.PresentationLayer.Events

Public Class CDataGridView
    Inherits DataGridView
    Implements IEntryControl

    Private _editingMode As Boolean
    Private _firstEditableColumn As Integer = -1
    Private _firstVisibleColumn As Integer = -1
    Private _insertColumnAdded As Boolean = False
    Private _lastEditableColumn As Integer = -1
    Private _dgvInsertColumnIndex As Integer = -1

    Public Sub New()
        MyBase.New()
        DoubleBuffered = True
        Enabled = True
        EditMode = DataGridViewEditMode.EditOnKeystroke
        BackColor = Drawing.SystemColors.ControlLight
        DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
        DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
        AlternatingRowsDefaultCellStyle.BackColor = Color.FloralWhite
        Ea = New EventAggregator()
        'Ea.SubscribeEvent(Me)
    End Sub

    Public Event ChangesMade As EventHandler

    Public Event DeletingRow(ByVal cancel As Boolean)

    Public Property DataInGridChanged As Boolean = False

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is readonly.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean = False

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that Deletion of first row is allowed.")>
    <Browsable(True)>
    Public Property FirstRowDeletionEnabled As Boolean = True

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that Insertion on first row not allowed.")>
    <Browsable(True)>
    Public Property FirstRowInsertionEnabled As Boolean = True

    Public Property Ea As EventAggregator

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
        End Set
    End Property

    Public ReadOnly Property FirstEditableColumn As Integer
        Get
            Return GetFirstEditableColumn()
        End Get
    End Property

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
    <Category("Properties")>
    <DefaultValue(GetType(String))>
    <Description("Enter here the property name for sequence column")>
    <Browsable(True)>
    Public Property SequenceColumn As String = "dgvSequence"

    Public Property StartTrackingChanges As Boolean = False

    Public ReadOnly Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return True
        End Get
    End Property

    Public Sub AddInsertColumn()
        With Columns
            Dim parentForm = FindForm()
            Dim presenterObj = CallByName(parentForm, "PresenterObj", CallType.Get)
            Dim editing As Boolean = CallByName(presenterObj, "EditMode", CallType.Get)
            Dim adding As Boolean = CallByName(presenterObj, "AddMode", CallType.Get)
            If editing Or adding Then
                Dim dgvInsColumn As New DataGridViewImageColumn
                .Insert(.Count, dgvInsColumn)
                dgvInsColumn.Image = Images.InsertRowImage
                dgvInsColumn.Width = 30
                dgvInsColumn.Name = "dgvInsertColumn"
                dgvInsColumn.HeaderText = MessagingLibrary.Messaging.TranslateCaption("Ins.")
                _insertColumnAdded = True
                _dgvInsertColumnIndex = dgvInsColumn.Index
            Else
                _insertColumnAdded = False
            End If
        End With
    End Sub

    Public Sub RemoveInsertColumn()
        With Columns
            If _insertColumnAdded Then
                .Remove("dgvInsertColumn")
                _insertColumnAdded = False
            End If
        End With
    End Sub

    'Public Sub ReSequenceDgvAfterDelete(Of T)(ByRef dataItems As List(Of T), Optional sequenceFieldName As String = "Sequence")
    '    Dim i = CurrentCell.RowIndex()
    '    For Each value In dataItems
    '        Dim sequence = CallByName(value, sequenceFieldName, CallType.Get)
    '        If sequence > i + 1 Then
    '            CallByName(value, sequenceFieldName, CallType.Set, sequence - 1)
    '        End If
    '    Next
    'End Sub

    Public Sub ReSequenceDgvAfterDelete(Optional sequenceFieldName As String = "Sequence")
        Dim i = CurrentCell.RowIndex()
        Dim myBindingSource = CType(DataSource, BindingSource)
        For Each value In myBindingSource
            Dim sequence = CallByName(value, sequenceFieldName, CallType.Get)
            If sequence > i + 1 Then
                CallByName(value, sequenceFieldName, CallType.Set, sequence - 1)
            End If
        Next
    End Sub

    'Public Sub ReSequenceDgvAfterInsert(Of T)(ByRef dataItems As List(Of T), Optional sequenceFieldName As String = "Sequence")
    '    Dim i = CurrentCell.RowIndex()
    '    For Each value In dataItems
    '        If value IsNot Nothing Then
    '            Dim sequence = CallByName(value, sequenceFieldName, CallType.Get)
    '            If sequence = 0 Then
    '                CallByName(value, sequenceFieldName, CallType.Set, i)
    '            ElseIf sequence >= i Then
    '                CallByName(value, sequenceFieldName, CallType.Set, sequence + 1)
    '            End If
    '        End If
    '    Next
    'End Sub

    Public Sub ReSequenceDgvAfterInsert(Optional sequenceFieldName As String = "Sequence")
        Dim i = CurrentCell.RowIndex()
        Dim myBindingSource = CType(DataSource, BindingSource)
        For Each o In myBindingSource
            If o IsNot Nothing Then
                Dim sequence = CallByName(o, sequenceFieldName, CallType.Get)
                If sequence = 0 Then
                    CallByName(o, sequenceFieldName, CallType.Set, i)
                ElseIf sequence >= i Then
                    CallByName(o, sequenceFieldName, CallType.Set, sequence + 1)
                End If
            End If
        Next
    End Sub

    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean ' Extract the key code from the key value.
        Dim key As Keys = keyData And Keys.KeyCode
        If key = Keys.Enter Then
            Dim currrentColumnIndex As Int16
            currrentColumnIndex = CurrentCell.ColumnIndex()
            If currrentColumnIndex < LastEditableColumn Then
                ' Handle the ENTER key as if it were a tab ARROW key
                Return ProcessTabKey(keyData)
            ElseIf currrentColumnIndex = LastEditableColumn Then
                ' go to next row on the first editable column
                If CurrentCell.RowIndex() >= RowCount() Then
                    CurrentCell = Me(FirstEditableColumn, RowCount() - 1)
                Else
                    CurrentCell = Me(FirstEditableColumn, CurrentCell.RowIndex())
                End If

            End If
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Private Sub CDataGridView_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles Me.DefaultValuesNeeded
        If EditMode Then
            With e.Row
                .Cells(SequenceColumn).Value = RowCount()
            End With
        End If
    End Sub

    Private Sub CDataGridView_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles MyBase.UserDeletedRow
        DataInGridChanged = True
        ReSequenceDgvAfterDelete()
        RaiseEvent ChangesMade(Me, EventArgs.Empty)
    End Sub

    Private Sub CDataGridView_UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles Me.UserDeletingRow
        Dim myForm = FindForm()
        Dim presenterObj = CallByName(myForm, "PresenterObj", CallType.Get)
        Dim editing As Boolean = CallByName(presenterObj, "EditMode", CallType.Get)
        Dim adding As Boolean = CallByName(presenterObj, "AddMode", CallType.Get)
        If Not (editing Or adding) Then
            MessagingLibrary.Messaging.Show(True, "MsgRowDelNotAllowedInViewMode", "Row deletion not allowed while in view mode. Press edit button to enable deletion.", "Error")
            e.Cancel = True
        End If
    End Sub

    'Private Sub ReSequenceDgv(Of T)(ByRef ds As T)
    '    Dim i = Me.CurrentCell.RowIndex()
    '    For Each r IN ds
    '        If Item.Sequence = 0 Then
    '            Item.Sequence = i
    '        ElseIf Item.Sequence >= i Then
    '            Item.Sequence = Item.Sequence + 1
    '        End If
    '    Next
    'End Sub
    Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles MyBase.CellClick
        With CurrentCell
            Select Case .OwningColumn.Name.ToLower()
                Case $"dgvinsertcolumn"
                    If EditingMode Then
                        If (CurrentRow.Index() <> NewRowIndex()) Then
                            'If Ea IsNot Nothing Then
                            '    Ea.PublishEvent(New InsertDgvLine(CurrentRow.Index(), Name))
                            'End If
                            If .RowIndex() <> 0 And FirstRowInsertionEnabled Then
                                Dim myBindingSource = CType(DataSource, BindingSource)
                                Dim current = myBindingSource.Current
                                Dim dataList = current.BlankCopy()
                                myBindingSource.Insert(.RowIndex(), dataList)
                                ReSequenceDgvAfterInsert()
                                SendKeys.Send("{UP}")
                            Else
                                Messaging.Show(True, "MsgInvalidInsertOnFirstRow", "Sorry, insertion on first row not allowed for {transactionName}.",
                                "Invalid Insertion", {"transactionName", "A.P. Journal Entry"})
                            End If
                        Else
                            MessagingLibrary.Messaging.Show(True, "MsgInvalidInsertOnViewMode", "Row insertion not allowed while in view mode. Press edit button to enable insertion.",
                                       "Invalid Insertion")
                        End If
            End Select
        End With
    End Sub

    Private Sub DataGridView_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Me.CellValueChanged
        If StartTrackingChanges Then
            DataInGridChanged = True
            RaiseEvent ChangesMade(Me, EventArgs.Empty)
            CallByName(CurrentRow.Cells("dgvInsColumn"), "Image", CallType.Set, Images.InsertRowImage)
        Else
            DataInGridChanged = False
        End If
    End Sub

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

    '' Write the method to call the Event, and then use it as you want.
    'Protected Sub OnParentofGridChanged(ByVal e As EventArgs)
    '    Dim ParentofGridChangedHandler As EventHandler =
    '    CType(Me.Events("ParentofGridChangedEvent"), EventHandler)
    '    If (ParentofGridChangedHandler IsNot Nothing) Then
    '        ParentofGridChangedHandler.Invoke(Me, e)
    '    End If
    'End Sub
    Private Sub DataGridViewGroupAccesses_CurrentCellChanged(sender As Object, e As EventArgs) Handles MyBase.CurrentCellChanged
        If StartTrackingChanges Then
            DataInGridChanged = True
        Else
            DataInGridChanged = False
        End If
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
        Dim iColumn As Integer = CurrentCell.ColumnIndex
        Dim iRow As Integer = Math.Min(CurrentCell.RowIndex, RowCount() - 1)
        Try
            Select Case e.KeyData
                Case Keys.Enter
                    'If iColumn = Columns.Count() - 1 OrElse iColumn = LastEditableColumn() OrElse iColumn = Columns.IndexOf(Columns("dgvInsertColumn")) Then
                    '    Dim r = Math.Min(iRow + 1, RowCount() - 1)
                    '    Dim c = FirstVisibleColumn
                    '    CurrentCell = Me(c, r)
                    'Else
                    '    If iColumn = ColumnCount() Then
                    '        iColumn = FirstVisibleColumn
                    '    End If
                    '    iRow = Math.Min(iRow, RowCount() - 1)
                    '    CurrentCell = Me(iColumn, iRow)
                    'End If
                    SendKeys.Send("{TAB}")
                    e.Handled = True
                'Case Keys.Down
                '    If iRow >= RowCount() - 1 Then
                '        Dim newRow As Integer = iRow - 1
                '        Dim newColumn As Integer = FirstVisibleColumn
                '        newRow = Math.Min(newRow, RowCount() - 1)
                '        CurrentCell = Me(newColumn, newRow)
                '        e.Handled = True
                '    Else
                '        e.Handled = False
                '        'iRow = Math.Min(iRow + 1, RowCount() - 1)
                '        'If iRow = RowCount() - 1 And iColumn > 1 Then
                '        '    Try
                '        '        CurrentCell = Me(iColumn, iRow)
                '        '    Catch
                '        '        iRow = iRow - 1
                '        '        CurrentCell = Me(iColumn, iRow)
                '        '        Refresh()
                '        '    End Try
                '        'End If
                '    End If

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
                            'Else
                            '    iRow = Math.Min(iRow, RowCount() - 1)
                            '    CurrentCell = Me(iColumn, iRow)
                        End If
                        'If iRow = RowCount() - 1 And iColumn = ColumnCount - 1 Then
                        '    CurrentCell = Me(FirstVisibleColumn, Math.Min(iRow, RowCount() - 1))
                        '    e.Handled = True
                        'Else
                        '    e.Handled = False
                        'End If
                    End If

                Case Else
                    e.Handled = False
            End Select
        Catch ex As Exception
            Forms.MessageBox.Show(ex.Message)
        End Try
        Return
    End Sub

    'Private Sub DgvRowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles MyBase.RowsAdded
    '    If _dgvInsertColumnIndex <= 0 Then Exit Sub
    '    CType(sender, DataGridView).Rows(e.RowIndex).Cells(_dgvInsertColumnIndex).Value = Images.InsertRowImage
    'End Sub

    'Private Sub CDataGridView_UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles Me.UserDeletingRow
    '    'MyBase.UserDeletingRow()
    '    Dim cancel As Boolean
    '    RaiseEvent DeletingRow(cancel)
    '    If cancel Then
    '        e.Cancel = True
    '    Else
    '        e.Cancel = False
    '    End If
    'End Sub
    'Private Sub dataGridView1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
    '    e.SuppressKeyPress = True
    '    Dim iColumn As Integer = CurrentCell.ColumnIndex
    '    Dim iRow As Integer = CurrentCell.RowIndex

    '    If iColumn = Columncount - 1 Then

    '        If RowCount > (iRow + 1) Then
    '            CurrentCell = Me(FirstVisibleColumn, iRow + 1)
    '        Else
    '        End If
    '    Else
    '        CurrentCell = Me(iColumn + 1, iRow)
    '    End If
    'End Sub

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
    '        'Catch ex As Exception

    '        'End Try

    '    End If
    '    'Try
    '        Return MyBase.ProcessDataGridViewKey(e)
    '    'Catch ex As Exception

    '    'End Try

    'End Function
    ''Private Sub DataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellEndEdit
    'Private Sub DataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellEndEdit
    '    if Me.CurrentCell.RowIndex = RowCount Then
    '        SendKeys.Send("{home}")
    '        SendKeys.Send("{down}")
    '    else
    '        SendKeys.Send("{up}")
    '        SendKeys.Send("{right}")
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
    '<Category("Properties")>
    '<DefaultValue(GetType(Boolean))>
    '<Description("Set to True to specify that data in grid has changed.")>
    '<Browsable(True)>
    'Public Property DataInGridChanged() As Boolean
    '    Get
    '        Return _DataInGridChanged
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _DataInGridChanged = value
    '    End Set
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
    'Public Sub MakeEditable(editableControl As Boolean) Implements IEntryControl.MakeEditable
    '    Throw New NotImplementedException()
    'End Sub

    'Public Sub MakeVisible(visibleControl As Boolean) Implements IEntryControl.MakeVisible
    '    Throw New NotImplementedException()
    'End Sub

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

End Class
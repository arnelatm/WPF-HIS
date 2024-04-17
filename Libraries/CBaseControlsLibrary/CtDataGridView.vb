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

Public Class CtDataGridView
    Inherits DataGridView
    Implements IEntryControl, IFindableControl

    Private _editingMode As Boolean
    Private _translatable As Boolean = True
    Private _firstEditableColumn As Integer = -1
    Private _firstVisibleColumn As Integer = -1
    Private _insertColumnAdded As Boolean = False
    Private _lastEditableColumn As Integer = -1
    Private _searchable As Boolean = True
    Private _memoryCache As Cache
    Private ReadOnly _origEditMode As DataGridViewEditMode
    Private _findColumnNo As Integer

    Public Sub New()
        MyBase.New()
        DoubleBuffered = True
        Enabled = True
        EditMode = DataGridViewEditMode.EditOnKeystroke
        BackColor = Drawing.SystemColors.ControlLight
        DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
        DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
        AlternatingRowsDefaultCellStyle.BackColor = GlobalVariables.DefaultAlternatingBackGroundColor
        ShowEditingIcon = True
        ShowCellErrors = True
        ShowRowErrors = True
        _origEditMode = EditMode

    End Sub

    Public Property Cached As Boolean = False

    Public Property DataFilter As String = Nothing

    Public Property FindColumnNo As Int16
        Get
            Return _findColumnNo
        End Get
        Set(value As Int16)
            _findColumnNo = value
        End Set
    End Property

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
            UpdateDisplayOnlyControl()
            For Each col In Columns
                If TypeOf col Is IEntryControl Then
                    'If TypeOf col Is CDgvCheckBoxColumn And value Then
                    '    Debugger.Break()
                    'End If
                    If col.DisplayOnly Then
                        col.EditingMode = False
                    Else
                        col.EditingMode = value
                    End If
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

    Public Sub UpdateDisplayOnlyControl()
        If _editingMode And Not DisplayOnly Then
            DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
            Me.[ReadOnly] = False
        Else
            'Me.[ReadOnly] = False
            DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            Try
                Me.[ReadOnly] = True
            Catch ex As Exception

            End Try

        End If
    End Sub

    Public ReadOnly Property FirstEditableColumn As Integer
        Get
            Return GetFirstEditableColumn()
        End Get
    End Property

    <Bindable(True)>
    <Category("Custom")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this grid is searchable.")>
    <Browsable(True)>
    Public Property Searchable As Boolean
        Get
            Return _searchable
        End Get
        Set(value As Boolean)
            _searchable = value
        End Set
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

    Public Sub ReSequenceDgvAfterDelete()
        If CurrentCell IsNot Nothing Then
            Dim i = CurrentCell.RowIndex()
            Dim myBindingSource = CType(DataSource, BindingSource)
            Try
                If Invoker.GetProperty(myBindingSource.Current, SequenceFieldName) IsNot Nothing Then
                    For Each record In myBindingSource
                        Dim sequence = CallByName(record, SequenceFieldName, CallType.Get)
                        If sequence > i + 1 Then
                            CallByName(record, SequenceFieldName, CallType.Set, sequence - 1)
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
            If Invoker.GetProperty(myBindingSource.Current, SequenceFieldName) IsNot Nothing Then
                For Each o In myBindingSource
                    If o IsNot Nothing Then
                        Dim sequence = Invoker.GetProperty(o, SequenceFieldName)
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

    <DebuggerStepThrough>
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
        If Not IsCurrentCellDirty Then
            ' Handle the ENTER key as if it were a RIGHT ARROW key.
            If e.KeyCode = Keys.Enter Then
                Return MoveToNextCell(e.KeyData)
            ElseIf e.KeyCode = Keys.Insert Then
                If Me.CurrentRow.Selected Then
                    InsertRow(CurrentRow.Index)
                End If
            End If
        End If
        Return MyBase.ProcessDataGridViewKey(e)
    End Function

    Private Sub Me_CellValidated(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Me.CellValidated
        ' Clear any error messages that may have been set in cell validation.
        Me.Rows(e.RowIndex).ErrorText = Nothing

    End Sub

    Private Function MoveToNextCell(keyData As Keys) As Boolean
        If Not IsCurrentCellDirty() Then
            Dim currentColumnIndex As Int16
            currentColumnIndex = CurrentCell.ColumnIndex()
            If currentColumnIndex = LastEditableColumn And currentColumnIndex < ColumnCount() Then
                If CurrentCell.RowIndex() + 1 < RowCount() Then
                    ' hack need next line because currentcell not changing properly dont know why.
                    'ProcessTabKey(keyData)
                    'Select the last row.
                    Rows(RowCount() - 1).Selected = True
                    CurrentCell = Me(FirstEditableColumn, CurrentCell.RowIndex() + 1)
                    Return (keyData)
                End If
            End If
        End If
        Return Me.ProcessTabKey(keyData)
    End Function

    Private Sub ctDataGridView_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles Me.DefaultValuesNeeded
        If (SequenceColumn IsNot Nothing AndAlso SequenceColumn <> "") Then
            If Columns(SequenceColumn) IsNot Nothing Then
                Dim nRowColumn = Columns(SequenceColumn).Index()
                With e.Row
                    .Cells(nRowColumn).Value = RowCount()
                End With
            End If
        End If
    End Sub

    Private Sub CtDataGridView_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles MyBase.UserDeletedRow
        ReSequenceDgvAfterDelete()
        RaiseEvent ChangesMade(Me, EventArgs.Empty)
    End Sub

    Private Sub CtDataGridView_UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles Me.UserDeletingRow
        If Not EditingMode Then
            Messaging.Show(True, "MsgRowDelNotAllowedInViewMode")
            e.Cancel = True
        End If
    End Sub


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


    Private Sub DataGridView_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles Me.DataError

        'Try
        'Catch ex As Exception
        If (e.Context = DataGridViewDataErrorContexts.Formatting) OrElse (e.Context = DataGridViewDataErrorContexts.PreferredSize) OrElse (e.Context = DataGridViewDataErrorContexts.Display) OrElse (e.Context = DataGridViewDataErrorContexts.Display) Then
            'Debugger.Break()
            ' ignore error
        Else
            If e.Context.HasFlag(DataGridViewDataErrorContexts.Parsing) Then
                Dim editControl As Object = Me.EditingControl
                If TypeOf (editControl) Is CtDgvDtpEditingControl Then
                    Dim x As CtDgvDtpEditingControl = DirectCast(editControl, CtDgvDtpEditingControl)
                    x.InformUserOfInvalidDate()
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles Me.RowHeaderMouseClick
        SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
        Rows(e.RowIndex).Selected = True
    End Sub

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

    Public Function GetEditingValue(Optional field As String = "")
        If CurrentCell IsNot Nothing Then
            Dim dgvControl As Libraries.CBaseControlsLibrary.CDgvComboBoxCell
            dgvControl = TryCast(CurrentCell, Libraries.CBaseControlsLibrary.CDgvComboBoxCell)
            If dgvControl IsNot Nothing Then
                If dgvControl.CellEditingControl.SelectedItem IsNot Nothing Then
                    Select Case field.ToLower()
                        Case $"code"
                            Dim x = DirectCast(DirectCast(CurrentCell, Libraries.CBaseControlsLibrary.CDgvComboBoxCell).CellEditingControl.SelectedItem, DataRowView).Row("Code")
                            Return x
                        Case $"name"
                            Dim x = DirectCast(DirectCast(CurrentCell, Libraries.CBaseControlsLibrary.CDgvComboBoxCell).CellEditingControl.SelectedItem, DataRowView).Row("Name")
                            Return x
                        Case $"idno"
                            Dim x = DirectCast(DirectCast(CurrentCell, Libraries.CBaseControlsLibrary.CDgvComboBoxCell).CellEditingControl.SelectedItem, DataRowView).Row("IdNo")
                            Return x
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

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles MyBase.EditingControlShowing
        If TypeOf e.Control Is CtComboBoxEditingControl Then
            'Me.EditingMode = True
            Me.SuspendDrawingNew()
            'declare variable(cb) as a CtCombobox
            Dim cb As CtComboBoxEditingControl
            cb = e.Control
            'set the dropdown style of a combobox
            cb.DropDownStyle = ComboBoxStyle.DropDown
            'set the property of a combobox to autocomplete mode.
            cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            'cb.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            'cb.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            If CurrentCell IsNot Nothing Then
                cb.SuggestCharCount = DirectCast(CurrentCell.OwningColumn, AATM.Libraries.CBaseControlsLibrary.CDgvComboBoxColumn).SuggestCharCount
            End If
            Me.ResumeDrawingNew()
        ElseIf TypeOf e.Control Is CCustomDateTimePicker Then
            Dim cDtp As CCustomDateTimePicker
            cDtp = e.Control
            e.CellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            e.CellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            'ElseIf TypeOf e.Control Is CDgvCheckBoxEditingControl Then
            '    Debugger.Break()

        End If
    End Sub

    Private Sub CtDataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Me.CellEndEdit
        If CurrentRow IsNot Nothing Then
            Dim nIndex = CurrentRow.Index
            If DataSource IsNot Nothing Then
                If DataSource.[GetType]() Is GetType(BindingSource) Then
                    'AssignEvent()
                    Dim myBindingSource = CType(DataSource, BindingSource)
                    'Dim nDataCount = DataSource().Count()
                    'Dim editingControl = Me.GetEditingValue()
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

    Private Sub EndEditMode(sender As System.Object, e As EventArgs) Handles MyBase.CurrentCellDirtyStateChanged
        'If current Then cell Of grid Is dirty, commits edit
        If Me.IsCurrentCellDirty Then
            If TypeOf CurrentCell Is CDgvCheckboxCell Then
                Debugger.Break()
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
                _findColumnNo = hitTestInfo.ColumnIndex
                If _findColumnNo >= 0 Then
                    FindValue()
                End If
            End If
        End If
    End Sub

    Public Sub ValidateExpiryDate(ByRef e As DataGridViewCellValidatingEventArgs, Optional AllowBlanks As Boolean = False)
        'Validate the input using the editing format and the display format.
        If AllowBlanks AndAlso (e.FormattedValue.Trim() = "" OrElse e.FormattedValue = "    /  " OrElse e.FormattedValue Is Nothing) Then
            Me.CurrentCell.Value = Nothing
        Else
            Dim value As Date
            e.Cancel = Not Date.TryParseExact(CStr(e.FormattedValue),
                                                      {"yyyyMMdd", "yyyy/MM/dd", "yyyy-MM-dd", "yyyyMM", "yyyy/MM", "yyyy-MM"},
                                                      Nothing,
                                                      DateTimeStyles.None,
                                                      value)
            If Not e.Cancel Then
                'Ensure data is displayed using the display format.
                EditingControl.Text = value.ToString("yyyy/MM/dd")
                If value < Today() Then
                    If Messaging.Show(True, "AskIfUseExpiredDate", "Are you sure you want to use this expired date?", "Please Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        e.Cancel = True
                    End If
                End If
            Else
                If Me.CurrentCell.Value Is Nothing Or CurrentCell.Value = Date.MinValue Then
                    Messaging.Show(True, "MsgBlankExpNotAllowed")
                Else
                    Messaging.ShowPmMessage(True, "MsgInvalidDate", {"enteredDate", e.FormattedValue})
                End If
                'e.Cancel = True
            End If
        End If
    End Sub

    Private Sub FindValue()
        Dim myForm = FindForm()
        Dim sw As Integer = 0
        Dim pnt As Point
        Dim dataTypeEnum As IFindableControl.DataTypeEnum
        If _findColumnNo >= 0 Then
            Dim columnDataType = Columns(_findColumnNo).ValueType
            _previousColumnSearch = _findColumnNo
            dataTypeEnum = GetObjectDataType(columnDataType)
            Dim searchForm As CFindForm
            FindDataType = dataTypeEnum
            searchForm = New CFindForm(Me) ', _findColumnNo) 
            Dim screenRectangle As Rectangle
            Dim formLocation As Point
            searchForm.SetFieldDescription(Columns(_findColumnNo).HeaderText)
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
                If dataTypeEnum = IFindableControl.DataTypeEnum.Decimal Or dataTypeEnum = IFindableControl.DataTypeEnum.Integer Then
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    ClearSelection()
                    If BegFindValue = EndFindValue OrElse EndFindValue = "" Then
                        For Each row As DataGridViewRow In Rows
                            If row.Cells(_findColumnNo).Value = BegFindValue Then
                                row.Selected = True
                                If sw = 0 Then
                                    'scroll and move to the first matching record
                                    FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
                                    sw = 1
                                    _previousSelectedRow = row.Index()
                                End If
                            End If
                        Next
                    Else
                        For Each row As DataGridViewRow In Rows
                            If row.Cells(_findColumnNo).Value >= BegFindValue And row.Cells(_findColumnNo).Value <= EndFindValue Then
                                row.Selected = True
                                If sw = 0 Then
                                    'scroll and move to the first matching record
                                    FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
                                    sw = 1
                                    _previousSelectedRow = row.Index()
                                End If
                            End If
                        Next
                    End If
                ElseIf dataTypeEnum = IFindableControl.DataTypeEnum.String Then
                    Dim searchValue As String = BegFindValue
                    For Each row As DataGridViewRow In Rows
                        If SearchPlace = IFindableControl.SearchPlaceEnum.AnywhereOnField Then
                            ' search anywhere
                            If IgnoreCase Then
                                If row.Cells(_findColumnNo).Value IsNot Nothing AndAlso row.Cells(_findColumnNo).Value.ToString().ToLower().Contains(searchValue.ToLower()) Then
                                    row.Selected = True
                                    If sw = 0 Then
                                        'scroll and move to the first matching record
                                        FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
                                        sw = 1
                                        _previousSelectedRow = row.Index()
                                    End If
                                End If
                            Else
                                If row.Cells(_findColumnNo).Value IsNot Nothing AndAlso row.Cells(_findColumnNo).Value.ToString().Contains(searchValue) Then
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
                            If row.Cells(_findColumnNo).Value = Val(searchValue) Then
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
                                If row.Cells(_findColumnNo).Value.ToString().ToLower().StartsWith(searchValue.ToLower()) Then
                                    row.Selected = True
                                    If sw = 0 Then
                                        'scroll and move to the first matching record
                                        FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
                                        sw = 1
                                        _previousSelectedRow = row.Index()
                                    End If
                                End If
                            Else
                                If row.Cells(_findColumnNo).Value.ToString().StartsWith(searchValue) Then
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
                    _previousTextSearch = searchValue
                    _previousSearchPlace = SearchPlace
                ElseIf dataTypeEnum = IFindableControl.DataTypeEnum.Date Then
                    SearchPlace = IFindableControl.SearchPlaceEnum.ExactValue
                    If BegFindValue IsNot Nothing Then
                        SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        ClearSelection()
                        If EndFindValue Is Nothing Then
                            For Each row As DataGridViewRow In Rows
                                If row.Cells(_findColumnNo).Value = BegFindValue Then
                                    row.Selected = True
                                    If sw = 0 Then
                                        'scroll and move to the first matching record
                                        FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
                                        sw = 1
                                        _previousSelectedRow = row.Index()
                                    End If
                                End If
                            Next
                        Else
                            For Each row As DataGridViewRow In Rows
                                If row.Cells(_findColumnNo).Value >= BegFindValue And row.Cells(_findColumnNo).Value <= EndFindValue Then
                                    row.Selected = True
                                    If sw = 0 Then
                                        'scroll and move to the first matching record
                                        FirstDisplayedScrollingRowIndex = SelectedRows(0).Index
                                        sw = 1
                                        _previousSelectedRow = row.Index()
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If
                searchForm.Dispose()
            End If
            If sw = 0 Then
                Messaging.Show(True, "MsgNoMatchingRecordFound")
                _existingFind = False
            End If
        End If
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

    Public Property OldCellValue As Object

    Private Sub MyCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles MyBase.CellBeginEdit
        OldCellValue = Me.CurrentCell.Value
    End Sub

    Private Sub OnCtDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles MyBase.CellContentClick
        If CurrentCell IsNot Nothing AndAlso TypeOf CurrentCell Is IEntryControl Then
            If TypeOf CurrentCell Is CDgvCheckboxCell Then
                If e.ColumnIndex < 0 OrElse e.RowIndex < 0 Then Exit Sub
                CurrentCell.Value = Not CurrentCell.Value
                CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        End If
    End Sub

    'Sub dataGridView1_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.CurrentCellDirtyStateChanged
    '    If IsCurrentCellDirty Then
    '        CommitEdit(DataGridViewDataErrorContexts.Commit)
    '    End If
    'End Sub


    'Public Sub ResetDisplayOnly(lDisplayOnly As Boolean, control As Control)
    '    If control.GetType().GetProperty("DisplayOnly") IsNot Nothing Then
    '        If _editingMode Then

    '            If lDisplayOnly Then
    '                DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
    '                DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
    '                [ReadOnly] = True
    '            Else
    '                DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
    '                DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
    '                [ReadOnly] = False
    '            End If
    '        Else
    '            DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
    '            DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
    '            [ReadOnly] = True
    '        End If
    '    End If
    'End Sub


End Class

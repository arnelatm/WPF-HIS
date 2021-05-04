Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports CrystalDecisions.CrystalReports.Engine

Namespace PresentationLayer.Views.Forms

    Public Class AccountReconciliationEntry
        Implements IAccountReconciliationView
        Implements ISubscriber(Of EditModeChanged), ISubscriber(Of AddModeChanged)

        Public Report As New ReportDocument
        Private ReadOnly _nfi As NumberFormatInfo
        Private _accountReconciliations As New List(Of AccountReconciliationItemView)
        Private _balance As Decimal
        Private _existingFind As Boolean = False
        Private _previousSelectedRow As Int16
        Private _previousTextSearch As String
        Private _previousSearchPlace As IFindableControl.SearchPlaceEnum
        Private _previousBegDateSearch As Date?
        Private _previousEndDateSearch As Date?
        Private _previousBegValueSearch As Decimal?
        Private _previousEndValueSearch As Decimal?
        Private _previousColumnSearch As Int16
        Private _progressDisplayForm As Form1
        'Private _accounts As List(Of ClassesLibrary.LookupData)

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "AccountReconciliation"
            SortOrderKey = "IdNo"
            FirstControl = dtpReconciliationDate
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            PresenterObj = New AccountReconciliationPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
            PublishEvent(New ReconciliationRefreshRequestEvent(Me))

        End Sub

#Region "Fields"

        Public Property AccountIdNo As Int16? Implements IAccountReconciliationView.AccountIdNo
            Get
                Return cboAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Balance As Decimal Implements IAccountReconciliationView.Balance
            Get
                Return txtBalance.Text.ToDecimalNumber(_nfi)
            End Get
            Set
                txtBalance.Text = FormatMoney(Value)
                txtBalance2.Text = txtBalance.Text
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IAccountReconciliationView.DateCreated
            Get
                If String.IsNullOrEmpty(txtDateCreated.Text) Then
                    Return Now()
                End If
                Return Convert.ToDateTime(txtDateCreated.Text)
            End Get
            Set(value As DateTime?)
                If value Is Nothing Then
                    txtDateCreated.Text = Nothing
                Else
                    txtDateCreated.Text = String.Format(CultureInfo.CurrentCulture, "{0:g}", value)
                End If
            End Set
        End Property

        'Public Property AccountReconciliationItemsDataSource As List(Of AccountReconciliationModel)

        Public Property IdNo As Int32 Implements IAccountReconciliationView.IdNo
            Get
                Return TxtIdNo.Text.ToInt32Number()
            End Get
            Set
                TxtIdNo.Text = Value.ToString()
            End Set
        End Property

        Public Property AccountReconciliationItems As List(Of AccountReconciliationItemView) Implements IAccountReconciliationView.AccountReconciliationItems
            Get
                Return _accountReconciliations
            End Get
            Set
                _accountReconciliations = Value
                BindAccountReconciliation()
                'If Value.Any() Then
                '    dtpReconciliationDate.DisplayOnly = True
                '    cboAccountIdNo.DisplayOnly = True
                'End If
            End Set
        End Property

        'Public Property Accounts As List(Of ClassesLibrary.LookupData) Implements IAccountReconciliationView.Accounts
        '    Get
        '        Return _accounts
        '    End Get
        '    Set(value As List(Of ClassesLibrary.LookupData))
        '        _accounts = value
        '        cboAccountIdNo.DataSource = Nothing
        '        cboAccountIdNo.DataSource = value
        '    End Set
        'End Property

        Public Property TotalCreditsCleared As Decimal Implements IAccountReconciliationView.TotalCreditsCleared
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalCreditsCleared.Text), _nfi)
            End Get
            Set
                txtTotalCreditsCleared.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property TotalCreditsNotCleared As Decimal Implements IAccountReconciliationView.TotalCreditsNotCleared
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalCreditsNotCleared.Text), _nfi)
            End Get
            Set
                txtTotalCreditsNotCleared.Text = FormatMoney(Value)
                OutstandingCredits = FormatMoney(Value)
            End Set
        End Property

        Public Property TotalDebitsCleared As Decimal Implements IAccountReconciliationView.TotalDebitsCleared
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalDebitsCleared.Text), _nfi)
            End Get
            Set
                txtTotalDebitsCleared.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property TotalDebitsNotCleared As Decimal Implements IAccountReconciliationView.TotalDebitsNotCleared
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalDebitsNotCleared.Text), _nfi)
            End Get
            Set
                txtTotalDebitsNotCleared.Text = FormatMoney(Value)
                OutstandingDeposits = FormatMoney(Value)
            End Set
        End Property

        Public Property GlSystemBalance As Decimal Implements IAccountReconciliationView.GlSystemBalance
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtGlSystemBalance.Text), _nfi)
            End Get
            Set
                txtGlSystemBalance.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property Posted As Boolean Implements IAccountReconciliationView.Posted
            Get
                Return chkPosted.Checked
            End Get
            Set
                chkPosted.Checked = Value
            End Set
        End Property

        Public Property TotalQtyCreditsCleared As Integer Implements IAccountReconciliationView.TotalQtyCreditsCleared
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalQtyCreditsCleared.Text), _nfi)
            End Get
            Set
                txtTotalQtyCreditsCleared.Text = Value
            End Set
        End Property

        Public Property TotalQtyDebitsCleared As Integer Implements IAccountReconciliationView.TotalQtyDebitsCleared
            Get
                Return Convert.ToDecimal(NumParser(Of Integer)(txtTotalQtyDebitsCleared.Text), _nfi)
            End Get
            Set
                txtTotalQtyDebitsCleared.Text = Value
            End Set
        End Property

        Public Property TotalQtyCreditsNotCleared As Integer Implements IAccountReconciliationView.TotalQtyCreditsNotCleared
            Get
                Return Convert.ToDecimal(NumParser(Of Integer)(txtTotalQtyCreditsNotCleared.Text), _nfi)
            End Get
            Set
                txtTotalQtyCreditsNotCleared.Text = Value
            End Set
        End Property

        Public Property TotalQtyDebitsNotCleared As Integer Implements IAccountReconciliationView.TotalQtyDebitsNotCleared
            Get
                Return Convert.ToDecimal(NumParser(Of Integer)(txtTotalQtyDebitsNotCleared.Text), _nfi)
            End Get
            Set
                txtTotalQtyDebitsNotCleared.Text = Value
            End Set
        End Property

        Public Property ReconciliationDate As Date? Implements IAccountReconciliationView.ReconciliationDate
            Get
                Return dtpReconciliationDate.Value
            End Get
            Set
                If Value Is Nothing Then
                    dtpReconciliationDate.Value = Date.Now()
                ElseIf dtpReconciliationDate.Value Is Nothing Or dtpReconciliationDate.Value <> Value Then
                    dtpReconciliationDate.Value = Value
                End If
            End Set
        End Property

        Public Property UnreconciledDifference As Decimal Implements IAccountReconciliationView.UnreconciledDifference
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtUnreconciledDifference.Text), _nfi)
            End Get
            Set
                txtUnreconciledDifference.Text = Value
            End Set
        End Property

        Public Property OutstandingCredits As Decimal Implements IAccountReconciliationView.OutstandingCredits
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtOutstandingCredits.Text), _nfi)
            End Get
            Set
                txtOutstandingCredits.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property OutstandingDeposits As Decimal Implements IAccountReconciliationView.OutstandingDeposits
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtOutstandingDeposits.Text), _nfi)
            End Get
            Set
                txtOutstandingDeposits.Text = FormatMoney(Value)
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList("BA,CK,CS")
            'cboAccountIdNo.BeginUpdate()
            'cboAccountIdNo.DataSource = Accounts ' PresenterObj.GetAccountTypesList("BA,CK,CS")
            'cboAccountIdNo.EndUpdate()
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AccountIdNo", cboAccountIdNo},
                {"Balance", txtBalance},
                {"IdNo", TxtIdNo},
                {"ReconciliationDate", dtpReconciliationDate}
                }
        End Sub

        'Protected Overrides Sub UpdateViewDisplay(idNo As Int32)
        '    MyBase.RecordPositionChanged()
        '    UpdateTotals()
        'End Sub

        Private Sub BindAccountReconciliation()
            SuspendLayout()
            bsAccountReconciliationItems.DataSource = AccountReconciliationItems
            bsAccountReconciliationItems.AllowNew = True
            With DataGridViewReconciliationItems
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsAccountReconciliationItems
                .Refresh()
            End With
            With DataGridViewReconciliationItems.Columns
                dgvSequence.DisplayOnly = True
                dgvJournalCode.DisplayOnly = True
                dgvJournalIdNo.DisplayOnly = True
                dgvCredit.DisplayOnly = True
                dgvDebit.DisplayOnly = True
                dgvReferenceNo.DisplayOnly = True
                dgvTransactionDate.DisplayOnly = True
            End With
            ResumeLayout()
        End Sub

#Region "FindValues"

        Private Sub DataGridViewReconciliationItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewReconciliationItems.CellContentClick
            If DataGridViewReconciliationItems.CurrentCell IsNot Nothing And (PresenterObj.EditMode Or PresenterObj.AddMode) Then
                With DataGridViewReconciliationItems.CurrentCell
                    Select Case .OwningColumn.Name.ToLower()
                        Case $"dgvcleared"
                            Dim selectedRow = DataGridViewReconciliationItems.Rows(.RowIndex).DataBoundItem
                            PublishEvent(New ReconciliationClearEvent(selectedRow, False, .Value, bsAccountReconciliationItems))
                    End Select
                End With
            End If
        End Sub

        Private Sub MenuClicked()
            Dim myForm = FindForm()
            Dim pnt As Point
            Dim searchForm = New CFindForm(Me)
            Dim screenRectangle As Rectangle
            Dim formLocation As Point
            screenRectangle = Screen.PrimaryScreen.WorkingArea
            searchForm.StartPosition = FormStartPosition.Manual
            pnt = myForm.PointToScreen(Location)
            If formLocation.Y + searchForm.Height > screenRectangle.Height Then
                formLocation.Y = pnt.Y - searchForm.Height + Height
            End If
            searchForm.Location = formLocation
            searchForm.ShowDialog()
            Dim textToSearch As String = ""
            searchForm.Dispose()
            If textToSearch <> "" Then
                DataGridViewReconciliationItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Try
                    For Each row As DataGridViewRow In DataGridViewReconciliationItems.Rows
                        If row.Cells(3).Value.ToString().Equals(textToSearch) Then
                            row.Selected = True
                            Exit For
                        End If
                    Next
                Catch exc As Exception
                    MessageBox.Show(exc.Message)
                End Try
            End If
        End Sub

        Private Sub CatchClose(ByVal sender As Object, ByVal e As ComponentModel.CancelEventArgs)
            ' Insert code to deal with impending closure of this form.
        End Sub

        Public Sub FormOpened()
            AddHandler Closing, AddressOf CatchClose
        End Sub

        Private Sub txtBalance_TextChanged(sender As Object, e As EventArgs) Handles txtBalance.Validated, txtBalance.TextChanged
            txtBalance2.Text = txtBalance.Text
            PublishEvent(New EndingBankBalanceEntryChangedEvent(sender))
        End Sub

        Private Sub DataGridViewReconciliationItems_MouseUp(sender As Object, e As MouseEventArgs) Handles DataGridViewReconciliationItems.MouseUp
            Dim hitTestInfo As DataGridView.HitTestInfo
            Dim continueSearch As Boolean = False
            Dim matchFound As Integer = -1
            If e.Button = MouseButtons.Right Then
                hitTestInfo = DataGridViewReconciliationItems.HitTest(e.X, e.Y)
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
                    'If hitTestInfo.Type = DataGridViewHitTestType.ColumnHeader Then
                    _existingFind = False
                    FindValue(hitTestInfo.ColumnIndex)
                End If
                'If hitTestInfo.Type = DataGridViewHitTestType.ColumnHeader AndAlso hitTestInfo.ColumnIndex = DataGridViewReconciliationItems.Columns.IndexOf(dgvReferenceNo) Then contextMenuForReferenceNo.Show(DataGridViewReconciliationItems, New Point(e.X, e.Y))
                'If hitTestInfo.Type = DataGridViewHitTestType.Cell AndAlso hitTestInfo.ColumnIndex = DataGridViewReconciliationItems.Columns.IndexOf(dgvDocumentNumber) Then contextMenuForDocumentNo.Show(DataGridViewReconciliationItems, New Point(e.X, e.Y))
                'If hitTestInfo.Type = DataGridViewHitTestType.Cell AndAlso hitTestInfo.ColumnIndex = DataGridViewReconciliationItems.Columns.IndexOf(dgvDebit) Then FindValue(DataGridViewReconciliationItems.Columns.IndexOf(dgvDebit))
                'If hitTestInfo.Type = DataGridViewHitTestType.Cell AndAlso hitTestInfo.ColumnIndex = DataGridViewReconciliationItems.Columns.IndexOf(dgvCredit) Then contextMenuForCredit.Show(DataGridViewReconciliationItems, New Point(e.X, e.Y))
            End If
        End Sub

        Private Sub FindValue(ByRef columnNo As Int16)
            Dim myForm = FindForm()
            Dim sw As Integer = 0
            Dim pnt As Point
            Dim dataTypeEnum As IFindableControl.DataTypeEnum
            Dim columnData As IFindableControl = DataGridViewReconciliationItems.Columns(columnNo)
            Dim columnDataType = DataGridViewReconciliationItems.Columns(columnNo).ValueType
            _previousColumnSearch = columnNo
            dataTypeEnum = GetObjectDataType(columnDataType)
            columnData.FindDataType = dataTypeEnum
            Dim searchForm As CFindForm
            searchForm = New CFindForm(DataGridViewReconciliationItems.Columns(columnNo))
            Dim screenRectangle As Rectangle
            Dim formLocation As Point
            searchForm.SetFieldDescription(DataGridViewReconciliationItems.Columns(columnNo).HeaderText)
            screenRectangle = Screen.PrimaryScreen.WorkingArea
            searchForm.StartPosition = FormStartPosition.Manual
            pnt = myForm.PointToScreen(Location)
            If formLocation.Y + searchForm.Height > screenRectangle.Height Then
                formLocation.Y = pnt.Y - searchForm.Height + Height
            End If
            searchForm.Location = formLocation
            searchForm.ShowDialog()
            Dim textToSearch As String
            Dim searchPlace As IFindableControl.SearchPlaceEnum
            If Not _existingFind Then
                _existingFind = True
            End If
            If dataTypeEnum = IFindableControl.SearchModeEnum.TextBox Then
                textToSearch = CallByName(columnData, "BegFindValue", CallType.Get)
                searchPlace = CallByName(columnData, "SearchPlace", CallType.Get)
                If textToSearch <> "" Then
                    DataGridViewReconciliationItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    Try
                        DataGridViewReconciliationItems.ClearSelection()
                        For Each row As DataGridViewRow In DataGridViewReconciliationItems.Rows
                            If searchPlace = IFindableControl.SearchPlaceEnum.AnywhereOnField Then
                                ' search anywhere
                                If row.Cells(columnNo).Value IsNot Nothing AndAlso row.Cells(columnNo).Value.ToString().Contains(textToSearch) Then
                                    row.Selected = True
                                    If sw = 0 Then
                                        'scroll and move to the first matching record
                                        DataGridViewReconciliationItems.FirstDisplayedScrollingRowIndex = DataGridViewReconciliationItems.SelectedRows(0).Index
                                        sw = 1
                                        _previousSelectedRow = row.Index()
                                    End If
                                End If
                            ElseIf searchPlace = IFindableControl.SearchPlaceEnum.ExactValue Then
                                ' exact match
                                If row.Cells(columnNo).Value.ToString().Equals(textToSearch) Then
                                    row.Selected = True
                                    If sw = 0 Then
                                        'scroll and move to the first matching record
                                        DataGridViewReconciliationItems.FirstDisplayedScrollingRowIndex = DataGridViewReconciliationItems.SelectedRows(0).Index
                                        sw = 1
                                        _previousSelectedRow = row.Index()
                                    End If
                                End If
                            Else
                                ' start of text
                                If row.Cells(columnNo).Value.ToString().StartsWith(textToSearch) Then
                                    row.Selected = True
                                    If sw = 0 Then
                                        'scroll and move to the first matching record
                                        DataGridViewReconciliationItems.FirstDisplayedScrollingRowIndex = DataGridViewReconciliationItems.SelectedRows(0).Index
                                        sw = 1
                                        _previousSelectedRow = row.Index()
                                    End If
                                End If
                            End If
                        Next
                        _previousTextSearch = textToSearch
                        _previousSearchPlace = searchPlace
                    Catch exc As Exception
                        MessageBox.Show(exc.Message)
                    End Try
                End If
            ElseIf dataTypeEnum = IFindableControl.DataTypeEnum.Date Then
                Dim dBegDate As Date? = CallByName(columnData, "BegFindValue", CallType.Get)
                Dim dEndDate As Date? = CallByName(columnData, "EndFindValue", CallType.Get)
                Dim dBDate As Date
                Dim dEDate As Date

                If dBegDate Is Nothing Then
                Else
                    If dEndDate Is Nothing Then
                        dBDate = Convert.ToDateTime(dBegDate)
                        dEDate = DateAndTime.DateAdd(DateInterval.Day, 1, dBDate)
                        'searchString = fieldName & " >= '" & dBDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "' and " & fieldName & " < '" & dEDate.ToString("yyyMMdd", CultureInfo.InvariantCulture) & "'"
                    Else
                        dBDate = Convert.ToDateTime(dBegDate)
                        dEDate = Convert.ToDateTime(dEndDate)
                        'dEDate = DateAndTime.DateAdd(DateInterval.Day, 1, dEDate)
                        'searchString = fieldName & " >= '" & dBDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "' and " & fieldName & " < '" & dEDate.ToString("yyyMMdd", CultureInfo.InvariantCulture) & "'"
                    End If
                End If
                DataGridViewReconciliationItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Try
                    DataGridViewReconciliationItems.ClearSelection()
                    For Each row As DataGridViewRow In DataGridViewReconciliationItems.Rows
                        Dim colDate As Date = row.Cells(columnNo).Value
                        If DateIsBetween(colDate, dBDate, dEDate) Then
                            'If DateIsBetween(colDate, dBegDate, dEndDate) Then
                            row.Selected = True
                            If sw = 0 Then
                                'scroll and move to the first matching record
                                DataGridViewReconciliationItems.FirstDisplayedScrollingRowIndex = DataGridViewReconciliationItems.SelectedRows(0).Index
                                _previousSelectedRow = DataGridViewReconciliationItems.SelectedRows(0).Index
                                sw = 1
                            End If
                            'If colDate.ToString("yyyyMMdd") >= dBDate.ToString("yyyyMMdd") And colDate.ToString("yyyMMdd") < dEDate.ToString("yyyyMMdd") Then
                            'row.Selected = True
                            'If sw = 0 Then
                            '    'scroll and move to the first matching record
                            '    DataGridViewReconciliationItems.FirstDisplayedScrollingRowIndex = DataGridViewReconciliationItems.SelectedRows(0).Index
                            '    _previousSelectedRow = DataGridViewReconciliationItems.SelectedRows(0).Index
                            '    sw = 1
                            'End If
                            'End If
                        End If
                    Next
                    _previousBegDateSearch = dBDate
                    _previousEndDateSearch = dEDate
                Catch exc As Exception
                    MessageBox.Show(exc.Message)
                End Try
            ElseIf dataTypeEnum = IFindableControl.DataTypeEnum.Decimal Then
                Dim dBegValue As Decimal? = Convert.ToDecimal(CallByName(columnData, "BegFindValue", CallType.Get))
                Dim dEndValue As Decimal? = Convert.ToDecimal(CallByName(columnData, "EndFindValue", CallType.Get))
                Dim dBValue As Decimal
                Dim dEValue As Decimal

                If dBegValue Is Nothing Then
                Else
                    If dEndValue Is Nothing Then
                        dBValue = Convert.ToDecimal(dBegValue)
                        dEValue = Convert.ToDecimal(dBegValue)
                        'searchString = fieldName & " >= '" & dBValue.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "' and " & fieldName & " < '" & dEValue.ToString("yyyMMdd", CultureInfo.InvariantCulture) & "'"
                    Else
                        dBValue = Convert.ToDecimal(dBegValue)
                        dEValue = Convert.ToDecimal(dEndValue)
                        'dEValue = DateAndTime.DateAdd(DateInterval.Day, 1, dEValue)
                        'searchString = fieldName & " >= '" & dBValue.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "' and " & fieldName & " < '" & dEValue.ToString("yyyMMdd", CultureInfo.InvariantCulture) & "'"
                    End If
                End If
                DataGridViewReconciliationItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Try
                    DataGridViewReconciliationItems.ClearSelection()
                    For Each row As DataGridViewRow In DataGridViewReconciliationItems.Rows
                        Dim colValue As Decimal = row.Cells(columnNo).Value
                        If colValue >= dBValue And colValue <= dEValue Then
                            'If DateIsBetween(colDate, dBegValue, dEndValue) Then
                            row.Selected = True
                            If sw = 0 Then
                                'scroll and move to the first matching record
                                DataGridViewReconciliationItems.FirstDisplayedScrollingRowIndex = DataGridViewReconciliationItems.SelectedRows(0).Index
                                _previousSelectedRow = DataGridViewReconciliationItems.SelectedRows(0).Index
                                sw = 1
                            Else
                                row.Selected = True
                            End If
                            'If colDate.ToString("yyyyMMdd") >= dBValue.ToString("yyyyMMdd") And colDate.ToString("yyyMMdd") < dEValue.ToString("yyyyMMdd") Then
                            'row.Selected = True
                            'If sw = 0 Then
                            '    'scroll and move to the first matching record
                            '    DataGridViewReconciliationItems.FirstDisplayedScrollingRowIndex = DataGridViewReconciliationItems.SelectedRows(0).Index
                            '    _previousSelectedRow = DataGridViewReconciliationItems.SelectedRows(0).Index
                            '    sw = 1
                            'End If
                            'End If
                        End If
                    Next
                    _previousBegValueSearch = dBValue
                    _previousEndValueSearch = dEValue
                Catch exc As Exception
                    MessageBox.Show(exc.Message)
                End Try
            End If
            If sw = 0 Then
                Messaging.Show(True, "MsgNoMatchingRecordFound")
                _existingFind = False
            End If
            searchForm.Dispose()

        End Sub

        Private Function ContinuePreviousSearch() As Integer
            Dim matchSw As Integer = 0
            Dim myForm = FindForm()
            Dim columnNo = _previousColumnSearch
            Dim nMode As Int16
            Dim columnDataType = DataGridViewReconciliationItems.Columns(columnNo).ValueType
            If columnDataType = GetType(Date?) Or columnDataType = GetType(Date) Or columnDataType = GetType(DateTime) Then
                nMode = 2
            ElseIf columnDataType = GetType(String) Or columnDataType = GetType(Char) Then
                nMode = 0
            ElseIf columnDataType = GetType(Int16) Or columnDataType = GetType(Int32) Or columnDataType = GetType(Int64) Then
                nMode = 0
            ElseIf columnDataType = GetType(Decimal) Then
                nMode = 3
            End If
            If nMode = IFindableControl.SearchModeEnum.TextBox Then
                DataGridViewReconciliationItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Try
                    'DataGridViewReconciliationItems.ClearSelection()
                    For Each row As DataGridViewRow In DataGridViewReconciliationItems.Rows
                        If _previousSearchPlace = IFindableControl.SearchPlaceEnum.AnywhereOnField Then
                            If row.Cells(columnNo).Value IsNot Nothing AndAlso row.Cells(columnNo).Value.ToString().Contains(_previousTextSearch) Then
                                row.Selected = True
                                If row.Index > _previousSelectedRow AndAlso Not DataGridViewReconciliationItems.Rows(row.Index).Displayed Then
                                    DataGridViewReconciliationItems.FirstDisplayedScrollingRowIndex = row.Index
                                    _previousSelectedRow = row.Index
                                    matchSw = 1
                                    Exit For
                                End If
                            End If
                        Else
                            If row.Cells(columnNo).Value IsNot Nothing AndAlso row.Cells(columnNo).Value.ToString().Equals(_previousTextSearch) Then
                                row.Selected = True
                                If Not DataGridViewReconciliationItems.Rows(row.Index).Displayed Then
                                    DataGridViewReconciliationItems.FirstDisplayedScrollingRowIndex = DataGridViewReconciliationItems.SelectedRows(0).Index
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
                DataGridViewReconciliationItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Try
                    DataGridViewReconciliationItems.ClearSelection()
                    Dim firstRowMatchSw As Int16 = 0

                    For Each row As DataGridViewRow In DataGridViewReconciliationItems.Rows
                        Dim colDate As Date = row.Cells(columnNo).Value
                        If DateIsBetween(colDate, dBegDate, dEndDate) Then
                            row.Selected = True
                            If firstRowMatchSw = 0 Then
                                DataGridViewReconciliationItems.FirstDisplayedScrollingRowIndex = DataGridViewReconciliationItems.SelectedRows(0).Index
                                firstRowMatchSw = 1
                                _previousSelectedRow = row.Index
                            ElseIf row.Index > _previousSelectedRow And Not DataGridViewReconciliationItems.Rows(row.Index).Displayed Then
                                DataGridViewReconciliationItems.FirstDisplayedScrollingRowIndex = DataGridViewReconciliationItems.SelectedRows(0).Index
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
                DataGridViewReconciliationItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Try
                    'DataGridViewReconciliationItems.ClearSelection()
                    'Dim firstRowMatchSw As Int16 = 0

                    For Each row As DataGridViewRow In DataGridViewReconciliationItems.Rows
                        Dim colValue As Decimal = row.Cells(columnNo).Value
                        If colValue >= dBegValue And colValue <= dEndValue Then
                            'row.Selected = True

                            'If firstRowMatchSw = 0 Then
                            '    DataGridViewReconciliationItems.FirstDisplayedScrollingRowIndex = DataGridViewReconciliationItems.SelectedRows(0).Index
                            '    firstRowMatchSw = 1
                            '    _previousSelectedRow = row.Index
                            If row.Index > _previousSelectedRow And Not DataGridViewReconciliationItems.Rows(row.Index).Displayed Then
                                DataGridViewReconciliationItems.FirstDisplayedScrollingRowIndex = DataGridViewReconciliationItems.SelectedRows(0).Index
                                _previousSelectedRow = row.Index
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

        Private Function DateIsBetween(dateToCheck As Object, begDate As Object, endDate As Object)
            If Not (TypeOf dateToCheck Is Date Or TypeOf dateToCheck Is Date?) And (TypeOf begDate Is Date Or TypeOf begDate Is Date?) And (TypeOf endDate Is Date Or TypeOf endDate Is Date?) Then
                MessageBox.Show("One of the passed date is not a valid date type.")
                Debugger.Break()
                Return False
            End If
            If TypeOf dateToCheck Is Date And TypeOf begDate Is Date And TypeOf endDate Is Date Then
                Dim dC As Date = dateToCheck
                Dim dB As Date = begDate
                Dim dE As Date = endDate
                If dC.ToString("yyyyMMdd") >= dB.ToString("yyyyMMdd") And dC.ToString("yyyyMMdd") <= dE.ToString("yyyyMMdd") Then
                    Return True
                Else
                    Return False
                End If
            ElseIf TypeOf dateToCheck Is Date? And TypeOf begDate Is Date? And TypeOf endDate Is Date? Then
                If dateToCheck Is Nothing And begDate Is Nothing And endDate Is Nothing Then
                    Return True
                End If
                If dateToCheck Is Nothing Then
                    If begDate IsNot Nothing And endDate IsNot Nothing Then
                        Return False
                    Else
                        Return True
                    End If
                Else
                    If begDate Is Nothing Or endDate Is Nothing Then
                        Return True
                    Else
                        Dim dDateToCheck As Date = dateToCheck
                        Dim dEndDate As Date = endDate
                        Dim dBegDate As Date = begDate
                        If dDateToCheck.ToString("yyyyMMdd") >= dBegDate.ToString("yyyyMMdd") And dDateToCheck.ToString("yyyyMMdd") <= dEndDate.ToString("yyyyMMdd") Then
                            Return True
                        Else
                            Return False
                        End If
                    End If
                End If
            End If
            Return False
        End Function

#End Region

        Private Sub dtpReconciliationDate_Validated(sender As Object, e As EventArgs) Handles dtpReconciliationDate.Validated
            If Not btnEdit.Enabled And dtpReconciliationDate.DateChanged Then
                PublishEvent(New EndingReconciliationDateChangedEvent(sender))
                bsAccountReconciliationItems.ResetBindings(False)
            End If
        End Sub

        Private Sub cboAccountIdNo_Changed(sender As Object, e As EventArgs) Handles cboAccountIdNo.Validated, cboAccountIdNo.SelectionChangeCommitted
            If Not btnEdit.Enabled Then
                If cboAccountIdNo.ValueChanged() Then
                    PublishEvent(New ReconciliationAccountChangedEvent(sender))
                    bsAccountReconciliationItems.ResetBindings(False)
                End If
            End If
        End Sub

        'Public Sub ButtonAdd_Click(sender As Object, e As EventArgs)
        '    cboAccountIdNo.DisplayOnly = False
        '    dtpReconciliationDate.DisplayOnly = False
        '    cboAccountIdNo.SelectedIndex = -1
        '    dtpReconciliationDate.Value = Nothing
        'End Sub

        Private Sub btnPost_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnPost.ClickButtonArea
            PublishEvent(New ReconciliationPostingRequestEvent(sender, Not btnSave.Enabled))
        End Sub

        Private Sub btnClearAll_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnClearAll.ClickButtonArea
            PublishEvent(New ReconciliationClearEvent(sender, True, True, bsAccountReconciliationItems))
        End Sub

        Private Sub btnUnClearAll_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnUnClearAll.ClickButtonArea
            PublishEvent(New ReconciliationClearEvent(sender, True, False, bsAccountReconciliationItems))
        End Sub

        Public Sub OnAcReconEditModeChanged(ByRef e As EditModeChanged) Implements ISubscriber(Of EditModeChanged).OnEventHandler
            MyBase.OnEventHandlerEditModeChanged(e)
            If e.EditMode Then
                btnClearAll.Enabled = True
                btnUnClearAll.Enabled = True
                btnPost.Enabled = False
            Else
                btnClearAll.Enabled = False
                btnUnClearAll.Enabled = False
                If chkPosted.Checked Then
                    btnPost.Enabled = False
                Else
                    btnPost.Enabled = True
                End If
            End If

        End Sub

        Public Sub OnAcReconAddModeChanged(ByRef e As AddModeChanged) Implements ISubscriber(Of AddModeChanged).OnEventHandler
            MyBase.OnEventHandlerAddModeChanged(e)
            If e.AddMode Then
                btnPost.Enabled = False
                btnClearAll.Enabled = True
                btnUnClearAll.Enabled = True
                'dtpReconciliationDate.Enabled = True
                'dtpReconciliationDate.DisplayOnly = False
                'dtpReconciliationDate.ReadOnlyDp = False
                'cboAccountIdNo.DisplayOnly = False
                'cboAccountIdNo.Enabled = True
            Else
                btnPost.Enabled = True
                btnClearAll.Enabled = False
                btnUnClearAll.Enabled = False
                If chkPosted.Checked Then
                    btnPost.Enabled = False
                Else
                    btnPost.Enabled = True
                End If
            End If
        End Sub

        'Private Sub BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker.DoWork
        '    _progressDisplayForm = New ProgressDisplayForm()
        '    _progressDisplayForm.Show()

        'End Sub

        'Private Sub BackgroundWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker.ProgressChanged
        '    _progressDisplayForm.ProgressBar.Value = e.ProgressPercentage
        '    _progressDisplayForm.lblProgress.Text = "Records processed : " + e.ProgressPercentage.ToString()
        'End Sub

        'Private Sub BackgroundWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker.RunWorkerCompleted

        'End Sub
    End Class

End Namespace
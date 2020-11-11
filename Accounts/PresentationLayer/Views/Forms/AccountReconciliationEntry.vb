Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports CrystalDecisions.CrystalReports.Engine

Namespace PresentationLayer.Views.Forms

    Public Class AccountReconciliationEntry
        Implements IAccountReconciliationView

        Public Report As New ReportDocument
        Private ReadOnly _nfi As NumberFormatInfo
        Private _accountReconciliations As New List(Of AccountReconciliationItemView)
        Private _glSystemBalance As Decimal
        Private _balance As Decimal
        Private bsSearchFieldsList As BindingSource
        Private contextMenuForReferenceNo As ContextMenu = New ContextMenu()
        Private contextMenuForDocumentNo As ContextMenu = New ContextMenu()
        Private contextMenuForDebit As ContextMenu = New ContextMenu()
        Private contextMenuForCredit As ContextMenu = New ContextMenu()

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "AccountReconciliation"
            SortOrderKey = "IdNo"
            FirstControl = cboAccountIdNo
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            PresenterObj = New AccountReconciliationPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

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
            End Set
        End Property

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
                txtTotalOutstandingCredits.Text = txtTotalCreditsNotCleared.Text
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
                txtTotalOutstandingDeposits.Text = txtTotalDebitsNotCleared.Text
            End Set
        End Property

        Public Property GlSystemBalance As Decimal Implements IAccountReconciliationView.GlSystemBalance
            Get
                Return _glSystemBalance
            End Get
            Set
                _glSystemBalance = Value
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
                Else
                    dtpReconciliationDate.Value = Value
                End If
            End Set
        End Property

        Public Property UnreconciledDifference As Decimal Implements IAccountReconciliationView.UnreconciledDifference
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtUnreconciledDifference.Text), _nfi)
            End Get
            Set
                txtUnreconciledDifference.Text = FormatMoney(Value)
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            PresenterObj.GetDetailAccountListByCode()
            'PresenterObj.GetRevCostCenterListByCode()
            cboAccountIdNo.BeginUpdate()
            cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList("BA,CK,CS")
            cboAccountIdNo.EndUpdate()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AccountIdNo", cboAccountIdNo},
                {"Balance", txtBalance},
                {"IdNo", TxtIdNo},
                {"ReconciliationDate", dtpReconciliationDate}
                }
        End Sub

        'Protected Overrides Sub RecordPositionChanged()
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

        Private Sub DataGridViewReconciliationItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewReconciliationItems.CellContentClick
            If DataGridViewReconciliationItems.CurrentCell IsNot Nothing And (PresenterObj.EditMode Or PresenterObj.AddMode) Then
                With DataGridViewReconciliationItems.CurrentCell
                    Select Case .OwningColumn.Name.ToLower()
                        Case $"dgvcleared"
                            Dim selectedRow As AccountReconciliationItemView
                            Dim checked = DataGridViewReconciliationItems.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue
                            selectedRow = DataGridViewReconciliationItems.Rows(.RowIndex).DataBoundItem
                            If checked Then
                                'DataGridViewReconciliationItems.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Green
                                If selectedRow.Debit > 0 Then
                                    TotalDebitsCleared += selectedRow.Debit
                                    TotalDebitsNotCleared -= selectedRow.Debit
                                    TotalQtyDebitsCleared += 1
                                    TotalQtyDebitsNotCleared -= 1
                                Else
                                    TotalCreditsCleared += selectedRow.Credit
                                    TotalCreditsNotCleared -= selectedRow.Credit
                                    TotalQtyCreditsCleared += 1
                                    TotalQtyCreditsNotCleared -= 1
                                End If
                            Else
                                'DataGridViewReconciliationItems.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gray
                                If selectedRow.Debit > 0 Then
                                    TotalDebitsCleared -= selectedRow.Debit
                                    TotalDebitsNotCleared += selectedRow.Debit
                                    TotalQtyDebitsCleared -= 1
                                    TotalQtyDebitsNotCleared += 1
                                Else
                                    TotalCreditsCleared -= selectedRow.Credit
                                    TotalCreditsNotCleared += selectedRow.Credit
                                    TotalQtyCreditsCleared -= 1
                                    TotalQtyCreditsNotCleared += 1
                                End If
                            End If
                            ReComputeDifference()
                            Refresh()
                    End Select
                End With
            End If
        End Sub

        Private Sub AccountReconciliationEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KeyPreview = True

            'contextMenuForReferenceNo.MenuItems.Add("File", New EventHandler(AddressOf MenuClicked))
            'contextMenuForReferenceNo.MenuItems.Add("Edit")

            'contextMenuForDebit.MenuItems.Add("Find value equal to ", AddressOf MenuClicked)

            ''contextMenuForReferenceNo.MenuItems.Add("Find", New EventHandler(AddressOf MenuClicked))
            ''contextMenuForReferenceNo.MenuItems.Add("Find", New EventHandler(AddressOf MenuClicked))
            ''contextMenuForReferenceNo.MenuItems.Add("Find", New EventHandler(AddressOf MenuClicked))
            ''contextMenuForReferenceNo.MenuItems.Add("Find", New EventHandler(AddressOf MenuClicked))

            ''contextMenuForDocumentNo.MenuItems.Add("Delete", New EventHandler(Delete))
            ''contextMenuForDebit.MenuItems.Add("Register", New EventHandler(Register))
            ''contextMenuForCredit.MenuItems.Add("Register", New EventHandler(Register))
            ''bsSearchFieldsList.DataSource = New List(Of String) From {
            ''                                     "test1",
            ''                                     "test2"
            ''                                     }
        End Sub

        'Private Sub MenuClicked()
        '    Dim myForm = FindForm()
        '    Dim pnt As Point
        '    Dim searchForm = New CFindForm
        '    Dim screenRectangle As Rectangle
        '    Dim formLocation As Point
        '    screenRectangle = Screen.PrimaryScreen.WorkingArea
        '    searchForm.StartPosition = FormStartPosition.Manual
        '    pnt = myForm.PointToScreen(Location)
        '    If formLocation.Y + searchForm.Height > screenRectangle.Height Then
        '        formLocation.Y = pnt.Y - searchForm.Height + Height
        '    End If
        '    searchForm.Location = formLocation
        '    'If System.ComponentModel.LicenseManager.UsageMode <> System.ComponentModel.LicenseUsageMode.Designtime Then
        '    '    SearchForm.RightToLeftLayout = myForm.RightToLeftLayout
        '    '    SearchForm.RightToLeft = myForm.RightToLeft
        '    'End If
        '    searchForm.ShowDialog()
        '    Dim _textToSearch As String
        '    Dim _searchAnywhere As String
        '    _textToSearch = searchForm.TextToSearch
        '    _searchAnywhere = Convert.ToBoolean(searchForm.GetSearchAnywhere)
        '    searchForm.Dispose()
        '    If _textToSearch <> "" Then
        '        DataGridViewReconciliationItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '        Try
        '            For Each row As DataGridViewRow In DataGridViewReconciliationItems.Rows
        '                If row.Cells(3).Value.ToString().Equals(_textToSearch) Then
        '                    row.Selected = True
        '                    Exit For
        '                End If
        '            Next
        '        Catch exc As Exception
        '            MessageBox.Show(exc.Message)
        '        End Try
        '    End If
        'End Sub

        'Private Sub FindValue()
        '    Dim myForm = FindForm()
        '    Dim pnt As Point
        '    Dim searchForm = New CFindForm
        '    Dim screenRectangle As Rectangle
        '    Dim formLocation As Point
        '    screenRectangle = Screen.PrimaryScreen.WorkingArea
        '    searchForm.StartPosition = FormStartPosition.Manual
        '    pnt = myForm.PointToScreen(Location)
        '    If formLocation.Y + searchForm.Height > screenRectangle.Height Then
        '        formLocation.Y = pnt.Y - searchForm.Height + Height
        '    End If
        '    searchForm.Location = formLocation
        '    'If System.ComponentModel.LicenseManager.UsageMode <> System.ComponentModel.LicenseUsageMode.Designtime Then
        '    '    SearchForm.RightToLeftLayout = myForm.RightToLeftLayout
        '    '    SearchForm.RightToLeft = myForm.RightToLeft
        '    'End If
        '    searchForm.ShowDialog()
        '    Dim _textToSearch As String
        '    Dim _searchAnywhere As String
        '    _textToSearch = searchForm.TextToSearch
        '    _searchAnywhere = Convert.ToBoolean(searchForm.GetSearchAnywhere)
        '    searchForm.Dispose()
        '    If _textToSearch <> "" Then
        '        DataGridViewReconciliationItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '        Try
        '            For Each row As DataGridViewRow In DataGridViewReconciliationItems.Rows
        '                If row.Cells(3).Value.ToString().Equals(_textToSearch) Then
        '                    row.Selected = True
        '                    Exit For
        '                End If
        '            Next
        '        Catch exc As Exception
        '            MessageBox.Show(exc.Message)
        '        End Try
        '    End If
        'End Sub

        Private Sub UpdateTotals()
            Dim nTotalDebitsCleared As Decimal = 0
            Dim nTotalCreditsCleared As Decimal = 0
            Dim nTotalDebitsNotCleared As Decimal = 0
            Dim nTotalCreditsNotCleared As Decimal = 0
            Dim nTotalQtyDebitsCleared As Integer = 0
            Dim nTotalQtyCreditsCleared As Integer = 0
            Dim nTotalQtyDebitsNotCleared As Integer = 0
            Dim nTotalQtyCreditsNotCleared As Integer = 0
            For Each accountReconciliationItem In bsAccountReconciliationItems
                If accountReconciliationItem.Cleared Then
                    If accountReconciliationItem.Debit > 0 Then
                        nTotalDebitsCleared += accountReconciliationItem.Debit
                        nTotalQtyDebitsCleared += 1
                    Else
                        nTotalQtyCreditsCleared += 1
                        nTotalCreditsCleared += accountReconciliationItem.Credit
                    End If
                Else
                    If accountReconciliationItem.Debit > 0 Then
                        nTotalDebitsNotCleared += accountReconciliationItem.Debit
                        nTotalQtyDebitsNotCleared += 1
                    Else
                        nTotalQtyCreditsNotCleared += 1
                        nTotalCreditsNotCleared += accountReconciliationItem.Credit
                    End If
                End If
            Next
            TotalDebitsCleared = nTotalDebitsCleared
            TotalCreditsCleared = nTotalCreditsCleared
            TotalDebitsNotCleared = nTotalDebitsNotCleared
            TotalCreditsNotCleared = nTotalCreditsNotCleared
            TotalQtyDebitsCleared = nTotalQtyDebitsCleared
            TotalQtyCreditsCleared = nTotalQtyCreditsCleared
            TotalQtyDebitsNotCleared = nTotalQtyDebitsNotCleared
            TotalQtyCreditsNotCleared = nTotalQtyCreditsNotCleared
            GlSystemBalance = GetGlSystemBalance()
            ReComputeDifference()
        End Sub

        Private Sub CatchClose(ByVal sender As Object, ByVal e As ComponentModel.CancelEventArgs)
            ' Insert code to deal with impending closure of this form.
        End Sub

        Public Sub FormOpened()
            AddHandler Closing, AddressOf CatchClose
        End Sub

        Private Function GetGlSystemBalance() As Decimal
            If cboAccountIdNo.SelectedIndex >= 0 Then
                Dim condition = "AccountIdNo = " & cboAccountIdNo.GetValue.ToString() & " and TransactionDate <= '" & DtoS(ReconciliationDate) & "'"
                Return PresenterObj.GetSqlValue(Of Decimal)("sum(Debit-Credit)", "GlLedgers_View", condition)
            End If
            Return 0
        End Function

        Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
            If Not DataGridViewReconciliationItems.DataBindings Is Nothing Then
                DataGridViewReconciliationItems.DataInGridChanged = False
            End If
            UpdateTotals()
        End Sub

        'Private Sub GetAcctReconItems()
        '    Dim acctReconItems = _accountReconciliationItemsPresenter.GetAcctReconItems(AccountIdNo, ReconciliationDate, "TransactionDate")
        '    Dim newItem As AccountReconciliationItemModel
        '    Dim nSeq As Integer = 1
        '    bsAccountReconciliationItems.Clear()
        '    If PresenterObj.AddMode Then
        '        For Each acctReconItem In acctReconItems
        '            acctReconItem.Cleared = False
        '            acctReconItem.IdNo = 0
        '            AddNewItem(acctReconItem, nSeq)
        '            nSeq = nSeq + 1
        '        Next
        '    Else
        '        For Each acctReconItem In acctReconItems
        '            If acctReconItem.AccountReconciliationIdNo = 0 Or acctReconItem.AccountReconciliationIdNo = IdNo Then
        '                'newItem = acctReconItems.Find(Function(c As AccountReconciliationItemModel) c.JournalCode = acctReconItem.JournalCode And
        '                '                                                                                 c.JournalItemIdNo = acctReconItem.JournalItemIdNo)
        '                'If newItem IsNot Nothing Then
        '                AddNewItem(acctReconItem, nSeq)
        '                'End If
        '                nSeq = nSeq + 1
        '            End If
        '        Next
        '    End If
        '    DataGridViewReconciliationItems.Refresh()
        'End Sub

        'Private Sub AddNewItem(acctReconItem As AccountReconciliationItemModel, nSeq As Integer)
        '    Dim item As New AccountReconciliationItemModel With {
        '            .AccountIdNo = acctReconItem.AccountIdNo,
        '            .AccountReconciliationIdNo = acctReconItem.AccountReconciliationIdNo,
        '            .Cleared = acctReconItem.Cleared,
        '            .Credit = acctReconItem.Credit,
        '            .Debit = acctReconItem.Debit,
        '            .IdNo = acctReconItem.IdNo,
        '            .JournalCode = acctReconItem.JournalCode,
        '            .JournalIdNo = acctReconItem.JournalIdNo,
        '            .JournalItemIdNo = acctReconItem.JournalItemIdNo,
        '            .PayDescription = IIf(GlobalVariables.RightToLeftLayout , acctReconItem.PayDescriptionAra, acctReconItem.PayDescription),
        '            .ReferenceNo = acctReconItem.ReferenceNo,
        '            .TransactionDate = acctReconItem.TransactionDate,
        '            .Sequence = nSeq}
        '    bsAccountReconciliationItems.Add(item)
        'End Sub

        'Private Sub AddNewItem(acctReconItem As AccountReconciliationItemModel, newItem As AccountReconciliationItemModel, nSeq As Integer)
        '    If newItem IsNot Nothing Then
        '        Dim item As New AccountReconciliationItemModel With {
        '                .AccountIdNo = acctReconItem.AccountIdNo,
        '                .AccountReconciliationIdNo = acctReconItem.AccountReconciliationIdNo,
        '                .Cleared = acctReconItem.Cleared,
        '                .Credit = acctReconItem.Credit,
        '                .Debit = acctReconItem.Debit,
        '                .IdNo = acctReconItem.IdNo,
        '                .JournalCode = acctReconItem.JournalCode,
        '                .JournalIdNo = acctReconItem.JournalIdNo,
        '                .JournalItemIdNo = acctReconItem.JournalItemIdNo,
        '                .PayDescription = acctReconItem.PayDescription,
        '                .PayDescriptionAra = acctReconItem.PayDescriptionAra,
        '                .ReferenceNo = acctReconItem.ReferenceNo,
        '                .TransactionDate = acctReconItem.TransactionDate,
        '                .Sequence = nSeq}
        '        bsAccountReconciliationItems.Add(item)
        '    Else
        '        bsAccountReconciliationItems(nSeq - 1).Sequence = nSeq
        '    End If
        'End Sub

        Private Sub txtBalance_TextChanged(sender As Object, e As EventArgs) Handles txtBalance.Validated
            txtBalance2.Text = txtBalance.Text
            ReComputeDifference()
        End Sub

        Private Sub ReComputeDifference()
            UnreconciledDifference = NumParser(Of Decimal)(txtBalance2.Text) + NumParser(Of Decimal)(txtTotalOutstandingDeposits.Text) _
                                     - NumParser(Of Decimal)(txtTotalOutstandingCredits.Text) - GlSystemBalance
        End Sub

        'Private Sub DtpReconciliationDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpReconciliationDate.Validating
        '    if DataGridViewReconciliationItems.RowCount() > 0 Then

        '    End If
        'End Sub

        'Private Sub DtpReconciliationDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpReconciliationDate.Validated, cboAccountIdNo.Validated
        '    If (PresenterObj.EditMode Or PresenterObj.AddMode) And AccountIdNo <> 0 And dtpReconciliationDate.Text IsNot Nothing And dtpReconciliationDate.Text <> "" Then
        '        AccountReconciliationItems = _accountReconciliationItemsPresenter.GetAcctReconItems(AccountIdNo, ReconciliationDate, PresenterObj.AddMode, PresenterObj.EditMode, PresenterObj.TargetIdNo, "TransactionDate")
        '        DisplayTotals()
        '        DataGridViewReconciliationItems.Refresh()
        '    End If
        'End Sub

        Private Sub DataGridViewReconciliationItems_MouseUp(sender As Object, e As MouseEventArgs) Handles DataGridViewReconciliationItems.MouseUp
            Dim hitTestInfo As DataGridView.HitTestInfo

            If e.Button = MouseButtons.Right Then
                hitTestInfo = DataGridViewReconciliationItems.HitTest(e.X, e.Y)
                If hitTestInfo.Type = DataGridViewHitTestType.ColumnHeader Then
                    FindValue(hitTestInfo.ColumnIndex)
                End If
                'If hitTestInfo.Type = DataGridViewHitTestType.ColumnHeader AndAlso hitTestInfo.ColumnIndex = DataGridViewReconciliationItems.Columns.IndexOf(dgvReferenceNo) Then contextMenuForReferenceNo.Show(DataGridViewReconciliationItems, New Point(e.X, e.Y))
                'If hitTestInfo.Type = DataGridViewHitTestType.Cell AndAlso hitTestInfo.ColumnIndex = DataGridViewReconciliationItems.Columns.IndexOf(dgvDocumentNumber) Then contextMenuForDocumentNo.Show(DataGridViewReconciliationItems, New Point(e.X, e.Y))
                'If hitTestInfo.Type = DataGridViewHitTestType.Cell AndAlso hitTestInfo.ColumnIndex = DataGridViewReconciliationItems.Columns.IndexOf(dgvDebit) Then FindValue(DataGridViewReconciliationItems.Columns.IndexOf(dgvDebit))
                'If hitTestInfo.Type = DataGridViewHitTestType.Cell AndAlso hitTestInfo.ColumnIndex = DataGridViewReconciliationItems.Columns.IndexOf(dgvCredit) Then contextMenuForCredit.Show(DataGridViewReconciliationItems, New Point(e.X, e.Y))
            End If
        End Sub

        Private Sub FindValue(ByRef columnNo As Int16)
            'Select Case columnNo
            '    Case DataGridViewReconciliationItems.Columns.IndexOf(dgvDebit)
            Dim myForm = FindForm()
            Dim pnt As Point
            Dim searchForm = New CFindForm
            Dim screenRectangle As Rectangle
            Dim formLocation As Point
            screenRectangle = Screen.PrimaryScreen.WorkingArea
            searchForm.StartPosition = FormStartPosition.Manual
            pnt = myForm.PointToScreen(Location)
            If formLocation.Y + searchForm.Height > screenRectangle.Height Then
                formLocation.Y = pnt.Y - searchForm.Height + Height
            End If
            searchForm.Location = formLocation
            'If System.ComponentModel.LicenseManager.UsageMode <> System.ComponentModel.LicenseUsageMode.Designtime Then
            '    SearchForm.RightToLeftLayout = myForm.RightToLeftLayout
            '    SearchForm.RightToLeft = myForm.RightToLeft
            'End If
            searchForm.ShowDialog()
            Dim textToSearch As String
            Dim searchAnywhere As String
            textToSearch = searchForm.TextToSearch
            searchAnywhere = Convert.ToBoolean(searchForm.GetSearchAnywhere)
            searchForm.Dispose()
            If textToSearch <> "" Then
                DataGridViewReconciliationItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Try
                    DataGridViewReconciliationItems.ClearSelection()
                    For Each row As DataGridViewRow In DataGridViewReconciliationItems.Rows
                        If searchAnywhere Then
                            If row.Cells(columnNo).Value.ToString().Contains(textToSearch) Then
                                row.Selected = True
                            End If
                        Else
                            If row.Cells(columnNo).Value.ToString().Equals(textToSearch) Then
                                row.Selected = True
                            End If
                        End If
                    Next
                Catch exc As Exception
                    MessageBox.Show(exc.Message)
                End Try
            End If

            '    Case Else

            'End Select

        End Sub

        'Public Sub CheckIfEditable() Handles MyBase.BeforeEdit
        '    If Posted Then
        '        Messaging.Show(True, "MsgReconciliationAlreadyPosted", $"This Reconciliation entry has already been posted. Edits not allowed!", "Posted Reconciliation")
        '        PresenterObj.CancelEdit = True
        '    End If
        'End Sub

        Private Sub dtpReconciliationDate_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles dtpReconciliationDate.Validating
            If dtpReconciliationDate.DateChanged() Then
                If dtpReconciliationDate.DateChanged() Then
                    If AccountReconciliationItems.Any() Then
                        Messaging.Show("MsgDateChangedNotAllowed", "Sorry you can't change the reconciliation date when account reconciliation grid is not empty. Previous value restored.")
                        dtpReconciliationDate.Undo()
                    End If
                End If
                If AccountIdNo <> 0 And dtpReconciliationDate.Text IsNot Nothing Then
                    AccountReconciliationItems = PresenterObj.GetAcctReconItems(AccountIdNo, ReconciliationDate, PresenterObj.TargetIdNo, "TransactionDate")
                    UpdateTotals()
                    DataGridViewReconciliationItems.Refresh()
                End If
            End If
        End Sub

        Private Sub cboAccountIdNo_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles cboAccountIdNo.Validating
            If cboAccountIdNo.ValueChanged() Then
                If cboAccountIdNo.SelectedIndex > -1 Then
                    If AccountReconciliationItems.Any() Then
                        Messaging.Show(True, "MsgOnEmptyReconChangeAccNotAllowed", "Sorry you can't change the account to reconcile when account reconciliation grid is not empty. Previous value restored.", "Account change not allowed")
                        cboAccountIdNo.RevertValue()
                    End If
                End If
            End If
            If dtpReconciliationDate.Text IsNot Nothing And dtpReconciliationDate.Text <> "" Then
                AccountReconciliationItems = PresenterObj.GetAcctReconItems(AccountIdNo, ReconciliationDate, PresenterObj.TargetIdNo, "TransactionDate")
                UpdateTotals()
                DataGridViewReconciliationItems.Refresh()
            End If
        End Sub

        Private Sub btnPost_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnPost.ClickButtonArea
            If UnreconciledDifference = 0 And Not Posted Then
                If btnSave.Enabled Then
                    Messaging.Show(True, "MsgSaveReconFirstBeforePosting", "Please save first your reconciliation before posting!", "Unsaved entries exist")
                Else
                    Dim message = "Are you sure you want to {action} this {itemName} entry?"
                    Dim caption = "Please confirm."
                    Dim action = "post"
                    Dim itemName = "account reconciliation"
                    Messaging.GetMessage(True, "AskIfContinueAction", message, caption)
                    message = message.Interpolate(Function(x) action, Function(x) itemName)
                    If Messaging.Show(True, "AskIfContinueAction", message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        PresenterObj.PostReconciliation(IdNo, AccountReconciliationItems)
                    Else
                        MyErrorProvider.ClearAllErrorMessages()
                    End If
                End If
            Else
                If Posted Then
                    Messaging.Show(True, "MsgAlreadyPosted", "Sorry this record has already been posted!", "Invalid Request")
                Else
                    Dim err = Messaging.GetMessage(True, "MsgCannotPostUnreconciledEntry", "Sorry you can't post an un-reconciled entry!", "")
                    Messaging.Show(False, "MsgCannotPostUnreconciledEntry")
                    MyErrorProvider.SetError(txtUnreconciledDifference, err)
                End If
            End If
        End Sub

        'Protected Overrides Sub EndEditOnAllBindingSources()
        '    'Dim bindingSourcesQuery = From BindingSources In components.Components
        '    '                          Where (TypeOf BindingSources Is Windows.Forms.BindingSource)
        '    'Select Case BindingSources
        '    Dim currentComponents = components.Components
        '    For Each item In currentComponents
        '        If TypeOf item Is Windows.Forms.BindingSource Then
        '            item.EndEdit()
        '        End If
        '    Next
        'End Sub

        'Private Function ShowError(translate As Boolean, key As String, message As String, caption As String, ParamArray variables As String())
        '    Dim oldValue As String = ""
        '    Dim newValue As String = ""
        '    message = Messaging.GetMessage(True, key, message, caption)
        '    For i = 0 To variables.Count - 1 Step 2
        '        oldValue = variables(i)
        '        newValue = variables(i + 1)
        '        message = Replace(message, oldValue, newValue, 1, -1, CompareMethod.Text)
        '    Next
        '    Return Messaging.Show(message, caption)
        'End Function
        'Public Sub OnParentRecordUpdatedSuccessfully(passedValue As Integer) _
        '    Handles MyBase.RecordUpdatedSuccessfully, MyBase.RecordAddedSuccessfully

        '    If PresenterObj.AddMode Then
        '        IdNo = passedValue
        '    End If
        '    If DtInsertTable IsNot Nothing Then
        '        DtInsertTable.Clear()
        '    End If
        '    If DtUpdateTable IsNot Nothing Then
        '        DtUpdateTable.Clear()
        '    End If
        '    Dim nRowCount = 1
        '    For Each ji In bsAccountReconciliationItems
        '        Dim workRow As DataRow
        '        If ji.IdNo <= 0 Then
        '            workRow = DtInsertTable.NewRow()
        '        Else
        '            workRow = DtUpdateTable.NewRow()
        '            workRow("IdNo") = ji.IdNo
        '        End If
        '        workRow("AccountReconciliationIdNo") = IdNo
        '        workRow("Cleared") = ji.Cleared
        '        workRow("JournalCode") = ji.JournalCode
        '        workRow("JournalItemIdNo") = ji.JournalItemIdNo
        '        workRow("Sequence") = nRowCount
        '        If ji.IdNo <= 0 Then
        '            DtInsertTable.Rows.Add(workRow)
        '        Else
        '            DtUpdateTable.Rows.Add(workRow)
        '        End If
        '        nRowCount += 1
        '    Next
        '    _accountReconciliationItemsPresenter.Save(DtInsertTable, DtUpdateTable, IdNo)
        'End Sub

    End Class

End Namespace
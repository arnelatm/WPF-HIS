Imports System.Globalization
Imports System.Threading
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
        'Private _progressDisplayForm As Form1

        Public Event ReconciliationAccountChangedEvent(sender As Object, bindingSource As BindingSource) Implements IAccountReconciliationView.ReconciliationAccountChangedEvent

        Public Event ReconciliationClearEvent(sender As Object, all As Boolean, clear As Boolean, dataBindingSource As BindingSource) Implements IAccountReconciliationView.ReconciliationClearEvent

        Public Event ReconciliationPostingRequestEvent(sender As Object, bindingSource As BindingSource) Implements IAccountReconciliationView.ReconciliationPostingRequestEvent

        Public Event ReconciliationReviewCompletionRequestEvent(sender As Object) Implements IAccountReconciliationView.ReconciliationReviewCompletionRequestEvent

        Public Event ReconciliationReviewReopenRequestEvent(sender As Object) Implements IAccountReconciliationView.ReconciliationReviewReopenRequestEvent

        Public Event ReconciliationRefreshRequestEvent() Implements IAccountReconciliationView.ReconciliationRefreshRequestEvent

        Public Event EndingBankBalanceEntryChangedEvent() Implements IAccountReconciliationView.EndingBankBalanceEntryChangedEvent

        Public Event EndingReconciliationDateChangedEvent() Implements IAccountReconciliationView.EndingReconciliationDateChangedEvent

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            FirstControl = dtpReconciliationDate
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
                txtReconciliationStatus.Text = GetStatusCaption(_status)
            End If
            UpdateReconciliationWorkflowButtons()
            RaiseEvent ReconciliationAccountChangedEvent(Me, bsAccountReconciliationItems)
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
                RunOrDeferViewDataBinding(AddressOf BindAccountReconciliation)
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
                UpdateReconciliationWorkflowButtons()
            End Set
        End Property

        Private _status As String = "Draft"

        Public Property Status As String Implements IAccountReconciliationView.Status
            Get
                Return _status
            End Get
            Set(value As String)
                _status = If(String.IsNullOrWhiteSpace(value), "Draft", value)
                If txtReconciliationStatus IsNot Nothing Then
                    txtReconciliationStatus.Text = GetStatusCaption(_status)
                End If
                UpdateReconciliationWorkflowButtons()
            End Set
        End Property

        Private Function GetStatusCaption(value As String) As String
            If System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then
                Return value
            End If
            Select Case value
                Case "ReviewCompleted"
                    Return Messaging.TranslateCaption("Review Completed")
                Case "Finalized"
                    Return Messaging.TranslateCaption("Finalized")
                Case Else
                    Return Messaging.TranslateCaption(value)
            End Select
        End Function

        Public Property ReviewedBy As String Implements IAccountReconciliationView.ReviewedBy
        Public Property ReviewedAt As DateTime? Implements IAccountReconciliationView.ReviewedAt
        Public Property FinalizedBy As String Implements IAccountReconciliationView.FinalizedBy
        Public Property FinalizedAt As DateTime? Implements IAccountReconciliationView.FinalizedAt

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

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AccountIdNo", cboAccountIdNo},
                {"Balance", txtBalance},
                {"IdNo", TxtIdNo},
                {"ReconciliationDate", dtpReconciliationDate}
                }
        End Sub

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
                Dim dateCulture = New System.Globalization.CultureInfo("en")
                dgvSequence.DisplayOnly = True
                dgvJournalCode.DisplayOnly = True
                dgvJournalIdNo.DisplayOnly = True
                dgvCredit.DisplayOnly = True
                dgvDebit.DisplayOnly = True
                'dgvJournalItemIdNo.DisplayOnly = True
                dgvReferenceNo.DisplayOnly = True
                dgvTransactionDate.DisplayOnly = True
                Dim englishDateTimeFormat As DateTimeFormatInfo = New CultureInfo("en-GB").DateTimeFormat
                Thread.CurrentThread.CurrentCulture.DateTimeFormat = englishDateTimeFormat
            End With
            ResumeLayout()
        End Sub

#Region "FindValues"

        'Private Sub DataGridViewReconciliationItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewReconciliationItems.CellContentClick
        '    If DataGridViewReconciliationItems.CurrentCell IsNot Nothing AndAlso (Presenter.EditMode Or Presenter.AddMode) Then
        '        With DataGridViewReconciliationItems.CurrentCell
        '            Select Case .OwningColumn.Name.ToLower()
        '                Case $"dgvcleared"
        '                    Dim selectedRow = DataGridViewReconciliationItems.Rows(.RowIndex).DataBoundItem
        '                    RaiseEvent ReconciliationClearEvent(selectedRow, False, .Value, bsAccountReconciliationItems)
        '            End Select
        '        End With
        '    End If
        'End Sub

        'Private Sub DataGridViewReconciliationItems_CellContentClick() Handles DataGridViewReconciliationItems.CellValueChanged
        '    If DataGridViewReconciliationItems.CurrentCell IsNot Nothing AndAlso (Presenter.EditMode Or Presenter.AddMode) Then
        '        With DataGridViewReconciliationItems.CurrentCell
        '            Select Case .OwningColumn.Name.ToLower()
        '                Case $"dgvcleared"
        '                    Dim selectedRow = DataGridViewReconciliationItems.Rows(.RowIndex).DataBoundItem
        '                    RaiseEvent ReconciliationClearEvent(selectedRow, False, .Value, bsAccountReconciliationItems)
        '            End Select
        '        End With
        '    End If
        'End Sub

        Private Sub CheckBoxValueChanged() Handles DataGridViewReconciliationItems.CellValueChanged
            If TypeOf DataGridViewReconciliationItems.CurrentCell Is DataGridViewCheckBoxCell Then
                If DataGridViewReconciliationItems.CurrentCell.OwningColumn.Name = "dgvCleared" Then
                    With DataGridViewReconciliationItems.CurrentCell
                        Dim selectedRow = DataGridViewReconciliationItems.Rows(.RowIndex).DataBoundItem
                        RaiseEvent ReconciliationClearEvent(selectedRow, False, .Value, bsAccountReconciliationItems)
                    End With
                End If
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
            If searchForm.ShowDialog() = DialogResult.OK Then
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
            RaiseEvent EndingBankBalanceEntryChangedEvent()
        End Sub

#End Region

        Private Sub dtpReconciliationDate_Validated(sender As Object, e As EventArgs) Handles dtpReconciliationDate.Validated
            If Not btnEdit.Enabled Then 'And dtpReconciliationDate.DateChanged Then
                RaiseEvent EndingReconciliationDateChangedEvent()
                bsAccountReconciliationItems.ResetBindings(False)
            End If
        End Sub

        Private Sub cboAccountIdNo_Changed(sender As Object, e As EventArgs) Handles cboAccountIdNo.Validated, cboAccountIdNo.SelectionChangeCommitted
            If Not btnEdit.Enabled Then
                'If cboAccountIdNo.ValueChanged() Then
                RaiseEvent ReconciliationAccountChangedEvent(sender, bsAccountReconciliationItems)
                'PublishEvent(New ReconciliationAccountChangedEvent(Me, bsAccountReconciliationItems))
                'bsAccountReconciliationItems.ResetBindings(False)
                'End If
            End If
        End Sub

        'Public Sub ButtonAdd_Click(sender As Object, e As EventArgs)
        '    cboAccountIdNo.DisplayOnly = False
        '    dtpReconciliationDate.DisplayOnly = False
        '    cboAccountIdNo.SelectedIndex = -1
        '    dtpReconciliationDate.Value = Nothing
        'End Sub

        Private Sub btnPost_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnPost.ClickButtonArea
            RaiseEvent ReconciliationPostingRequestEvent(Me, bsAccountReconciliationItems)
        End Sub

        Private Sub btnCompleteReview_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCompleteReview.ClickButtonArea
            RaiseEvent ReconciliationReviewCompletionRequestEvent(Me)
        End Sub

        Private Sub btnReopenReview_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnReopenReview.ClickButtonArea
            RaiseEvent ReconciliationReviewReopenRequestEvent(Me)
        End Sub

        Private Sub btnClearAll_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnClearAll.ClickButtonArea
            RaiseEvent ReconciliationClearEvent(sender, True, True, bsAccountReconciliationItems)
        End Sub

        Private Sub btnUnClearAll_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnUnClearAll.ClickButtonArea
            RaiseEvent ReconciliationClearEvent(sender, True, False, bsAccountReconciliationItems)
        End Sub

        Public Sub OnAcReconEditModeChanged(ByRef e As EditModeChanged) Implements ISubscriber(Of EditModeChanged).OnEventHandler
            'MyBase.OnEventHandlerEditModeChanged(e)
            If e.EditMode Then
                btnClearAll.Enabled = True
                btnUnClearAll.Enabled = True
                UpdateReconciliationWorkflowButtons()
            Else
                btnClearAll.Enabled = False
                btnUnClearAll.Enabled = False
                UpdateReconciliationWorkflowButtons()
            End If

        End Sub

        Public Sub OnAcReconAddModeChanged(ByRef e As AddModeChanged) Implements ISubscriber(Of AddModeChanged).OnEventHandler
            'MyBase.OnEventHandlerAddModeChanged(e)
            If e.AddMode Then
                UpdateReconciliationWorkflowButtons()
                btnClearAll.Enabled = True
                btnUnClearAll.Enabled = True
                'dtpReconciliationDate.Enabled = True
                'dtpReconciliationDate.DisplayOnly = False
                'dtpReconciliationDate.ReadOnlyDp = False
                'cboAccountIdNo.DisplayOnly = False
                'cboAccountIdNo.Enabled = True
            Else
                UpdateReconciliationWorkflowButtons()
                btnClearAll.Enabled = False
                btnUnClearAll.Enabled = False
                UpdateReconciliationWorkflowButtons()
            End If
        End Sub

        Private Sub UpdateReconciliationWorkflowButtons()
            If btnPost Is Nothing OrElse btnCompleteReview Is Nothing OrElse btnReopenReview Is Nothing Then
                Return
            End If
            Dim finalised = Posted OrElse String.Equals(Status, "Finalized", StringComparison.OrdinalIgnoreCase)
            Dim reviewCompleted = String.Equals(Status, "ReviewCompleted", StringComparison.OrdinalIgnoreCase)
            Dim recordSaved = IdNo > 0
            'These captions are assigned each time the workflow state is refreshed.
            'Use the translation service here instead of hard-coding English so a
            'state change cannot undo the form's current language.  Keep the
            'designer path database-free because it has no runtime translator.
            If System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then
                btnPost.Text = "Finalize"
                btnCompleteReview.Text = "Complete Review"
                btnReopenReview.Text = "Reopen Review"
            Else
                btnPost.Text = Messaging.TranslateCaption("Finalize")
                btnCompleteReview.Text = Messaging.TranslateCaption("Complete Review")
                btnReopenReview.Text = Messaging.TranslateCaption("Reopen Review")
            End If
            'btnEdit is disabled while the record is being edited. Workflow
            'actions are available only after the record has been saved.
            Dim recordIsSaved = btnEdit.Enabled
            btnPost.Enabled = recordSaved AndAlso reviewCompleted AndAlso Not finalised AndAlso recordIsSaved
            btnCompleteReview.Enabled = recordSaved AndAlso Not reviewCompleted AndAlso Not finalised AndAlso recordIsSaved
            btnReopenReview.Enabled = recordSaved AndAlso reviewCompleted AndAlso Not finalised AndAlso recordIsSaved
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

        'Private Sub HS_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs) Handles DataGridViewReconciliationItems.CellPainting
        '    If e.ColumnIndex > 0 AndAlso DataGridViewReconciliationItems.Columns(e.ColumnIndex).CellTemplate.[GetType]() = GetType(CDgvButtonCell) AndAlso e.RowIndex > -1 Then
        '        e.Handled = True
        '        Dim x = DataGridViewReconciliationItems.CurrentRow
        '        Dim s As String = If(x.DataBoundItem.Cleared, "Yes", "No")
        '        e.PaintBackground(e.CellBounds, DataGridViewReconciliationItems.CurrentCellAddress.Y = e.RowIndex)
        '        Dim sf As StringFormat = New StringFormat()
        '        sf.LineAlignment = StringAlignment.Center
        '        e.Graphics.DrawString(s, DataGridViewReconciliationItems.Font, New SolidBrush(DataGridViewReconciliationItems.ForeColor), e.CellBounds, sf)

        '    End If
        'End Sub

        'Private Sub CellPainting(ByVal sender As Object,
        '                         ByVal e As DataGridViewCellPaintingEventArgs) Handles DataGridViewReconciliationItems.CellPainting
        '    If (e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0) Then
        '        If TypeOf DataGridViewReconciliationItems.Columns(e.ColumnIndex) Is CDgvCheckBoxColumn Then
        '            Dim value = DirectCast(e.FormattedValue, Nullable(Of Boolean))
        '            If btnEdit.Enabled Or btnAdd.Enabled Then
        '                e.Paint(e.CellBounds, DataGridViewPaintParts.All And
        '                                      Not (DataGridViewPaintParts.ContentForeground))
        '                Dim state = IIf((value.HasValue And value.Value),
        '                                VisualStyles.CheckBoxState.CheckedDisabled,
        '                                VisualStyles.CheckBoxState.UncheckedDisabled)
        '                Dim size = RadioButtonRenderer.GetGlyphSize(e.Graphics, state)
        '                Dim location = New Point((e.CellBounds.Width - size.Width) / 2,
        '                                         (e.CellBounds.Height - size.Height) / 2)
        '                location.Offset(e.CellBounds.Location)
        '                CheckBoxRenderer.DrawCheckBox(e.Graphics, location, state)
        '                e.Handled = True
        '            End If
        '        End If
        '    End If
        'End Sub

        'Private Sub CellPainting(ByVal sender As Object,
        '                         ByVal e As DataGridViewCellPaintingEventArgs) Handles DataGridViewReconciliationItems.CellPainting
        '    If (e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0) Then
        '        If TypeOf DataGridViewReconciliationItems.Columns(e.ColumnIndex) Is CDgvCheckBoxColumn Then
        '            Dim value = DirectCast(e.FormattedValue, Nullable(Of Boolean))
        '            e.Paint(e.CellBounds, DataGridViewPaintParts.All And
        '                                  Not (DataGridViewPaintParts.ContentForeground))
        '            Dim state = IIf((value.HasValue And value.Value),
        '                            VisualStyles.CheckBoxState.CheckedNormal,
        '                            VisualStyles.CheckBoxState.MixedNormal)
        '            Dim size = RadioButtonRenderer.GetGlyphSize(e.Graphics, state)
        '            Dim location = New Point((e.CellBounds.Width - size.Width) / 2,
        '                                     (e.CellBounds.Height - size.Height) / 2)
        '            location.Offset(e.CellBounds.Location)
        '            CheckBoxRenderer.DrawCheckBox(e.Graphics, location, state)
        '            e.Handled = True
        '        End If
        '    End If
        'End Sub

        'Private Sub Dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewReconciliationItems.CellFormatting
        '    With DataGridViewReconciliationItems
        '        If e.Value IsNot Nothing Then
        '            Dim t As Type = .Columns(e.ColumnIndex).GetType()
        '            If TypeOf .Columns(e.ColumnIndex) Is CDgvCheckBoxColumn Then
        '                Dim x = DataGridViewReconciliationItems.CurrentRow
        '                Dim s As String = If(x.DataBoundItem.Cleared, "Yes", "No")
        '                Dim c As CDgvCheckBoxColumn = DataGridViewReconciliationItems.Columns(e.ColumnIndex)
        '                Dim w As CDgvCheckboxCell = DataGridViewReconciliationItems.Columns(e.ColumnIndex).CellTemplate
        '                If
        '                e.CellStyle.BackColor = System.Drawing.Color.Red
        '                'w.UseColumnTextForButtonValue = True
        '                'w.Value = s
        '                'c.Text = s
        '                'DirectCast(DataGridViewReconciliationItems.Columns(e.ColumnIndex), DataGridViewButtonColumn).Text = s
        '                'w.UseColumnTextForButtonValue = True
        '            End If
        '        End If
        '    End With
        'End Sub

        'Private Sub dgView_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridViewReconciliationItems.CellFormatting
        '    Dim dgBtn As CDgvButtonCell
        '    Dim dgView As CtDataGridView = DataGridViewReconciliationItems
        '    If (dgView.Columns(e.ColumnIndex).Name = "dgvCleared") Then
        '        dgBtn = CType(dgView.Rows(e.RowIndex).Cells(8), CDgvButtonCell)
        '        If (dgBtn.Value.ToString = "True") Then
        '            dgBtn.UseColumnTextForButtonValue = False
        '            dgView.CurrentCell = dgView.Rows(e.RowIndex).Cells(2)
        '            dgView.CurrentCell.ReadOnly = False
        '            dgBtn.Value = "Yes"
        '            dgView.CurrentCell.ReadOnly = True
        '        Else
        '            dgBtn.UseColumnTextForButtonValue = False
        '            dgView.CurrentCell = dgView.Rows(e.RowIndex).Cells(2)
        '            dgView.CurrentCell.ReadOnly = False
        '            dgBtn.Value = "No"
        '            dgView.CurrentCell.ReadOnly = True
        '        End If

        '    End If
        'End Sub

        'Private Sub Dgv_RowPostPaint(e As ) Handles DataGridViewReconciliationItems.RowPostPaint
        '    DataGridViewReconciliationItems.(DataGridViewReconciliationItems.Columns("Cleared").Index, e.RowIndex).Value = "Button " & (e.RowIndex + 1).ToString()
        'end sub

        'Private Sub DataGridViewReconciliationItems_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridViewReconciliationItems.RowsAdded
        '    if DataGridViewReconciliationItems.Columns(e.RowIndex).CellTemplate
        ''End Sub

        'Private Sub dgv_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewReconciliationItems.CellContentClick
        '    If e.RowIndex < 1 OrElse e.ColumnIndex = 0 Then Return
        '    Dim value = DataGridViewReconciliationItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        '    If value IsNot Nothing AndAlso value <> DBNull.Value Then DataGridViewReconciliationItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Not CBool(value)
        'End Sub

        'Private Sub dgv_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridViewReconciliationItems.CellFormatting
        '    If (DataGridViewReconciliationItems.Columns(e.ColumnIndex).Name = "dgvCleared") Then
        '        If e.RowIndex < 0 OrElse e.ColumnIndex = 0 Then Return
        '        Dim value = DataGridViewReconciliationItems.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        '        If value IsNot Nothing AndAlso value <> DBNull.Value Then e.Value = If(CBool(value), "-", "+")
        '    End If
        'End Sub

        Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
            DataGridViewReconciliationItems.FirstDisplayedScrollingRowIndex = 0
            DataGridViewReconciliationItems.Focus()
        End Sub

    End Class

End Namespace

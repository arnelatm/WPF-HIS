Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class DistributionSchemeEntryTv
        Implements IDistributionSchemeView, IDistributionSchemeItemsView

        Private ReadOnly _distributionSchemeItemsPresenter As DistributionSchemeItemsPresenter
        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _profitCentersByCode
        Private ReadOnly _profitCentersByName
        Private _distributionSchemeItems As List(Of DistributionSchemeItemModel)
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Set KeyPreview object to true to allow the form to process
            ' the key before the control with focus processes it.
            KeyPreview = True

            MainTableName = "DistributionScheme"
            TvMainFieldName = "DistributionSchemeName"
            TvSecondaryFieldName = "DistributionSchemeCode"
            SortOrderKey = "DistributionSchemeName"
            FirstControl = txtDistributionSchemeCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New DistributionSchemePresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

            _distributionSchemeItemsPresenter = New DistributionSchemeItemsPresenter(Me)

            PresenterObj.DistributionSchemeItemsPresenter = _distributionSchemeItemsPresenter

            DtInsertTable.Columns.Add("DistributionSchemeIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Sequence", GetType(Int32))
            DtInsertTable.Columns.Add("ProfitCenterIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Percentage", GetType(Decimal))

            DtUpdateTable.Columns.Add("IDNo", GetType(Int32))
            DtUpdateTable.Columns.Add("DistributionSchemeIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int32))
            DtUpdateTable.Columns.Add("ProfitCenterIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Percentage", GetType(Decimal))

            _profitCentersByCode = PresenterObj.GetProfitCenterListByCode()
            _profitCentersByName = PresenterObj.GetProfitCenterListByName()

            'CreateEnumResourceFile()

            'ResourceEnumConverter.MakeResource("DistributionSchemeTypeSelection", GetType(DistributionSchemeTypeSelection))
        End Sub

        '' The form will handle all key events before the control with
        '' focus handles them
        'Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        '    e.Handled = False
        'End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
            'ResourceEnumConverter.MakeResource("DistributionSchemeTypeSelection", GetType(DistributionSchemeTypeSelection))
            'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        End Sub

#Region "DistributionSchemeView"

        Public Property IdNo As Int32 Implements IDistributionSchemeView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIDNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property DistributionSchemeCode As String Implements IDistributionSchemeView.DistributionSchemeCode
            Get
                Return txtDistributionSchemeCode.Text
            End Get
            Set
                txtDistributionSchemeCode.Text = Value
            End Set
        End Property

        Public Property DistributionSchemeName As String Implements IDistributionSchemeView.DistributionSchemeName
            Get
                Return txtDistributionSchemeName.Text
            End Get
            Set
                txtDistributionSchemeName.Text = Value
            End Set
        End Property

        Public Property DistributionSchemeNameAra As String Implements IDistributionSchemeView.DistributionSchemeNameAra
            Get
                Return txtDistributionSchemeNameAra.Text
            End Get
            Set
                txtDistributionSchemeNameAra.Text = Value
            End Set
        End Property

        Public Property ValidityStartDate As Date? Implements IDistributionSchemeView.ValidityStartDate
            Get
                Return dtpValidityStartDate.Value
            End Get
            Set
                If Value Is Nothing Then
                    dtpValidityStartDate.Value = Date.Now()
                Else
                    dtpValidityStartDate.Value = Value
                End If
            End Set
        End Property

        Public Property ValidityEndDate As Date? Implements IDistributionSchemeView.ValidityEndDate
            Get
                Return dtpValidityEndDate.Value
            End Get
            Set
                If Value Is Nothing Then
                    dtpValidityEndDate.Value = Date.Now()
                Else
                    dtpValidityEndDate.Value = Value
                End If
            End Set
        End Property

        Public Property Notes As String Implements IDistributionSchemeView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property TotalPercentage As Decimal Implements IDistributionSchemeView.TotalPercentage
            Get
                Return txtTotalPercentage.Text
            End Get
            Set
                txtTotalPercentage.Text = Value
            End Set
        End Property

        Public Property IDistributionSchemeView_DistributionSchemeItems As List(Of DistributionSchemeItemView) Implements IDistributionSchemeView.DistributionSchemeItems

#End Region

#Region "DistributionSchemeItemsView"

        Public Property DistributionSchemeItemsDataSource As List(Of DistributionSchemeItemModel)

        Private Property DistributionSchemeItems As IList(Of DistributionSchemeItemModel) Implements IDistributionSchemeItemsView.DistributionSchemeItems
            Get
                Return _distributionSchemeItems
            End Get
            Set(value As IList(Of DistributionSchemeItemModel))
                _distributionSchemeItems = value
            End Set
        End Property

        Private Sub BindDistributionSchemeItem()
            bsDistributionSchemeItems.DataSource = DistributionSchemeItems
            bsDistributionSchemeItems.AllowNew = True

            With DataGridViewDistributionSchemeItems
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsDistributionSchemeItems
                .Refresh()
                .AllowUserToAddRows = True
            End With
            With DataGridViewDistributionSchemeItems.Columns
                dgvSequence.DisplayOnly = True
                dgvProfitCenterIdNo.DataSource = _profitCentersByCode
                dgvProfitCenterIdNo.DisplayMember = "Name"
                dgvProfitCenterIdNo.ValueMember = "idNo"
                dgvProfitCenterIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvProfitCenterIdNo.DisplayStyleForCurrentCellOnly = True
                dgvProfitCenterIdNo.AutoComplete = True
            End With
        End Sub

#End Region

        Protected Overrides Sub AddMandatoryFieldCheck()
            'Add controls one by one in error provider.
            MyErrorProvider.Controls.AddMandatory(txtDistributionSchemeCode, "DistributionScheme Code")
            MyErrorProvider.Controls.AddMandatory(txtDistributionSchemeName, "DistributionScheme Name in English")
            'Set summary error message
            MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
        End Sub

        Public Sub OnBeforeAdd() Handles MyBase.BeforeAdd
            dtpValidityStartDate.Value = Date.Now()
            dtpValidityEndDate.Value = Date.Now()
            bsDistributionSchemeItems.Clear()
            DataGridViewDistributionSchemeItems.Refresh()
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If bsDistributionSchemeItems Is Nothing OrElse bsDistributionSchemeItems.Count() = 0 Then
                If MessageBox.Show("Empty Distribution Scheme Not Allowed.", "Distribution Scheme Error",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    PresenterObj.CancelSave = True
                End If
            ElseIf Not DataIsValid() Then
                PresenterObj.CancelSave = True
            End If
        End Sub

        Private Sub OnInputsTurnedOn() Handles Me.InputsTurnedOn
            DataGridViewDistributionSchemeItems.StartTrackingChanges = True
            DataGridViewDistributionSchemeItems.AddInsertColumn()
        End Sub

        Private Sub OnInputsTurnedOff() Handles Me.InputsTurnedOff
            DataGridViewDistributionSchemeItems.StartTrackingChanges = False
            DataGridViewDistributionSchemeItems.RemoveInsertColumn()
        End Sub

        Public Sub OnParentRecordUpdatedSuccessfully(ByVal passedValue As Integer) Handles MyBase.ParentRecordUpdatedSuccessfully, MyBase.ParentRecordAddedSuccessfully
            If PresenterObj.AddMode Then
                IDNo = passedValue
            End If
            If DtInsertTable IsNot Nothing Then
                DtInsertTable.Clear()
            End If
            If DtUpdateTable IsNot Nothing Then
                DtUpdateTable.Clear()
            End If
            Dim nRowCount = 1
            For Each ji In bsDistributionSchemeItems
                Dim workRow As DataRow
                If ji.IdNo <= 0 Then
                    workRow = DtInsertTable.NewRow()
                Else
                    workRow = DtUpdateTable.NewRow()
                    workRow("IdNo") = ji.IdNo
                End If
                workRow("DistributionSchemeIdNo") = IDNo
                workRow("ProfitCenterIdNo") = ji.ProfitCenterIdNo
                workRow("Sequence") = nRowCount
                workRow("Percentage") = ji.Percentage
                If ji.IdNo <= 0 Then
                    DtInsertTable.Rows.Add(workRow)
                Else
                    DtUpdateTable.Rows.Add(workRow)
                End If
                nRowCount += 1
            Next
            _distributionSchemeItemsPresenter.Save(DtInsertTable, DtUpdateTable, IDNo)
        End Sub

        'Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewDistributionSchemeItems.CellBeginEdit
        '    With DataGridViewDistributionSchemeItems.CurrentCell
        '        Select Case .OwningColumn.Name.ToLower()
        '            Case "dgvprofitcenteridno"
        '                dgvProfitCenterIdNo.DisplayMember = "Name"
        '        End Select
        '    End With
        'End Sub

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDistributionSchemeItems.CellEndEdit
            With DataGridViewDistributionSchemeItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    'Case "dgvprofitcenteridno"
                    '    dgvProfitCenterIdNo.DisplayMember = "Name"
                    Case "dgvpercentage"
                        Dim amount = .Value
                        If amount <> 0 Then
                            Dim row = .OwningRow
                            Dim selectedRow As DistributionSchemeItemModel
                            selectedRow = DataGridViewDistributionSchemeItems.Rows(.RowIndex).DataBoundItem
                            If amount > 100 Or amount < 0 Then
                                selectedRow.Percentage = 0
                                MessageBox.Show("Percentage value must be between <1-100>.")
                            End If
                        End If
                        UpdateTotals()
                        'SendKeys.Send("{HOME}{DOWN}{ENTER}")
                End Select
            End With
        End Sub

        Private Sub UpdateTotals()
            txtTotalPercentage.Text = DistributionSchemeItems.Sum(Function(totals) totals.Percentage)
        End Sub

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
            Handles DataGridViewDistributionSchemeItems.CellClick
            With DataGridViewDistributionSchemeItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case "dgvdeletecolumn"
                        If PresenterObj.EditMode OrElse PresenterObj.AddMode Then
                            Dim row = .OwningRow
                            Dim selectedRow As New DistributionSchemeItemModel
                            selectedRow = DataGridViewDistributionSchemeItems.Rows(.RowIndex).DataBoundItem
                            bsDistributionSchemeItems.Remove(selectedRow)
                            ReSequenceDgvAfterDelete()
                            UpdateTotals()
                        Else
                            MessageBox.Show("Row deletion not allowed while in view mode. Press edit button to enable deletion.")
                        End If
                    Case "dgvinsertcolumn"
                        If PresenterObj.EditMode OrElse PresenterObj.AddMode Then
                            Dim row = .OwningRow
                            Dim newRow As New DistributionSchemeItemModel
                            bsDistributionSchemeItems.Insert(.RowIndex(), newRow)
                            ReSequenceDgvAfterInsert()
                            SendKeys.Send("{UP}")
                        Else
                            MessageBox.Show("Row insertion not allowed while in view mode. Press edit button to enable insertion.")
                        End If
                End Select
            End With
        End Sub

        '' PreviewKeyDown is where you preview the key.
        '' Do not put any logic here, instead use the
        '' KeyDown event after setting IsInputKey to true.
        'Private Sub button1_PreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs) Handles DataGridViewDistributionSchemeItems.PreviewKeyDown
        '    Select Case (e.KeyCode)
        '        Case Keys.Enter
        '            Dim x = 0
        '            x = x + 1
        '        Case Keys.Down, Keys.Up
        '            e.IsInputKey = True
        '    End Select
        'End Sub

        'Private Sub button2_PreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs) Handles Me.PreviewKeyDown
        '    Select Case (e.KeyCode)
        '        Case Keys.Enter
        '            Dim x = 0
        '            x = x + 1
        '        Case Keys.Down, Keys.Up
        '            e.IsInputKey = True
        '    End Select
        'End Sub

        Private Sub txtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            DataGridViewDistributionSchemeItems.Focus()
        End Sub

        Private Sub ReSequenceDgvAfterInsert()
            Dim i = DataGridViewDistributionSchemeItems.CurrentCell.RowIndex()
            For Each item In DistributionSchemeItems
                If item.Sequence = 0 Then
                    item.Sequence = i
                ElseIf item.Sequence >= i Then
                    item.Sequence = item.Sequence + 1
                End If
            Next
        End Sub

        Private Sub ReSequenceDgvAfterDelete()
            Dim i = DataGridViewDistributionSchemeItems.CurrentCell.RowIndex()
            For Each item In DistributionSchemeItems
                If item.Sequence > i Then
                    item.Sequence = item.Sequence - 1
                End If
            Next
        End Sub

        Public Sub OnAfterSave() Handles MyBase.AfterSave
            If PresenterObj.AddMode Then
                btnLast.PerformClick()
            End If
        End Sub

        'Private Sub DataGridViewDistributionSchemeItems_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridViewDistributionSchemeItems.KeyDown
        '    Dim x = 0
        '    x = x + 1
        'End Sub

        'Private Sub DataGridViewDistributionSchemeItems_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridViewDistributionSchemeItems.KeyPress
        '    Dim x = 0
        '    x = x + 1
        'End Sub

    End Class

End Namespace
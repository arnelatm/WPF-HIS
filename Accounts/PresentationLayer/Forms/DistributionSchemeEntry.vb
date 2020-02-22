Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Forms


    Public Class DistributionSchemeEntry
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

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "DistributionScheme"
            IdFieldName = "IdNo"
            SortOrderKey = "IdNo"
            FirstControl = txtDistributionSchemeCode
            _nfi.NumberDecimalDigits = 2
            PresenterObj = New DistributionSchemePresenter(Me)

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
        End Sub

        ' The form will handle all key events before the control with
        ' focus handles them
        Private Sub Form1_KeyDown(sender As Object,
                                  e As KeyEventArgs) Handles MyBase.KeyDown
            e.Handled = False
        End Sub

#Region "DistributionSchemeView"

        Public Property IdNo As Integer Implements IDistributionSchemeView.IdNo
            Get
                If TxtIDNo.Text <> "" Then
                    Return Convert.ToInt16(TxtIDNo.Text)
                Else
                    Return 0
                End If
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

#End Region

#Region "DistributionSchemeItemsView"

        Public Property DistributionSchemeItems As IList(Of DistributionSchemeItemModel) Implements IDistributionSchemeItemsView.DistributionSchemeItems
            Get
                Return _distributionSchemeItems
            End Get
            Set
                _distributionSchemeItems = Value
                BindDistributionSchemeItem()
            End Set
        End Property

        Public Property DistributionSchemeItemsDataSource As List(Of DistributionSchemeItemModel)

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
                dgvProfitCenterIdNo.DisplayMember = "Code"
                dgvProfitCenterIdNo.ValueMember = "idNo"
                dgvProfitCenterIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvProfitCenterIdNo.DisplayStyleForCurrentCellOnly = True
                dgvProfitCenterIdNo.AutoComplete = True
                dgvProfitCenterName.DataSource = _profitCentersByName
                dgvProfitCenterName.DisplayMember = "Name"
                dgvProfitCenterName.ValueMember = "idNo"
                dgvProfitCenterName.AutoComplete = True
                dgvProfitCenterName.DisplayStyleForCurrentCellOnly = True
            End With
        End Sub

#End Region

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
                    CancelSave = True
                End If
            ElseIf Not _distributionSchemeItemsPresenter.DataIsValid() Then
                CancelSave = True
            End If
        End Sub

        'Private Sub OnDisplayedRecordChanged() Handles MyBase.DisplayedRecordChanged
        '    If Not DataGridViewDistributionSchemeItems.DataBindings Is Nothing Then
        '        DataGridViewDistributionSchemeItems.DataInGridChanged = False
        '    End If
        'End Sub

        Private Sub OnInputsTurnedOn() Handles Me.InputsTurnedOn
            DataGridViewDistributionSchemeItems.StartTrackingChanges = True
            DataChangesMade = False
            'DataGridViewDistributionSchemeItems.AddDeleteColumn()
            DataGridViewDistributionSchemeItems.AddInsertColumn()
        End Sub

        Private Sub OnInputsTurnedOff() Handles Me.InputsTurnedOff
            DataGridViewDistributionSchemeItems.StartTrackingChanges = False
            'DataGridViewDistributionSchemeItems.RemoveDeleteColumn()
            DataGridViewDistributionSchemeItems.RemoveInsertColumn()
        End Sub

        Private Sub DataGridViewDistributionSchemeItems_ChangesMade(sender As Object, e As EventArgs) Handles DataGridViewDistributionSchemeItems.ChangesMade
            DataChangesMade = True
        End Sub

        Public Sub OnParentRecordUpdatedSuccessfully(passedValue As Integer) _
            Handles MyBase.ParentRecordUpdatedSuccessfully, MyBase.ParentRecordAddedSuccessfully

            If AddMode Then
                IdNo = passedValue
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
                workRow("DistributionSchemeIdNo") = IdNo
                workRow("DistributionSchemeIdNo") = passedValue
                workRow("Sequence") = nRowCount
                workRow("Percentage") = ji.Percentage
                If ji.IdNo <= 0 Then
                    DtInsertTable.Rows.Add(workRow)
                Else
                    DtUpdateTable.Rows.Add(workRow)
                End If
                nRowCount += 1
            Next
            _distributionSchemeItemsPresenter.Save(DtInsertTable, DtUpdateTable, IdNo)
        End Sub

        Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewDistributionSchemeItems.CellBeginEdit
            With DataGridViewDistributionSchemeItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case "dgvprofitcenteridno"
                        dgvProfitCenterIdNo.DisplayMember = "Name"
                    Case "dgvprofitcentername"
                        dgvProfitCenterName.DisplayMember = "Code"
                End Select
            End With
        End Sub

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) _
            Handles DataGridViewDistributionSchemeItems.CellEndEdit
            With DataGridViewDistributionSchemeItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case "dgvprofitcenteridno"
                        dgvProfitCenterIdNo.DisplayMember = "Code"
                        SendKeys.Send("{TAB}")
                    Case "dgvprofitcentername"
                        dgvProfitCenterName.DisplayMember = "Name"
                        ' repaint grid to reflect changes in the dgvProfitCenterIdNo
                        '(this column and dgvProfitCenterIdNo have the same source so any changes here must be reflected there)
                        DataGridViewDistributionSchemeItems.Refresh()
                    Case "dgvpercentage"
                        Dim amount = .Value
                        If amount <> 0 Then
                            Dim selectedRow As DistributionSchemeItemModel
                            selectedRow = DataGridViewDistributionSchemeItems.Rows(.RowIndex).DataBoundItem
                            If amount > 100 Or amount < 0 Then
                                selectedRow.Percentage = 0
                                MessageBox.Show("Percentage value must be between <1-100>.")
                            End If
                        End If
                        txtTotalPercentage.Text = DistributionSchemeItems.Sum(Function(totals) totals.Percentage)
                        SendKeys.Send("{TAB}")
                End Select
            End With
        End Sub

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
            Handles DataGridViewDistributionSchemeItems.CellClick
            With DataGridViewDistributionSchemeItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case "dgvdeletecolumn"
                        If EditMode OrElse AddMode Then
                            Dim selectedRow As New DistributionSchemeItemModel
                            DataChangesMade = True
                            selectedRow = DataGridViewDistributionSchemeItems.Rows(.RowIndex).DataBoundItem
                            bsDistributionSchemeItems.Remove(selectedRow)
                            ReSequenceDgvAfterDelete()
                            txtTotalPercentage.Text = DistributionSchemeItems.Sum(Function(totals) totals.Percentage)
                        Else
                            MessageBox.Show("Row deletion not allowed while in view mode. Press edit button to enable deletion.")
                        End If
                    Case "dgvinsertcolumn"
                        DataChangesMade = True
                        If EditMode OrElse AddMode Then
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
            If AddMode Then
                BtnLast.PerformClick()
            End If
        End Sub

    End Class
End NameSpace
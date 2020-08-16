Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.CustomControlsLibrary

Namespace PresentationLayer.Forms

    Public Class DistributionSchemeEntry
        Implements IDistributionSchemeView

        Private ReadOnly _distributionSchemeItemsPresenter As DistributionSchemeItemsPresenter
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _revCostCenterByCode
        Private _footer As DgvFooter
        Private _revCostCenterByName
        Private _totalPercentage As Decimal
        Private _distributionSchemeItems As List(Of DistributionSchemeItemView)

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Set KeyPreview object to true to allow the form to process
            ' the key before the control with focus processes it.
            KeyPreview = True

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "DistributionScheme"
            SortOrderKey = "IdNo"
            FirstControl = txtDistributionSchemeCode
            _nfi.NumberDecimalDigits = 2
            PresenterObj = New DistributionSchemePresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

#Region "DistributionSchemeView"

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

        Public Property IdNo As Int32 Implements IDistributionSchemeView.IdNo
            Get
                If TxtIdNo.Text <> "" Then
                    Return Convert.ToInt16(TxtIdNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
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
                Return _totalPercentage
            End Get
            Set
                _totalPercentage = Value
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

        Public Property DistributionSchemeitems As List(Of DistributionSchemeItemView) Implements IDistributionSchemeView.DistributionSchemeItems
            Get
                Return _distributionSchemeItems
            End Get
            Set
                _distributionSchemeItems = Value
                BindDistributionSchemeItem()
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            _revCostCenterByCode = PresenterObj.GetRevCostCenterListByCode()
            _revCostCenterByName = PresenterObj.GetRevCostCenterListByName()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"DistributionSchemeCode", txtDistributionSchemeCode},
         {"DistributionSchemeName", txtDistributionSchemeName},
         {"DistributionSchemeNameAra", txtDistributionSchemeNameAra},
         {"IdNo", TxtIdNo},
         {"Notes", txtNotes},
         {"ValididtyEndDate", dtpValidityEndDate},
         {"ValidityStartDate", dtpValidityStartDate}
        }
        End Sub

        Protected Overrides Sub RecordPositionChanged()
            MyBase.RecordPositionChanged()
            UpdateTotals()
        End Sub

        Private Sub BindDistributionSchemeItem()
            SuspendLayout()
            bsDistributionSchemeItems.DataSource = DistributionSchemeitems
            bsDistributionSchemeItems.AllowNew = True
            With DataGridViewDistributionSchemeItems
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsDistributionSchemeItems
                .Refresh()
                .AllowUserToAddRows = True
                .AllowUserToDeleteRows = True
            End With
            With DataGridViewDistributionSchemeItems.Columns
                dgvSequence.DisplayOnly = True
                dgvRevCostCenterIdNo.DataSource = _revCostCenterByCode
                dgvRevCostCenterIdNo.DisplayMember = "Code"
                dgvRevCostCenterIdNo.ValueMember = "idNo"
                dgvRevCostCenterIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvRevCostCenterIdNo.DisplayStyleForCurrentCellOnly = True
                dgvRevCostCenterIdNo.AutoComplete = True
            End With
            ResumeLayout()
        End Sub

        Private Sub OnUserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewDistributionSchemeItems.UserDeletedRow
            ReSequenceDgvAfterDelete()
            UpdateTotals()
        End Sub

        Private Overloads Sub Dispose()
            _footer.Dispose()
        End Sub

        'Private Sub GeneralJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '    _footer = New DgvFooter(Me.DataGridViewDistributionSchemeItems)
        '    _footer.AutoCalc = True
        '    _footer.ColumnToSum("dgvPercentage") = True
        '    _footer.SetAlignment("dgvPercentage", ContentAlignment.MiddleRight)
        '    _footer.SetText("DgvRevCostCenterIdNo", "Totals ->")
        'End Sub

        Private Sub OnInputsTurnedOff() Handles Me.InputsTurnedOff
            DataGridViewDistributionSchemeItems.RemoveInsertColumn()
        End Sub

        Private Sub OnInputsTurnedOn() Handles Me.InputsTurnedOn
            DataGridViewDistributionSchemeItems.AddInsertColumn()
        End Sub

        Private Sub ReSequenceDgvAfterDelete()
            Dim i = DataGridViewDistributionSchemeItems.CurrentCell.RowIndex()
            For Each item In DistributionSchemeitems
                If item.Sequence > i + 1 Then
                    item.Sequence = item.Sequence - 1
                End If
            Next
        End Sub

        Private Sub ReSequenceDgvAfterInsert()
            Dim i = DataGridViewDistributionSchemeItems.CurrentCell.RowIndex()
            For Each item In DistributionSchemeitems
                If item.Sequence = 0 Then
                    item.Sequence = i
                ElseIf item.Sequence >= i Then
                    item.Sequence = item.Sequence + 1
                End If
            Next
        End Sub

        Private Sub txtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            If DataGridViewDistributionSchemeItems IsNot Nothing Then
                DataGridViewDistributionSchemeItems.Focus()
            End If
        End Sub

        Private Sub UpdateTotals()
            If _footer IsNot Nothing Then
                _footer.SumAllColumns()
                TotalPercentage = _footer.Value("dgvPercentage")
            End If
        End Sub

        Protected Overrides Sub RecordAdded()
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

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
                    Handles DataGridViewDistributionSchemeItems.CellClick
            With DataGridViewDistributionSchemeItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case "dgvdeletecolumn"
                        If PresenterObj.EditMode OrElse PresenterObj.AddMode Then
                            Dim selectedRow As New DistributionSchemeItemModel
                            selectedRow = DataGridViewDistributionSchemeItems.Rows(.RowIndex).DataBoundItem
                            bsDistributionSchemeItems.Remove(selectedRow)
                            ReSequenceDgvAfterDelete()
                            TotalPercentage = DistributionSchemeitems.Sum(Function(totals) totals.Percentage)
                        Else
                            MessageBox.Show("Row deletion not allowed while in view mode. Press edit button to enable deletion.")
                        End If
                    Case "dgvinsertcolumn"
                        If PresenterObj.EditMode OrElse PresenterObj.AddMode Then
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

        'Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewDistributionSchemeItems.CellBeginEdit
        '    With DataGridViewDistributionSchemeItems.CurrentCell
        '        Select Case .OwningColumn.Name.ToLower()
        '            Case "dgvRevCostCenterIdNo"
        '                dgvRevCostCenterIdNo.DisplayMember = "Name"
        '            Case "dgvRevCostCenterName"
        '                dgvRevCostCenterName.DisplayMember = "Code"
        '        End Select
        '    End With
        'End Sub

        'Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) _
        '    Handles DataGridViewDistributionSchemeItems.CellEndEdit
        '    With DataGridViewDistributionSchemeItems.CurrentCell
        '        Select Case .OwningColumn.Name.ToLower()
        '            Case "dgvRevCostCenterIdNo"
        '                dgvRevCostCenterIdNo.DisplayMember = "Code"
        '                SendKeys.Send("{TAB}")
        '            Case "dgvRevCostCenterName"
        '                dgvRevCostCenterName.DisplayMember = "Name"
        '                ' repaint grid to reflect changes in the dgvRevCostCenterIdNo
        '                '(this column and dgvRevCostCenterIdNo have the same source so any changes here must be reflected there)
        '                DataGridViewDistributionSchemeItems.Refresh()
        '            Case "dgvpercentage"
        '                Dim amount = .Value
        '                If amount <> 0 Then
        '                    Dim selectedRow As DistributionSchemeItemModel
        '                    selectedRow = DataGridViewDistributionSchemeItems.Rows(.RowIndex).DataBoundItem
        '                    If amount > 100 Or amount < 0 Then
        '                        selectedRow.Percentage = 0
        '                        MessageBox.Show("Percentage value must be between <1-100>.")
        '                    End If
        '                End If
        '                TotalPercentage = DistributionSchemeitems.Sum(Function(totals) totals.Percentage)
        '                SendKeys.Send("{TAB}")
        '        End Select
        '    End With
        'End Sub

    End Class

End Namespace
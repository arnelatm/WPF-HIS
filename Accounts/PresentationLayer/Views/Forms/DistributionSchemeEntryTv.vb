Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class DistributionSchemeEntryTv
        Implements IDistributionSchemeView, IDistributionSchemeItemsView

        Private ReadOnly _distributionSchemeItemsPresenter As DistributionSchemeItemsPresenter
        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _revCostCenterByCode

        'Private ReadOnly _revCostCenterByName
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
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))
            DtInsertTable.Columns.Add("RevCostCenterIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Percentage", GetType(Decimal))

            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("DistributionSchemeIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))
            DtUpdateTable.Columns.Add("RevCostCenterIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Percentage", GetType(Decimal))

            _revCostCenterByCode = PresenterObj.GetLookup("RevCostCenter")

        End Sub

#Region "DistributionSchemeView"

        Public Property IdNo As Int32 Implements IDistributionSchemeView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
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

        Public Property DistributionSchemeItems As IList(Of DistributionSchemeItemModel) Implements IDistributionSchemeItemsView.DistributionSchemeItems
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
                dgvRevCostCenterIdNo.DataSource = _revCostCenterByCode
                dgvRevCostCenterIdNo.DisplayMember = "Name"
                dgvRevCostCenterIdNo.ValueMember = "idNo"
                dgvRevCostCenterIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvRevCostCenterIdNo.DisplayStyleForCurrentCellOnly = True
                dgvRevCostCenterIdNo.AutoComplete = True
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

        Protected Overrides Sub InputsTurnedOn()
            If PresenterObj.AddMode Then
                dtpValidityStartDate.Value = Date.Now()
                dtpValidityEndDate.Value = Date.Now()
                bsDistributionSchemeItems.Clear()
                DataGridViewDistributionSchemeItems.Refresh()
            End If
        End Sub

        'Public Sub OnParentRecordUpdatedSuccessfully(ByVal passedValue As Integer) Handles MyBase.RecordUpdatedSuccessfully, MyBase.RecordAddedSuccessfully
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
        '    For Each ji In bsDistributionSchemeItems
        '        Dim workRow As DataRow
        '        If ji.IdNo <= 0 Then
        '            workRow = DtInsertTable.NewRow()
        '        Else
        '            workRow = DtUpdateTable.NewRow()
        '            workRow("IdNo") = ji.IdNo
        '        End If
        '        workRow("DistributionSchemeIdNo") = IdNo
        '        workRow("RevCostCenterIdNo") = ji.RevCostCenterIdNo
        '        workRow("Sequence") = nRowCount
        '        workRow("Percentage") = ji.Percentage
        '        If ji.IdNo <= 0 Then
        '            DtInsertTable.Rows.Add(workRow)
        '        Else
        '            DtUpdateTable.Rows.Add(workRow)
        '        End If
        '        nRowCount += 1
        '    Next
        '    _distributionSchemeItemsPresenter.Save(DtInsertTable, DtUpdateTable, IdNo)
        'End Sub

        'Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewDistributionSchemeItems.CellBeginEdit
        '    With DataGridViewDistributionSchemeItems.CurrentCell
        '        Select Case .OwningColumn.Name.ToLower()
        '            Case "dgvRevCostCenterIdNo"
        '                dgvRevCostCenterIdNo.DisplayMember = "Name"
        '        End Select
        '    End With
        'End Sub

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDistributionSchemeItems.CellEndEdit
            With DataGridViewDistributionSchemeItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    'Case "dgvRevCostCenterIdNo"
                    '    dgvRevCostCenterIdNo.DisplayMember = "Name"
                    Case "dgvpercentage"
                        Dim amount = .Value
                        If amount <> 0 Then
                            Dim row = .OwningRow
                            Dim selectedRow As DistributionSchemeItemModel
                            selectedRow = DataGridViewDistributionSchemeItems.Rows(.RowIndex).DataBoundItem
                            If amount > 100 Or amount < 0 Then
                                selectedRow.Percentage = 0
                                AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgInvalidPercentageRange")
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

        Private Sub txtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            If DataGridViewDistributionSchemeItems IsNot Nothing Then
                DataGridViewDistributionSchemeItems.Focus()
            End If
        End Sub

        Protected Overrides Sub RecordSaved(ByRef e As RecordSaved)
            MyBase.RecordSaved(e)
            If PresenterObj.AddMode Then
                btnLast.PerformClick()
            End If
        End Sub

    End Class

End Namespace
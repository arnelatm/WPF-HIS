Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.PresentationLayer.Events

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

        Public Property DistributionSchemeItems As List(Of DistributionSchemeItemView) Implements IDistributionSchemeView.DistributionSchemeItems
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
         {"ValidityEndDate", dtpValidityEndDate},
         {"ValidityStartDate", dtpValidityStartDate}
        }
        End Sub

        Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
            UpdateTotals()
        End Sub

        Private Sub BindDistributionSchemeItem()
            SuspendLayout()
            bsDistributionSchemeItems.DataSource = DistributionSchemeItems
            bsDistributionSchemeItems.AllowNew = True
            With DataGridViewDistributionSchemeItems
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsDistributionSchemeItems
                .Refresh()
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
            UpdateTotals()
        End Sub

        Private Overloads Sub Dispose()
            _footer.Dispose()
        End Sub

        Protected Overrides Sub InputsTurnedOn()
            If PresenterObj.AddMode Then
                dtpValidityStartDate.Value = Date.Now()
                dtpValidityEndDate.Value = Date.Now()
                bsDistributionSchemeItems.Clear()
                DataGridViewDistributionSchemeItems.Refresh()
            End If
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

    End Class

End Namespace
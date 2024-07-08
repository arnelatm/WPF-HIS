Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Forms

    Public Class ReportSelectorForm
        Implements IReportSelectorView

        Private _reportList As New List(Of IReportView)
        Private _reportGroupList As New List(Of IReportGroupView)

        Public Event PrintReportEvent(reportIdNo As Int16) Implements IReportSelectorView.PrintReportEvent
        Public Event SelectedReportGroupChangedEvent(ByRef bsReportGroupList As BindingSource, ByRef bsReportList As BindingSource) Implements IReportSelectorView.SelectedReportGroupChangedEvent

        Public Sub New() ' reportGroupParam As String)
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            Me.Text = Messaging.TranslateCaption("Report Selector")
        End Sub

#Region "Field Items"

        Public Property ReportList As List(Of IReportView) Implements IReportSelectorView.ReportList
            Get
                Return _reportList
            End Get
            Set
                _reportList = Value
                bsReportList.DataSource = Value
                bsReportList.ResetBindings(False)
            End Set
        End Property

        Public Property ReportGroupList As List(Of IReportGroupView) Implements IReportSelectorView.ReportGroupList
            Get
                Return _reportGroupList
            End Get
            Set
                _reportGroupList = Value
            End Set
        End Property
        Public Property ViewDisplayName As String Implements IViewNew.ViewDisplayName
        Public Property ReportFileName As String Implements IReportSelectorView.ReportFileName

#End Region

        Private Sub ReportSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            SetupDataGrids()
        End Sub

        Private Sub SetupDataGrids()
            With DataGridViewReportGroupList
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
            End With
            With DataGridViewReportList
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
            End With
            With DataGridViewReportList.Columns
                dgvIdNo.DisplayOnly = True
            End With
            SetupGridDataBindings()
        End Sub

        Private Sub SetupGridDataBindings()
            bsReportGroupList.DataSource = ReportGroupList
            bsReportList.DataSource = ReportList
        End Sub

        Private Sub DataGridViewReportList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewReportList.CellDoubleClick
            Dim _idNo = DataGridViewReportList.Rows(e.RowIndex).Cells("dgvIdNo").Value
            RaiseEvent PrintReportEvent(_idNo)
        End Sub

        Private Sub DataGridViewReportGroupList_Click(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewReportGroupList.CellClick, DataGridViewReportGroupList.CellEnter
            If e.RowIndex < 0 Then
                ' do nothing
            Else
                RaiseEvent SelectedReportGroupChangedEvent(bsReportGroupList, bsReportList) ',GetReportGroupIdNo())
                bsReportList.DataSource = ReportList
            End If
            DataGridViewReportList.Refresh()
        End Sub

    End Class

End Namespace
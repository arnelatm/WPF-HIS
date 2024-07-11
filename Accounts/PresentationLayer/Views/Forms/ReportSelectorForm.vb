Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class ReportSelectorForm
        Implements IReportSelectorView

        Private _reportList As New List(Of IReportView)
        Private _reportGroupList As New List(Of IReportGroupView)

        Public Event PrintReportEvent(bsReportList As BindingSource) Implements IReportSelectorView.PrintReportEvent
        Public Event SelectedReportGroupChangedEvent(ByRef bsReportGroupList As BindingSource, ByRef bsReportList As BindingSource) Implements IReportSelectorView.SelectedReportGroupChangedEvent

        Public Sub New()
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
            RaiseEvent PrintReportEvent(bsReportList)
        End Sub

        Private Sub DataGridViewReportGroupList_Click(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewReportGroupList.CellClick, DataGridViewReportGroupList.CellEnter
            RaiseEvent SelectedReportGroupChangedEvent(bsReportGroupList, bsReportList)
        End Sub

    End Class

End Namespace
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Forms

    Public Class ReportSelectorForm
        Implements IReportSelectorView

        Private _reportList As New List(Of IReportView)
        Private _reportGroupList As New List(Of IReportGroupView)
        Private _idNo As Int32
        Private _reportGroupIdNo As Int32
        Private ReadOnly _sReportGroup As String

        Public Event ReportDoubleClickEvent(reportIdNo As Int16) Implements IReportSelectorView.ReportDoubleClickEvent
        Public Event ReportGroupClickEvent(reportIdNo As Int16) Implements IReportSelectorView.ReportGroupClickEvent

        Public Sub New(reportGroupParam As String)
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            Me.Text = Messaging.TranslateCaption("Report Selector")
            _sReportGroup = reportGroupParam
        End Sub

#Region "Field Items"

        Private Property ReportList As List(Of IReportView) Implements IReportSelectorView.ReportList
            Get
                Return _reportList
            End Get
            Set
                _reportList = Value
                BindReportList()
            End Set
        End Property

        Public Property ReportGroupList As List(Of IReportGroupView) Implements IReportSelectorView.ReportGroupList
            Get
                Return _reportGroupList
            End Get
            Set
                _reportGroupList = Value
                BindReportGroupList()
            End Set
        End Property

        Public Property ViewDisplayName As String Implements IViewNew.ViewDisplayName
        Public Property ReportFileName As String Implements IReportSelectorView.ReportFileName

#End Region


        Private Sub BindReportList()
            SuspendLayout()
            bsReportList.DataSource = Nothing
            DataGridViewReportList.Refresh()
            bsReportList.DataSource = ReportList
            bsReportList.AllowNew = True
            With DataGridViewReportList
                .AutoGenerateColumns = False
                .DataSource = bsReportList
            End With
            With DataGridViewReportList.Columns
                dgvIdNo.DisplayOnly = True
            End With
            ResumeLayout()
        End Sub

        Private Sub BindReportGroupList()
            SuspendLayout()
            bsReportGroupList.DataSource = Nothing
            DataGridViewReportGroupList.Refresh()
            bsReportGroupList.DataSource = ReportGroupList
            bsReportGroupList.AllowNew = True
            With DataGridViewReportGroupList
                .AutoGenerateColumns = False
                .DataSource = bsReportGroupList
            End With
            ResumeLayout()
        End Sub

        Private Sub ReportSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            DataGridViewReportList.Refresh()
            DataGridViewReportGroupList.Refresh()
            BindReportList()
            BindReportGroupList()
        End Sub

        Private Sub ReportSelector_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            bsReportList.ResetBindings(True)
            bsReportGroupList.ResetBindings(True)
            'PublishClickedButton(ButtonClicked.Edit)
        End Sub

        Private Sub DataGridViewReportList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewReportList.CellDoubleClick
            _idNo = DataGridViewReportList.Rows(e.RowIndex).Cells("dgvIdNo").Value
            RaiseEvent ReportDoubleClickEvent(_idNo)
        End Sub

        Private Sub DataGridViewReportGroupList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewReportGroupList.CellClick
            If e.RowIndex < 0 Then
                ' do nothing
            Else
                _reportGroupIdNo = DataGridViewReportGroupList.Rows(e.RowIndex).Cells("dgvReportGroupIdNo").Value
                RaiseEvent ReportGroupClickEvent(_reportGroupIdNo)
                BindReportList()
            End If

        End Sub

    End Class

End Namespace
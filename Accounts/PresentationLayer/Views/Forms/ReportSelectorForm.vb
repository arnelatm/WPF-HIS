Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Forms

    Public Class ReportSelectorForm
        Implements IReportSelectorView

        Private _reportList As New List(Of IReportView)
        Private _reportGroupList As New List(Of IReportGroupView)
        Private _idNo As Int32
        Private _reportGroupIdNo As Int32

        Public Event ReportDoubleClickEvent(reportIdNo As Int16) Implements IReportSelectorView.ReportDoubleClickEvent
        Public Event ReportGroupClickEvent(reportIdNo As Int16) Implements IReportSelectorView.ReportGroupClickEvent
        Public Event ReportGroupBindingEvent(sender As Object) Implements IReportSelectorView.ReportGroupBindingEvent
        Public Event ReportListBindingEvent(sender As Object) Implements IReportSelectorView.ReportListBindingEvent

        Public Sub New(reportGroupParam As String)
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            Me.Text = Messaging.TranslateCaption("Report Selector")
        End Sub

#Region "Field Items"

        Private Property ReportList As List(Of IReportView) Implements IReportSelectorView.ReportList
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
        Public Property ViewDisplayName As String Implements IViewNew.ViewDisplayName
        Public Property ReportFileName As String Implements IReportSelectorView.ReportFileName

#End Region


        Private Sub BindReportList()
            With DataGridViewReportList
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
            End With
            With DataGridViewReportList.Columns
                dgvIdNo.DisplayOnly = True
            End With
            RaiseEvent ReportListBindingEvent(DataGridViewReportList)
        End Sub


        Private Sub BindReportGroup()
            With DataGridViewReportGroupList
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
            End With
            RaiseEvent ReportGroupBindingEvent(DataGridViewReportGroupList)
        End Sub

        Private Sub ReportSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            DataGridViewReportList.Refresh()
            DataGridViewReportGroupList.Refresh()
            BindReportList()
            BindReportGroup()
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
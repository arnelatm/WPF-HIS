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

        Public Event PrintReportEvent(reportIdNo As Int16) Implements IReportSelectorView.PrintReportEvent
        Public Event ReportGroupSelected(reportIdNo As Int16) Implements IReportSelectorView.ReportGroupSelected
        'Public Event ReportGroupBindingEvent(sender As Object) Implements IReportSelectorView.ReportGroupBindingEvent
        ' Event ReportListBindingEvent(sender As Object) Implements IReportSelectorView.ReportListBindingEvent

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
                bsReportGroupList.DataSource = Value
                bsReportList.ResetBindings(False)
            End Set
        End Property
        Public Property ReportGroupList As List(Of IReportGroupView) Implements IReportSelectorView.ReportGroupList
            Get
                Return _reportGroupList
            End Get
            Set
                _reportGroupList = Value
                bsReportGroupList.DataSource = Value
                bsReportGroupList.ResetBindings(False)
            End Set
        End Property
        Public Property ViewDisplayName As String Implements IViewNew.ViewDisplayName
        Public Property ReportFileName As String Implements IReportSelectorView.ReportFileName

#End Region

        Private Sub ReportSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            'BindReportGroup()
            'BindReportList()
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
            bsReportGroupList.DataSource = ReportGroupList
            bsReportList.DataSource = ReportList
            'DataGridViewReportGroupList.DataSource = bsReportGroupList
            'DataGridViewReportList.DataSource = bsReportList
            DataGridViewReportList.Refresh()
            DataGridViewReportGroupList.Refresh()
        End Sub


        Private Sub DataGridViewReportList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewReportList.CellDoubleClick
            _idNo = DataGridViewReportList.Rows(e.RowIndex).Cells("dgvIdNo").Value
            RaiseEvent PrintReportEvent(_idNo)
        End Sub

        'Private Sub BindReportGroup()
        '    With DataGridViewReportGroupList
        '        .AutoGenerateColumns = False
        '        .AllowUserToAddRows = False
        '    End With
        '    'bsReportGroupList.DataSource = ReportGroupList
        '    RaiseEvent ReportGroupSelected(GetReportGroupIdNo)
        'End Sub

        'Private Sub BindReportList()
        '    With DataGridViewReportList
        '        .AutoGenerateColumns = False
        '        .AllowUserToAddRows = False
        '    End With
        '    With DataGridViewReportList.Columns
        '        dgvIdNo.DisplayOnly = True
        '    End With
        '    'DataGridViewReportGroupList.DataSource = ReportGroupList
        '    bsReportList.DataSource = ReportList
        '    DataGridViewReportList.Refresh()
        '    'RaiseEvent ReportListBindingEvent(DataGridViewReportList)
        'End Sub


        Private Sub DataGridViewReportGroupList_Click(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewReportGroupList.CellClick
            If e.RowIndex < 0 Then
                ' do nothing
            Else
                '_reportGroupIdNo = GetReportGroupIdNo()
                RaiseEvent ReportGroupSelected(GetReportGroupIdNo())
                DataGridViewReportList.DataSource = ReportList
            End If
            DataGridViewReportList.Refresh()
        End Sub

        Private Function GetReportGroupIdNo() As Integer
            Dim selectedReportIdNo As Int16 = 0
            If bsReportGroupList.Current IsNot Nothing Then
                selectedReportIdNo = bsReportGroupList.Current.IdNo ' DataGridViewReportGroupList.Rows(e.RowIndex).Cells("dgvReportGroupIdNo").Value
            End If
            Return selectedReportIdNo
        End Function
    End Class

End Namespace
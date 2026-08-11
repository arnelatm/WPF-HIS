Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class ReportSelectorForm
        Implements IReportSelectorView

        Private _reportList As New List(Of IReportView)
        Private _reportGroupList As New List(Of IReportGroupView)
        Private ReadOnly _sReportGroup As String

        Public Event ReportDoubleClickEvent(reportIdNo As Int16) Implements IReportSelectorView.ReportDoubleClickEvent
        Public Event ReportGroupDoubleClickEvent(reportIdNo As Int16) Implements IReportSelectorView.ReportGroupDoubleClickEvent

        Public Sub New(reportGroupParam As String)
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            Me.Text = Messaging.TranslateCaption("Report Selector")
            FormToolStrip.Visible = False
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

        Public Property IdNo As Int16 Implements IReportSelectorView.IdNo
        Public Property QueryForm As String Implements IReportSelectorView.QueryForm
        Public Property ReportCode As String Implements IReportSelectorView.ReportCode
        Public Property ReportFileName As String Implements IReportSelectorView.ReportFileName
        Public Property ReportGroupIdNo As Int16 Implements IReportSelectorView.ReportGroupIdNo
        Private Property IReportSelectorView_ReportName As String Implements IReportSelectorView.ReportName
        Public Property ReportNameAra As String Implements IReportSelectorView.ReportNameAra
        Public Property ReportTitle As String Implements IReportSelectorView.ReportTitle
        Public Property ReportTitleAra As String Implements IReportSelectorView.ReportTitleAra
        Public Property QueryFormParameters As String Implements IReportView.QueryFormParameters
        Public Property QueryParameters As String Implements IReportView.QueryParameters
        Public Property PrintJobIdNo As Short Implements IReportView.PrintJobIdNo
        Public Property Active As Boolean Implements IReportView.Active
        Public Property BranchIdNo As Short Implements IReportView.BranchIdNo
        Public Property DateCreated As Date Implements IReportView.DateCreated
        Public Property DatabaseName As String Implements IReportView.DatabaseName


#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {}
        End Sub

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
            BackgroundImage = Global.AATM.Libraries.GlobalResources.My.Resources.Resources.EntryFormBackground
            DataGridViewReportList.Refresh()
            DataGridViewReportGroupList.Refresh()
            BindReportList()
            BindReportGroupList()
        End Sub

        Private Sub ReportSelector_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            bsReportList.ResetBindings(True)
            bsReportGroupList.ResetBindings(True)
            PublishClickedButton(ButtonClicked.Edit)
        End Sub

        Private Sub DataGridViewReportList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewReportList.CellDoubleClick
            IdNo = DataGridViewReportList.Rows(e.RowIndex).Cells("dgvIdNo").Value
            RaiseEvent ReportDoubleClickEvent(IdNo)
        End Sub

        Private Sub DataGridViewReportGroupList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewReportGroupList.CellClick
            If e.RowIndex < 0 Then
                ' do nothing
            Else
                ReportGroupIdNo = DataGridViewReportGroupList.Rows(e.RowIndex).Cells("dgvReportGroupIdNo").Value
                RaiseEvent ReportGroupDoubleClickEvent(ReportGroupIdNo)
                BindReportList()
            End If

        End Sub

    End Class

End Namespace

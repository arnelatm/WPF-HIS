Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class ReportSelector
        Implements IEmployeeIdListView

        Private _employeeIdList As New List(Of EmployeeIdView)

        Public Event ClearAllEmployee(sender As Object, clear As Boolean) Implements IEmployeeIdListView.ClearAllEmployee

        'Public Event EmployeeIdCheckedEvent(sender As Object) Implements IEmployeeIdListView.EmployeeIdCheckedEvent

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            Me.Text = Messaging.TranslateCaption("Employee I.D. Printing")
            btnEdit.Visible = False
        End Sub

#Region "Field Items"

        Private Property EmployeeIdList As List(Of EmployeeIdView) Implements IEmployeeIdListView.EmployeeIdList
            Get
                Return _employeeIdList
            End Get
            Set
                _employeeIdList = Value
                BindEmployeeIdList()
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {}
        End Sub

        Private Sub BindEmployeeIdList()
            SuspendLayout()
            bsEmployeeIdList.DataSource = Nothing
            DataGridViewEmployeeIdList.Refresh()
            bsEmployeeIdList.DataSource = EmployeeIdList
            bsEmployeeIdList.AllowNew = True
            With DataGridViewEmployeeIdList
                .AutoGenerateColumns = False
                .DataSource = bsEmployeeIdList
            End With
            With DataGridViewEmployeeIdList.Columns
                dgvIdNo.DisplayOnly = True
                dgvEmployeeName.DisplayOnly = True
                dgvNationalIdNo.DisplayOnly = True
                dgvPicture.ImageLayout = DataGridViewImageCellLayout.Stretch
            End With
            ResumeLayout()
        End Sub

        Private Sub ReportSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            DataGridViewEmployeeIdList.Refresh()
            BindEmployeeIdList()
        End Sub

        Private Sub ReportSelector_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            bsEmployeeIdList.ResetBindings(True)
            PublishClickedButton(ButtonClicked.Edit)
        End Sub

        Private Sub SelectAll_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnSelectAll.ClickButtonArea
            RaiseEvent ClearAllEmployee(bsEmployeeIdList, True)
            bsEmployeeIdList.ResetBindings(False)
        End Sub

        Private Sub UnselectAll_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnUnSelectAll.ClickButtonArea
            RaiseEvent ClearAllEmployee(bsEmployeeIdList, False)
            bsEmployeeIdList.ResetBindings(False)
        End Sub

    End Class

End Namespace
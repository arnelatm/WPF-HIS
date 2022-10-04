Imports System.Configuration
Imports System.Globalization
Imports AATM.Accounts.BusinessLayer.IGroup
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.PresentationLayer.Views.Interfaces.IGroup
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms.IGroup

    Public Class PmrInvestigationRequestForm
        Implements IPmrInvestigationView

        Private Event RetrieveInvestigations()
        Public Event GetDoctorPatientsRequested() Implements IPmrInvestigationView.GetDoctorPatientsRequested
        Private _pmrPatientsDisplay As List(Of IPmrPatientDisplayView)

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            dtpTransactionDate.Value = "2022/02/26"
            txtDoctorId.Text = "209"
            ' Add any initialization after the InitializeComponent() call.
            'RaiseEvent RetrieveInvestigations()

        End Sub


        Public Property DoctorId As String Implements IPmrInvestigationView.DoctorID
            Get
                Return txtDoctorId.Text
            End Get
            Set(value As String)
                txtDoctorId.Text = value
            End Set
        End Property


        Public Property DoctorName As String Implements IPmrInvestigationView.DoctorName
            Get
                Return txtDoctorName.Text
            End Get
            Set(value As String)
                txtDoctorName.Text = value
            End Set
        End Property

        Public Property TransactionDate As String Implements IPmrInvestigationView.TransactionDate
            Get
                Return dtpTransactionDate.Value
            End Get
            Set(value As String)
                dtpTransactionDate.Value = value
            End Set
        End Property

        Public Property PmrPatientsDisplay As List(Of IPmrPatientDisplayView) Implements IPmrInvestigationView.PmrPatientsDisplay
            Get
                Return _pmrPatientsDisplay
            End Get
            Set
                _pmrPatientsDisplay = Value
                BindPmrPatientDisplay()
            End Set
        End Property

        Private Sub BindPmrPatientDisplay()
            SuspendLayout()
            bsPmrPatientDisplay.DataSource = Nothing
            DataGridViewPmrPatientDisplay.Refresh()
            bsPmrPatientDisplay.DataSource = PmrPatientsDisplay
            bsPmrPatientDisplay.AllowNew = True
            With DataGridViewPmrPatientDisplay
                .AutoGenerateColumns = False
                .DataSource = bsPmrPatientDisplay
            End With
            With DataGridViewPmrPatientDisplay.Columns
                'dgvSequence.DisplayOnly = True
                'dgvAccountIdNo.DataSource = AccountsByCode
                'dgvAccountIdNo.DisplayMember = "Name"
                'dgvAccountIdNo.ValueMember = "IdNo"
                'dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
                'dgvRevCostCenterIdNo.DataSource = RevCostCentersByCode
                'dgvRevCostCenterIdNo.DisplayMember = "Name"
                'dgvRevCostCenterIdNo.ValueMember = "idNo"
                'dgvRevCostCenterIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            ResumeLayout()
        End Sub

        Private Sub btnRefresh_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnRefresh.ClickButtonArea
            RaiseEvent GetDoctorPatientsRequested()
        End Sub
    End Class

End Namespace
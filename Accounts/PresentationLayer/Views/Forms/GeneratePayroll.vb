Imports System.Dynamic
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class GeneratePayroll

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            MainTableName = "Payroll"
            SortOrderKey = "IdNo"
            PresenterObj = New GeneratePayrollPresenter(Me)
            MyPresenter = PresenterObj
            ProgressBar.Minimum = 0
            ProgressBar.Maximum = 100

        End Sub

        Private Property MyPresenter As ApJournalPresenter

        Private Sub GeneratePayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            cboPayrollIdNo.DataSource = PresenterObj.GetLookup("Payroll")
            cboPayCycleIdNo.DataSource = PresenterObj.GetLookup("PayCycle")
            cboPayCycleIdNo.EditingMode = False
            cboPayrollIdNo.EditingMode = True
            txtPayrollIdNo.EditingMode = False
            txtPayrollName.EditingMode = False
            dtpBeginningDate.EditingMode = False
            dtpEndingDate.EditingMode = False
        End Sub

        Private Sub cboPayrollIdNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPayrollIdNo.SelectedIndexChanged
            Dim payroll As Object = New ExpandoObject
            payroll = PresenterObj.ModelPresenter.GetFieldsWithIdNo(cboPayrollIdNo.SelectedValue, "Payroll", "IdNo,PayrollCode,StartDate,EndDate,PayrollName,PayCycleIdNo")
            dtpBeginningDate.Value = CType(payroll.StartDate, Date)
            dtpEndingDate.Value = CType(payroll.EndDate, Date)
            txtPayrollName.Text = payroll.PayrollName
            txtPayrollIdNo.Text = payroll.IdNo
            cboPayCycleIdNo.SetValue(payroll.PayCycleIdNo)
        End Sub

        Private Sub btnCancel_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub btnOk_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            PresenterObj.GeneratePayroll(cboPayrollIdNo.SelectedValue, dtpBeginningDate.Value, dtpEndingDate.Value, ProgressBar)
        End Sub

    End Class

End Namespace
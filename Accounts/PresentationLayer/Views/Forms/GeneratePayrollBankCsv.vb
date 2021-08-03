Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Views.Forms

    Public Class GeneratePayrollBankCsv
        Implements IPayrollView

        Public Property MainTableName As String
        Public Property EndDate As Date Implements IPayrollView.EndDate
        Public Property IdNo As Integer Implements IPayrollView.IdNo
        Public Property PayCycleIdNo As Short Implements IPayrollView.PayCycleIdNo
        Public Property PayrollCode As String Implements IPayrollView.PayrollCode
        Public Property PayrollName As String Implements IPayrollView.PayrollName
        Public Property PayrollNameAra As String Implements IPayrollView.PayrollNameAra
        Public Property StartDate As Date Implements IPayrollView.StartDate
        Public Property PayrollAttendance As List(Of AttendanceItemView) Implements IPayrollView.PayrollAttendance
        Public Property PayrollOvertime As List(Of OtWorkHourView) Implements IPayrollView.PayrollOvertime
        Public Property PayFrequency As Char Implements IPayrollView.PayFrequency

        Protected SortOrderKey As String

        Public Event InitializeAttendance(sender As Object) Implements IPayrollView.InitializeAttendance

        Public Event InitializeOvertime(sender As Object) Implements IPayrollView.InitializeOvertime

        Public Event GenerateRegularPayElements(sender As Object) Implements IPayrollView.GenerateRegularPayElements

        Public Event InitializePayroll(sender As Object) Implements IPayrollView.InitializePayroll

        Public Event GenerateCsvFile(payrollIdNo As Int32) Implements IPayrollView.GenerateCsvFile

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            MainTableName = "Payroll"
            SortOrderKey = "IdNo"
            SingleData = True
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("Payroll", cboPayrollIdNo)
        End Sub

        Private Sub btnOk_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            RaiseEvent GenerateCsvFile(cboPayrollIdNo.SelectedValue.IdNo)
        End Sub

    End Class

End Namespace
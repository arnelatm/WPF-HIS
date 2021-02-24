Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class GeneratePayrollPresenter
        Inherits AccountsPresenter(Of IView, AccountModel)

        Public Sub New(view As IView)
            MyBase.New(view)
            TableName = "Account"
            ModelPresenter = New ModelAccounts("Account")
            TableName = "Account"
            SortOrderKey = "IdNo"
            OriginalModel = New AccountModel()
            DataModel = New AccountModel()
        End Sub

        Public Sub GenerateEarnings(ByVal payrollIdNo As Int16, ByVal startDate As Date, ByVal endDate As Date)
            Dim attendance As List(Of AttendanceItem)
            Dim earnings As List(Of Earning)
            Dim payEarnings As New List(Of PayrollEarning)
            Dim attendanceItemDao = New AttendanceItemDao
            Dim employeeEarningDao = New EmployeeEarningDao
            Dim earningsDao = New EarningDao
            Dim nPaidDays As Decimal
            Dim empEarnings As List(Of EmployeeEarning)
            Dim regularEarning = EnumToCode(EarningTypeSelection.Regular)
            Dim fixedEarning = EnumToCode(CalculationTypeSelection.Fixed)
            attendance = attendanceItemDao.GetRecordsWithIdNo(payrollIdNo)
            For Each employeeAttendance In attendance
                'Dim earning As New PayrollEarning
                nPaidDays = employeeAttendance.DaysPresent + employeeAttendance.DaysAbsentWithPay + employeeAttendance.DaysOff
                empEarnings = New List(Of EmployeeEarning)
                empEarnings = employeeEarningDao.GetRecordsWithIdNo(employeeAttendance.EmployeeIdNo)
                For Each empEarning In empEarnings
                    Dim earning As Earning
                    earning = earningsDao.GetRecordById(empEarning.EarningIdNo)
                    If earning.EarningType = regularEarning Then
                        If earning.CalculationType = fixedEarning Then
                            Dim payEarning As PayrollEarning = New PayrollEarning With {
                                .PayrollIdNo = payrollIdNo,
                                .EmployeeIdNo = employeeAttendance.EmployeeIdNo,
                                .Amount = empEarning.Amount,
                                .EarningIdNo = empEarning.EarningIdNo}
                            payEarnings.Add(payEarning)
                        End If
                    End If
                Next
            Next
            'Dim payEarningView As New List(Of PayrollEarningView)
            'GlobalVariables.Mapper.Map(payEarnings, payEarningView)
            Dim dtInsertTable As New DataTable
            Dim dtUpdateTable As New DataTable
            CreateDataTable(dtInsertTable, {{"Amount", GetType(Decimal)},
                                            {"EarningIdNo", GetType(Int16)},
                                            {"EmployeeIdNo", GetType(Int32)},
                                            {"PayrollIdNo", GetType(Int16)}
                                           })

            ViewToDataTables(payEarnings, dtInsertTable, dtUpdateTable, AddressOf PayrollEarningFillData, AddressOf PayrollEarningFilter, "IdNo", "")

        End Sub

        Public Function PayrollEarningFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("Amount") = itemDataView.Amount
            workRow("EarningIdNo") = itemDataView.EarningIdNo
            workRow("EmployeeIdNo") = itemDataView.EmployeeIdNo
            workRow("PayrollIdNo") = itemDataView.PayrollIdNo
            Return True
        End Function

        Public Function PayrollEarningFilter(ByVal obj As Object) As Boolean
            'If (obj.Debit = 0 AndAlso obj.Credit = 0 AndAlso obj.Sequence <> 1) Then
            '    Return False
            'End If
            Return True
        End Function

    End Class

End Namespace
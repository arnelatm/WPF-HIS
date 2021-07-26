Imports System.Dynamic
Imports System.Globalization
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class PayrollDetailPresenter(Of TM As New)
        Inherits PresenterNew(Of IPayrollDetailView, TM)

        Protected DtPayElementInsertTable As New DataTable
        Protected DtPayElementUpdateTable As New DataTable

        'Protected DtDedInsertTable As New DataTable
        'Protected DtDedUpdateTable As New DataTable
        Private ReadOnly _payrollPayElementModel As New ModelAccounts("PayrollPayElement")

        Private _attendanceItemModel
        Private _reinitialize As Boolean = False
        Private _PayrollDetailEarning

        Public Sub New(itemView As IPayrollDetailView)
            MyBase.New(itemView)
            TreeViewMainField = "EmployeeName"
            TreeViewSecondaryField = "EmployeeCode"
            TableName = "PayrollDetail_View"
            SortOrderKey = "EmployeeName"

            Service = New AccountsService("AttendanceItem")

            CreateDataTable(DtPayElementInsertTable, {{"Amount", GetType(Decimal)},
                                            {"PayElementIdNo", GetType(Int16)},
                                            {"PayrollDetailIdNo", GetType(Int32)}
                                           })

            CreateDataTable(DtPayElementUpdateTable, {{"Amount", GetType(Decimal)},
                                            {"IdNo", GetType(Int32)},
                                            {"PayElementIdNo", GetType(Int16)},
                                            {"PayrollDetailIdNo", GetType(Int32)}
                                           })

            AddHandler View.UpdateDataFilterEvent, AddressOf OnUpdateDataFilterHandler

            'CreateDataTable(DtDedInsertTable, {{"Amount", GetType(Decimal)},
            '                    {"PayElementIdNo", GetType(Int16)},
            '                    {"PayrollDetailIdNo", GetType(Int32)}
            '                   })

            'CreateDataTable(DtDedUpdateTable, {{"Amount", GetType(Decimal)},
            '                                {"IdNo", GetType(Int32)},
            '                                {"PayElementIdNo", GetType(Int16)},
            '                                {"PayrollDetailIdNo", GetType(Int32)}
            '                               })

        End Sub

        Public Sub UpdateDataFilter(payrollIdNo As Int16)
            If payrollIdNo = 0 Then
                payrollIdNo = Service.GetFieldOnMaxField("PayrollIdNo", "PayrollDetail", "PayrollIdNo")
            End If
            DataFilter = "PayrollIdNo = " & payrollIdNo.ToString()
        End Sub

        Public Sub DisplayPayrollDetails(ByRef startDate As Date?, ByRef endDate As Date?, ByRef payDescription As String)
            Dim payroll As Object = New ExpandoObject
            payroll = Service.GetFieldsWithIdNo(View.PayrollIdNo, "Payroll", "StartDate,EndDate,PayrollName")
            startDate = CType(payroll.StartDate, Date)
            endDate = CType(payroll.EndDate, Date)
            payDescription = payroll.PayrollName
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                Dim data As New List(Of PayrollPayElementView)
                data.AddRange(View.PayrollEarnings)
                data.AddRange(View.PayrollDeductions)
                ViewToDataTables(data, DtPayElementInsertTable, DtPayElementUpdateTable, AddressOf FillData, AddressOf PayrollPayElementFilter, "IdNo", "")
                'ViewToDataTables(View.PayrollEarnings, DtEarnInsertTable, DtEarnUpdateTable, AddressOf FillData, AddressOf PayrollPayElementFilter, "IdNo", "")
                'ViewToDataTables(View.PayrollDeductions, DtDedInsertTable, DtDedUpdateTable, AddressOf FillData, AddressOf PayrollPayElementFilter, "IdNo", "")
            End If
        End Sub

        Private Sub FillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("Amount") = itemDataView.Amount
            workRow("PayElementIdNo") = itemDataView.PayElementIdNo
            workRow("PayrollDetailIdNo") = View.IdNo
        End Sub

        Public Function PayrollPayElementFilter(ByVal obj As Object) As Boolean
            If (obj.Amount = 0 Or obj.PayElementIdNo = 0) Then
                Return False
            End If
            Return True
        End Function

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateEmpPayElements(DtPayElementUpdateTable, DtPayElementInsertTable)
            'If retVal >= 0 Then
            '    ' retVal = UpdateEmpPayElements(DtDedUpdateTable, DtDedInsertTable)
            'End If
        End Sub

        Protected Function UpdateEmpPayElements(updateTable As DataTable, insertTable As DataTable) As Integer
            Dim retVal As Integer
            Dim _payrollPayElementsDao = New PayrollPayElementDao
            retVal = _payrollPayElementsDao.UpdInsEmpPayElementTvp(updateTable, insertTable, View.IdNo, View.EmployeeIdNo)
            Return retVal
        End Function

        Public Overrides Sub GoPrintRecord()
            Dim currencies As New List(Of CurrencyInfo)()
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim reportName As String = "Payroll Report.Rpt"
            Dim reportTitle As String = Service.GetField(Of String, Int32)(View.PayrollIdNo, "Payroll", "IdNo", "PayrollName")
            Dim cForm As New ReportFormNew(reportName, reportTitle, curCulture, {View.PayrollIdNo, "PayrollIdNo"})
            cForm.Show()
        End Sub

        Private Sub OnUpdateDataFilterHandler(idNo As Int16)
            DisplayPayrollDetails(View.StartDate, View.EndDate, View.PayPeriodName)
        End Sub

    End Class

End Namespace
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class EmployeePresenter
        Inherits AccountsPresenter(Of IEmployeeView, EmployeeModel)

        Protected DtEarnInsertTable As New DataTable
        Protected DtEarnUpdateTable As New DataTable
        Protected DtDeductInsertTable As New DataTable
        Protected DtDeductUpdateTable As New DataTable

        Private ReadOnly _employeeDeductionModel As New ModelAccounts("EmployeeDeduction")
        Private ReadOnly _employeeEarningModel As New ModelAccounts("EmployeeEarning")

        Public Sub New(view As IEmployeeView)
            MyBase.New(view)
            TableName = "Employee"
            SortOrderKey = "EmployeeName"
            TreeViewMainField = "EmployeeName"
            TreeViewSecondaryField = "EmployeeCode"
            ModelPresenter = New ModelAccounts("Employee")
            OriginalModel = New EmployeeModel()
            DataModel = New EmployeeModel
            TreeViewList = New List(Of EmployeeModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
            CreateDataTables()

        End Sub

        Private Function CreateDataTables()

            DtEarnInsertTable.Columns.Add("Amount", GetType(Decimal))
            DtEarnInsertTable.Columns.Add("EarningIdNo", GetType(Int16))
            DtEarnInsertTable.Columns.Add("EmployeeIdNo", GetType(Int32))
            DtEarnInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtDeductInsertTable.Columns.Add("Amount", GetType(Decimal))
            DtDeductInsertTable.Columns.Add("DeductionIdNo", GetType(Int16))
            DtDeductInsertTable.Columns.Add("EmployeeIdNo", GetType(Int32))
            DtDeductInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtEarnUpdateTable.Columns.Add("Amount", GetType(Decimal))
            DtEarnUpdateTable.Columns.Add("EarningIdNo", GetType(Int16))
            DtEarnUpdateTable.Columns.Add("EmployeeIdNo", GetType(Int32))
            DtEarnUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtEarnUpdateTable.Columns.Add("Sequence", GetType(Int16))

            DtDeductUpdateTable.Columns.Add("Amount", GetType(Decimal))
            DtDeductUpdateTable.Columns.Add("DeductionIdNo", GetType(Int16))
            DtDeductUpdateTable.Columns.Add("EmployeeIdNo", GetType(Int32))
            DtDeductUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtDeductUpdateTable.Columns.Add("Sequence", GetType(Int16))

        End Function

        Public Function GetEmployeeBalance(idNo As Integer)
            Return Model.GetSqlValue(Of Decimal)("Sum(Debit-Credit)", "ErStatement_View", "EmployeeIdNo = " & idNo.ToString())
        End Function

        Public Function GetEmployeeDeductions(ByVal idNo As Int32) As List(Of EmployeeDeductionModel)
            Return _employeeDeductionModel.GetRecordsWithIdNo(Of EmployeeDeductionModel)(idNo, "Sequence")
        End Function

        Public Function GetEmployeeEarnings(ByVal idNo As Int32) As List(Of EmployeeEarningModel)
            Return _employeeEarningModel.GetRecordsWithIdNo(Of EmployeeEarningModel)(idNo, "Sequence")
        End Function

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                ViewToDataTables(View.EmployeeDeductions, DtDeductInsertTable, DtDeductUpdateTable, AddressOf DeductionFillData, AddressOf DeductionFilter)
                ViewToDataTables(View.EmployeeEarnings, DtEarnInsertTable, DtEarnUpdateTable, AddressOf EarningFillData, AddressOf EarningFilter)
            End If
        End Sub

        Public Sub EarningFillData(ByRef item As Object, ByVal idNo As Integer, ByRef workRow As DataRow)
            workRow("Amount") = item.Amount
            workRow("EarningIdNo") = item.EarningIdNo
            workRow("EmployeeIdNo") = idNo
        End Sub

        Public Sub DeductionFillData(ByRef item As Object, ByVal idNo As Integer, ByRef workRow As DataRow)
            workRow("Amount") = item.Amount
            workRow("DeductionIdNo") = item.DeductionIdNo
            workRow("EmployeeIdNo") = idNo
        End Sub

        Public Function DeductionFilter(ByVal obj As Object) As Boolean
            If obj.Amount > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function EarningFilter(ByVal obj As EmployeeEarningView) As Boolean
            If obj.Amount > 0 Then
                Return True
            End If
            Return False
        End Function

        Private Sub FillDataRow(item As Object, idNo As Integer, workRow As DataRow, nRowCount As Short)
            workRow("Amount") = CallByName(item, "Amount", CallType.Get)
            workRow("EarningIdNo") = CallByName(item, "EarningIdNo", CallType.Get)
            workRow("EmployeeIdNo") = idNo
            workRow("Sequence") = nRowCount
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_employeeDeductionModel, DtDeductUpdateTable, DtDeductInsertTable, passedValue, "EmployeeIdNo")
            If retVal >= 0 Then
                retVal = UpdateChildData(_employeeEarningModel, DtEarnUpdateTable, DtEarnInsertTable, passedValue, "EmployeeIdNo")
            End If
        End Sub

        Function Func1(item As EmployeeDeductionView)
            Dim workRow As DataRow
            If item.IdNo <= 0 Then
                workRow = DtDeductInsertTable.NewRow()
            Else
                workRow = DtDeductUpdateTable.NewRow()
                workRow("IdNo") = item.IdNo
            End If
            workRow("Amount") = item.Amount
            workRow("DeductionIdNo") = item.DeductionIdNo
            workRow("EmployeeIdNo") = View.IdNo
            workRow("Sequence") = 1 ' nRowCount
            Return workRow
        End Function

    End Class
End Namespace
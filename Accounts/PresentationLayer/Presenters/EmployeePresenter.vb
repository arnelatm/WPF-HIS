Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
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

        Public Sub OnBeforeSaveOld() Handles MyBase.BeforeSave
            If Not CancelSave Then
                Dim nRowCount = 1
                If DtDeductInsertTable IsNot Nothing Then
                    DtDeductInsertTable.Clear()
                End If
                If DtDeductUpdateTable IsNot Nothing Then
                    DtDeductUpdateTable.Clear()
                End If
                For Each deduction In View.EmployeeDeductions
                    If (deduction.Amount = 0) Then
                        ' ignore these records (no amount no account)
                    Else
                        Dim workRow As DataRow
                        If deduction.IdNo <= 0 Then
                            workRow = DtDeductInsertTable.NewRow()
                        Else
                            workRow = DtDeductUpdateTable.NewRow()
                            workRow("IdNo") = deduction.IdNo
                        End If
                        workRow("Amount") = deduction.Amount
                        workRow("DeductionIdNo") = deduction.DeductionIdNo
                        workRow("EmployeeIdNo") = View.IdNo
                        workRow("Sequence") = nRowCount
                        If deduction.IdNo <= 0 Then
                            DtDeductInsertTable.Rows.Add(workRow)
                        Else
                            DtDeductUpdateTable.Rows.Add(workRow)
                        End If
                        nRowCount = nRowCount + 1
                    End If
                Next
                nRowCount = 1
                If DtEarnInsertTable IsNot Nothing Then
                    DtEarnInsertTable.Clear()
                End If
                If DtEarnUpdateTable IsNot Nothing Then
                    DtEarnUpdateTable.Clear()
                End If
                For Each earning In View.EmployeeEarnings
                    If (earning.Amount = 0) Then
                        ' ignore these records (no amount no account)
                    Else
                        Dim workRow As DataRow
                        If earning.IdNo <= 0 Then
                            workRow = DtEarnInsertTable.NewRow()
                        Else
                            workRow = DtEarnUpdateTable.NewRow()
                            workRow("IdNo") = earning.IdNo
                        End If
                        workRow("Amount") = earning.Amount
                        workRow("EarningIdNo") = earning.EarningIdNo
                        workRow("EmployeeIdNo") = View.IdNo
                        workRow("Sequence") = nRowCount
                        If earning.IdNo <= 0 Then
                            DtEarnInsertTable.Rows.Add(workRow)
                        Else
                            DtEarnUpdateTable.Rows.Add(workRow)
                        End If
                        nRowCount = nRowCount + 1
                    End If
                Next
            End If
        End Sub

        'Public Sub OnBeforeSave() Handles MyBase.BeforeSave
        '    If Not CancelSave Then
        '        MakeWorkRow(View.EmployeeDeductions, DtDeductInsertTable, DtDeductUpdateTable)
        '        MakeWorkRow(View.EmployeeEarnings, DtEarnInsertTable, DtEarnUpdateTable)
        '    End If
        'End Sub

        Dim EarningFillData As FillDataFunc

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                MakeWorkRow(View.EmployeeDeductions, DtDeductInsertTable, DtDeductUpdateTable, AddressOf EarningFillData)
                MakeWorkRow(View.EmployeeEarnings, DtEarnInsertTable, DtEarnUpdateTable)
            End If
        End Sub

        'Private Function MakeDed(dedView As EmployeeDeductionView, )
        '    Dim workRow As DataRow
        '    If item.IdNo <= 0 Then
        '        workRow = DtDeductInsertTable.NewRow()
        '    Else
        '        workRow = DtDeductUpdateTable.NewRow()
        '        workRow("IdNo") = item.IdNo
        '    End If
        '    workRow("Amount") = item.Amount
        '    workRow("DeductionIdNo") = item.DeductionIdNo
        '    workRow("EmployeeIdNo") = View.IdNo
        '    workRow("Sequence") = 1 ' nRowCount
        '    'Return workRow
        'End Function

        'Private Sub MakeDed(item As EmployeeDeductionView)
        '    Dim workRow As DataRow
        '    If item.IdNo <= 0 Then
        '        workRow = DtDeductInsertTable.NewRow()
        '    Else
        '        workRow = DtDeductUpdateTable.NewRow()
        '        workRow("IdNo") = item.IdNo
        '    End If
        '    workRow("Amount") = item.Amount
        '    workRow("DeductionIdNo") = item.DeductionIdNo
        '    workRow("EmployeeIdNo") = View.IdNo
        '    workRow("Sequence") = 1 ' nRowCount
        '    'Return workRow
        'End Sub

        'Public Sub GetSomeWork(Of T)(ByRef insertTable As DataTable, ByRef updateTable As DataTable, ByRef listView As List(Of T),
        '                                  ByVal idField As String, ignoreThese As Predicate(Of T), ByVal someDelegateFunc As SomeWorkDelegate)
        '    If insertTable IsNot Nothing Then
        '        insertTable.Clear()
        '    End If
        '    If updateTable IsNot Nothing Then
        '        updateTable.Clear()
        '    End If
        '    Dim nRowCount = 1
        '    For Each item In listView
        '        If ignoreThese.Invoke(item) Then
        '            ' ignore these records
        '        Else
        '            Dim workRow As DataRow = someDelegateFunc(item)
        '            If CallByName(item, idField, CallType.Get) <= 0 Then
        '                insertTable.Rows.Add(workRow)
        '            Else
        '                updateTable.Rows.Add(workRow)
        '            End If
        '            nRowCount = nRowCount + 1
        '        End If
        '    Next
        'End Sub

        Delegate Sub FillDataFunc(item As Object, idNo As Integer, workRow As DataRow, nRowCount As Short)

        Dim EarningFillData As

        Public Sub EarningFillData(ByRef item As EmployeeEarningView, ByVal idNo As Integer, ByRef workRow As DataRow)
            workRow("Amount") = item.Amount
            workRow("EarningIdNo") = item.EarningIdNo
            workRow("EmployeeIdNo") = idNo
        End Sub

        Public Sub DeductionFillData(item As EmployeeDeductionView, idNo As Integer, workRow As DataRow, nRowCount As Short)
            workRow("Amount") = item.Amount
            workRow("DeductionIdNo") = item.DeductionIdNo
            workRow("EmployeeIdNo") = idNo
        End Sub

        Private Function MakeWorkRow(ByRef myView As Object, ByRef insertTable As DataTable, ByRef updateTable As DataTable, myFunc As FillDataFunc) As DataRow
            If insertTable IsNot Nothing Then
                insertTable.Clear()
            End If
            If updateTable IsNot Nothing Then
                updateTable.Clear()
            End If
            Dim nRowCount As Int16 = 1
            Dim workRow As DataRow = Nothing
            For Each item In myView
                Dim idNo As Integer = CallByName(item, "IdNo", CallType.Get)
                If idNo <= 0 Then
                    workRow = insertTable.NewRow()
                Else
                    workRow = updateTable.NewRow()
                    workRow("IdNo") = idNo
                End If
                myFunc.Invoke(item, idNo, workRow, nRowCount)
                workRow("Sequence") = nRowCount
                If idNo <= 0 Then
                    insertTable.Rows.Add(workRow)
                Else
                    updateTable.Rows.Add(workRow)
                End If
                nRowCount += 1
                CallByName(item, "Sequence", CallType.Set, nRowCount)
            Next
            Return workRow
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

    'Class MakeDataTables

    '    ' Define the delegate function
    '    Delegate Function MakeData(ByVal item As Object, ByRef insertTable As DataTable, ByRef updateTable As DataTable) As DataRow

    '    ' Display properties in ascending or descending order.

    '    Function MyMakeData(ByVal data As MakeData)
    '        Dim workRow As DataRow
    '        'workRow = data(_item, _insertTable, _updateTable)
    '        workRow = data.Invoke(_item, _insertTable, _updateTable)
    '        Return workRow
    '    End Function

    '    Private _insertTable As DataTable

    '    Property InsertTable As DataTable
    '        Get
    '            Return _insertTable
    '        End Get
    '        Set(value As DataTable)
    '            _insertTable = value
    '        End Set
    '    End Property

    '    Private _updateTable As DataTable

    '    Property UpdateTable As DataTable
    '        Get
    '            Return _updateTable
    '        End Get
    '        Set(value As DataTable)
    '            _updateTable = value
    '        End Set
    '    End Property

    '    Private _item

    '    Property Item
    '        Get
    '            Return _item
    '        End Get
    '        Set
    '            _item = Value
    '        End Set
    '    End Property

    'End Class

    'Function Deduction(item As EmployeeDeductionView, insertTable As DataTable, updateTable As DataTable)
    '    Dim workRow As DataRow
    '    If item.IdNo <= 0 Then
    '        workRow = insertTable.NewRow()
    '    Else
    '        workRow = updateTable.NewRow()
    '        workRow("IdNo") = item.IdNo
    '    End If
    '    workRow("Amount") = item.Amount
    '    workRow("DeductionIdNo") = item.DeductionIdNo
    '    workRow("EmployeeIdNo") = item.IdNo
    '    workRow("Sequence") = 1 ' nRowCount
    '    Return workRow
    'End Function

    'Function Earning(item As EmployeeEarningView, insertTable As DataTable, updateTable As DataTable)
    '    Dim workRow As DataRow
    '    If item.IdNo <= 0 Then
    '        workRow = insertTable.NewRow()
    '    Else
    '        workRow = updateTable.NewRow()
    '        workRow("IdNo") = item.IdNo
    '    End If
    '    workRow("Amount") = item.Amount
    '    workRow("EarningIdNo") = item.EarningIdNo
    '    workRow("EmployeeIdNo") = item.IdNo
    '    workRow("Sequence") = 1 ' nRowCount
    '    Return workRow
    'End Function

    'Public Class class1
    '    Function Func1(item As EmployeeDeductionView)
    '        Dim workRow As DataRow
    '        If item.IdNo <= 0 Then
    '            workRow = DtDeductInsertTable.NewRow()
    '        Else
    '            workRow = DtDeductUpdateTable.NewRow()
    '            workRow("IdNo") = item.IdNo
    '        End If
    '        workRow("Amount") = item.Amount
    '        workRow("DeductionIdNo") = item.DeductionIdNo
    '        workRow("EmployeeIdNo") = View.IdNo
    '        workRow("Sequence") = 1 ' nRowCount
    '        Return workRow
    '    End Function
    'End Class

End Namespace
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class EmployeePresenterNew
        Inherits AccountsPresenterNew(Of IEmployeeView, EmployeeModel)

        Protected DtEmpPayElementInsertTable As New DataTable
        Protected DtEmpPayElementUpdateTable As New DataTable
        Protected DtPhoneInsertTable As New DataTable
        Protected DtPhoneUpdateTable As New DataTable
        Private ReadOnly _employeePayElementModel As New ModelAccounts("EmployeePayElement")
        Private ReadOnly _employeePhoneModel As New ModelAccounts("EmployeePhone")

        Public Sub New(view As IEmployeeView)
            MyBase.New(view)
            ModelOfPresenter = New ModelAccounts("Employee")
            TableName = "Employee"
            TreeViewMainField = "EmployeeName"
            TreeViewSecondaryField = "EmployeeCode"
            SortOrderKey = "EmployeeName"
            OriginalModel = New EmployeeModel()
            DataModel = New EmployeeModel
            CreateDataTables()
        End Sub

        Private Sub CreateDataTables()

            CreateDataTable(DtEmpPayElementInsertTable, {{"Amount", GetType(Decimal)},
                                             {"EmployeeIdNo", GetType(Int32)},
                                             {"PayElementIdNo", GetType(Int16)},
                                             {"Rate", GetType(Decimal)},
                                             {"Sequence", GetType(Int16)},
                                             {"Unit", GetType(String)}}
                                             )

            CreateDataTable(DtPhoneInsertTable, {{"AreaCode", GetType(String)},
                                             {"CountryTelIdNo", GetType(Int16)},
                                             {"EmployeeIdNo", GetType(Int32)},
                                             {"PhoneNumber", GetType(String)},
                                             {"PhoneTypeIdNo", GetType(Int16)},
                                             {"Sequence", GetType(Int16)}})

            CreateDataTable(DtEmpPayElementUpdateTable, {{"Amount", GetType(Decimal)},
                                            {"EmployeeIdNo", GetType(Int32)},
                                            {"IdNo", GetType(Int32)},
                                            {"PayElementIdNo", GetType(Int16)},
                                            {"Rate", GetType(Decimal)},
                                            {"Sequence", GetType(Int16)},
                                            {"Unit", GetType(String)}})

            CreateDataTable(DtPhoneUpdateTable, {{"AreaCode", GetType(String)},
                                             {"CountryTelIdNo", GetType(Int16)},
                                             {"EmployeeIdNo", GetType(Int32)},
                                             {"IdNo", GetType(Int32)},
                                             {"PhoneNumber", GetType(String)},
                                             {"PhoneTypeIdNo", GetType(Int16)},
                                             {"Sequence", GetType(Int16)}
                                            })

        End Sub

        Public Function GetEmployeeBalance(idNo As Integer)
            Return Model.GetFieldValue(Of Decimal)("Sum(Debit-Credit)", "ErStatement_View", "EmployeeIdNo = " & idNo.ToString())
        End Function

        Public Function GetEmployeeDeductions(ByVal idNo As Int32) As List(Of EmployeePayElementModel)
            Dim _employeePayElementDao As New EmployeePayElementDao
            Dim employeeDeductionModel As New List(Of EmployeePayElementModel)
            Dim employeeDeduction As List(Of EmployeePayElement) = _employeePayElementDao.GetDaoRecords("PayElementKind = '" & PayElementKindSelection.Deduction & "' and EmployeeIdNo = " & View.IdNo)
            GlobalVariables.Mapper.Map(employeeDeduction, employeeDeductionModel)
            Return employeeDeductionModel
        End Function

        Public Function GetEmployeeEarnings(ByVal idNo As Int32) As List(Of EmployeePayElementModel)
            Dim _employeePayElementDao As New EmployeePayElementDao
            Dim employeeEarningModel As New List(Of EmployeePayElementModel)
            Dim employeeEarning As List(Of EmployeePayElement) = _employeePayElementDao.GetDaoRecords("PayElementKind = '" & PayElementKindSelection.Earning & "' and EmployeeIdNo = " & View.IdNo)
            GlobalVariables.Mapper.Map(employeeEarning, employeeEarningModel)
            Return employeeEarningModel
        End Function

        Public Function GetEmployeePhones(ByVal idNo As Int16) As List(Of EmployeePhoneModel)
            Return _employeePhoneModel.GetRecordsWithGroupIdNo(Of EmployeePhoneModel)(idNo, "Sequence")
        End Function

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                Dim employeePayElements As New List(Of EmployeePayElementView)
                employeePayElements.AddRange(View.RegularEmployeeEarnings)
                employeePayElements.AddRange(View.RegularEmployeeDeductions)
                ViewToDataTables(employeePayElements, DtEmpPayElementInsertTable, DtEmpPayElementUpdateTable, AddressOf EmpPayElementFillData, AddressOf EmpPayElementFilter)
                ViewToDataTables(View.EmployeePhones, DtPhoneInsertTable, DtPhoneUpdateTable, AddressOf PhoneFillData, AddressOf PhoneFilter)
                If IsEmpty(View.HiredDate) Then
                    View.HiredDate = Today()
                End If
            End If
        End Sub

        Private Sub EmpPayElementFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("Amount") = itemDataView.Amount
            workRow("EmployeeIdNo") = View.IdNo
            workRow("PayElementIdNo") = itemDataView.PayElementIdNo
            workRow("Rate") = itemDataView.Rate
            workRow("Unit") = itemDataView.Unit
            workRow("Sequence") = itemDataView.Sequence
        End Sub

        Private Sub PhoneFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("AreaCode") = itemDataView.AreaCode
            workRow("CountryTelIdNo") = itemDataView.CountryTelIdNo
            workRow("EmployeeIdNo") = View.IdNo
            workRow("PhoneNumber") = itemDataView.PhoneNumber
            workRow("PhoneTypeIdNo") = itemDataView.PhoneTypeIdNo
        End Sub

        Public Function EmpPayElementFilter(ByVal obj As EmployeePayElementView) As Boolean
            If obj.Amount <> 0 Or obj.Rate <> 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function PhoneFilter(ByVal obj As EmployeePhoneView) As Boolean
            If obj.PhoneNumber <> "" Then
                Return True
            End If
            Return False
        End Function

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_employeePayElementModel, DtEmpPayElementUpdateTable, DtEmpPayElementInsertTable, passedValue, "EmployeeIdNo")
            If retVal >= 0 Then
                retVal = UpdateChildData(_employeePhoneModel, DtPhoneUpdateTable, DtPhoneInsertTable, passedValue, "EmployeeIdNo")
            End If
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                ' look for duplicate PayElementIdNo in bsEarning
                Dim duplicate = FirstFieldDuplicate(Of EmployeePayElementView, Int16)(View.RegularEmployeeEarnings, "PayElementIdNo")
                If duplicate IsNot Nothing Then
                    MessageBox.Show("Duplicate earning value found in Employee Earnings. See line <" + (duplicate + 1).ToString() + ">.")
                Else
                    duplicate = FirstFieldDuplicate(Of EmployeePayElementView, Int16)(View.RegularEmployeeDeductions, "PayElementIdNo")
                    If duplicate IsNot Nothing Then
                        MessageBox.Show("Duplicate earning value found in Employee Deductions. See line <" + (duplicate + 1).ToString() + ">.")
                    Else
                        retValue = True
                    End If
                End If
            End If
            Return retValue
        End Function

        Private Function hasDuplicates(Of T)(ByVal myList As List(Of T)) As Boolean
            Dim hs = New HashSet(Of T)()
            For i = 0 To myList.Count - 1
                If Not hs.Add(myList(i)) Then Return True
            Next
            Return False
        End Function

        Public Shared Function FirstDuplicate(ByVal items As IEnumerable(Of Integer)) As Integer?
            Dim [set] As HashSet(Of Integer) = New HashSet(Of Integer)()
            For Each item As Integer In items
                If [set].Contains(item) Then
                    Return item
                End If
                [set].Add(item)
            Next
            Return Nothing
        End Function

        Public Shared Function FirstFieldDuplicate(Of T1, T2)(ByRef items As List(Of T1), ByVal fieldName As String) As Integer?
            Dim [set] As HashSet(Of T2) = New HashSet(Of T2)()
            Dim i As Integer = 0
            Dim x As T2
            For Each item As T1 In items
                x = CallByName(item, fieldName, CallType.Get)
                If [set].Contains(x) Then
                    Return i
                End If
                [set].Add(x)
                i += 1
            Next
            Return Nothing
        End Function

        Public Sub UpdateCode(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            'Dim passedValue As Integer = retVal
            If retVal >= 0 And GlobalFunctions.IsEmpty(View.EmployeeCode) Then
                retVal = ModelOfPresenter.GenerateCode(View.IdNo)
            End If
        End Sub

        Public Overrides Sub GoFilter()
            If DataFilter Is Nothing Or DataFilter = "" Then
                DataFilter = "Active = 1"
            Else
                DataFilter = ""
            End If
            CallByName(View, "DisplayTreeViewData", CallType.Method)
            GoFirstRecord()
        End Sub

        Private Sub OnAfterRecordRetrieval() Handles MyBase.AfterRecordRetrieval
            Dim value As Double
            value = Convert.ToDecimal(GetEmployeeBalance(View.IdNo))
            View.Balance = value
        End Sub

        'Public Function ComputePayAmount(payFrequency As PayFrequencySelection, amount As Decimal, unit As String) As Decimal
        '    Return ComputePayAmount(payFrequency, amount, unit)
        'End Function

    End Class

End Namespace
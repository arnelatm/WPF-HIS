Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Presenters

    Public Class EmployeePresenter(Of TM As New)
        Inherits AccountsPresenterNew(Of IEmployeeView, TM)
        Implements ISubscriber(Of PayCycleIdNoChanged),
                   ISubscriber(Of DataChanged)

        Protected DtEmpPayElementInsertTable As New DataTable
        Protected DtEmpPayElementUpdateTable As New DataTable
        Protected DtPhoneInsertTable As New DataTable
        Protected DtPhoneUpdateTable As New DataTable
        Private ReadOnly _employeePayElementService As New ServiceAccounts("EmployeePayElement")
        Private ReadOnly _employeePhoneService As New ServiceAccounts("EmployeePhone")

        Public Sub New(itemView As IEmployeeView)
            MyBase.New(itemView)
            Service = New ServiceAccounts("Employee")
            TableName = "Employee"
            TreeViewMainField = "EmployeeName"
            TreeViewSecondaryField = "EmployeeCode"
            SortOrderKey = "EmployeeName"
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
            Return Service.GetFieldValue(Of Decimal)("Sum(Debit-Credit)", "ErStatement_View", "EmployeeIdNo = " & idNo.ToString())
        End Function

        Public Function GetEmployeeDeductions(ByVal idNo As Int32) As List(Of EmployeePayElementModel)
            Dim employeePayElementDao As New EmployeePayElementDao
            Dim employeeDeductionModel As New List(Of EmployeePayElementModel)
            Dim employeeDeduction As List(Of EmployeePayElement) = employeePayElementDao.GetDaoRecords("PayElementKind = '" & PayElementKindSelection.Deduction & "' and EmployeeIdNo = " & View.IdNo)
            GlobalVariables.Mapper.Map(employeeDeduction, employeeDeductionModel)
            Return employeeDeductionModel
        End Function

        Public Function GetEmployeeEarnings(ByVal idNo As Int32) As List(Of EmployeePayElementModel)
            Dim employeePayElementDao As New EmployeePayElementDao
            Dim employeeEarningModel As New List(Of EmployeePayElementModel)
            Dim employeeEarning As List(Of EmployeePayElement) = employeePayElementDao.GetDaoRecords("PayElementKind = '" & PayElementKindSelection.Earning & "' and EmployeeIdNo = " & View.IdNo)
            GlobalVariables.Mapper.Map(employeeEarning, employeeEarningModel)
            Return employeeEarningModel
        End Function

        Public Function GetEmployeePhones(ByVal idNo As Int16) As List(Of EmployeePhoneModel)
            Return _employeePhoneService.GetRecordsWithGroupIdNo(Of EmployeePhoneModel)(idNo, "Sequence")
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
            retVal = UpdateChildData(_employeePayElementService, DtEmpPayElementUpdateTable, DtEmpPayElementInsertTable, passedValue, "EmployeeIdNo")
            If retVal >= 0 Then
                retVal = UpdateChildData(_employeePhoneService, DtPhoneUpdateTable, DtPhoneInsertTable, passedValue, "EmployeeIdNo")
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

        Private Function HasDuplicates(Of T)(ByVal myList As List(Of T)) As Boolean
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
                x = LateBinding.GetProperty(item, fieldName)
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
            If retVal >= 0 And IsEmpty(View.EmployeeCode) Then
                retVal = Service.GenerateCode(View.IdNo)
                View.EmployeeCode = Service.GetFieldWithIdNo(View.IdNo, "Employee", "EmployeeCode")
            End If
        End Sub

        Public Overrides Sub GoFilter()
            If DataFilter Is Nothing Or DataFilter = "" Then
                DataFilter = "Active = 1"
            Else
                DataFilter = ""
            End If
            DisplayTree()
            GoFirstRecord()
        End Sub

        Private Sub OnAfterRecordRetrieval() Handles MyBase.AfterRecordRetrieval
            Dim value As Double
            value = Convert.ToDecimal(GetEmployeeBalance(View.IdNo))
            View.Balance = value
        End Sub

        Public Sub OnPayCycleEventChangedHandler(ByRef eventType As PayCycleIdNoChanged) Implements ISubscriber(Of PayCycleIdNoChanged).OnEventHandler
            View.PayFrequency = CodeToEnum(Of PayFrequencySelection)(GetFieldWithIdNo(eventType.PayCycleIdNo, "PayCycle", "PayFrequency"))
        End Sub

        Public Sub OnPayElementDataChangedEventHandler(ByRef eventType As DataChanged) Implements ISubscriber(Of DataChanged).OnEventHandler
            With eventType.BindingSource
                If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
                    Dim earnIdNo = eventType.BindingSource.Current.PayElementIdNo
                    Dim calcType = GetFieldWithIdNo(earnIdNo, "PayElement", "CalculationType")
                    Dim amount As Decimal
                    Dim employeePayElement As EmployeePayElementView = eventType.BindingSource.Current
                    Select Case eventType.PropertyName
                        Case $"PayElementIdNo"
                            earnIdNo = eventType.EnteredValue
                            calcType = GetFieldWithIdNo(earnIdNo, "PayElement", "CalculationType")
                            If IsEmpty(employeePayElement.Unit) Then
                                employeePayElement.Unit = GetFieldWithIdNo(earnIdNo, "PayElement", "Unit")
                            End If
                            If employeePayElement.Rate = 0 Then
                                employeePayElement.Rate = GetFieldWithIdNo(earnIdNo, "PayElement", "Rate")
                            End If
                            If calcType = EnumToCode(CalculationTypeSelection.FixedRate) Then
                                amount = 0
                            ElseIf calcType = EnumToCode(CalculationTypeSelection.FixedAmount) Then
                                amount = ComputePayAmount(View.PayFrequency, employeePayElement.Rate, employeePayElement.Unit)
                            End If
                        Case $"Rate"
                            If calcType = EnumToCode(CalculationTypeSelection.FixedRate) Then
                                amount = 0
                            ElseIf calcType = EnumToCode(CalculationTypeSelection.FixedAmount) Then
                                amount = ComputePayAmount(View.PayFrequency, eventType.EnteredValue, employeePayElement.Unit)
                            End If
                        Case $"Unit"
                            amount = ComputePayAmount(View.PayFrequency, employeePayElement.Rate, eventType.EnteredValue)
                    End Select
                    employeePayElement.Amount = amount
                End If
            End With
        End Sub

    End Class

End Namespace

Public Class PayCycleIdNoChanged

    Public Sub New(ByVal payCycleIdNo As Int16?)
        Me.PayCycleIdNo = payCycleIdNo
    End Sub

    Public Property PayCycleIdNo As Int16?

End Class

Public Class EmployeePayElementChanged

    Public Sub New(payElements As List(Of EmployeePayElementView), row As Int32, propertyName As String, elementName As String, enteredValue As Object)
        Me.PayElements = payElements
        Me.Row = row
        Me.PropertyName = propertyName
        Me.ElementName = elementName
        Me.EnteredValue = enteredValue
    End Sub

    Public Sub New(bindingSource As BindingSource, row As Int32, propertyName As String, elementName As String, enteredValue As Object)
        Me.BindingSource = bindingSource
        Me.Row = row
        Me.PropertyName = propertyName
        Me.ElementName = elementName
        Me.EnteredValue = enteredValue
    End Sub

    Public Property BindingSource As BindingSource
    Public Property PayElements As List(Of EmployeePayElementView)
    Public Property Row As Int32
    Public Property PropertyName As String
    Public Property ElementName As String
    Public Property EnteredValue As Object

End Class
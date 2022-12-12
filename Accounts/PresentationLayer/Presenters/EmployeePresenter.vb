Imports System.IO
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Presenters

    Public Class EmployeePresenter(Of TM As New)
        Inherits CommonPresenter(Of IEmployeeView, TM)
        Implements ISubscriber(Of PayCycleIdNoChanged),
                   ISubscriber(Of DataChanged)

        Protected DtEmpPayElementInsertTable As New DataTable
        Protected DtEmpPayElementUpdateTable As New DataTable
        Protected DtEmpLeaveCreditInsertTable As New DataTable
        Protected DtEmpLeaveCreditUpdateTable As New DataTable
        Protected DtPhoneInsertTable As New DataTable
        Protected DtPhoneUpdateTable As New DataTable
        Protected DtDocumentInsertTable As New DataTable
        Protected DtDocumentUpdateTable As New DataTable
        Private ReadOnly _employeePayElementService As New AccountsService("EmployeePayElement")
        Private ReadOnly _employeeDocumentService As New AccountsService("EmployeeDocument")
        Private ReadOnly _employeeLeaveCreditService As New AccountsService("EmployeeLeaveCredit")
        Private ReadOnly _employeePhoneService As New AccountsService("EmployeePhone")

        Public Sub New(itemView As IEmployeeView)
            MyBase.New(itemView)
            Service = New AccountsService("Employee")
            TableName = "Employee"
            TreeViewMainField = "EmployeeName"
            'TreeViewSecondaryField = "EmployeeCode"
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

            CreateDataTable(DtDocumentInsertTable, {
                                 {"DataImageIdNo", GetType(Int32)},
                                 {"DocumentIdNo", GetType(Int16)},
                                 {"DocumentNumber", GetType(String)},
                                 {"EmployeeIdNo", GetType(Int32)},
                                 {"ExpiryDate", GetType(Date)},
                                 {"IssueDate", GetType(Date)},
                                 {"Sequence", GetType(Int16)}})

            CreateDataTable(DtPhoneInsertTable, {{"AreaCode", GetType(String)},
                                             {"CountryTelIdNo", GetType(Int16)},
                                             {"EmployeeIdNo", GetType(Int32)},
                                             {"PhoneNumber", GetType(String)},
                                             {"PhoneTypeIdNo", GetType(Int16)},
                                             {"Sequence", GetType(Int16)}})

            CreateDataTable(DtEmpLeaveCreditInsertTable, {
                                            {"AccumulatedLeave", GetType(Decimal)},
                                            {"Cumulative", GetType(Boolean)},
                                            {"EmployeeIdNo", GetType(Int32)},
                                            {"LeaveAllowed", GetType(Decimal)},
                                            {"LeaveIdNo", GetType(Int16)},
                                            {"MaxCarryOver", GetType(Decimal)},
                                            {"MaxLimit", GetType(Decimal)},
                                            {"NoMaxLimit", GetType(Boolean)},
                                            {"PaidPercent", GetType(Decimal)},
                                            {"Sequence", GetType(Int16)}
                                                         })

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

            CreateDataTable(DtDocumentUpdateTable, {
                                 {"DataImageIdNo", GetType(Int32)},
                                 {"DocumentIdNo", GetType(Int16)},
                                 {"DocumentNumber", GetType(String)},
                                 {"EmployeeIdNo", GetType(Int32)},
                                 {"ExpiryDate", GetType(Date)},
                                 {"IdNo", GetType(Int32)},
                                 {"IssueDate", GetType(Date)},
                                 {"Sequence", GetType(Int16)}})

            CreateDataTable(DtEmpLeaveCreditUpdateTable, {
                                            {"AccumulatedLeave", GetType(Decimal)},
                                            {"Cumulative", GetType(Boolean)},
                                            {"EmployeeIdNo", GetType(Int32)},
                                            {"IdNo", GetType(Int32)},
                                            {"LeaveAllowed", GetType(Decimal)},
                                            {"LeaveIdNo", GetType(Int16)},
                                            {"MaxCarryOver", GetType(Decimal)},
                                            {"MaxLimit", GetType(Decimal)},
                                            {"NoMaxLimit", GetType(Boolean)},
                                            {"PaidPercent", GetType(Decimal)},
                                            {"Sequence", GetType(Int16)}})

        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateEnumDataSource(Of MaleFemaleSelection)("Gender")
            CreateEnumDataSource(Of MaritalStatusSelection)("MaritalStatus")
            CreateEnumDataSource(Of PayrollPaymentMethodSelection)("PaymentMethod")
            CreateEnumDataSource(Of SponsorTypeSelection)("SponsorType")
            CreateEnumDataSource(Of BloodTypeSelection)("BloodType")
            CreateDataSourceThread({{"Bank", "BankIdNo", Nothing, Nothing},
                                    {"Country", "CountryCode", Nothing, Nothing},
                                    {"Department", "DepartmentIdNo", Nothing, Nothing},
                                    {"Designation", "DesignationIdNo", Nothing, Nothing},
                                    {"Country", "NationalityCode", "CountryCode, CountryName", Nothing},
                                    {"Religion", "ReligionIdNo", Nothing, Nothing},
                                    {"PayCycle", "PayCycleIdNo", Nothing, Nothing},
                                    {"PayGroup", "PayGroupIdNo", Nothing, Nothing},
                                    {"Employee", "SupervisorIdNo", Nothing, "Supervisor=1"}})

            CreateListDataSource("List", "Title", "NameTitle")
            CreateEnumData(Of PayRateUnitSelection)(View.Unit)
            CreateLookupData("PhoneType", "PhoneTypes")
            CreateLookupData("Document", "Documents", "DocumentType = '" + EnumToCode(DocumentTypeSelection.Employee) + "'")
            CreateLookupData("Leave", "Leaves")
            CreateLookupData("PayElement", "DeductionsByName", "PayElementKind = '" + EnumToCode(PayElementKindSelection.Deduction) + "' and PayElementType = '" + EnumToCode(PayElementTypeSelection.Regular) + "'")
            CreateLookupData("PayElement", "EarningsByName", "PayElementKind = '" + EnumToCode(PayElementKindSelection.Earning) + "' and PayElementType = '" + EnumToCode(PayElementTypeSelection.Regular) + "'")
        End Sub

        Public Function GetEmployeeBalance(idNo As Integer)
            Return Service.GetFieldValue(Of Decimal)("Sum(Debit-Credit)", "ErStatement_View", "EmployeeIdNo = " & idNo.ToString())
        End Function

        'Public Function GetEmployeeDeductions(ByVal idNo As Int32) As List(Of EmployeePayElementModel)
        '    Dim employeePayElementDao As New EmployeePayElementDao
        '    Dim employeeDeductionModel As New List(Of EmployeePayElementModel)
        '    Dim employeeDeduction As List(Of EmployeePayElement) = employeePayElementDao.GetDaoRecords("PayElementKind = '" & PayElementKindSelection.Deduction & "' and EmployeeIdNo = " & View.IdNo)
        '    GlobalVariables.Mapper.Map(employeeDeduction, employeeDeductionModel)
        '    Return employeeDeductionModel
        'End Function

        'Public Function GetEmployeeEarnings(ByVal idNo As Int32) As List(Of EmployeePayElementModel)
        '    Dim employeePayElementDao As New EmployeePayElementDao
        '    Dim employeeEarningModel As New List(Of EmployeePayElementModel)
        '    Dim employeeEarning As List(Of EmployeePayElement) = employeePayElementDao.GetDaoRecords("PayElementKind = '" & PayElementKindSelection.Earning & "' and EmployeeIdNo = " & View.IdNo)
        '    GlobalVariables.Mapper.Map(employeeEarning, employeeEarningModel)
        '    Return employeeEarningModel
        'End Function

        'Public Function GetEmployeePhones(ByVal idNo As Int16) As List(Of EmployeePhoneModel)
        '    Return _employeePhoneService.GetRecordsWithGroupIdNo(Of EmployeePhoneModel)(idNo, "Sequence")
        'End Function

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                Dim employeePayElements As New List(Of EmployeePayElementView)
                employeePayElements.AddRange(View.RegularEmployeeEarnings)
                employeePayElements.AddRange(View.RegularEmployeeDeductions)

                ViewToDataTables(employeePayElements, DtEmpPayElementInsertTable, DtEmpPayElementUpdateTable, AddressOf EmpPayElementFillData, AddressOf EmpPayElementFilter)
                ViewToDataTables(View.EmployeePhones, DtPhoneInsertTable, DtPhoneUpdateTable, AddressOf PhoneFillData, AddressOf PhoneFilter)
                ViewToDataTables(View.EmployeeLeaveCredits, DtEmpLeaveCreditInsertTable, DtEmpLeaveCreditUpdateTable, AddressOf EmpLeaveCreditFillData, AddressOf EmpLeaveCreditFilter)
                SaveDocumentImages()
                ViewToDataTables(View.EmployeeDocuments, DtDocumentInsertTable, DtDocumentUpdateTable, AddressOf DocumentFillData, AddressOf DocumentFilter)
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

        Private Sub DocumentFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("DataImageIdNo") = itemDataView.DataImageIdNo
            workRow("DocumentIdNo") = itemDataView.DocumentIdNo
            workRow("DocumentNumber") = itemDataView.DocumentNumber
            workRow("EmployeeIdNo") = View.IdNo
            workRow("ExpiryDate") = IIf(itemDataView.ExpiryDate Is Nothing, DBNull.Value, itemDataView.ExpiryDate)
            workRow("IssueDate") = IIf(itemDataView.IssueDate Is Nothing, DBNull.Value, itemDataView.IssueDate)
            workRow("Sequence") = itemDataView.Sequence
        End Sub

        Private Sub PhoneFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("AreaCode") = itemDataView.AreaCode
            workRow("CountryTelIdNo") = itemDataView.CountryTelIdNo
            workRow("EmployeeIdNo") = View.IdNo
            workRow("PhoneNumber") = itemDataView.PhoneNumber
            workRow("PhoneTypeIdNo") = itemDataView.PhoneTypeIdNo
        End Sub

        Private Sub EmpLeaveCreditFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("AccumulatedLeave") = itemDataView.AccumulatedLeave
            workRow("Cumulative") = itemDataView.Cumulative
            workRow("EmployeeIdNo") = View.IdNo
            workRow("LeaveAllowed") = itemDataView.LeaveAllowed
            workRow("LeaveIdNo") = itemDataView.LeaveIdNo
            workRow("MaxCarryOver") = itemDataView.MaxCarryOver
            workRow("MaxLimit") = itemDataView.MaxLimit
            workRow("PaidPercent") = itemDataView.PaidPercent
            workRow("Sequence") = itemDataView.Sequence
        End Sub

        Public Function EmpPayElementFilter(ByVal obj As EmployeePayElementView) As Boolean
            If obj.Amount <> 0 Or obj.Rate <> 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function DocumentFilter(ByVal obj As EmployeeDocumentView) As Boolean
            If obj.DocumentIdNo <> 0 Then
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

        Public Function EmpLeaveCreditFilter(ByVal obj As EmployeeLeaveCreditView) As Boolean
            If obj.LeaveAllowed <> 0 Then
                Return True
            End If
            Return False
        End Function

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_employeePayElementService, DtEmpPayElementUpdateTable, DtEmpPayElementInsertTable, passedValue, "EmployeeIdNo")
            If retVal >= 0 Then
                retVal = UpdateChildData(_employeePhoneService, DtPhoneUpdateTable, DtPhoneInsertTable, passedValue, "EmployeeIdNo")
                If retVal >= 0 Then

                    retVal = UpdateChildData(_employeeDocumentService, DtDocumentUpdateTable, DtDocumentInsertTable, passedValue, "EmployeeIdNo")
                    If retVal >= 0 Then
                        retVal = UpdateChildData(_employeeLeaveCreditService, DtEmpLeaveCreditUpdateTable, DtEmpLeaveCreditInsertTable, passedValue, "EmployeeIdNo")
                    End If
                End If
            End If
        End Sub

        Private Sub SaveDocumentImages()
            For Each item In View.EmployeeDocuments
                If item.Changed Then
                    ' item has changed need to save the image
                    Dim diImage As New DataImage
                    If IsEmpty(item.ImageFileName) Then
                        If item.DataImageIdNo > 0 Then
                            diImage.IdNo = item.IdNo
                            diImage.Image = Nothing
                            SaveDataImage(item, diImage, Nothing)
                        End If
                    Else
                        Dim fileInfo As New FileInfo(item.ImageFileName)
                        Dim length As Long = fileInfo.Length
                        Dim maxImageSize As Decimal = 3000000
                        If maxImageSize > 0 Then
                            If fileInfo.Length > maxImageSize Then
                                Dim resizer As ImageResizer = New ImageResizer(maxImageSize, item.ImageFileName, item.ImageFileName)
                                If Not resizer.ScaleImage() Then
                                    MessageBox.Show("Cannot scale image to " & maxImageSize.ToString() & $" bytes size. Either select a smaller file size or resize the image manually to less than or equal to " & maxImageSize.ToString() & " bytes.")
                                Else
                                    If IsEmpty(item.ImageFileName) Then
                                        diImage.Image = Nothing
                                    Else
                                        diImage.Image = Drawing.Image.FromFile(item.ImageFileName)
                                    End If
                                    SaveDataImage(item, diImage, item.ImageFileName)
                                End If
                            Else
                                diImage.IdNo = item.DataImageIdNo
                                SaveDataImage(item, diImage, item.ImageFileName)
                            End If
                        End If
                    End If
                End If
            Next
        End Sub

        Private Shared Sub SaveDataImage(ByRef employeeDocumentView As EmployeeDocumentView, ByRef diImage As DataImage, ByVal imageFileName As String)
            Dim diDao As New DataImageDao
            If IsEmpty(employeeDocumentView.ImageFileName) Then
                If diImage.IdNo > 0 Then
                    diDao.DeleteRecord(diImage.IdNo, "DataImage")
                End If
            Else
                diImage.Image = IIf(IsEmpty(employeeDocumentView.ImageFileName), CObj(DBNull.Value), Drawing.Image.FromFile(imageFileName))
                If employeeDocumentView.DataImageIdNo > 0 Then
                    diDao.UpdateRecord(diImage)
                    'employeeDocumentView.DataImageIdNo =
                Else
                    employeeDocumentView.DataImageIdNo = diDao.AddRecord(diImage)
                End If
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
                        duplicate = FirstFieldDuplicate(Of EmployeeLeaveCreditView, Int16)(View.EmployeeLeaveCredits, "LeaveIdNo")
                        If duplicate IsNot Nothing Then
                            MessageBox.Show("Duplicate leave value found in Employee Leave Credits. See line <" + (duplicate + 1).ToString() + ">.")
                        Else
                            retValue = True
                        End If
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
                x = Invoker.GetProperty(item, fieldName)
                If [set].Contains(x) Then
                    Return i
                End If
                [set].Add(x)
                i += 1
            Next
            Return Nothing
        End Function

        Public Sub RecordAddedUpdated(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
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

        Private Sub OnBeforeMapping(dataModel As Object) Handles MyBase.BeforeMappingData
            Dim value As Double
            value = Convert.ToDecimal(GetEmployeeBalance(dataModel.IdNo))
            View.Balance = value
        End Sub

        Public Sub OnPayCycleEventChangedHandler(ByRef eventType As PayCycleIdNoChanged) Implements ISubscriber(Of PayCycleIdNoChanged).OnEventHandler
            View.PayFrequency = CodeToEnum(Of PayFrequencySelection)(GetFieldWithIdNo(eventType.PayCycleIdNo, "PayCycle", "PayFrequency"))
        End Sub

        Public Sub OnPayElementDataChangedEventHandler(ByRef eventType As DataChanged) Implements ISubscriber(Of DataChanged).OnEventHandler
            With eventType.BindingSource
                If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
                    Select Case eventType.PropertyName
                        Case $"PayElementIdNo"
                            Dim amount As Decimal
                            Dim employeePayElement As EmployeePayElementView = eventType.BindingSource.Current
                            Dim earnIdNo = eventType.BindingSource.Current.PayElementIdNo
                            Dim calcType = GetFieldWithIdNo(earnIdNo, "PayElement", "CalculationType")
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
                            employeePayElement.Amount = amount
                        Case $"Rate"
                            Dim amount As Decimal
                            Dim employeePayElement As EmployeePayElementView = eventType.BindingSource.Current

                            Dim earnIdNo = eventType.BindingSource.Current.PayElementIdNo
                            Dim calcType = GetFieldWithIdNo(earnIdNo, "PayElement", "CalculationType")
                            If calcType = EnumToCode(CalculationTypeSelection.FixedRate) Then
                                amount = 0
                            ElseIf calcType = EnumToCode(CalculationTypeSelection.FixedAmount) Then
                                amount = ComputePayAmount(View.PayFrequency, eventType.EnteredValue, employeePayElement.Unit)
                            End If
                            employeePayElement.Amount = amount
                        Case $"Unit"
                            Dim amount As Decimal
                            Dim employeePayElement As EmployeePayElementView = eventType.BindingSource.Current
                            amount = ComputePayAmount(View.PayFrequency, employeePayElement.Rate, eventType.EnteredValue)
                            employeePayElement.Amount = amount
                        'Case $"LeaveCycle"
                        '    Dim empLeaveCredit As EmployeeLeaveCreditView = eventType.BindingSource.Current
                        '    Dim leaveDao As New LeaveDao
                        '    Dim leave As Leave = leaveDao.GetRecordByIdNo(empLeaveCredit.IdNo)
                        '    If leave.LeaveCycle = EnumToCode(LeaveCycleSelection.OnceOnly) Or leave.LeaveCycle = EnumToCode(LeaveCycleSelection.AsNeeded) then
                        '        empLeaveCredit.MaxCarryOver = 0
                        '        empLeaveCredit.MaxLimit = 0
                        '        empLeaveCredit.NoMaxLimit = False
                        '    Else
                        '        empLeaveCredit.NoMaxLimit = True
                        '        empLeaveCredit.MaxLimit = 0
                        '    End If
                        Case $"LeaveIdNo"
                            Dim empLeaveCredit As EmployeeLeaveCreditView = eventType.BindingSource.Current
                            Dim leaveDao As New LeaveDao
                            Dim leave As Leave = leaveDao.GetRecordByIdNo(empLeaveCredit.LeaveIdNo)
                            'If empLeaveCredit.LeaveAllowed
                            empLeaveCredit.LeaveAllowed = leave.LeaveAllowed
                            empLeaveCredit.MaxCarryOver = leave.MaxCarryOver
                            empLeaveCredit.MaxLimit = leave.MaxLimit
                            empLeaveCredit.NoMaxLimit = leave.NoMaxLimit
                            empLeaveCredit.Cumulative = leave.Cumulative
                            empLeaveCredit.PaidPercent = leave.PaidPercent
                            'End If
                            'If leave.LeaveCycle = EnumToCode(LeaveCycleSelection.OnceOnly) Or leave.LeaveCycle = EnumToCode(LeaveCycleSelection.AsNeeded) Then
                            '    empLeaveCredit.MaxCarryOver = 0
                            '    empLeaveCredit.MaxLimit = 0
                            '    empLeaveCredit.NoMaxLimit = False
                            '    empLeaveCredit.Cumulative = False
                            '    Beep()
                            'Else
                            '    If Not empLeaveCredit.Cumulative Then
                            '        empLeaveCredit.MaxCarryOver = 0
                            '        empLeaveCredit.MaxLimit = 0
                            '        empLeaveCredit.NoMaxLimit = False
                            '    Else
                            '        empLeaveCredit.NoMaxLimit = True
                            '        empLeaveCredit.MaxLimit = 0
                            '    End If
                            'End If
                        Case $"Cumulative"
                            Dim empLeaveCredit As EmployeeLeaveCreditView = eventType.BindingSource.Current
                            Dim leaveDao As New LeaveDao
                            Dim leave As Leave = leaveDao.GetRecordByIdNo(empLeaveCredit.LeaveIdNo)
                            If leave.LeaveCycle = EnumToCode(LeaveCycleSelection.OnceOnly) Or leave.LeaveCycle = EnumToCode(LeaveCycleSelection.AsNeeded) Then
                                empLeaveCredit.MaxCarryOver = 0
                                empLeaveCredit.MaxLimit = 0
                                empLeaveCredit.NoMaxLimit = False
                                empLeaveCredit.Cumulative = False
                                Beep()
                            Else
                                If Not empLeaveCredit.Cumulative Then
                                    empLeaveCredit.MaxCarryOver = 0
                                    empLeaveCredit.MaxLimit = 0
                                    empLeaveCredit.NoMaxLimit = False
                                Else
                                    empLeaveCredit.NoMaxLimit = True
                                    empLeaveCredit.MaxLimit = 0
                                End If
                            End If
                        Case $"NoMaxLimit"
                            Dim empLeaveCredit As EmployeeLeaveCreditView = eventType.BindingSource.Current
                            If Not empLeaveCredit.Cumulative Then
                                Beep()
                                empLeaveCredit.NoMaxLimit = False
                            End If
                        Case $"MaxLimit"
                            Dim empLeaveCredit As EmployeeLeaveCreditView = eventType.BindingSource.Current
                            If Not empLeaveCredit.Cumulative Then
                                Beep()
                                empLeaveCredit.MaxLimit = 0
                            End If
                        Case $"MaxCarryOver"
                            Dim empLeaveCredit As EmployeeLeaveCreditView = eventType.BindingSource.Current
                            If Not empLeaveCredit.Cumulative Then
                                Beep()
                                empLeaveCredit.MaxCarryOver = 0
                            End If
                        Case $"AccumulatedLeave"
                            Dim empLeaveCredit As EmployeeLeaveCreditView = eventType.BindingSource.Current
                            If Not empLeaveCredit.Cumulative Then
                                Beep()
                                empLeaveCredit.AccumulatedLeave = 0
                            End If
                        Case $"IssueDate"
                            Dim empDocument As EmployeeDocumentView = eventType.BindingSource.Current
                            If empDocument.IssueDate = "" Then
                                empDocument.IssueDate = Nothing
                            End If
                    End Select
                End If
            End With
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int32)(View.IdNo, "User", "EmployeeIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "EmployeeLeave", "EmployeeIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "AttendanceItem", "EmployeeIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "AttendanceItem", "EmployeeIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "EmployeeAbsence", "EmployeeIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "EmployeeLeaveCredit", "EmployeeIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "EmployeePayElement", "EmployeeIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "EmployeePhone", "EmployeeIdNo") Then
                Return True
                'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "ErDetails_View", "EmployeeIdNo") Then
                '    Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "EmployeeDocument", "EmployeeIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "ErJournal", "EmployeeIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "HolidayTransferItem", "EmployeeIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "OtWorkHour", "EmployeeIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "HolidayTransferItem", "EmployeeIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "PayrollDetail", "EmployeeIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "RecurringPayElement", "EmployeeIdNo") Then
                Return True
            End If
            Return False
        End Function

    End Class

End Namespace

Public Class PayCycleIdNoChanged

    Public Sub New(ByVal payCycleIdNo As Byte?)
        Me.PayCycleIdNo = payCycleIdNo
    End Sub

    Public Property PayCycleIdNo As Byte?

End Class

'Public Class EmployeePayElementChanged

'    Public Sub New(payElements As List(Of EmployeePayElementView), row As Int32, propertyName As String, elementName As String, enteredValue As Object)
'        Me.PayElements = payElements
'        Me.Row = row
'        Me.PropertyName = propertyName
'        Me.ElementName = elementName
'        Me.EnteredValue = enteredValue
'    End Sub

'    Public Sub New(bindingSource As BindingSource, row As Int32, propertyName As String, elementName As String, enteredValue As Object)
'        Me.BindingSource = bindingSource
'        Me.Row = row
'        Me.PropertyName = propertyName
'        Me.ElementName = elementName
'        Me.EnteredValue = enteredValue
'    End Sub

'    Public Property BindingSource As BindingSource
'    Public Property PayElements As List(Of EmployeePayElementView)
'    Public Property Row As Int32
'    Public Property PropertyName As String
'    Public Property ElementName As String
'    Public Property EnteredValue As Object

'End Class
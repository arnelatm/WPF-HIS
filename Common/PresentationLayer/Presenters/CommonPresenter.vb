Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class CommonPresenter(Of T As IView, TM As New)
        Inherits Presenter(Of T, TM)

        Private _tableDefaultFieldValueList As List(Of DefaultFieldValueModel)

        Shared Sub New()
            CommonModel = New ModelCommon()
            ModelDefaultFieldValue = New ModelDefaultFieldValue
        End Sub

        Public Sub New(view As IView)
            MyBase.New(view)
            TableDefaultFieldValues = ModelDefaultFieldValue.GetDefaultFieldValue(TableName)
        End Sub

        Public Shared Property ModelDefaultFieldValue As IModelDefaultFieldValue
        Public Shared Property TableDefaultFieldValues As List(Of DefaultFieldValueModel)
        Private Shared Shadows Property CommonModel As IModelCommon

        Public Function GetAccountTypesList(accountType As String, Optional ByVal sortKey As String = "AccountName")
            LookUpTableToGet = "Chart"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "AccountName"
            LookUpDisplayNameArabic = "AccountNameAra"
            LookUpDisplayCode = "AccountCode"
            Dim values = accountType.Split(",")
            LookUpFilterKey = ""
            For Each account In values
                If LookUpFilterKey <> "" Then
                    LookUpFilterKey = LookUpFilterKey + " Or "
                End If
                LookUpFilterKey = LookUpFilterKey + "SpecialAccount = '" & account & "'"
            Next
            Return GetTableListFiltered()
        End Function

        Public Function GetBankList(Optional ByVal sortKey As String = "BankName")
            LookUpTableToGet = "Bank"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "BankName"
            LookUpDisplayNameArabic = "BankNameAra"
            LookUpDisplayCode = "BankCode"
            Return GetLookupByNameCode()
        End Function

        Public Function GetChartList(Optional ByVal sortKey As String = "AccountName")
            LookUpTableToGet = "Chart"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "AccountName"
            LookUpDisplayNameArabic = "AccountNameAra"
            LookUpDisplayCode = "AccountCode"
            Return GetLookupByCodeName()
        End Function

        Public Function GetCountryList(Optional ByVal sortKey As String = "CountryName")
            LookUpTableToGet = "Country"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "CountryName"
            LookUpDisplayNameArabic = "CountryNameAra"
            LookUpDisplayCode = "CountryCode"
            Return GetLookupByNameCode()
        End Function

        Public Function GetCountryTelIdNoList(Optional ByVal sortKey As String = "CountryName")
            Return GetLookupData("CountryName", "CountryNameAra", "CountryTelCode", "Country", sortKey, "")
        End Function

        Public Function GetCustomerListByCode(Optional ByVal sortKey As String = "CustomerCode")
            LookUpTableToGet = "Customer"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "CustomerName"
            LookUpDisplayNameArabic = "CustomerNameAra"
            LookUpDisplayCode = "CustomerCode"
            Return GetLookupByCodeName()
        End Function

        Public Function GetCustomerListByName(Optional ByVal sortKey As String = "CustomerName")
            LookUpTableToGet = "Customer"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "CustomerName"
            LookUpDisplayNameArabic = "CustomerNameAra"
            LookUpDisplayCode = "CustomerCode"
            Return GetLookupByNameCode()
        End Function

        'Public Function GetDepartmentList(Optional ByVal sortKey As String = "DepartmentName")
        '    LookUpTableToGet = "Department"
        '    LookUpSortExpression = sortKey
        '    LookUpDisplayName = "DepartmentName"
        '    LookUpDisplayNameArabic = "DepartmentNameAra"
        '    LookUpDisplayCode = "DepartmentCode"
        '    Return GetTableList()
        'End Function

        'Public Function GetDepartmentListByName(Optional ByVal sortKey As String = "DepartmentName")
        '    LookUpTableToGet = "Department"
        '    LookUpSortExpression = sortKey
        '    LookUpDisplayName = "DepartmentName"
        '    LookUpDisplayNameArabic = "DepartmentNameAra"
        '    LookUpDisplayCode = "DepartmentCode"
        '    Return GetLookupByName()
        'End Function

        'Public Function GetDesignationList(Optional ByVal sortKey As String = "DesignationName")
        '    LookUpTableToGet = "Designation"
        '    LookUpSortExpression = sortKey
        '    LookUpDisplayName = "DesignationName"
        '    LookUpDisplayNameArabic = "DesignationNameAra"
        '    LookUpDisplayCode = "DesignationCode"
        '    Return GetTableList()
        'End Function

        Public Function GetDetailAccountList(Optional ByVal sortKey As String = "AccountCode")
            LookUpTableToGet = "Chart"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "AccountName"
            LookUpDisplayNameArabic = "AccountNameAra"
            LookUpDisplayCode = "AccountCode"
            LookUpFilterKey = "DetailAccount=1"
            Return GetLookupFilteredData()
        End Function

        Public Function GetDetailAccountListByCode(Optional ByVal sortKey As String = "AccountCode")
            LookUpTableToGet = "Chart"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "AccountName"
            LookUpDisplayNameArabic = "AccountNameAra"
            LookUpDisplayCode = "AccountCode"
            LookUpFilterKey = "DetailAccount=1"
            Return GetLookupFilteredDataByCode()
        End Function

        Public Function GetDetailAccountListByName(Optional ByVal sortKey As String = "AccountName")
            LookUpTableToGet = "Chart"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "AccountName"
            LookUpDisplayNameArabic = "AccountNameAra"
            LookUpDisplayCode = "AccountCode"
            LookUpFilterKey = "DetailAccount=1"
            Return GetLookupFilteredDataByName()
        End Function

        Public Function GetEmployeeListByCode(Optional ByVal sortKey As String = "EmployeeName")
            LookUpTableToGet = "Employee"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "EmployeeName"
            LookUpDisplayNameArabic = "EmployeeNameAra"
            LookUpDisplayCode = "EmployeeCode"
            Return GetLookupByCodeName()
        End Function

        Public Function GetEmployeeListByName(Optional ByVal sortKey As String = "EmployeeName")
            LookUpTableToGet = "Employee"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "EmployeeName"
            LookUpDisplayNameArabic = "EmployeeNameAra"
            LookUpDisplayCode = "EmployeeCode"
            Return GetLookupByNameCode()
        End Function

        'Public Function GetFilteredListByCode(listName As String, filter As String)
        '    LookUpTableToGet = listName
        '    LookUpDisplayName = listName + "Name"
        '    LookUpSortExpression = LookUpDisplayName
        '    LookUpDisplayNameArabic = LookUpDisplayName + "Ara"
        '    LookUpDisplayCode = listName + "Code"
        '    Return GetLookupByCodeName()
        'End Function

        Public Function GetListByCode(listName As String, Optional filter As String = Nothing)
            LookUpTableToGet = listName
            LookUpDisplayName = listName + "Name"
            LookUpSortExpression = LookUpDisplayName
            LookUpDisplayNameArabic = LookUpDisplayName + "Ara"
            LookUpDisplayCode = listName + "Code"
            Return GetLookupByCodeName(filter)
        End Function

        'Public Function GetPayGroupList(Optional ByVal sortKey As String = "PayGroupName")
        '    LookUpTableToGet = "PayGroup"
        '    LookUpSortExpression = sortKey
        '    LookUpDisplayName = "PayGroupName"
        '    LookUpDisplayNameArabic = "PayGroupNameAra"
        '    LookUpDisplayCode = "PayGroupCode"
        '    Return GetTableList()
        'End Function
        Public Function GetListByName(listName As String, Optional filter As String = Nothing)
            LookUpTableToGet = listName
            LookUpDisplayName = listName + "Name"
            LookUpSortExpression = LookUpDisplayName
            LookUpDisplayNameArabic = LookUpDisplayName + "Ara"
            LookUpDisplayCode = listName + "Code"
            Return GetLookupByName(filter)
        End Function

        Public Function GetPayGroupList(Optional ByVal sortKey As String = "PayGroupName")
            LookUpTableToGet = "PayGroup"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "PayGroupName"
            LookUpDisplayNameArabic = "PayGroupNameAra"
            LookUpDisplayCode = "PayGroupCode"
            Return GetTableList()
        End Function

        Public Function GetPayGroupListByCode(Optional ByVal sortKey As String = "PayGroupCode")
            LookUpTableToGet = "PayGroup"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "PayGroupName"
            LookUpDisplayNameArabic = "PayGroupNameAra"
            LookUpDisplayCode = "PayGroupCode"
            Return GetLookupByCodeName()
        End Function

        'Public Function GetPaymentTypeList(Optional ByVal sortKey As String = "PaymentTypeCode")
        '    LookUpTableToGet = "PaymentType"
        '    LookUpSortExpression = sortKey
        '    LookUpDisplayName = "PaymentTypeName"
        '    LookUpDisplayNameArabic = "PaymentTypeNameAra"
        '    LookUpDisplayCode = "PaymentTypeCode"
        '    Return GetLookupByCodeName()
        'End Function

        Public Function GetProductCategoryList(Optional ByVal sortKey As String = "ProductCategoryCode")
            LookUpTableToGet = "ProductCategory"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "ProductCategoryName"
            LookUpDisplayNameArabic = "ProductCategoryNameAra"
            LookUpDisplayCode = "ProductCategoryCode"
            Return GetLookupByCodeName()
        End Function

        Public Function GetRecords(ByVal pLookUpTableToGet As String, ByVal pDisplayName As String, ByVal pDisplayCode As String, Optional ByVal sortKey As String = "IdNo")
            LookUpTableToGet = pLookUpTableToGet
            LookUpSortExpression = sortKey
            LookUpDisplayName = pDisplayName
            LookUpDisplayNameArabic = pDisplayName
            LookUpDisplayCode = pDisplayCode
            Return GetLookupByCodeName()
        End Function

        'Public Function GetReligionList(Optional ByVal sortKey As String = "ReligionName")
        '    LookUpTableToGet = "Religion"
        '    LookUpSortExpression = sortKey
        '    LookUpDisplayName = "ReligionName"
        '    LookUpDisplayNameArabic = "ReligionNameAra"
        '    LookUpDisplayCode = "ReligionCode"
        '    Return GetTableList()
        'End Function
        Public Function GetRevCostCenterList(Optional ByVal sortKey As String = "RevCostCenterName")
            LookUpTableToGet = "RevCostCenter"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "RevCostCenterName"
            LookUpDisplayNameArabic = "RevCostCenterNameAra"
            LookUpDisplayCode = "RevCostCenterCode"
            Return GetTableList()
        End Function

        Public Function GetRevCostCenterListByCode(Optional ByVal sortKey As String = "RevCostCenterCode")
            LookUpTableToGet = "RevCostCenter"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "RevCostCenterName"
            LookUpDisplayNameArabic = "RevCostCenterNameAra"
            LookUpDisplayCode = "RevCostCenterCode"
            Return GetLookupByCodeName()
        End Function

        Public Function GetRevCostCenterListByName(Optional ByVal sortKey As String = "RevCostCenterName")
            LookUpTableToGet = "RevCostCenter"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "RevCostCenterName"
            LookUpDisplayNameArabic = "RevCostCenterNameAra"
            LookUpDisplayCode = "RevCostCenterCode"
            Return GetLookupByName()
        End Function

        Public Function GetRevenueGroupList(Optional ByVal sortKey As String = "RevenueGroupName")
            LookUpTableToGet = "RevenueGroup"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "RevenueGroupName"
            LookUpDisplayNameArabic = "RevenueGroupNameAra"
            LookUpDisplayCode = "RevenueGroupCode"
            Return GetTableList()
        End Function

        Public Function GetSupplierListByCode(Optional ByVal sortKey As String = "SupplierCode")
            LookUpTableToGet = "Supplier"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "SupplierName"
            LookUpDisplayNameArabic = "SupplierNameAra"
            LookUpDisplayCode = "SupplierCode"
            Return GetLookupByCodeName()
        End Function

        Public Function GetSupplierListByName(Optional ByVal sortKey As String = "SupplierName")
            LookUpTableToGet = "Supplier"
            LookUpSortExpression = sortKey
            LookUpDisplayName = "SupplierName"
            LookUpDisplayNameArabic = "SupplierNameAra"
            LookUpDisplayCode = "SupplierCode"
            Return GetLookupByNameCode()
        End Function

        Public Overrides Sub GoAddRecord()
            MyBase.GoAddRecord()
            MakeDefaultValues()
        End Sub

        Public Overridable Sub Initializer(baseClassName As String, Optional tableOrViewName As String = Nothing)
            Dim presenterModelName = $"AATM.Common.PresentationLayer.Models.ModelCommon"
            TableName = IIf(tableOrViewName Is Nothing, baseClassName, tableOrViewName)
            SortOrderKey = baseClassName + "Name"
            Dim args As Object() = {baseClassName}
            Dim t As Type = Type.GetType(presenterModelName)
            ModelPresenter = Activator.CreateInstance(t, args)
            OriginalModel = New TM
            DataModel = New TM
            'Dim presenterModelName = $"AATM.Accounts.PresentationLayer.Model." + baseClassName + "Model"
            'OriginalModel = Activator.CreateInstance(Type.GetType(presenterModelName))
            'DataModel = Activator.CreateInstance(Type.GetType(presenterModelName))
        End Sub

        Public Overridable Sub InitializerWithTv(baseClassName As String, Optional tableOrViewName As String = Nothing)
            TreeViewMainField = baseClassName + "Name"
            TreeViewSecondaryField = baseClassName + "Code"
            TreeViewList = New List(Of TM)
            Initializer(baseClassName, tableOrViewName)
        End Sub

        Public Sub MakeDefaultValues()
            For Each item In TableDefaultFieldValues
                Select Case item.DataType
                    Case DataTypeSelection.StringType
                        CallByName(View, item.FieldName, CallType.Set, item.DefaultValue)
                    Case DataTypeSelection.CharType
                        CallByName(View, item.FieldName, CallType.Set, item.DefaultValue)
                    Case DataTypeSelection.IntegerType
                        CallByName(View, item.FieldName, CallType.Set, CInt(item.DefaultValue))
                    Case DataTypeSelection.BooleanType
                        CallByName(View, item.FieldName, CallType.Set, CBool(item.DefaultValue))
                    Case DataTypeSelection.SingleType
                        CallByName(View, item.FieldName, CallType.Set, CSng(item.DefaultValue))
                    Case DataTypeSelection.DoubleType
                        CallByName(View, item.FieldName, CallType.Set, CDbl(item.DefaultValue))
                    Case DataTypeSelection.DecimalType
                        CallByName(View, item.FieldName, CallType.Set, CDec(item.DefaultValue))
                    Case DataTypeSelection.LongType
                        CallByName(View, item.FieldName, CallType.Set, CLng(item.DefaultValue))
                    Case DataTypeSelection.DateType
                        If item.DefaultValue = "today" Then
                            CallByName(View, item.FieldName, CallType.Set, Today())
                        ElseIf item.DefaultValue = "yesterday" Then
                            CallByName(View, item.FieldName, CallType.Set, DateTime.Now.AddDays(-1))
                        ElseIf item.DefaultValue = "tomorrow" Then
                            CallByName(View, item.FieldName, CallType.Set, DateTime.Now.AddDays(1))
                        Else
                            CallByName(View, item.FieldName, CallType.Set, CDate(item.DefaultValue))
                        End If
                    Case DataTypeSelection.ShortType
                        CallByName(View, item.FieldName, CallType.Set, CShort(item.DefaultValue))
                    Case DataTypeSelection.UIntegerType
                        CallByName(View, item.FieldName, CallType.Set, CUInt(item.DefaultValue))
                    Case DataTypeSelection.ULongType
                        CallByName(View, item.FieldName, CallType.Set, CULng(item.DefaultValue))
                    Case DataTypeSelection.UShortType
                        CallByName(View, item.FieldName, CallType.Set, CUShort(item.DefaultValue))
                    Case Else
                        MessageBox.Show($"Default Value Datatype Conversion for Field " & item.FieldName & " in table " & item.TableName & " conversion not handled")
                End Select
            Next item
            Return
        End Sub

        Private Sub OnBeforeEdit() Handles MyBase.BeforeEdit
            Dim type As Type = View.GetType
            If type.GetProperty("Posted") IsNot Nothing Then
                Dim cPosted = CallByName(View, "Posted", CallType.Get)
                If cPosted Then
                    Messaging.Show(True, "MsgEditingOfPostedRecordNotAllowed", $"This record has already been posted. Edits not allowed!", "Posted Entry")
                    CancelEdit = True
                End If
            End If
        End Sub

    End Class

End Namespace
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
            TableToGet = "Chart"
            SortExpression = sortKey
            DisplayName = "AccountName"
            DisplayNameArabic = "AccountNameAra"
            DisplayCode = "AccountCode"
            Dim values = accountType.Split(",")
            FilterKey = ""
            For Each account In values
                If FilterKey <> "" Then
                    FilterKey = FilterKey + " Or "
                End If
                FilterKey = FilterKey + "SpecialAccount = '" & account & "'"
            Next
            Return GetTableListFiltered()
        End Function

        Public Function GetBankList(Optional ByVal sortKey As String = "BankName")
            TableToGet = "Bank"
            SortExpression = sortKey
            DisplayName = "BankName"
            DisplayNameArabic = "BankNameAra"
            DisplayCode = "BankCode"
            Return GetLookupDataByNameWithCode()
        End Function

        Public Function GetChartList(Optional ByVal sortKey As String = "AccountName")
            TableToGet = "Chart"
            SortExpression = sortKey
            DisplayName = "AccountName"
            DisplayNameArabic = "AccountNameAra"
            DisplayCode = "AccountCode"
            Return GetLookupDataByCode()
        End Function

        Public Function GetCountryList(Optional ByVal sortKey As String = "CountryName")
            TableToGet = "Country"
            SortExpression = sortKey
            DisplayName = "CountryName"
            DisplayNameArabic = "CountryNameAra"
            DisplayCode = "Isoa2"
            Return GetLookupDataByNameWithCode()
        End Function

        Public Function GetCustomerListByCode(Optional ByVal sortKey As String = "CustomerCode")
            TableToGet = "Customer"
            SortExpression = sortKey
            DisplayName = "CustomerName"
            DisplayNameArabic = "CustomerNameAra"
            DisplayCode = "CustomerCode"
            Return GetLookupDataByCode()
        End Function

        Public Function GetCustomerListByName(Optional ByVal sortKey As String = "CustomerName")
            TableToGet = "Customer"
            SortExpression = sortKey
            DisplayName = "CustomerName"
            DisplayNameArabic = "CustomerNameAra"
            DisplayCode = "CustomerCode"
            Return GetLookupDataByNameWithCode()
        End Function

        Public Function GetDepartmentList(Optional ByVal sortKey As String = "DepartmentName")
            TableToGet = "Department"
            SortExpression = sortKey
            DisplayName = "DepartmentName"
            DisplayNameArabic = "DepartmentNameAra"
            DisplayCode = "DepartmentCode"
            Return GetTableList()
        End Function

        Public Function GetDepartmentListByName(Optional ByVal sortKey As String = "DepartmentName")
            TableToGet = "Department"
            SortExpression = sortKey
            DisplayName = "DepartmentName"
            DisplayNameArabic = "DepartmentNameAra"
            DisplayCode = "DepartmentCode"
            Return GetLookupDataByName()
        End Function

        Public Function GetDesignationList(Optional ByVal sortKey As String = "DesignationName")
            TableToGet = "Designation"
            SortExpression = sortKey
            DisplayName = "DesignationName"
            DisplayNameArabic = "DesignationNameAra"
            DisplayCode = "DesignationCode"
            Return GetTableList()
        End Function

        Public Function GetDetailAccountList(Optional ByVal sortKey As String = "AccountCode")
            TableToGet = "Chart"
            SortExpression = sortKey
            DisplayName = "AccountName"
            DisplayNameArabic = "AccountNameAra"
            DisplayCode = "AccountCode"
            FilterKey = "DetailAccount=1"
            Return GetLookupFilteredData()
        End Function

        Public Function GetDetailAccountListByCode(Optional ByVal sortKey As String = "AccountCode")
            TableToGet = "Chart"
            SortExpression = sortKey
            DisplayName = "AccountName"
            DisplayNameArabic = "AccountNameAra"
            DisplayCode = "AccountCode"
            FilterKey = "DetailAccount=1"
            Return GetLookupFilteredDataByCode()
        End Function

        Public Function GetPayGroupListByCode(Optional ByVal sortKey As String = "PayGroupCode")
            TableToGet = "PayGroup"
            SortExpression = sortKey
            DisplayName = "PayGroupName"
            DisplayNameArabic = "PayGroupNameAra"
            DisplayCode = "PayGroupCode"
            Return GetLookupDataByCode()
        End Function

        Public Function GetDetailAccountListByName(Optional ByVal sortKey As String = "AccountName")
            TableToGet = "Chart"
            SortExpression = sortKey
            DisplayName = "AccountName"
            DisplayNameArabic = "AccountNameAra"
            DisplayCode = "AccountCode"
            FilterKey = "DetailAccount=1"
            Return GetLookupFilteredDataByName()
        End Function

        Public Function GetEmployeeListByCode(Optional ByVal sortKey As String = "EmployeeName")
            TableToGet = "Employee"
            SortExpression = sortKey
            DisplayName = "EmployeeName"
            DisplayNameArabic = "EmployeeNameAra"
            DisplayCode = "EmployeeCode"
            Return GetLookupDataByCode()
        End Function

        Public Function GetEmployeeListByName(Optional ByVal sortKey As String = "EmployeeName")
            TableToGet = "Employee"
            SortExpression = sortKey
            DisplayName = "EmployeeName"
            DisplayNameArabic = "EmployeeNameAra"
            DisplayCode = "EmployeeCode"
            Return GetLookupDataByNameWithCode()
        End Function

        'Public Function GetPayGroupList(Optional ByVal sortKey As String = "PayGroupName")
        '    TableToGet = "PayGroup"
        '    SortExpression = sortKey
        '    DisplayName = "PayGroupName"
        '    DisplayNameArabic = "PayGroupNameAra"
        '    DisplayCode = "PayGroupCode"
        '    Return GetTableList()
        'End Function

        Public Function GetListByCode(listName As String)
            TableToGet = listName
            DisplayName = listName + "Name"
            SortExpression = DisplayName
            DisplayNameArabic = DisplayName + "Ara"
            DisplayCode = listName + "Code"
            Return GetLookupDataByCode()
        End Function

        Public Function GetProductCategoryList(Optional ByVal sortKey As String = "ProductCategoryCode")
            TableToGet = "ProductCategory"
            SortExpression = sortKey
            DisplayName = "ProductCategoryName"
            DisplayNameArabic = "ProductCategoryNameAra"
            DisplayCode = "ProductCategoryCode"
            Return GetLookupDataByCode()
        End Function

        Public Function GetRecords(ByVal pTableToGet As String, ByVal pDisplayName As String, ByVal pDisplayCode As String, Optional ByVal sortKey As String = "IdNo")
            TableToGet = pTableToGet
            SortExpression = sortKey
            DisplayName = pDisplayName
            DisplayNameArabic = pDisplayName
            DisplayCode = pDisplayCode
            Return GetLookupDataByCode()
        End Function

        Public Function GetReligionList(Optional ByVal sortKey As String = "ReligionName")
            TableToGet = "Religion"
            SortExpression = sortKey
            DisplayName = "ReligionName"
            DisplayNameArabic = "ReligionNameAra"
            DisplayCode = "ReligionCode"
            Return GetTableList()
        End Function

        Public Function GetCountryTelIdNoList(Optional ByVal sortKey As String = "CountryName")
            Return GetLookupData("CountryName", "CountryNameAra", "CountryTelCode",
                                 "Country", sortKey, "")
        End Function

        Public Function GetRevCostCenterList(Optional ByVal sortKey As String = "RevCostCenterName")
            TableToGet = "RevCostCenter"
            SortExpression = sortKey
            DisplayName = "RevCostCenterName"
            DisplayNameArabic = "RevCostCenterNameAra"
            DisplayCode = "RevCostCenterCode"
            Return GetTableList()
        End Function

        Public Function GetRevCostCenterListByCode(Optional ByVal sortKey As String = "RevCostCenterCode")
            TableToGet = "RevCostCenter"
            SortExpression = sortKey
            DisplayName = "RevCostCenterName"
            DisplayNameArabic = "RevCostCenterNameAra"
            DisplayCode = "RevCostCenterCode"
            Return GetLookupDataByCode()
        End Function

        Public Function GetRevCostCenterListByName(Optional ByVal sortKey As String = "RevCostCenterName")
            TableToGet = "RevCostCenter"
            SortExpression = sortKey
            DisplayName = "RevCostCenterName"
            DisplayNameArabic = "RevCostCenterNameAra"
            DisplayCode = "RevCostCenterCode"
            Return GetLookupDataByName()
        End Function

        Public Function GetRevenueGroupList(Optional ByVal sortKey As String = "RevenueGroupName")
            TableToGet = "RevenueGroup"
            SortExpression = sortKey
            DisplayName = "RevenueGroupName"
            DisplayNameArabic = "RevenueGroupNameAra"
            DisplayCode = "RevenueGroupCode"
            Return GetTableList()
        End Function

        Public Function GetPayGroupList(Optional ByVal sortKey As String = "PayGroupName")
            TableToGet = "PayGroup"
            SortExpression = sortKey
            DisplayName = "PayGroupName"
            DisplayNameArabic = "PayGroupNameAra"
            DisplayCode = "PayGroupCode"
            Return GetTableList()
        End Function

        Public Function GetSupplierListByCode(Optional ByVal sortKey As String = "SupplierCode")
            TableToGet = "Supplier"
            SortExpression = sortKey
            DisplayName = "SupplierName"
            DisplayNameArabic = "SupplierNameAra"
            DisplayCode = "SupplierCode"
            Return GetLookupDataByCode()
        End Function

        Public Function GetSupplierListByName(Optional ByVal sortKey As String = "SupplierName")
            TableToGet = "Supplier"
            SortExpression = sortKey
            DisplayName = "SupplierName"
            DisplayNameArabic = "SupplierNameAra"
            DisplayCode = "SupplierCode"
            Return GetLookupDataByNameWithCode()
        End Function

        Public Overrides Sub GoAddRecord()
            MyBase.GoAddRecord()
            MakeDefaultValues()
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
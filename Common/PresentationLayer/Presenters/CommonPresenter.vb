Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views
Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Presenters

    Public Class CommonPresenter(Of T As IView, TM As New)
        Inherits Presenter(Of T, TM)

        Private Shared Shadows Property CommonModel As IModelCommon

        Shared Sub New()
            CommonModel = New ModelCommon()
        End Sub

        Public Sub New(view As IView)
            MyBase.New(view)
        End Sub


        Public Function GetChartList(Optional ByVal sortKey As String = "AccountName")
            TableToGet = "Chart"
            SortExpression = sortKey
            DisplayName = "AccountName"
            DisplayNameArabic = "AccountNameAra"
            DisplayCode = "AccountCode"
            Return GetLookupDataByCode()
        End Function

        Public Function GetRevenueGroupList(Optional ByVal sortKey As String = "RevenueGroupName")
            TableToGet = "RevenueGroup"
            SortExpression = sortKey
            DisplayName = "RevenueGroupName"
            DisplayNameArabic = "RevenueGroupNameAra"
            DisplayCode = "RevenueGroupCode"
            Return GetTableList()
        End Function

        Public Function GetProfitCenterList(Optional ByVal sortKey As String = "ProfitCenterName")
            TableToGet = "ProfitCenter"
            SortExpression = sortKey
            DisplayName = "ProfitCenterName"
            DisplayNameArabic = "ProfitCenterNameAra"
            DisplayCode = "ProfitCenterCode"
            Return GetTableList()
        End Function

        Public Function GetCostCenterList(Optional ByVal sortKey As String = "CostCenterName")
            TableToGet = "CostCenter"
            SortExpression = sortKey
            DisplayName = "CostCenterName"
            DisplayNameArabic = "CostCenterNameAra"
            DisplayCode = "CostCenterCode"
            Return GetTableList()
        End Function

        Public Function GetDepartmentList(Optional ByVal sortKey As String = "DepartmentName")
            TableToGet = "Department"
            SortExpression = sortKey
            DisplayName = "DepartmentName"
            DisplayNameArabic = "DepartmentNameAra"
            DisplayCode = "DepartmentCode"
            Return GetTableList()
        End Function

        Public Function GetEmployeeListByCode(Optional ByVal sortKey As String = "EmployeeName")
            TableToGet = "Employee"
            SortExpression = sortKey
            DisplayName = "EmployeeName"
            DisplayNameArabic = "EmployeeNameAra"
            DisplayCode = "EmployeeCode"
            Return GetLookupDataByCode()
        End Function

        Public Function GetCategoryList(Optional ByVal sortKey As String = "CategoryCode")
            TableToGet = "Category"
            SortExpression = sortKey
            DisplayName = "CategoryName"
            DisplayNameArabic = "CategoryNameAra"
            DisplayCode = "CategoryCode"
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

        Public Function GetBankList(Optional ByVal sortKey As String = "BankName")
            TableToGet = "Bank"
            SortExpression = sortKey
            DisplayName = "BankName"
            DisplayNameArabic = "BankNameAra"
            DisplayCode = "BankCode"
            Return GetLookupDataByNameWithCode()
        End Function

        Public Function GetReligionList(Optional ByVal sortKey As String = "ReligionName")
            TableToGet = "Religion"
            SortExpression = sortKey
            DisplayName = "ReligionName"
            DisplayNameArabic = "ReligionNameAra"
            DisplayCode = "ReligionCode"
            Return GetTableList()
        End Function

        Public Function GetDesignationList(Optional ByVal sortKey As String = "DesignationName")
            TableToGet = "Designation"
            SortExpression = sortKey
            DisplayName = "DesignationName"
            DisplayNameArabic = "DesignationNameAra"
            DisplayCode = "DesignationCode"
            Return GetTableList()
        End Function

        Public Function GetProfitCenterListByCode(Optional ByVal sortKey As String = "ProfitCenterCode")
            TableToGet = "ProfitCenter"
            SortExpression = sortKey
            DisplayName = "ProfitCenterName"
            DisplayNameArabic = "ProfitCenterNameAra"
            DisplayCode = "ProfitCenterCode"
            Return GetLookupDataByCode()
        End Function

        Public Function GetProfitCenterListByName(Optional ByVal sortKey As String = "ProfitCenterName")
            TableToGet = "ProfitCenter"
            SortExpression = sortKey
            DisplayName = "ProfitCenterName"
            DisplayNameArabic = "ProfitCenterNameAra"
            DisplayCode = "ProfitCenterCode"
            Return GetLookupDataByName()
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
            Return GetLookupDataByName()
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
            Return GetLookupDataByName()
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

        Public Function GetDetailAccountListByName(Optional ByVal sortKey As String = "AccountName")
            TableToGet = "Chart"
            SortExpression = sortKey
            DisplayName = "AccountName"
            DisplayNameArabic = "AccountNameAra"
            DisplayCode = "AccountCode"
            FilterKey = "DetailAccount=1"
            Return GetLookupFilteredDataByName()
        End Function

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

    End Class

End Namespace
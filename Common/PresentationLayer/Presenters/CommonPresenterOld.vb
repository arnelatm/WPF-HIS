Imports System.Globalization
Imports AATM.BusinessLayer
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class CommonPresenterOld(Of T As IView, TBiz As BusinessObject, TM As New)
        Inherits PresenterOld(Of T, TBiz, TM)

        'Public Overloads Shared Property ModelModelCommon As IModelCommonOld

        'Shared Sub New()
        '    ModelModelCommon = New ModelModelCommon()
        'End Sub

        Public Sub New(view As T)
            MyBase.New(view)
        End Sub

#Region "GetLookupTable"

        Private Property TableToGet As String
        Private Property SortExpression As String
        Private Property DisplayName As String
        Private Property DisplayCode As String
        Private Property DisplayNameArabic As String
        Private Property FilterKey As String = Nothing
        Private Property FieldsToShow As String()
        Private Property DisplayFieldName As String

        Public Function GetSecurityGroupList(Optional ByVal sortKey As String = "SecurityGroupName")
            TableToGet = "SecurityGroup"
            SortExpression = sortKey
            DisplayName = "SecurityGroupName"
            DisplayNameArabic = "SecurityGroupNameAra"
            DisplayCode = "SecurityGroupCode"
            Return GetLookupDataByCode()
        End Function

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

        Public Function GetDetailAccountList(Optional ByVal sortKey As String = "AccountName")
            TableToGet = "Chart"
            SortExpression = sortKey
            DisplayName = "AccountName"
            DisplayNameArabic = "AccountNameAra"
            DisplayCode = "AccountCode"
            FilterKey = "DetailAccount=1"
            Return GetTableListFiltered()
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
            TableToGet = "AccountTypes_View"
            SortExpression = sortKey
            DisplayName = "AccountName"
            DisplayNameArabic = "AccountNameAra"
            DisplayCode = "AccountCode"
            FilterKey = "AccountTypes = '" & accountType & "'"
            Return GetTableListFiltered()
        End Function

        Private Function GetLookupDataByCode()
            FormatFields()
            Return Model.GetLookupDataByCode(TableToGet, SortExpression, FieldsToShow)
        End Function

        Private Function GetLookupDataByName()
            FormatFields()
            Return Model.GetLookupDataByName(TableToGet, SortExpression, FieldsToShow)
        End Function

        Private Function GetLookupDataByNameWithCode()
            FormatFields()
            Return Model.GetLookupDataByNameWithCode(TableToGet, SortExpression, FieldsToShow)
        End Function

        Private Function GetTableList()
            FormatFields()
            Return Model.GetRecords(TableToGet, SortExpression, FieldsToShow)
        End Function

        Public Function GetTableListFiltered()
            FormatFields()
            Return Model.GetRecordsFiltered(TableToGet, SortExpression, FilterKey, FieldsToShow)
        End Function

        Private Function GetLookupFilteredDataByName()
            FormatFields()
            Return Model.GetLookupFilteredDataByName(TableToGet, SortExpression, FilterKey, FieldsToShow)
        End Function

        Private Function GetLookupFilteredDataByCode()
            FormatFields()
            Return Model.GetLookupFilteredDataByCode(TableToGet, SortExpression, FilterKey, FieldsToShow)
        End Function

        Private Sub FormatFields()
            Dim displayFieldName As String
            If IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
                If SortExpression = DisplayName Then
                    SortExpression = DisplayNameArabic
                End If
                displayFieldName = DisplayNameArabic
            Else
                displayFieldName = DisplayName
            End If
            FieldsToShow = {"IdNo", displayFieldName, DisplayCode}
        End Sub

#End Region

    End Class

End Namespace
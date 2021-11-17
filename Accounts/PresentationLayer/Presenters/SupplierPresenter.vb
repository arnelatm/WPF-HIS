Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class SupplierPresenter(Of TM As New)
        Inherits AccountsPresenterNew(Of ISupplierView, TM)

        Public ParentViewList As List(Of SupplierModel)

        Public Sub New(view As ISupplierView)
            MyBase.New(view)
            If view IsNot Nothing Then
                TableName = "Supplier"
                Service = New AccountsService("Supplier")
                TreeViewMainField = "SupplierName"
                TreeViewSecondaryField = "SupplierCode"
                SortOrderKey = "SupplierName"
                'OriginalModel = New SupplierModel()
                'DataModel = New SupplierModel
            End If
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateEnumDataSource(Of AccountStatusSelection)("AccountStatus")
            CreateEnumDataSource(Of PaymentMethodSelection)("PaymentMethod")
            CreateDataSource("Bank", "BankIdNo")
            CreateDataSource("Country", "CountryCode")
            CreateDataSource("Account", "ExpAccountIdNo", "DetailAccount=1")
            CreateSpecialAccountDataSource("ApAccountIdNo", {EnumToCode(SpecialAccountSelection.AccountsPayable)})
        End Sub


        Public Function GetSupplierBalance(idNo As Integer)
            Return Service.GetFieldValue(Of Decimal)("Sum(Credit-Debit)", "ApStatement_View", "SupplierIdNo = " & idNo.ToString() & " and SpecialAccount = 'AP'")
        End Function

        Private Function FunctionOnSuccessfulUpdate() Handles MyBase.RecordUpdatedSuccessfully
            Dim retVal As Integer
            retVal = UpdateOpeningBalance()
            Return retVal
        End Function

        Private Function OnSuccessfulAdd() Handles MyBase.RecordAddedSuccessfully
            Dim retVal As Integer
            retVal = UpdateOpeningBalance()
            Return retVal
        End Function

        Public Function UpdateOpeningBalance()
            Return Service.UpdateOpeningBalance(Model)
        End Function

        Public Sub UpdateCode(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            If retVal >= 0 And IsEmpty(View.SupplierCode) Then
                retVal = Service.GenerateCode(View.IdNo)
                View.SupplierCode = Service.GetFieldWithIdNo(View.IdNo, "Supplier", "SupplierCode")
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

        Protected Overrides Sub UpdateViewDisplay()
            MyBase.UpdateViewDisplay()
            Dim value As Double
            value = Convert.ToDouble(GetSupplierBalance(TargetIdNo))
            View.Balance = value.ToString("N2")
        End Sub

    End Class

End Namespace
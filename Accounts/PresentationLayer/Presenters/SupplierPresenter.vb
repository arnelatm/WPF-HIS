Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Presenters

    Public Class SupplierPresenter
        Inherits AccountsPresenterNew(Of ISupplierView, SupplierModel)

        Public ParentViewList As List(Of SupplierModel)

        Public Sub New(view As ISupplierView)
            MyBase.New(view)
            If view IsNot Nothing Then
                TableName = "Supplier"
                Service = New ServiceAccounts("Supplier")
                TreeViewMainField = "SupplierName"
                TreeViewSecondaryField = "SupplierCode"
                SortOrderKey = "SupplierName"
                OriginalModel = New SupplierModel()
                DataModel = New SupplierModel
            End If
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
            Return Service.UpdateOpeningBalance(DataModel)
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
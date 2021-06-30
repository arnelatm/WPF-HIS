Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class CustomerPresenterNew
        Inherits AccountsPresenterNew(Of ICustomerView, CustomerModel)

        Public ParentViewList As List(Of CustomerModel)

        Public Sub New(view As ICustomerView)
            MyBase.New(view)
            TableName = "Customer"
            ModelOfPresenter = New ModelAccounts("Customer")
            TreeViewMainField = "CustomerName"
            TreeViewSecondaryField = "CustomerCode"
            SortOrderKey = "CustomerName"
            OriginalModel = New CustomerModel()
            DataModel = New CustomerModel
        End Sub

        Private Sub OnSuccessfulUpdate(ByRef retVal As Integer) Handles MyBase.RecordUpdatedSuccessfully, MyBase.RecordAddedSuccessfully
            retVal = ModelOfPresenter.UpdateOpeningBalance(DataModel)
        End Sub

        Public Sub UpdateCode(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            'Dim passedValue As Integer = retVal
            If retVal >= 0 And GlobalFunctions.IsEmpty(View.CustomerCode) Then
                retVal = ModelOfPresenter.GenerateCode(View.IdNo)
                View.CustomerCode = ModelOfPresenter.GetFieldWithIdNo(View.IdNo, "Customer", "CustomerCode")
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

        Public Overrides Sub UpdateViewDisplay(idNo As Int32)
            MyBase.UpdateViewDisplay(idNo)
            Dim value As Double
            value = Convert.ToDouble(GetCustomerBalance(idNo))
            View.Balance = value.ToString("N2")
        End Sub

        Public Function GetCustomerBalance(idNo As Integer)
            Return Model.GetFieldValue(Of Decimal)("Sum(Debit-Credit)", "ArStatement_View", "CustomerIdNo = " & idNo.ToString())
        End Function

    End Class

End Namespace
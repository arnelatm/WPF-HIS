Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class CustomerPresenter(Of TM As New)
        Inherits AccountsPresenterNew(Of ICustomerView, TM)

        Public ParentViewList As List(Of TM)

        Public Sub New(view As ICustomerView)
            MyBase.New(view)
            TableName = "Customer"
            Service = New AccountsService("Customer")
            TreeViewMainField = "CustomerName"
            TreeViewSecondaryField = "CustomerCode"
            SortOrderKey = "CustomerName"
            'OriginalModel = New CustomerModel()
            'DataModel = New CustomerModel
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateEnumDataSource(Of PaymentMethodSelection)("PaymentMethod")
            CreateEnumDataSource(Of AccountStatusSelection)("AccountStatus")
            CreateDataSource("Country", "CountryCode")
            CreateDataSource("Bank", "BankIdNo")
            CreateDataSource("DiscountScheme", "DiscountSchemeIdNo")
            CreateSpecialAccountDataSource("ArAccountIdNo", {EnumToCode(SpecialAccountSelection.AccountsReceivable)})
            CreateDataSource("Account", "RevAccountIdNo", "DetailAccount=1")
        End Sub

        Private Sub OnSuccessfulUpdate(ByRef retVal As Integer) Handles MyBase.RecordUpdatedSuccessfully, MyBase.RecordAddedSuccessfully
            retVal = Service.UpdateOpeningBalance(Model)
        End Sub

        Public Sub UpdateCode(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            'Dim passedValue As Integer = retVal
            If retVal >= 0 And GlobalFunctions.IsEmpty(View.CustomerCode) Then
                retVal = Service.GenerateCode(View.IdNo)
                View.CustomerCode = Service.GetFieldWithIdNo(View.IdNo, "Customer", "CustomerCode")
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

        Protected Overrides Sub UpdateViewDisplay() 'idNo As Int32)
            MyBase.UpdateViewDisplay()
            Dim value As Double
            value = Convert.ToDouble(GetCustomerBalance(TargetIdNo))
            View.Balance = value.ToString("N2")
        End Sub

        Public Function GetCustomerBalance(idNo As Integer)
            Return Service.GetFieldValue(Of Decimal)("Sum(Debit-Credit)", "ArStatement_View", "CustomerIdNo = " & idNo.ToString())
        End Function

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int16)(View.IdNo, "ArJournal", "CustomerIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int16)(View.IdNo, "ArStatement_View", "CustomerIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int16)(View.IdNo, "ArInvoices_View", "CustomerIdNo") Then
                Return False
            End If
            Return False
        End Function

    End Class

End Namespace
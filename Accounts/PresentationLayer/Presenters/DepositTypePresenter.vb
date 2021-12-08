Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class DepositTypePresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IDepositTypeView, TM)

        Public Sub New(view As IDepositTypeView)
            MyBase.New(view)
            Service = New AccountsService("DepositType")
            TableName = "DepositType"
            TreeViewMainField = "DepositTypeName"
            TreeViewSecondaryField = "DepositTypeCode"
            SortOrderKey = "DepositTypeName"
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDetailAccountList("AccountIdNo")
            CreateDetailAccountList("BankChargesAccountIdNo")
            CreateDetailAccountList("BankChargesVatAccountIdNo")
        End Sub

        Protected Sub CreateDetailAccountList(fieldName As String)
            CreateDataSource("Account", fieldName, "DetailAccount=1")
        End Sub

        Private Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not View.WithBankCharges Then
                View.Rate = 0
                View.BankChargesAccountIdNo = Nothing
                View.BankChargesVatAccountIdNo = Nothing
            End If
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int32)(View.IdNo, "SalesDeposit", "DepositTypeIdNo") Then
                Return True
            End If
            Return False
        End Function

    End Class

End Namespace
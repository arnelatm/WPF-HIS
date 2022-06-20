Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class PayrollDeductAccountPresenter
        Inherits AccountsPresenter(Of IPayrollDeductAccountsView, PayrollDeductAccountModel)

        Public Sub New(view As IPayrollDeductAccountsView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("PayrollDeductAccount")
            TableName = "PayrollDeductAccount"
            SortOrderKey = "Sequence"
            DataModel = New PayrollDeductAccountModel
        End Sub

        '''' <summary>
        ''''     Displays list of  PayrollDeductAccount Items.
        '''' </summary>
        '''' <param name="DeductionIdNo">DeductionIdNo id to display.</param>
        Public Overloads Sub Display(DeductionIdNo As Int32)
            View.PayrollDeductAccounts = Model.GetRecordsWithGroupIdNo(Of PayrollDeductAccountModel)(DeductionIdNo, "DeductionIdNo")
        End Sub

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       DeductionIdNo As Int32)
            Dim insertReturnValue
            Dim updateReturnValue
            Dim retVal
            updateReturnValue = Model.DelUpdateTvp(dtUpdate, DeductionIdNo)
            If updateReturnValue >= 0 AndAlso dtInsert.Rows.Count > 0 Then
                insertReturnValue = Model.InsertTvp(dtInsert)
                If insertReturnValue >= 0 Then
                    retVal = updateReturnValue + insertReturnValue
                Else
                    retVal = insertReturnValue
                End If
            Else
                retVal = updateReturnValue
            End If
            Return retVal
        End Function

    End Class

End Namespace
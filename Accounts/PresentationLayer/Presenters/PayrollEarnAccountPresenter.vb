Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class PayrollEarnAccountPresenter
        Inherits AccountsPresenter(Of IPayrollEarnAccountsView, PayrollEarnAccountModel)

        Public Sub New(view As IPayrollEarnAccountsView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("PayrollEarnAccount")
            TableName = "PayrollEarnAccount"
            SortOrderKey = "Sequence"
            DataModel = New PayrollEarnAccountModel

        End Sub

        '''' <summary>
        ''''     Displays list of  PayrollEarnAccount Items.
        '''' </summary>
        '''' <param name="earningIdNo">EarningIdNo id to display.</param>
        Public Overloads Sub Display(earningIdNo As Int32)
            View.PayrollEarnAccounts = Model.GetRecordsWithGroupIdNo(Of PayrollEarnAccountModel)(earningIdNo, "EarningIdNo")
        End Sub

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       earningIdNo As Int32)
            Dim insertReturnValue
            Dim updateReturnValue
            Dim retVal
            updateReturnValue = Model.DelUpdateTvp(dtUpdate, earningIdNo)
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
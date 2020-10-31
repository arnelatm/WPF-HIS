Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class DeductionPresenter
        Inherits AccountsPresenter(Of IDeductionView, DeductionModel)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _payrollDeductAccountModel As New ModelAccounts("PayrollDeductAccount")

        Public Sub New(view As IDeductionView)
            MyBase.New(view)

            InitializerWithTv("Deduction")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

            DtInsertTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("DeductionIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("PayGroupIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtUpdateTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("DeductionIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("PayGroupIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))

        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                ViewToDataTables(View.PayrollDeductAccounts, DtInsertTable, DtUpdateTable, AddressOf FillData, AddressOf PayrollDeductAccountFilter)
            End If
        End Sub

        Private Sub FillData(ByRef item As Object, ByVal idNo As Integer, ByRef workRow As DataRow)
            workRow("AccountIdNo") = item.AccountIdNo
            workRow("DeductionIdNo") = View.IdNo
            workRow("PayGroupIdNo") = item.PayGroupIdNo
        End Sub

        Public Function PayrollDeductAccountFilter(ByVal obj As Object) As Boolean
            If (obj.AccountIdNo Is Nothing Or obj.AccountIdNo = 0) Then 'AndAlso (obj.PayGroupIdNo Is Nothing Or obj.PayGroupIdNo = 0) Then
                Return False
            End If
            Return True
        End Function

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_payrollDeductAccountModel, DtUpdateTable, DtInsertTable, passedValue, "DeductionIdNo")
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                retValue = True
                If Not UsePayGroups() Then
                    If View.AccountIdNo <= 0 Then
                        Messaging.Show(True, "MsgPostingAccountMustNotBeBlank")
                        retValue = False
                    End If
                End If
            End If
                Return retValue
        End Function

    End Class

End Namespace
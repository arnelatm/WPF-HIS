Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class SupplierPresenter
        Inherits AccountsPresenter(Of ISupplierView, SupplierModel)

        Public ParentViewList As List(Of SupplierModel)

        Public Sub New(view As ISupplierView)
            MyBase.New(view)
            InitializerWithTv("Supplier")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

        End Sub

        Public Function GetSupplierBalance(idNo As Integer)
            Return Model.GetFieldValue(Of Decimal)("Sum(Credit-Debit)", "ApStatement_View", "SupplierIdNo = " & idNo.ToString())
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
            Return ModelOfPresenter.UpdateOpeningBalance(DataModel)
        End Function

        Public Sub UpdateCode(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            'Dim passedValue As Integer = retVal
            If retVal >= 0 And GlobalFunctions.IsEmpty(View.SupplierCode) Then
                retVal = ModelOfPresenter.GenerateCode(View.IdNo)
            End If
        End Sub

        Public Overrides Sub GoFilter()
            If DataFilter Is Nothing Or DataFilter = "" Then
                DataFilter = "Active = 1"
            Else
                DataFilter = ""
            End If
            CallByName(View, "DisplayTreeViewData", CallType.Method)
            GoFirstRecord()
        End Sub

    End Class

End Namespace
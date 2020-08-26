Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries

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
            Return Model.GetSqlValue(Of Decimal)("Sum(Credit-Debit)", "ApStatement_View", "SupplierIdNo = " & idNo.ToString())
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
            Return ModelPresenter.UpdateOpeningBalance(DataModel)
        End Function

    End Class

End Namespace
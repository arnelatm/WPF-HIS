Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class CustomerPresenter
        Inherits AccountsPresenter(Of ICustomerView, CustomerModel)

        Public ParentViewList As List(Of CustomerModel)

        Public Sub New(view As ICustomerView)
            MyBase.New(view)
            InitializerWithTv("Customer")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Function GetCustomerBalance(idNo As Integer)
            Return Model.GetFieldValue(Of Decimal)("Sum(Debit-Credit)", "ArStatement_View", "CustomerIdNo = " & idNo.ToString())
        End Function

        Private Sub OnSuccessfulUpdate(ByRef retVal As Integer) Handles MyBase.RecordUpdatedSuccessfully, MyBase.RecordAddedSuccessfully
            retVal = ModelOfPresenter.UpdateOpeningBalance(DataModel)
        End Sub

        Public Sub UpdateCode(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            'Dim passedValue As Integer = retVal
            If retVal >= 0 And GlobalFunctions.IsEmpty(View.CustomerCode) Then
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
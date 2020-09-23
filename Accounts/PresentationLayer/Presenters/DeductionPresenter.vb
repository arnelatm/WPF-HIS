Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class DeductionPresenter
        Inherits AccountsPresenter(Of IDeductionView, DeductionModel)

        Public Sub New(view As IDeductionView)
            MyBase.New(view)

            InitializerWithTv("Deduction")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

        End Sub

        'Private Sub OnBeforeSave() Handles MyBase.BeforeSave
        '    If GetEnumCodeValue(Of DeductionTypeSelection)(View.DeductionType) = DeductionTypeSelection.Others Then

        '    End If
        'End Sub

        'Protected Overrides Function IsBizDataValid() As Boolean
        '    Dim retValue = False
        '    If MyBase.IsBizDataValid() Then
        '        If View.DeductionType = EnumCode(DeductionTypeSelection.Others) Then
        '            View.DeductionType =
        '        End If
        '    End If
        '    Return retValue
        'End Function

    End Class

End Namespace
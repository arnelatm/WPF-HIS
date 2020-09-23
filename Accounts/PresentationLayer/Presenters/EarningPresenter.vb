Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class EarningPresenter
        Inherits AccountsPresenter(Of IEarningView, EarningModel)

        Public Sub New(view As IEarningView)
            MyBase.New(view)

            InitializerWithTv("Earning")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

        End Sub

        'Private Sub OnBeforeSave() Handles MyBase.BeforeSave
        '    If GetEnumCodeValue(Of EarningTypeSelection)(View.EarningType) = EarningTypeSelection.Others Then

        '    End If
        'End Sub

        'Protected Overrides Function IsBizDataValid() As Boolean
        '    Dim retValue = False
        '    If MyBase.IsBizDataValid() Then
        '        If View.EarningType = EnumCode(EarningTypeSelection.Others) Then
        '            View.EarningType =
        '        End If
        '    End If
        '    Return retValue
        'End Function

    End Class

End Namespace
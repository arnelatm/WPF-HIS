Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class LeavePresenter
        Inherits AccountsPresenter(Of ILeaveView, LeaveModel)

        Public Sub New(view As ILeaveView)
            MyBase.New(view)

            InitializerWithTv("Leave")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

        End Sub

        'Private Sub OnBeforeSave() Handles MyBase.BeforeSave
        '    If GetEnumCodeValue(Of LeaveTypeSelection)(View.LeaveType) = LeaveTypeSelection.Others Then

        '    End If
        'End Sub

        'Protected Overrides Function IsBizDataValid() As Boolean
        '    Dim retValue = False
        '    If MyBase.IsBizDataValid() Then
        '        If View.LeaveType = EnumCode(LeaveTypeSelection.Others) Then
        '            View.LeaveType =
        '        End If
        '    End If
        '    Return retValue
        'End Function

    End Class

End Namespace
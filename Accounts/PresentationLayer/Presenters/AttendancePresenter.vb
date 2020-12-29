Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class AttendancePresenter
        Inherits AccountsPresenter(Of IAttendanceView, AttendanceModel)

        Public Sub New(view As IAttendanceView)
            MyBase.New(view)

            Initializer("PayPeriod")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

        End Sub

        'Protected Overrides Function IsBizDataValid() As Boolean
        '    Dim retValue = False
        '    If MyBase.IsBizDataValid() Then
        '        retValue = True
        '    End If
        '    Return retValue
        'End Function

    End Class

End Namespace
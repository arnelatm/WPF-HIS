Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class AttendancePresenter
        Inherits AccountsPresenter(Of IAttendanceItemView, AttendanceItemModel)

        Public Sub New(itemView As IAttendanceItemView)
            MyBase.New(itemView)

            Initializer("Payroll")
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
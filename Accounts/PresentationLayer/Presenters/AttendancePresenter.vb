Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class AttendancePresenter
        Inherits AccountsPresenterNew(Of IAttendanceItemView, AttendanceItemModel)

        Public Sub New(itemView As IAttendanceItemView)
            MyBase.New(itemView)
            Service = New AccountsService("Payroll")
            TableName = "Payroll"
            TreeViewMainField = "PayrollName"
            'TreeViewSecondaryField = "PayrollCode"
            SortOrderKey = "PayrollName"
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
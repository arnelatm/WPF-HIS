Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PayrollEarningModel

        Public Property Amount As Decimal
        Public Property EmployeeIdNo As Int32
        Public Property EarningIdNo As Int16
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property PayPeriodIdNo As Int32

    End Class

End Namespace
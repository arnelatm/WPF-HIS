Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PayrollPayElementModel
        Public Property Amount As Decimal
        Public Property EmployeeIdNo As Int32
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property PayElementIdNo As Int16
        Public Property PayrollDetailIdNo As Int32
        Public Property PayrollIdNo As Int16
        Public Property RecurringPayElementIdNo As Int32
    End Class

End Namespace
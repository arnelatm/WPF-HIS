Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PayrollEarnAccountModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property EarningIdNo As Int16
        Public Property DepartmentIdNo As Int16
        Public Property EmployeeIdNo As Int32
    End Class

End Namespace
Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeEarningModel
        Public Property Amount As Decimal
        Public Property EarningCode As String
        Public Property EarningIdNo As String
        Public Property EarningName As String
        Public Property EarningNameAra As String
        Public Property EarningType As String
        Public Property EmployeeIdNo As Int32
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property Sequence As Int16

    End Class

End Namespace
Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeEarningModel

        Public Property EarningIdNo As String
        Public Property EmployeeIdNo As String
        Public Property EarningName As String
        Public Property EarningNameAra As String
        Public Property Errors As List(Of String)
        Public Property Frequency As Char
        Public Property IdNo As Int32
        Public Property Rate As Decimal
    End Class

End Namespace
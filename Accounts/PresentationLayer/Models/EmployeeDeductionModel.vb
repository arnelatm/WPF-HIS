Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeDeductionModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property EmployeeDeductionIdNo As Int16
        Public Property DeductionName As String
        Public Property DeductionNameAra As String
        Public Property EmployeeIdNo As String
        Public Property DeductionIdNo As String
        Public Property Frequency As Char
        Public Property Rate As Decimal

    End Class

End Namespace
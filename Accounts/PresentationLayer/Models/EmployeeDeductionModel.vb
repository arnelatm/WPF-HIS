Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeDeductionModel

        Public Property Amount As Decimal
        Public Property DeductionCode As String
        Public Property DeductionIdNo As Int16
        Public Property DeductionName As String
        Public Property DeductionNameAra As String
        Public Property DeductionType As String
        Public Property EmployeeIdNo As Integer
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32

    End Class

End Namespace
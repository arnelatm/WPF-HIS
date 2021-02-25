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
        Public Property DeductionType As Char
        Public Property EmployeeIdNo As Int32
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property Rate As Decimal
        Public Property Sequence As Int16
        Public Property Unit As String
    End Class

End Namespace
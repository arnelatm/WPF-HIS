Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PayrollDetailModel
        Public Property BankTransfer As Boolean
        Public Property EmployeeCode As String
        Public Property EmployeeIdNo As Int32
        Public Property EmployeeName As String
        Public Property EmployeeNameAra As String
        Public Property EndDate As Date
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property PayPeriodName As String
        Public Property PayPeriodNameAra As String
        Public Property PayrollDeductions As List(Of PayrollPayElementModel)
        Public Property PayrollEarnings As List(Of PayrollPayElementModel)
        Public Property PayrollIdNo As Int16
        Public Property PaymentMethod As String
        Public Property Posted As Boolean
        Public Property SponsorType as String
        Public Property StartDate As Date
        Public Property Selected As Boolean
    End Class

End Namespace
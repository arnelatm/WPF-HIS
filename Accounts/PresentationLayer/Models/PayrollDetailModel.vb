Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PayrollDetailModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property PayrollIdNo As Int16
        Public Property EmployeeIdNo As Int32
        Public Property EmployeeName As String
        Public Property EmployeeNameAra As String
        Public Property EmployeeCode As String
        Public Property PayrollEarnings As List(Of PayrollPayElementModel)
        Public Property PayrollDeductions As List(Of PayrollPayElementModel)

    End Class

End Namespace
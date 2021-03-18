Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeePayElementModel
        Public Property Amount As Decimal
        Public Property PayElementCode As String
        Public Property PayElementIdNo As Int16
        Public Property PayElementName As String
        Public Property PayElementNameAra As String
        Public Property PayElementType As Char
        Public Property EmployeeIdNo As Int32
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property Rate As Decimal
        Public Property Sequence As Int16
        Public Property Unit As String

    End Class

End Namespace
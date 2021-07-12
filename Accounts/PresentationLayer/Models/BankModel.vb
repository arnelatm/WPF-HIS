Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class BankModel
        Implements IModelNew

        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property BankCode As String
        Public Property BankName As String
        Public Property BankNameAra As String
        Public Property Notes As String
    End Class

End Namespace
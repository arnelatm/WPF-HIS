Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PayrollEarnAccountModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property EarningIdNo As Int16
        Public Property PayGroupIdNo As Int16
        Public Property PayGroupName As String
        Public Property AccountIdNo As Int16
        Public Property AccountName As String


    End Class

End Namespace
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PayrollEarnAccountModel
        Implements ISelfDuplicating

        Public Sub New()
        End Sub

        Public Property AccountIdNo As Int16
        Public Property AccountName As String
        Public Property EarningIdNo As Int16
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property PayGroupIdNo As Int16
        Public Property PayGroupName As String
        Public Property Sequence As Int16

        Public Function BlankCopy() As Object Implements ISelfDuplicating.BlankCopy
            Return New PayrollEarnAccountModel
        End Function

    End Class

End Namespace
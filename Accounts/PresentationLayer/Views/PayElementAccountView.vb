Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PayElementAccountView
        Implements IPayElementAccountView

        Public Property AccountIdNo As Int16 Implements IPayElementAccountView.AccountIdNo
        Public Property AccountName As String Implements IPayElementAccountView.AccountName
        Public Property PayElementIdNo As Int16 Implements IPayElementAccountView.PayElementIdNo
        Public Property IdNo As Int32 Implements IPayElementAccountView.IdNo
        Public Property PayGroupIdNo As Int16 Implements IPayElementAccountView.PayGroupIdNo
        Public Property PayGroupName As String Implements IPayElementAccountView.PayGroupName
        Public Property Sequence As Int16 Implements IPayElementAccountView.Sequence
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Errors As List(Of String) Implements IView.Errors


    End Class

End Namespace
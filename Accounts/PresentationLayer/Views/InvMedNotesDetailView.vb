Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class InvMedNotesDetailView
        Implements IInvMedNotesDetailView

        Public Property IdNo As Integer Implements IInvMedNotesDetailView.IdNo
        Public Property Seq As Integer Implements IInvMedNotesDetailView.Seq
        Public Property ItemCode As String Implements IInvMedNotesDetailView.ItemCode
        Public Property ItemName As String Implements IInvMedNotesDetailView.ItemName
        Public Property MRN As Int32 Implements IInvMedNotesDetailView.MRN
        Public Property Note As String Implements IInvMedNotesDetailView.Note
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property DataFilter As String Implements IView.DataFilter

    End Class

End Namespace
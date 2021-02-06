Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class TransactionsPresenter(Of T As IView, TM As New)
        Inherits AccountsPresenter(Of T, TM)

        Public Sub New(itemView As T)
            MyBase.New(itemView)
        End Sub

        Public Overrides Function IsOkToDeleteRecord() As Boolean
            Dim type As Type = View.GetType
            Dim retVal As Boolean = True
            If type.GetProperty("Posted") IsNot Nothing Then
                Dim cPosted = CallByName(View, "Posted", CallType.Get)
                If cPosted Then
                    Dim description As String = ""
                    description = Messaging.TranslateCaption("Posted")
                    Messaging.ShowParametrizedMessage(True, "MsgDeleteEntryNotAllowed", {"description", description})
                    retVal = False
                End If
            End If
            Return retVal
        End Function

        Public Overrides Function IsOkToEditRecord() As Boolean
            Dim type As Type = View.GetType
            Dim retVal As Boolean = True
            If type.GetProperty("Posted") IsNot Nothing Then
                Dim cPosted = CallByName(View, "Posted", CallType.Get)
                If cPosted Then
                    Messaging.Show(True, "MsgEditingOfPostedRecordNotAllowed", $"This record has already been posted. Edits not allowed!", "Posted Entry")
                    retVal = False
                End If
            End If
            Return retVal
        End Function

    End Class

End Namespace
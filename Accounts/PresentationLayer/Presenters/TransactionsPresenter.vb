Imports AATM.Libraries
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class TransactionsPresenter(Of T As IView, TM As New)
        Inherits AccountsPresenter(Of T, TM)
        Implements ISubscriber(Of ValidatingData)

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
            Dim retVal As Boolean = True
            If MyBase.IsOkToEditRecord() Then
                Dim type As Type = View.GetType
                Static closedTransactionDate As Date = GetRecordFieldWithKeyG(Of Date)("Closed Period", "LastPosting", "TransactionName", "LastPostingDate")
                If type.GetProperty("Posted") IsNot Nothing Then
                    Dim cPosted = CallByName(View, "Posted", CallType.Get)
                    If cPosted Then
                        Messaging.Show(True, "MsgEditingOfPostedRecordNotAllowed")
                        retVal = False
                    End If
                End If
                If retVal AndAlso type.GetProperty("TransactionDate") IsNot Nothing Then
                    Dim cTransactionDate = CallByName(View, "TransactionDate", CallType.Get)
                    If cTransactionDate <= closedTransactionDate Then
                        Messaging.Show(True, "MsgEditingClosedTransaction")
                        retVal = False
                    End If
                End If
                Dim approved = CallByName(View, "Approved", CallType.Get)
                If retVal AndAlso type.GetProperty("Approved") IsNot Nothing Then
                    Dim approved = CallByName(View, "Approved", CallType.Get)
                    If approved Then
                        Messaging.Show(True, "MsgEditingApprovedTransaction")
                        retVal = False
                    End If
                End If
            End If
            Return retVal
        End Function

        Public Sub OnValidatingDataTransactionEvent(ByRef eventType As ValidatingData) Implements ISubscriber(Of ValidatingData).OnEventHandler
            Dim type As Type = View.GetType
            Dim retVal As Boolean = True
            Static closedTransactionDate As Date = GetRecordFieldWithKeyG(Of Date)("Closed Period", "LastPosting", "TransactionName", "LastPostingDate")
            If type.GetProperty("TransactionDate") IsNot Nothing Then
                Dim cTransactionDate = CallByName(View, "TransactionDate", CallType.Get)
                If cTransactionDate <= closedTransactionDate Then
                    Messaging.Show(True, "MsgTransactionDateClosed")
                    eventType.Validated = False
                End If
            End If
        End Sub

    End Class

End Namespace
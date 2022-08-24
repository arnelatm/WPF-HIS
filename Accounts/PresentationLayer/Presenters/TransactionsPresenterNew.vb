Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class TransactionsPresenterNew(Of TV As IView, TM As New)
        Inherits AccountsPresenter(Of TV, TM)
        Implements ISubscriber(Of ValidatingData)

        Public Sub New(itemView As IView)
            MyBase.New(itemView)
        End Sub

        Public Overrides Function IsOkToDeleteRecord() As Boolean
            Dim retVal As Boolean = True
            If MyBase.IsOkToDeleteRecord() Then
                Dim type As Type = View.GetType
                If type.GetProperty("Posted") IsNot Nothing Then
                    Dim cPosted = CallByName(View, "Posted", CallType.Get)
                    If cPosted Then
                        Dim description As String = ""
                        description = Messaging.TranslateCaption("Posted")
                        Messaging.ShowPmMessage(True, "MsgDeleteEntryNotAllowed", {"description", description})
                        retVal = False
                    End If
                End If
            Else
                retVal = False
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
                If retVal AndAlso type.GetProperty("Approved") IsNot Nothing Then
                    Dim approved = CallByName(View, "Approved", CallType.Get)
                    If retVal AndAlso approved Then
                        Dim controlSecurityValues As ArrayList
                        Dim isEditable As Boolean
                        Dim controlSecurityObjectIdNo As Int32
                        controlSecurityObjectIdNo = GetControlSecurityIdNo("ApproveTransactions")
                        controlSecurityValues = GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo)
                        If controlSecurityValues.Count > 0 Then
                            isEditable = controlSecurityValues(1)
                        Else
                            isEditable = False
                        End If
                        If isEditable Then
                            ' user has editing options for approved transactions
                        Else
                            Messaging.Show(True, "MsgEditingApprovedTransaction")
                            retVal = False
                        End If
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

        Public Function GetLocalizedPrefix(journalCode As String)
            Return Service.GetField(journalCode, "JournalPrefix", "JournalCode", "JournalCodeAra")
        End Function

    End Class

End Namespace
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.Messaging

Namespace PresentationLayer.Presenters

    Public Class AccountPresenter(Of TM As New)
        Inherits CommonPresenter(Of IAccountView, TM)

        Public ParentViewList As List(Of TM)

        Public Sub New(itemView As IAccountView)
            MyBase.New(itemView)
            AddHandler View.ParentIdUpdated, AddressOf OnParentIdUpdated
            Service = New AccountsService("Account")
            TableBaseName = "Account"
            TableName = "Account_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "AccountName"
            TreeViewSecondaryField = "AccountCode"
            ParentFieldName = "ParentIdNo"
        End Sub

        Protected Overrides Sub CreateDataSources()
            MakeControlDataSources({New Object() {"Account", "ParentIdNo", Nothing, Nothing}})
            CreateEnumDataSource(Of AccountGroupSelection)("AccountGroup")
            CreateEnumDataSource(Of PayeeTypeSelection)("PayeeType")
            CreateEnumDataSource(Of DebitCreditSelection)("NormalBalance")
            CreateEnumDataSource(Of SpecialAccountSelection)("SpecialAccount")
        End Sub

        Public Function EditableAccountGroup(ByVal idNo As Int32?, ByVal parentIdNo As Int32?) As Boolean
            If AccountHasChildren(idNo) Then
                Return False
            Else
                Dim parentAccount As AccountModel
                parentAccount = Service.GetRecordByIdNo(Of AccountModel)(parentIdNo)
                If parentAccount.AccountGroup Is Nothing Then
                    Return False
                Else
                    If parentAccount.AccountGroup = "S" Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
        End Function

        Public Function AccountHasChildren(ByVal idNo As Int32?) As Boolean
            If idNo Is Nothing Then
                Return True
            End If
            Return Service.CountRecordWithKey(Of Int16)("Account", "ParentIdNo", idNo) > 0
        End Function

        Public Function GetAccountNameOfChild(idNoToSearch As Integer) As String
            Return Service.GetField(Of Int32, String)(idNoToSearch, "Account", "ParentIdNo", "AccountName")
        End Function

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                If EditMode And View.ParentIdNo = View.IdNo Then
                    MessagingService.Show(True, "MsgMemberCannotBeAParentToItself")
                Else
                    retValue = True
                End If
            End If
            Return retValue
        End Function

        Private Sub OnParentIdUpdated(ByRef pEditableAccountGroup As Boolean)
            If EditableAccountGroup(View.IdNo, View.ParentIdNo) Then
                pEditableAccountGroup = False
            Else
                pEditableAccountGroup = True
            End If
            If View.ParentIdNo IsNot Nothing Then
                View.AccountGroup = GetFieldWithIdNo(View.ParentIdNo, "Account", "AccountGroup")
                View.LevelNumber = GetRecordFieldWithKeyG(Of Integer)(View.ParentIdNo, "Account_View", "IdNo", "LevelNumber") + 1
            End If
            If AccountHasChildren(View.IdNo) Then
                View.DetailAccount = False
            Else
                View.DetailAccount = True
            End If
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentJournalRecords("CdJournalItem", "Cash Disbursement") Then
                Return True
            ElseIf CheckDependentJournalRecords("PcJournalItem", "Petty Cash Disbursement") Then
                Return True
            ElseIf CheckDependentJournalRecords("CashReceiptJournalItem", "Cash Receipt") Then
                Return True
            ElseIf CheckDependentJournalRecords("ApJournalItem", "Accounts Payable") Then
                Return True
            ElseIf CheckDependentJournalRecords("ArJournalItem", "Accounts Receivable") Then
                Return True
            ElseIf CheckDependentJournalRecords("SalesJournalItem", "Sales Journal") Then
                Return True
            ElseIf CheckDependentJournalRecords("GeneralJournalItem", "General Journal") Then
                Return True
            ElseIf CheckDependentJournalRecords("ErJournalItem", "Employee Loans Journal") Then
                Return True
            ElseIf CheckDependentJournalRecords("PayElementAccount", "Pay Element Account", "PayElementIdNo") Then
                Return True
            End If
            Return False
        End Function

        Private Function CheckDependentJournalRecords(ByVal journalName As String, ByVal journalDescription As String, Optional returnFieldName As String = "JournalIdNo") As Boolean
            Dim transactionIdNo = Service.GetRecordFieldWithKeyG(Of Integer)(View.IdNo, journalName, "AccountIdNo", returnFieldName)
            If transactionIdNo > 0 Then
                Dim jdMessage = MessagingService.TranslateCaption(journalDescription)
                Dim additionalMessage = MessagingService.GetParametrizedMessage(True, "MsgSeeTransactionNumber", {"transactionName", jdMessage, "transactionNumber", transactionIdNo})
                Dim message = MessagingService.GetParametrizedMessage(True, "MsgDependentRecordExists", {"additionalMessage", additionalMessage})
                MessagingService.Show(message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return True
            End If
            Return False
        End Function

    End Class

End Namespace
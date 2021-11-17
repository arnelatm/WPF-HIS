Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class AccountPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IAccountView, TM)

        Public ParentViewList As List(Of TM)

        Public Sub New(itemView As IAccountView)
            MyBase.New(itemView)
            AddHandler View.ParentIdUpdated, AddressOf OnParentIdUpdated
            Service = New AccountsService("Account")
            TableName = "Account_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "AccountName"
            TreeViewSecondaryField = "AccountCode"
            ParentFieldName = "ParentIdNo"
        End Sub

        Public Overrides Sub CreateDataSources()
            CreateControlDataSource("Account", "ParentIdNo")
            CreateControlEnumDataSource(Of AccountGroupSelection)("AccountGroup")
            CreateControlEnumDataSource(Of PayeeTypeSelection)("PayeeType")
            CreateControlEnumDataSource(Of DebitCreditSelection)("NormalBalance")
            CreateControlEnumDataSource(Of SpecialAccountSelection)("SpecialAccount")
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
            Return Service.CountRecordWithKey(idNo, "Account", "ParentIdNo") > 0
        End Function

        Public Function GetAccountNameOfChild(idNoToSearch As Integer) As String
            Return Service.GetField(Of Int32, String)(idNoToSearch, "Account", "ParentIdNo", "AccountName")
        End Function

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                If EditMode And View.ParentIdNo = View.IdNo Then
                    Messaging.Show(True, "MsgMemberCannotBeAParentToItself")
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
            If CheckDependentRecords("CdJournalItem", "Cash Disbursement") Then
                Return True
            ElseIf CheckDependentRecords("PcJournalItem", "Petty Cash Disbursement") Then
                Return True
            ElseIf CheckDependentRecords("CashReceiptJournalItem", "Cash Receipt") Then
                Return True
            ElseIf CheckDependentRecords("ApJournalItem", "Accounts Payable") Then
                Return True
            ElseIf CheckDependentRecords("ArJournalItem", "Accounts Receivable") Then
                Return True
            ElseIf CheckDependentRecords("SalesJournalItem", "Sales Journal") Then
                Return True
            ElseIf CheckDependentRecords("GeneralJournalItem", "General Journal") Then
                Return True
            ElseIf CheckDependentRecords("ErJournalItem", "Employee Loans Journal") Then
                Return True
            ElseIf CheckDependentRecords("PayElementAccount", "Pay Element Account", "PayElementIdNo") Then
                Return True
            End If
            Return False
        End Function

        Private Function CheckDependentRecords(ByVal journalName As String, ByVal journalDescription As String, Optional returnFieldName As String = "JournalIdNo") As Boolean
            Dim transactionIdNo = Service.GetRecordFieldWithKeyG(Of Integer)(View.IdNo, journalName, "AccountIdNo", returnFieldName)
            If transactionIdNo > 0 Then
                Dim jdMessage = Messaging.TranslateCaption(journalDescription)
                Dim additionalMessage = Messaging.GetParametrizedMessage(True, "MsgSeeTransactionNumber", {"transactionName", jdMessage, "transactionNumber", transactionIdNo})
                Dim message = Messaging.GetParametrizedMessage(True, "MsgDependentRecordExists", {"additionalMessage", additionalMessage})
                Messaging.Show(message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return True
            End If
            Return False
        End Function

    End Class

End Namespace
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class AccountPresenter(Of TM As New)
        Inherits AccountsPresenterNew(Of IAccountView, TM)

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
            'Dim accountGroup As String
            'If idNo Is Nothing Then
            '    Return True
            'End If
            'accountGroup = Model.GetRecordFieldWithKeyG(Of String)(idNo, "Account", "IdNo", "AccountGroup")
            'If accountGroup = "S" Then
            '    Return True
            'End If
            'Return False
        End Function

        Public Function AccountHasChildren(ByVal idNo As Int32?) As Boolean
            If idNo Is Nothing Then
                Return True
            End If
            Return Service.CountRecordWithKey(idNo, "Account", "ParentIdNo") > 0
        End Function

        Public Function GetAccountNameOfChild(idNoToSearch As Integer) As String
            Return Service.GetField(Of Int32, String)(idNoToSearch, "Account", "ParentIdNo", "AccountName")
            'Return Model.GetRecordFieldWithKey(idNoToSearch, "Account", "ParentIdNo", "AccountName")
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

    End Class

End Namespace
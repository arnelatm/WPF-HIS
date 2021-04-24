Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Presenters

    Public Class AccountPresenter
        Inherits AccountsPresenter(Of IAccountView, AccountModel)

        Public ParentViewList As List(Of AccountModel)

        Public Sub New(view As IAccountView)
            MyBase.New(view)
            ModelOfPresenter = New ModelAccounts("Account")
            'TableName = "Account_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "AccountName"
            TreeViewSecondaryField = "AccountCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New AccountModel()
            DataModel = New AccountModel
            TreeViewList = New List(Of AccountModel)
            ParentViewList = New List(Of AccountModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Function EditableAccountGroup(ByVal idNo As Int32?, ByVal parentIdNo As Int32?) As Boolean
            If AccountHasChildren(idNo) Then
                Return False
            Else
                Dim parentAccount As AccountModel
                parentAccount = ModelOfPresenter.GetRecordByIdNo(Of AccountModel)(parentIdNo)
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
            Return Model.CountRecordWithKey(idNo, "Account", "ParentIdNo") > 0
        End Function

        Public Function GetAccountNameOfChild(idNoToSearch As Integer) As String
            Return Model.GetField(Of Int32, String)(idNoToSearch, "Account", "ParentIdNo", "AccountName")
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

        Public Sub ParentIdUpdated()
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
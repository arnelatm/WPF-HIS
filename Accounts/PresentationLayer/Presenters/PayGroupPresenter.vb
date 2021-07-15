Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class PayGroupPresenter(Of TM As New)
        Inherits PresenterNew(Of IPayGroupView, TM)

        Public Sub New(itemView As IPayGroupView)
            MyBase.New(itemView)
            Service = New ServiceAccounts("PayGroup")
            TableName = "PayGroup_View"
            TreeViewMainField = "PayGroupName"
            TreeViewSecondaryField = "PayGroupCode"
            SortOrderKey = "SortKey"
            ParentFieldName = "ParentIdNo"
        End Sub

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

    End Class

End Namespace
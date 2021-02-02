Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class PayGroupPresenter
        Inherits AccountsPresenter(Of IPayGroupView, PayGroupModel)

        Public Sub New(view As IPayGroupView)
            MyBase.New(view)
            TreeViewParentIdField = "ParentIdNo"
            InitializerWithTv("PayGroup")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
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
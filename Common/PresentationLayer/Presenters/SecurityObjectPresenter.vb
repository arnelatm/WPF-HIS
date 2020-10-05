Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.PresentationLayer.Views.Forms
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer

    Public Class SecurityObjectPresenter
        Inherits Presenter(Of ISecurityObjectView, SecurityObjectModel)

        Public Sub New(view As ISecurityObjectView)
            MyBase.New(view)
            ModelPresenter = New Model("SecurityObject")
            TableName = "SecurityObject_View"
            SortOrderKey = "SecurityObjectName"
            TreeViewMainField = "SecurityObjectName"
            TreeViewSecondaryField = "IdNo"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New SecurityObjectModel()
            DataModel = New SecurityObjectModel
            TreeViewList = New List(Of SecurityObjectModel)
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
End NameSpace
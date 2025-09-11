Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Presentation.Presenters

Namespace PresentationLayer.Presenters

    Public Class CodeGroupPresenter(Of TM As New)
        Inherits CommonPresenter(Of ICodeGroupView, TM)

        Public Sub New(itemView As ICodeGroupView)
            MyBase.New(itemView)
            Service = New AccountsService("CodeGroup")
            TableName = "CodeGroup"
            TreeViewMainField = "CodeGroupName"
            SortOrderKey = "CodeGroupName"
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int32)(View.IdNo, "ItemCode", "CodeGroupIdNo") Then
                returnValue = True
            End If
            Return returnValue
        End Function

    End Class

End Namespace
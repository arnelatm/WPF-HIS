Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Presenters

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
            'If CheckDependentRecords(Of Int32)(View.IdNo, "CodeGroupAccount", "CodeGroupIdNo") Then
            '    Return True
            'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Supplier", "CodeGroupIdNo") Then
            '    Return True
            'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Customer", "CodeGroupIdNo") Then
            '    Return True
            'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Employee", "CodeGroupIdNo") Then
            '    Return True
            'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "PensionProvider", "CodeGroupIdNo") Then
            '    Return True
            'End If
            Return False
        End Function

    End Class

End Namespace
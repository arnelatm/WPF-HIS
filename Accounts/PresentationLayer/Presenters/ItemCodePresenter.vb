Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class ItemCodePresenter(Of TM As New)
        Inherits CommonPresenter(Of IItemCodeView, TM)

        Public Sub New(itemView As IItemCodeView)
            MyBase.New(itemView)
            Service = New AccountsService("ItemCode")
            TableName = "ItemCode"
            TreeViewMainField = "ItemCodeName"
            SortOrderKey = "ItemCodeName"
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("CodeGroup", "CodeGroupIdNo")
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            'If CheckDependentRecords(Of Int32)(View.IdNo, "ItemCodeAccount", "ItemCodeIdNo") Then
            '    Return True
            'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Supplier", "ItemCodeIdNo") Then
            '    Return True
            'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Customer", "ItemCodeIdNo") Then
            '    Return True
            'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Employee", "ItemCodeIdNo") Then
            '    Return True
            'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "PensionProvider", "ItemCodeIdNo") Then
            '    Return True
            'End If
            Return False
        End Function

    End Class

End Namespace
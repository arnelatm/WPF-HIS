Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class BankPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IBankView, TM)

        Public Sub New(itemView As IBankView)
            MyBase.New(itemView)
            Service = New AccountsService("Bank")
            TableName = "Bank"
            TreeViewMainField = "BankName"
            'TreeViewSecondaryField = "BankCode"
            SortOrderKey = "BankName"
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int32)(View.IdNo, "BankAccount", "BankIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Supplier", "BankIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Customer", "BankIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Employee", "BankIdNo") Then
                Return True
            ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "PensionProvider", "BankIdNo") Then
                Return True
            End If
            Return False
        End Function

    End Class

End Namespace
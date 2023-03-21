Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class CategoryPresenter(Of TM As New)
        Inherits CommonPresenter(Of ICategoryView, TM)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Protected DtEarnInsertTable As New DataTable
        Protected DtEarnUpdateTable As New DataTable
        
        Public Sub New(view As ICategoryView)
            MyBase.New(view)
            If view IsNot Nothing Then
                Service = New AccountsService("Category")
                TableName = "Category"
                TreeViewMainField = "CategoryName"
                SortOrderKey = "CategoryName"
            End If
        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            data.Add({"Account", "PurchaseAccountIdNo", Nothing, Nothing})
            data.Add({"Account", "SaleAccountIdNo", Nothing, Nothing})
            data.Add({"Account", "VatPurchaseAccountIdNo", Nothing, Nothing})
            data.Add({"Account", "VatSaleAccountIdNo", Nothing, Nothing})
            CreateDataSourceThread(data)
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int32)(View.IdNo, "Product", "CategoryIdNo") Then
                Return True
            End If
            Return False
        End Function

    End Class

End Namespace
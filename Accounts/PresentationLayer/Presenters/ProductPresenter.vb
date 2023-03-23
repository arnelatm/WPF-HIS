Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class ProductPresenter(Of TM As New)
        Inherits CommonPresenter(Of IProductView, TM)

        Public Sub New(view As IProductView)
            MyBase.New(view)
            Service = New AccountsService("Product")
            TableName = "Product"
            WithTreeView = False
            SortOrderKey = "ProductName"
        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            'data.Add({"Product", "IdNo", Nothing, Nothing})
            data.Add({"Unit", "BaseUnitIdNo", Nothing, Nothing})
            CreateDataSourceThread(data)
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            'If CheckDependentRecords(Of Int32)(View.IdNo, "Product", "CategoryIdNo") Then
            '    Return True
            'End If
            Return False
        End Function

    End Class

End Namespace
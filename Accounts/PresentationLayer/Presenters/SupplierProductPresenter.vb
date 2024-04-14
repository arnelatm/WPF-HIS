Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class SupplierProductPresenter(Of TM As New)
        Inherits CommonPresenter(Of ISupplierProductView, TM)

        Public Sub New(view As ISupplierProductView)
            MyBase.New(view)
            Service = New AccountsService("SupplierProduct")
            TableName = "SupplierProduct"
            WithTreeView = False
            SortOrderKey = "SupplierIdNo"
        End Sub

        Protected Overrides Sub CreateDataSources()
            MakeControlDataSources({New Object() {"Supplier", "SupplierIdNo", Nothing, Nothing},
                                    New Object() {"Product", "ProductIdNo", Nothing, Nothing}})
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            'If CheckDependentRecords(Of Int32)(View.IdNo, "SupplierProduct", "CategoryIdNo") Then
            '    Return True
            'End If
            Return False
        End Function

    End Class

End Namespace
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class ProductPresenter(Of TM As New)
        Inherits CommonPresenter(Of IProductView, TM)

        Protected DtProductUnitInsertTable As New DataTable
        Protected DtProductUnitUpdateTable As New DataTable
        Private ReadOnly _productUnitService As New AccountsService("ProductUnit")

        Public Sub New(view As IProductView)
            MyBase.New(view)
            Service = New AccountsService("Product")
            TableName = "Product"
            WithTreeView = False
            SortOrderKey = "ProductName"
        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim data1 As New ArrayList
            data1.Add({"Unit", "BaseUnitIdNo", Nothing, Nothing})
            Dim data2 As New ArrayList
            data2.Clear()
            data2.Add({"Unit", "UnitsByCode", Nothing, Nothing})
            CreateLookupDataThread(data2)
            CreateDataTable(DtProductUnitInsertTable, {{"BaseQty", GetType(Int16)},
                                 {"ProductIdNo", GetType(Int32)},
                                 {"UnitIdNo", GetType(Int16)},
                                 {"UnitQty", GetType(Int16)}
                                 })

            CreateDataTable(DtProductUnitUpdateTable, {{"BaseQty", GetType(Int16)},
                                             {"IdNo", GetType(Int32)},
                                             {"ProductIdNo", GetType(Int32)},
                                             {"UnitIdNo", GetType(Int16)},
                                             {"UnitQty", GetType(Int16)}
                                            })

        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            'If CheckDependentRecords(Of Int32)(View.IdNo, "Product", "CategoryIdNo") Then
            '    Return True
            'End If
            Return False
        End Function

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                ViewToDataTables(View.ProductUnits, DtProductUnitInsertTable, DtProductUnitUpdateTable, AddressOf ProductUnitFillData, AddressOf ProductUnitFilter, "IdNo", "")
            End If
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Int16 = 0
            UpdateChildData(_productUnitService, DtProductUnitUpdateTable, DtProductUnitInsertTable, passedValue, "ProductIdNo")
        End Sub


        Public Function ProductUnitFilter(ByVal obj As ProductUnitView) As Boolean
            If obj.UnitIdNo <> 0 And obj.BaseQty > 0 And obj.UnitQty > 0 Then
                Return True
            End If
            Return False
        End Function

        Private Sub ProductUnitFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("BaseQty") = itemDataView.BaseQty
            workRow("ProductIdNo") = View.IdNo
            workRow("UnitIdNo") = itemDataView.UnitIdNo
            workRow("UnitQty") = itemDataView.UnitQty
        End Sub

    End Class

End Namespace
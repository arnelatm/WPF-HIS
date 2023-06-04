Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.MessagingLibrary.Messaging
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.DataLayer
Imports AATM.Accounts.DataLayer.AdoNet

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
            view.BranchCount = GetBranchCount()
            AddHandler view.LockBranchClicked, AddressOf LockBranchClicked
            AddHandler view.FilterRecords, AddressOf FilterRecords
        End Sub

        Private Function GetBranchCount()
            Return Service.CountRecordWithKey(Of Integer)("SecurityBranch", "SecurityGroupIdNo", GlobalVariables.SecurityGroupIdNo)
        End Function

        Private Function GetBranch()
            Return Service.GetTopOneFields("SecurityBranch", "BranchIdNo", "SecurityGroupIdNo = " & GlobalVariables.SecurityGroupIdNo.ToString(), "BranchIdNo", False)
        End Function

        Protected Overrides Sub CreateDataSources()
            Dim data1 As New ArrayList
            data1.Add({"Unit", "BaseUnitIdNo", Nothing, Nothing})
            data1.Add({"Category", "CategoryIdNo", Nothing, Nothing})
            data1.Add({"Branch", "BranchIdNo", Nothing, Nothing})
            Dim data2 As New ArrayList
            CreateDataSourceThread(data1)

            data2.Clear()
            data2.Add({"Unit", "UnitsByCode", Nothing, Nothing})
            CreateLookupDataThread(data2)
            CreateDataTable(DtProductUnitInsertTable, {{"BaseQty", GetType(Int16)},
                                 {"ProductIdNo", GetType(Int32)},
                                 {"Sequence", GetType(Int16)},
                                 {"UnitIdNo", GetType(Int16)},
                                 {"UnitQty", GetType(Int16)}
                                 })

            CreateDataTable(DtProductUnitUpdateTable, {{"BaseQty", GetType(Int16)},
                                             {"IdNo", GetType(Int32)},
                                             {"ProductIdNo", GetType(Int32)},
                                             {"Sequence", GetType(Int16)},
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
            workRow("Sequence") = itemDataView.Sequence
            workRow("UnitIdNo") = itemDataView.UnitIdNo
            workRow("UnitQty") = itemDataView.UnitQty
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            Dim textDescription = TranslateCaption("Product Units")
            If MyBase.IsBizDataValid() Then
                ' look for duplicate PayElementIdNo in bsEarning
                Dim duplicate = FirstFieldDuplicate(Of ProductUnitView, Int16)(View.ProductUnits, "UnitIdNo")
                If duplicate IsNot Nothing Then
                    ShowPmMessage(True, "MsgDuplicateLine", {"lineNumber", (duplicate + 1).ToString()})
                Else
                    retValue = True
                    For Each item As ProductUnitView In View.ProductUnits
                        If item.UnitIdNo = View.BaseUnitIdNo Then
                            Show(True, "MsgUnitEqualToBaseUnit")
                            retValue = False
                            Exit For
                        ElseIf item.BaseQty = item.UnitQty Then
                            Show(True, "MsgUnitQtyEqualToBUQty")
                            retValue = False
                            Exit For
                        End If
                    Next
                End If
                If Not CodeAndBranchUnique() Then
                    Dim errorMessage = Libraries.MessagingLibrary.Messaging.GetParametrizedMessage(True, "MsgDuplicateValuesNotAllowed", {"fieldValue", View.BranchIdNo.ToString() + "-" + View.ProductCode, "fieldDescription", "BranchIdNo - Product Code"})
                    Libraries.MessagingLibrary.Messaging.Show(errorMessage)
                    retValue = False
                End If
            End If
            Return retValue
        End Function

        Private Function CodeAndBranchUnique() As Boolean
            Dim idNo As Int32 = Service.GetRecordFieldWith2KeyG(Of String, Int16, Int32)(View.ProductCode, View.BranchIdNo, "Product", "ProductCode", "BranchIdNo", "IdNo")
            If idNo <> 0 AndAlso idNo <> View.IdNo Then
                Return False
            End If
            Return True
        End Function

        Private Function BarCodeAndBranchUnique() As Boolean
            Dim idNo As Int32 = Service.GetRecordFieldWith2KeyG(Of String, Int16, Int32)(View.Barcode, View.BranchIdNo, "Product", "BarCode", "BranchIdNo", "IdNo")
            If idNo <> 0 AndAlso idNo <> View.IdNo Then
                Return False
            End If
            Return True
        End Function

        Private Function GTinAndBranchUnique() As Boolean
            Dim idNo As Int32 = Service.GetRecordFieldWith2KeyG(Of String, Int16, Int32)(View.GTIN, View.BranchIdNo, "Product", "GTIN", "BranchIdNo", "IdNo")
            If idNo <> 0 AndAlso idNo <> View.IdNo Then
                Return False
            End If
            Return True
        End Function

        Public Sub FilterRecords()
            If View.BranchCount < 2 Then
                View.SavedBranch = GetBranch().BranchIdNo
                DataFilter = "BranchIdNo = " & View.SavedBranch.ToString()
            Else
                DataFilter = Nothing
            End If
            GoLastRecord()
        End Sub

        Public Sub LockBranchClicked()
            If View.LockBranch Then
                DataFilter = "BranchIdNo = " & View.BranchIdNo.ToString()
            Else
                DataFilter = ""
            End If
        End Sub

        Public Sub RecordAddedUpdated(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            'Dim passedValue As Integer = retVal
            If retVal >= 0 And IsEmpty(View.ProductCode) Then
                retVal = Service.GenerateCode(View.IdNo)
                View.ProductCode = Service.GetFieldWithIdNo(View.IdNo, "Product", "ProductCode")
            End If
        End Sub

    End Class

End Namespace
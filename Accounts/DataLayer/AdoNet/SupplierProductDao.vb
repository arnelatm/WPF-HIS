Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for SupplierProduct
    ' ** DAO Pattern

    Public Class SupplierProductDao
        Inherits CommonDao
        Implements IDao(Of SupplierProduct)

        Private Const FieldList = "IdNo," &
                          "ProductIdNo," &
                          "SupplierIdNo," &
                          "SupplierProductCode," &
                          "SupplierProductName," &
                          "SupplierProductNameAra"

        Private ReadOnly Db As New Db()


        Public Function UpdateRecord(ByRef SupplierProduct As SupplierProduct) As Integer Implements IDao(Of SupplierProduct).UpdateRecord
            Dim sql As String = " UPDATE [SupplierProduct] Set" &
                    " ProductIdNo = @ProductIdNo," &
                    " SupplierIdNo = @SupplierIdNo," &
                    " SupplierProductCode = @SupplierProductCode," &
                    " SupplierProductName = @SupplierProductName," &
                    " SupplierProductNameAra = @SupplierProductNameAra" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(SupplierProduct))
        End Function

        Public Function AddRecord(ByRef SupplierProduct As SupplierProduct) As Integer Implements IDao(Of SupplierProduct).AddRecord
            Dim sql As String =
                    " INSERT INTO [SupplierProduct] " &
                    " (ProductIdNo,SupplierIdNo,SupplierProductCode,SupplierProductName,SupplierProductNameAra) " &
                    " VALUES (@ProductIdNo,@SupplierIdNo,@SupplierProductCode,@SupplierProductName,@SupplierProductNameAra) "
            Return Db.Insert(sql, Take(SupplierProduct))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, SupplierProduct) =
                                    Function(reader) _
            New SupplierProduct() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .ProductIdNo = Extensions.AsInt(Of Int32)(reader("ProductIdNo")),
            .SupplierIdNo = Extensions.AsInt(Of Int32)(reader("SupplierIdNo")),
            .SupplierProductCode = Extensions.AsString(reader("SupplierProductCode")),
            .SupplierProductName = Extensions.AsString(reader("SupplierProductName")),
            .SupplierProductNameAra = Extensions.AsString(reader("SupplierProductNameAra"))
            }

        Private Function Take(SupplierProduct As SupplierProduct) As Object()
            Return New Object() {"@ProductIdNo", SupplierProduct.ProductIdNo,
                                  "@SupplierIdNo", SupplierProduct.SupplierIdNo,
                                  "@IdNo", SupplierProduct.IdNo,
                                  "@SupplierProductCode", SupplierProduct.SupplierProductCode,
                                  "@SupplierProductName", SupplierProduct.SupplierProductName,
                                  "@SupplierProductNameAra", SupplierProduct.SupplierProductNameAra
                                }
        End Function

        Public Function GetSupplierProductsBySearchString(searchString As String)
            Dim sql As String

            sql = "SELECT IdNo,SupplierProductCode,SupplierProductName,Barcode,GTIN from SupplierProduct where BranchIdNo = " + GlobalVariables.BranchIdNo.ToString() + " AND (SupplierProductName like '%" + searchString + "%' Or " +
                  "SupplierProductCode = @searchString or GTIN = @searchString or Barcode = @searchString ) order by SupplierProductName"
            Dim params As String() = {"@SearchString", searchString}
            Return Db.Read(sql, MakeSupplierProduct, params).ToList()
        End Function

        Private Shared ReadOnly MakeSupplierProduct As Func(Of IDataReader, SupplierProduct) =
                                    Function(reader) _
            New SupplierProduct() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .SupplierProductName = Extensions.AsString(reader("SupplierProductName")),
            .SupplierProductCode = Extensions.AsString(reader("SupplierProductCode"))
            }

        Public Function GetRecordByIdNo(idNo) As SupplierProduct Implements IDao(Of SupplierProduct).GetRecordByIdNo
            Dim sql As String = " SELECT " & FieldList &
                    " FROM SupplierProduct" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

    End Class


End Namespace

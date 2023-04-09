Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Product
    ' ** DAO Pattern

    Public Class ProductDao
        Inherits CommonDao
        Implements IDao(Of Product)

        Private Const FieldList = "Active," &
                          "Barcode," &
                          "BaseUnitIdNo," &
                          "CategoryIdNo," &
                          "GTIN," &
                          "IdNo," &
                          "ProductCode," &
                          "ProductName," &
                          "ProductNameAra"

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As Product Implements IDao(Of Product).GetRecordByIdNo
            Dim sql As String = " SELECT " & FieldList &
                    " FROM Product" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef Product As Product) As Integer Implements IDao(Of Product).UpdateRecord
            Dim sql As String = " UPDATE [Product] Set" &
                    " Active = @Active," &
                    " Barcode = @Barcode," &
                    " BaseUnitIdNo = @BaseUnitIdNo," &
                    " CategoryIdNo = @CategoryIdNo," &
                    " GTIN = @GTIN," &
                    " ProductCode = @ProductCode," &
                    " ProductName = @ProductName," &
                    " ProductNameAra = @ProductNameAra" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(Product))
        End Function

        Public Function AddRecord(ByRef Product As Product) As Integer Implements IDao(Of Product).AddRecord
            Dim sql As String =
                    " INSERT INTO [Product] " &
                    " (Active,Barcode,BaseUnitIdNo,CategoryIdNo,GTIN,ProductCode,ProductName,ProductNameAra) " &
                    " VALUES (@Active,@Barcode,@BaseUnitIdNo,@CategoryIdNo,@GTIN,@ProductCode,@ProductName,@ProductNameAra) "
            Return Db.Insert(sql, Take(Product))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Product) =
                                    Function(reader) _
            New Product() With {
            .Active = Extensions.AsBool(reader("Active")),
            .BarCode = Extensions.AsString(reader("Barcode")),
            .BaseUnitIdNo = Extensions.AsInt(Of Int16)(reader("BaseUnitIdNo")),
            .CategoryIdNo = Extensions.AsInt(Of Int16)(reader("CategoryIdNo")),
            .GTIN = Extensions.AsString(reader("GTIN")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .ProductCode = Extensions.AsString(reader("ProductCode")),
            .ProductName = Extensions.AsString(reader("ProductName")),
            .ProductNameAra = Extensions.AsString(reader("ProductNameAra"))
            }

        Private Function Take(Product As Product) As Object()
            Return New Object() {
                                    "@Active", Product.Active,
                                    "@Barcode", Product.BarCode,
                                    "@BaseUnitIdNo", Product.BaseUnitIdNo,
                                    "@CategoryIdNo", Product.CategoryIdNo,
                                    "@GTIN", Product.GTIN,
                                    "@IdNo", Product.IdNo,
                                    "@ProductCode", Product.ProductCode,
                                    "@ProductName", Product.ProductName,
                                    "@ProductNameAra", Product.ProductNameAra
                                }
        End Function

        Public Function GetProductsBySearchString(searchString As String)
            Dim sql As String

            sql = "SELECT IdNo,ProductCode,ProductName,BarCode,GTIN from Product where ProductName like '%" + searchString + "%' Or " +
                  "ProductCode = @searchString or GTIN = @searchString or BarCode = @searchString order by ProductName"
            Dim params As String() = {"@SearchString", searchString}
            Return Db.ExecuteReader(sql, params)
        End Function


        Private Shared ReadOnly MakeProduct As Func(Of IDataReader, Product) =
                                    Function(reader) _
            New Product() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .ProductName = Extensions.AsString(reader("ProductName")),
            .ProductCode = Extensions.AsString(reader("ProductCode")),
            .BarCode = Extensions.AsString(reader("Barcode")),
            .GTIN = Extensions.AsString(reader("GTIN"))            
            }
    End Class

End Namespace
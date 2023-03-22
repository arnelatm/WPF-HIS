Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Product
    ' ** DAO Pattern

    Public Class ProductDao
        Inherits CommonDao
        Implements iDao(Of Product)

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

        Public Function GetRecordByIdNo(idNo) As Product Implements iDao(Of Product).GetRecordByIdNo
            Dim sql As String = " SELECT " & FieldList &
                    " FROM Product" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef Product As Product) As Integer Implements iDao(Of Product).UpdateRecord
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

        Public Function AddRecord(ByRef Product As Product) As Integer Implements iDao(Of Product).AddRecord
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
            .Barcode = Extensions.AsString(reader("Barcode")),
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
                                    "@Barcode", Product.Barcode,
                                    "@BaseUnitIdNo", Product.BaseUnitIdNo,
                                    "@CategoryIdNo", Product.CategoryIdNo,
                                    "@GTIN", Product.GTIN,
                                    "@IdNo", Product.IdNo,
                                    "@ProductCode", Product.ProductCode,
                                    "@ProductName", Product.ProductName,
                                    "@ProductNameAra", Product.ProductNameAra
                                }
        End Function

    End Class

End Namespace
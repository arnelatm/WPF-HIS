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

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As Product Implements iDao(Of Product).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, ProductCode, ProductName, ProductNameAra, CategoryIdNo, GlAccountIdNo, VatAccountIdNo," &
                    "   Unit1, Unit2, Unit3, Unit1Ara, Unit2Ara, Unit3Ara, StdPrice1, StdPrice2, StdPrice3, Active" &
                    "   FROM [Product]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef Product As Product) As Integer Implements iDao(Of Product).UpdateRecord
            Dim sql As String =
                    " UPDATE [Product]" &
                    "    SET ProductCode = @ProductCode," &
                    "        ProductName = @ProductName," &
                    "        ProductNameAra = @ProductNameAra," &
                    "        CategoryIdNo = @CategoryIdNo," &
                    "        GlAccountIdNo = @GlAccountIdNo," &
                    "        VatAccountIdNo = @VatAccountIdNo," &
                    "        Unit1 = @Unit1," &
                    "        Unit2 = @Unit2," &
                    "        Unit3 = @Unit3," &
                    "        Unit1Ara = @Unit1Ara," &
                    "        Unit2Ara = @Unit2Ara," &
                    "        Unit3Ara = @Unit3Ara," &
                    "        StdPrice1 = @StdPrice1," &
                    "        StdPrice2 = @StdPrice2," &
                    "        StdPrice3 = @StdPrice3," &
                    "        Active = @Active" &
                    "  WHERE IdNo = @IdNo"

            Return Db.Update(sql, Take(Product))
        End Function

        Public Function AddRecord(ByRef Product As Product) As Integer Implements iDao(Of Product).AddRecord
            Dim sql As String =
                    " INSERT INTO [Product] " &
                    " (ProductCode,ProductName,ProductNameAra,CategoryIdNo, GlAccountIdNo, VatAccountIdNo," &
                    "   Unit1, Unit2, Unit3, Unit1Ara, Unit2Ara, Unit3Ara, StdPrice1, StdPrice2, StdPrice3, Active) " &
                    " VALUES (@ProductCode,@ProductName,@ProductNameAra,@CategoryIdNo, @GlAccountIdNo, @VatAccountIdNo," &
                    "   @Unit1, @Unit2, @Unit3, @Unit1Ara, @Unit2Ara, @Unit3Ara, @StdPrice1, @StdPrice2, @StdPrice3, @Active) "
            Return Db.Insert(sql, Take(Product))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Product) =
                                    Function(reader) _
            New Product() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .ProductCode = Extensions.AsString(reader("ProductCode")),
            .ProductName = Extensions.AsString(reader("ProductName")),
            .ProductNameAra = Extensions.AsString(reader("ProductNameAra")),
            .CategoryIdNo = Extensions.AsInt(Of Int16)(reader("CategoryIdNo")),
            .GlAccountIdNo = Extensions.AsInt(Of Int16)(reader("GlAccountIdNo")),
            .VatAccountIdNo = Extensions.AsInt(Of Int16)(reader("VatAccountIdNo")),
            .Unit1 = Extensions.AsString(reader("Unit1")),
            .Unit2 = Extensions.AsString(reader("Unit2")),
            .Unit3 = Extensions.AsString(reader("Unit3")),
            .Unit1Ara = Extensions.AsString(reader("Unit1Ara")),
            .Unit2Ara = Extensions.AsString(reader("Unit2Ara")),
            .Unit3Ara = Extensions.AsString(reader("Unit3Ara")),
            .StdPrice1 = Extensions.AsDecimal(reader("StdPrice1")),
            .StdPrice2 = Extensions.AsDecimal(reader("StdPrice2")),
            .StdPrice3 = Extensions.AsDecimal(reader("StdPrice3")),
            .Active = Extensions.AsBool(reader("Active"))
            }

        Private Function Take(Product As Product) As Object()
            Return New Object() {
                                    "@IdNo", Product.IdNo,
                                    "@ProductCode", Product.ProductCode,
                                    "@ProductName", Product.ProductName,
                                    "@ProductNameAra", Product.ProductNameAra,
                                    "@CategoryIdNo", Product.CategoryIdNo,
                                    "@GlAccountIdNo", Product.GlAccountIdNo,
                                    "@VatAccountIdNo", Product.VatAccountIdNo,
                                    "@Unit1", Product.Unit1,
                                    "@Unit2", Product.Unit2,
                                    "@Unit3", Product.Unit3,
                                    "@Unit1Ara", Product.Unit1Ara,
                                    "@Unit2Ara", Product.Unit2Ara,
                                    "@Unit3Ara", Product.Unit3Ara,
                                    "@StdPrice1", Product.StdPrice1,
                                    "@StdPrice2", Product.StdPrice2,
                                    "@StdPrice3", Product.StdPrice3,
                                    "@Active", Product.Active
                                }
        End Function

    End Class

End Namespace
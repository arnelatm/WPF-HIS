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
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            If data IsNot Nothing Then
                Dim productUnitDao = New ProductUnitDao
                Dim pu As List(Of ProductUnit) = productUnitDao.GetRecordsWithGroupIdNo(data.IdNo)
                data.ProductUnits = pu
            End If
            Return data
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
            .BaseUnitIdNo = Extensions.AsInt(Of Int32)(reader("BaseUnitIdNo")),
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

    Public Class ProductUnitDao
        Inherits AccountsDao
        Implements IDaoChild(Of ProductUnit)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of ProductUnit) Implements IDaoChild(Of ProductUnit).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "BaseQty," &
                    "IdNo," &
                    "Multiplier," &
                    "UnitIdNo " &
                    "FROM ProductUnit " &
                    "WHERE ProductIdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of ProductUnit).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateProductUnitTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of ProductUnit).InsertTvp
            Return Db.InsertTvp("InsertProductUnitTVP", tvpTable)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, ProductUnit) =
                                    Function(reader) _
            New ProductUnit() With {
            .BaseQty = Extensions.AsInt(Of Int16)(reader("BaseQty")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Multiplier = Extensions.AsInt(Of Int16)(reader("Multiplier")),
            .UnitIdNo = Extensions.AsInt(Of Int32)(reader("UnitIdNo"))
           }

    End Class

End Namespace
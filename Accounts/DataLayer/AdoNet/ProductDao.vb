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
                          "BranchIdNo," &
                          "CategoryIdNo," &
                          "DateCreated," &
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
                Dim pu As List(Of ProductUnit) = productUnitDao.GetRecordsWithGroupIdNo(data.IdNo, "")
                data.ProductUnits = pu
            End If
            Return data
        End Function

        Public Function UpdateRecord(ByRef Product As Product) As Integer Implements IDao(Of Product).UpdateRecord
            Dim sql As String = " UPDATE [Product] Set" &
                    " Active = @Active," &
                    " Barcode = @Barcode," &
                    " BaseUnitIdNo = @BaseUnitIdNo," &
                    " BranchIdNo = @BranchIdNo," &
                    " CategoryIdNo = @CategoryIdNo," &
                    " DateCreated = @DateCreated," &
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
                    " (Active,Barcode,BaseUnitIdNo,BranchIdNo,CategoryIdNo,DateCreated,GTIN,ProductCode,ProductName,ProductNameAra) " &
                    " VALUES (@Active,@Barcode,@BaseUnitIdNo,@BranchIdNo,@CategoryIdNo,@DateCreated,@GTIN,@ProductCode,@ProductName,@ProductNameAra) "
            Return Db.Insert(sql, Take(Product))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Product) =
                                    Function(reader) _
            New Product() With {
            .Active = Extensions.AsBool(reader("Active")),
            .Barcode = Extensions.AsString(reader("Barcode")),
            .BaseUnitIdNo = Extensions.AsInt(Of Int16)(reader("BaseUnitIdNo")),
            .BranchIdNo = Extensions.AsInt(Of Int16)(reader("BranchIdNo")),
            .CategoryIdNo = Extensions.AsInt(Of Int16)(reader("CategoryIdNo")),
            .DateCreated = Extensions.AsNullable(Of DateTime)(reader("DateCreated")),
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
                                    "@BranchIdNo", Product.BranchIdNo,
                                    "@CategoryIdNo", Product.CategoryIdNo,
                                    "@DateCreated", Product.DateCreated,
                                    "@GTIN", Product.GTIN,
                                    "@IdNo", Product.IdNo,
                                    "@ProductCode", Product.ProductCode,
                                    "@ProductName", Product.ProductName,
                                    "@ProductNameAra", Product.ProductNameAra
                                }
        End Function

        Public Function GetProductsBySearchString(searchString As String)
            Dim sql As String

            sql = "SELECT IdNo,ProductCode,ProductName,Barcode,GTIN from Product where ProductName like '%" + searchString + "%' Or " +
                  "ProductCode = @searchString or GTIN = @searchString or Barcode = @searchString order by ProductName"
            Dim params As String() = {"@SearchString", searchString}
            Return Db.ExecuteReader(sql, params)
        End Function


        Private Shared ReadOnly MakeProduct As Func(Of IDataReader, Product) =
                                    Function(reader) _
            New Product() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .ProductName = Extensions.AsString(reader("ProductName")),
            .ProductCode = Extensions.AsString(reader("ProductCode")),
            .Barcode = Extensions.AsString(reader("Barcode")),
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
                    "ProductIdNo," &
                    "Sequence," &
                    "UnitIdNo," &
                    "UnitQty " &
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
            .ProductIdNo = Extensions.AsInt(Of Int32)(reader("ProductIdNo")),
            .Sequence = Extensions.AsInt(Of Int16)(reader("Sequence")),
            .UnitIdNo = Extensions.AsInt(Of Int16)(reader("UnitIdNo")),
            .UnitQty = Extensions.AsInt(Of Int16)(reader("UnitQty"))
           }

    End Class

End Namespace

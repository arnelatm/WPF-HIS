Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Category
    ' ** DAO Pattern

    Public Class CategoryDao
        Inherits CommonDao
        Implements IDao(Of Category)

        Private Const FieldList = "IdNo," &
                                  "BranchIdNo," &
                                  "CategoryCode," &
                                  "CategoryName," &
                                  "CategoryNameAra," &
                                  "NeedsExpiryDate," &
                                  "PurchaseAccountIdNo," &
                                  "SaleAccountIdNo," &
                                  "VatPurchaseAccountIdNo," &
                                  "VatSaleAccountIdNo," &
                                  "VatPercentage," &
                                  "Notes"

        Private ReadOnly Db As New Db()

        Public Sub New()

        End Sub

        Public Function GetRecordByIdNo(idNo) As Category Implements IDao(Of Category).GetRecordByIdNo
            Dim sql As String = " SELECT " & FieldList &
                    " FROM [Category]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef Category As Category) As Integer Implements IDao(Of Category).UpdateRecord
            Dim sql As String =
                    " UPDATE [Category] Set" &
                    " BranchIdNo = @BranchIdNo," &
                    " CategoryCode = @CategoryCode," &
                    " CategoryName = @CategoryName," &
                    " CategoryNameAra = @CategoryNameAra," &
                    " NeedsExpiryDate = @NeedsExpiryDate," &
                    " Notes = @Notes," &
                    " PurchaseAccountIdNo = @PurchaseAccountIdNo," &
                    " SaleAccountIdNo = @SaleAccountIdNo," &
                    " VatPurchaseAccountIdNo = @VatPurchaseAccountIdNo," &
                    " VatSaleAccountIdNo = @VatSaleAccountIdNo," &
                    " VatPercentage = @VatPercentage" &
                    " WHERE IdNo = @IdNo"

            Return Db.Update(sql, Take(Category))
        End Function

        Public Function AddRecord(ByRef Category As Category) As Integer Implements IDao(Of Category).AddRecord
            Dim sql As String =
                    " INSERT INTO [Category] " &
                    " (BranchIdNo,CategoryCode,CategoryName,CategoryNameAra,NeedsExpiryDate,PurchaseAccountIdNo,SaleAccountIdNo,VatPurchaseAccountIdNo,VatSaleAccountIdNo,VatPercentage,Notes) " &
                    " VALUES (@BranchIdNo,@CategoryCode,@CategoryName,@CategoryNameAra,@NeedsExpiryDate,@PurchaseAccountIdNo,@SaleAccountIdNo,@VatPurchaseAccountIdNo,@VatSaleAccountIdNo,@VatPercentage,@Notes) "
            Return Db.Insert(sql, Take(Category))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Category) =
                                    Function(reader) _
            New Category() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .BranchIdNo = Extensions.AsInt(Of Int16)(reader("BranchIdNo")),
            .CategoryCode = Extensions.AsString(reader("CategoryCode")),
            .CategoryName = Extensions.AsString(reader("CategoryName")),
            .CategoryNameAra = Extensions.AsString(reader("CategoryNameAra")),
            .NeedsExpiryDate = Extensions.AsBool(reader("NeedsExpiryDate")),
            .PurchaseAccountIdNo = Extensions.AsInt(Of Int16)(reader("PurchaseAccountIdNo")),
            .SaleAccountIdNo = Extensions.AsInt(Of Int16)(reader("SaleAccountIdNo")),
            .VatPurchaseAccountIdNo = Extensions.AsInt(Of Int16)(reader("VatPurchaseAccountIdNo")),
            .VatSaleAccountIdNo = Extensions.AsInt(Of Int16)(reader("VatSaleAccountIdNo")),
            .VatPercentage = Extensions.AsDecimal(reader("VatPercentage")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(Category As Category) As Object()
            Return New Object() {
                                    "@IdNo", Category.IdNo,
                                    "@BranchIdNo", Category.BranchIdNo,
                                    "@CategoryCode", Category.CategoryCode,
                                    "@CategoryName", Category.CategoryName,
                                    "@CategoryNameAra", Category.CategoryNameAra,
                                    "@NeedsExpiryDate", Category.NeedsExpiryDate,
                                    "@PurchaseAccountIdNo", Category.PurchaseAccountIdNo,
                                    "@SaleAccountIdNo", Category.SaleAccountIdNo,
                                    "@VatPurchaseAccountIdNo", Category.VatPurchaseAccountIdNo,
                                    "@VatSaleAccountIdNo", Category.VatSaleAccountIdNo,
                                    "@VatPercentage", Category.VatPercentage,
                                    "@Notes", Category.Notes
                                }
        End Function

    End Class

End Namespace
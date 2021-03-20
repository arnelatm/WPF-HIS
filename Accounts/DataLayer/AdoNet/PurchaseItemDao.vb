Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PurchaseItem
    ' ** DAO Pattern

    Public Class PurchaseItemDao
        Inherits CommonDao
        Implements IDaoAll(Of PurchaseItem)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As PurchaseItem Implements IDaoAll(Of PurchaseItem).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, PurchaseItemCode, PurchaseItemName, PurchaseItemNameAra, ProductCategoryIdNo, GlAccountIdNo, VatAccountIdNo," &
                    "   Unit1, Unit2, Unit3, Unit1Ara, Unit2Ara, Unit3Ara, StdPrice1, StdPrice2, StdPrice3, Active" &
                    "   FROM [PurchaseItem]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of PurchaseItem) _
            Implements IDaoAll(Of PurchaseItem).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "PurchaseItemName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, PurchaseItemCode, PurchaseItemName, PurchaseItemNameAra" &
                    "   FROM [PurchaseItem] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef purchaseItem As PurchaseItem) As Integer Implements IDaoAll(Of PurchaseItem).UpdateRecord
            Dim sql As String =
                    " UPDATE [PurchaseItem]" &
                    "    SET PurchaseItemCode = @PurchaseItemCode," &
                    "        PurchaseItemName = @PurchaseItemName," &
                    "        PurchaseItemNameAra = @PurchaseItemNameAra," &
                    "        ProductCategoryIdNo = @ProductCategoryIdNo," &
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

            Return Db.Update(sql, Take(purchaseItem))
        End Function

        Public Function AddRecord(ByRef purchaseItem As PurchaseItem) As Integer Implements IDaoAll(Of PurchaseItem).AddRecord
            Dim sql As String =
                    " INSERT INTO [PurchaseItem] " &
                    " (PurchaseItemCode,PurchaseItemName,PurchaseItemNameAra,ProductCategoryIdNo, GlAccountIdNo, VatAccountIdNo," &
                    "   Unit1, Unit2, Unit3, Unit1Ara, Unit2Ara, Unit3Ara, StdPrice1, StdPrice2, StdPrice3, Active) " &
                    " VALUES (@PurchaseItemCode,@PurchaseItemName,@PurchaseItemNameAra,@ProductCategoryIdNo, @GlAccountIdNo, @VatAccountIdNo," &
                    "   @Unit1, @Unit2, @Unit3, @Unit1Ara, @Unit2Ara, @Unit3Ara, @StdPrice1, @StdPrice2, @StdPrice3, @Active) "
            Return Db.Insert(sql, Take(purchaseItem))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PurchaseItem) =
                                    Function(reader) _
            New PurchaseItem() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .PurchaseItemCode = Extensions.AsString(reader("PurchaseItemCode")),
            .PurchaseItemName = Extensions.AsString(reader("PurchaseItemName")),
            .PurchaseItemNameAra = Extensions.AsString(reader("PurchaseItemNameAra")),
            .ProductCategoryIdNo = Extensions.AsInt(Of Int16)(reader("ProductCategoryIdNo")),
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

        Private Function Take(purchaseItem As PurchaseItem) As Object()
            Return New Object() {
                                    "@IdNo", purchaseItem.IdNo,
                                    "@PurchaseItemCode", purchaseItem.PurchaseItemCode,
                                    "@PurchaseItemName", purchaseItem.PurchaseItemName,
                                    "@PurchaseItemNameAra", purchaseItem.PurchaseItemNameAra,
                                    "@ProductCategoryIdNo", purchaseItem.ProductCategoryIdNo,
                                    "@GlAccountIdNo", purchaseItem.GlAccountIdNo,
                                    "@VatAccountIdNo", purchaseItem.VatAccountIdNo,
                                    "@Unit1", purchaseItem.Unit1,
                                    "@Unit2", purchaseItem.Unit2,
                                    "@Unit3", purchaseItem.Unit3,
                                    "@Unit1Ara", purchaseItem.Unit1Ara,
                                    "@Unit2Ara", purchaseItem.Unit2Ara,
                                    "@Unit3Ara", purchaseItem.Unit3Ara,
                                    "@StdPrice1", purchaseItem.StdPrice1,
                                    "@StdPrice2", purchaseItem.StdPrice2,
                                    "@StdPrice3", purchaseItem.StdPrice3,
                                    "@Active", purchaseItem.Active
                                }
        End Function

    End Class

End Namespace
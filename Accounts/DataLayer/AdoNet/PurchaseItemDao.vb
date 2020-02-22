Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for PurchaseItem
    ' ** DAO Pattern

    Public Class PurchaseItemDao
        Inherits CommonDaoOld
        Implements IPurchaseItemDao

        Private Shared ReadOnly Db As New Db()

        Public Sub New()
            DbCommon = Db
        End Sub

        Public Function GetRecordById(idNo As Integer) As PurchaseItem Implements IPurchaseItemDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, PurchaseItemCode, PurchaseItemName, PurchaseItemNameAra, CategoryIdNo, GlAccountIdNo, VatAccountIdNo," &
                    "   Unit1, Unit2, Unit3, Unit1Ara, Unit2Ara, Unit3Ara, StdPrice1, StdPrice2, StdPrice3, Active" &
                    "   FROM [PurchaseItem]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "PurchaseItemName ASC") As List(Of PurchaseItem) _
            Implements IPurchaseItemDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, PurchaseItemCode, PurchaseItemName, PurchaseItemNameAra" &
                    "   FROM [PurchaseItem] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef purchaseItem As PurchaseItem) As Integer Implements IPurchaseItemDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [PurchaseItem]" &
                    "    SET PurchaseItemCode = @PurchaseItemCode," &
                    "        PurchaseItemName = @PurchaseItemName," &
                    "        PurchaseItemNameAra = @PurchaseItemNameAra," &
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
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(purchaseItem))
        End Function

        Public Function AddRecord(ByRef purchaseItem As PurchaseItem) As Integer Implements IPurchaseItemDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [PurchaseItem] " &
                    " (PurchaseItemCode,PurchaseItemName,PurchaseItemNameAra,CategoryIdNo, GlAccountIdNo, VatAccountIdNo," &
                    "   Unit1, Unit2, Unit3, Unit1Ara, Unit2Ara, Unit3Ara, StdPrice1, StdPrice2, StdPrice3, Active) " &
                    " VALUES (@PurchaseItemCode,@PurchaseItemName,@PurchaseItemNameAra,@CategoryIdNo, @GlAccountIdNo, @VatAccountIdNo," &
                    "   @Unit1, @Unit2, @Unit3, @Unit1Ara, @Unit2Ara, @Unit3Ara, @StdPrice1, @StdPrice2, @StdPrice3, @Active) "
            Return Db.Insert(sql, Take(purchaseItem))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PurchaseItem) =
                                    Function(reader) _
            New PurchaseItem() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .PurchaseItemCode = Extensions.AsString(reader("PurchaseItemCode")),
            .PurchaseItemName = Extensions.AsString(reader("PurchaseItemName")),
            .PurchaseItemNameAra = Extensions.AsString(reader("PurchaseItemNameAra")),
            .CategoryIdNo = Extensions.AsInt(Of Int32)(reader("CategoryIdNo")),
            .GlAccountIdNo = Extensions.AsInt(Of Int32)(reader("GlAccountIdNo")),
            .VatAccountIdNo = Extensions.AsInt(Of Int32)(reader("VatAccountIdNo")),
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
                                    "@IDNo", purchaseItem.IdNo,
                                    "@PurchaseItemCode", purchaseItem.PurchaseItemCode,
                                    "@PurchaseItemName", purchaseItem.PurchaseItemName,
                                    "@PurchaseItemNameAra", purchaseItem.PurchaseItemNameAra,
                                    "@CategoryIdNo", purchaseItem.CategoryIdNo,
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
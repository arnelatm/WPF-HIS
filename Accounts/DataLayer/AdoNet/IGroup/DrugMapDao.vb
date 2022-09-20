Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for DrugMap
    ' ** DAO Pattern

    Public Class DrugMapDao
        Inherits CommonDao
        Implements IDao(Of DrugMap)

        Private _db As New Db("IGROUPCLINIC")

        Private FieldList As String = "Batch," &
                                      "BranchId," &
                                      "CashPrice," &
                                      "Expiry," &
                                      "GTIN," &
                                      "IdNo," &
                                      "Item_Code," &
                                      "ItemNameEnglish," &
                                      "PurchaseNo," &
                                      "Quantity," &
                                      "SerialNo"

        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Function GetRecordByIdNo(idNo) As DrugMap Implements IDao(Of DrugMap).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " & FieldList &
                    " FROM DrugMap_View" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim value As DrugMap = _db.Read(sql, Make, params).FirstOrDefault()
            Return value
        End Function

        Public Function UpdateRecord(ByRef DrugMap As DrugMap) As Integer Implements IDao(Of DrugMap).UpdateRecord
            Dim sql As String = " UPDATE StockPositionCurrent SET " &
                    " Batch = @Batch, " &
                    " Expiry = @Expiry," &
                    " SerialNo = @SerialNo"
            Dim retVal As Integer
            retVal = _db.Update(sql, Take(DrugMap))
            If retVal > 0 And Not GlobalFunctions.IsEmpty(DrugMap.GTIN) Then
                Dim sql1 As String = "UPDATE ItemDetails SET " &
                    " GTIN = @GTIN" &
                    " WHERE Item_Code = @Item_Code and BranchId = @BranchId"
                _db.Update(sql1, TakeItem(DrugMap))
            End If
            Return retVal
        End Function

        Public Function AddRecord(ByRef DrugMap As DrugMap) As Integer Implements IDao(Of DrugMap).AddRecord
            MessageBox.Show("Adding Is Not implemented... ", "Help")
            Return 0
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DrugMap) =
                            Function(reader) _
            New DrugMap() With {
            .Batch = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Batch")),
            .BranchID = AATM.DataLayer.AdoNet.Extensions.AsString(reader("BranchID")),
            .CashPrice = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("CashPrice")),
            .Expiry = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("Expiry")),
            .GTIN = AATM.DataLayer.AdoNet.Extensions.AsString(reader("GTIN")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Item_Code = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Item_Code")),
            .ItemNameEnglish = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemNameEnglish")),
            .PurchaseNo = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("PurchaseNo")),
            .Quantity = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Quantity")),
            .SerialNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("SerialNo"))
            }

        Private Function Take(DrugMap As DrugMap) As Object()
            Return New Object() {
                            "Batch", DrugMap.Batch,
                            "Expiry", DrugMap.Expiry,
                            "SerialNo", DrugMap.SerialNo
                            }
        End Function

        Private Function TakeItem(DrugMap As DrugMap) As Object()
            Return New Object() {
                                 "Item_Code", DrugMap.Item_Code,
                                 "GTIN", DrugMap.GTIN,
                                 "BranchId", DrugMap.BranchID
                                 }
        End Function

        Public Overrides Function GetActualFieldName(fieldName As String)
            Dim actualFieldName As String
            If fieldName = "DrugMapCode" Then
                actualFieldName = "Item_Code"
            ElseIf fieldName = "DrugMapName" Then
                actualFieldName = "ItemNameEnglish"
            Else
                actualFieldName = fieldName
            End If
            Return actualFieldName
        End Function

    End Class

End Namespace
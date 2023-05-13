Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for DrugSale
    ' ** DAO Pattern

    Public Class DrugSaleDao
        Inherits CommonDao
        Implements IDao(Of DrugSale)

        'Private ReadOnly _db As New Db("IGROUPCLINIC")
        Private ReadOnly _db As New Db()

        Private ReadOnly _fieldList As String = "BatchNo," &
                                      "Expiry," &
                                      "GTin," &
                                      "IdNo," &
                                      "ProductCode," &
                                      "ProductName," &
                                      "SaleDate," &
                                      "SerializationNo"

        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Function GetRecordByIdNo(idNo) As DrugSale Implements IDao(Of DrugSale).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " & _fieldList &
                    " FROM DrugSale_View" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim value As DrugSale = _db.Read(sql, Make, params).FirstOrDefault()
            Return value
        End Function

        Public Function UpdateRecord(ByRef drugSale As DrugSale) As Integer Implements IDao(Of DrugSale).UpdateRecord
            Dim sql As String = " UPDATE DrugSale SET " &
                    " BatchNo = @BatchNo, " &
                    " Expiry = @Expiry," &
                    " SerializationNo = @SerializationNo," &
                    " GTin = @GTin " &
                    " where IdNo = @IdNo"
            Dim retVal As Integer
            retVal = _db.Update(sql, Take(drugSale))
            'If retVal > 0 And Not GlobalFunctions.IsEmpty(drugSale.GTin) Then
            '    Dim sql1 As String = "UPDATE ItemDetails SET " &
            '        " GTin = @GTin" &
            '        " WHERE ProductCode = @ProductCode and BranchId = @BranchId"
            '    _db.Update(sql1, Take(drugSale))
            'End If
            Return retVal
        End Function

        Public Function AddRecord(ByRef drugSale As DrugSale) As Integer Implements IDao(Of DrugSale).AddRecord
            Dim sql As String =
                    " INSERT INTO [DrugSale] " &
                    " (BatchNo,Expiry,GTin,SaleDate,SerializationNo) " &
                    " VALUES (@BatchNo,@Expiry,@GTin,@SaleDate,@SerializationNo) "
            Return _db.Insert(sql, Take(drugSale))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DrugSale) =
                            Function(reader) _
            New DrugSale() With {
            .BatchNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("BatchNo")),
            .Expiry = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Date)(reader("Expiry")),
            .GTin = AATM.DataLayer.AdoNet.Extensions.AsString(reader("GTin")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .ProductCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductCode")),
            .ProductName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductName")),
            .SaleDate = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Date)(reader("SaleDate")),
            .SerializationNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("SerializationNo"))
            }

        Private Function Take(drugSale As DrugSale) As Object()
            Return New Object() {
                            "BatchNo", drugSale.BatchNo,
                            "Expiry", drugSale.Expiry,
                            "GTin", drugSale.GTin,
                            "IdNo", drugSale.IdNo,
                            "SaleDate", drugSale.SaleDate,
                            "SerializationNo", drugSale.SerializationNo
                            }
        End Function

        'Public Overrides Function GetActualFieldName(fieldName As String)
        '    Dim actualFieldName As String
        '    If fieldName = "DrugSaleCode" Then
        '        actualFieldName = "ProductCode"
        '    ElseIf fieldName = "DrugSaleName" Then
        '        actualFieldName = "ProductName"
        '    Else
        '        actualFieldName = fieldName
        '    End If
        '    Return actualFieldName
        'End Function

    End Class

End Namespace
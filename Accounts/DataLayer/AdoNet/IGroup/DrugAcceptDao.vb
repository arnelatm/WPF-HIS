Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for DrugAccept
    ' ** DAO Pattern

    Public Class DrugAcceptDao
        Inherits CommonDao
        Implements IDao(Of DrugAccept)

        Private ReadOnly _db As New Db("IGROUPCLINIC")
        'Private ReadOnly _db As New Db()

        Private ReadOnly _fieldList As String = "BatchNo," &
                                      "Expiry," &
                                      "GTin," &
                                      "IdNo," &
                                      "ProductCode," &
                                      "ProductName," &
                                      "AcceptDate," &
                                      "SerializationNo"

        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Function GetRecordByIdNo(idNo) As DrugAccept Implements IDao(Of DrugAccept).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " & _fieldList &
                    " FROM DrugAccept_View" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim value As DrugAccept = _db.Read(sql, Make, params).FirstOrDefault()
            Return value
        End Function

        Public Function UpdateRecord(ByRef DrugAccept As DrugAccept) As Integer Implements IDao(Of DrugAccept).UpdateRecord
            Dim sql As String = " UPDATE DrugAccept SET " &
                    " BatchNo = @BatchNo, " &
                    " Expiry = @Expiry," &
                    " SerializationNo = @SerializationNo," &
                    " Gtin = @GTin " &
                    " where IdNo = @IdNo"
            Dim retVal As Integer
            retVal = _db.Update(sql, Take(DrugAccept))
            'If retVal > 0 And Not GlobalFunctions.IsEmpty(DrugAccept.GTin) Then
            '    Dim sql1 As String = "UPDATE ItemDetails SET " &
            '        " GTin = @GTin" &
            '        " WHERE ProductCode = @ProductCode and BranchId = @BranchId"
            '    _db.Update(sql1, Take(DrugAccept))
            'End If
            Return retVal
        End Function

        Public Function AddRecord(ByRef DrugAccept As DrugAccept) As Integer Implements IDao(Of DrugAccept).AddRecord
            Dim sql As String =
                    " INSERT INTO [DrugAccept] " &
                    " (BatchNo,Expiry,GTin,AcceptDate,SerializationNo) " &
                    " VALUES (@BatchNo,@Expiry,@GTin,@AcceptDate,@SerializationNo) "
            Return _db.Insert(sql, Take(DrugAccept))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DrugAccept) =
                            Function(reader) _
            New DrugAccept() With {
            .BatchNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("BatchNo")),
            .Expiry = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Date?)(reader("Expiry")),
            .GTin = AATM.DataLayer.AdoNet.Extensions.AsString(reader("GTin")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .ProductCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductCode")),
            .ProductName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductName")),
            .AcceptDate = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Date?)(reader("AcceptDate")),
            .SerializationNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("SerializationNo"))
            }

        Private Function Take(DrugAccept As DrugAccept) As Object()
            Return New Object() {
                            "BatchNo", DrugAccept.BatchNo,
                            "Expiry", DrugAccept.Expiry,
                            "GTin", DrugAccept.GTin,
                            "IdNo", DrugAccept.IdNo,
                            "AcceptDate", DrugAccept.AcceptDate,
                            "SerializationNo", DrugAccept.SerializationNo
                            }
        End Function

        'Public Overrides Function GetActualFieldName(fieldName As String)
        '    Dim actualFieldName As String
        '    If fieldName = "DrugAcceptCode" Then
        '        actualFieldName = "ProductCode"
        '    ElseIf fieldName = "DrugAcceptName" Then
        '        actualFieldName = "ProductName"
        '    Else
        '        actualFieldName = fieldName
        '    End If
        '    Return actualFieldName
        'End Function

    End Class

End Namespace
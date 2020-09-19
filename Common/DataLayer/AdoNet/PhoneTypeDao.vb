Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PhoneType
    ' ** DAO Pattern

    Public Class PhoneTypeDao
        Inherits CommonDao
        Implements IDaoAll(Of PhoneType)

        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo) As PhoneType Implements IDaoAll(Of PhoneType).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, PhoneTypeCode, PhoneTypeName, PhoneTypeNameAra, Notes" &
                    "   FROM [PhoneType]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of PhoneType) _
            Implements IDaoAll(Of PhoneType).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "PhoneTypeName"
            End If
            Dim sql As String =
                    " SELECT IdNo, PhoneTypeCode, PhoneTypeName, PhoneTypeNameAra, Notes" &
                    "   FROM [PhoneType] " & "order by " & sortExpression
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef phoneType As PhoneType) As Integer _
            Implements IDaoAll(Of PhoneType).UpdateRecord
            Dim sql As String =
                    " UPDATE [PhoneType]" &
                    "    SET PhoneTypeCode = @PhoneTypeCode," &
                    "        PhoneTypeName = @PhoneTypeName," &
                    "        PhoneTypeNameAra = @PhoneTypeNameAra," &
                    "        Notes = @Notes" &
                    "  WHERE IdNo = @IdNo"

            Return _db.Update(sql, Take(phoneType))
        End Function

        Public Function AddRecord(ByRef phoneType As PhoneType) As Integer Implements IDaoAll(Of PhoneType).AddRecord
            Dim sql As String =
                    " INSERT INTO [PhoneType] " &
                    " (PhoneTypeCode,PhoneTypeName,PhoneTypeNameAra,Notes) " &
                    " VALUES (@PhoneTypeCode,@PhoneTypeName,@PhoneTypeNameAra,@Notes) "
            Return _db.Insert(sql, Take(phoneType))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PhoneType) =
                                    Function(reader) _
            New PhoneType() With {
            .IdNo = Extensions.AsId(Of Byte)(reader("IdNo")),
            .PhoneTypeCode = Extensions.AsString(reader("PhoneTypeCode")),
            .PhoneTypeName = Extensions.AsString(reader("PhoneTypeName")),
            .PhoneTypeNameAra = Extensions.AsString(reader("PhoneTypeNameAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(phoneType As PhoneType) As Object()
            Return New Object() {
                                    "@IdNo", phoneType.IdNo,
                                    "@PhoneTypeCode", phoneType.PhoneTypeCode,
                                    "@PhoneTypeName", phoneType.PhoneTypeName,
                                    "@PhoneTypeNameAra", phoneType.PhoneTypeNameAra,
                                    "@Notes", phoneType.Notes
                                }
        End Function

    End Class

End Namespace
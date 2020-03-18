

Imports AATM.DataLayer.AdoNet
Imports AATM.Common.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for PhoneType
    ' ** DAO Pattern

    Public Class PhoneTypeDao
        Inherits CommonDao
        Implements IPhoneTypeDao

        Private ReadOnly Db As New Db()
        
        Public Function GetRecordById(idNo As Integer) As PhoneType Implements IPhoneTypeDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, PhoneTypeCode, PhoneTypeName, PhoneTypeNameAra, Notes" &
                    "   FROM [PhoneType]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "PhoneTypeName") As List(Of PhoneType) Implements IPhoneTypeDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, PhoneTypeCode, PhoneTypeName, PhoneTypeNameAra, Notes" &
                    "   FROM [PhoneType] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef phoneType As PhoneType) As Integer Implements IPhoneTypeDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [PhoneType]" &
                    "    SET PhoneTypeCode = @PhoneTypeCode," &
                    "        PhoneTypeName = @PhoneTypeName," &
                    "        PhoneTypeNameAra = @PhoneTypeNameAra," &
                    "        Notes = @Notes" &
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(phoneType))
        End Function

        Public Function AddRecord(ByRef phoneType As PhoneType) As Integer Implements IPhoneTypeDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [PhoneType] " &
                    " (PhoneTypeCode,PhoneTypeName,PhoneTypeNameAra,Notes) " &
                    " VALUES (@PhoneTypeCode,@PhoneTypeName,@PhoneTypeNameAra,@Notes) "
            Return Db.Insert(sql, Take(phoneType))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PhoneType) =
                                    Function(reader) _
            New PhoneType() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .PhoneTypeCode = Extensions.AsString(reader("PhoneTypeCode")),
            .PhoneTypeName = Extensions.AsString(reader("PhoneTypeName")),
            .PhoneTypeNameAra = Extensions.AsString(reader("PhoneTypeNameAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(phoneType As PhoneType) As Object()
            Return New Object() {
                                    "@IDNo", phoneType.IdNo,
                                    "@PhoneTypeCode", phoneType.PhoneTypeCode,
                                    "@PhoneTypeName", phoneType.PhoneTypeName,
                                    "@PhoneTypeNameAra", phoneType.PhoneTypeNameAra,
                                    "@Notes", phoneType.Notes
                                }
        End Function

    End Class

End Namespace
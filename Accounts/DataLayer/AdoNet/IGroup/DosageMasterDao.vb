Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for DosageMaster
    ' ** DAO Pattern

    Public Class DosageMasterDao
        Inherits CommonDao
        Implements IDao(Of DosageMaster), IDaoGetAll(Of DosageMaster)

        Private ReadOnly _db As New Db("IGROUPCLINIC")

        Private ReadOnly _fieldList As String = "Primary_Key," &
                                                "ItemId," &
                                                "ItemNameArabic," &
                                                "ItemNameEnglish"
        Public Overrides Function GetDB()
            Return _db
        End Function


        Public Function GetAll(Of TM)(sortExpression As String) As List(Of DosageMaster) Implements IDaoGetAll(Of DosageMaster).GetAll
            Dim sql As String = "SELECT " & _fieldList & " FROM MedicineDosageMaster order by " & GetActualFieldName(sortExpression)
            Return _db.Read(sql, Make).ToList()
        End Function


        Public Function GetRecordByIdNo(idNo) As DosageMaster Implements IDao(Of DosageMaster).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " & _fieldList &
                    " FROM MedicineDosageMaster" &
                    " WHERE " & GetPrimaryFieldName() & " = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim value As DosageMaster = _db.Read(sql, Make, params).FirstOrDefault()
            Return value
        End Function

        Public Function UpdateRecord(ByRef dosageMaster As DosageMaster) As Integer Implements IDao(Of DosageMaster).UpdateRecord
            Dim sql As String = " UPDATE MedicineDosageMaster SET " &
                    " ItemNameArabic = @DosageMasterNameAra where " & GetPrimaryFieldName() & " = @IdNo"
            Dim retVal As Integer
            retVal = _db.Update(sql, Take(dosageMaster))
            Return retVal
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DosageMaster) =
                            Function(reader) _
            New DosageMaster With {
            .DosageMasterCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemId")),
            .DosageMasterName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemNameEnglish")),
            .DosageMasterNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemNameArabic")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("Primary_Key"))
            }

        Private Function Take(DosageMaster As DosageMaster) As Object()
            Return New Object() {
                            "ItemId", DosageMaster.DosageMasterNameAra,
                            "ItemNameEnglish", DosageMaster.DosageMasterName,
                            "ItemNameArabic", DosageMaster.DosageMasterNameAra
                            }
        End Function

        Public Function AddRecord(ByRef recordData As DosageMaster) As Integer Implements IDao(Of DosageMaster).AddRecord
            Throw New NotImplementedException()
        End Function

        Public Overrides Function GetActualFieldName(fieldName As String)
            Dim actualFieldName As String
            If fieldName = "DosageMasterCode" Then
                actualFieldName = "ItemId"
            ElseIf fieldName = "DosageMasterName" Then
                actualFieldName = "ItemNameEnglish"
            ElseIf fieldName = "DosageMasterNameAra" Then
                actualFieldName = "ItemNameArabic"
            Else
                actualFieldName = fieldName
            End If
            Return actualFieldName
        End Function

        Public Overrides Function GetPrimaryFieldName()
            Return "Primary_Key"
        End Function

    End Class

    Public Class DosageMasterListDao
        Inherits CommonDao
        Implements IDaoGetAll(Of DosageMaster)

        Private ReadOnly _db As New Db("IGROUPCLINIC")

        Private ReadOnly _fieldList As String = "Primary_Key," &
                                                "ItemId," &
                                                "ItemNameArabic," &
                                                "ItemNameEnglish"

        Public Overrides Function GetDB()
            Return _db
        End Function

        Public Function GetAll(Of TM)(sortExpression As String) As List(Of DosageMaster) Implements IDaoGetAll(Of DosageMaster).GetAll
            Dim sql As String = "SELECT " & _fieldList & " FROM MedicineDosageMaster order by " & GetActualFieldName(sortExpression)
            Return _db.Read(sql, Make).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DosageMaster) =
                    Function(reader) _
                    New DosageMaster With {
                    .DosageMasterCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemId")),
                    .DosageMasterName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemNameEnglish")),
                    .DosageMasterNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemNameArabic")),
                    .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("Primary_Key"))
                    }

    End Class
End Namespace
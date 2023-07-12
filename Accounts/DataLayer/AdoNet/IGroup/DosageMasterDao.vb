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
        Implements IDao(Of DosageMasterDetail), IDaoGetAll(Of DosageMasterDetail)

        Private ReadOnly _db As New Db("IGROUPCLINIC")

        Private ReadOnly _fieldList As String = "IdNo," &
                                                "ItemId," &
                                                "ItemNameArabic," &
                                                "ItemNameEnglish"

        Public Overrides Function GetDB()
            Return _db
        End Function


        Public Function GetAll(Of DosageMasterDetail)(Optional sortString As String = Nothing) As List(Of DosageMasterDetail) Implements IDaoGetAll(Of DosageMasterDetail).GetAll
            Dim sql As String =
                    "SELECT " & _fieldList &
                    " FROM MedicineDosageMaster order by " & GetActualFieldName(sortString)
            Dim value As List(Of DosageMasterDetail) = _db.Read(sql, Make).ToList()
            Return value
        End Function


        Public Function GetRecordByIdNo(idNo) As DosageMasterDetail Implements IDao(Of DosageMasterDetail).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " & _fieldList &
                    " FROM DosageMaster" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim value As DosageMasterDetail = _db.Read(sql, Make, params).FirstOrDefault()
            Return value
        End Function

        Public Function UpdateRecord(ByRef dosageMasterDetail As DosageMasterDetail) As Integer Implements IDao(Of DosageMasterDetail).UpdateRecord
            Dim sql As String = " UPDATE DosageMaster SET " &
                    " ItemNameArabic = @DosageMasterNameAra where IdNo = @IdNo"
            Dim retVal As Integer
            retVal = _db.Update(sql, Take(dosageMasterDetail))
            Return retVal
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DosageMasterDetail) =
                            Function(reader) _
            New DosageMasterDetail() With {
            .DosageMasterCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemId")),
            .DosageMasterName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemNameEnglish")),
            .DosageMasterNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemNameArabic")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo"))
            }

        Private Function Take(DosageMaster As DosageMasterDetail) As Object()
            Return New Object() {
                            "ItemId", DosageMaster.DosageMasterNameAra,
                            "ItemNameEnglish", DosageMaster.DosageMasterName,
                            "ItemNameArabic", DosageMaster.DosageMasterNameAra
                            }
        End Function

        Public Function AddRecord(ByRef recordData As DosageMasterDetail) As Integer Implements IDao(Of DosageMasterDetail).AddRecord
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

    End Class

End Namespace
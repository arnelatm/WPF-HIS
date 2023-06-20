Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class PrescriptionDetailDao
        Inherits AccountsDao
        Implements IDaoChildUpdateOnly(Of PrescriptionDetail)
        'Implements IDaoGetRecords(Of PrescriptionDetail), IDaoGetRecord(Of PrescriptionDetail)

        Private ReadOnly _db As New Db("IGROUPCLINIC")

        Const FieldList As String = "Dosage," &
                                    "Duration," &
                                    "ItemCode," &
                                    "ItemName," &
                                    "RowNbr," &
                                    "TransKey"

        Public Overrides Function GetDB()
            Return _db
        End Function


        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of PrescriptionDetail) Implements IDaoChildUpdateOnly(Of PrescriptionDetail).GetRecordsWithGroupIdNo
            If idNo Is Nothing OrElse idNo.Equals(DBNull.Value) OrElse idNo = 0 Then
                Return Nothing
            Else
                If sortExpression Is Nothing Then
                    sortExpression = "RowNBR"
                End If
                Dim sql As String =
                        " SELECT " & FieldList &
                        " FROM PrescriptionDetail_View" &
                        " WHERE TransKey = @IdNo  " &
                        " ORDER BY " & sortExpression
                Dim params() As Object = {"@IdNo", idNo}
                Return _db.Read(sql, Make, params).ToList()
            End If
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PrescriptionDetail) =
                                    Function(reader) _
            New PrescriptionDetail() With {
            .Dosage = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Dosage")),
            .Duration = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Duration")),
            .ItemCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemCode")),
            .ItemName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemName")),
            .RowNbr = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("RowNbr")),
            .TransKey = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Transkey"))
            }

        'Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of PrescriptionDetail) Implements IDaoGetRecords(Of PrescriptionDetail).GetDaoRecords
        '    Dim sql As String = "SELECT " &
        '                        FieldList &
        '                        " FROM [PrescriptionDetail_View]" &
        '                        IIf(filter Is Nothing, "", " WHERE " & filter)
        '    Return Db.Read(sql, Make).ToList()
        'End Function

        'Public Function GetDaoRecord(Optional filter As String = Nothing) As PrescriptionDetail Implements IDaoGetRecord(Of PrescriptionDetail).GetDaoRecord
        '    Dim sql As String = "SELECT " & FieldList &
        '                        " FROM [PrescriptionDetail_View]" &
        '                        IIf(filter Is Nothing, "", " WHERE " & filter)
        '    Dim x As PrescriptionDetail = Db.Read(sql, Make).FirstOrDefault()
        '    Return x
        'End Function

    End Class

End Namespace
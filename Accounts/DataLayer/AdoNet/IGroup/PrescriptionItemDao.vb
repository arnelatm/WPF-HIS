Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CbcRetrieval
    ' ** DAO Pattern

    Public Class PrescriptionItemDao
        Inherits AccountsDao
        Implements IDaoChildUpdateOnly(Of PrescriptionItem)
        'Implements IDaoGetRecords(Of PrescriptionDetail), IDaoGetRecord(Of PrescriptionDetail)

        Private ReadOnly _db As New Db("IGROUPCLINIC")


        Const FieldList As String = "Dosage," &
                                    "Duration," &
                                    "GenericName," &
                                    "ItemCode," &
                                    "ItemName," &
                                    "LabelPrinted," &
                                    "PrescriptionItemIdNo," &
                                    "PrintLabel," &
                                    "RowNbr," &
                                    "TransKey"

        Public Overrides Function GetDB()
            Return _db
        End Function


        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of PrescriptionItem) Implements IDaoChildUpdateOnly(Of PrescriptionItem).GetRecordsWithGroupIdNo
            If idNo Is Nothing OrElse idNo.Equals(DBNull.Value) OrElse idNo = 0 Then
                Return Nothing
            Else
                If sortExpression Is Nothing Then
                    sortExpression = "RowNBR"
                End If
                Dim sql As String =
                        " SELECT " & FieldList &
                        " FROM PrescriptionItem_View" &
                        " WHERE TransKey = @IdNo  " &
                        " ORDER BY " & sortExpression
                Dim params() As Object = {"@IdNo", idNo}
                Return _db.Read(sql, Make, params).ToList()
            End If
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PrescriptionItem) =
                                    Function(reader) _
            New PrescriptionItem() With {
            .Dosage = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Dosage")),
            .Duration = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Duration")),
            .GenericName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("GenericName")),
            .ItemCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemCode")),
            .ItemName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemName")),
            .LabelPrinted = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("LabelPrinted")),
            .PrescriptionItemIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("PrescriptionItemIdNo")),
            .RowNbr = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("RowNbr")),
            .TransKey = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Transkey")),
            .PrintLabel = Not (AATM.DataLayer.AdoNet.Extensions.AsBool(reader("LabelPrinted")))
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
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

        Private ReadOnly Db As New Db()

        Const FieldList As String = "DosageEnglish," &
                                    "Duration," &
                                    "Item_Code," &
                                    "ItemNameEnglish," &
                                    "RowNbr," &
                                    "Trans_Key"

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of PrescriptionDetail) Implements IDaoChildUpdateOnly(Of PrescriptionDetail).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "RowNBR"
            End If
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM PMRMedicineDetails_View" &
                    " WHERE Group_key = @IdNo  " &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PrescriptionDetail) =
                                    Function(reader) _
            New PrescriptionDetail() With {
            .DosageEnglish = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DosageEnglish")),
            .Duration = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Duration")),
            .Item_Code = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Item_Code")),
            .ItemNameEnglish = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ItemNameEnglish")),
            .RowNbr = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("RowNbr"))
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
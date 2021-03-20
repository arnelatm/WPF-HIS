Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for TranslatedCaption
    ' ** DAO Pattern

    Public Class TranslatedCaptionDao
        Inherits BaseDao
        Implements IDao(Of TranslatedCaption)

        Private ReadOnly _db As New Db ' ("TRANSLATIONS")

        Public Function GetRecordByIdNo(idNo) As TranslatedCaption _
            Implements IDao(Of TranslatedCaption).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, TranslatedCaption, CaptionIdNo, LanguageIdNo " &
                    "   FROM [TranslatedCaption]" &
                    " WHERE CaptionIdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef TranslatedCaption As TranslatedCaption) As Integer _
            Implements IDao(Of TranslatedCaption).UpdateRecord
            Dim sql As String =
                    " UPDATE [TranslatedCaption]" &
                    "    SET TranslatedCaption = @TranslatedCaption," &
                    "        LanguageIdNo = @LanguageIdNo," &
                    "        CaptionIdNo = @CaptionIdNo" &
                    "  WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(TranslatedCaption))
        End Function

        Public Function AddRecord(ByRef TranslatedCaption As TranslatedCaption) As Integer _
            Implements IDao(Of TranslatedCaption).AddRecord
            Dim sql As String =
                    " INSERT INTO [TranslatedCaption] " &
                    " (TranslatedCaption,CaptionIdNo,LanguageIdNo) " &
                    " VALUES (@TranslatedCaption,@CaptionIdNo,@LanguageIdNo) "
            Dim retVal As Integer
            retVal = _db.Insert(sql, Take(TranslatedCaption))
            Return retVal
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, TranslatedCaption) =
                                    Function(reader) _
            New TranslatedCaption() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .CaptionIdNo = Extensions.AsInt(Of Int32)(reader("CaptionIdNo")),
            .LanguageIdNo = Extensions.AsInt(Of Int16)(reader("LanguageIdNo")),
            .TranslatedCaption = Extensions.AsString(reader("TranslatedCaption"))
            }

        Private Function Take(TranslatedCaption As TranslatedCaption) As Object()
            Return New Object() {"@IdNo", TranslatedCaption.IdNo,
                                 "@CaptionIdNo", TranslatedCaption.CaptionIdNo,
                                 "@LanguageIdNo", TranslatedCaption.LanguageIdNo,
                                 "@TranslatedCaption", TranslatedCaption.TranslatedCaption}
        End Function

    End Class

End Namespace
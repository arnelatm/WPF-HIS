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

        Public Function GetRecordById(idNo As Integer) As TranslatedCaption _
            Implements IDao(Of TranslatedCaption).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, TranslatedCaption, CaptionIdNo, LanguageIdNo " &
                    "   FROM [TranslatedCaption]" &
                    " WHERE CaptionIdNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef TranslatedCaption As TranslatedCaption) As Integer _
            Implements IDao(Of TranslatedCaption).UpdateRecord
            Dim sql As String =
                    " UPDATE [TranslatedCaption]" &
                    "    SET TranslatedCaption = @TranslatedCaption," &
                    "        LanguageIdNo = @LanguageIdNo," &
                    "        CaptionIdNo = @CaptionIdNo" &
                    "  WHERE IDNo = @IDNo"
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
            .IdNo = Extensions.AsId(reader("IDNo")),
            .CaptionIdNo = Extensions.AsInt(Of Integer)(reader("CaptionIdNo")),
            .LanguageIdNo = Extensions.AsInt(Of Integer)(reader("LanguageIdNo")),
            .TranslatedCaption = Extensions.AsString(reader("TranslatedCaption"))
            }

        Private Function Take(TranslatedCaption As TranslatedCaption) As Object()
            Return New Object() {"@IDNo", TranslatedCaption.IdNo,
                                 "@CaptionIdNo", TranslatedCaption.CaptionIdNo,
                                 "@LanguageIdNo", TranslatedCaption.LanguageIdNo,
                                 "@TranslatedCaption", TranslatedCaption.TranslatedCaption}
        End Function

    End Class

End Namespace
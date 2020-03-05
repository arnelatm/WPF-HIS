Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for TranslatedMessages
    ' ** DAO Pattern

    Public Class TranslatedMessagesDao
        Inherits BaseDao
        Implements ITranslatedMessagesDao

        Private Shared ReadOnly Db As New Db("TRANSLATIONS")

        Public Function GetRecordById(idNo As Integer) As TranslatedMessages Implements ITranslatedMessagesDao.GetRecordById
            Dim sql As String =
                    " SELECT IdNo, TranslatedMessage, TranslatedCaption, OriginalIdNo, LanguageIdNo " &
                    "   FROM [TranslatedMessages]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "IdNo") As List(Of TranslatedMessages) Implements ITranslatedMessagesDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, TranslatedMessage" &
                    "   FROM [TranslatedMessages] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef translatedMessages As TranslatedMessages) As Integer Implements ITranslatedMessagesDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [TranslatedMessages]" &
                    "    SET TranslatedMessage = @TranslatedMessage," &
                    "        TranslatedCaption = @TranslatedCaption," &
                    "        LanguageIdNo = @LanguageIdNo," &
                    "        OriginalIdNo = @OriginalIdNo" &
                    "  WHERE IDNo = @IDNo"
            Return Db.Update(sql, Take(translatedMessages))
        End Function

        Public Function AddRecord(ByRef translatedMessages As TranslatedMessages) As Integer Implements ITranslatedMessagesDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [TranslatedMessages] " &
                    " (TranslatedMessage,TranslatedCaption,OriginalIdNo,LanguageIdNo) " &
                    " VALUES (@TranslatedMessage,@TranslatedCaption,@OriginalIdNo,@LanguageIdNo) "
            Return Db.Insert(sql, Take(translatedMessages))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, TranslatedMessages) =
                                    Function(reader) _
            New TranslatedMessages() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .OriginalIdNo = Extensions.AsInt(Of Integer)(reader("OriginalIdNo")),
            .LanguageIdNo = Extensions.AsInt(Of Integer)(reader("LanguageIdNo")),
            .TranslatedMessage = Extensions.AsString(reader("TranslatedMessage")),
            .TranslatedCaption = Extensions.AsString(reader("TranslatedCaption"))
                                          }

        Private Function Take(translatedMessages As TranslatedMessages) As Object()
            Return New Object() {"@IDNo", translatedMessages.IdNo,
                                  "@OriginalIdNo", translatedMessages.OriginalIdNo,
                                  "@LanguageIdNo", translatedMessages.LanguageIdNo,
                                  "@TranslatedMessage", translatedMessages.TranslatedMessage,
                                  "@TranslatedCaption", translatedMessages.TranslatedCaption}
        End Function

    End Class

End Namespace
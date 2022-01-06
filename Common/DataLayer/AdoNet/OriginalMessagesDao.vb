Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for OriginalMessages
    ' ** DAO Pattern

    Public Class OriginalMessagesDao
        Inherits CommonDao
        Implements iDao(Of OriginalMessages), IDaoList(Of OriginalMessages)

        Private ReadOnly _db As New Db

        Public Function GetRecordByIdNo(idNo) As OriginalMessages _
            Implements iDao(Of OriginalMessages).GetRecordByIdNo
            Dim sql As String = "select	o.[IdNo], " &
                                "o.[MessageKey], " &
                                "o.[Message], " &
                                "o.[Caption], " &
                                "o.Notes, " &
                                "t.[IdNo] AS 'IdNoTranslated', " &
                                "t.LanguageIdNo, " &
                                "t.TranslatedMessage, " &
                                "t.TranslatedCaption " &
                                "FROM [dbo].[OriginalMessages] o " &
                                "Left JOIN dbo.TranslatedMessages t " &
                                "ON o.IdNo = t.MessageIdNo " &
                                "Left JOIN dbo.Languages l " &
                                "ON t.LanguageIdNo = l.IdNo " &
                                "where o.[IdNo] = @IdNo and (LanguageIdNo = 16 OR LanguageIdNo IS Null)"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef originalMessages As OriginalMessages) As Integer _
            Implements iDao(Of OriginalMessages).UpdateRecord
            Dim sql As String =
                    " UPDATE [OriginalMessages]" &
                    "    SET MessageKey = @MessageKey," &
                    "        Message = @Message," &
                    "        Caption = @Caption," &
                    "        Notes = @Notes" &
                    "  WHERE IdNo = @IdNo"
            Dim retVal = _db.Update(sql, Take(originalMessages))
            If retVal > 0 Then
                If (String.IsNullOrWhiteSpace(originalMessages.TranslatedMessage) AndAlso String.IsNullOrWhiteSpace(originalMessages.TranslatedCaption)) Then
                    DeleteRecord(originalMessages.IdNoTranslated, "TranslatedMessages")
                Else
                    If String.IsNullOrWhiteSpace(originalMessages.TranslatedMessage) Then
                        originalMessages.TranslatedMessage = originalMessages.Message
                    Else
                        originalMessages.TranslatedCaption = originalMessages.Caption
                    End If
                    sql = " UPDATE [TranslatedMessages]" &
                        "    SET TranslatedMessage = @TranslatedMessage," &
                        "        TranslatedCaption = @TranslatedCaption," &
                        "        LanguageIdNo = @LanguageIdNo," &
                        "        MessageIdNo = @IdNo" &
                        "  WHERE IdNo = @IdNoTranslated"
                    retVal = _db.Update(sql, TakeTranslatedMessage(originalMessages))
                    If retVal = 0 Then
                        sql = "INSERT INTO [TranslatedMessages] " &
                          "(TranslatedMessage,TranslatedCaption,MessageIdNo,LanguageIdNo) " &
                          "VALUES (@TranslatedMessage,@TranslatedCaption,@IdNo,@LanguageIdNo)"
                        retVal = _db.Insert(sql, TakeTranslatedMessage(originalMessages))
                    End If
                End If
            End If
            Return retVal
        End Function

        Public Function AddRecord(ByRef originalMessage As OriginalMessages) As Integer _
            Implements iDao(Of OriginalMessages).AddRecord
            Dim sql As String =
                    " INSERT INTO [OriginalMessages] " &
                    " (MessageKey,Message,Caption,Notes) " &
                    " VALUES (@MessageKey,@Message,@Caption,@Notes) "
            Dim retVal As Integer
            retVal = _db.Insert(sql, Take(originalMessage))
            If retVal > 0 Then
                originalMessage.IdNo = retVal
                sql = "INSERT INTO [TranslatedMessages] " &
                      "(TranslatedMessage, TranslatedCaption, MessageIdNo, LanguageIdNo) " &
                      "VALUES (@TranslatedMessage, @TranslatedCaption, @IdNo, @LanguageIdNo)"
                _db.Insert(sql, TakeTranslatedMessage(originalMessage))
            End If
            Return retVal
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, OriginalMessages) =
                                    Function(reader) _
            New OriginalMessages() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .MessageKey = Extensions.AsString(reader("MessageKey")),
            .Message = Extensions.AsString(reader("Message")),
            .Caption = Extensions.AsString(reader("Caption")),
            .IdNoTranslated = Extensions.AsString(reader("IdNoTranslated")),
            .TranslatedMessage = Extensions.AsString(reader("TranslatedMessage")),
            .TranslatedCaption = Extensions.AsString(reader("TranslatedCaption")),
            .LanguageIdNo = Extensions.AsInt(Of Int16)(reader("LanguageIdNo")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(originalMessage As OriginalMessages) As Object()
            Return New Object() {
                                    "@IdNo", originalMessage.IdNo,
                                    "@MessageKey", originalMessage.MessageKey,
                                    "@Message", originalMessage.Message,
                                    "@Caption", originalMessage.Caption,
                                    "@Notes", originalMessage.Notes
                                }
        End Function

        Private Function TakeTranslatedMessage(translatedMessage As OriginalMessages) As Object()
            Return New Object() {"@IdNoTranslated", translatedMessage.IdNoTranslated,
                                 "@IdNo", translatedMessage.IdNo,
                                 "@LanguageIdNo", translatedMessage.LanguageIdNo,
                                 "@TranslatedMessage", translatedMessage.TranslatedMessage,
                                 "@TranslatedCaption", translatedMessage.TranslatedCaption}
        End Function

        Public Function GetList(Optional sortExpression As String = Nothing) As List(Of OriginalMessages) Implements IDaoList(Of OriginalMessages).GetList
            Dim sql As String = "select	o.[IdNo], " &
                                "o.[MessageKey], " &
                                "o.[Message], " &
                                "o.[Caption], " &
                                "o.Notes, " &
                                "t.[IdNo] AS 'IdNoTranslated', " &
                                "t.LanguageIdNo, " &
                                "t.TranslatedMessage, " &
                                "t.TranslatedCaption " &
                                "FROM [dbo].[OriginalMessages] o " &
                                "Left JOIN dbo.TranslatedMessages t " &
                                "ON o.IdNo = t.MessageIdNo " &
                                "Left JOIN dbo.Languages l " &
                                "ON t.LanguageIdNo = l.IdNo " 
            Return _db.Read(sql, Make).ToList()
        End Function
    End Class

End Namespace
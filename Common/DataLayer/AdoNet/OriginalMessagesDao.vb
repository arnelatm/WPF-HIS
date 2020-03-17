Imports AATM.DataLayer.AdoNet
Imports AATM.Common.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for OriginalMessages
    ' ** DAO Pattern

    Public Class OriginalMessagesDao
        Inherits CommonDao
        Implements IOriginalMessagesDao

        Private ReadOnly Db As New Db("TRANSLATIONS")

        Public Function GetRecordById(idNo As Integer) As OriginalMessages Implements IOriginalMessagesDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, MessageKey, Message, Caption, Notes" &
                    "   FROM [OriginalMessages]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "MessageKey") As List(Of OriginalMessages) Implements IOriginalMessagesDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, MessageKey, Message, Caption, Notes" &
                    "   FROM [OriginalMessages] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef originalMessages As OriginalMessages) As Integer Implements IOriginalMessagesDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [OriginalMessages]" &
                    "    SET MessageKey = @MessageKey," &
                    "        Message = @Message," &
                    "        Caption = @Caption," &
                    "        Notes = @Notes" &
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(originalMessages))
        End Function

        Public Function AddRecord(ByRef originalMessages As OriginalMessages) As Integer Implements IOriginalMessagesDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [OriginalMessages] " &
                    " (MessageKey,Message,Caption,Notes) " &
                    " VALUES (@MessageKey,@Message,@Caption,@Notes) "
            Return Db.Insert(sql, Take(originalMessages))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, OriginalMessages) =
                                    Function(reader) _
            New OriginalMessages() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .MessageKey = Extensions.AsString(reader("MessageKey")),
            .Message = Extensions.AsString(reader("Message")),
            .Caption = Extensions.AsString(reader("Caption")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(originalMessages As OriginalMessages) As Object()
            Return New Object() {
                                    "@IDNo", originalMessages.IdNo,
                                    "@MessageKey", originalMessages.MessageKey,
                                    "@Message", originalMessages.Message,
                                    "@Caption", originalMessages.Caption,
                                    "@Notes", originalMessages.Notes
                                }
        End Function

    End Class

End Namespace
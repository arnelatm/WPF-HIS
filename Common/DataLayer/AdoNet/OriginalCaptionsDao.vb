Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for OriginalCaptions
    ' ** DAO Pattern

    Public Class OriginalCaptionsDao
        Inherits CommonDao
        Implements iDao(Of OriginalCaptions) ', IDaoList(Of OriginalCaptions)

        Private ReadOnly _db As New Db

        Public Function GetRecordByIdNo(idNo) As OriginalCaptions _
            Implements iDao(Of OriginalCaptions).GetRecordByIdNo
            Dim sql As String = "select o.[IdNo]," &
                                "o.[Caption] , " &
                                "t.[IdNo] AS 'IdNoTranslated'," &
                                "t.LanguageIdNo, " &
                                "t.TranslatedCaption " &
                                "FROM [dbo].[OriginalCaptions] o " &
                                "Left JOIN dbo.TranslatedCaption t " &
                                "ON o.IdNo = t.CaptionIdNo " &
                                "Left JOIN dbo.Languages l " &
                                "ON t.LanguageIdNo = l.IdNo " &
                                "where o.[IdNo] = @IdNo and (LanguageIdNo = 16 OR LanguageIdNo IS Null) "
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        'Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of OriginalCaptions) _
        '    Implements iDaoAll(Of OriginalCaptions).GetAll
        '    If sortExpression Is Nothing Then
        '        sortExpression = "Caption"
        '    End If
        '    Dim sql As String =
        '            " SELECT IdNo, Caption" &
        '            "   FROM [OriginalCaptions] " & "order by " & sortExpression
        '    Return _db.Read(sql, Make).ToList()
        'End Function

        Public Function UpdateRecord(ByRef originalCaptions As OriginalCaptions) As Integer _
            Implements iDao(Of OriginalCaptions).UpdateRecord
            Dim retVal As Integer = 0
            Dim sql As String = "UPDATE [OriginalCaptions] " &
                    "Set Caption = @Caption " &
                    "WHERE IdNo = @IdNo"
            retVal = _db.Update(sql, Take(originalCaptions))
            If retVal > 0 Then
                If String.IsNullOrWhiteSpace(originalCaptions.TranslatedCaption) Then
                    DeleteRecord(originalCaptions.IdNoTranslated, "TranslatedCaption")
                Else
                    sql = "UPDATE [TranslatedCaption] " &
                      "SET TranslatedCaption = @TranslatedCaption, " &
                      "LanguageIdNo = @LanguageIdNo, " &
                      "CaptionIdNo = @IdNo " &
                      "WHERE IdNo = @IdNoTranslated"
                    retVal = _db.Update(sql, TakeTranslatedCaption(originalCaptions))
                    If retVal <= 0 Then
                        sql = " INSERT INTO [TranslatedCaption] " &
                          " (TranslatedCaption,CaptionIdNo,LanguageIdNo) " &
                          " VALUES (@TranslatedCaption,@IdNo,@LanguageIdNo) "
                        retVal = _db.Insert(sql, TakeTranslatedCaption(originalCaptions))
                    End If
                End If
            End If
            Return retVal
        End Function

        Public Function AddRecord(ByRef originalCaptions As OriginalCaptions) As Integer _
            Implements iDao(Of OriginalCaptions).AddRecord
            Dim sql As String = "INSERT INTO [OriginalCaptions] " &
                    "(Caption) " &
                    "VALUES (@Caption) "
            Dim retVal As Integer
            retVal = _db.Insert(sql, Take(originalCaptions))
            If retVal > 0 Then
                originalCaptions.IdNo = retVal
                sql = "INSERT INTO [TranslatedCaption] " &
                      "(TranslatedCaption,CaptionIdNo,LanguageIdNo) " &
                      "VALUES (@TranslatedCaption,@IdNo,@LanguageIdNo)"
                _db.Insert(sql, TakeTranslatedCaption(originalCaptions))
            End If
            Return retVal
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, OriginalCaptions) =
                                    Function(reader) _
            New OriginalCaptions() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Caption = Extensions.AsString(reader("Caption")),
            .IdNoTranslated = Extensions.AsInt(Of Integer)(reader("IdNoTranslated")),
            .TranslatedCaption = Extensions.AsString(reader("TranslatedCaption")),
            .LanguageIdNo = Extensions.AsInt(Of Int16)(reader("LanguageIdNo"))
            }

        Private Function Take(originalCaptions As OriginalCaptions) As Object()
            Return New Object() {
                                    "@IdNo", originalCaptions.IdNo,
                                    "@Caption", originalCaptions.Caption
                                }
        End Function

        Private Function TakeTranslatedCaption(originalCaptions As OriginalCaptions) As Object()
            Return New Object() {"@IdNoTranslated", originalCaptions.IdNoTranslated,
                                 "@IdNo", originalCaptions.IdNo,
                                 "@LanguageIdNo", originalCaptions.LanguageIdNo,
                                 "@TranslatedCaption", originalCaptions.TranslatedCaption}
        End Function

    End Class

End Namespace
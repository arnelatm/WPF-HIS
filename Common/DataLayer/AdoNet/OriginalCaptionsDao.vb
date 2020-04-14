Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for OriginalCaptions
    ' ** DAO Pattern

    Public Class OriginalCaptionsDao
        Inherits CommonDao
        Implements IDaoAll(Of OriginalCaptions)

        Private ReadOnly _db As New Db

        Public Function GetRecordById(idNo As Integer) As OriginalCaptions _
            Implements IDaoAll(Of OriginalCaptions).GetRecordById
            Dim sql As String =
                    " SELECT IDNo, Caption " &
                    "   FROM [OriginalCaptions]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of OriginalCaptions) _
            Implements IDaoAll(Of OriginalCaptions).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "Caption"
            End If
            Dim sql As String =
                    " SELECT IDNo, Caption" &
                    "   FROM [OriginalCaptions] " & "order by " & sortExpression
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef originalCaptions As OriginalCaptions) As Integer _
            Implements IDaoAll(Of OriginalCaptions).UpdateRecord
            Dim sql As String =
                    " UPDATE [OriginalCaptions]" &
                    " Set Caption = @Caption" &
                    " WHERE IDNo = @IDNo"
            Return _db.Update(sql, Take(originalCaptions))
        End Function

        Public Function AddRecord(ByRef originalCaptions As OriginalCaptions) As Integer _
            Implements IDaoAll(Of OriginalCaptions).AddRecord
            Dim sql As String =
                    " INSERT INTO [OriginalCaptions] " &
                    " (Caption) " &
                    " VALUES (@Caption) "
            Return _db.Insert(sql, Take(originalCaptions))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, OriginalCaptions) =
                                    Function(reader) _
            New OriginalCaptions() With {
            .IdNo = Extensions.AsId(reader("IdNo")),
            .Caption = Extensions.AsString(reader("Caption"))
            }

        Private Function Take(originalCaptions As OriginalCaptions) As Object()
            Return New Object() {
                                    "@IDNo", originalCaptions.IdNo,
                                    "@Caption", originalCaptions.Caption
                                }
        End Function

    End Class

End Namespace
Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Document
    ' ** DAO Pattern

    Public Class DocumentDao
        Inherits CommonDao
        Implements iDao(Of Document), IDaoAutoCode

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As Document Implements iDao(Of Document).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, DocumentCode, DocumentName, DocumentNameAra, DocumentType, ImageType, NeedsNumber, NeedsIssueDate, NeedsExpiryDate, Notes" &
                    "   FROM [Document]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef Document As Document) As Integer Implements iDao(Of Document).UpdateRecord
            Dim sql As String =
                    " UPDATE [Document]" &
                    "    SET DocumentCode = @DocumentCode," &
                    "        DocumentName = @DocumentName," &
                    "        DocumentNameAra = @DocumentNameAra," &
                    "        DocumentType = @DocumentType," &
                    "        ImageType = @ImageType," &
                    "        NeedsNumber = @NeedsNumber," &
                    "        NeedsIssueDate = @NeedsIssueDate," &
                    "        NeedsExpiryDate = @NeedsExpiryDate," &
                    "        Notes = @Notes" &
                    "  WHERE IdNo = @IdNo"

            Return Db.Update(sql, Take(Document))
        End Function

        Public Function AddRecord(ByRef Document As Document) As Integer Implements iDao(Of Document).AddRecord
            Dim sql As String =
                    " INSERT INTO [Document] " &
                    " (DocumentCode,DocumentName,DocumentNameAra,DocumentType,ImageType,NeedsNumber,NeedsIssueDate,NeedsExpiryDate,Notes) " &
                    " VALUES (@DocumentCode,@DocumentName,@DocumentNameAra,@DocumentType,@ImageType,@NeedsNumber,@NeedsIssueDate,@NeedsExpiryDate,@Notes) "
            Return Db.Insert(sql, Take(Document))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Document) =
                                    Function(reader) _
            New Document() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .DocumentCode = Extensions.AsString(reader("DocumentCode")),
            .DocumentName = Extensions.AsString(reader("DocumentName")),
            .DocumentNameAra = Extensions.AsString(reader("DocumentNameAra")),
            .DocumentType = Extensions.AsString(reader("DocumentType")),
            .ImageType = Extensions.AsString(reader("ImageType")),
            .NeedsNumber = Extensions.AsBool(reader("NeedsNumber")),
            .NeedsIssueDate = Extensions.AsBool(reader("NeedsIssueDate")),
            .NeedsExpiryDate = Extensions.AsBool(reader("NeedsExpiryDate")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(Document As Document) As Object()
            Return New Object() {
                                    "@IdNo", Document.IdNo,
                                    "@DocumentCode", Document.DocumentCode,
                                    "@DocumentName", Document.DocumentName,
                                    "@DocumentNameAra", Document.DocumentNameAra,
                                    "@DocumentType", Document.DocumentType,
                                    "@ImageType", Document.ImageType,
                                    "@NeedsNumber", Document.NeedsNumber,
                                    "@NeedsIssueDate", Document.NeedsIssueDate,
                                    "@NeedsExpiryDate", Document.NeedsExpiryDate,
                                    "@Notes", Document.Notes
                                }
        End Function

        Public Function GenerateCode(idNo As Integer) As String Implements IDaoAutoCode.GenerateCode
            Return UpdateCode(db, "Document", "DocumentCode", "IdNo", idNo)
        End Function

    End Class

End Namespace
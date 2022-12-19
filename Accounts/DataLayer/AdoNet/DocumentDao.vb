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

        Private Const FieldList = "DocumentCode," &
                                  "DocumentName," &
                                  "DocumentNameAra," &
                                  "DocumentType," &
                                  "IdNo," &
                                  "ImageType," &
                                  "NeedsExpiryDate," &
                                  "NeedsIssueDate," &
                                  "NeedsNumber," &
                                  "Notes"

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As Document Implements iDao(Of Document).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " &
                    FieldList &
                    " FROM [Document]" &
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
                    "        NeedsExpiryDate = @NeedsExpiryDate," &
                    "        NeedsIssueDate = @NeedsIssueDate," &
                    "        NeedsNumber = @NeedsNumber," &
                    "        Notes = @Notes" &
                    "  WHERE IdNo = @IdNo "
            Return Db.Update(sql, Take(Document))
        End Function

        Public Function AddRecord(ByRef Document As Document) As Integer Implements iDao(Of Document).AddRecord
            Dim sql As String = "INSERT INTO [Document] (" &
                                  "DocumentCode," &
                                  "DocumentName," &
                                  "DocumentNameAra," &
                                  "DocumentType," &
                                  "ImageType," &
                                  "NeedsExpiryDate," &
                                  "NeedsIssueDate," &
                                  "NeedsNumber," &
                                  "Notes" &
                                  ") VALUES (" &
                                  "@DocumentCode," &
                                  "@DocumentName," &
                                  "@DocumentNameAra," &
                                  "@DocumentType," &
                                  "@ImageType," &
                                  "@NeedsExpiryDate," &
                                  "@NeedsIssueDate," &
                                  "@NeedsNumber," &
                                  "@Notes" &
                                  ")"
            Return Db.Insert(sql, Take(Document))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Document) =
                                    Function(reader) _
            New Document() With {
            .DocumentCode = Extensions.AsString(reader("DocumentCode")),
            .DocumentName = Extensions.AsString(reader("DocumentName")),
            .DocumentNameAra = Extensions.AsString(reader("DocumentNameAra")),
            .DocumentType = Extensions.AsString(reader("DocumentType")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .ImageType = Extensions.AsString(reader("ImageType")),
            .NeedsExpiryDate = Extensions.AsBool(reader("NeedsExpiryDate")),
            .NeedsIssueDate = Extensions.AsBool(reader("NeedsIssueDate")),
            .NeedsNumber = Extensions.AsBool(reader("NeedsNumber")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(Document As Document) As Object()
            Return New Object() {
                                    "@DocumentCode", Document.DocumentCode,
                                    "@DocumentName", Document.DocumentName,
                                    "@DocumentNameAra", Document.DocumentNameAra,
                                    "@DocumentType", Document.DocumentType,
                                    "@IdNo", Document.IdNo,
                                    "@ImageType", Document.ImageType,
                                    "@NeedsExpiryDate", Document.NeedsExpiryDate,
                                    "@NeedsIssueDate", Document.NeedsIssueDate,
                                    "@NeedsNumber", Document.NeedsNumber,
                                    "@Notes", Document.Notes
                                }
        End Function

        Public Function GenerateCode(idNo As Integer) As String Implements IDaoAutoCode.GenerateCode
            Return UpdateCode("Document", "DocumentCode", "IdNo", idNo)
        End Function

    End Class

End Namespace
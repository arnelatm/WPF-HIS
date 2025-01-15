Imports System.IO
Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for DocumentDetail
    ' ** DAO Pattern

    Public Class DocumentDetailDao
        Inherits CommonDao
        Implements IDao(Of DocumentDetail)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo As Object) As DocumentDetail Implements IDao(Of DocumentDetail).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " &
                    "Active," &
                    "BranchIdNo," &
                    "ContactIdNo," &
                    "DateCreated," &
                    "DataImageIdNo," &
                    "DocumentIdNo," &
                    "DocumentNumber," &
                    "ExpiryDate," &
                    "IdNo," &
                    "IssueDate," &
                    "Picture," &
                    "UserIdNo" &
                    " FROM DocumentDetail" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function
        Public Function UpdateRecord(ByRef documentDetail As DocumentDetail) As Integer Implements IDao(Of DocumentDetail).UpdateRecord
            Dim sql As String =
                    " UPDATE [DocumentDetail]" &
                    " SET Active = @Active," &
                    " BranchIdNo = @BranchIdNo," &
                    " ContactIdNo = @ContactIdNo," &
                    " DataImageIdNo = @DataImageIdNo," &
                    " DocumentIdNo = @DocumentIdNo," &
                    " DocumentNumber = @DocumentNumber," &
                    " ExpiryDate = @ExpiryDate," &
                    " IssueDate = @IssueDate," &
                    " Picture = @Picture" &
                    " WHERE IdNo = @IdNo "
            Return Db.Update(sql, Take(documentDetail))
        End Function

        Public Function AddRecord(ByRef documentDetail As DocumentDetail) As Integer Implements IDao(Of DocumentDetail).AddRecord
            Dim sql As String = "INSERT INTO [DocumentDetail] (" &
                                  "Active," &
                                  "BranchIdNo," &
                                  "ContactIdNo," &
                                  "DataImageIdNo," &
                                  "DocumentIdNo," &
                                  "DocumentNumber," &
                                  "ExpiryDate," &
                                  "IssueDate," &
                                  "Picture," &
                                  "UserIdNo" &
                                  ") VALUES (" &
                                  "@Active," &
                                  "@BranchIdNo," &
                                  "@ContactIdNo," &
                                  "@DataImageIdNo," &
                                  "@DocumentIdNo," &
                                  "@DocumentNumber," &
                                  "@ExpiryDate," &
                                  "@IssueDate," &
                                  "@Picture," &
                                  "@UserIdNo" &
                                  ")"
            Return Db.Insert(sql, Take(documentDetail))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DocumentDetail) =
                                    Function(reader) _
            New DocumentDetail() With {
            .Active = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Active")),
            .ContactIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("ContactIdNo")),
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("DateCreated")),
            .DataImageIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("DataImageIdNo")),
            .DocumentIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("DocumentIdNo")),
            .DocumentNumber = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DocumentNumber")),
            .ExpiryDate = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Date?)(reader("ExpiryDate")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("IdNo")),
            .IssueDate = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Date?)(reader("IssueDate")),
            .Picture = AATM.DataLayer.AdoNet.Extensions.AsImage(reader("Picture")),
            .UserIdNo = GlobalVariables.UserIdNo
            }

        Private Function Take(documentDetail As DocumentDetail) As Object()
            Return New Object() {
                                    "@Active", documentDetail.Active,
                                    "@BranchIdNo", GlobalVariables.BranchIdNo,
                                    "@ContactIdNo", documentDetail.ContactIdNo,
                                    "@DataImageIdNo", documentDetail.DataImageIdNo,
                                    "@DocumentIdNo", documentDetail.DocumentIdNo,
                                    "@DocumentNumber", documentDetail.DocumentNumber,
                                    "@ExpiryDate", documentDetail.ExpiryDate,
                                    "@IdNo", documentDetail.IdNo,
                                    "@IssueDate", documentDetail.IssueDate,
                                    "@Picture", ToSqlImage(documentDetail.Picture),
                                    "@UserIdNo", documentDetail.UserIdNo
                                 }
        End Function

        Public Function ToSqlImage(ByVal imageIn As System.Drawing.Image) As Byte()
            If imageIn Is Nothing Then
                Return System.Text.Encoding.UTF8.GetBytes("")
            Else
                Dim data As Byte() = {}
                Dim saveImage As New Bitmap(imageIn)
                saveImage.Save("C:\temp\Picture.jpg", Imaging.ImageFormat.Jpeg)
                saveImage.Dispose()
                Dim cPictureBox As New PictureBox
                cPictureBox.Image = Image.FromFile("c:\temp\Picture.jpg")
                Using ms = New MemoryStream()
                    If imageIn IsNot Nothing Then
                        cPictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                        data = ms.ToArray()
                    End If
                End Using
                Return data
            End If
        End Function

    End Class

End Namespace
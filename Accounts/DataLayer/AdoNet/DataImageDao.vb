Imports System.IO
Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for DataImage
    ' ** DAO Pattern

    Public Class DataImageDao
        Inherits CommonDao
        Implements IDao(Of DataImage)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As DataImage Implements IDao(Of DataImage).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, DataImage" &
                    "   FROM [DataImage]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef DataImage As DataImage) As Integer Implements IDao(Of DataImage).UpdateRecord
            Dim sql As String = "UPDATE [DataImage] SET DataImage = @DataImage WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(DataImage))
        End Function

        Public Function AddRecord(ByRef DataImage As DataImage) As Integer Implements IDao(Of DataImage).AddRecord
            Dim sql As String =
                    " INSERT INTO [DataImage] " &
                    " (DataImage) " &
                    " VALUES (@DataImage) "
            Return Db.Insert(sql, Take(DataImage))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, DataImage) =
                                    Function(reader) _
            New DataImage() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .Image = Extensions.AsImage(reader("Image"))
            }

        Private Function Take(DataImage As DataImage) As Object()
            Return New Object() {
                                    "@Image", ToSqlImage(DataImage.Image)
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
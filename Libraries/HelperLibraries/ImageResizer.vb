Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Windows.Forms

Public Class ImageResizer
    Private ReadOnly _allowedFileSizeInByte As Integer
    Private ReadOnly _sourcePath As String
    Private ReadOnly _destinationPath As String

    Public Sub New(ByVal allowedSize As Integer, ByVal sourcePath As String, ByVal destinationPath As String)
        _allowedFileSizeInByte = allowedSize
        _sourcePath = sourcePath
        _destinationPath = destinationPath
    End Sub

    Public Function ScaleImage() As Boolean
        Dim retValue As Boolean = True
        Using ms As MemoryStream = New MemoryStream()
            Using fs As FileStream = New FileStream(_sourcePath, FileMode.Open)
                Dim bmp As Bitmap = CType(Image.FromStream(fs), Bitmap)
                SaveTemporary(bmp, ms, 100)
                Dim prevSize As Double = ms.Length
                While ms.Length < 0.9 * _allowedFileSizeInByte OrElse ms.Length > _allowedFileSizeInByte
                    Dim scale As Double = Math.Sqrt(CDbl(_allowedFileSizeInByte) / CDbl(ms.Length))
                    ms.SetLength(0)
                    bmp = ScaleImage(bmp, scale)
                    SaveTemporary(bmp, ms, 100)
                    If Math.Abs(prevSize - ms.Length) < 10 Then
                        If (ms.Length / prevSize) > 1.5 Then
                            MessageBox.Show("File too large please limit file size to " + _allowedFileSizeInByte.ToString())
                            retValue = False
                        End If
                        Exit While
                    End If
                    prevSize = ms.Length
                End While
                If bmp IsNot Nothing Then bmp.Dispose()
                SaveImageToFile(ms)
            End Using
        End Using
        Return retValue
    End Function

    Private Sub SaveImageToFile(ByVal ms As MemoryStream)
        Dim data As Byte() = ms.ToArray()
        Using fs As FileStream = New FileStream(_destinationPath, FileMode.Create)
            fs.Write(data, 0, data.Length)
        End Using
    End Sub

    Private Sub SaveTemporary(ByVal bmp As Bitmap, ByVal ms As MemoryStream, ByVal quality As Integer)
        Dim qualityParam As EncoderParameter = New EncoderParameter(Encoder.Quality, quality)
        Dim codec = GetImageCodecInfo()
        Dim encoderParams = New EncoderParameters(1)
        encoderParams.Param(0) = qualityParam
        If codec IsNot Nothing Then
            bmp.Save(ms, codec, encoderParams)
        Else
            bmp.Save(ms, GetImageFormat())
        End If
    End Sub

    Public Function ScaleImage(ByVal image As Bitmap, ByVal scale As Double) As Bitmap
        Dim newWidth As Integer = CInt((image.Width * scale))
        Dim newHeight As Integer = CInt((image.Height * scale))
        Dim result As Bitmap = New Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb)
        result.SetResolution(image.HorizontalResolution, image.VerticalResolution)

        Using g As Graphics = Graphics.FromImage(result)
            g.InterpolationMode = InterpolationMode.HighQualityBicubic
            g.CompositingQuality = CompositingQuality.HighQuality
            g.SmoothingMode = SmoothingMode.HighQuality
            g.PixelOffsetMode = PixelOffsetMode.HighQuality
            g.DrawImage(image, 0, 0, result.Width, result.Height)
        End Using

        Return result
    End Function

    Private Function GetImageCodecInfo() As ImageCodecInfo
        Dim fi As FileInfo = New FileInfo(_sourcePath)

        Select Case fi.Extension
            Case ".bmp"
                Return ImageCodecInfo.GetImageEncoders()(0)
            Case ".jpg", ".jpeg"
                Return ImageCodecInfo.GetImageEncoders()(1)
            Case ".gif"
                Return ImageCodecInfo.GetImageEncoders()(2)
            Case ".tiff"
                Return ImageCodecInfo.GetImageEncoders()(3)
            Case ".png"
                Return ImageCodecInfo.GetImageEncoders()(4)
            Case Else
                Return Nothing
        End Select
    End Function

    Private Function GetImageFormat() As ImageFormat
        Dim fi As FileInfo = New FileInfo(_sourcePath)

        Select Case fi.Extension
            Case ".jpg"
                Return ImageFormat.Jpeg
            Case ".bmp"
                Return ImageFormat.Bmp
            Case ".gif"
                Return ImageFormat.Gif
            Case ".png"
                Return ImageFormat.Png
            Case ".tiff"
                Return ImageFormat.Tiff
            Case Else
                Return ImageFormat.Png
        End Select
    End Function

End Class
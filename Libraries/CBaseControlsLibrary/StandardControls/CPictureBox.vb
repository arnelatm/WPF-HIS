Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class CPictureBox
    Inherits PictureBox
    Implements IEntryControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    <Category("Custom Properties")>
    <DefaultValue(CType(Nothing, String))>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String

    <Category("Custom Properties")>
    <DefaultValue(CType(Nothing, String))>
    <Description("Maximum image size allowed.")>
    <Browsable(True)>
    Public Property MaxImageSize As Int32

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode

    Public Property DisplayOnly As Boolean

    Public Property Translatable As Boolean Implements IEntryControl.Translatable

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown

        If Not DisplayOnly AndAlso EditingMode Then
            If e.Button = MouseButtons.Middle Then
                If Image IsNot Nothing Then
                    _previousImage = Image
                    Image = Nothing
                Else
                    Image = _previousImage
                    _previousImage = Nothing
                End If
            ElseIf e.Button = MouseButtons.Left Then
                Using fd As OpenFileDialog = New OpenFileDialog()
                    fd.Title = $"Open File Dialog"
                    fd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                    fd.Filter = $"Image Files(*.BMP;*.JPG;*.GIF;*.JPEG;*.TIFF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.TIFF;*.PNG"
                    fd.FilterIndex = 1
                    fd.RestoreDirectory = True
                    If fd.ShowDialog() = DialogResult.OK Then
                        Try
                            ReplaceImageFromFile(fd.FileName)
                        Catch ex As Exception When TypeOf ex Is IOException OrElse
                            TypeOf ex Is UnauthorizedAccessException OrElse TypeOf ex Is ArgumentException OrElse
                            TypeOf ex Is ExternalException OrElse TypeOf ex Is OutOfMemoryException OrElse
                            TypeOf ex Is InvalidOperationException
                            MessageBox.Show(MessagingLibrary.Messaging.TranslateCaption("Unable to load the selected image. Please select a valid image within the allowed size."))
                        End Try
                    End If
                End Using
            End If
        End If
    End Sub

    Private _previousImage As Image
    Private _ownedImage As Image

    Private Sub ReplaceImageFromFile(fileName As String)
        Dim replacement = LoadSelectedImage(fileName)
        Try
            Image = replacement
        Catch
            replacement.Dispose()
            Throw
        End Try

        ' Images assigned by a form or shared resource remain owned by that caller.
        Dim oldOwnedImage = _ownedImage
        _ownedImage = replacement
        _previousImage = Nothing
        If oldOwnedImage IsNot Nothing Then oldOwnedImage.Dispose()
    End Sub

    Private Function LoadSelectedImage(fileName As String) As Image
        Dim temporaryPath As String = Nothing
        Try
            Dim imagePath = fileName
            If MaxImageSize > 0 AndAlso New FileInfo(fileName).Length > MaxImageSize Then
                temporaryPath = GlobalFuncNSub.GetTempFileName(Path.GetExtension(fileName))
                Dim resizer As New ImageResizer(MaxImageSize, fileName, temporaryPath)
                If Not resizer.ScaleImage() OrElse New FileInfo(temporaryPath).Length > MaxImageSize Then
                    Throw New InvalidOperationException("The image could not be resized within the allowed size.")
                End If
                imagePath = temporaryPath
            End If

            ' Copy the decoded pixels so the source and temporary files are not locked.
            Using sourceImage = Drawing.Image.FromFile(imagePath)
                Return New Bitmap(sourceImage)
            End Using
        Finally
            If temporaryPath IsNot Nothing Then
                Try
                    File.Delete(temporaryPath)
                Catch ex As IOException
                    Debug.WriteLine("Unable to remove the temporary resized image.")
                Catch ex As UnauthorizedAccessException
                    Debug.WriteLine("Unable to remove the temporary resized image.")
                End Try
            End If
        End Try
    End Function

    Private Sub CPictureBox_Disposed(sender As Object, e As EventArgs) Handles MyBase.Disposed
        _previousImage = Nothing
        If _ownedImage IsNot Nothing Then
            _ownedImage.Dispose()
            _ownedImage = Nothing
        End If
    End Sub

    'Private Sub imgPicture_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDoubleClick, MyBase.MouseDown
    '    If Not DisplayOnly AndAlso EditingMode Then
    '        If Image IsNot Nothing Then
    '            _previousImage = Image
    '            Image = Nothing
    '        Else
    '            Image = _previousImage
    '        End If
    '    End If
    'End Sub

End Class

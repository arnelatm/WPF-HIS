Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
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
                End If
            ElseIf e.Button = MouseButtons.Left Then
                'Dim fd As OpenFileDialog = New OpenFileDialog()
                Dim strFileName As String = Nothing
                Dim oldImage = Image
                Using fd As OpenFileDialog = New OpenFileDialog()
                    fd.Title = $"Open File Dialog"
                    fd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                    fd.Filter = $"Image Files(*.BMP;*.JPG;*.GIF;*.JPEG;*.TIFF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.TIFF;*.PNG"
                    fd.FilterIndex = 1
                    fd.RestoreDirectory = True
                    If fd.ShowDialog() = DialogResult.OK Then
                        strFileName = fd.FileName
                        Me.Image = Drawing.Image.FromFile(strFileName)
                        Dim fileInfo As New FileInfo(strFileName)
                        Dim length As Long = fileInfo.Length
                        If MaxImageSize > 0 Then
                            If fileInfo.Length > MaxImageSize Then
                                Image.Dispose()
                                Image = Nothing
                                Dim fileExtension = fileInfo.Extension
                                Dim path As String = GlobalFuncNSub.GetTempFileName(fileExtension)
                                Dim resizer As ImageResizer = New ImageResizer(MaxImageSize, strFileName, path)
                                If Not resizer.ScaleImage() Then
                                    MessageBox.Show("Cannot scale image to 1 Megabyte size. Either select a smaller file size or resize the image manually to less than or equal to 1 Megabyte.")
                                End If
                                Image = Drawing.Image.FromFile(path)
                            End If
                        End If
                    End If
                End Using
            End If
        End If
    End Sub

    Private _previousImage As Image

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
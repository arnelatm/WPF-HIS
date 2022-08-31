Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Presenters

Public Class CPictureViewer

    Private _debugSwitch As Byte = 0
    Private _displayOnly As Boolean
    Public ImageFileName As String = Nothing


    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(cFileName As String, imageDescription As String, Optional displayOnly As Boolean = True)
        ' This call is required by the designer.
        InitializeComponent()
        lblPictureNote.Text = imageDescription
        ImageFileName = cFileName
        _displayOnly = displayOnly
        If ImageFileName IsNot Nothing Then
            CPictureBox1.Load(ImageFileName)
        End If
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub btnShow_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnShow.ClickButtonArea
        ' Show the Open File dialog. If the user clicks OK, load the
        ' picture that the user chose.
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            CPictureBox1.Load(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub btnClear_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnClear.ClickButtonArea
        ' Clear the picture.
        CPictureBox1.Image = Nothing
        CPictureBox1.ImageLocation = ""
    End Sub

    Private Sub btnCancel_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
        DialogResult = DialogResult.Cancel
    End Sub

    'Private Sub btnBackground_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnBackground.ClickButtonArea
    '    ' Show the color dialog box. If the user clicks OK, change the
    '    ' PictureBox control's background to the color the user chose.
    '    If ColorDialog1.ShowDialog() = DialogResult.OK Then
    '        CPictureBox1.BackColor = ColorDialog1.Color
    '    End If
    'End Sub

    Private Sub btnClose_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnClose.ClickButtonArea
        'Dim docImage As Image
        DialogResult = DialogResult.OK
        ImageFileName = CPictureBox1.ImageLocation()
        'ImageFileName = OpenFileDialog1.FileName
        'Using fd As OpenFileDialog = OpenFileDialog1
        '    'fd.Title = $"Open File Dialog"
        '    'fd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        '    'fd.Filter = $"Image Files(*.BMP;*.JPG;*.GIF;*.JPEG;*.TIFF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.TIFF;*.PNG"
        '    'fd.FilterIndex = 1
        '    'fd.RestoreDirectory = True
        '     ImageFileName = fd.FileName
        'End Using
        '   fd.Title = $"Open File Dialog"
        '   fd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        '   fd.Filter = $"Image Files(*.BMP;*.JPG;*.GIF;*.JPEG;*.TIFF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.TIFF;*.PNG"
        '   fd.FilterIndex = 1
        '    fd.RestoreDirectory = True
        '    If fd.ShowDialog() = DialogResult.OK Then
        '        ImageFileName = fd.FileName
        '        'docImage = Drawing.Image.FromFile(ImageFileName)
        '        'Dim fileInfo As New FileInfo(ImageFileName)
        '        'Dim length As Long = fileInfo.Length
        '        ''If MaxImageSize > 0 Then
        '        ''If fileInfo.Length > MaxImageSize Then
        '        'docImage.Dispose()
        '        'docImage = Nothing
        '        'Dim fileExtension = fileInfo.Extension
        '        'Dim path As String = GlobalFuncNSub.GetTempFileName(fileExtension)
        '        'Dim resizer As ImageResizer = New ImageResizer(MaxImageSize, strFileName, path)
        '        'If Not resizer.ScaleImage() Then
        '        '    MessageBox.Show("Cannot scale image to " & maxImageSize.ToString() & $" bytes size. Either select a smaller file size or resize the image manually to less than or equal to " & MaxImageSize.ToString() & " bytes.")
        '        'End If
        '        'docImage = Drawing.Image.FromFile(path)
        '        'End If
        '        'End If
        '    End If
        'End Using



        Close()
    End Sub

    'Private Sub cCheckBox_Click(sender As Object, e As EventArgs) Handles cCheckBox.Click
    '    cCheckBox.Checked = Not cCheckBox.Checked
    'End Sub

    Private Sub CLabel1_Click(sender As Object, e As EventArgs) Handles CLabel1.Click
        cCheckBox.Checked = Not cCheckBox.Checked
    End Sub

    Private Sub cCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles cCheckBox.CheckedChanged
        If cCheckBox.Checked Then
            CPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Else
            CPictureBox1.SizeMode = PictureBoxSizeMode.Normal
        End If
    End Sub

    Private Sub CPictureViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _displayOnly Then
            btnCancel.Visible = False
            btnClear.Visible = False
            btnShow.Visible = False
        End If
    End Sub
End Class
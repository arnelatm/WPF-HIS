Imports System.Windows.Forms

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

    Private Sub btnClose_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnClose.ClickButtonArea
        DialogResult = DialogResult.OK
        ImageFileName = CPictureBox1.ImageLocation()
        Close()
    End Sub

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
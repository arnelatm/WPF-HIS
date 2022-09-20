Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class CPictureViewer

    Private _debugSwitch As Byte = 0
    Private _displayOnly As Boolean
    Private _origPictureBoxSize As Size
    Private _origViewerSize As Size
    Private _origBtnContWidth As Int16
    Private _origFloStretchWidth As Int16
    Private _origFloButtonWidth As Int16
    Private _origBtnContHeight As Int16
    Public ImageFileName As String = Nothing

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(cFileName As String, imageDescription As String, Optional displayOnly As Boolean = True)
        ' This call is required by the designer.
        InitializeComponent()
        _origPictureBoxSize.Height = PictureBoxImage.Height
        _origPictureBoxSize.Width = PictureBoxImage.Width
        _origViewerSize.Height = Height
        _origViewerSize.Width = Width
        _origBtnContWidth = btnCancel.Width + btnClear.Width + btnClose.Width + btnShow.Width + 6 * 4
        _origFloButtonWidth = floButtons.Width
        _origBtnContHeight = floButtons.Height
        lblPictureNote.Text = imageDescription
        _displayOnly = displayOnly
        If cFileName IsNot Nothing Then
            ResizeViewer(cFileName)
            PictureBoxImage.Load(cFileName)
        End If

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub ResizeViewer(ByVal cFileName As String)
        Dim imageOnFile As Image = Image.FromFile(cFileName)
        Dim adjustedImageSize As Size
        Dim btnWidth As Int16 = btnCancel.Width + btnClear.Width + btnClose.Width + btnShow.Width + 6 * 4
        If imageOnFile.Width >= imageOnFile.Height Then
            adjustedImageSize.Height = _origPictureBoxSize.Width * imageOnFile.Height / imageOnFile.Width
            If adjustedImageSize.Height > _origPictureBoxSize.Height Then
                adjustedImageSize.Height = _origPictureBoxSize.Height
                adjustedImageSize.Width = adjustedImageSize.Height * imageOnFile.Width / imageOnFile.Height
            Else
                adjustedImageSize.Width = _origPictureBoxSize.Width
            End If
        Else
            adjustedImageSize.Height = _origPictureBoxSize.Height
            adjustedImageSize.Width = adjustedImageSize.Height * imageOnFile.Width / imageOnFile.Height
            If adjustedImageSize.Width > _origPictureBoxSize.Width Then
                adjustedImageSize.Width = _origPictureBoxSize.Width
                adjustedImageSize.Height = adjustedImageSize.Width * imageOnFile.Height / imageOnFile.Width
            End If
        End If
        Width = adjustedImageSize.Width + (_origViewerSize.Width - _origPictureBoxSize.Width)
        If Width >= _origViewerSize.Width Then
            Height = adjustedImageSize.Height + (_origViewerSize.Height - _origPictureBoxSize.Height)
        Else
            Height = adjustedImageSize.Height + _origBtnContHeight + 80
        End If
        PictureBoxImage.Height = adjustedImageSize.Height
        PictureBoxImage.Width = adjustedImageSize.Width
        'TableLayoutPanel1.AutoSize = True
        'PictureBoxImage.AutoSize = True
    End Sub

    Public Shared Function ResizeImage(ByVal image As Image,
                                       ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth,
                                       percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function

    Private Sub btnShow_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnShow.ClickButtonArea
        ' Show the Open File dialog. If the user clicks OK, load the
        ' picture that the user chose.
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            'Dim image As Image = Load(OpenFileDialog1.FileName)
            'Dim image As Image = Image.FromFile(OpenFileDialog1.FileName)
            ResizeViewer(OpenFileDialog1.FileName)
            PictureBoxImage.Load(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub AdjustText(lblQueue As Button)
        Dim Fit As Boolean = False
        Dim CurSize As Single
        Dim SizeStep As Single = 1
        Do Until Fit
            CurSize += SizeStep
            Dim Fnt As Font = New Font(lblQueue.Font.Name, CurSize)
            Dim textSize As Size = TextRenderer.MeasureText(lblQueue.Text, Fnt)
            If textSize.Height >= lblQueue.Height Or textSize.Width >= lblQueue.Width Or lblQueue.Height = 0 Or lblQueue.Width = 0 Then
                Fit = True
                If textSize.Width > lblQueue.Width Then
                    CurSize -= SizeStep
                End If
                If textSize.Height > lblQueue.Height Then
                    CurSize -= SizeStep
                End If
            End If
        Loop

        If CurSize >= 0 Then
            lblQueue.Font = New Font(lblQueue.Font.Name, CurSize)
            Application.DoEvents()
        End If
    End Sub

    Private Sub btnClear_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnClear.ClickButtonArea
        ' Clear the picture.
        PictureBoxImage.Image = Nothing
        PictureBoxImage.ImageLocation = ""
        DialogResult = DialogResult.Abort
    End Sub

    Private Sub btnCancel_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnClose_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnClose.ClickButtonArea
        DialogResult = DialogResult.OK
        ImageFileName = PictureBoxImage.ImageLocation()
        Close()
    End Sub

    Private Sub CPictureViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _displayOnly Then
            btnCancel.Visible = False
            btnClear.Visible = False
            btnShow.Visible = False
        End If
    End Sub

End Class
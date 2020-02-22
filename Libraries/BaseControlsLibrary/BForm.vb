Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalResources

Public Class BForm
    Inherits Form

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = SystemColors.Desktop
        BackgroundImage = Images.GreenGradientBackgroundLarge
        BackgroundImageLayout = ImageLayout.Stretch
        KeyPreview = True
    End Sub

    'Public Sub New()
    '    MyBase.New()
    '    BackColor = SystemColors.ControlLight
    'End Sub
End Class
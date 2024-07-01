Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalResources

Public Class FormBase
    Inherits Form

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = SystemColors.Desktop
        BackgroundImage = Images.GreenGradientBackgroundLarge
        'BackgroundImage = Images.Unlock
        BackgroundImageLayout = ImageLayout.Stretch
        Application.EnableVisualStyles()

    End Sub

    'Public Sub New()
    '    MyBase.New()
    '    BackColor = SystemColors.ControlLight
    'End Sub

End Class
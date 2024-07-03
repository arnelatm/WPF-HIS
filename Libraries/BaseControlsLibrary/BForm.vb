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
        'BackgroundImage = Images.Unlock
        BackgroundImageLayout = ImageLayout.Stretch
        Application.EnableVisualStyles()

    End Sub

End Class
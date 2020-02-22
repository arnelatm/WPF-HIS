Imports System.Drawing
Imports System.Windows.Forms

Public Class CTreeView

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        RightToLeft = RightToLeft.Inherit
        SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)

        UpdateStyles()

    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pEvent As PaintEventArgs)

        MyBase.OnPaintBackground(pEvent)

        pEvent.Graphics.DrawImage(My.Resources.GreenGradientBackgroundLarge, New Rectangle(0, 0, ClientSize.Width, ClientSize.Height))

    End Sub


End Class
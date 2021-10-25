
Imports System.Windows.Forms.Design
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

<ToolboxItem(False)> _
Public Class ColorComboBox
    Inherits ComboBox

    Public Event HoverSelect(ByVal sender As Object, ByVal fontcolor As String)

    Private Known_Color() As String = Split("Transparent,Black,DimGray,Gray,DarkGray,Silver,LightGray,Gainsboro," & _
    "WhiteSmoke,White,RosyBrown,IndianRed,Brown,Firebrick,LightCoral,Maroon,DarkRed,Red,Snow,MistyRose," & _
    "Salmon,Tomato,DarkSalmon,Coral,OrangeRed,LightSalmon,Sienna,SeaShell,Chocalate,SaddleBrown,SandyBrown," & _
    "PeachPuff,Peru,Linen,Bisque,DarkOrange,BurlyWood,Tan,AntiqueWhite,NavajoWhite,BlanchedAlmond,PapayaWhip," & _
    "Mocassin,Orange,Wheat,OldLace,FloralWhite,DarkGoldenrod,Cornsilk,Gold,Khaki,LemonChiffon,PaleGoldenrod," & _
    "DarkKhaki,Beige,LightGoldenrodYellow,Olive,Yellow,LightYellow,Ivory,OliveDrab,YellowGreen,DarkOliveGreen," & _
    "GreenYellow,Chartreuse,LawnGreen,DarkSeaGreen,ForestGreen,LimeGreen,PaleGreen,DarkGreen,Green,Lime," & _
    "Honeydew,SeaGreen,MediumSeaGreen,SpringGreen,MintCream,MediumSpringGreen,MediumAquaMarine," & _
    "YellowAquaMarine,Turquoise,LightSeaGreen,MediumTurquoise,DarkSlateGray,PaleTurquoise,Teal,DarkCyan,Aqua," & _
    "Cyan,LightCyan,Azure,DarkTurquoise,CadetBlue,PowderBlue,LightBlue,DeepSkyBlue,SkyBlue,LightSkyBlue," & _
    "SteelBlue,AliceBlue,DodgerBlue,SlateGray,LightSlateGray,LightSteelBlue,CornflowerBlue,RoyalBlue," & _
    "MidnightBlue,Lavender,Navy,DarkBlue,MediumBlue,Blue,GhostWhite,SlateBlue,DarkSlateBlue,MediumSlateBlue," & _
    "MediumPurple,BlueViolet,Indigo,DarkOrchid,DarkViolet,MediumOrchid,Thistle,Plum,Violet,Purple,DarkMagenta," & _
    "Magenta,Fuchsia,Orchid,MediumVioletRed,DeepPink,HotPink,LavenderBlush,PaleVioletRed,Crimson,Pink,LightPink", ",")

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Add your custom paint code here
    End Sub

    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        MyBase.OnHandleCreated(e)
        If Not DesignMode Then LoadColors()
    End Sub

    Public Sub New()
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        AddHandler DrawItem, New DrawItemEventHandler(AddressOf List_DrawItem)

        With Me
            .Items.Clear()
            .DropDownWidth = 150
            .AutoSize = False
            .Width = 100
            .DropDownStyle = ComboBoxStyle.DropDownList
            .DropDownHeight = 250
        End With
    End Sub

    Public Sub LoadColors()
        With Me
            .Items.Clear()
            .Items.AddRange(Known_Color)
        End With

    End Sub

    ' Handle the DrawItem event for an owner-drawn List.
    Private Sub List_DrawItem(ByVal sender As Object, _
        ByVal e As DrawItemEventArgs)

        If e.Index = -1 Then Exit Sub

        Dim CBox As ComboBox = CType(sender, ComboBox)
        Dim itemString As String = CType(CBox.Items(e.Index), String)

        Dim rect As Rectangle
        If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
            e.Graphics.FillRectangle(New SolidBrush(BackColor), e.Bounds)

        ElseIf (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            rect = New Rectangle(e.Bounds.X + 1, e.Bounds.Y, e.Bounds.Width - 3, e.Bounds.Height - 2)
            e.Graphics.FillRectangle(Brushes.Beige, rect)
            e.Graphics.DrawRectangle(Pens.Blue, rect)
            RaiseEvent HoverSelect(Me, itemString)

        Else
            e.Graphics.FillRectangle(New SolidBrush(BackColor), e.Bounds)
        End If

        'Draw a Color Swatch
        Using myBrush As New SolidBrush(Color.FromName(itemString))

            e.Graphics.FillRectangle(myBrush, e.Bounds.X + 3, e.Bounds.Y + 2, 20, e.Bounds.Height - 5)
            e.Graphics.DrawRectangle(Pens.Black, e.Bounds.X + 3, e.Bounds.Y + 2, 19, e.Bounds.Height - 6)

            ' Draw the text in the item.
            e.Graphics.DrawString(itemString, New Font("Microsoft Sans Serif", 8.25), _
                Brushes.Black, e.Bounds.X + 25, e.Bounds.Y + 1)
        End Using
    End Sub
End Class



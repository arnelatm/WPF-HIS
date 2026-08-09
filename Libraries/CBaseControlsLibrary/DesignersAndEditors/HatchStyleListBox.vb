Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

#Region "HatchStyleListBox Custom Control"

<ToolboxItem(False)>
Public Class HatchStyleListBox
    Inherits ListBox

    ' The editor service displaying this control.
    Private m_EditorService As IWindowsFormsEditorService

    Public Sub New(ByVal hatch_style As String,
      ByVal ColorFore As Color,
      ByVal ColorBack As Color,
      ByVal editor_service As IWindowsFormsEditorService)
        MyBase.New()

        m_EditorService = editor_service
        ' Make items for each LineStyles value.
        Me.Items.Clear()
        Dim hatchNames As String() = System.Enum.GetNames(GetType(HatchStyle))
        Array.Sort(hatchNames)
        For Each hs As String In hatchNames
            Me.Items.Add(hs)
        Next
        Me.SelectedIndex = Me.FindStringExact(hatch_style)
        Me.ColorFore = ColorFore
        Me.ColorBack = ColorBack
        Me.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ItemHeight = 21
        Me.Height = 200
        Me.Width = 200
    End Sub

    Private _ColorFore As Color

    Public Property ColorFore() As Color
        Get
            Return _ColorFore
        End Get
        Set(ByVal value As Color)
            _ColorFore = value
        End Set
    End Property

    Private _ColorBack As Color

    Public Property ColorBack() As Color
        Get
            Return _ColorBack
        End Get
        Set(ByVal value As Color)
            _ColorBack = value
        End Set
    End Property

    ' When the user selects an item, close the dropdown.
    Private Sub HatchStyleListBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        If m_EditorService IsNot Nothing Then
            m_EditorService.CloseDropDown()
        End If
    End Sub

    ' Draw a menu item.
    Private Sub HatchStyleListBox_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
        e.DrawBackground()
        If e.Index <> -1 And Me.Items.Count > 0 Then
            Dim g As Graphics = e.Graphics
            Dim sample As Rectangle = e.Bounds
            Dim sampletext As Rectangle = e.Bounds

            sample.Width = 40
            sample.Inflate(0, -3)
            sampletext.Width = sampletext.Width - sample.Width - 2
            sampletext.X = sample.Right + 2

            Dim displayText As String = Me.Items(e.Index).ToString()
            Dim hs As HatchStyle = CType(System.Enum.Parse(GetType(HatchStyle), displayText, True), HatchStyle)
            Using hb As New HatchBrush(hs, ColorFore, ColorBack),
                sf As New StringFormat With {
                    .Alignment = StringAlignment.Near,
                    .LineAlignment = StringAlignment.Center,
                    .FormatFlags = StringFormatFlags.NoWrap
                }, borderPen As New Pen(Color.Black, 1)
                If (e.State And DrawItemState.Focus) = 0 Then
                    Using backgroundBrush As New SolidBrush(SystemColors.Window),
                        textBrush As New SolidBrush(SystemColors.WindowText)
                        g.FillRectangle(backgroundBrush, sampletext)
                        g.DrawString(displayText, Me.Font, textBrush, sampletext, sf)
                    End Using
                Else
                    Using backgroundBrush As New SolidBrush(SystemColors.Highlight),
                        textBrush As New SolidBrush(SystemColors.HighlightText)
                        g.FillRectangle(backgroundBrush, sampletext)
                        g.DrawString(displayText, Me.Font, textBrush, sampletext, sf)
                    End Using
                End If
                g.FillRectangle(hb, sample)
                g.DrawRectangle(borderPen, sample)
            End Using
        End If
        e.DrawFocusRectangle()

    End Sub

End Class

#End Region 'HatchStyleListBox Custom Control

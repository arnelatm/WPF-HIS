Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design.Behavior

Public Class ChooseGlyph
    Inherits Glyph

#Region "Declarations"

    Private relatedControl As CButton
    Private behaviorSvc As System.Windows.Forms.Design.Behavior.BehaviorService
    Private selectionSvc As ISelectionService = Nothing
    Private relatedDesigner As IDesigner = Nothing
    Private ChooseAdorner As Adorner
    Private selectBox As Rectangle
    Private padBox As Rectangle
    Private cornBox As Rectangle
    Private focalPtBox As Rectangle
    Private boxFillColor As Brush = New SolidBrush(Color.FromArgb(120, Color.White))

    Enum eChooseWhat
        Pad
        Corner
        FocalPt
        None
    End Enum

    Public Property chooseWhat As eChooseWhat = eChooseWhat.None
    Public Property sendWhat As eChooseWhat = eChooseWhat.None

#End Region

#Region "New"

    Public Sub New(
                   ByVal behaviorService As System.Windows.Forms.Design.Behavior.BehaviorService,
                   ByVal control As CButton,
                   ByVal selectionService As ISelectionService,
                   ByVal relatedDesigner As IDesigner,
                   ByVal myAdorner As Adorner)

        MyBase.New(New CornBehavior(relatedDesigner))
        ' Cache references for convenience.
        behaviorSvc = behaviorService
        selectionSvc = selectionService
        Me.relatedDesigner = relatedDesigner
        ChooseAdorner = myAdorner

        ' Cache a reference to the control being designed.
        relatedControl = CType(Me.relatedDesigner.Component, CButton)

        ' Hook the SelectionChanged event.
        AddHandler selectionSvc.SelectionChanged, AddressOf selectionService_SelectionChanged

        AddHandler relatedControl.Move, AddressOf relatedControl_Move
        AddHandler relatedControl.Resize, AddressOf relatedControl_Resize

    End Sub

#End Region

#Region "Events"

    Private Sub relatedControl_Move(ByVal sender As Object, ByVal e As EventArgs)

        If Object.ReferenceEquals(selectionSvc.PrimarySelection, relatedControl) Then
            SetBoxes()
            ChooseAdorner.Invalidate()
        End If

    End Sub

    Private Sub relatedControl_Resize(
                                      ByVal sender As Object,
                                      ByVal e As EventArgs)
        If Object.ReferenceEquals(selectionSvc.PrimarySelection, relatedControl) Then
            SetBoxes()
            ChooseAdorner.Invalidate()
        End If
    End Sub

    Private Sub selectionService_SelectionChanged(
                                                  ByVal sender As Object,
                                                  ByVal e As EventArgs)

        If relatedControl.GetType = GetType(CButton) Then

            If Object.ReferenceEquals(selectionSvc.PrimarySelection, relatedControl) Then
                SetBoxes()
                ChooseAdorner.Enabled = True
                relatedControl.DesignerSelected = True
            Else
                If relatedControl.DesignerSelected Then
                    ChooseAdorner.Enabled = False
                    relatedControl.DesignerSelected = False
                End If
            End If

        End If
        chooseWhat = eChooseWhat.None

    End Sub

#End Region

#Region "Overrides"

    Public Overrides Function GetHitTest(ByVal p As Point) As Cursor

        If Object.ReferenceEquals(selectionSvc.PrimarySelection, relatedControl) Then
            If padBox.Contains(p) Then
                sendWhat = eChooseWhat.Pad
                Return Cursors.Hand
            ElseIf cornBox.Contains(p) Then
                sendWhat = eChooseWhat.Corner
                Return Cursors.Hand
            ElseIf focalPtBox.Contains(p) Then
                sendWhat = eChooseWhat.FocalPt
                Return Cursors.Hand
            ElseIf selectBox.Contains(p) Then
                sendWhat = eChooseWhat.None
                Return Cursors.Arrow
            Else
                Return Nothing
            End If
        End If

        Return Nothing

    End Function

    Public Overrides ReadOnly Property Bounds() As Rectangle
        Get
            Return selectBox
        End Get

    End Property

    Public Overrides Sub Paint(ByVal pe As PaintEventArgs)
        If Object.ReferenceEquals(selectionSvc.PrimarySelection, relatedControl) Then
            Using pn As New Pen(Brushes.DarkGray, 1) With {.DashStyle = Drawing2D.DashStyle.Solid}
                Dim fnt As Font = New Font("Arial", 8)
                Dim sf As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                pe.Graphics.FillRectangle(boxFillColor, selectBox)
                pe.Graphics.DrawRectangle(pn, selectBox)
                pn.DashStyle = Drawing2D.DashStyle.Dot
                pe.Graphics.DrawRectangle(pn, padBox)
                pe.Graphics.DrawRectangle(pn, cornBox)
                pe.Graphics.DrawRectangle(pn, focalPtBox)
                padBox.Offset(1, 1)
                cornBox.Offset(1, 1)
                focalPtBox.Offset(1, 1)
                pe.Graphics.DrawString("P", fnt, Brushes.Black, padBox, sf)
                pe.Graphics.DrawString("C", fnt, Brushes.Black, cornBox, sf)
                pe.Graphics.DrawString("F", fnt, Brushes.Black, focalPtBox, sf)
                padBox.Offset(-1, -1)
                cornBox.Offset(-1, -1)
                focalPtBox.Offset(-1, -1)
            End Using
        End If

    End Sub

#End Region

#Region "Methods"

    Private Sub SetBoxes()
        Dim edge As Point = behaviorSvc.ControlToAdornerWindow(relatedControl)
        If relatedControl.Height < 40 Then

            selectBox = New Rectangle(edge.X + relatedControl.Width + 5, edge.Y + relatedControl.Height \ 2 - 8, 42, 16)
            padBox = New Rectangle(edge.X + relatedControl.Width + 8, edge.Y + relatedControl.Height \ 2 - 5, 10, 10)
            cornBox = New Rectangle(edge.X + relatedControl.Width + 21, edge.Y + relatedControl.Height \ 2 - 5, 10, 10)
            focalPtBox = New Rectangle(edge.X + relatedControl.Width + 34, edge.Y + relatedControl.Height \ 2 - 5, 10, 10)
        Else

            selectBox = New Rectangle(edge.X + relatedControl.Width + 5, edge.Y, 16, 42)
            padBox = New Rectangle(edge.X + relatedControl.Width + 8, edge.Y + 3, 10, 10)
            cornBox = New Rectangle(edge.X + relatedControl.Width + 8, edge.Y + 16, 10, 10)
            focalPtBox = New Rectangle(edge.X + relatedControl.Width + 8, edge.Y + 29, 10, 10)

        End If

    End Sub

#End Region

    Class CornBehavior
        Inherits Behavior

#Region "Declarations"

        Private relatedDesigner As IDesigner = Nothing
        Private relatedControl As CButton = Nothing

#End Region

#Region "New"

        Friend Sub New(ByVal relatedDesigner As IDesigner)
            Me.relatedDesigner = relatedDesigner
            relatedControl = CType(relatedDesigner.Component, CButton)
        End Sub

#End Region

#Region "Overrides"

        Public Overrides Function OnMouseDown(g As Glyph, button As MouseButtons, mouseLoc As Point) As Boolean
            Dim pGlyph As ChooseGlyph = DirectCast(g, ChooseGlyph)
            pGlyph.chooseWhat = pGlyph.sendWhat

            Select Case pGlyph.chooseWhat
                Case eChooseWhat.Pad
                    DirectCast(relatedDesigner, CButtonDesigner).PadAdorner.Invalidate()

                Case eChooseWhat.Corner
                    DirectCast(relatedDesigner, CButtonDesigner).CornAdorner.Invalidate()

                Case eChooseWhat.FocalPt
                    DirectCast(relatedDesigner, CButtonDesigner).FocalPtAdorner.Invalidate()

            End Select
            Return True
        End Function

#End Region

    End Class

End Class
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports System.Windows.Forms.Design.Behavior

#Region "CButtonDesigner"

Public Class CButtonDesigner
    Inherits ControlDesigner
    Public PadAdorner As Adorner = Nothing
    Public CornAdorner As Adorner = Nothing
    Public FocalPtAdorner As Adorner = Nothing
    Public ChooseAdorner As Adorner = Nothing

    Private selectionSvc As ISelectionService = Nothing
    Private behaviorSvc As BehaviorService = Nothing

    Private _CButton As CButton
    Private _Lists As DesignerActionListCollection

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (Me.behaviorSvc IsNot Nothing) Then
                ' Remove the adorners added by this designer from
                ' the BehaviorService.Adorners collection.
                Me.behaviorSvc.Adorners.Remove(Me.PadAdorner)
                Me.behaviorSvc.Adorners.Remove(Me.CornAdorner)
                Me.behaviorSvc.Adorners.Remove(Me.FocalPtAdorner)
                Me.behaviorSvc.Adorners.Remove(Me.ChooseAdorner)
            End If
        End If

        MyBase.Dispose(disposing)

    End Sub

    Public Overrides Sub Initialize(ByVal component As IComponent)
        MyBase.Initialize(component)

        InitializeServices()
        InitializePadAdorner()
        InitializeCornerAdorner()
        InitializeFocalPtAdorner()
        InitializeChooseAdorner()

        ' Get CButton control reference
        _CButton = CType(component, CButton)

    End Sub

#Region "Init Methods"

    ' This utility method connects the designer to various services.
    ' These references are cached for convenience.
    Private Sub InitializeServices()

        ' Acquire a reference to ISelectionService.
        Me.selectionSvc = CType(GetService(GetType(ISelectionService)), ISelectionService)

        ' Acquire a reference to BehaviorService.
        Me.behaviorSvc = CType(GetService(GetType(BehaviorService)), Windows.Forms.Design.Behavior.BehaviorService)

    End Sub

    Private Sub InitializePadAdorner()

        If (Not (PadAdorner) Is Nothing) Then
            PadAdorner.Glyphs.Clear()
        Else
            PadAdorner = New Adorner()
            behaviorSvc.Adorners.Add(PadAdorner)
            PadAdorner.Glyphs.Add(New PadGlyph(behaviorSvc, CType(Control, CButton), selectionSvc, Me, PadAdorner, PadGlyph.eAdjWhat.Button))
            PadAdorner.Glyphs.Add(New PadGlyph(behaviorSvc, CType(Control, CButton), selectionSvc, Me, PadAdorner, PadGlyph.eAdjWhat.Text))
        End If
    End Sub

    Private Sub InitializeCornerAdorner()

        If (Not (CornAdorner) Is Nothing) Then
            CornAdorner.Glyphs.Clear()
        Else
            CornAdorner = New Adorner()
            behaviorSvc.Adorners.Add(CornAdorner)
            CornAdorner.Glyphs.Add(New CornerGlyph(behaviorSvc, CType(Control, CButton), selectionSvc, Me, CornAdorner, CornerGlyph.eCorner.All))
            CornAdorner.Glyphs.Add(New CornerGlyph(behaviorSvc, CType(Control, CButton), selectionSvc, Me, CornAdorner, CornerGlyph.eCorner.UpperLeft))
            CornAdorner.Glyphs.Add(New CornerGlyph(behaviorSvc, CType(Control, CButton), selectionSvc, Me, CornAdorner, CornerGlyph.eCorner.UpperRight))
            CornAdorner.Glyphs.Add(New CornerGlyph(behaviorSvc, CType(Control, CButton), selectionSvc, Me, CornAdorner, CornerGlyph.eCorner.LowerLeft))
            CornAdorner.Glyphs.Add(New CornerGlyph(behaviorSvc, CType(Control, CButton), selectionSvc, Me, CornAdorner, CornerGlyph.eCorner.LowerRight))
        End If
    End Sub

    Private Sub InitializeFocalPtAdorner()

        If (Not (FocalPtAdorner) Is Nothing) Then
            FocalPtAdorner.Glyphs.Clear()
        Else
            FocalPtAdorner = New Adorner()
            behaviorSvc.Adorners.Add(FocalPtAdorner)
            FocalPtAdorner.Glyphs.Add(New FocalPtGlyph(behaviorSvc, CType(Control, CButton), selectionSvc, Me, FocalPtAdorner, FocalPtGlyph.eAdjWhat.FocalScale))
            FocalPtAdorner.Glyphs.Add(New FocalPtGlyph(behaviorSvc, CType(Control, CButton), selectionSvc, Me, FocalPtAdorner, FocalPtGlyph.eAdjWhat.Center))
        End If
    End Sub

    Private Sub InitializeChooseAdorner()

        If (Not (ChooseAdorner) Is Nothing) Then
            ChooseAdorner.Glyphs.Clear()
        Else
            ChooseAdorner = New Adorner()
            behaviorSvc.Adorners.Add(ChooseAdorner)
            ChooseAdorner.Glyphs.Add(New ChooseGlyph(behaviorSvc, CType(Control, CButton), selectionSvc, Me, ChooseAdorner))
        End If

    End Sub

#End Region

#Region "ActionLists"

    Public Overrides ReadOnly Property ActionLists() As DesignerActionListCollection
        Get
            If _Lists Is Nothing Then
                _Lists = New DesignerActionListCollection
                _Lists.Add(New CButtonActionList(Component))
            End If
            Return _Lists
        End Get
    End Property

#End Region 'ActionLists

End Class

#End Region    'CButtonDesigner
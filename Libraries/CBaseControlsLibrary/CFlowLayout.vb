Imports System.ComponentModel
Imports System.Windows.Forms

Public Class CFlowLayout
    Inherits FlowLayoutPanel

    Private _autoMirrorFlow As Boolean = True
    Private _reverseChildrenWhenRtl As Boolean = False
    Private _lastEffectiveRtl As RightToLeft = RightToLeft.Inherit
    Private _parentHooked As Boolean

    <Category("Layout"),
     Description("Automatically mirror using RightToLeft. Leave FlowDirection = LeftToRight for horizontal RTL."),
     DefaultValue(True)>
    Public Property AutoMirrorFlow As Boolean
        Get
            Return _autoMirrorFlow
        End Get
        Set(value As Boolean)
            If _autoMirrorFlow <> value Then
                _autoMirrorFlow = value
                ApplyRtlFlow()
            End If
        End Set
    End Property

    <Category("Layout"),
     Description("Reverse the Controls collection order when switching between LTR and RTL."),
     DefaultValue(False)>
    Public Property ReverseChildrenWhenRtl As Boolean
        Get
            Return _reverseChildrenWhenRtl
        End Get
        Set(value As Boolean)
            If _reverseChildrenWhenRtl <> value Then
                _reverseChildrenWhenRtl = value
                ApplyRtlFlow()
            End If
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        RightToLeft = RightToLeft.Inherit
        DoubleBuffered = True
        BackColor = Drawing.Color.Transparent
    End Sub

    Public Sub RefreshRtl()
        ApplyRtlFlow()
    End Sub

    Protected Overrides Sub OnRightToLeftChanged(e As EventArgs)
        MyBase.OnRightToLeftChanged(e)
        ApplyRtlFlow()
    End Sub

    Protected Overrides Sub OnParentChanged(e As EventArgs)
        MyBase.OnParentChanged(e)
        HookParentRtlChange()
        ApplyRtlFlow()
    End Sub

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)
        HookParentRtlChange()
        ApplyRtlFlow()
    End Sub

    Private Sub HookParentRtlChange()
        If _parentHooked Then Return
        Dim f = FindForm()
        If f IsNot Nothing Then
            AddHandler f.RightToLeftChanged, AddressOf Parent_RightToLeftChanged
            _parentHooked = True
        End If
    End Sub

    Private Sub Parent_RightToLeftChanged(sender As Object, e As EventArgs)
        ApplyRtlFlow()
    End Sub

    Private Sub ApplyRtlFlow()
        If Not _autoMirrorFlow Then Return
        If Not IsHandleCreated Then Return

        Dim effective = ResolveEffectiveRtl(Me)
        If effective = RightToLeft.Inherit Then effective = RightToLeft.No

        ' For horizontal layouts: enforce FlowDirection = LeftToRight; RightToLeft flag gives mirroring.
        If FlowDirection = FlowDirection.LeftToRight Or FlowDirection = FlowDirection.RightToLeft Then
            If effective = RightToLeft.Yes AndAlso FlowDirection <> FlowDirection.LeftToRight Then
                FlowDirection = FlowDirection.LeftToRight
            End If
        End If

        ' Reverse children only when toggling between RTL states if requested.
        If _reverseChildrenWhenRtl AndAlso effective <> _lastEffectiveRtl Then
            ReverseChildren()
        End If

        _lastEffectiveRtl = effective

        SuspendLayout()
        ResumeLayout(performLayout:=True)
        PerformLayout()
    End Sub

    Private Sub ReverseChildren()
        If Controls.Count < 2 Then Return
        Dim list = Controls.Cast(Of Control).ToList()
        SuspendLayout()
        Controls.Clear()
        For Each c In list.AsEnumerable().Reverse()
            Controls.Add(c)
        Next
        ResumeLayout()
    End Sub

    Private Function ResolveEffectiveRtl(ctrl As Control) As RightToLeft
        Dim c As Control = ctrl
        While c IsNot Nothing
            If c.RightToLeft <> RightToLeft.Inherit Then
                Return c.RightToLeft
            End If
            c = c.Parent
        End While
        Return RightToLeft.No
    End Function
End Class
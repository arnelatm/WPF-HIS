Imports System.ComponentModel
Imports System.Windows.Forms

Public Class CFlowLayout
    Inherits FlowLayoutPanel

    Private _autoMirrorFlow As Boolean = True
    Private _parentHooked As Boolean

    <Category("Layout"),
     Description("Automatically set FlowDirection to RightToLeft when effective RTL is Yes."),
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

    Public Sub New()
        MyBase.New()
        RightToLeft = RightToLeft.Inherit
        BackColor = Drawing.Color.Transparent
        DoubleBuffered = True
    End Sub

    ' Public helper so external code (e.g., after language switch) can force recalculation.
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
        Dim f = Me.FindForm()
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
        Dim effective = ResolveEffectiveRtl(Me)
        Dim desired = If(effective = RightToLeft.Yes,
                         FlowDirection.RightToLeft,
                         FlowDirection.LeftToRight)
        If FlowDirection <> desired Then
            SuspendLayout()
            FlowDirection = desired
            ResumeLayout(performLayout:=True)
        End If
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
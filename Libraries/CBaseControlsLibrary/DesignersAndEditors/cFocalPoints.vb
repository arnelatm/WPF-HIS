Imports System.ComponentModel
Imports System.Drawing

<TypeConverter(GetType(FocalPointsConverter))>
Public Class cFocalPoints

    Private _CenterPtX As Single = 0.5

    <RefreshProperties(RefreshProperties.Repaint)>
    <NotifyParentProperty(True)>
    <DefaultValue(CSng(0.5))>
    Public Property CenterPtX() As Single
        Get
            Return _CenterPtX
        End Get
        Set(ByVal value As Single)
            If value < 0 Then value = 0
            If value > 1 Then value = 1
            _CenterPtX = value
        End Set
    End Property

    Private _CenterPtY As Single = 0.5

    <RefreshProperties(RefreshProperties.Repaint)>
    <NotifyParentProperty(True)>
    <DefaultValue(CSng(0.5))>
    Public Property CenterPtY() As Single
        Get
            Return _CenterPtY
        End Get
        Set(ByVal value As Single)
            If value < 0 Then value = 0
            If value > 1 Then value = 1
            _CenterPtY = value
        End Set
    End Property

    Private _FocusPtX As Single = 0

    <RefreshProperties(RefreshProperties.Repaint)>
    <NotifyParentProperty(True)>
    <DefaultValue(CSng(0))>
    Public Property FocusPtX() As Single
        Get
            Return _FocusPtX
        End Get
        Set(ByVal value As Single)
            If value < 0 Then value = 0
            If value > 1 Then value = 1
            _FocusPtX = value
        End Set
    End Property

    Private _FocusPtY As Single = 0

    <RefreshProperties(RefreshProperties.Repaint)>
    <NotifyParentProperty(True)>
    <DefaultValue(CSng(0))>
    Public Property FocusPtY() As Single
        Get
            Return _FocusPtY
        End Get
        Set(ByVal value As Single)
            If value < 0 Then value = 0
            If value > 1 Then value = 1
            _FocusPtY = value
        End Set
    End Property

    Public Function CenterPoint() As PointF
        Return New PointF(CenterPtX, CenterPtY)
    End Function

    Public Function FocusScales() As PointF
        Return New PointF(FocusPtX, FocusPtY)
    End Function

    Public Sub SetCenterPoint(centerPoint As PointF)
        CenterPtX = centerPoint.X
        CenterPtY = centerPoint.Y
    End Sub

    Public Sub SetFocusScales(focusScale As PointF)
        FocusPtX = focusScale.X
        FocusPtY = focusScale.Y
    End Sub

    Sub New()
        CenterPtX = 0.5
        CenterPtY = 0.5
        FocusPtX = 0
        FocusPtY = 0
    End Sub

    Sub New(ByVal Cx As Single, ByVal Cy As Single, ByVal Fx As Single, ByVal Fy As Single)
        CenterPtX = Cx
        CenterPtY = Cy
        FocusPtX = Fx
        FocusPtY = Fy
    End Sub

    Sub New(ByVal ptC As PointF, ByVal ptF As PointF)
        CenterPtX = ptC.X
        CenterPtY = ptC.Y
        FocusPtX = ptF.X
        FocusPtY = ptF.Y
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("{0}, {1}, {2}, {3}", _CenterPtX, _CenterPtY, _FocusPtX, _FocusPtY)
    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        Dim eObj As cFocalPoints = CType(obj, cFocalPoints)

        Return CenterPtX = eObj.CenterPtX _
               AndAlso CenterPtY = eObj.CenterPtY _
               AndAlso FocusPtX = eObj.FocusPtX _
               AndAlso FocusPtY = eObj.FocusPtY

    End Function

End Class
Imports System.ComponentModel

<TypeConverter(GetType(CornerConverter))>
Public Class CornersProperty

    Private _All As Int32 = -1
    Private _UpperLeft As Int32 = 0
    Private _UpperRight As Int32 = 0
    Private _LowerLeft As Int32 = 0
    Private _LowerRight As Int32 = 0

    Public Sub New(ByVal LowerLeft As Int32, ByVal LowerRight As Int32,
                   ByVal UpperLeft As Int32, ByVal UpperRight As Int32)
        Me.LowerLeft = LowerLeft
        Me.LowerRight = LowerRight
        Me.UpperLeft = UpperLeft
        Me.UpperRight = UpperRight
    End Sub

    Public Sub New(ByVal All As Int32)
        Me.All = All
    End Sub

    Public Sub New()
        LowerLeft = 0
        LowerRight = 0
        UpperLeft = 0
        UpperRight = 0
    End Sub

    Private Sub CheckForAll(ByVal val As Int32)
        If val = LowerLeft AndAlso
           val = LowerRight AndAlso
           val = UpperLeft AndAlso
           val = UpperRight Then
            If _All <> val Then _All = val
        Else
            If All <> -1 Then All = -1
        End If
    End Sub

    <DescriptionAttribute("Set the Radius of the All four Corners the same")>
    <RefreshProperties(RefreshProperties.Repaint)>
    <NotifyParentProperty(True)>
    <DefaultValue(-1)>
    Public Property All() As Int32
        Get
            Return _All
        End Get
        Set(ByVal Value As Int32)
            _All = Value
            If Value > -1 Then
                _LowerLeft = Value
                _LowerRight = Value
                _UpperLeft = Value
                _UpperRight = Value
            End If
        End Set

    End Property

    <DescriptionAttribute("Set the Radius of the Upper Left Corner")>
    <RefreshProperties(RefreshProperties.Repaint)>
    <NotifyParentProperty(True)>
    <DefaultValue(0)>
    Public Property UpperLeft() As Int32
        Get
            Return _UpperLeft
        End Get
        Set(ByVal Value As Int32)
            _UpperLeft = Value

            CheckForAll(Value)
        End Set
    End Property

    <DescriptionAttribute("Set the Radius of the Upper Right Corner")>
    <RefreshProperties(RefreshProperties.Repaint)>
    <NotifyParentProperty(True)>
    <DefaultValue(0)>
    Public Property UpperRight() As Int32
        Get
            Return _UpperRight
        End Get
        Set(ByVal Value As Int32)
            _UpperRight = Value
            CheckForAll(Value)
        End Set
    End Property

    <DescriptionAttribute("Set the Radius of the Lower Left Corner")>
    <RefreshProperties(RefreshProperties.Repaint)>
    <NotifyParentProperty(True)>
    <DefaultValue(0)>
    Public Property LowerLeft() As Int32
        Get
            Return _LowerLeft
        End Get
        Set(ByVal Value As Int32)
            _LowerLeft = Value
            CheckForAll(Value)
        End Set
    End Property

    <DescriptionAttribute("Set the Radius of the Lower Right Corner")>
    <RefreshProperties(RefreshProperties.Repaint)>
    <NotifyParentProperty(True)>
    <DefaultValue(0)>
    Public Property LowerRight() As Int32
        Get
            Return _LowerRight
        End Get
        Set(ByVal Value As Int32)
            _LowerRight = Value
            CheckForAll(Value)
        End Set
    End Property

    Public Overrides Function Equals(ByVal obj As Object) As Boolean

        Dim eObj As CornersProperty = CType(obj, CornersProperty)

        Return All = eObj.All _
               AndAlso LowerLeft = eObj.LowerLeft _
               AndAlso LowerRight = eObj.LowerRight _
               AndAlso UpperLeft = eObj.UpperLeft _
               AndAlso UpperRight = eObj.UpperRight

    End Function

End Class
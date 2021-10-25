Imports System.ComponentModel

<TypeConverter(GetType(TimeColorConverter))> _
Public Class TimeColors

    Public Sub New()

    End Sub

    Public Sub New(ByVal FrameOuter As Color, ByVal FrameInner As Color, ByVal FaceOuter As Color, ByVal FaceInner As Color, ByVal Box As Color, ByVal HourNums As Color, ByVal HourHand As Color, ByVal MinuteNums As Color, ByVal MinuteHand As Color, ByVal MinutePlus As Color, ByVal TimeAMPM_ON As Color, ByVal TimeAMPM_OFF As Color, ByVal DisplayTime As Color, ByVal BackGround As Color)

        Me.FrameOuter = FrameOuter
        Me.FrameInner = FrameInner
        Me.FaceOuter = FaceOuter
        Me.FaceInner = FaceInner
        Me.Box = Box
        Me.Hour = HourNums
        Me.HourHand = HourHand
        Me.Minute = MinuteNums
        Me.MinuteHand = MinuteHand
        Me.MinutePlus = MinutePlus
        Me.TimeAMPM_ON = TimeAMPM_ON
        Me.TimeAMPM_OFF = TimeAMPM_OFF
        Me.DisplayTime = DisplayTime
        Me.BackGround = BackGround
    End Sub

    Public Sub New(ByVal FrameOuter As String, ByVal FrameInner As String, ByVal FaceOuter As String, ByVal FaceInner As String, ByVal Box As String, ByVal HourNums As String, ByVal HourHand As String, ByVal MinuteNums As String, ByVal MinuteHand As String, ByVal MinutePlus As String, ByVal TimeAMPM_ON As String, ByVal TimeAMPM_OFF As String, ByVal DisplayTime As String, ByVal BackGround As String)

        Me.FrameOuter = Color.FromName(FrameOuter)
        Me.FrameInner = Color.FromName(FrameInner)
        Me.FaceOuter = Color.FromName(FaceOuter)
        Me.FaceInner = Color.FromName(FaceInner)
        Me.Box = Color.FromName(Box)
        Me.Hour = Color.FromName(HourNums)
        Me.HourHand = Color.FromName(HourHand)
        Me.Minute = Color.FromName(MinuteNums)
        Me.MinuteHand = Color.FromName(MinuteHand)
        Me.MinutePlus = Color.FromName(MinutePlus)
        Me.TimeAMPM_ON = Color.FromName(TimeAMPM_ON)
        Me.TimeAMPM_OFF = Color.FromName(TimeAMPM_OFF)
        Me.DisplayTime = Color.FromName(DisplayTime)
        Me.BackGround = Color.FromName(BackGround)
    End Sub

    Private _FrameOuter As Color = Color.CornflowerBlue
    <Category("Appearance Color")> _
    <Description("Get or Set Outer Color of the frames")> _
    Public Property FrameOuter() As Color
        Get
            Return _FrameOuter
        End Get
        Set(ByVal value As Color)
            _FrameOuter = value
        End Set
    End Property

    Private _FrameInner As Color = Color.AliceBlue
    <Category("Appearance Color")> _
   <Description("Get or Set Inner Color of the frames")> _
    Public Property FrameInner() As Color
        Get
            Return _FrameInner
        End Get
        Set(ByVal value As Color)
            _FrameInner = value
        End Set
    End Property

    Private _FaceOuter As Color = Color.LightGoldenrodYellow
    <Category("Appearance Color")> _
    <Description("Get or Set Outer Color of the Clock Face")> _
    Public Property FaceOuter() As Color
        Get
            Return _FaceOuter
        End Get
        Set(ByVal value As Color)
            _FaceOuter = value
        End Set
    End Property

    Private _FaceInner As Color = Color.White
    <Category("Appearance Color")> _
    <Description("Get or Set Inner Color of the Clock Face")> _
    Public Property FaceInner() As Color
        Get
            Return _FaceInner
        End Get
        Set(ByVal value As Color)
            _FaceInner = value
        End Set
    End Property

    Private _Box As Color = Color.White
    <Category("Appearance Color")> _
    <Description("Get or Set Inner Color of the frames")> _
    Public Property Box() As Color
        Get
            Return _Box
        End Get
        Set(ByVal value As Color)
            _Box = value
        End Set
    End Property

    Private _Hour As Color = Color.DarkBlue
    <Category("Appearance Color")> _
    <Description("Get or Set Color of the Hour Numbers")> _
    Public Property Hour() As Color
        Get
            Return _Hour
        End Get
        Set(ByVal value As Color)
            _Hour = value
        End Set
    End Property

    Private _HourHand As Color = Color.DarkBlue
    <Category("Appearance Color")> _
    <Description("Get or Set Color of the Hour Hand")> _
    Public Property HourHand() As Color
        Get
            Return _HourHand
        End Get
        Set(ByVal value As Color)
            _HourHand = value
        End Set
    End Property

    Private _Minute As Color = Color.Blue
    <Category("Appearance Color")> _
    <Description("Get or Set Color of the Minute Numbers")> _
    Public Property Minute() As Color
        Get
            Return _Minute
        End Get
        Set(ByVal value As Color)
            _Minute = value
        End Set
    End Property

    Private _MinutePlus As Color = Color.LightSlateGray
    <Category("Appearance Color")> _
    <Description("Get or Set Color of the Minute Plus Numbers")> _
    Public Property MinutePlus() As Color
        Get
            Return _MinutePlus
        End Get
        Set(ByVal value As Color)
            _MinutePlus = value
        End Set
    End Property

    Private _MinuteHand As Color = Color.OrangeRed
    <Category("Appearance Color")> _
    <Description("Get or Set Color of the Minute Hand")> _
    Public Property MinuteHand() As Color
        Get
            Return _MinuteHand
        End Get
        Set(ByVal value As Color)
            _MinuteHand = value
        End Set
    End Property

    Private _TimeAMPM_ON As Color = Color.MediumBlue
    <Category("Appearance Color")> _
    <Description("Get or Set Color of the selected AM-PM")> _
    Public Property TimeAMPM_ON() As Color
        Get
            Return _TimeAMPM_ON
        End Get
        Set(ByVal value As Color)
            _TimeAMPM_ON = value
        End Set
    End Property

    Private _TimeAMPM_OFF As Color = Color.LightSteelBlue
    <Category("Appearance Color")> _
   <Description("Get or Set Color of the un-selected AM-PM")> _
    Public Property TimeAMPM_OFF() As Color
        Get
            Return _TimeAMPM_OFF
        End Get
        Set(ByVal value As Color)
            _TimeAMPM_OFF = value
        End Set
    End Property

    Private _DisplayTime As Color = Color.Red
    <Category("Appearance Color")> _
   <Description("Get or Set Color of the Display Time")> _
    Public Property DisplayTime() As Color
        Get
            Return _DisplayTime
        End Get
        Set(ByVal value As Color)
            _DisplayTime = value
        End Set
    End Property

    Private _BackGround As Color = Color.White
    <Category("Appearance Color")> _
   <Description("Get or Set Color of the Display Time")> _
    Public Property BackGround() As Color
        Get
            Return _BackGround
        End Get
        Set(ByVal value As Color)
            _BackGround = value
        End Set
    End Property

End Class

#Region "TimeColorConverter"

Friend Class TimeColorConverter : Inherits ExpandableObjectConverter

    Public Overrides Function GetCreateInstanceSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function

    Public Overrides Function CreateInstance( _
      ByVal context As System.ComponentModel.ITypeDescriptorContext, _
      ByVal propertyValues As System.Collections.IDictionary) As Object

        Dim NewTC As New TimeColors
        With NewTC
            .FrameOuter = CType(propertyValues("FrameOuter"), Color)
            .FrameInner = CType(propertyValues("FrameInner"), Color)
            .FaceOuter = CType(propertyValues("FaceOuter"), Color)
            .FaceInner = CType(propertyValues("FaceInner"), Color)
            .Box = CType(propertyValues("Box"), Color)
            .Hour = CType(propertyValues("Hour"), Color)
            .HourHand = CType(propertyValues("HourHand"), Color)
            .Minute = CType(propertyValues("Minute"), Color)
            .MinuteHand = CType(propertyValues("MinuteHand"), Color)
            .MinutePlus = CType(propertyValues("MinutePlus"), Color)
            .TimeAMPM_ON = CType(propertyValues("TimeAMPM_ON"), Color)
            .TimeAMPM_OFF = CType(propertyValues("TimeAMPM_OFF"), Color)
            .DisplayTime = CType(propertyValues("DisplayTime"), Color)
            .BackGround = CType(propertyValues("BackGround"), Color)
        End With

        Return NewTC
    End Function

    Public Overloads Overrides Function CanConvertFrom(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal sourceType As System.Type) As Boolean
        If (sourceType Is GetType(String)) Then
            Return True
        End If
        Return MyBase.CanConvertFrom(context, sourceType)
    End Function

    Public Overloads Overrides Function ConvertFrom(ByVal context As System.ComponentModel.ITypeDescriptorContext, _
      ByVal culture As System.Globalization.CultureInfo, ByVal value As Object) As Object
        If TypeOf value Is String Then
            Try
                Dim s As String = CType(value, String)
                Dim TimeColorParts(4) As String
                TimeColorParts = Split(s, ",")
                If Not IsNothing(TimeColorParts) Then
                    If IsNothing(TimeColorParts(0)) Then TimeColorParts(0) = "CornflowerBlue"
                    If IsNothing(TimeColorParts(1)) Then TimeColorParts(1) = "AliceBlue"
                    If IsNothing(TimeColorParts(2)) Then TimeColorParts(2) = "LightGoldenrodYellow"
                    If IsNothing(TimeColorParts(3)) Then TimeColorParts(3) = "White"
                    If IsNothing(TimeColorParts(4)) Then TimeColorParts(4) = "White"
                    If IsNothing(TimeColorParts(5)) Then TimeColorParts(5) = "DarkBlue"
                    If IsNothing(TimeColorParts(6)) Then TimeColorParts(6) = "DarkBlue"
                    If IsNothing(TimeColorParts(7)) Then TimeColorParts(7) = "Blue"
                    If IsNothing(TimeColorParts(8)) Then TimeColorParts(8) = "OrangeRed"
                    If IsNothing(TimeColorParts(9)) Then TimeColorParts(9) = "Blue"
                    If IsNothing(TimeColorParts(10)) Then TimeColorParts(10) = "MediumBlue"
                    If IsNothing(TimeColorParts(11)) Then TimeColorParts(11) = "LightSteelBlue"
                    If IsNothing(TimeColorParts(12)) Then TimeColorParts(12) = "Red"
                    If IsNothing(TimeColorParts(13)) Then TimeColorParts(13) = "White"
                    Return New TimeColors(Color.FromName(TimeColorParts(0).Trim), _
                                            Color.FromName(TimeColorParts(1).Trim), _
                                            Color.FromName(TimeColorParts(2).Trim), _
                                            Color.FromName(TimeColorParts(3).Trim), _
                                            Color.FromName(TimeColorParts(4).Trim), _
                                            Color.FromName(TimeColorParts(5).Trim), _
                                            Color.FromName(TimeColorParts(6).Trim), _
                                            Color.FromName(TimeColorParts(7).Trim), _
                                            Color.FromName(TimeColorParts(8).Trim), _
                                            Color.FromName(TimeColorParts(9).Trim), _
                                            Color.FromName(TimeColorParts(11).Trim), _
                                            Color.FromName(TimeColorParts(11).Trim), _
                                            Color.FromName(TimeColorParts(12).Trim), _
                                            Color.FromName(TimeColorParts(13).Trim))
                End If
            Catch ex As Exception
                Throw New ArgumentException("Can not convert '" & CStr(value) & "' to type TimeColors")
            End Try
        Else
            Return New TimeColors()
        End If

        Return MyBase.ConvertFrom(context, culture, value)
    End Function

    Public Overloads Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, _
      ByVal culture As System.Globalization.CultureInfo, _
      ByVal value As Object, ByVal destinationType As System.Type) As Object

        If (destinationType Is GetType(System.String) AndAlso TypeOf value Is TimeColors) Then
            Dim _TimeColor As TimeColors = CType(value, TimeColors)

            ' build the string as "UpperLeft,UpperRight,LowerLeft,LowerRight" 
            Return String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}", _
                _TimeColor.FrameOuter.Name, _
                _TimeColor.FrameInner.Name, _
                _TimeColor.FaceOuter.Name, _
                _TimeColor.FaceInner.Name, _
                _TimeColor.Box.Name, _
                _TimeColor.Hour.Name, _
                _TimeColor.HourHand.Name, _
                _TimeColor.Minute.Name, _
                _TimeColor.MinuteHand.Name, _
                _TimeColor.MinutePlus.Name, _
                _TimeColor.TimeAMPM_ON.Name, _
                _TimeColor.TimeAMPM_OFF.Name, _
                _TimeColor.DisplayTime.Name, _
                _TimeColor.BackGround.Name)
        End If
        Return MyBase.ConvertTo(context, culture, value, destinationType)

    End Function

End Class 'CornerConverter Code

#End Region 'TimeColorConverter

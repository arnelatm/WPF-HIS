Imports System.ComponentModel
Imports System.Drawing

<System.Diagnostics.DebuggerStepThrough()>
<TypeConverter(GetType(BlendItemsConverter))>
Public Class cBlendItems
    'Implements INotifyPropertyChanged

    'Public Event PropertyChanged As PropertyChangedEventHandler _
    '    Implements INotifyPropertyChanged.PropertyChanged

    'Private Sub NotifyPropertyChanged(ByVal info As String)
    '    RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    'End Sub

    Sub New()

    End Sub

    Sub New(ByVal Color As Color(), ByVal Pt As Single())
        iColor = Color
        iPoint = Pt
    End Sub

    Private _iColor As Color()

    <Description("The Color for the Point"),
        Category("Appearance")>
    Public Property iColor() As Color()
        Get
            Return _iColor
        End Get
        Set(ByVal value As Color())
            _iColor = value
            '   NotifyPropertyChanged("iColor")
        End Set
    End Property

    Private _iPoint As Single()

    <Description("The Color for the Point"),
        Category("Appearance")>
    Public Property iPoint() As Single()
        Get
            Return _iPoint
        End Get
        Set(ByVal value As Single())
            _iPoint = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        ' build the string as "Color1;Color2;Color3|Pt1;Pt2;Pt3"
        Dim bColors As New ArrayList
        Dim bPoints As New ArrayList
        For Each bColor As Color In _iColor
            If bColor.IsNamedColor Then
                bColors.Add(bColor.Name)
            Else
                bColors.Add(String.Format("{0},{1},{2},{3}", bColor.A, bColor.R, bColor.G, bColor.B))
            End If
        Next
        For Each bPoint As Single In _iPoint
            bPoints.Add(bPoint.ToString)
        Next

        Return String.Format("{0}|{1}", Join(bColors.ToArray, ";"), Join(bPoints.ToArray, ";"))
    End Function

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        Dim eObj As cBlendItems = CType(obj, cBlendItems)
        If iColor.Length <> eObj.iColor.Length _
           OrElse iPoint.Length <> eObj.iPoint.Length Then
            Return False
        Else
            For i As Integer = 0 To iColor.Length - 1
                If iColor(i) <> eObj.iColor(i) OrElse iPoint(i) <> eObj.iPoint(i) Then
                    Return False
                End If
            Next
            Return True
        End If

    End Function

End Class
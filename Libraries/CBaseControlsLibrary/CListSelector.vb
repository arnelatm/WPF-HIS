Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class CListSelector
    Inherits CForm

    Private _formPosition As Point
    Private _controlHeight As Int16
    Private _controlWidth As Int16
    Private ReadOnly _findableControl As IFindableControl

    Public Sub New(ctrl As Control, dataList As ArrayList)

        ' This call is required by the designer.
        InitializeComponent()
        Dim formPoint As Point
        _formPosition.X = formPoint.X
        _formPosition.Y = formPoint.Y
        _controlHeight = ctrl.Height
        _controlWidth = ctrl.Width

        Dim pnt As Point = ctrl.PointToScreen(New Point(0 + ctrl.Width, 0))
        _formPosition.X = pnt.X
        _formPosition.Y = pnt.Y

        lstItems.DataSource = dataList
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub SetFormLocation()
        Dim pnt As Point
        Dim formLocation As Point
        Dim screenRectangle As Rectangle
        screenRectangle = Screen.PrimaryScreen.WorkingArea
        StartPosition = FormStartPosition.Manual
        pnt = _formPosition
        If GlobalVariables.RightToLeftLayout Then
            formLocation = New Point(pnt.X - Width - _controlWidth, pnt.Y)
        Else
            formLocation = New Point(pnt.X, pnt.Y)
        End If
        Dim horizontalCoordinateOutsideScreen As Boolean = False
        If formLocation.X < 0 Then
            formLocation.X = 0
            horizontalCoordinateOutsideScreen = True
        End If

        If formLocation.X + Width > screenRectangle.Width Then
            formLocation.X = screenRectangle.Width - Width
            horizontalCoordinateOutsideScreen = True
            ' set to true if form will not fit on the right
        End If
        If formLocation.Y < 0 Then
            formLocation.Y = 0
        End If
        If formLocation.Y + Height > screenRectangle.Height Then
            formLocation.Y = formLocation.Y - Height
        Else
            If horizontalCoordinateOutsideScreen Then
                ' move down so as not to cover the field to be searched
                formLocation.Y = formLocation.Y + _controlHeight
            End If
        End If
        Location = formLocation
    End Sub

    Private Sub CListSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetFormLocation()
    End Sub

End Class
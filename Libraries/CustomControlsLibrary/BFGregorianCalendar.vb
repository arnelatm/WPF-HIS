Imports System.Globalization
Imports AATM.Libraries.CBaseControlsLibrary

Public Class BfGregorianCalendar
    Inherits CForm

    Private strValue As String = ""
    Private ReadOnly curDate As DateTime?
    Private ReadOnly Cul As CultureInfo = New CultureInfo(CultureInfo.CurrentCulture.Name)
    Private ReadOnly Cal As GregorianCalendar = New GregorianCalendar
    Private passedDateStr As String
    Private _userSelectedDate As Boolean = False

    Public Sub New(dDate As DateTime?)
        'If System.Globalization.CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
        '    RightToLeftLayout = True
        '    RightToLeft = System.Windows.Forms.RightToLeft.Yes
        'Else
        '    RightToLeftLayout = False
        '    RightToLeft = System.Windows.Forms.RightToLeft.No
        'End If
        ' This call is required by the designer.
        InitializeComponent()
        Cul.DateTimeFormat.Calendar = Cal
        ' Add any initialization after the InitializeComponent() call.
        curDate = dDate
        Dim CurCul = CultureInfo.CurrentCulture
        'If System.Globalization.CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
        '    RightToLeftLayout = True
        '    RightToLeft = System.Windows.Forms.RightToLeft.Yes
        'Else
        '    RightToLeftLayout = False
        '    RightToLeft = System.Windows.Forms.RightToLeft.No
        'End If
    End Sub

    Public Property ReturnedDateString As String
        Get
            Dim retDateStr As String
            If strValue Is Nothing OrElse strValue = "" Then
                retDateStr = Nothing
            Else
                retDateStr = GregCalendar.SelectionRange.Start.ToShortDateString()
            End If
            Return retDateStr
        End Get
        Set
            passedDateStr = Value
        End Set
    End Property

    'Private Sub Calendar_DateChanged(sender As Object, e As Windows.Forms.DateRangeEventArgs) Handles Calendar.DateChanged
    '    Dim strDate As String
    '    strDate = Se
    '    strValue = strDate.ToString()
    'End Sub

    Private Sub Calendar_DateSelected(sender As Object, e As DateRangeEventArgs) Handles GregCalendar.DateSelected
        ' Show selected Date
        Dim selDate As Date?
        strValue = e.Start.ToShortDateString()
        selDate = e.Start.Date()
        'RaiseEvent DateChanged(Me, New EventArgs())
        btnOK.Visible = True
        btnOK.PerformClick()
        'Hide()
    End Sub

    Private Sub BFGregorianCalendar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim GDate As String
        If curDate Is Nothing Then
            GDate = DateTime.Now.ToString()
        Else
            Dim dDate As DateTime
            dDate = curDate
            GDate = dDate.ToString()
        End If
        GregCalendar.Select()
        GregCalendar.SetDate(GDate)
        'If System.Globalization.CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
        '    RightToLeftLayout = True
        '    RightToLeft = System.Windows.Forms.RightToLeft.Yes
        'Else
        '    RightToLeftLayout = False
        '    RightToLeft = System.Windows.Forms.RightToLeft.No
        'End If
    End Sub

    Private Sub BFGregorianCalendar_RightToLeftLayoutChanged(sender As Object, e As EventArgs) _
        Handles MyBase.RightToLeftLayoutChanged
        GregCalendar.RightToLeftLayout = RightToLeftLayout
        GregCalendar.RightToLeft = RightToLeft
    End Sub

End Class
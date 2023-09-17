Public Class DateRangeControl


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim now As Date = Today()
        dtpEndingDate.Value = now
        dtpBeginningDate.Value = DateAndTime.DateAdd(DateInterval.Day, Day(now) * -1 + 1, now)


    End Sub

    'Public Property BeginningDate As Date?
    '    Get
    '        Return dtpBeginningDate.Value
    '    End Get
    '    Set(value As Date?)
    '        dtpBeginningDate.Value = value
    '    End Set
    'End Property

    'Public Property EndingDate As Date?
    '    Get
    '        Return dtpEndingDate.Value
    '    End Get
    '    Set(value As Date?)
    '        dtpEndingDate.Value = value
    '    End Set
    'End Property


End Class

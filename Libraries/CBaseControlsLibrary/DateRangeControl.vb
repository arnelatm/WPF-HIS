Public Class DateRangeControl
    Public Property BeginningDate As Date?
        Get
            Return dtpBeginningDate.Value
        End Get
        Set(value As Date?)
            dtpBeginningDate.Value = value
        End Set
    End Property

    Public Property EndingDate As Date?
        Get
            Return dtpEndingDate.Value
        End Get
        Set(value As Date?)
            dtpEndingDate.Value = value
        End Set
    End Property


End Class

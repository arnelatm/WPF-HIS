Public Class ValidationControl
    Private _control As Object
    Private _displayname As String
    Private _errormessage As String
    Private _validate As Boolean = True
    Private _mandatory As Boolean = True

    'Validate property decides Whether control is to be validated. Default value is TRUE.
    Public Property Validate As Boolean
        Get
            Return _validate
        End Get
        Set
            _validate = Value
        End Set
    End Property

    'ControlObj is a control from windows form which is to be validated.
    'For example txtStudentName
    Public Property ControlObj As Object
        Get
            Return _control
        End Get
        Set
            _control = Value
        End Set
    End Property

    'DisplayName property is used for displaying summary message to user.
    'For example, for txtStudentName you can set 'Student Full Name' as field name.
    'This field name will be displayed in summary message.
    Public Property DisplayName As String
        Get
            Return _displayname
        End Get
        Set
            _displayname = Value
        End Set
    End Property

    'ErrorMessage is also used for displaying summary message.
    'For example, you can enter 'Student Name is mandatory' as an error message.
    Public Property ErrorMessage As String
        Get
            Return _errormessage
        End Get
        Set
            _errormessage = Value
        End Set
    End Property

    'ErrorMessage is also used for displaying summary message.
    'For example, you can enter 'Student Name is mandatory' as an error message.
    Public Property Mandatory As Boolean
        Get
            Return _mandatory
        End Get
        Set
            _mandatory = Value
        End Set
    End Property

End Class
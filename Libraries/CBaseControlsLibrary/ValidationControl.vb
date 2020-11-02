Public Class ValidationControl

    'Validate property decides Whether control is to be validated. Default value is TRUE.
    Public Property Validate As Boolean = True

    'ControlObj is a control from windows form which is to be validated.
    'For example txtStudentName
    Public Property ControlObj As Object

    'DisplayName property is used for displaying summary message to user.
    'For example, for txtStudentName you can set 'Student Full Name' as field name.
    'This field name will be displayed in summary message.
    Public Property DisplayName As String

    'ErrorMessage is also used for displaying summary message.
    'For example, you can enter 'Student Name is mandatory' as an error message.
    Public Property ErrorMessage As String

    'ErrorMessage is also used for displaying summary message.
    'For example, you can enter 'Student Name is mandatory' as an error message.
    Public Property Mandatory As Boolean = True

End Class
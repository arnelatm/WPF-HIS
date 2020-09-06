Public Class ClassesLibrary
    'Public Class LookupData
    '    Property IdNo As Int32
    '    Property Name As String
    '    Property Code As String

    '    Public Overrides Function ToString() as String
    '        return Name.ToString()
    '    End Function
    'End Class

    Public Class HLookupData
        Property IdNo
        Property Name As String
        Property ParentIdNo
        Property Code As String
    End Class

    Public Class LookupData
        Public Property IdNo
        Public Property Name As String
        Public Property Code As String
        Public Property Index

        Public Overrides Function ToString() As String
            Return Name.ToString()
        End Function

    End Class

End Class
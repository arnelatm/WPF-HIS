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
        Property IdNo As Int32
        Property Name As String
        Property ParentIdNo As Int32?
        Property Code As String
    End Class

    Public Class LookupData
        Public Property IdNo As Int32
        Public Property Name As String
        Public Property Code As String
        Public Property Index As Nullable(Of Int32)

        Public Overrides Function ToString() As String
            Return Name.ToString()
        End Function

    End Class

End Class
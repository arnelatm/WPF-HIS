Public Interface IFindableControl
    Property FindEnabled As Boolean
    Property BegFindValue As Object
    Property EndFindValue As Object
    Property SearchPlace As SearchPlaceEnum
    Property FieldName As String
    ReadOnly Property DataSource As Object
    ReadOnly Property DisplayMember As String
    ReadOnly Property SearchMode As SearchModeEnum
    ReadOnly Property ValueMember As String

    Enum SearchModeEnum
        [String]
        [Date]
        [ComboBox]
        [CheckBox]
    End Enum

    Enum SearchPlaceEnum
        [StartOfField]
        [AnywhereOnField]
        [ExactValue]
    End Enum

End Interface
Public Interface IFindableControl
    Property FindDataType As DataTypeEnum
    Property FindEnabled As Boolean
    Property BegFindValue As Object
    Property EndFindValue As Object
    Property SearchPlace As SearchPlaceEnum
    Property FieldName As String
    Property FieldDescription As String
    Property IgnoreCase as Boolean
    ReadOnly Property FindDataSource As Object
    ReadOnly Property FindDisplayMember As String
    ReadOnly Property SearchMode As SearchModeEnum
    ReadOnly Property FindValueMember As String
    
    
    Enum SearchModeEnum
        [TextBox]
        [Date]
        [ComboBox]
        [CheckBox]
    End Enum

    Enum SearchPlaceEnum
        [StartOfField]
        [AnywhereOnField]
        [ExactValue]
    End Enum

    Enum DataTypeEnum
        [String]
        [Date]
        [DateTime]
        [Integer]
        [Decimal]
        [Boolean]
    End Enum

End Interface
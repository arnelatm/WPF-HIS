Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.ServicesLayer.Services

Public Enum DataTypeSelection
    BooleanType = 0
    ByteType = 1
    CharType = 2
    DateType = 3
    DecimalType = 4
    DoubleType = 5
    IntegerType = 6
    LongType = 7
    ObjectType = 8
    SByteType = 9
    ShortType = 10
    SingleType = 11
    StringType = 12
    UIntegerType = 13
    ULongType = 14
    UserDefinedType = 15
    UShortType = 16
End Enum

Public Class DataTableLookupSpec
    Public Property TableName As String
    Public Property LuFields As String
    Public Property SortKey As String
    Public Property Filter As String
    Public Property ValueMember As String
    Public Property DisplayMember As String
    Public Property DataView As DataView
    Public Property NameField As String
    Public Property NameFieldOrig As String
    Public Property NameDisplayValue As String
    Public Property LookUpTask As Task(Of DataTable)
    Public Property DvLookUpTask As Task(Of DataView)
    Public Property Data As DataTable
    Public Property NameFieldToUse As String
    Public Property Ascending As Boolean
End Class

Public Class DataLookupSpecs
    Inherits DataTableLookupSpec

    Public Property PropertyControl As CtComboBox
    Public Property PropertyName As String

End Class

Public Class DataCreator

    Private Shared _sv As Service

    Public Sub New(svc As Service)
        _sv = svc
    End Sub

    Public Function CreateDataTable(dtl As DataLookupSpecs) As DataTable
        Return _sv.GetDtRecords(dtl.TableName, dtl.LuFields, dtl.Filter, dtl.SortKey, dtl.Ascending)
    End Function

    Public Function CreateDataTable(dtl As DataTableLookupSpec) As DataTable
        Return _sv.GetDtRecords(dtl.TableName, dtl.LuFields, dtl.Filter, dtl.SortKey, dtl.Ascending)
    End Function

End Class

Public Class DataViewCreator

    Private Shared _sv As Service

    Public Sub New(svc As Service)
        _sv = svc
    End Sub

    Public Function CreateDataView(dtl As DataLookupSpecs) As DataView
        Dim dt As DataTable = _sv.GetDtRecords(dtl.TableName, dtl.LuFields, dtl.Filter, dtl.SortKey, dtl.Ascending)
        Dim dv As DataView
        dv = dt.DefaultView
        Return dv
    End Function

End Class


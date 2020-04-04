Imports System.ComponentModel
Imports System.Globalization
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.EnumLocalization
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

''' <summary>
'''     Base class for all presenter classes. Keeps track of Model and View classes.
'''     Notice that Model is static and View is set in the constructor.
''' </summary>
''' <remarks>
'''     MV Patterns: MVP design pattern.
''' </remarks>
''' <typeparam name="T">Type of view.</typeparam>
Public MustInherit Class Presenter(Of T As IView, TM As New)

    Protected OriginalModel
    Public ChildPresenters As New List(Of Object)

    Protected DataService

    Protected DataModel

    Protected TreeViewMainField As String
    Protected TreeViewSecondaryField As String
    Protected TreeViewParentIdField As String
    Protected TreeViewList

    Friend DateTimeStampField As String = "DateTimeStamp"
    Friend RecordDateTimeStampValue As Object
    Protected DbDataDao
    Private _tableColumnPropertyList As List(Of TblColPropModel)
    Private _tableDefaultFieldValueList As List(Of DefaultFieldValueModel)

    Protected Shared Property Model As New Model()
    Protected Shared Property ModelTblColProp As IModelTblColProp
    Protected Shared Property ModelDefaultFieldValue As IModelDefaultFieldValue

    Public Shared Property TableProperties As Array
    Public Shared Property TableDefaultFieldValues As List(Of DefaultFieldValueModel)
    Public Shared Property SortOrderKey As String = "IDNo"

    Public Shared SecurityModel As New Model

    Public Property ModelPresenter
        Get
            Return Model
        End Get
        Set(value)
            Model = value
        End Set
    End Property

    Shared Sub New()
        Model = New Model()
        ModelTblColProp = New ModelTblColProp
        ModelDefaultFieldValue = New ModelDefaultFieldValue
    End Sub

    Public Sub New(view As T)
        If view Is Nothing Then
            ''
        Else
            Me.View = view
            TableName = GetPropertyValue(Me.View, "MainTableName")
            'GetPropertyValue(view,"MainTableName")
            If TableName Is Nothing OrElse TableName.TrimEnd() = "" Then
                MessageBox.Show($"'MainTableName' property of the form is not set.")
            End If
            Dim tableColumnPropertyList As List(Of TblColPropModel)

            tableColumnPropertyList = ModelTblColProp.GetMainTableColumnProperties(TableName)
            TableProperties = tableColumnPropertyList.ToArray
            TableDefaultFieldValues = ModelDefaultFieldValue.GetDefaultFieldValue(TableName)
        End If
    End Sub

    Public Function GetBizObjectRules()
        Return Model.GetBizObjectRules()
    End Function

    Public Function GetBizObjectErrors() As List(Of String)
        Return Model.GetBizObjectErrors()
    End Function

    Public Property View As T

    Public Shared Property TableName As String

    Public Shared Property RecordCount As Integer

    'Public Function GetRecordCountValue() As Integer
    '    Try
    '        Return GetRecordCount()
    '    Catch ex As Exception
    '        Return 0
    '    End Try
    'End Function

    Public Shared Property RecordNumber As Integer

    Public Sub AddChildPresenter(obj As Object)
        ChildPresenters.Add(obj)
    End Sub

    Private Function GetRecordNumberValue(idNo As Integer) As Integer
        Try
            Return GetRecordPosition(idNo)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetIdNoOfSortedPositionNumber(recordNo As Integer) As Integer
        Try
            Return Model.GetIdNoOfSortedPositionNumber(recordNo, TableName, SortOrderKey)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetSortedRecordPosition(idNo As Integer) As Integer
        Try
            Return Model.GetSortedRecordPosition(idNo, TableName, SortOrderKey)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function FindField(txtControl As Control) As Integer
        Dim fieldName As String = txtControl.Name.Substring(3)
        Dim searchString As String
        Dim searchAnywhere As Boolean
        searchString = CallByName(txtControl, "GetTextToSearch", CallType.Get)
        searchAnywhere = CallByName(txtControl, "GetSearchAnywhere", CallType.Get)
        Return Model.FindField(TableName, fieldName, searchString, searchAnywhere)
    End Function

    Public Function FindFieldContinue(idNo As Integer) As Integer
        Return Model.FindFieldContinue(TableName, idNo)
    End Function

    Public Function GetRecordCount() As Integer
        Try
            Return Model.GetRecordCount(TableName)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetRecordPosition(idNo As Integer)
        Try
            Return Model.GetRecordPosition(TableName, idNo) + 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetTableProperties() As List(Of TblColPropModel)
        Return ModelTblColProp.GetMainTableColumnProperties(TableName)
    End Function

    Public Property NewlyAddedRecordIdNo As Integer

    Public Function DeleteRecord(idNo As Integer) As Integer
        Try
            Return Model.DeleteRecord(idNo, TableName)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Overridable Sub Display(idNo As Integer)
        Dim modelData
        modelData = ModelPresenter.GetRecordById(Of TM)(idNo)
        'If modelData IsNot Nothing And modelData.IdNo > 0 Then
            GlobalVariables.Mapper.Map(Of TM, T)(modelData, View)
            For Each child In ChildPresenters
                child.Display(idNo)
            Next
        'End If
    End Sub

    Public Sub SaveOriginalValues()
        GlobalVariables.Mapper.Map(Of T, TM)(Me.View, Me.OriginalModel)
        For Each item In ChildPresenters
            item.SaveOriginalValues()
        Next
    End Sub

    Public Function GetTreeViewDataNew()
        Dim cModel As New TM
        Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of TM)(SortOrderKey, cModel)
        Dim treeMainFieldName = TranslateField(Of TM)(TreeViewMainField, cModel)
        If TreeViewParentIdField Is Nothing OrElse TreeViewParentIdField = "" Then
            If String.IsNullOrEmpty(TreeViewSecondaryField) Then
                Return Model.GetRecords(TableName, newSortOrderKey, {"IdNo", treeMainFieldName})
            Else
                Return Model.GetRecords(TableName, newSortOrderKey, {"IdNo", treeMainFieldName, TreeViewSecondaryField})
            End If
        Else
            If String.IsNullOrEmpty(TreeViewSecondaryField) Then
                Return Model.GetHRecords(TableName, newSortOrderKey, {"IdNo", treeMainFieldName, TreeViewParentIdField})
            Else
                Return _
                    Model.GetHRecords(TableName, newSortOrderKey,
                                      {"IdNo", treeMainFieldName, TreeViewParentIdField, TreeViewSecondaryField})
            End If
        End If
    End Function

    Public Overridable Function Save(ByRef addMode As Boolean)
        Dim retVal As Integer
        Dim record As New TM
        GlobalVariables.Mapper.Map(Of IView, TM)(View, record)
        If addMode Then
            retVal = AddRecord(record)
        Else
            retVal = UpdateRecord(record)
        End If
        If retVal > 0 Then
            Dim lRetVal As Integer
            lRetVal = SaveChildren(addMode, retVal)
            If lRetVal < 0 Then
                retVal = lRetVal
            End If
        End If
        Return retVal
    End Function

    Protected Overridable Function SaveChildren(addMode As Boolean, retVal As Integer) As Integer
        For Each child In ChildPresenters
            retVal = child.Save(addMode)
            If retVal <= 0 Then
                Exit For
            End If
        Next
        Return retVal
    End Function

    Protected Overridable Function UpdateRecord(record As TM) As Integer
        Return Model.UpdateRecord(record)
    End Function

    Protected Overridable Function AddRecord(record As TM) As Integer
        Dim retVal As Integer
        NewlyAddedRecordIdNo = ModelPresenter.AddRecord(record)
        retVal = NewlyAddedRecordIdNo
        CallByName(View, "IdNo", CallType.Set, retVal)
        Return retVal
    End Function

    Private _errorList As String = ""

    Public Sub ShowErrors(Optional ByVal additionalMessage As String = Nothing)
        If additionalMessage IsNot Nothing Then
            _errorList = additionalMessage + Environment.NewLine
        End If
        For Each bizError In Model.GetBizObjectErrors()
            If _errorList.Contains(bizError & Environment.NewLine) Then
                ' don't add duplicate message
            Else
                _errorList = _errorList & bizError & Environment.NewLine
            End If
        Next

        Messaging.Show(_errorList, $"Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'MessageBox.Show(_errorList, $"Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Overridable Function DataIsValid() As Boolean
        Dim retVal = False
        GlobalVariables.Mapper.Map(Of T, TM)(View, DataModel)
        If Model.IsValid(DataModel) Then
            retVal = True
        End If
        Return retVal
    End Function

    Public Function GetRecordFieldWithKey(searchValue As String, cTableName As String, searchFieldName As String,
                                          returnFieldName As String) _
        As String
        Try
            Return Model.GetRecordFieldWithKey(searchValue, cTableName, searchFieldName, returnFieldName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function CountRecordWithKey(searchValue As String, searchFieldName As String) As Integer
        Try
            Return Model.CountRecordWithKey(searchValue, TableName, searchFieldName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetRecordWithIdNo(idNo As Integer, returnFieldName As String) As String
        Try
            Return Model.GetRecordWithIdNo(idNo, TableName, returnFieldName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetRecordDateTimeStamp(idNo As Integer) As Object
        Try
            Return Model.GetRecordDateTimeStamp(idNo, TableName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function HasRecordChanged(idNo As Integer, timeStampedValue As Object) As Boolean
        Dim retValue = False
        Try
            Dim newDateTimeStamp As Object
            newDateTimeStamp = Model.GetRecordDateTimeStamp(idNo, TableName, DateTimeStampField)
            For i = 0 To 7
                If timeStampedValue(i) <> newDateTimeStamp(i) Then
                    retValue = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            Return Nothing
        End Try
        Return retValue
    End Function

    Public Function GetOriginalValue(ByRef control As Object) As String
        Dim retVal = ""
        Dim type As Type = OriginalModel.GetType()
        Dim properties As PropertyInfo() = type.GetProperties()
        For Each [property] As PropertyInfo In properties
            If [property].Name.ToLower() = control.Name.ToString().Substring(3).ToLower() Then
                retVal = [property].GetValue(OriginalModel)
                Exit For
            End If
        Next
        Return retVal
    End Function

    Public Function GetOriginalModel() As TM
        Return OriginalModel
    End Function

    Public Function CheckIfUnique(textValue As String, fieldName As String, targetIdNo As Int32) As Boolean
        If Model.CheckIfUnique(textValue, TableName, fieldName, targetIdNo) Then
            Return True
        End If
        Return False
    End Function

    Public Overridable Function ChangesMade() As Boolean
        Dim retVal As Boolean = False
        If Not ObjectsCompare(OriginalModel, View) Then
            retVal = True
        Else
            ' if object compare equal check the children
            For Each child In ChildPresenters
                If child.ChangesMade() Then
                    retVal = True
                    Exit For
                End If
            Next
        End If
        Return retVal
    End Function

    Protected Function GetTranslatedSortOrderKey(Of TX)(sortKey As String, ByRef dModel As TX) As String
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            If GlobalVariables.RightToLeftLayout Then
                Dim stringLength = SortOrderKey.Length
                Dim suffix = ""
                Dim nameOfField As String = sortKey
                If stringLength > 4 And
                   (SortOrderKey.Substring(stringLength - 4).ToLower() = " asc" OrElse
                    SortOrderKey.Substring(stringLength - 4).ToLower() = " des") Then
                    suffix = SortOrderKey.Substring(stringLength - 4)
                    nameOfField = SortOrderKey.Substring(0, stringLength - 4)
                End If
                nameOfField = GetTranslatedField(Of TX)(nameOfField, dModel)
                sortKey = nameOfField + suffix
            End If
        End If
        Return sortKey
    End Function

    Protected Function GetTranslatedField(Of TX)(dataSortOrder As String, ByRef dModel As TX) As String
        Dim translatedSortOrder As String = dataSortOrder
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            If GlobalVariables.RightToLeftLayout Then
                Dim stringLength = dataSortOrder.Length
                Dim suffix = ""
                Dim nameOfField As String = dataSortOrder
                If stringLength > 4 And
                   (dataSortOrder.Substring(stringLength - 4).ToLower() = " asc" OrElse
                    dataSortOrder.Substring(stringLength - 4).ToLower() = " des") Then
                    suffix = dataSortOrder.Substring(stringLength - 4)
                    nameOfField = dataSortOrder.Substring(0, stringLength - 4)
                End If
                If PropertyExists(dModel, nameOfField + "ara") Then
                    nameOfField = nameOfField + "Ara"
                    translatedSortOrder = nameOfField + suffix
                End If
            End If
        End If
        Return translatedSortOrder
    End Function

    Protected Function TranslateField(Of TX)(fieldToTranslate As String, ByRef dModel As TX) As String
        Dim translatedField As String = fieldToTranslate
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            If GlobalVariables.RightToLeftLayout Then
                If PropertyExists(dModel, fieldToTranslate + "ara") Then
                    translatedField = fieldToTranslate + "Ara"
                End If
            End If
        End If
        Return translatedField
    End Function

    Public Shared Function CreateClass(className As String, properties As Dictionary(Of String, Type)) As Type

        Dim myDomain As AppDomain = AppDomain.CurrentDomain
        Dim myAsmName As New AssemblyName("MyAssembly")
        Dim myAssembly As AssemblyBuilder = myDomain.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.Run)

        Dim myModule As ModuleBuilder = myAssembly.DefineDynamicModule("MyModule")

        Dim myType As TypeBuilder = myModule.DefineType(className, TypeAttributes.Public)

        myType.DefineDefaultConstructor(MethodAttributes.Public)

        For Each o In properties

            Dim prop As PropertyBuilder = myType.DefineProperty(o.Key, PropertyAttributes.HasDefault, o.Value, Nothing)
            Dim field As FieldBuilder = myType.DefineField("_" + o.Key, o.Value, FieldAttributes.[Private])

            Dim getter As MethodBuilder = myType.DefineMethod("get_" + o.Key,
                                                              MethodAttributes.[Public] Or MethodAttributes.SpecialName Or
                                                              MethodAttributes.HideBySig, o.Value, Type.EmptyTypes)
            Dim getterIl As ILGenerator = getter.GetILGenerator()
            getterIl.Emit(OpCodes.Ldarg_0)
            getterIl.Emit(OpCodes.Ldfld, field)
            getterIl.Emit(OpCodes.Ret)

            Dim setter As MethodBuilder = myType.DefineMethod("set_" + o.Key,
                                                              MethodAttributes.[Public] Or MethodAttributes.SpecialName Or
                                                              MethodAttributes.HideBySig, Nothing, New Type() {o.Value})
            Dim setterIl As ILGenerator = setter.GetILGenerator()
            setterIl.Emit(OpCodes.Ldarg_0)
            setterIl.Emit(OpCodes.Ldarg_1)
            setterIl.Emit(OpCodes.Stfld, field)
            setterIl.Emit(OpCodes.Ret)

            prop.SetGetMethod(getter)
            prop.SetSetMethod(setter)

        Next

        Return myType.CreateType()
    End Function

    Public Property EnumConverter As ResourceEnumConverter

    Public Function GetEnumList(Of TE)()
        If EnumConverter Is Nothing Then
            EnumConverter = TypeDescriptor.GetConverter(GetType(TE))
        End If
        Dim dataList As New List(Of ClassesLibrary.LookupData)
        'Dim enumValues = [Enum].GetValues(GetType(TE))
        For Each c In [Enum].GetValues(GetType(TE))
            Dim data As New ClassesLibrary.LookupData
            data.IdNo = CInt(c)
            data.Code = GetEnumCode(c)
            data.Name = EnumConverter.GetValueText(CultureInfo.CurrentCulture, c)
            dataList.Add(data)
        Next
        Return dataList
    End Function

    Public Function MakeEnumComboList(Of TE)()
        If EnumConverter Is Nothing Then
            EnumConverter = TypeDescriptor.GetConverter(GetType(TE))
        End If
        Dim dataList As New List(Of ClassesLibrary.LookupData)
        'Dim enumValues = [Enum].GetValues(GetType(TE))
        'Dim x As Object
        For Each c In [Enum].GetValues(GetType(TE))
            Dim data As New ClassesLibrary.LookupData
            'dim code As String
            data.IdNo = CInt(c)
            'code = GlobalFunctions.GetDescription(c,"")
            data.Code = GetEnumCode(c)
            'x = Adapter.GetEnumDescription(c)
            'data.Code = Adaptor.GetEnumDescription(c)
            data.Name = EnumConverter.GetValueText(CultureInfo.CurrentCulture, c)
            dataList.Add(data)
        Next
        Return dataList
    End Function

    Public Sub MakeDefaultValues()
        For Each item In TableDefaultFieldValues
            Select Case item.DataType
                Case DataTypeSelection.StringType
                    CallByName(View, item.FieldName, CallType.Set, item.DefaultValue)
                Case DataTypeSelection.CharType
                    CallByName(View, item.FieldName, CallType.Set, item.DefaultValue)
                Case DataTypeSelection.IntegerType
                    CallByName(View, item.FieldName, CallType.Set, CInt(item.DefaultValue))
                Case DataTypeSelection.BooleanType
                    CallByName(View, item.FieldName, CallType.Set, CBool(item.DefaultValue))
                Case DataTypeSelection.SingleType
                    CallByName(View, item.FieldName, CallType.Set, CSng(item.DefaultValue))
                Case DataTypeSelection.DoubleType
                    CallByName(View, item.FieldName, CallType.Set, CDbl(item.DefaultValue))
                Case DataTypeSelection.DecimalType
                    CallByName(View, item.FieldName, CallType.Set, CDec(item.DefaultValue))
                Case DataTypeSelection.LongType
                    CallByName(View, item.FieldName, CallType.Set, CLng(item.DefaultValue))
                Case DataTypeSelection.DateType
                    If item.DefaultValue = "today" Then
                        CallByName(View, item.FieldName, CallType.Set, Today())
                    ElseIf item.DefaultValue = "yesterday" Then
                        CallByName(View, item.FieldName, CallType.Set, DateTime.Now.AddDays(-1))
                    ElseIf item.DefaultValue = "tomorrow" Then
                        CallByName(View, item.FieldName, CallType.Set, DateTime.Now.AddDays(1))
                    Else
                        CallByName(View, item.FieldName, CallType.Set, CDate(item.DefaultValue))
                    End If
                Case DataTypeSelection.ShortType
                    CallByName(View, item.FieldName, CallType.Set, CShort(item.DefaultValue))
                Case DataTypeSelection.UIntegerType
                    CallByName(View, item.FieldName, CallType.Set, CUInt(item.DefaultValue))
                Case DataTypeSelection.ULongType
                    CallByName(View, item.FieldName, CallType.Set, CULng(item.DefaultValue))
                Case DataTypeSelection.UShortType
                    CallByName(View, item.FieldName, CallType.Set, CUShort(item.DefaultValue))
                Case Else
                    MessageBox.Show(
                        $"Default Value Datatype Conversion for Field " & item.FieldName & " in table " & item.TableName &
                        " conversion not handled")
            End Select
        Next item
        Return
    End Sub

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

    Public Function GetSqlValue(Of TType)(sqlStatement As String, cTableName As String, condition As String) As TType
        Try
            Return Model.GetSqlValue(Of TType)(sqlStatement, cTableName, condition)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#Region "GetLookupTable"

    Protected Property TableToGet As String
    Protected Property SortExpression As String
    Protected Property DisplayName As String
    Protected Property DisplayCode As String
    Protected Property DisplayNameArabic As String
    Protected Property FilterKey As String = Nothing
    Protected Property FieldsToShow As String()

    Public Function GetSecurityGroupList(Optional ByVal sortKey As String = "SecurityGroupName")
        TableToGet = "SecurityGroup"
        SortExpression = sortKey
        DisplayName = "SecurityGroupName"
        DisplayNameArabic = "SecurityGroupNameAra"
        DisplayCode = "SecurityGroupCode"
        Return GetLookupDataByCode()
    End Function

    Public Function GetSecurityObjectList(Optional ByVal sortKey As String = "SecurityObjectName")
        TableToGet = "SecurityObject"
        SortExpression = sortKey
        DisplayName = "SecurityObjectName"
        DisplayNameArabic = "SecurityObjectNameAra"
        DisplayCode = "IdNo"
        Return GetLookupDataByCode()
    End Function

    Protected Function GetLookupDataByCode()
        FormatFields()
        Return Model.GetLookupDataByCode(TableToGet, SortExpression, FieldsToShow)
    End Function

    Protected Function GetLookupDataByName()
        FormatFields()
        Return Model.GetLookupDataByName(TableToGet, SortExpression, FieldsToShow)
    End Function

    Protected Function GetLookupDataByNameWithCode()
        FormatFields()
        Return Model.GetLookupDataByNameWithCode(TableToGet, SortExpression, FieldsToShow)
    End Function

    Protected Function GetTableList()
        FormatFields()
        Return Model.GetRecords(TableToGet, SortExpression, FieldsToShow)
    End Function

    Protected Function GetTableListFiltered()
        FormatFields()
        Return Model.GetRecordsFiltered(TableToGet, SortExpression, FilterKey, FieldsToShow)
    End Function

    Protected Function GetLookupFilteredData()
        FormatFields()
        Return Model.GetLookupFilteredDataByName(TableToGet, SortExpression, FilterKey, FieldsToShow)
    End Function

    Protected Function GetLookupFilteredDataByName()
        FormatFields()
        Return Model.GetLookupFilteredDataByName(TableToGet, SortExpression, FilterKey, FieldsToShow)
    End Function

    Protected Function GetLookupFilteredDataByCode()
        FormatFields()
        Return Model.GetLookupFilteredDataByCode(TableToGet, SortExpression, FilterKey, FieldsToShow)
    End Function

    Protected Sub FormatFields()
        Dim dFieldName As String
        If IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
            If SortExpression = DisplayName Then
                SortExpression = DisplayNameArabic
            End If
            dFieldName = DisplayNameArabic
        Else
            dFieldName = DisplayName
        End If
        FieldsToShow = {"IdNo", dFieldName, DisplayCode}
    End Sub

    Protected Function GetLookupData(pDisplayName, pDisplayNameArabic, pDisplayCode, pTableToGet, pSortExpression, pFilterKey)
        Dim dFieldName As String
        If IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
            If SortExpression = pDisplayName Then
                SortExpression = pDisplayNameArabic
            End If
            dFieldName = pDisplayNameArabic
        Else
            dFieldName = pDisplayName
        End If
        FieldsToShow = {"IdNo", dFieldName, pDisplayCode}
        Return Model.GetLookupFilteredDataByCode(pTableToGet, pSortExpression, pFilterKey, FieldsToShow)
    End Function

#End Region

End Class
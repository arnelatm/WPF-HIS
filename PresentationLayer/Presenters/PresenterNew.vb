Imports System.ComponentModel
Imports System.Globalization
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Windows.Forms
Imports AATM.BusinessLayer
Imports AATM.Libraries
Imports AATM.LIBRARIES.GlobalFuncNSub
Imports AATM.LIBRARIES.Languages
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
Public MustInherit Class PresenterNew(Of T As IView, TBiz As BusinessObject, TM As New)

    Friend DateTimeStampField As String = "DateTimeStamp"
    Friend RecordDateTimeStampValue As Object

    '    Private _errorProvider As ErrorProviderExtended
    '    Private _fieldsDictionary As Dictionary(Of String, Object)
    '    Private _tableColumnPropertyList As List(Of TblColPropModel)
    '    Private _tableDefaultFieldValueList As List(Of DefaultFieldValueModel)
    Protected BizObject

    Protected DataModel
    Protected DbDataDao
    Protected OriginalModel
    Protected TreeViewList
    Protected TreeViewMainField As String
    Protected TreeViewParentIdField As String
    Protected TreeViewSecondaryField As String
    Public Shared Property Model As IModelOld

    Shared Sub New()
        Model = New ModelOld()
    End Sub

    Public Shared Property TableProperties As Array
    Public Shared Property TableDefaultFieldValues As List(Of DefaultFieldValueModel)
    Public Shared Property SortOrderKey As String = "IDNo"

    '    Public Shared SecurityModel As New Model

    'Public Property PublicOriginalModel
    '    Get
    '        Return OriginalModel
    '    End Get
    '    Set(value)
    '        OriginalModel = value
    '    End Set
    'End Property

    Public Sub New(view As T)
        If view Is Nothing Then
            ''
        Else
            Me.View = view
            TableName = GetPropertyValue(Me.View, "MainTableName")
            If TableName Is Nothing OrElse TableName.TrimEnd() = "" Then
                MessageBox.Show($"'MainTableName' property of the form is not set.")
            End If
            Dim tblColPropModel As New ModelOld
            Dim tableColumnPropertyList As List(Of TblColPropModel)
            tableColumnPropertyList = tblColPropModel.GetMainTableColumnProperties(TableName)
            TableProperties = tableColumnPropertyList.ToArray
            TableDefaultFieldValues = Model.GetDefaultFieldValues(TableName)
        End If
    End Sub

    Public Function GetBizObjectRules()
        Return BizObject.GetRules()
    End Function

    Public Function GetBizObjectErrors()
        Return BizObject.GetErrors()
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

    '    Private Shared Function GetRecordNumberValue(idNo As Integer) As Integer
    '        Try
    '            Return GetRecordPosition(idNo)
    '        Catch ex As Exception
    '            Return 0
    '        End Try
    '    End Function

    Public Function GetSortedRecordNumber(recordNo As Integer) As Integer
        Try
            Return Model.GetSortedRecordNumber(recordNo, TableName, SortOrderKey)
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

    Public Shared Function GetRecordPosition(idNo As Integer)
        Try
            Return Model.GetRecordPosition(TableName, idNo) + 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function GetTableProperties() As List(Of TblColPropModel)
        Return Model.GetMainTableColumnProperties(TableName)
    End Function

    Public Property NewlyAddedRecordIdNo As Integer

    Public Function DeleteRecord(idNo As Integer) As Integer
        Try
            Return Model.DeleteRecord(idNo, TableName)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Overridable Overloads Sub MakeView(ByRef viewObject As List(Of TM), dataSortOrder As String)
        Dim xModel As New TM
        Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of TM)(dataSortOrder, xModel)
        'Dim newSortOrderKey As String = dataSortOrder
        'newSortOrderKey = GetTranslatedField(newSortOrderKey)
        Dim modelData = Model.GetAll(Of TM)(newSortOrderKey)
        viewObject.Clear()
        For Each modData In modelData
            viewObject.Add(modData)
        Next
    End Sub

    'Public Overridable Overloads Sub MakeView(ByRef viewObject As List(Of TM), ByVal dataSortOrder As String)
    '    Dim sortExpression As String = dataSortOrder
    '    sortExpression = GetTranslatedField(dataSortOrder)
    '    Dim modData = Model.GetAll(Of TM)(sortExpression)
    '    viewObject.Clear()
    '    For Each mData In modData
    '        Dim modelTm As TM
    '        MapObject(modData, modelTb)
    '        viewObject.Add(modData)
    '    Next
    'End Sub

    Public Overridable Overloads Sub Display(idNo As Integer, Optional ByVal undoMode As Boolean = False)
        Dim modelData
        modelData = Model.GetRecordById(Of TM)(idNo)
        If modelData IsNot Nothing Then
            MapObject(modelData, View)
            MapObject(modelData, OriginalModel)
        End If
    End Sub

    Public Function GetTreeViewData(sortKey As String) As Object
        Dim xModel As New TM
        Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of TM)(sortKey, xModel)
        Dim modelData = Model.GetAll(Of TM)(newSortOrderKey)
        If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
            TreeViewList.Clear()
        End If
        For Each modData In modelData
            Dim modelTb As New TM
            MapObject(modData, modelTb)
            TreeViewList.Add(modelTb)
        Next
        Return TreeViewList
    End Function

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

        If addMode Then
            NewlyAddedRecordIdNo = Model.AddRecord(Of TBiz)(BizObject)
            retVal = NewlyAddedRecordIdNo
        Else
            retVal = Model.UpdateRecord(BizObject)
        End If
        Return retVal
    End Function

    Public Overridable Function BeforeSave(ByRef addMode As Boolean)
        Return True
        'Dim retVal As Integer

        'If addMode Then
        '    NewlyAddedRecordIdNo = Model.AddRecord(Of TBiz)(BizObject)
        '    retVal = NewlyAddedRecordIdNo
        'Else
        '    retVal = Model.UpdateRecord(BizObject)
        'End If
        'Return retVal
    End Function

    Public Overridable Function DataIsValid()
        MapObject(View, BizObject)
        If BizObject.IsValid() Then
            Return True
        End If
        Return False
    End Function

    Public Sub ShowErrors()
        Dim errorList = ""
        For Each bizError In BizObject.Errors
            If errorList.Contains(bizError & Environment.NewLine) Then
                ' don't add duplicate message
            Else
                errorList = errorList & bizError & Environment.NewLine
            End If
        Next
        MessageBox.Show(errorList)
    End Sub

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

    Public Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList
        Try
            Return Model.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetOriginalValue(ByRef control As Object) As String
        Dim retVal = ""
        ' ReSharper disable VBPossibleMistakenCallToGetType.2
        Dim type As Type = OriginalModel.GetType()
        ' ReSharper restore VBPossibleMistakenCallToGetType.2
        Dim properties As PropertyInfo() = type.GetProperties()
        For Each [property] As PropertyInfo In properties
            If [property].Name.ToLower() = control.Name.ToString().Substring(3).ToLower() Then
                retVal = [property].GetValue(OriginalModel)
                Exit For
            End If
        Next
        Return retVal
    End Function

    Public Function CheckIfUnique(textValue As String, fieldName As String, targetIdNo As Int32) As Boolean
        If Model.CheckIfUnique(textValue, TableName, fieldName, targetIdNo) Then
            Return True
        End If
        Return False
    End Function

    Public Function IsUnique(textValue As String, fieldName As String) As Boolean
        Dim idNo = DirectCast(BizObject.IdNo, Integer)
        If Model.IsUnique(textValue, TableName, fieldName, idNo) Then
            Return True
        End If
        Return False
    End Function

    Public Overridable Function ChangesMade() As Boolean
        Return Not ObjectsCompare(OriginalModel, View)
    End Function

    Public Sub MapObject(Of TS, TT)(ByRef source As TS, ByRef target As TT,
                                     Optional ByVal fieldsDictionary As Dictionary(Of String, String) = Nothing)
        Dim tPropertyInfos = target.GetType().GetProperties()
        Dim sPropertyInfos = source.GetType().GetProperties()
        Dim comparer = StringComparer.OrdinalIgnoreCase
        Dim tDictionary = New Dictionary(Of String, Int16)(comparer)
        Dim sDictionary = New Dictionary(Of String, Int16)(comparer)
        Dim i As Int16 = 1
        For Each propertyInfo As PropertyInfo In tPropertyInfos
            Dim pName = propertyInfo.Name
            tDictionary.Add(pName, i)
            i = i + 1
        Next
        i = 1
        For Each propertyInfo As PropertyInfo In sPropertyInfos
            Dim pName = propertyInfo.Name
            sDictionary.Add(pName, i)
            i = i + 1
        Next
        Dim sourcePropertyName As String
        Dim targetPropertyName = ""
        For Each s As PropertyInfo In sPropertyInfos
            sourcePropertyName = s.Name
            If sourcePropertyName = $"datecreated" Then
                Debugger.Break()
            End If
            If fieldsDictionary IsNot Nothing Then
                fieldsDictionary.TryGetValue(s.Name, targetPropertyName)
                If targetPropertyName Is Nothing Then
                    targetPropertyName = sourcePropertyName
                End If
            Else
                targetPropertyName = sourcePropertyName
            End If
            Dim iIndex As Int16
            Dim t As PropertyInfo
            tDictionary.TryGetValue(targetPropertyName, iIndex)
            'If s.Name.ToLower() = "distributionschemeitems" Then
            '    Debugger.Break()
            'End If
            ' the above procedure will give a iIndex of zero if "targetPropertyName" is not found
            ' but 0 is also a valid return value for array
            ' so to avoid this I used 1 as the base value for index and just subtract 1 when gettning the desired value
            If iIndex <> 0 Then
                t = tPropertyInfos(iIndex - 1)  ' subtract 1 since base value started with 1
                'MessageBox.Show(t.GetIndexParameters().ToString())
                If Not TypeOf s.GetValue(source) Is ICollection Then
                    t.SetValue(target, s.GetValue(source))
                End If

            End If
        Next
    End Sub

    'Public Sub MapObject(Of TS, TT)(ByRef source As TS, ByRef target As TT, ByVal Optional fieldsDictionary As Dictionary(Of String, String) = nothing)
    '    Dim tPropertyInfos = target.GetType().GetProperties()
    '    Dim comparer = StringComparer.OrdinalIgnoreCase
    '    Dim tDictionary = New Dictionary(Of String, Int16)(comparer)
    '    Dim i As Int16 = 0
    '    For Each propertyInfo As PropertyInfo In tPropertyInfos
    '        Dim pName = propertyInfo.Name
    '        tDictionary.Add(pName, i)
    '        i = i + 1
    '    Next
    '    If source IsNot Nothing Then
    '        Dim sPropertyInfos = source.GetType().GetProperties()
    '        Dim sDictionary = New Dictionary(Of String, Int16)(comparer)
    '        i = 0
    '        For Each propertyInfo As PropertyInfo In sPropertyInfos
    '            Dim pName = propertyInfo.Name
    '            sDictionary.Add(pName, i)
    '            i = i + 1
    '        Next
    '        Dim propertyName As String
    '        Dim j As Int16 = 0
    '        For Each s As PropertyInfo In sPropertyInfos
    '            propertyName = s.Name
    '            If tDictionary.ContainsKey(propertyName) Then
    '                Dim x = tDictionary(propertyName)
    '                Dim t = tPropertyInfos(x)
    '                t.SetValue(target, s.GetValue(source))
    '            End If
    '            'For Each s As PropertyInfo In source.GetType().GetProperties()
    '            '    If propertyInfo.Name.ToLower().Trim() = s.Name.ToLower().Trim() Then
    '            '        If propertyInfo.CanWrite Then
    '            '            'If propertyInfo.Name.ToLower() = "MessageKey" Then
    '            '            '    Debugger.Break()
    '            '            'END IF
    '            '            If Not TypeOf s.GetValue(source) Is ICollection Then
    '            '                propertyInfo.SetValue(target, s.GetValue(source))
    '            '            End If
    '            '        End If
    '            '        Exit For
    '            '    End If
    '            'Next
    '        Next

    '        'Dim propertyInfos = target.GetType().GetProperties()
    '        'For Each propertyInfo As PropertyInfo In propertyInfos
    '        '    For Each s As PropertyInfo In source.GetType().GetProperties()
    '        '        If propertyInfo.Name.ToLower().Trim() = s.Name.ToLower().Trim() Then
    '        '            If propertyInfo.CanWrite Then
    '        '                'If propertyInfo.Name.ToLower() = "MessageKey" Then
    '        '                '    Debugger.Break()
    '        '                'END IF
    '        '                If Not TypeOf s.GetValue(source) Is ICollection Then
    '        '                    propertyInfo.SetValue(target, s.GetValue(source))
    '        '                End If
    '        '            End If
    '        '            Exit For
    '        '        End If
    '        '    Next
    '        'Next
    '    End If
    'End Sub

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
        EnumConverter = TypeDescriptor.GetConverter(GetType(TE))
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

    'Public Sub MakeEnumList(Of TE)(ByRef tcbComboBox As TxtComboBox)
    '    EnumConverter = TypeDescriptor.GetConverter(GetType(TE))
    '    Dim dataList As New List(Of ClassesLibrary.LookupData)
    '    'Dim enumValues = [Enum].GetValues(GetType(TE))
    '    For Each c In [Enum].GetValues(GetType(TE))
    '        Dim data As New ClassesLibrary.LookupData
    '        data.IdNo = CInt(c)
    '        data.Name = EnumConverter.GetValueText(CultureInfo.CurrentCulture, c)
    '        dataList.Add(data)
    '    Next
    '    tcbComboBox.ValueMember = "IDNo"
    '    tcbComboBox.DisplayMember = "Name"
    '    tcbComboBox.DataSource = dataList
    'End Sub

    Public Function MakeEnumComboList(Of TE)()
        EnumConverter = TypeDescriptor.GetConverter(GetType(TE))
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
                    CallByName(View, item.FieldName, CallType.Set, CDate(item.DefaultValue))
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
                        $"Default Value Datatype Conversion for Field " & item.FieldName & $" in table " &
                        item.TableName & $" conversion not handled")
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
End Class
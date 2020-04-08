Imports System.ComponentModel
Imports System.Globalization
Imports System.Linq.Expressions
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Transactions
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.EnumLocalization
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Languages
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views
Imports KellermanSoftware.CompareNetObjects

''' <summary>
'''     Base class for all presenter classes. Keeps track of Model and View classes.
'''     Notice that Model is static and View is set in the constructor.
''' </summary>
''' <remarks>
'''     MV Patterns: MVP design pattern.
''' </remarks>
''' <typeparam name="T">Type of view.</typeparam>
Public MustInherit Class Presenter(Of T As IView, TM As New)
    Implements ISubscriber(Of SelectedButton)

    Public ChildPresenters As New List(Of Object)
    Friend DateTimeStampField As String = "DateTimeStamp"
    Friend RecordDateTimeStampValue As Object
    Protected DataModel
    Protected DataService
    Protected DbDataDao
    Protected IdFieldName As String = "IdNo"
    Protected OriginalModel
    Protected SortOrderKey As String = "IdNo"
    Protected TreeViewList
    Protected TreeViewMainField As String
    Protected TreeViewParentIdField As String
    Protected TreeViewSecondaryField As String
    Private _addMode As Boolean = False
    Private _debugSwitch As Byte = 0
    Private _editMode As Boolean = False
    Private _errorList As String = ""
    Private _recordPositionNumber As Integer = 0
    Private _tableColumnPropertyList As List(Of TblColPropModel)
    Private _tableDefaultFieldValueList As List(Of DefaultFieldValueModel)
    Private _targetIdNo As Integer = 0

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

    Shared Sub New()
        Model = New Model()
        ModelTblColProp = New ModelTblColProp
        ModelDefaultFieldValue = New ModelDefaultFieldValue
    End Sub

    Public Sub New(view As T)
        GlobalVariables.EventAggregator.SubscribeEvent(Me)
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

    Public Event AddingRecordChanged(adding As Boolean)

    Public Event AfterAdd()

    Public Event AfterDelete()

    Public Event AfterDisplayView()

    Public Event AfterEdit()

    Public Event AfterSave()

    Public Event BeforeAdd()

    Public Event BeforeDelete()

    Public Event BeforeDisplayView()

    Public Event BeforeEdit()

    Public Event BeforeSave()

    Public Event BeforeValidate()

    Public Event CancelChanges()

    Public Event DisplayedRecordChanged()

    Public Event EditingRecordChanged(editing As Boolean)

    Public Event ParentRecordAddedSuccessfully(idNoOfRecord As Integer)

    Public Event ParentRecordUpdatedSuccessfully(idNoOfRecord As Integer)

    Public Event SuccessfulAdd(idNoOfSavedRecord As Integer)

    Public Event SuccessfulDelete(idNoOfDeletedRecord As Integer)

    Public Event SuccessfulUpdate(idNoOfAddedRecord As Integer)

    Public Event TextDisplayChanged()

    Public Event UndoEdits(addingRec As Boolean)

    Public Property AddMode As Boolean
        Set
            If _addMode <> Value Then
                _addMode = Value
            End If
            GlobalVariables.EventAggregator.PublishEvent(New AddModeChanged(Value))
        End Set
        Get
            Return _addMode
        End Get
    End Property

    Public Property AutoValidationsPassed As Boolean = False
    Public Property CancelDelete As Boolean = False
    Public Property CancelEdit As Boolean = False
    Public Property CancelSave As Boolean = False
    Public Property CurrentSortKeyValue As String

    Public Property EditMode As Boolean
        Set
            If _editMode <> Value Then
                _editMode = Value
            End If
            GlobalVariables.EventAggregator.PublishEvent(New EditModeChanged(Value))
        End Set
        Get
            Return _editMode
        End Get
    End Property

    Public Property EnumConverter As ResourceEnumConverter

    '<Description("This is the last IDNo of the Displayed record before moving to a different record.")>
    'Public Property CurrentIdNo As Integer
    Public Property LastIdNo As Integer

    Public Property ModelPresenter
        Get
            Return Model
        End Get
        Set(value)
            Model = value
        End Set
    End Property

    Public Property NewlyAddedRecordIdNo As Integer
    Public Shared Property RecordCount As Integer

    Public Property RecordPositionNumber As Integer
        Get
            Return _recordPositionNumber
        End Get
        Set(value As Integer)
            _recordPositionNumber = value
            TargetIdNo = GetIdNoOfSortedPositionNumber(RecordPositionNumber)
        End Set
    End Property

    Public Shared Property TableDefaultFieldValues As List(Of DefaultFieldValueModel)
    Public Shared Property TableName As String
    Public Shared Property TableProperties As Array

    'Public Property TableDefaultFieldValues
    <Description("This is the value of the current IDNo in the TxtIDNo Field ")>
    Public Property TargetIdNo As Integer
        Get
            Return _targetIdNo
        End Get
        Set(value As Integer)
            _targetIdNo = value
            UpdateViewDisplay(value)
            GlobalVariables.EventAggregator.PublishEvent(New RecordPositionChanged(value))
        End Set
    End Property

    Private Sub GoUndoChanges()
        If OkToMove() Then
            'RaiseEvent UndoEdits(True)
            UndoMode = True
            If AddMode Then
                AddMode = False
                RecordPositionNumber = GetSortedRecordPosition(LastIdNo)
            Else
                EditMode = False
            End If
        End If
        UndoMode = False
        'CancelClose = True
    End Sub

    Public Property View As T
    Protected Shared Property Model As New Model()
    Protected Shared Property ModelDefaultFieldValue As IModelDefaultFieldValue
    Protected Shared Property ModelTblColProp As IModelTblColProp

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

    Public Sub AddChildPresenter(obj As Object)
        ChildPresenters.Add(obj)
    End Sub

    Public Overridable Function ChangesMade() As Boolean
        Dim retVal As Boolean = False
        Dim compareLogic As New CompareLogic()
        compareLogic.Config.IgnoreObjectTypes = True
        compareLogic.Config.MaxDifferences = 100
        compareLogic.Config.CompareChildren = True
        Dim result As ComparisonResult = compareLogic.Compare(OriginalModel, View)
        If Not result.AreEqual Then
            Messaging.Show(result.DifferencesString, "Differences")
            retVal = True
        End If
        Return retVal
    End Function

    Public Function CheckIfUnique(textValue As String, fieldName As String, targetIdNo As Int32) As Boolean
        If Model.CheckIfUnique(textValue, TableName, fieldName, targetIdNo) Then
            Return True
        End If
        Return False
    End Function

    Public Function CountRecordWithKey(searchValue As String, searchFieldName As String) As Integer
        Try
            Return Model.CountRecordWithKey(searchValue, TableName, searchFieldName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function DeleteRecord(idNo As Integer) As Integer
        Try
            Return Model.DeleteRecord(idNo, TableName)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Overridable Function DeleteRecord() As Integer
        If _debugSwitch Then
            Debugger.Break()
        End If
        Dim retValue = 0
        Dim currentIdNo = GetPropertyValue(Me, IdFieldName)
        If IsOkToDeleteRecord(currentIdNo) Then
            If Messaging.Show(True, "AskIfDeleteRecord", "Are you sure you want to delete this record?", "Please Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                RaiseEvent BeforeDelete()
                retValue = DeleteRecord(currentIdNo)
                If retValue <= 0 Then
                    Messaging.Show(True, "MsgDeleteRecordFailed", "This record was not deleted because of an error. Please try again later or ask Database Administrator for help.", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    RaiseEvent SuccessfulDelete(currentIdNo)
                    Messaging.Show(True, "MsgRecordSuccessfullyDeleted", "Record was successfully deleted.", "Record Deleted")
                    ' if deleted stay on that given RecordPositionNumber
                    ' which in this case will be the next record after the deleted record
                    TargetIdNo = GetIdNoOfSortedPositionNumber(RecordPositionNumber)
                    UpdateViewDisplay(TargetIdNo)
                    RaiseEvent DisplayedRecordChanged()
                End If
                RaiseEvent AfterDelete()
            End If
        End If
        Return retValue
    End Function

    Public Sub EditRecord()
        If _debugSwitch Then
            Debugger.Break()
        End If
        RaiseEvent BeforeEdit()
        If CancelEdit Then
            CancelEdit = False
        Else
            EditMode = True
            AddMode = False
        End If
        RaiseEvent AfterEdit()
    End Sub

    Public Sub FindField(fieldName, searchString, searchAnywhere)
        Dim idNo = Model.FindField(TableName, fieldName, searchString, searchAnywhere)
        RecordPositionNumber = GetSortedRecordPosition(idNo)
    End Sub

    Public Function FindFieldContinue(idNo As Integer) As Integer
        Return Model.FindFieldContinue(TableName, idNo)
    End Function

    Public Function GetBizObjectErrors() As List(Of String)
        Return Model.GetBizObjectErrors()
    End Function

    'Public Shared SecurityModel As New Model
    Public Function GetBizObjectRules()
        Return Model.GetBizObjectRules()
    End Function

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

    Public Function GetIdNoOfSortedPositionNumber(recordNo As Integer) As Integer
        Try
            Return Model.GetIdNoOfSortedPositionNumber(recordNo, TableName, SortOrderKey)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetOriginalModel() As TM
        Return OriginalModel
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

    Public Function GetRecordCount() As Integer
        Try
            Return Model.GetRecordCount(TableName)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    'Public Function FindField(txtControl As Control) As Integer
    '    If _debugSwitch Then
    '        Debugger.Break()
    '    End If
    '    If PresenterObj.OkToMove("FindField") Then
    '        Dim idNoOfFoundRecord As Integer
    '        idNoOfFoundRecord = PresenterObj.FindField(txtControl)
    '        If idNoOfFoundRecord = 0 Then
    '            _MBTextToFindNotFound.Show(Me, GetPropertyValue(txtControl, "GetTextToSearch"))
    '            btnFind.Enabled = False
    '        Else
    '            btnFind.Enabled = True
    '            PresenterObj.TargetIdNo = idNoOfFoundRecord
    '            PresenterObj.RecordPositionNumber = PresenterObj.GetSortedRecordPosition(PresenterObj.TargetIdNo)
    '            PresenterObj.UpdateViewDisplay(PresenterObj.TargetIdNo)
    '            RaiseEvent DisplayedRecordChanged()
    '        End If
    '        CancelClose = True
    '    End If
    '    Return PresenterObj.TargetIdNo
    'End Function
    Public Function GetRecordDateTimeStamp(idNo As Integer) As Object
        Try
            Return Model.GetRecordDateTimeStamp(idNo, TableName)
        Catch ex As Exception
            Return Nothing
        End Try
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

    Public Function GetRecordPosition(idNo As Integer)
        Try
            Return Model.GetRecordPosition(TableName, idNo) + 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetRecordWithIdNo(idNo As Integer, returnFieldName As String) As String
        Try
            Return Model.GetRecordWithIdNo(idNo, TableName, returnFieldName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetSortedRecordPosition(idNo As Integer) As Integer
        Try
            Return Model.GetSortedRecordPosition(idNo, TableName, SortOrderKey)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetSqlValue(Of TType)(sqlStatement As String, cTableName As String, condition As String) As TType
        Try
            Return Model.GetSqlValue(Of TType)(sqlStatement, cTableName, condition)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetTableProperties() As List(Of TblColPropModel)
        Return ModelTblColProp.GetMainTableColumnProperties(TableName)
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
                Return Model.GetHRecords(TableName, newSortOrderKey,
                                      {"IdNo", treeMainFieldName, TreeViewParentIdField, TreeViewSecondaryField})
            End If
        End If
    End Function

    Public Sub GoFirstRecord()
        If _debugSwitch Then
            Debugger.Break()
        End If
        If OkToMove() Then
            RecordPositionNumber = 1
        End If
    End Sub

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

    Public Overridable Function IsOkToDeleteRecord(idNo As Integer) As Boolean
        Dim retValue As Boolean = False
        If Not DependentRecordsExist(idNo) Then
            retValue = True
        End If
        Return retValue
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

    Public Overridable Function OkToMove() As Boolean
        Dim retValue As Boolean
        If Not (EditMode OrElse AddMode) Then
            retValue = True
        Else
            If ChangesMade() Then
                Dim result = SaveOrAbandonChanges()
                If result = DialogResult.Yes Then
                    'Save()
                    retValue = True
                ElseIf result = DialogResult.No Then
                    If AddMode Then
                        AddMode = False
                        TargetIdNo = LastIdNo
                    Else
                        EditMode = False
                    End If
                    UpdateViewDisplay(TargetIdNo)
                    retValue = True
                Else
                    retValue = False
                End If
            Else
                retValue = True
            End If
        End If
        Return retValue
    End Function

    Public Sub OnEventHandler(e As SelectedButton) Implements ISubscriber(Of SelectedButton).OnEventHandler
        Select Case e.ClickedButton
            Case ButtonClicked.First
                GoFirstRecord()
            Case ButtonClicked.Next
                GoNextRecord()
            Case ButtonClicked.Previous
                GoPreviousRecord()
            Case ButtonClicked.Last
                GoLastRecord()
            Case ButtonClicked.Find
                GoFindRecord()
            Case ButtonClicked.Undo
                GoUndoChanges()
            Case ButtonClicked.Add
                GoAddRecord()
            Case ButtonClicked.Delete
                GoDeleteRecord()
            Case ButtonClicked.Edit
                GoEditRecord()
            Case ButtonClicked.Q
                'UndoChanges()
        End Select
    End Sub

    Public Overridable Function Save()
        Dim retVal As Integer
        Dim record As New TM
        GlobalVariables.Mapper.Map(Of IView, TM)(View, record)
        If AddMode Then
            retVal = AddRecord(record)
        Else
            retVal = UpdateRecord(record)
        End If
        'If retVal > 0 Then
        '    Dim lRetVal As Integer
        '    lRetVal = SaveChildren(PresenterObj.AddMode, retVal)
        '    If lRetVal < 0 Then
        '        retVal = lRetVal
        '    End If
        'End If
        Return retVal
    End Function

    Public Sub SaveOriginalValues()
        GlobalVariables.Mapper.Map(Of T, TM)(Me.View, Me.OriginalModel)
        For Each item In ChildPresenters
            item.SaveOriginalValues()
        Next
    End Sub

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

    Public Overridable Sub UpdateViewDisplay(idNo As Integer)
        If idNo <> 0 Then
            Dim modelData
            RecordCount = GetRecordCount()
            RecordDateTimeStampValue = GetRecordDateTimeStamp(TargetIdNo)
            modelData = ModelPresenter.GetRecordById(Of TM)(idNo)
            GlobalVariables.Mapper.Map(Of TM, T)(modelData, View)
            For Each child In ChildPresenters
                child.UpdateViewDisplay(idNo)
            Next
            SaveOriginalValues()
            EditMode = False
            AddMode = False
            UndoMode = False
        End If
    End Sub

    Protected Overridable Function AdditionalChangesMadeCheck()
        Return False
    End Function

    'Public Overridable Function DataIsValid() As Boolean
    '    Dim retVal = False
    '    GlobalVariables.Mapper.Map(Of T, TM)(View, DataModel)
    '    If Model.IsValid(DataModel) Then
    '        retVal = True
    '    End If
    '    Return retVal
    'End Function

    Protected Overridable Function AddRecord(record As TM) As Integer
        Dim retVal As Integer
        NewlyAddedRecordIdNo = ModelPresenter.AddRecord(record)
        retVal = NewlyAddedRecordIdNo
        CallByName(View, "IdNo", CallType.Set, retVal)
        Return retVal
    End Function

    Protected Overridable Function DataIsValid() As Boolean
        Dim retValue As Boolean = False
        Dim validated As Boolean = False
        RaiseEvent BeforeValidate()
        ' check first if automatic rules are valid
        GlobalVariables.EventAggregator.PublishEvent(New ValidatingData(validated))
        If validated Then
            If DataIsValid() Then
                retValue = True
            Else
                Dim lErrors = GetBizObjectErrors()
                GlobalVariables.EventAggregator.PublishEvent(New PassErrorList(lErrors))
                Beep()
                ShowErrors("Record not saved!")
            End If
        End If
        Return retValue
    End Function

    Protected Overridable Function DependentRecordsExist(masterIdNo As Integer) As Integer
        Return 0
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

    Protected Sub GoLastRecord()
        If _debugSwitch Then
            Debugger.Break()
        End If
        If OkToMove() Then
            RecordPositionNumber = GetRecordCount()
        End If
    End Sub

    Protected Sub GoNextRecord()
        If _debugSwitch Then
            Debugger.Break()
        End If
        If OkToMove() Then
            If RecordPositionNumber = RecordCount Then
                Messaging.Show(True, "MsgLastRecordHit", "This is already the last record.", "Last Record")
            Else
                RecordPositionNumber += 1
            End If
        End If
    End Sub

    Protected Sub GoPreviousRecord()
        If _debugSwitch Then
            Debugger.Break()
        End If
        If OkToMove() Then
            If RecordPositionNumber = 1 Or RecordPositionNumber = 0 Then
                Messaging.Show(True, "MsgFirstRecordHit", "This is already the first record.", "First Record")
            Else
                RecordPositionNumber -= 1
            End If
        End If
    End Sub

    Protected Function OkToSaveRecord() As Boolean
        Dim retValue As Boolean = False
        If Not AddMode Then
            If HasRecordChanged(TargetIdNo, RecordDateTimeStampValue) Then
                Messaging.Show(True, "MsgRecordChangedSinceLastRetrieval", "Record Has Changed since you last retrieved the record, cannot save your modifications. Please refresh the record and try again.", "Someone changed the record!")
                Return False
            Else
                'If Not ChangesMade() Then
                '    _MBNoChangesMadeNothingToSave.Show(Me)
                '    Return False
                'End If
            End If
        End If
        If DataIsValid() Then
            retValue = True
        End If
        Return retValue
    End Function

    'Protected Overridable Function SaveChildren(addMode As Boolean, retVal As Integer) As Integer
    '    For Each child In ChildPresenters
    '        retVal = child.Save(AddMode)
    '        If retVal <= 0 Then
    '            Exit For
    '        End If
    '    Next
    '    Return retVal
    'End Function

    Protected Function SaveOrAbandonChanges() As DialogResult
        Dim result As DialogResult
        result = Messaging.Show(True, "AskIfUserWantsToSaveOrContinueEdits",
                                "Changes have been made to this record.  Press [Yes] to save changes, [No] to Abandon changes, or press [Cancel] to continue editing record? Save Changes?",
                                "Please Confirm.",
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button3)
        Return result
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

    Protected Sub Undo()
        If ChangesMade() Then
            Dim result As DialogResult
            result = SaveOrAbandonChanges()
            If result = DialogResult.Yes Then
                Save()
                AddMode = False
                EditMode = False
                UpdateViewDisplay(TargetIdNo)
            ElseIf result = DialogResult.No Then
                ' undo changes retrieve the last record
                If AddMode Then
                    AddMode = False
                    TargetIdNo = LastIdNo
                Else
                    EditMode = False
                End If
                UpdateViewDisplay(TargetIdNo)
            Else
                ' DialogResult.Cancel
                ' don't do anything just continue edits
            End If
        Else
            AddMode = False
            EditMode = False
            UpdateViewDisplay(TargetIdNo)
        End If
    End Sub

    Protected Overridable Function UpdateRecord(record As TM) As Integer
        Return Model.UpdateRecord(record)
    End Function

    Private Function FindRecord() As Integer
        If _debugSwitch Then
            Debugger.Break()
        End If
        Dim idNoOfFoundRecord As Integer = 0
        If OkToMove() Then
            idNoOfFoundRecord = FindFieldContinue(TargetIdNo)
        End If
        Return idNoOfFoundRecord
    End Function

    'Private Function GetRecordNumberValue(idNo As Integer) As Integer
    '    Try
    '        Return GetRecordPosition(idNo)
    '    Catch ex As Exception
    '        Return 0
    '    End Try
    'End Function

    Private Sub GoAddRecord()
        LastIdNo = GetPropertyValue(Me, IdFieldName)
        Try
            If _debugSwitch Then
                Debugger.Break()
            End If
            MakeDefaultValues()
            AddMode = True
            EditMode = False
            RaiseEvent BeforeAdd()
        Catch oEx As Exception
            MsgBox("Error:   " + oEx.Message)
            AddMode = False
        End Try
    End Sub

    Private Sub GoFindRecord()
        Dim idNoOfFoundRecord = FindRecord()
        If FindRecord() = 0 Then
            If Messaging.Show(True, "AskLastRecordReachedStartFromBeginning", "This is the last matching record for the given text. Do you want to start search from the first record?", "Last Record Found.",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                idNoOfFoundRecord = FindFieldContinue(1)
                RecordPositionNumber = GetSortedRecordPosition(idNoOfFoundRecord)
            Else
                '' stay on the current record
            End If
        Else
            RecordPositionNumber = GetSortedRecordPosition(idNoOfFoundRecord)
        End If
        If EditMode Then
            EditMode = False
        End If
    End Sub

    'Private Sub InitiateSave(ByVal sender As Object, ByVal e As WaitWindowEventArgs)
    Private Function InitiateSave(retValue As Short) ' As Short
        Try
            Using scope As New TransactionScope(TransactionScopeOption.Required, New TimeSpan(0, 1, 0))
                retValue = Save(AddMode)
                If retValue <= 0 Then
                    '_MBRecordNotSaved.Show(Me)
                Else
                    If AddMode Then
                        RaiseEvent ParentRecordAddedSuccessfully(retValue)
                        TargetIdNo = retValue
                        RaiseEvent SuccessfulAdd(retValue)
                        'PresenterObj.AddMode = False
                    Else
                        ' Using scope As New TransactionScope(TransactionScopeOption.RequiresNew)
                        RaiseEvent ParentRecordUpdatedSuccessfully(retValue)
                        RaiseEvent SuccessfulUpdate(retValue)
                        'PresenterObj.EditMode = False
                    End If

                End If
                scope.Complete()
                'If retValue > 0 Then
                '    _MBRecordSuccessfullySaved.Show(Me)
                'End If
            End Using
        Catch ex As TransactionAbortedException
            MessageBox.Show(ex.Message, StringWords.Transaction_Aborted)
        Catch oEx As Exception

            If oEx.Message.Contains("Timeout Expired") Then
                retValue = -1
            Else
                MsgBox("Error:   " + oEx.Message)
                retValue = -1
            End If
            Debugger.Break()

        End Try

        Return retValue
    End Function

    Private Function IsRecordNotUnique(cCtrl As Control, fldName As String) As Boolean
        If CheckIfUnique(cCtrl.Text, fldName, TargetIdNo) Then
            Return False
        End If
        Return True
    End Function

    'Public Sub FindFieldContinue(recIdKey As Integer)
    '    If _debugSwitch Then
    '        Debugger.Break()
    '    End If
    '    If OkToMove() Then
    '        TargetIdNo = FindFieldContinue(TargetIdNo)
    '        If TargetIdNo <> 0 Then
    '            RecordPositionNumber = GetSortedRecordPosition(TargetIdNo)
    '            UpdateViewDisplay(TargetIdNo)
    '        End If
    '        CancelClose = True
    '    End If
    'End Sub

#Region "GetLookupTable"

    Protected Property DisplayCode As String
    Protected Property DisplayName As String
    Protected Property DisplayNameArabic As String
    Protected Property FieldsToShow As String()
    Protected Property FilterKey As String = Nothing
    Protected Property SortExpression As String
    Protected Property TableToGet As String

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

    Protected Function GetLookupFilteredData()
        FormatFields()
        Return Model.GetLookupFilteredDataByName(TableToGet, SortExpression, FilterKey, FieldsToShow)
    End Function

    Protected Function GetLookupFilteredDataByCode()
        FormatFields()
        Return Model.GetLookupFilteredDataByCode(TableToGet, SortExpression, FilterKey, FieldsToShow)
    End Function

    Protected Function GetLookupFilteredDataByName()
        FormatFields()
        Return Model.GetLookupFilteredDataByName(TableToGet, SortExpression, FilterKey, FieldsToShow)
    End Function

    Protected Function GetTableList()
        FormatFields()
        Return Model.GetRecords(TableToGet, SortExpression, FieldsToShow)
    End Function

    Protected Function GetTableListFiltered()
        FormatFields()
        Return Model.GetRecordsFiltered(TableToGet, SortExpression, FilterKey, FieldsToShow)
    End Function

#End Region

    'Public Sub Save()
    '    If _debugSwitch Then
    '        Debugger.Break()
    '    End If
    '    If OkToSaveRecord() Then
    '        BeforeSave()
    '        Dim retValue As Short
    '        Try
    '            Using scope As New TransactionScope(TransactionScopeOption.Required, New TimeSpan(0, 1, 0))
    '                retValue = Save(PresenterObj.AddMode)
    '                If retValue > 0 Then
    '                    If PresenterObj.AddMode Then
    '                        RaiseEvent ParentRecordAddedSuccessfully(retValue)
    '                        AddChildren()
    '                        TargetIdNo = retValue
    '                        RaiseEvent SuccessfulAdd(retValue)
    '                    Else
    '                        UpdateChildren(retValue)
    '                        RaiseEvent ParentRecordUpdatedSuccessfully(retValue)
    '                        RaiseEvent SuccessfulUpdate(retValue)
    '                    End If
    '                End If
    '                scope.Complete()
    '            End Using
    '        Catch ex As TransactionAbortedException
    '            MessageBox.Show(ex.Message, StringWords.Transaction_Aborted)
    '        Catch oEx As Exception
    '            If oEx.Message.Contains("Timeout Expired") Then
    '                retValue = -1
    '            Else
    '                MsgBox("Error:   " + oEx.Message)
    '                retValue = -1
    '            End If
    '            Debugger.Break()
    '        End Try
    '        If retValue > 0 Then
    '            AfterSave()
    '            ' redisplay the updated record to reflect changes and to put record in viewmode
    '            sUpdateViewDisplay(TargetIdNo)
    '            _MBRecordSuccessfullySaved.Show(Me)
    '        End If
    '    End If
    'End Sub

#Region "Temporary"

    Public Overridable Sub Display(idNo As Integer)
        '
    End Sub

#End Region

End Class

#Region "Other Classes"

Public Enum ButtonClicked
    [Add]
    [Delete]
    [Edit]
    [Find]
    [First]
    [Last]
    [Next]
    [Previous]
    [Quit]
    [Save]
    [Undo]
End Enum

Public Class AddModeChanged

    Public Sub New(ByVal addMode As Boolean)
        Me.AddMode = addMode
    End Sub

    Public Property AddMode As Boolean

End Class

Public Class EditModeChanged

    Public Sub New(ByVal editMode As Boolean)
        Me.EditMode = editMode
    End Sub

    Public Property EditMode As Boolean

End Class

Public Class RecordPositionChanged

    Public Sub New(ByRef recPos)
        RecordPosition = recPos
    End Sub

    Public Property RecordPosition

End Class

Public Class SelectedButton

    Public Sub New(ByVal clickedButton As ButtonClicked)
        Me.ClickedButton = clickedButton
    End Sub

    Public Property ClickedButton As ButtonClicked

End Class

Public Class ValidatingData

    Public Sub New(ByRef validated As Boolean)
        Me.Validated = validated
    End Sub

    Public Property Validated

End Class

Public Class PassErrorList

    Public Sub New(ByRef errors As List(Of String))
        Me.Errors = errors
    End Sub

    Public Property Errors As List(Of String)

End Class

#End Region
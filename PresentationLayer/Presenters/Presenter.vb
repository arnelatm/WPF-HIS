Imports System.ComponentModel
Imports System.Globalization
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Transactions
Imports System.Windows.Forms
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
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
''' <typeparam name="T">Type of itemView.</typeparam>
Public MustInherit Class Presenter(Of T As IView, TM As New)
    Implements ISubscriber(Of SelectedButton)

    Public ChildPresenters As New List(Of Object)
    Public ChildModels As New List(Of Object)
    Public IdFieldName As String = "IdNo"
    Friend DateTimeStampField As String = "DateTimeStamp"
    Friend RecordDateTimeStampValue As Object
    Protected CompareDifferences As String
    Protected DataModel = New TM
    Protected DataService
    Protected DbDataDao
    Protected OriginalModel
    Protected SortOrderKey As String = "IdNo"
    Protected TreeViewList
    Protected TreeViewMainField As String
    Protected TreeViewParentIdField As String
    Protected TreeViewSecondaryField As String
    Protected DataFilter As String = Nothing
    Private ReadOnly _debugSwitch As Byte = 0
    Private ReadOnly _tableColumnPropertyList As List(Of TblColPropModel)
    Private _addMode As Boolean = False
    Private _editMode As Boolean = False
    Private _errorList As String = ""
    Private _recordPositionNumber As Integer = 0
    Private _targetIdNo As Int32 = 0
    Private _undoMode As Boolean = False
    Private _tableName As String
    Private _actualTableName As String

    Public Sub New(itemView As T)
        If itemView Is Nothing Then
            ''
        Else
            Me.View = itemView
            TableName = GetPropertyValue(Me.View, "MainTableName")
            Dim tableColumnPropertyList As List(Of TblColPropModel)
            tableColumnPropertyList = ModelTblColProp.GetMainTableColumnProperties(TableName)
            TableProperties = tableColumnPropertyList.ToArray
        End If
    End Sub

    Protected Sub New()
        'ModelTblColProp = New ModelTblColProp
        Model = New Model()
        'ModelDefaultFieldValue = New ModelDefaultFieldValue
    End Sub

    Delegate Sub FillDataFunc(ByRef dataView As Object, ByRef workRow As DataRow)

    Public Event AddingRecordChanged(adding As Boolean)

    Public Event AfterAdd(retVal As Integer)

    Public Event AfterDelete()

    Public Event AfterDisplayView()

    Public Event AfterEdit(retVal As Integer)

    Public Event AfterRecordRetrieval(values As TM)

    Public Event AfterSave()

    Public Event BeforeAdd()

    Public Event BeforeCompare()

    Public Event BeforeDelete()

    Public Event BeforeDisplayView()

    Public Event BeforeEdit()

    Public Event BeforeSave()

    Public Event BeforeValidate()

    Public Event CancelChanges()

    Public Event EditingRecordChanged(editing As Boolean)

    Public Event RecordAddedSuccessfully(ByRef idNoOfRecord As Integer)

    Public Event RecordUpdatedSuccessfully(ByRef idNoOfRecord As Integer)

    Public Event SuccessfulDelete(idNoOfRecord As Integer)

    Public Event TextDisplayChanged()

    Public Event UndoEdits(addingRec As Boolean)

    Public Property AddMode As Boolean
        Set
            _addMode = Value
            If Ea IsNot Nothing Then
                Ea.PublishEvent(New AddModeChanged(Value))
            End If
            If Value Then
                SaveOriginalValues()
            End If
        End Set
        Get
            Return _addMode
        End Get
    End Property

    Public Property QuitOnSave As Boolean = False
    Public Property AskBeforeSave As Boolean = False
    Public Property SaveSuccessful As Boolean = False
    Public Property AutoValidationsPassed As Boolean = False
    Public Property CancelDelete As Boolean = False
    Public Property CancelEdit As Boolean = False
    Public Property CancelSave As Boolean = False
    Public Property CurrentSortKeyValue As String
    Public Property Ea As EventAggregator
    Public Property DisableSaveMemento

    Public Property EditMode As Boolean
        Set
            _editMode = Value
            If Ea IsNot Nothing Then
                Ea.PublishEvent(New EditModeChanged(Value))
            End If
            If Value Then
                If Not DisableSaveMemento Then
                    SaveOriginalValues()
                End If
            End If
        End Set
        Get
            Return _editMode
        End Get
    End Property

    Public Property LastIdNo As Int32

    ' This is the model of the Inheriting Presenter
    ' when refferred to in this module this will be the current model
    ' while if reffered in the Inheriting Presenter it will be the
    ' model assigned to that presenter.
    Public Property ModelOfPresenter
        Get
            Return Model
        End Get
        Set(value)
            Model = value
        End Set
    End Property

    Public Property NewlyAddedRecordIdNo As Int32
    Public Property RecordCount As Integer

    Public Property RecordPositionNumber As Integer
        Get
            Return _recordPositionNumber
        End Get
        Set(value As Integer)
            _recordPositionNumber = value
            TargetIdNo = GetIdNoOfSortedPositionNumber(value)
        End Set
    End Property

    Public Property TableName As String
        Get
            Return _tableName
        End Get
        Set(value As String)
            _tableName = value
        End Set
    End Property

    Public Property ActualTableName As String
        Get
            Return _actualTableName
        End Get
        Set(value As String)
            _actualTableName = value
        End Set
    End Property

    Public Property TableProperties As Array

    Public Property TargetIdNo As Int32
        Get
            'If _targetIdNo = 0 Then
            '    Debugger.Break()
            'End If
            Return _targetIdNo
        End Get
        Set(value As Integer)
            'If value = 0 Then
            '    Debugger.Break()
            'End If
            _targetIdNo = value
            UpdateViewDisplay(value)
            If Ea IsNot Nothing Then
                Ea.PublishEvent(New RecordPositionChanged(value))
            End If
        End Set
    End Property

    Public Property UndoMode As Boolean
        Set
            If _undoMode <> Value Then
                _undoMode = Value
            End If
        End Set
        Get
            Return _undoMode
        End Get
    End Property

    Public Property View As T
    Protected Property LookUpDisplayCode As String
    Protected Property LookUpDisplayName As String
    Protected Property LookUpDisplayNameArabic As String
    Protected Property LookUpFieldsToShow As String()
    Protected Property LookUpFilterKey As String = Nothing
    Protected Property LookUpSortExpression As String
    Protected Property LookUpTableToGet As String
    Protected Property Model As IModel
    Protected Shared Property ModelTblColProp As IModelTblColProp = New ModelTblColProp

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

    Public Shared Function IsDateRangeValid(text As String, targetDate As Date, startDate As Date, endDate As Date) As DialogResult
        Dim retValue As DialogResult
        Dim dateField As String = Messaging.TranslateCaption(text)
        Dim startDateStr As String = startDate.ToShortDateString()
        Dim endDateStr As String = endDate.ToShortDateString()
        If targetDate < startDate Or targetDate > endDate Then
            Dim variables = {"dateField", dateField, "startDate", startDateStr, "endDate", endDateStr}
            Messaging.ShowParametrizedMessage(True, "MsgInvalidDate", variables)
            retValue = DialogResult.No
        Else
            retValue = DialogResult.Yes
        End If
        Return retValue
    End Function

    Public Sub AddChildPresenter(obj As Object)
        ChildPresenters.Add(obj)
    End Sub

    Public Overridable Function ChangesMade() As Boolean
        Dim retVal As Boolean = False
        RaiseEvent BeforeCompare()
        Dim compareLogic As New CompareLogic()
        compareLogic.Config.IgnoreObjectTypes = True
        compareLogic.Config.MaxDifferences = 100
        compareLogic.Config.CompareChildren = True
        compareLogic.Config.MembersToIgnore.Add("DateCreated")
        compareLogic.Config.MembersToIgnore.Add("Errors")
        Dim result As ComparisonResult = compareLogic.Compare(OriginalModel, View)
        If Not result.AreEqual Then
            CompareDifferences = result.DifferencesString
            'Messaging.Show(result.DifferencesString, "Differences")
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

    Public Sub CreateDataTable(ByRef dataTable As DataTable, rowColumns As Object)
        For i = 0 To rowColumns.GetLength(0) - 1
            dataTable.Columns.Add(rowColumns(i, 0), rowColumns(i, 1))
        Next
    End Sub

    Public Function DeleteRecord(idNo As Int32) As Integer
        Dim retValue As Integer
        Try
            Using scope As New TransactionScope(TransactionScopeOption.Required, New TimeSpan(0, 1, 0))
                If ActualTableName Is Nothing Then
                    retValue = Model.DeleteRecord(idNo, TableName)
                Else
                    retValue = Model.DeleteRecord(idNo, ActualTableName)
                End If
                If retValue > 0 Then
                    If Ea IsNot Nothing Then
                        'Ea.PublishEvent(New RecordDeleted(idNo))
                    End If
                    RaiseEvent SuccessfulDelete(idNo)
                End If
                scope.Complete()
            End Using
        Catch ex As TransactionAbortedException
            MessageBox.Show(ex.Message, "Record Deletion Aborted!")
        Catch oEx As Exception

            If oEx.Message.Contains("Timeout Expired") Then
                retValue = -1
            Else
                MsgBox("Error:   " + oEx.Message)
                retValue = -1
            End If
            If Debugger.IsAttached Then
                Debugger.Break()
            End If
        End Try

        Return retValue
    End Function

    Public Overridable Sub Display(idNo As Int32)
        '
    End Sub

    'Public Sub FindField(fieldName As String, searchString As String, searchPlace As Char)
    '    Dim idNo = Model.FindField(TableName, fieldName, searchString, searchPlace, DataFilter)
    '    If idNo <> 0 Then
    '        RecordPositionNumber = GetSortedRecordPosition(idNo)
    '    Else
    '        Messaging.Show(True, "MsgNoMatchingRecordFound")
    '    End If
    'End Sub

    Public Sub FindFieldNew(findableControl As IFindableControl)
        'Dim fieldType = Model.GetFieldType(TableName, findableControl.FieldName)
        Dim idNo = Model.FindFieldNew(TableName, findableControl, SortOrderKey, DataFilter)
        If idNo <> 0 Then
            RecordPositionNumber = GetSortedRecordPosition(idNo)
        Else
            Messaging.Show(True, "MsgNoMatchingRecordFound")
        End If
    End Sub

    Public Sub FindDateField(fieldName As String, findableControl As IFindableControl)
        Dim idNo = Model.FindDateField(TableName, findableControl, DataFilter)
        If idNo <> 0 Then
            RecordPositionNumber = GetSortedRecordPosition(idNo)
        Else
            Messaging.Show(True, "MsgNoMatchingRecordFound")
        End If
    End Sub

    'Public Function FindFieldOnTable(tableNameToSearch, fieldName, searchString, searchPlace)
    '    Dim idNo = Model.FindField(tableNameToSearch, fieldName, searchString, searchPlace, DataFilter)
    '    Return idNo
    'End Function

    Public Function FindFieldContinue(idNo As Int32) As Integer
        Return Model.FindFieldContinue(TableName, idNo, SortOrderKey)
    End Function

    Public Function FindRecord() As Integer
        Dim idNoOfFoundRecord As Integer = 0
        If OkToMove() Then
            idNoOfFoundRecord = FindFieldContinue(TargetIdNo)
        End If
        Return idNoOfFoundRecord
    End Function

    Public Function GetAppSetting(ByVal settingCode As String, ByVal group As String, ByVal description As String)
        Dim retValue = Model.GetRecordFieldWithKey(settingCode, "Setting", "SettingCode", "Value")
        If retValue Is Nothing Then
            Dim setupName As String = Messaging.TranslateCaption(description)
            Dim groupSetting As String = group
            Messaging.ShowParametrizedMessage(True, "MsgSettingNotSet", {"setupName", setupName, "groupSetting", groupSetting})
            Return Nothing
        End If
        Return retValue
    End Function

    Public Function GetBizObjectErrors() As List(Of String)
        Return Model.GetBizObjectErrors()
    End Function

    Public Function GetBizObjectRules()
        Return Model.GetBizObjectRules()
    End Function

    Public Function GetControlSecurityIdNo(searchValue As String, Optional menu As Boolean = False) As String
        Try
            Return Model.GetControlSecurityIdNo(searchValue, menu)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetDepartmentUseSetting()
        Dim retValue = Model.GetRecordFieldWithKey("DEPT", "Setting", "SettingCode", "Value")
        If retValue Is Nothing Then
            Dim setupName As String = Messaging.TranslateCaption("Use Revenue/Cost Centers")
            Dim groupSetting As String = "Company"
            Messaging.ShowParametrizedMessage(True, "MsgSettingNotSet", {"setupName", setupName, "groupSetting", groupSetting})
            Return Nothing
        End If
        If retValue = "0" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String)
        Try
            Return Model.GetFieldWithIdNo(idNo, tableName, returnFieldName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetIdNoOfSortedPositionNumber(recordNo As Integer) As Integer
        Try
            Return Model.GetIdNoOfSortedPositionNumber(recordNo, TableName, SortOrderKey, DataFilter)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Overloads Function GetLookup(listName As String, Optional filter As String = Nothing) As List(Of ClassesLibrary.LookupData)
        ComposeLookupParameters(listName)
        ProcessLookupFields()
        Return Model.GetLookup(LookUpTableToGet, LookUpSortExpression, LookUpFieldsToShow, filter)
    End Function

    Public Overloads Function GetLookup(LookupTableToGet As String, LookUpSortExpression As String, LookupFieldsToShow As String(), Optional filter As String = Nothing)
        Dim dFieldName As String
        If IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
            If Model.FieldExistInTable(LookupTableToGet, LookUpSortExpression.Trim() + "Ara") Then
                LookUpSortExpression = LookUpSortExpression.Trim() + "Ara"
            End If
            If Model.FieldExistInTable(LookupFieldsToShow(1), LookupFieldsToShow(1).Trim() + "Ara") Then
                dFieldName = LookupFieldsToShow(1).Trim() + "Ara"
            Else
                dFieldName = LookupFieldsToShow(1)
            End If
            LookupFieldsToShow = {LookupFieldsToShow(0), dFieldName, LookupFieldsToShow(2)}
        End If
        Return Model.GetLookup(LookupTableToGet, LookUpSortExpression, LookupFieldsToShow, filter)
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

    Public Function GetRecordCount(Optional pTableName As String = Nothing, Optional pFilter As String = Nothing) As Integer
        Try
            If pTableName Is Nothing Then
                pTableName = TableName
                Return Model.GetRecordCount(TableName, DataFilter)
            Else
                Return Model.GetRecordCount(pTableName, pFilter)
            End If
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

    Public Function GetRecordDateTimeStamp(idNo As Int32) As Object
        Try
            Return Model.GetRecordDateTimeStamp(idNo, TableName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetRecordField(cTableName As String, returnFieldName As String) As Object
        Try
            Return Model.GetRecordField(cTableName, returnFieldName)
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

    Public Function GetRecordFieldWithKeyG(Of TT)(searchValue As String, cTableName As String, searchFieldName As String, returnFieldName As String) As TT
        Try
            Return Model.GetRecordFieldWithKeyG(Of TT)(searchValue, cTableName, searchFieldName, returnFieldName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetRecordPosition(idNo As Int32)
        Try
            Return Model.GetRecordPosition(TableName, idNo) + 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetRevCostCenterUseSetting()
        Dim retValue = Model.GetRecordFieldWithKey("RCCN", "Setting", "SettingCode", "Value")
        If retValue Is Nothing Then
            Dim setupName As String = Messaging.TranslateCaption("Use Departments")
            Dim groupSetting As String = "Company"
            Messaging.ShowParametrizedMessage(True, "MsgSettingNotSet", {"setupName", setupName, "groupSetting", groupSetting})
            Return Nothing
        End If
        If retValue = "0" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetSortedRecordPosition(idNo As Int32) As Integer
        Try
            Return Model.GetSortedRecordPosition(idNo, TableName, SortOrderKey, DataFilter)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetFieldValue(Of TType)(sqlStatement As String, cTableName As String, condition As String) As TType
        Try
            Return Model.GetFieldValue(Of TType)(sqlStatement, cTableName, condition)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetTableProperties() As List(Of TblColPropModel)
        Return ModelTblColProp.GetMainTableColumnProperties(TableName)
    End Function

    Public Function GetTreeNodeText()
        Dim cModel As New TM
        Dim cText As String
        Dim treeMainFieldName = TranslateField(Of TM)(TreeViewMainField, cModel)
        If String.IsNullOrEmpty(TreeViewSecondaryField) Then
            cText = CallByName(View, treeMainFieldName, CallType.Get) + " | " + CType(CallByName(View, IdFieldName, CallType.Get), String)
        Else
            Dim addText = CallByName(View, TreeViewSecondaryField, CallType.Get)
            cText = CallByName(View, treeMainFieldName, CallType.Get) + " | " + CType(CallByName(View, IdFieldName, CallType.Get), String) +
                    If(String.IsNullOrEmpty(addText), "", " (" + addText.ToString() + ")")
        End If
        Return cText
    End Function

    Public Function GetTreeViewData()
        Dim cModel As New TM
        Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of TM)(SortOrderKey, cModel)
        Dim treeMainFieldName = TranslateField(Of TM)(TreeViewMainField, cModel)
        If TreeViewParentIdField Is Nothing OrElse TreeViewParentIdField = "" Then
            If String.IsNullOrEmpty(TreeViewSecondaryField) Then
                'Return Model.GetLookupRecords(TableName, newSortOrderKey, {IdFieldName, treeMainFieldName}, DataFilter)
                Return Model.GetLookup(TableName, newSortOrderKey, {IdFieldName, treeMainFieldName}, DataFilter)
            Else
                'Return Model.GetLookupRecords(TableName, newSortOrderKey, {IdFieldName, treeMainFieldName, TreeViewSecondaryField}, DataFilter)
                Return Model.GetLookup(TableName, newSortOrderKey, {IdFieldName, treeMainFieldName, TreeViewSecondaryField}, DataFilter)
            End If
        Else
            newSortOrderKey = "SortKey"
            If String.IsNullOrEmpty(TreeViewSecondaryField) Then
                Return Model.GetHRecords(TableName, newSortOrderKey, {IdFieldName, treeMainFieldName, TreeViewParentIdField})
            Else
                Return Model.GetHRecords(TableName, newSortOrderKey, {IdFieldName, treeMainFieldName, TreeViewParentIdField, TreeViewSecondaryField})
            End If
        End If
    End Function

    'Public Function GetRecordsByField(ByVal tableName As String, ByVal sortOrder As String, fieldNames As String(), Optional filter As String = Nothing)
    '    Return Model.GetRecords(tableName, sortOrder, fieldNames, filter)
    'End Function

    Public Function GetRecords(ByVal tableName As String, ByVal sortOrder As String, ByVal fieldNames As String(), Optional filter As String = Nothing)
        Return Model.GetRecords(tableName, sortOrder, fieldNames, filter)
    End Function

    'Public Function GetFields(ByVal tableName As String, ByVal sortOrder As String, ByVal ParamArray fieldNames() As String)
    '    Return Model.GetFields(tableName, sortOrder, fieldNames)
    'End Function

    Public Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int16) As ArrayList
        Return Model.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
    End Function

    Public Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList
        Return Model.GetUserSecurityForKey(securityObjectName, securityGroupIdNo)
    End Function

    Public Function AddSecurityObject(securityObject As SecurityObject) As Int32
        Return Model.AddSecurityObject(securityObject)
    End Function

    Public Function InitializeSecurityObject() As Integer
        Return Model.InitializeSecurityObject()
    End Function

    Public Overridable Sub GoAddRecord()
        LastIdNo = CallByName(View, IdFieldName, CallType.Get)
        Try
            DataModel = New TM
            GlobalVariables.Mapper.Map(DataModel, View)
            AddMode = True
            RaiseEvent BeforeAdd()
        Catch oEx As Exception
            MsgBox("Error:   " + oEx.Message)
            AddMode = False
        End Try
    End Sub

    Public Overridable Function GoDeleteRecord() As Integer
        Dim record As New TM
        GlobalVariables.Mapper.Map(Of IView, TM)(View, record)
        Dim retValue = 0
        Dim currentIdNo = CallByName(View, IdFieldName, CallType.Get)
        If IsOkToDeleteRecord() Then
            If Messaging.Show(True, "AskIfDeleteRecord", "Are you sure you want to delete this record?", "Please Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                RaiseEvent BeforeDelete()
                retValue = DeleteRecord(currentIdNo)
                If retValue <= 0 Then
                    Messaging.Show(True, "MsgDeleteRecordFailed", "This record was not deleted because of an error. Please try again later or ask Database Administrator for help.", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Messaging.Show(True, "MsgRecordSuccessfullyDeleted", "Record was successfully deleted.", "Record Deleted")
                    ' if deleted stay on that given RecordPositionNumber
                    ' which in this case will be the next record after the deleted record
                    TargetIdNo = GetIdNoOfSortedPositionNumber(RecordPositionNumber)
                    If TargetIdNo = 0 Then
                        ' last record deleted
                        GoLastRecord()
                    End If
                    UpdateViewDisplay(TargetIdNo)
                End If
                RaiseEvent AfterDelete()
            End If
        End If
        Return retValue
    End Function

    Public Sub GoEditRecord()
        If IsOkToEditRecord() Then
            RaiseEvent BeforeEdit()
            If CancelEdit Then
                CancelEdit = False
            Else
                EditMode = True
            End If
            'RaiseEvent AfterEdit()
        End If
    End Sub

    Public Sub GoFindRecord()
        Dim idNoOfFoundRecord = FindRecord()
        If idNoOfFoundRecord = 0 Then
            If Messaging.Show(True, "AskLastRecordReachStartBeg", "This is the last matching record for the given text. Do you want to start search from the first record?", "Last Record Found.",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                idNoOfFoundRecord = FindFieldContinue(0)
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

    Public Sub GoFirstRecord()
        If OkToMove() Then
            RecordPositionNumber = 1
        End If
    End Sub

    Public Sub GoLastRecord()
        If OkToMove() Then
            RecordPositionNumber = GetRecordCount()
        End If
    End Sub

    Public Sub GoNextRecord()
        If OkToMove() Then
            If RecordPositionNumber = RecordCount Then
                Messaging.Show(True, "MsgLastRecordHit", "This is already the last record.", "Last Record")
            Else
                RecordPositionNumber += 1
            End If
        End If
    End Sub

    Public Sub GoPreviousRecord()
        If OkToMove() Then
            If RecordPositionNumber = 1 Or RecordPositionNumber = 0 Then
                Messaging.Show(True, "MsgFirstRecordHit", "This is already the first record.", "First Record")
            Else
                RecordPositionNumber -= 1
            End If
        End If
    End Sub

    Public Overridable Sub GoPrintRecord()

    End Sub

    Public Sub GoQuit()
        If OkToMove() Then
            If Ea IsNot Nothing Then
                Ea.PublishEvent(New QuitView(True))
            End If
        End If
    End Sub

    Public Overridable Sub GoSaveRecord()
        Dim continueSave As Boolean = True
        Dim addAnother = False
        If AskBeforeSave Then
            If Not MessageBeforeSave() Then
                continueSave = False
            End If
        End If
        If continueSave Then
            Dim retVal As Integer
            retVal = Save()
            If retVal > 0 Then
                SaveSuccessful = True
                Messaging.Show(True, "MsgRecordSuccessfullySaved", "Record saved successfully!", "Record Saved")
                If Not QuitOnSave Then
                    If AddMode Then
                        If Messaging.Show(True, "AskAddAnotherRecord", "Do you want to add another record?",
                                      "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                      MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                            addAnother = True
                        Else
                            Dim idNo = CallByName(View, IdFieldName, CallType.Get)
                            RecordPositionNumber = GetSortedRecordPosition(idNo)
                        End If
                    Else
                        RecordPositionNumber = GetSortedRecordPosition(TargetIdNo)
                        'RecordPositionNumber = GetSortedRecordPosition(CallByName(View, IdFieldName, CallType.Get))
                    End If
                    If AddMode Then
                        AddMode = False
                    Else
                        EditMode = False
                    End If
                    If addAnother Then
                        GoAddRecord()
                    End If
                End If
            Else
                SaveSuccessful = False
            End If
        End If
    End Sub

    Public Overridable Function MessageBeforeSave() As Boolean
        Dim retVal As Boolean = False
        Dim message = "Are you sure you want to {action} this {itemName} entry?"
        Dim caption = "Please confirm."
        Dim action As String = Messaging.TranslateCaption("save")
        Dim itemName As String = Messaging.TranslateCaption("transaction")
        Dim msg = Messaging.GetParametrizedMessage(True, "AskIfContinueAction", {"action", action, "itemName", itemName})
        'message = message.Interpolate(Function(x) action, Function(x) itemName)
        If Messaging.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            retVal = True
        End If
        Return retVal
    End Function

    Public Sub GoTranslate()
        'Dim frm As New TranslationTableManager()
        'frm.SystemViewIdNoToTranslate = SystemViewIdNo
        'frm.AppDataDAC = AppDataDAC
        'frm.TranslatorDAC = TranslatorDAC
        'frm.Show()
    End Sub

    Public Overridable Sub GoFilter()
    End Sub

    Public Sub GoUndoChanges()
        If OkToMove() Then
            UndoMode = True
            If AddMode Then
                RecordPositionNumber = GetSortedRecordPosition(LastIdNo)
                AddMode = False
            Else
                RecordPositionNumber = RecordPositionNumber
                EditMode = False
            End If
        End If
        UndoMode = False
    End Sub

    Public Overridable Function IsOkToEditRecord() As Boolean
        Return True
    End Function

    Public Overridable Function IsOkToDeleteRecord() As Boolean
        Dim retValue As Boolean = False
        If Not DependentRecordsExist() Then
            retValue = True
        End If
        Return retValue
    End Function

    Public Function IsRecordNotUnique(cCtrl As Control, fldName As String) As Boolean
        If CheckIfUnique(cCtrl.Text, fldName, TargetIdNo) Then
            Return False
        End If
        Return True
    End Function

    Public Overridable Function OkToMove() As Boolean
        Dim retValue As Boolean = False
        If QuitOnSave Then
            retValue = True
        ElseIf Not (EditMode OrElse AddMode) Then
            retValue = True
        Else
            Dim result As DialogResult
            If ChangesMade() Then
                result = SaveOrAbandonChanges()
                If result = DialogResult.Yes Or result = DialogResult.No Then
                    If result = DialogResult.Yes Then
                        result = Save()
                        If result > 0 Then
                            Messaging.Show(True, "MsgRecordSuccessfullySaved", "Record saved successfully!", "Record Saved")
                            If AddMode Then
                                RecordPositionNumber = GetSortedRecordPosition(TargetIdNo)
                            End If
                            retValue = True
                        End If
                    Else
                        If AddMode Then
                            RecordPositionNumber = GetSortedRecordPosition(LastIdNo)
                        Else
                            RecordPositionNumber = RecordPositionNumber
                        End If
                        retValue = True
                    End If
                Else
                    retValue = False
                End If
            Else
                retValue = True
            End If
        End If
        If retValue Then
            If AddMode Then
                AddMode = False
            Else
                EditMode = False
            End If
        End If
        Return retValue
    End Function

    Public Sub OnEventHandler(ByRef e As SelectedButton) Implements ISubscriber(Of SelectedButton).OnEventHandler
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
            Case ButtonClicked.Save
                GoSaveRecord()
            Case ButtonClicked.Print
                GoPrintRecord()
            Case ButtonClicked.Quit
                GoQuit()
            Case ButtonClicked.Translate
                GoTranslate()
            Case ButtonClicked.Filter
                GoFilter()
        End Select
    End Sub

    Public Overridable Function Save()
        Dim retVal As Integer = 0
        If EditMode AndAlso (Not AddMode) AndAlso RecordHasChanged(TargetIdNo, RecordDateTimeStampValue) Then
            Messaging.Show(True, "MsgRecordChangedSinceLastRetrieval", "Record Has Changed since you last retrieved the record, cannot save your modifications. Please refresh the record and try again.", "Someone changed the record!")
        Else
            RaiseEvent BeforeValidate()
            If EditMode AndAlso Not ChangesMade() Then
                Messaging.Show(True, "MsgNoChangesMadeNothingToSave", "No changes made, nothing to save!", "Nothing to save")
            Else
                Dim validated As Boolean = True
                Dim validatingObject = New ValidatingData(validated)
                If Ea IsNot Nothing Then
                    Ea.PublishEvent(validatingObject)
                    'Ea.PublishEvent(New ValidatingData(viewIsValid))
                End If
                If validatingObject.Validated AndAlso IsBizDataValid() Then
                    RaiseEvent BeforeSave()
                    retVal = InitiateSave()
                    If retVal < 0 Then
                        Messaging.Show(True, "MsgSaveRecordFailed", "Something went wrong during saving, saving record failed", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'Else
                        '    Messaging.Show(true,"MsgRecordHasBeenSaved", "Record has been successfully saved!")
                    Else
                        RaiseEvent AfterSave()
                        If Ea IsNot Nothing Then
                            Ea.PublishEvent(New RecordSaved(DataModel))
                        End If
                    End If
                Else
                    retVal = -1
                End If
            End If
        End If
        If retVal < 0 Then
            Dim lErrors = GetBizObjectErrors()
            If Ea IsNot Nothing And lErrors IsNot Nothing Then
                Ea.PublishEvent(New PassErrorList(lErrors))
            End If
            Beep()
            ShowErrors("Record not saved!")
        End If
        Return retVal
    End Function

    Public Function SaveOrAbandonChanges() As DialogResult
        Dim result As DialogResult
        Dim msg As String
        msg = Messaging.GetMessage(True, "AskIfUserWantsToSaveOrContinueEdits",
                                 "Changes have been made to this record.  Press [Yes] to save changes, [No] to Abandon changes, or press [Cancel] to continue editing record? Save Changes?",
                                 "Please Confirm.")
        If GlobalVariables.ShowDataDifferenceWhenSaving Then
            result = Messaging.Show(msg & Environment.NewLine & CompareDifferences, "Please Confirm", MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button3)
        Else
            result = Messaging.Show(msg & Environment.NewLine, "Please Confirm", MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button3)
        End If
        Return result
    End Function

    Public Overridable Sub SaveOriginalValues()
        GlobalVariables.Mapper.Map(Of T, TM)(Me.View, Me.OriginalModel)
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
        Messaging.MessageKey = "ValidationErrors"
        Messaging.Show(_errorList, $"Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Sub Undo()
        If ChangesMade() Then
            Dim result As DialogResult
            result = SaveOrAbandonChanges()
            If result = DialogResult.Yes Then
                Save()
                UpdateViewDisplay(TargetIdNo)
            ElseIf result = DialogResult.No Then
                ' undo changes retrieve the last record
                TargetIdNo = LastIdNo
                UpdateViewDisplay(TargetIdNo)
            Else
                ' DialogResult.Cancel
                ' don't do anything just continue edits
            End If
        Else
            UpdateViewDisplay(TargetIdNo)
        End If
        If AddMode Then
            AddMode = False
        Else
            EditMode = False
        End If
    End Sub

    Public Overridable Sub UpdateViewDisplay(idNo As Int32)
        If idNo <> 0 Then
            Dim modelData As TM
            RecordCount = GetRecordCount()
            RecordDateTimeStampValue = GetRecordDateTimeStamp(TargetIdNo)
            modelData = Model.GetRecordByIdNo(Of TM)(idNo)
            RaiseEvent AfterRecordRetrieval(modelData)
            If Ea IsNot Nothing Then
                Ea.PublishEvent(New BeforeAssignment(modelData))
            End If
            GlobalVariables.Mapper.Map(Of TM, T)(modelData, View)
            For Each child In ChildPresenters
                child.UpdateViewDisplay(idNo)
            Next
        End If
    End Sub

    Public Function UsePayGroups()
        Dim retValue = Model.GetRecordFieldWithKey("PYGP", "Setting", "SettingCode", "Value")
        If retValue Is Nothing Then
            Dim setupName As String = Messaging.TranslateCaption("Use Pay Groups")
            Dim groupSetting As String = "Payroll"
            Messaging.ShowParametrizedMessage(True, "MsgSettingNotSet", {"setupName", setupName, "groupSetting", groupSetting})
            Return Nothing
        End If
        If retValue = "1" Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Overridable Function AdditionalChangesMadeCheck()
        Return False
    End Function

    Protected Overridable Function AddRecord(record As TM) As Integer
        Dim retVal As Integer
        NewlyAddedRecordIdNo = Model.AddRecord(record)
        retVal = NewlyAddedRecordIdNo
        CallByName(View, IdFieldName, CallType.Set, retVal)
        Return retVal
    End Function

    Protected Sub ComposeLookupParameters(listName As String)
        LookUpTableToGet = listName
        LookUpDisplayName = listName + "Name"
        LookUpSortExpression = LookUpDisplayName
        LookUpDisplayNameArabic = LookUpDisplayName + "Ara"
        LookUpDisplayCode = listName + "Code"
    End Sub

    Protected Sub ComposeLookupParametersNew(listName As String)
        LookUpTableToGet = listName
        LookUpDisplayName = "Name"
        LookUpSortExpression = LookUpDisplayName
        LookUpDisplayNameArabic = "NameAra"
        LookUpDisplayCode = "Code"
    End Sub

    Protected Overridable Function DependentRecordsExist() As Boolean
        Return False
    End Function

    Protected Function GetLookupByCodeName()
        ProcessLookupFields()
        Return Model.GetLookupByCodeName(LookUpTableToGet, LookUpSortExpression, LookUpFieldsToShow, LookUpFilterKey)
    End Function

    Protected Function GetLookupByName()
        ProcessLookupFields()
        Return Model.GetLookupByName(LookUpTableToGet, LookUpSortExpression, LookUpFieldsToShow, LookUpFilterKey)
    End Function

    Protected Function GetLookupByNameCode()
        ProcessLookupFields()
        Return Model.GetLookupByNameCode(LookUpTableToGet, LookUpSortExpression, LookUpFieldsToShow, LookUpFilterKey)
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
                    nameOfField += "Ara"
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

    Protected Overridable Function IsBizDataValid() As Boolean
        Dim retValue As Boolean = False
        GlobalVariables.Mapper.Map(Of T, TM)(View, DataModel)
        If Model.IsValid(DataModel) Then
            'For Each item In ChildServices
            '    GlobalVariables.Mapper.Map()
            '    If Not item.IsBizDataValid() Then
            '        Exit For
            '    End If
            'Next
            retValue = True
        End If
        Return retValue
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

    Protected Function UpdateChildData(ByRef childDataModel As Model, updateTable As DataTable, insertTable As DataTable, passedValue As Integer, parentIdFieldName As String) As Integer
        Dim retVal As Integer
        Dim updateReturnValue As Object
        Dim insertReturnValue As Object
        Dim parentIdNo As Integer
        If AddMode Then
            parentIdNo = passedValue
        Else
            parentIdNo = CallByName(View, IdFieldName, CallType.Get)
        End If
        updateReturnValue = childDataModel.DelUpdateTvp(updateTable, parentIdNo)
        If updateReturnValue >= 0 AndAlso insertTable.Rows.Count > 0 Then
            If passedValue <> 0 Then
                For Each row As DataRow In insertTable.Rows
                    row.Item(parentIdFieldName) = parentIdNo
                Next
            End If
            insertReturnValue = childDataModel.InsertTvp(insertTable)
            If insertReturnValue >= 0 Then
                retVal = updateReturnValue + insertReturnValue
            Else
                retVal = insertReturnValue
            End If
        Else
            retVal = updateReturnValue
        End If
        Return retVal
    End Function

    Protected Function UpdateDataTables(updateTable As DataTable, insertTable As DataTable, parentIdNo As Integer, parentIdFieldName As String) As Integer
        Dim retVal As Integer
        Dim updateReturnValue As Object
        Dim insertReturnValue As Object
        updateReturnValue = Model.DelUpdateTvp(updateTable, parentIdNo)
        If updateReturnValue >= 0 AndAlso insertTable.Rows.Count > 0 Then
            If parentIdNo <> 0 Then
                For Each row As DataRow In insertTable.Rows
                    row.Item(parentIdFieldName) = parentIdNo
                Next
            End If
            insertReturnValue = Model.InsertTvp(insertTable)
            If insertReturnValue >= 0 Then
                retVal = updateReturnValue + insertReturnValue
            Else
                retVal = insertReturnValue
            End If
        Else
            retVal = updateReturnValue
        End If
        Return retVal
    End Function

    Protected Overridable Function UpdateRecord(record As TM) As Integer
        Return Model.UpdateRecord(record)
    End Function

    Protected Function ViewToDataTables(ByRef dataViews As Object, ByRef insertTable As DataTable, ByRef updateTable As DataTable, ByVal fillSub As FillDataFunc,
                                      ByVal includeFilter As Predicate(Of Object), ByVal Optional dataViewIdNoFieldName As String = "IdNo", ByVal Optional sequenceFieldName As String = "Sequence") As DataRow
        If insertTable IsNot Nothing Then
            insertTable.Clear()
        End If
        If updateTable IsNot Nothing Then
            updateTable.Clear()
        End If
        Dim nRowCount As Int16 = 1
        Dim workRow As DataRow = Nothing
        For Each dataView In dataViews
            If includeFilter.Invoke(dataView) Then
                Dim idNo As Integer = CallByName(dataView, dataViewIdNoFieldName, CallType.Get)
                If idNo <= 0 Then
                    workRow = insertTable.NewRow()
                Else
                    workRow = updateTable.NewRow()
                    workRow(dataViewIdNoFieldName) = idNo
                End If
                If sequenceFieldName <> "" Then
                    workRow(sequenceFieldName) = nRowCount
                End If
                fillSub.Invoke(dataView, workRow)
                If idNo <= 0 Then
                    insertTable.Rows.Add(workRow)
                Else
                    updateTable.Rows.Add(workRow)
                End If
                nRowCount += 1
            End If
        Next
        Return workRow
    End Function

    Private Function InitiateSave() As Integer
        Dim retValue As Integer
        Try
            Dim record As New TM
            GlobalVariables.Mapper.Map(Of IView, TM)(View, record)
            Using scope As New TransactionScope(TransactionScopeOption.Required, New TimeSpan(0, 1, 0))
                If AddMode Then
                    Dim retVal As Integer = 0
                    retValue = AddRecord(record)
                    If retValue > 0 Then
                        retVal = retValue
                        RaiseEvent RecordAddedSuccessfully(retVal)
                        If retVal < 0 Then
                            retValue = retVal
                        End If
                    End If
                Else
                    retValue = UpdateRecord(record)
                    If retValue >= 0 Then
                        Dim retVal As Integer = retValue
                        RaiseEvent RecordUpdatedSuccessfully(retVal)
                        If retVal < 0 Then
                            retValue = retVal
                        Else
                            retValue += retVal
                        End If
                    End If
                End If
                If retValue >= 0 Then
                    scope.Complete()
                End If
            End Using
        Catch ex As TransactionAbortedException
            retValue = -1
            MessageBox.Show(ex.Message, "Transaction Aborted")
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

    Private Sub ProcessLookupFields()
        Dim dFieldName As String
        If IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
            If LookUpSortExpression = LookUpDisplayName Then
                LookUpSortExpression = LookUpDisplayNameArabic
            End If
            dFieldName = LookUpDisplayNameArabic
        Else
            dFieldName = LookUpDisplayName
        End If
        LookUpFieldsToShow = {"IdNo", dFieldName, LookUpDisplayCode}
    End Sub

    Private Function RecordHasChanged(idNo As Int32, timeStampedValue As Object) As Boolean
        Dim retValue = False
        Try
            If timeStampedValue IsNot Nothing Then
                Dim newDateTimeStamp As Object
                newDateTimeStamp = Model.GetRecordDateTimeStamp(idNo, TableName, DateTimeStampField)
                If newDateTimeStamp IsNot Nothing Then
                    For i = 0 To 7
                        If timeStampedValue(i) <> newDateTimeStamp(i) Then
                            retValue = True
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Return Nothing
        End Try
        Return retValue
    End Function

    Public Function MakeEnumComboList(Of TE)()
        Dim dataList As New List(Of ClassesLibrary.LookupData)
        For Each c In [Enum].GetValues(GetType(TE))
            Dim data As New ClassesLibrary.LookupData With {
                .IdNo = CInt(c),
                .Code = EnumToCode(c),
                .Name = Messaging.TranslateCaption(c.ToString().SplitCamelCase())
            }
            dataList.Add(data)
        Next
        Return dataList
    End Function

    Public Function MakeEnumComboList2(Of TE)()
        Dim dataList As New List(Of ClassesLibrary.LookupData)
        For Each c In [Enum].GetValues(GetType(TE))
            Dim data As New ClassesLibrary.LookupData With {
                    .IdNo = CInt(c),
                    .Code = CInt(c),
                    .Name = Messaging.TranslateCaption(c.ToString().SplitCamelCase())
                    }
            dataList.Add(data)
        Next
        Return dataList
    End Function

    Public Sub AddToParentError(errors As List(Of String))
        Dim mainBizObj = DirectCast(DirectCast(DirectCast(Model, AATM.PresentationLayer.Models.Model).DataService, AATM.ServicesLayer.Services.Service).DataBo, AATM.BusinessLayer.BusinessObject)
        mainBizObj.AddError(errors)
    End Sub

    'Public Function IsBusinessDataValid(ByRef dataDictionary As Dictionary(Of String, Object)) As Boolean
    '    Dim retValue As Boolean = False
    '    GlobalVariables.Mapper.Map(Of T, TM)(View, DataModel)
    '    If Model.IsValid(DataModel) Then
    '        retValue = True
    '    Else
    '        UpdateErrors(dataDictionary)
    '    End If
    '    Return retValue
    'End Function

    'Private Sub UpdateErrors(ByRef dataDictionary As Dictionary(Of String, Object))

    'End Sub

End Class
Imports System.ComponentModel
Imports System.Globalization
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Transactions
Imports System.Windows.Forms
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.CBaseControlsLibrary
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
Public MustInherit Class PresenterNew(Of T As IView, TM As New)
    Implements IPresenter,
               ISubscriber(Of ViewButtonClicked),
               ISubscriber(Of FindFieldRequested),
               ISubscriber(Of EntryFormLoaded),
               ISubscriber(Of SaveDataRequested),
               ISubscriber(Of GetDataSource),
               ISubscriber(Of GetLookupDataRequested),
               ISubscriber(Of LanguageChanged)

    Public ChildPresenters As New List(Of Object)
    Public ChildModels As New List(Of Object)
    Public IdFieldName As String = "IdNo"
    Public MyErrorProvider As New ErrorProviderExtended

    Friend DateTimeStampField As String = "DateTimeStamp"
    Friend RecordDateTimeStampValue As Object
    Protected CompareDifferences As String
    Protected DataModel = New TM
    Protected DataService
    Protected DbDataDao
    Protected OriginalModel
    Protected SortOrderKey As String = "IdNo"
    Protected DataFilter As String = Nothing
    Private ReadOnly _debugSwitch As Byte = 0
    Private ReadOnly _tableColumnPropertyList As List(Of TblColPropModel)
    Private _addMode As Boolean = False
    Private _editMode As Boolean = False
    Private _errorList As String = ""
    Private _recordPositionNumber As Integer = 0
    Private _targetIdNo As Int32 = 0

    'Private _recordCount As Int32 = 0
    Private _undoMode As Boolean = False

    Private _ea As EventAggregator
    Private _dataErrors As String = ""
    Private ReadOnly _withTreeView As Boolean = False

    Public Sub New(itemView As T)
        If itemView Is Nothing Then
            ''
        Else
            Me.View = itemView
            'MyErrorProvider = CallByName(View, "MyErrorProvider", CallType.Get)

            MyErrorProvider = LateBinding.GetField(View, "MyErrorProvider")
            Ea.SubscribeEvent(Me)

            Dim pi As PropertyInfo = View.GetType().GetProperty("FormTreeView")
            If pi IsNot Nothing Then
                _withTreeView = True
                FormTreeView = pi.GetValue(View)
            End If

        End If
    End Sub

    Protected Sub New()
        Model = New Model()
    End Sub

    Delegate Sub FillDataFunc(ByRef dataView As Object, ByRef workRow As DataRow)

    Public Event AddingRecordChanged(adding As Boolean)

    Public Event AfterAdd(retVal As Integer)

    Public Event AfterDelete(retVal As Integer)

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

    Protected ReadOnly Property MenuFormName As String
        Get
            Return LateBinding.GetProperty(View, "MenuFormName")
        End Get
    End Property

    Protected ReadOnly Property ViewName As String
        Get
            Return LateBinding.GetProperty(View, "Name")
        End Get
    End Property

    Protected ReadOnly Property MainFieldsDictionary As Dictionary(Of String, Object)
        Get
            'Return CallByName(View, "MainFieldsDictionary", CallType.Get)
            Return LateBinding.GetField(View, "MainFieldsDictionary")
        End Get
    End Property

    Public Property AddMode As Boolean
        Get
            Return _addMode
        End Get
        Set(value As Boolean)
            _addMode = value
            If value Then
                _editMode = False
            End If
            CurrentRecordChanged()
        End Set
    End Property

    Public Property Ea As EventAggregator
        Get
            'Return CallByName(View, "Ea", CallType.Get)
            Return LateBinding.GetField(View, "Ea")
        End Get
        Set(value As EventAggregator)
            _ea = value
        End Set
    End Property

    Protected Property QuitOnSave As Boolean
        Get
            Return LateBinding.GetProperty(View, "QuitOnSave")
        End Get
        Set(value As Boolean)
            LateBinding.SetProperty(View, "QuitOnSave")
        End Set
    End Property

    Public Property AskBeforeSave As Boolean = False
    Public Property SaveSuccessful As Boolean = False

    Public Property CancelDelete As Boolean = False

    Public Property CancelEdit As Boolean = False
    Public Property CancelSave As Boolean = False
    Public Property CurrentSortKeyValue As String
    Public Property DisableSaveMemento

    Public Property EditMode As Boolean
        Get
            Return _editMode
        End Get
        Set
            _editMode = Value
            If Value Then
                _addMode = False
                If Not DisableSaveMemento Then
                    SaveOriginalValues()
                End If
                LateBinding.InvokeFunction(View, "TurnOnInputs")
            Else
                LateBinding.InvokeFunction(View, "TurnOffInputs")
            End If
        End Set
    End Property

    Public Property LastIdNo As Int32

    ' This is the model of the Inheriting Presenter
    ' when referred to in this module this will be the current model
    ' while if referred in the Inheriting Presenter it will be the
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

    Public ReadOnly Property RecordCount As Integer
        Get
            Return Model.GetRecordCount(TableName, DataFilter)
        End Get
    End Property

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
            LateBinding.InvokeFunction(View, "CurrentRecordChanged", {EditMode, AddMode, RecordPositionNumber, TargetIdNo, RecordCount})
            'CallByName(View, "CurrentRecordChanged", CallType.Method, {EditMode, AddMode, RecordPositionNumber, TargetIdNo, RecordCount})
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
        'CallByName(View, "IgnoreTextBoxNumParserMessage", CallType.Set, True)
        Dim result As ComparisonResult = compareLogic.Compare(OriginalModel, View)
        If Not result.AreEqual Then
            CompareDifferences = result.DifferencesString
            'Messaging.Show(result.DifferencesString, "Differences")
            retVal = True
        End If
        'CallByName(View, "IgnoreTextBoxNumParserMessage", CallType.Set, False)
        Return retVal
    End Function

    Public Function CheckIfUnique(textValue As String, fieldName As String, pTargetIdNo As Integer) As Boolean
        If Model.CheckIfUnique(textValue, TableName, fieldName, pTargetIdNo) Then
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
                retValue = Model.DeleteRecord(idNo, TableName)
                If retValue > 0 Then
                    If GlobalVariables.EventAggregator IsNot Nothing Then
                        'GlobalVariables.EventAggregator.PublishEvent(New RecordDeleted(idNo))
                    End If
                    RaiseEvent SuccessfulDelete(idNo)
                End If
                scope.Complete()
            End Using
        Catch ex As TransactionAbortedException
            MessageBox.Show(ex.Message, $"Record Deletion Aborted!")
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

    Public Sub FindFieldNew(findableControl As IFindableControl)
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

    Public Function FindFieldContinue(idNo As Int32) As Integer
        Return Model.FindFieldContinue(TableName, idNo, SortOrderKey)
    End Function

    Public Function FindRecord() As Integer
        Dim idNoOfFoundRecord As Integer = FindFieldContinue(TargetIdNo)
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

    Public Function GetFieldWithIdNo(idNo As Object, pTableName As String, returnFieldName As String) Implements IPresenter.GetFieldWithIdNo
        Try
            Return Model.GetFieldWithIdNo(idNo, pTableName, returnFieldName)
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

    Public Overloads Function GetLookup(listName As String, Optional filter As String = Nothing) As List(Of ClassesLibrary.LookupData) Implements IPresenter.GetLookup
        ComposeLookupParameters(listName)
        ProcessLookupFields()
        Return Model.GetLookup(LookUpTableToGet, LookUpSortExpression, LookUpFieldsToShow, filter)
    End Function

    Public Overloads Function GetLookup(lLookupTableToGet As String, lLookUpSortExpression As String, lLookupFieldsToShow As String(), Optional filter As String = Nothing) As List(Of ClassesLibrary.LookupData) Implements IPresenter.GetLookup
        Dim dFieldName As String
        If IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
            If Model.FieldExistInTable(LookUpTableToGet, lLookUpSortExpression.Trim() + "Ara") Then
                lLookUpSortExpression = lLookUpSortExpression.Trim() + "Ara"
            End If
            If Model.FieldExistInTable(lLookupFieldsToShow(1), lLookupFieldsToShow(1).Trim() + "Ara") Then
                dFieldName = lLookupFieldsToShow(1).Trim() + "Ara"
            Else
                dFieldName = lLookupFieldsToShow(1)
            End If
            lLookupFieldsToShow = {lLookupFieldsToShow(0), dFieldName, lLookupFieldsToShow(2)}
        End If
        Return Model.GetLookup(lLookupTableToGet, lLookUpSortExpression, lLookupFieldsToShow, filter)
    End Function

    Protected Sub ComposeLookupParameters(listName As String)
        LookUpTableToGet = listName
        LookUpDisplayName = listName + "Name"
        LookUpSortExpression = LookUpDisplayName
        LookUpDisplayNameArabic = LookUpDisplayName + "Ara"
        LookUpDisplayCode = listName + "Code"
    End Sub

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

    'Public Function GetRecordCount(Optional pTableName As String = Nothing, Optional pFilter As String = Nothing) As Integer
    '    Try
    '        If pTableName Is Nothing Then
    '            pTableName = TableName
    '            Return Model.GetRecordCount(TableName, DataFilter)
    '        Else
    '            Return Model.GetRecordCount(pTableName, pFilter)
    '        End If
    '    Catch ex As Exception
    '        Return 0
    '    End Try
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

    Public Function GetRecords(ByVal pTableName As String, ByVal sortOrder As String, ByVal fieldNames As String(), Optional filter As String = Nothing)
        Return Model.GetRecords(pTableName, sortOrder, fieldNames, filter)
    End Function

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
        LastIdNo = LateBinding.GetProperty(View, IdFieldName)
        Try
            DataModel = New TM
            GlobalVariables.Mapper.Map(DataModel, View)
            AddMode = True
            RaiseEvent BeforeAdd()
        Catch oEx As Exception
            MsgBox("Error:   " + oEx.Message)
            AddMode = False
            'CallByName(View, "AddMode", CallType.Set, False)
        End Try
    End Sub

    Public Overridable Function GoDeleteRecord() As Integer
        Dim record As New TM
        GlobalVariables.Mapper.Map(Of IView, TM)(View, record)
        Dim retValue = 0
        Dim currentIdNo = LateBinding.GetProperty(View, IdFieldName)
        If IsOkToDeleteRecord() Then
            If Messaging.Show(True, "AskIfDeleteRecord", "Are you sure you want to delete this record?", "Please Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                RaiseEvent BeforeDelete()
                If _withTreeView Then
                    TreeViewBeforeDelete()
                End If
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
                End If
                RaiseEvent AfterDelete(retValue)
                If _withTreeView Then
                    TreeViewAfterDelete(retValue)
                End If
                'UpdateViewDisplay(TargetIdNo)
            End If
        End If
        Return retValue
    End Function

    Private Sub GoEditRecord()
        If IsOkToEditRecord() Then
            RaiseEvent BeforeEdit()
            If CancelEdit Then
                CancelEdit = False
            Else
                EditMode = True
            End If
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
        RecordPositionNumber = 1
    End Sub

    Public Sub GoLastRecord()
        RecordPositionNumber = RecordCount
        'If OkToMove() Then
        'RecordPositionNumber = GetRecordCount()
        'RecordCount = RecordPositionNumber
        'End If
    End Sub

    Public Sub GoNextRecord()
        If RecordPositionNumber = RecordCount Then
            Messaging.Show(True, "MsgLastRecordHit", "This is already the last record.", "Last Record")
        Else
            RecordPositionNumber += 1
        End If
    End Sub

    Public Sub GoPreviousRecord()
        If RecordPositionNumber = 1 Or RecordPositionNumber = 0 Then
            Messaging.Show(True, "MsgFirstRecordHit", "This is already the first record.", "First Record")
        Else
            RecordPositionNumber -= 1
        End If
    End Sub

    Public Overridable Sub GoPrintRecord()

    End Sub

    Public Sub GoQuit()
        LateBinding.SetProperty(View, "CancelClose", {False})
    End Sub

    Public Overridable Function MessageBeforeSave() As Boolean
        Dim retVal As Boolean = False
        Dim caption = "Please confirm."
        Dim action As String = Messaging.TranslateCaption("save")
        Dim itemName As String = Messaging.TranslateCaption("transaction")
        Dim msg = Messaging.GetParametrizedMessage(True, "AskIfContinueAction", {"action", action, "itemName", itemName})
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
        If AddMode Then
            AddMode = False
            RecordPositionNumber = GetSortedRecordPosition(LastIdNo)
        Else
            EditMode = False
            UpdateViewDisplay(TargetIdNo)
            'RecordPositionNumber = RecordPositionNumber
        End If
        ClearAllErrorMessages()
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
        If CheckIfUnique(ControlDescription(cCtrl), fldName, TargetIdNo) Then
            Return False
        End If
        Return True
    End Function

    'Public Overridable Function OkToMove() As Boolean
    '    Dim retValue As Boolean = False
    '    If QuitOnSave Then
    '        retValue = True
    '    ElseIf Not (EditMode OrElse AddMode) Then
    '        retValue = True
    '    Else
    '        Dim result As DialogResult
    '        If ChangesMade() Then
    '            result = SaveOrAbandonChanges()
    '            If result = DialogResult.Yes Or result = DialogResult.No Then
    '                If result = DialogResult.Yes Then
    '                    result = Save()
    '                    If result > 0 Then
    '                        Messaging.Show(True, "MsgRecordSuccessfullySaved", "Record saved successfully!", "Record Saved")
    '                        If AddMode Then
    '                            RecordPositionNumber = GetSortedRecordPosition(TargetIdNo)
    '                        End If
    '                        retValue = True
    '                    End If
    '                Else
    '                    If AddMode Then
    '                        RecordPositionNumber = GetSortedRecordPosition(LastIdNo)
    '                    Else
    '                        RecordPositionNumber = RecordPositionNumber
    '                    End If
    '                    retValue = True
    '                End If
    '            Else
    '                retValue = False
    '            End If
    '        Else
    '            retValue = True
    '        End If
    '    End If
    '    If retValue Then
    '        If AddMode Then
    '            AddMode = False
    '        Else
    '            EditMode = False
    '        End If
    '    End If
    '    Return retValue
    'End Function

    Public Overridable Function Save(ByRef viewControl As Control)
        RaiseEvent BeforeSave()
        Dim record As New TM
        GlobalVariables.Mapper.Map(Of IView, TM)(View, record)
        Dim retVal As Integer = InitiateSave()
        If retVal < 0 Then
            Messaging.Show(True, "MsgSaveRecordFailed", "Something went wrong during saving, saving record failed", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If _withTreeView Then
                TreeViewAfterSave()
            End If
            RaiseEvent AfterSave()
        End If
        If retVal < 0 Then
        Else
            Messaging.Show(True, "MsgRecordSuccessfullySaved", "Record saved successfully!", "Record Saved")
            If AddMode Then
                RecordPositionNumber = GetSortedRecordPosition(retVal)
                'TargetIdNo = retVal
            End If
            'turn off addmode/editmode
            AddMode = False
            EditMode = False
            UpdateViewDisplay(TargetIdNo)
            ClearAllErrorMessages()
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
        GlobalVariables.Mapper.Map(Of T, TM)(View, OriginalModel)
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
                'Save()
                'UpdateViewDisplay(TargetIdNo)
            ElseIf result = DialogResult.No Then
                ' undo changes retrieve the last record
                TargetIdNo = LastIdNo
                'UpdateViewDisplay(TargetIdNo)
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
            'RecordCount = GetRecordCount()
            RecordDateTimeStampValue = GetRecordDateTimeStamp(TargetIdNo)
            modelData = Model.GetRecordByIdNo(Of TM)(idNo)
            RaiseEvent AfterRecordRetrieval(modelData)
            If GlobalVariables.EventAggregator IsNot Nothing Then
                GlobalVariables.EventAggregator.PublishEvent(New BeforeAssignment(modelData))
            End If
            GlobalVariables.Mapper.Map(Of TM, T)(modelData, View)
            For Each child In ChildPresenters
                child.UpdateViewDisplay(idNo)
            Next
            If _withTreeView Then
                TreeViewUpdateViewDisplay(idNo)
            End If
            CurrentRecordChanged()
            ClearAllErrorMessages()
        End If
    End Sub

    Public Sub CurrentRecordChanged()
        'CallByName(View, "CurrentRecordChanged", CallType.Method, {EditMode, AddMode, RecordPositionNumber, TargetIdNo, RecordCount})
        LateBinding.InvokeFunction(View, "CurrentRecordChanged", {EditMode, AddMode, RecordPositionNumber, TargetIdNo, RecordCount})
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

    Protected Overridable Function SaveAddedRecord(record As TM) As Integer
        Dim retVal As Integer
        NewlyAddedRecordIdNo = Model.AddRecord(record)
        retVal = NewlyAddedRecordIdNo
        LateBinding.SetProperty(View, IdFieldName, retVal)
        Return retVal
    End Function

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
        Dim retValue As Boolean = True
        GlobalVariables.Mapper.Map(Of T, TM)(View, DataModel)
        If Not Model.IsValid(DataModel) Then
            retValue = False
        End If
        Dim rules = GetBizObjectRules()
        For Each rule In rules
            Dim control As Control = Nothing
            If Not rule.Valid Then
                MainFieldsDictionary.TryGetValue(rule.Property, control)
                FormatError(control, rule.Error)
            End If
        Next
        Return retValue
    End Function

    Private Sub FormatError(ctrl As Object, ctrlError As String)
        If DirectCast(ctrl, Control).Dock = DockStyle.Fill Then
            MyErrorProvider.SetIconPadding(ctrl, -18)
        End If
        If GlobalVariables.RightToLeftLayout Then
            MyErrorProvider.SetIconAlignment(ctrl, ErrorIconAlignment.TopLeft)
        Else
            MyErrorProvider.SetIconAlignment(ctrl, ErrorIconAlignment.TopRight)
        End If
        Dim controlError As String
        controlError = MyErrorProvider.GetError(ctrl)
        If controlError Is Nothing OrElse controlError = "" Then
            controlError = ctrlError
        Else
            controlError += Environment.NewLine & ctrlError
        End If
        MyErrorProvider.SetError(ctrl, controlError)
        _dataErrors += Environment.NewLine + ctrlError
    End Sub

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
            parentIdNo = LateBinding.GetProperty(View, IdFieldName)
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
                Dim idNo As Integer = LateBinding.GetProperty(dataView, dataViewIdNoFieldName)
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
                    retValue = SaveAddedRecord(record)
                    If retValue > 0 Then
                        Dim retVal As Integer = retValue
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
            MessageBox.Show(ex.Message, $"Transaction Aborted")
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

    Public Function MakeEnumComboList(Of TE)() Implements IPresenter.MakeEnumComboList
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

    'Public Function MakeEnumComboList2(Of TE)()
    '    Dim dataList As New List(Of ClassesLibrary.LookupData)
    '    For Each c In [Enum].GetValues(GetType(TE))
    '        Dim data As New ClassesLibrary.LookupData With {
    '                .IdNo = CInt(c),
    '                .Code = CInt(c),
    '                .Name = Messaging.TranslateCaption(c.ToString().SplitCamelCase())
    '                }
    '        dataList.Add(data)
    '    Next
    '    Return dataList
    'End Function

    Public Sub AddToParentError(errors As List(Of String))
        Dim mainBizObj = DirectCast(DirectCast(DirectCast(Model, Model).DataService, ServicesLayer.Services.Service).DataBo, BusinessLayer.BusinessObject)
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

    'Public Overridable Function ValidateView()
    '    Dim validationsPassed As Boolean
    '    validationsPassed = True
    '    Dim allControls As New List(Of Control)
    '    Dim originalValue As String
    '    Dim cForm As Form
    '    cForm = View
    '    For Each cCtrl As Control In FindControlRecursive(allControls, Me)
    '        If TypeOf cCtrl Is IEntryControl Then

    '            If TypeOf cCtrl Is CTextBoxIdNo Then
    '                ' no validations for this type of control. These are Identity Columns and are filled automatically
    '                ' by the Data Server.
    '            ElseIf TypeOf cCtrl Is CTextBox AndAlso GetPropertyValue(cCtrl, "ComputedValue") Then
    '                ' ignore this also computed values don't need to be validated for empty values
    '            ElseIf TypeOf cCtrl Is CTextBoxArabic Then
    '                Dim thisControl As CTextBoxArabic
    '                thisControl = cCtrl
    '                If thisControl.EnglishControl Is Nothing Then
    '                    MessageBox.Show($"EnglishControl for  CTextBoxArabic control <{thisControl.Name}> not set.")
    '                End If
    '                originalValue = PresenterObj.GetOriginalValue(thisControl.EnglishControl)
    '                Dim englishText As String = GetPropertyValue(thisControl.EnglishControl, "Text")
    '                If thisControl.AutoFill And String.IsNullOrEmpty(cCtrl.Text) OrElse cCtrl.Text.Trim() = originalValue Then
    '                    thisControl.Text = englishText
    '                End If
    '            ElseIf TypeOf cCtrl Is CTextBox Then 'OrElse TypeOf cCtrl Is CTextBoxArabic Then
    '                ' check for duplicate values
    '                Dim thisControl As CTextBox = cCtrl
    '                If thisControl.ValueIsNumeric Then
    '                    If Not IsNumberValid(cCtrl) Then
    '                        validationsPassed = False
    '                    End If
    '                End If
    '                If validationsPassed AndAlso GetPropertyValue(cCtrl, "ValueIsUnique") Then
    '                    validationsPassed = ValueIsUnique(cCtrl, validationsPassed)
    '                End If
    '                If validationsPassed AndAlso GetPropertyValue(cCtrl, "ValueIsUniqueBlanksAllowed") Then
    '                    If cCtrl IsNot Nothing AndAlso cCtrl.Text <> "" Then
    '                        validationsPassed = ValueIsUnique(cCtrl, validationsPassed)
    '                    End If
    '                End If
    '            End If

    '        End If
    '    Next
    '    AutoValidationsPassed = validationsPassed
    '    Return validationsPassed
    'End Function

    Public Sub OnFindFieldRequested_EventHandler(ByRef eventType As FindFieldRequested) Implements ISubscriber(Of FindFieldRequested).OnEventHandler
        Dim idNo = Model.FindFieldNew(TableName, eventType.FindableControl, SortOrderKey, DataFilter)
        If idNo <> 0 Then
            RecordPositionNumber = GetSortedRecordPosition(idNo)
        Else
            Messaging.Show(True, "MsgNoMatchingRecordFound")
        End If
    End Sub

    Public Sub OnViewButtonClicked_EventHandler(ByRef eventType As ViewButtonClicked) Implements ISubscriber(Of ViewButtonClicked).OnEventHandler
        Select Case eventType.SelectedButton
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
            'Case ButtonClicked.Save
            '    GoSaveRecord()
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

    Public Sub OnEntryFormLoaded_EventHandler(ByRef eventType As EntryFormLoaded) Implements ISubscriber(Of EntryFormLoaded).OnEventHandler
        Dim rules = GetBizObjectRules()
        For Each rule In rules
            Dim control As Control = Nothing
            MainFieldsDictionary.TryGetValue(rule.Property, control)
            MyErrorProvider.Controls.AddValidation(control, rule.Property, rule.Error)
        Next
        Dim tableColumnPropertyList As List(Of TblColPropModel)
        tableColumnPropertyList = ModelTblColProp.GetMainTableColumnProperties(TableName)
        TableProperties = tableColumnPropertyList.ToArray
        SetAllControlsDynamicProperties(eventType.ViewControl)
        If _withTreeView Then
            DisplayTree()
        End If
    End Sub

    Public Sub OnEventHandler(ByRef eventType As SaveDataRequested) Implements ISubscriber(Of SaveDataRequested).OnEventHandler
        ' Validate record first for errors before saving
        Dim validated As Boolean = True
        RaiseEvent BeforeValidate()
        PreValidate()
        ClearAllErrorMessages()
        _dataErrors = ""
        validated = CheckForDataErrors(eventType)
        If validated AndAlso EditMode AndAlso Not ChangesMade() Then
            Messaging.Show(True, "MsgNoChangesMadeNothingToSave", "No changes made, nothing to save!", "Nothing to save")
        Else
            If Not IsBizDataValid() Then
                validated = False
            End If
        End If
        If validated Then
            Save(eventType.ViewControl)
        Else
            Beep()
            Messaging.MessageKey = "ValidationErrors"
            Messaging.Show("Record not saved!" & Environment.NewLine & _dataErrors, $"Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'ShowErrors("Record not saved!" & Environment.NewLine & _dataErrors)
        End If
    End Sub

    Private Function CheckForDataErrors(eventType As SaveDataRequested) As Boolean
        Dim validated As Boolean = True
        For Each item In MainFieldsDictionary
            Dim cCtrl = item.Value
            Dim fldName = item.Key
            'If fldName = "CreditLimit" Then
            '    Debugger.Break()
            'End If
            If CheckForNumericValue(cCtrl) Then
                If TypeOf cCtrl Is CTextBox Then
                    Dim cTextTextBox As CTextBox = cCtrl
                    If cTextTextBox.ValueIsNumeric Then
                        If Not IsNumberValid(eventType.ViewControl, cCtrl) Then
                            validated = False
                        End If
                    End If
                End If
            End If
            If CheckForUniqueness(cCtrl) Then
                If Not ValueIsUnique(cCtrl) Then
                    If GetPropertyValue(cCtrl, "ValueIsUniqueBlanksAllowed") Then
                        If cCtrl IsNot Nothing AndAlso cCtrl.Text <> "" Then
                            validated = False
                        End If
                    Else
                        validated = False
                    End If
                End If
            End If
        Next
        Return validated
    End Function

    Private Sub PreValidate()
        For Each item In MainFieldsDictionary
            If TypeOf item.Value Is CTextBoxArabic Then
                UpdateArabicControl(item.Value)
            End If
        Next
    End Sub

    Private Sub UpdateArabicControl(cCtrl As CTextBoxArabic)
        If cCtrl.EnglishControl Is Nothing Then
            MessageBox.Show($"EnglishControl for  CTextBoxArabic control <{cCtrl.Name}> not set.")
        End If
        Dim originalValue As String = GetOriginalValue(cCtrl.EnglishControl)
        Dim englishText As String = GetPropertyValue(cCtrl.EnglishControl, "Text")
        If cCtrl.AutoFill And String.IsNullOrEmpty(cCtrl.Text) OrElse cCtrl.Text.Trim() = originalValue Then
            cCtrl.Text = englishText
        End If
    End Sub

    'Public Sub OnEventHandler(ByRef eventType As ValidateViewRequested) Implements ISubscriber(Of ValidateViewRequested).OnEventHandler
    '    Dim validationsPassed As Boolean
    '    validationsPassed = True
    '    Dim allControls As New List(Of Control)
    '    Dim originalValue As String
    '    Dim cForm As Control
    '    cForm = eventType.ViewControl
    '    For Each cCtrl As Control In FindControlRecursive(allControls, cForm)
    '        If TypeOf cCtrl Is IEntryControl Then
    '            If TypeOf cCtrl Is CTextBoxIdNo Then
    '                ' no validations for this type of control. These are Identity Columns and are filled automatically
    '                ' by the Data Server.
    '            ElseIf TypeOf cCtrl Is CTextBox AndAlso GetPropertyValue(cCtrl, "ComputedValue") Then
    '                ' ignore this also computed values don't need to be validated for empty values
    '            ElseIf TypeOf cCtrl Is CTextBoxArabic Then
    '                Dim thisControl As CTextBoxArabic
    '                thisControl = cCtrl
    '                If thisControl.EnglishControl Is Nothing Then
    '                    MessageBox.Show($"EnglishControl for  CTextBoxArabic control <{thisControl.Name}> not set.")
    '                End If
    '                originalValue = GetOriginalValue(thisControl.EnglishControl)
    '                Dim englishText As String = GetPropertyValue(thisControl.EnglishControl, "Text")
    '                If thisControl.AutoFill And String.IsNullOrEmpty(cCtrl.Text) OrElse cCtrl.Text.Trim() = originalValue Then
    '                    thisControl.Text = englishText
    '                End If
    '            ElseIf TypeOf cCtrl Is CTextBox Then 'OrElse TypeOf cCtrl Is CTextBoxArabic Then
    '                ' check for duplicate values
    '                Dim thisControl As CTextBox = cCtrl
    '                If thisControl.ValueIsNumeric Then
    '                    If Not IsNumberValid(eventType.ViewControl, cCtrl) Then
    '                        validationsPassed = False
    '                    End If
    '                End If
    '                If validationsPassed AndAlso GetPropertyValue(cCtrl, "ValueIsUnique") Then
    '                    validationsPassed = ValueIsUnique(cCtrl, validationsPassed)
    '                End If
    '                If validationsPassed AndAlso GetPropertyValue(cCtrl, "ValueIsUniqueBlanksAllowed") Then
    '                    If cCtrl IsNot Nothing AndAlso cCtrl.Text <> "" Then
    '                        validationsPassed = ValueIsUnique(cCtrl, validationsPassed)
    '                    End If
    '                End If
    '            End If

    '        End If
    '    Next
    '    'AutoValidationsPassed = validationsPassed
    '    eventType.ValidView = validationsPassed
    'End Sub

    Public Function IsNumberValid(ByRef viewControl As Control, ByRef obj As CTextBox)
        Dim returnValue As Boolean = True
        Dim objName = Strings.Mid(obj.Name, 4)
        'If objName = "CreditLimit" Then
        '    Debugger.Break()
        'End If
        Dim targetValue = obj.Text
        Dim y As PropertyInfo = viewControl.GetType().GetProperty(objName, BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.IgnoreCase)
        If y IsNot Nothing Then
            Dim x As Type = y.PropertyType
            Dim u As Type = Nullable.GetUnderlyingType(x)
            If targetValue Is Nothing OrElse targetValue.Equals(DBNull.Value) OrElse String.IsNullOrWhiteSpace(targetValue) Then
                Return True
            Else
                Dim controlName As String = ControlDescription(obj)
                Dim num As Double
                If Not IsNumeric(targetValue) Then
                    FormatError(obj, Messaging.GetParametrizedMessage(True, "MsgInvalidNumericValue", {"controlName", controlName, "text", obj.Text}))
                    returnValue = False
                Else
                    Dim nMinValue As Double
                    Dim nMaxValue As Double
                    Dim typeCode As TypeCode = Type.GetTypeCode(x)
                    Dim underlyingTypeCode As TypeCode = Type.GetTypeCode(u)
                    If u Is Nothing Then
                        nMinValue = GetMinMaxValue(typeCode, nMaxValue)
                    Else
                        typeCode = Type.GetTypeCode(u)
                        nMinValue = GetMinMaxValue(underlyingTypeCode, nMaxValue)
                    End If
                    num = Val(targetValue)
                    If num < nMinValue OrElse num > nMaxValue Then
                        Dim err As String = Messaging.GetParametrizedMessage(True, "MsgNumericOverflow", {"number", obj.Text, "controlName", controlName, "lowNumber", nMinValue.ToString(), "highNumber", nMaxValue.ToString()})
                        returnValue = False
                    End If
                    Dim isInteger As Boolean = False
                    If u Is Nothing Then
                        If NumTypeIsInteger(typeCode) Then
                            isInteger = True
                        End If
                    Else
                        If NumTypeIsInteger(underlyingTypeCode) Then
                            isInteger = True
                        End If
                    End If
                    If isInteger Then
                        If Not Math.Abs(num Mod 1) <= (Double.Epsilon * 100) Then
                            FormatError(obj, Messaging.GetParametrizedMessage(True, "MsgInvalidInteger", {"number", obj.Text, "controlName", controlName}))
                            returnValue = False
                        End If
                    End If
                    If num < obj.MinimumValue OrElse num > obj.MaximumValue Then
                        FormatError(obj, Messaging.GetParametrizedMessage(True, "MsgNumericOverflow", {"number", obj.Text, "controlName", controlName, "lowNumber", obj.MinimumValue, "highNumber", obj.MaximumValue}))
                        returnValue = False
                    End If
                End If

                ''Dim isNumeric As Boolean = Decimal.TryParse(targetValue, num)
                'If Not IsNumeric() Then
                '    FormatError(obj, Messaging.GetParametrizedMessage(True, "MsgInvalidNumericValue", {"controlName", controlName, "text", obj.Text}))
                '    returnValue = False
                'End If

            End If
        End If
        Return returnValue
    End Function

    Private Function ValueIsUnique(cCtrl As Control) As Boolean
        Dim fldName As String = cCtrl.Name.Substring(3)
        Dim recordIsNotUnique = False
        If AddMode Then
            If IsRecordNotUnique(cCtrl, fldName) Then
                recordIsNotUnique = True
            End If
        Else
            Dim originalValue As String
            originalValue = GetOriginalValue(cCtrl)
            ' if value did not change no need to check for duplicate values.
            If cCtrl.Text <> originalValue Then
                If IsRecordNotUnique(cCtrl, fldName) Then
                    recordIsNotUnique = True
                End If
            End If
        End If
        If recordIsNotUnique Then
            Messaging.ShowParametrizedMessage(True, "MsgDuplicateValuesNotAllowed", {"fieldName", cCtrl.Text, "fieldDescription", ControlDescription(cCtrl)})
            Return False
        End If
        Return True
    End Function

    Private Function CheckForUniqueness(cCtrl As Control) As Boolean
        If GetPropertyValue(cCtrl, "ValueIsUnique") IsNot Nothing Then
            If GetPropertyValue(cCtrl, "ValueIsUnique") Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Function CheckForNumericValue(cCtrl As Control) As Boolean
        If GetPropertyValue(cCtrl, "ValueIsNumeric") IsNot Nothing Then
            Return True
        End If
        Return False
    End Function

    Public Function ValidateNumericValues(sender As Control)
        Dim validationsPassed As Boolean
        validationsPassed = True
        Dim allControls As New List(Of Control)
        For Each cCtrl As Control In FindControlRecursive(allControls, sender)
            If TypeOf cCtrl Is IEntryControl Then
                If TypeOf cCtrl Is CTextBox Then
                    Dim thisControl As CTextBox = cCtrl
                    If thisControl.ValueIsNumeric Then
                        If Not IsNumberValid(sender, cCtrl) Then
                            validationsPassed = False
                        End If
                    End If
                End If
            End If
        Next
        Return validationsPassed
    End Function

    Private Sub SetAllControlsDynamicProperties(viewControl As Control)
        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
            Dim allControls As New List(Of Control)
            Dim resources = New ComponentResourceManager(Me.GetType())
            For Each cCtrl As Control In FindControlRecursive(allControls, viewControl)
                'If cCtrl.Name = "txtCreditLimit" Then
                '    Debugger.Break()
                'End If
                SetControlDynamicProperties(cCtrl)
                SetObjectSecurityNew(cCtrl)
            Next
        End If
    End Sub

    Private Sub ClearAllErrorMessages()
        Dim myDict = MainFieldsDictionary
        For Each cCtrl As Control In myDict.Values
            MyErrorProvider.SetError(cCtrl, "")
        Next
    End Sub

    Private Sub SetControlDynamicProperties(ByRef cCtrl As Control)
        'Dim myView = cCtrl.FindForm()
        If TypeOf cCtrl Is IEntryControl Then
            ' get FieldName from control : by convention when using this system
            ' all DataBoundControls TextBox & Combobox that will hold field variables are named by convention in this format
            ' textboxes  = txt<FieldName>
            ' combobox   = cbo<FieldName>
            ' datetimePicker = dtp<FieldName>
            ' so to get the field name just get the characters from the control starting at the 4th character onwards
            Dim fldName As String
            fldName = cCtrl.Name.Substring(3) ' get control name starting from the 3rd character (0 based)

            For Each row In TableProperties
                If fldName.ToLower() = row.FldName.ToLower Then
                    If TypeOf cCtrl Is CTextBox Or TypeOf cCtrl Is CMaskedTextBox OrElse TypeOf cCtrl Is CTextBoxArabic Then
                        If row.FldType.ToLower = "int" OrElse
                            row.FldType.ToLower = "smallint" OrElse
                            row.FldType.ToLower = "money" OrElse
                            row.FldType.ToLower = "decimal" OrElse
                            row.FldType.ToLower = "bigint" OrElse
                            row.FldType.ToLower = "tinyint" OrElse
                            row.FldType.ToLower = $"smallmoney" OrElse
                            row.FldType.ToLower = "real" OrElse
                            row.FldType.ToLower = "float" OrElse
                            row.FldType.ToLower = "numeric" Then
                            Select Case row.FldType.ToLower
                                Case "int"
                                    SetPropertyValue(cCtrl, "MinimumValue", -2147483648D)
                                    SetPropertyValue(cCtrl, "MaximumValue", 2147483648D)
                                Case "tinyint"
                                    SetPropertyValue(cCtrl, "MinimumValue", 0D)
                                    SetPropertyValue(cCtrl, "MaximumValue", 255D)
                                Case "smallint"
                                    SetPropertyValue(cCtrl, "MinimumValue", -32768D)
                                    SetPropertyValue(cCtrl, "MaximumValue", 32767D)
                                Case "bigint"
                                    SetPropertyValue(cCtrl, "MinimumValue", -922337236854775808D)
                                    SetPropertyValue(cCtrl, "MaximumValue", 922337236854775807D)
                                Case "money"
                                    SetPropertyValue(cCtrl, "MinimumValue", -922337203685477.5808D)
                                    SetPropertyValue(cCtrl, "MaximumValue", 922337203685477.5807D)
                                Case $"smallmoney"
                                    SetPropertyValue(cCtrl, "MinimumValue", -214748.3647D)
                                    SetPropertyValue(cCtrl, "MaximumValue", 214748.3647D)
                            End Select
                            SetPropertyValue(cCtrl, "ValueIsNumeric", True)
                        Else
                            SetPropertyValue(cCtrl, "Maxlength", If(row.fldType.ToLower() = "nvarchar", Convert.ToInt16(row.MaxLength / 2), row.MaxLength))
                            SetPropertyValue(cCtrl, "ValueIsNullable", row.IsNullable)
                            If (Not row.IsIdentity) And (Not row.IsNullable) Then
                                If GetPropertyValue(cCtrl, "IgnoreNullCheck") Then
                                    MyErrorProvider.Controls.AddMandatory(cCtrl, ControlDescription(cCtrl))
                                End If
                            End If
                        End If
                        Exit For
                    ElseIf TypeOf cCtrl Is CaComboBox OrElse TypeOf cCtrl Is CComboBox Then
                        '
                        '
                    ElseIf TypeOf cCtrl Is CCustomDateTimePicker OrElse TypeOf cCtrl Is CDateTimePicker OrElse
                        TypeOf cCtrl Is CDTPHijriDate OrElse TypeOf cCtrl Is tdpGregorian OrElse
                        TypeOf cCtrl Is CDtpGregorianDate Then
                        SetPropertyValue(cCtrl, "ValueIsNullable", row.IsNullable)
                        If Not row.IsNullable Then
                            'Add this controls to the Mandatory fields error provider.
                            MyErrorProvider.Controls.AddMandatory(cCtrl, cCtrl.Name)
                        End If
                        Exit For
                    End If
                    If TypeOf cCtrl Is IFindableControl And Not (TypeOf cCtrl Is CForm) Then
                        Dim thisControl As IFindableControl = cCtrl
                        If thisControl.FindEnabled Then
                            thisControl = cCtrl
                            thisControl.FindDataType = GetObjectDataType(GetFieldType(ViewName.Substring(3)))
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub SetObjectSecurityNew(ByRef cCtrl As Control)
        Dim objectSecurityKey As String
        If TypeOf cCtrl Is MenuStrip Then
            ' check for MenuStrip first because MenuStrip is also a ToolStrip
            Dim subMenuName = MenuFormName + " > " + cCtrl.Name.Trim()
            Dim menuStrip As MenuStrip = cCtrl
            SetMenuSecurity(menuStrip, subMenuName)
            SetMenuStripItemsNew(menuStrip.Items, subMenuName)
        ElseIf TypeOf cCtrl Is ToolStrip Then
            Dim subMenuName = MenuFormName + " > " + cCtrl.Name.TrimEnd()
            Dim toolStrip As ToolStrip = cCtrl
            SetMenuSecurity(toolStrip, subMenuName)
            SetToolStripItemsNew(toolStrip.Items, subMenuName)
        Else
            objectSecurityKey = GetControlSecurityKey(cCtrl)
            If objectSecurityKey Is Nothing OrElse objectSecurityKey = "" Then
                'cCtrl.Visible = True
                'cCtrl.Enabled = True
            Else
                Dim controlSecurityValues As ArrayList
                Dim isEditable As Boolean
                Dim isVisible As Boolean
                controlSecurityValues = GetControlSecurityValues(objectSecurityKey)
                If controlSecurityValues.Count > 0 Then
                    isVisible = controlSecurityValues(0)
                    isEditable = controlSecurityValues(1)
                Else
                    isVisible = False
                    isEditable = False
                End If
                SetControlVisibility(cCtrl, isVisible)
                SetControlEditability(cCtrl, isEditable)
            End If
        End If
    End Sub

    Private Sub SetControlVisibility(ByRef cCtrl As Control, controlVisible As Boolean)
        ' if Visible is false, Don't show the controls content by masking content with '*' asterisk
        If Not controlVisible Then
            SetPropertyValue(cCtrl, "PasswordChar", Convert.ToChar("*"))
        End If
    End Sub

    Private Sub SetControlEditability(ByRef cCtrl As Control, ByRef editable As Boolean)
        ' if Editable is False, make the control readonly property so that it can't be edited
        If Not editable Then
            SetPropertyValue(cCtrl, "DisplayOnly", True)
        End If
    End Sub

    Private Function GetControlSecurityValues(ByRef controlSecurityKey As String, Optional menu As Boolean = False) As ArrayList
        Dim controlSecurityObjectIdNo As Int32
        controlSecurityObjectIdNo = GetControlSecurityIdNo(controlSecurityKey, menu)
        Return GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo)
    End Function

    Private Function GetControlSecurityKey(ByRef cCtrl As Control)
        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
            If cCtrl.GetType().GetProperty("SecurityKey") IsNot Nothing Then
                Return GetPropertyValue(cCtrl, "SecurityKey")
            End If
        End If
        Return ""
    End Function

    Private Sub SetMenuSecurity(cControl As Object, controlSecurityKey As String)
        If GlobalVariables.UserName = $"Arnel" Then
            ' make all editable and visible regardless of security values
            cControl.Enabled = True
            cControl.Visible = True
        Else
            Dim securityIdNo As Integer
            Dim controlSecurityValues As ArrayList
            Dim isSelectable As Boolean
            Dim isVisible As Boolean

            securityIdNo = GetControlSecurityIdNo(controlSecurityKey, True)
            If securityIdNo <> 0 Then
                controlSecurityValues = GetUserSecurity(Convert.ToInt16(securityIdNo), GlobalVariables.SecurityGroupIdNo)
                If controlSecurityValues.Count > 0 Then
                    ' Visible property stored in first element of the array
                    isVisible = controlSecurityValues(0)
                    isSelectable = controlSecurityValues(1)
                    ' Editable property stored in second element of the array
                Else
                    isVisible = False
                    isSelectable = False
                End If
            Else
                isVisible = True
                isSelectable = True
            End If
            cControl.Enabled = isSelectable
            If cControl.Visible Then
                cControl.Visible = isVisible
            End If
        End If
    End Sub

    Private Sub SetMenuStripItemsNew(dropDownItems As ToolStripItemCollection, pParentMenuName As String)
        For Each dropDownItem As Object In dropDownItems
            Dim subMenu = TryCast(dropDownItem, ToolStripMenuItem)
            If subMenu IsNot Nothing Then
                Dim parentMenuName = pParentMenuName
                ApplyMenuSecurityNew(dropDownItem, parentMenuName)
                If subMenu.HasDropDown Then
                    Dim childSubMenuName As String = pParentMenuName + " > " + Mid(dropDownItem.Name, 18)
                    SetMenuStripItemsNew(subMenu.DropDownItems, childSubMenuName)
                End If
            End If
        Next
    End Sub

    Private Sub ApplyMenuSecurityNew(ByRef obj As ToolStripMenuItem, ByRef subMenuName As String)
        Dim toolStripMenuItem As ToolStripMenuItem = obj
        Dim controlSecurityKey = subMenuName + " > " + Mid(toolStripMenuItem.Name, 18)
        If GlobalVariables.IsUserLoggedIn Then
            SetMenuSecurity(toolStripMenuItem, controlSecurityKey)
        Else
            toolStripMenuItem.Enabled = False
            toolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub SetToolStripItemsNew(dropDownItems As ToolStripItemCollection, subMenuName As String)
        For Each obj As Object In dropDownItems
            ' ReSharper disable once VBPossibleMistakenCallToGetType.2
            If obj.GetType().ToString() = "System.Windows.Forms.ToolStripButton" Then
                Dim toolStripButton As ToolStripButton = obj
                Dim controlSecurityKey = Mid(toolStripButton.Name, 16).TrimEnd()
                If GlobalVariables.IsUserLoggedIn Then
                    Dim controlSecurityValues As ArrayList
                    Dim isSelectable As Boolean
                    Dim isVisible As Boolean
                    Dim securityIdNo As Int32 = GetControlSecurityIdNo(subMenuName + " > " + controlSecurityKey, True)
                    If securityIdNo <> 0 Then
                        If GlobalVariables.SecurityGroupIdNo <> 0 Then
                            controlSecurityValues = GetUserSecurity(securityIdNo, GlobalVariables.SecurityGroupIdNo)
                            If controlSecurityValues.Count > 0 Then
                                ' Visible property stored in first element of the array
                                isVisible = controlSecurityValues(0)
                                ' Editable property stored in third element of the array
                                isSelectable = controlSecurityValues(1)
                            Else
                                isVisible = False
                                isSelectable = False
                            End If
                        Else
                            isVisible = True
                            isSelectable = False
                        End If
                    Else
                        isVisible = True
                        isSelectable = True
                    End If
                    toolStripButton.Enabled = isSelectable
                    toolStripButton.Visible = isVisible
                Else
                    If obj.Name = "ToolStripButtonLogin" Then
                        toolStripButton.Enabled = True
                        toolStripButton.Visible = True
                    Else
                        toolStripButton.Enabled = False
                        toolStripButton.Visible = True
                    End If
                End If
            Else
                obj.Enabled = True
                obj.Visible = True
            End If
        Next

    End Sub

    Public Function GetFieldType(fieldName As String) As Type
        Return LateBinding.GetProperty(Me, fieldName, CallType.Get).GetType
    End Function

    Public Function ControlDescription(control As Control)
        Dim description As String
        If TypeOf control Is ILinkedLabel Then
            description = DirectCast(control, ILinkedLabel).GetControlDescription()
        Else
            description = control.Name.Substring(control.Name, 3)
        End If
        Return description
    End Function

    'Public Sub ShowWaitForm_DoWorkHandler(sender As Object, e As DoWorkEventArgs(Of String))
    '    If ShowWaitForm.CancellationPending Then
    '        e.Cancel = True
    '        Return
    '    End If
    '    e.Result = PresenterObj.GetIdNoOfSortedPositionNumber(PresenterObj.RecordPositionNumber)
    'End Sub

    'Public Sub GotoTargetRecordWorker_DoWorkHandler(sender As Object, e As DoWorkEventArgs(Of String))
    '    If GotoTargetRecordWorker.CancellationPending Then
    '        e.Cancel = True
    '        Return
    '    End If
    '    PresenterObj.TargetIdNo = e.Argument
    '    PresenterObj.RecordPositionNumber = PresenterObj.GetSortedRecordPosition(PresenterObj.TargetIdNo)
    '    PresenterObj.TargetIdNo = PresenterObj.GetIdNoOfSortedPositionNumber(PresenterObj.RecordPositionNumber)
    '    PresenterObj.UpdateViewDisplay(PresenterObj.TargetIdNo)
    '    DoPaintEvents()
    'End Sub

    Public Sub OnGetDataSourceHandler(ByRef eventType As GetDataSource) Implements ISubscriber(Of GetDataSource).OnEventHandler
        Dim data As List(Of ClassesLibrary.LookupData)
        data = GetLookup(eventType.TableName)
        'CallByName(eventType.Control, "DataSource", CallType.Set, data)
        LateBinding.SetProperty(eventType.Control, "DataSource", {data})
    End Sub

    Public Sub OnGetLookupDataRequestedHandler(ByRef eventType As GetLookupDataRequested) Implements ISubscriber(Of GetLookupDataRequested).OnEventHandler
        If eventType.View IsNot Nothing Then
            Dim data As List(Of ClassesLibrary.LookupData)
            If eventType.Fields Is Nothing Then
                data = GetLookup(eventType.TableName, eventType.Filter)
            Else
                data = GetLookup(eventType.TableName, eventType.SortKey, eventType.Fields, eventType.Filter)
            End If
            'CallByName(eventType.View, eventType.TargetProperty, CallType.Set, data)
            LateBinding.SetProperty(eventType.View, eventType.TargetProperty, {data})
        End If
    End Sub

    'Public Sub OnGetEnumListHandler(Of TE)(ByRef eventType As GetEnumListRequested) Implements ISubscriber(Of GetEnumListRequested).OnEventHandler
    '    Dim dataList As New List(Of ClassesLibrary.LookupData)
    '    For Each c In [Enum].GetValues(GetType(TE))
    '        Dim data As New ClassesLibrary.LookupData With {
    '                .IdNo = CInt(c),
    '                .Code = EnumToCode(c),
    '                .Name = Messaging.TranslateCaption(c.ToString().SplitCamelCase())
    '                }
    '        dataList.Add(data)
    '    Next
    '    eventType.Target = dataList
    'End Sub

    'Public Sub OnEventHandler(Of TE)(ByRef eventType As GetEnumListRequested) Implements ISubscriber(Of GetEnumListRequestedNew).OnEventHandler
    '    Dim dataList As New List(Of ClassesLibrary.LookupData)
    '    For Each c In [Enum].GetValues(GetType(TE))
    '        Dim data As New ClassesLibrary.LookupData With {
    '                .IdNo = CInt(c),
    '                .Code = EnumToCode(c),
    '                .Name = Messaging.TranslateCaption(c.ToString().SplitCamelCase())
    '                }
    '        dataList.Add(data)
    '    Next
    '    eventType.Target = dataList
    'End Sub

#Region "TreeView"

    Protected TreeViewList
    Protected TreeViewMainField As String
    Protected TreeViewParentIdField As String
    Protected TreeViewSecondaryField As String
    Protected ParentFieldName As String = ""
    Protected WithEvents FormTreeView As TreeView
    Protected NodeToDelete As TreeNode

    'Public Sub NewTreeView()
    '    FormTreeView = CallByName(View, "FormTreeView", CallType.Get)
    'End Sub

    'Public Sub OnTvEntryFormLoaded_EventHandler(ByRef eventType As EntryFormLoaded) Implements ISubscriber(Of EntryFormLoaded).OnEventHandler
    '    DisplayTree()
    'End Sub

    Protected Sub DisplayTree()
        Dim root As TreeNode = FormTreeView.Nodes(0)
        root.Nodes.Clear()
        root.Text = Messaging.TranslateCaption(TableName)
        ' create the tree
        If GlobalVariables.RightToLeftLayout Then
            FormTreeView.RightToLeft = RightToLeft.Yes
            FormTreeView.RightToLeftLayout = True
        Else
            FormTreeView.RightToLeft = RightToLeft.No
            FormTreeView.RightToLeftLayout = False
        End If
        Dim treeViewData As Object = GetTreeViewData()
        If ParentFieldName Is Nothing OrElse ParentFieldName = "" Then
            For Each dataNode In treeViewData
                AddRecordToTree(dataNode)
            Next
        Else
            For Each dataNode In treeViewData
                AddRecordToTreeHierarchical(dataNode, True, FormTreeView)
            Next
        End If
        FormTreeView.ExpandAll()
        GotoRecordInTreeView()
    End Sub

    Public Function GetTreeViewData()
        Dim cModel As New TM
        Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of TM)(SortOrderKey, cModel)
        Dim treeMainFieldName = TranslateField(Of TM)(TreeViewMainField, cModel)
        If TreeViewParentIdField Is Nothing OrElse TreeViewParentIdField = "" Then
            If String.IsNullOrEmpty(TreeViewSecondaryField) Then
                Return Model.GetLookup(TableName, newSortOrderKey, {IdFieldName, treeMainFieldName}, DataFilter)
            Else
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

    Protected Overloads Sub AddRecordToTreeHierarchical(dataNode As Object, parentChanged As Boolean, treeViewTableName As TreeView)
        'Dim parentFieldName As String = CallByName(View, "ParentFieldName", CallType.Get)
        Dim parentIdValue As Integer? = GetPropertyValue(dataNode, ParentFieldName)
        If parentIdValue Is Nothing OrElse parentIdValue = 0 Then
            AddRecordToTree(dataNode) ', "Name")
        Else
            Dim idNo As Int32 = GetPropertyValue(dataNode, "IdNo")
            Dim mainValue As String = GetPropertyValue(dataNode, "Name")
            Dim secondaryValue As String = GetPropertyValue(dataNode, "Code")
            Dim treeNode As TreeNode = MakeTreeNode(mainValue, secondaryValue, idNo)
            If parentIdValue Is Nothing OrElse parentIdValue = 0 Then
                If parentChanged Then
                    treeViewTableName.Nodes(treeViewTableName.Nodes.Count - 1).Nodes.Add(treeNode)
                Else
                    treeViewTableName.Nodes(0).Nodes.Add(treeNode)
                End If
            Else
                If parentChanged Then
                    Dim foundNode As TreeNode() = treeViewTableName.Nodes.Find(parentIdValue.ToString(), True)
                    If foundNode.Length <> 0 Then
                        foundNode(0).Nodes.Add(treeNode)
                    End If
                End If
            End If
        End If
    End Sub

    Protected Overloads Sub AddRecordToTree(dataNode As Object) ', mainFieldName As String)
        Dim idNo As Int32 = GetPropertyValue(dataNode, IdFieldName)
        Dim mainValue As String = GetPropertyValue(dataNode, "Name")
        Dim secondaryValue As String = GetPropertyValue(dataNode, "Code")
        Dim treeNode As TreeNode = MakeTreeNode(mainValue, secondaryValue, idNo)
        FormTreeView.Nodes(0).Nodes.Add(treeNode)
    End Sub

    Protected Function MakeTreeNode(mainFieldValue As String, secondaryFieldValue As String, idNo As Int32) _
        As TreeNode
        Dim treeTextDisplay As String
        treeTextDisplay = TreeNodeTextDisplay(mainFieldValue, secondaryFieldValue)
        Return New TreeNode With {
            .Text = treeTextDisplay,
            .Tag = idNo,
            .Name = idNo
            }
    End Function

    Protected Overridable Function TreeNodeTextDisplay(tvName As String, ByVal Optional tvAdditionalText As String = "") _
        As String
        Return tvName.Trim() + If(String.IsNullOrEmpty(tvAdditionalText), "", " (" + tvAdditionalText.ToString().Trim() + ")")
    End Function

    Private Sub GotoRecordInTreeView()
        Dim found As TreeNode() = FormTreeView.Nodes.Find(TargetIdNo, True)
        If found.Length <> 0 Then
            With FormTreeView
                .SelectedNode = found(0)
                .HideSelection = False
                .Select()
            End With
        End If
        If FormTreeView.SelectedNode IsNot Nothing AndAlso FormTreeView.SelectedNode.IsVisible Then
            FormTreeView.SelectedNode.EnsureVisible()
        End If
    End Sub

    Public Function GetTreeNodeText()
        Dim cModel As New TM
        Dim cText As String
        Dim treeMainFieldName = TranslateField(Of TM)(TreeViewMainField, cModel)
        If String.IsNullOrEmpty(TreeViewSecondaryField) Then
            cText = LateBinding.GetProperty(View, treeMainFieldName).Trim() + " | " + CType(LateBinding.GetProperty(View, IdFieldName), String).Trim()
        Else
            Dim addText = LateBinding.GetProperty(View, TreeViewSecondaryField)
            cText = LateBinding.GetProperty(View, treeMainFieldName).Trim() + " | " + CType(LateBinding.GetProperty(View, IdFieldName), String).Trim() +
                    If(String.IsNullOrEmpty(addText), "", " (" + addText.ToString().Trim() + ")")
        End If
        Return cText
    End Function

    Public Sub TreeViewUpdateViewDisplay(idNo As Int32)
        GotoRecordInTreeView()
    End Sub

    Protected Sub BfTvEntry_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles FormTreeView.AfterSelect
        Select Case e.Action
            Case TreeViewAction.ByKeyboard
                    'MessageBox.Show("You like the keyboard!")

            Case TreeViewAction.ByMouse
                'MessageBox.Show("You like the mouse!")
            Case Else
                ' A problem here is causing a windows handle error when executing the below code.
                ' Therefore since this is just a selection change during initialization no need
                ' to execute the codes below so just exit the sub. This will also make initialization
                ' faster because no more need to move the database anyway at initialization the
                ' first record will be the one to be shown.
                Exit Sub
        End Select
        Dim nTag As Integer
        FormTreeView.ImageIndex = 1
        If FormTreeView.SelectedNode.Tag Is Nothing Then
            RecordPositionNumber = 1
        Else
            nTag = FormTreeView.SelectedNode.Tag
            RecordPositionNumber = GetSortedRecordPosition(nTag)
        End If
        If Not FormTreeView.SelectedNode.IsVisible Then
            FormTreeView.SelectedNode.EnsureVisible()
        End If
    End Sub

    Private Sub FormTreeViewBeforeSelect(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs) Handles FormTreeView.BeforeSelect
        If EditMode Or AddMode Then
            e.Cancel = True
        End If
    End Sub

    Public Sub TreeViewBeforeDelete()
        NodeToDelete = FormTreeView.SelectedNode()
    End Sub

    Public Sub TreeViewAfterDelete(retVal As Integer)
        If retVal > 0 Then
            FormTreeView.Nodes.Remove(NodeToDelete)
        End If
    End Sub

    Private Sub TreeViewAfterSave()
        DisplayTree()
    End Sub

    Public Sub OnLanguageChangedEventHandler(ByRef eventType As LanguageChanged) Implements ISubscriber(Of LanguageChanged).OnEventHandler
        DisplayTree()
    End Sub

#End Region

End Class

Public Class ViewButtonClicked

    Public Sub New(ByVal selectedButton As ButtonClicked)
        Me.SelectedButton = selectedButton
    End Sub

    Public Property SelectedButton As ButtonClicked

End Class

Public Class GetDataSource

    Public Sub New(ByVal tableName As String, ByRef control As Control, Optional ByVal filter As String = Nothing)
        Me.TableName = tableName
        Me.Control = control
        Me.Filter = filter
    End Sub

    Public Sub New(ByVal tableName As String, ByRef control As Control, ByVal fields As String(), Optional ByVal filter As String = Nothing)
        Me.TableName = tableName
        Me.Control = control
        Me.Filter = filter
        Me.Fields = fields
    End Sub

    Public Property TableName As String
    Public Property Control As Control
    Public Property Fields As String()
    Public Property Filter As String

End Class

Public Class GetLookupDataRequested

    Public Sub New(ByVal tableName As String, ByRef view As Control, targetProperty As String, ByVal Optional filter As String = Nothing)
        Me.TableName = tableName
        Me.TargetProperty = targetProperty
        Me.Filter = filter
        Me.View = view
    End Sub

    Public Sub New(ByVal tableName As String, ByRef view As Control, targetProperty As String, ByVal fields As String(), ByVal Optional filter As String = Nothing)
        Me.TableName = tableName
        Me.View = view
        Me.TargetProperty = targetProperty
        Me.Filter = filter
        Me.Fields = fields
    End Sub

    Public Sub New(ByVal tableName As String, ByRef view As Control, targetProperty As String, ByVal sortKey As String, ByVal fields As String(), ByVal Optional filter As String = Nothing)
        Me.TableName = tableName
        Me.View = view
        Me.TargetProperty = targetProperty
        Me.Filter = filter
        Me.SortKey = sortKey
        Me.Fields = fields
    End Sub

    Public Property TableName As String
    Public Property View As Control
    Public Property TargetProperty As String
    Public Property Fields As String()
    Public Property Filter As String
    Public Property SortKey As String
End Class

Public Class GetEnumListRequested

    Public Sub New(ByRef enumList As Object, ByRef target As List(Of ClassesLibrary.LookupData))
        Me.Target = target
        Me.EnumList = enumList
    End Sub

    Public Property Target As List(Of ClassesLibrary.LookupData)
    Public Property EnumList As Object

End Class

Public Class GetEnumListRequestedNew(Of TE)

    Public Sub New(ByRef enumList As TE, ByRef target As List(Of ClassesLibrary.LookupData))
        Me.Target = target
        Me.EnumList = enumList
    End Sub

    Public Property Target As List(Of ClassesLibrary.LookupData)
    Public Property EnumList As TE

End Class

Public Class SaveDataRequested

    Public Sub New(ByVal viewControl As Control)
        Me.ViewControl = viewControl
    End Sub

    Public Property ViewControl As Control
    Public Property ValidData As Boolean

End Class

Public Class FindFieldRequested

    Public Sub New(ByVal findableControl As IFindableControl)
        Me.FindableControl = findableControl
    End Sub

    Public Property FindableControl As IFindableControl

End Class

Public Class ValidateViewRequested

    Public Sub New(ByRef viewControl As Control)
        Me.ViewControl = viewControl
    End Sub

    Public Property ViewControl As Control
    Public Property ValidView As Boolean

End Class

Public Class IdNoEventArgs
    Inherits EventArgs

    Private _idNo As Int32

    Public Sub New(ByVal idNo As Int32)
        _idNo = idNo
    End Sub

    Public Property IdNo As Int32
        Get
            Return _idNo
        End Get
        Set(ByVal value As Int32)
            _idNo = value
        End Set
    End Property

End Class

Public Class EntryFormLoaded

    Public Sub New(ByVal viewControl As Control)
        Me.ViewControl = viewControl
    End Sub

    Public Property ViewControl As Control

End Class

Public Class LanguageChanged

    Public Sub New(ByVal viewControl As Control)
        Me.ViewControl = viewControl
    End Sub

    Public Property ViewControl As Control

End Class

'Public Enum ButtonClicked
'    [Add]
'    [Delete]
'    [Edit]
'    [Find]
'    [First]
'    [Last]
'    [Next]
'    [Previous]
'    [Quit]
'    [Save]
'    [Undo]
'    [Print]
'    [Filter]
'    [Translate]
'End Enum
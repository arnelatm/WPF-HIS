Imports System.ComponentModel
Imports System.Drawing
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
Imports AATM.ServicesLayer.Services
Imports AutoMapper
Imports KellermanSoftware.CompareNetObjects

''' <summary>
'''     Base class for all presenter classes. Keeps track of Service and View classes.
'''     Notice that Service is static and View is set in the constructor.
''' </summary>
''' <remarks>
'''     MV Patterns: MVP design pattern.
''' </remarks>
''' <typeparam name="TV">Type of itemView.</typeparam>
Public MustInherit Class Presenter(Of TV As IView, TM As New)
    Implements ISubscriber(Of ViewButtonClicked),
               ISubscriber(Of FindFieldRequested),
               ISubscriber(Of EntryFormLoaded),
               ISubscriber(Of SaveDataRequested),
               ISubscriber(Of GetDataSource),
               ISubscriber(Of GetLookupDataRequested),
               ISubscriber(Of LanguageChanged)

    Public ChildPresenters As New List(Of Object)
    Public ChildServices As New List(Of Service)
    Public IdFieldName As String = "IdNo"
    Public MyErrorProvider As New ErrorProviderExtended

    Friend DateTimeStampField As String = "DateTimeStamp"
    Friend RecordDateTimeStampValue As Object
    Protected CompareDifferences As String
    Protected Model As New TM
    Protected DataService
    Protected DbDataDao
    Protected OriginalModel
    Protected SortOrderKey As String = "IdNo"
    Protected DataFilter As String = Nothing
    Private _tableDefaultFieldValueList As List(Of DefaultFieldValueModel)
    Protected DefaultFieldValueService As New DefaultFieldValueService
    Public Property ViewDefaultFieldValues As List(Of DefaultFieldValueModel)
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

    'Private _withTreeView As Boolean = False
    Protected Service As Object

    Public Sub New(itemView As IView)
        If itemView IsNot Nothing Then
            Me.View = itemView
            'Me.Model = New TM
            MyErrorProvider = GetErrorProvider()
            If Ea IsNot Nothing Then
                Ea.SubscribeEvent(Me)
            End If
            InitializeTreeViewIfPresent()
            OriginalModel = Activator.CreateInstance(GetType(TM))
            Dim systemViewName As String
            If DirectCast(itemView, AATM.Libraries.CBaseControlsLibrary.CForm).ViewDisplayName IsNot Nothing Then
                systemViewName = DirectCast(itemView, AATM.Libraries.CBaseControlsLibrary.CForm).ViewDisplayName.Trim()
                If systemViewName Is Nothing Or systemViewName = "" Then
                    systemViewName = DirectCast(itemView, System.Windows.Forms.Control).Name.Trim()
                End If
            Else
                systemViewName = DirectCast(itemView, System.Windows.Forms.Control).Name.Trim()
            End If
            Dim data As List(Of DefaultFieldValue) = DefaultFieldValueService.GetDefaultFieldValues(systemViewName)
            ViewDefaultFieldValues = New List(Of DefaultFieldValueModel)
            GlobalVariables.Mapper.Map(data, ViewDefaultFieldValues)
        End If
        WithTreeView = True
    End Sub

    Public Sub MakeDefaultValues()
        For Each item In ViewDefaultFieldValues
            Select Case item.DataType
                Case DataTypeSelection.StringType
                    Invoker.SetProperty(View, item.FieldName, item.DefaultValue)
                Case DataTypeSelection.AccountType
                    Invoker.SetProperty(View, item.FieldName, item.DefaultValue)
                Case DataTypeSelection.IntegerType
                    Invoker.SetProperty(View, item.FieldName, CInt(item.DefaultValue))
                Case DataTypeSelection.BooleanType
                    Invoker.SetProperty(View, item.FieldName, CBool(item.DefaultValue))
                Case DataTypeSelection.SingleType
                    Invoker.SetProperty(View, item.FieldName, CSng(item.DefaultValue))
                Case DataTypeSelection.DoubleType
                    Invoker.SetProperty(View, item.FieldName, CDbl(item.DefaultValue))
                Case DataTypeSelection.DecimalType
                    Invoker.SetProperty(View, item.FieldName, CDec(item.DefaultValue))
                Case DataTypeSelection.LongType
                    Invoker.SetProperty(View, item.FieldName, CLng(item.DefaultValue))
                Case DataTypeSelection.DateType
                    If item.DefaultValue = "today" Then
                        Invoker.SetProperty(View, item.FieldName, Today())
                    ElseIf item.DefaultValue = "yesterday" Then
                        Invoker.SetProperty(View, item.FieldName, DateTime.Now.AddDays(-1))
                    ElseIf item.DefaultValue = "tomorrow" Then
                        Invoker.SetProperty(View, item.FieldName, DateTime.Now.AddDays(1))
                    Else
                        Invoker.SetProperty(View, item.FieldName, CDate(item.DefaultValue))
                    End If
                Case DataTypeSelection.ShortType
                    Invoker.SetProperty(View, item.FieldName, CShort(item.DefaultValue))
                Case DataTypeSelection.UIntegerType
                    Invoker.SetProperty(View, item.FieldName, CUInt(item.DefaultValue))
                Case DataTypeSelection.ULongType
                    Invoker.SetProperty(View, item.FieldName, CULng(item.DefaultValue))
                Case DataTypeSelection.UShortType
                    Invoker.SetProperty(View, item.FieldName, CUShort(item.DefaultValue))
                Case Else
                    MessageBox.Show($"Default Value Datatype Conversion for Field " & item.FieldName & " in form/view " & item.SystemViewName & " conversion not handled")
            End Select
        Next item
        Return
    End Sub

    Private Sub InitializeTreeViewIfPresent()
        Dim pi As PropertyInfo = View.GetType().GetProperty("FormTreeView")
        If pi IsNot Nothing Then
            _WithTreeView = True
            FormTreeView = pi.GetValue(View)
        End If
    End Sub

    Private Function GetErrorProvider() As Object
        Return Invoker.GetField(View, "MyErrorProvider")
    End Function

    Public Property WithTreeView As Boolean

    Protected Sub New()
        Service = New Service()
    End Sub

    Delegate Sub FillDataFunc(ByRef dataView As Object, ByRef workRow As DataRow)

    Public Event AfterDelete(retVal As Integer)

    'Public Event AfterRecordRetrieval(values As TM)

    Public Event AfterUpdateView()

    Public Event AfterSave()

    Public Event NewRecordInitialized()

    Public Event BeforeMappingData(dataModel As TM)

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
            Return Invoker.GetProperty(View, "MenuFormName")
        End Get
    End Property

    Protected ReadOnly Property ViewName As String
        Get
            Return Invoker.GetProperty(View, "Name")
        End Get
    End Property

    Protected ReadOnly Property MainFieldsDictionary As Dictionary(Of String, Object)
        Get
            'Return CallByName(View, "MainFieldsDictionary", CallType.Get)
            Return Invoker.GetField(View, "MainFieldsDictionary")
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
            UpdateViewDisplay()
        End Set
    End Property

    Public Property Ea As EventAggregator
        Get
            Return CallByName(View, "Ea", CallType.Get)
            'Return Invoker.GetField(View, "Ea")

        End Get
        Set(value As EventAggregator)
            _ea = value
        End Set
    End Property

    Protected Property QuitOnSave As Boolean
        Get
            Return Invoker.GetProperty(View, "QuitOnSave")
        End Get
        Set(value As Boolean)
            Invoker.SetProperty(View, "QuitOnSave")
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
            End If
            UpdateViewDisplay()
        End Set
    End Property

    Public Property LastIdNo As Int32

    ' This is the Service of the Inheriting Presenter
    ' when referred to in this module this will be the current Service
    ' while if referred in the Inheriting Presenter it will be the
    ' Service assigned to that presenter.
    'Public Property ModelOfPresenter
    '    Get
    '        Return Service
    '    End Get
    '    Set(value)
    '        Service = value
    '    End Set
    'End Property

    Public Property NewlyAddedRecordIdNo As Int32

    Public ReadOnly Property RecordCount As Integer
        Get
            Return Service.GetRecordCount(TableName, DataFilter)
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
            UpdateView(value)
            'CallByName(View, "CurrentRecordChanged", CallType.Method, {EditMode, AddMode, RecordPositionNumber, TargetIdNo, RecordCount})
        End Set
    End Property

    Protected Sub UpdateView(value As Integer)
        UpdateViewData(value)
        UpdateViewDisplay()
        RaiseEvent AfterUpdateView()
    End Sub

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

    Public Property View As TV

    'Protected Property Service As IModel
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
        If Service.CheckIfUnique(textValue, TableName, fieldName, pTargetIdNo) Then
            Return True
        End If
        Return False
    End Function

    Public Function CountRecordWithKey(searchValue As String, searchFieldName As String) As Integer
        Try
            Return Service.CountRecordWithKey(searchValue, TableName, searchFieldName)
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
                retValue = Service.DeleteRecord(idNo, TableName)
                If retValue > 0 Then
                    If Ea IsNot Nothing Then
                        Ea.PublishEvent(New RecordDeleted(idNo))
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
        Dim idNo = Service.FindFieldNew(TableName, findableControl, SortOrderKey, DataFilter)
        If idNo <> 0 Then
            RecordPositionNumber = GetSortedRecordPosition(idNo)
        Else
            Messaging.Show(True, "MsgNoMatchingRecordFound")
        End If
    End Sub

    Public Sub FindDateField(fieldName As String, findableControl As IFindableControl)
        Dim idNo = Service.FindDateField(TableName, findableControl, DataFilter)
        If idNo <> 0 Then
            RecordPositionNumber = GetSortedRecordPosition(idNo)
        Else
            Messaging.Show(True, "MsgNoMatchingRecordFound")
        End If
    End Sub

    Public Function FindFieldContinue(idNo As Int32) As Integer
        Return Service.FindFieldContinue(TableName, idNo, SortOrderKey)
    End Function

    Public Function FindRecord() As Integer
        Dim idNoOfFoundRecord As Integer = FindFieldContinue(TargetIdNo)
        Return idNoOfFoundRecord
    End Function

    Public Function GetAppSetting(ByVal settingCode As String, ByVal group As String, ByVal description As String)
        Dim retValue = Service.GetRecordFieldWithKey(settingCode, "Setting", "SettingCode", "Value")
        If retValue Is Nothing Then
            Dim setupName As String = Messaging.TranslateCaption(description)
            Dim groupSetting As String = group
            Messaging.ShowParametrizedMessage(True, "MsgSettingNotSet", {"setupName", setupName, "groupSetting", groupSetting})
            Return Nothing
        End If
        Return retValue
    End Function

    Public Function GetBizObjectErrors() As List(Of String)
        Return Service.GetBizObjectErrors()
    End Function

    Public Function GetBizObjectRules()
        Return Service.GetBizObjectRules()
    End Function

    Public Function GetControlSecurityIdNo(searchValue As String, Optional menu As Boolean = False) As String
        Try
            Return Service.GetControlSecurityIdNo(searchValue, menu)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetDepartmentUseSetting()
        Dim retValue = Service.GetRecordFieldWithKey("DEPT", "Setting", "SettingCode", "Value")
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

    Public Function GetFieldWithIdNo(idNo As Object, pTableName As String, returnFieldName As String)
        Try
            Return Service.GetFieldWithIdNo(idNo, pTableName, returnFieldName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetIdNoOfSortedPositionNumber(recordNo As Integer) As Integer
        Try
            Dim cModel As New TM
            Dim newSortOrder As String = GetTranslatedSortOrderKey(Of TM)(SortOrderKey, cModel)
            Return Service.GetIdNoOfSortedPositionNumber(recordNo, TableName, newSortOrder, DataFilter)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Overloads Function GetLookup(lookupObj As Lookup) As List(Of Lookup.LookupData)
        Return Service.GetLookup(lookupObj, False)
    End Function

    Public Overloads Function GetLookup(pTableName As String, Optional pFilter As String = Nothing) As List(Of Lookup.LookupData)
        Dim lookupObj As New Lookup(pTableName, pFilter)
        Return Service.GetLookup(lookupObj)
    End Function

    Public Overloads Function GetLookup(pTableName As String, pSortKey As String, Optional pFilter As String = Nothing) As List(Of Lookup.LookupData)
        Dim lookupObj As New Lookup(pTableName, pFilter)
        lookupObj.SortKey = pSortKey
        lookupObj.FilterKey = pFilter
        Return Service.GetLookup(lookupObj)
    End Function

    Public Overloads Function GetLookup(pTableName As String, pSortKey As String, pFieldsToShow As String(), Optional pFilter As String = Nothing) As List(Of Lookup.LookupData)
        Dim lookupObj As New Lookup(pTableName, pFilter)
        lookupObj.SortKey = pSortKey
        lookupObj.FilterKey = pFilter
        lookupObj.FieldsToShow = pFieldsToShow
        Return Service.GetLookup(lookupObj)
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

    'Public Function GetRecordCount(Optional pTableName As String = Nothing, Optional pFilter As String = Nothing) As Integer
    '    Try
    '        If pTableName Is Nothing Then
    '            pTableName = TableName
    '            Return Service.GetRecordCount(TableName, DataFilter)
    '        Else
    '            Return Service.GetRecordCount(pTableName, pFilter)
    '        End If
    '    Catch ex As Exception
    '        Return 0
    '    End Try
    'End Function

    Public Function GetRecordDateTimeStamp(idNo As Int32) As Object
        Try
            Return Service.GetRecordDateTimeStamp(idNo, TableName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetRecordField(cTableName As String, returnFieldName As String) As Object
        Try
            Return Service.GetRecordField(cTableName, returnFieldName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetRecordFieldWithKey(searchValue As String, cTableName As String, searchFieldName As String,
                                          returnFieldName As String) _
        As String
        Try
            Return Service.GetRecordFieldWithKey(searchValue, cTableName, searchFieldName, returnFieldName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetRecordFieldWithKeyG(Of TT)(searchValue As String, cTableName As String, searchFieldName As String, returnFieldName As String) As TT
        Try
            Return Service.GetRecordFieldWithKeyG(Of TT)(searchValue, cTableName, searchFieldName, returnFieldName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetRecordPosition(idNo As Int32)
        Try
            Return Service.GetRecordPosition(TableName, idNo) + 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetRevCostCenterUseSetting()
        Dim retValue = Service.GetRecordFieldWithKey("RCCN", "Setting", "SettingCode", "Value")
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
            Dim cModel As New TM
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of TM)(SortOrderKey, cModel)
            Return Service.GetSortedRecordPosition(idNo, TableName, newSortOrderKey, DataFilter)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetFieldValue(Of TType)(sqlStatement As String, cTableName As String, condition As String) As TType
        Try
            Return Service.GetFieldValue(Of TType)(sqlStatement, cTableName, condition)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetRecords(ByVal pTableName As String, ByVal sortOrder As String, ByVal fieldNames As String(), Optional filter As String = Nothing)
        Return Service.GetRecords(pTableName, sortOrder, fieldNames, filter)
    End Function

    Public Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int16) As ArrayList
        Return Service.GetUserSecurity(securityObjectIdNo, securityGroupIdNo)
    End Function

    Public Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList
        Return Service.GetUserSecurityForKey(securityObjectName, securityGroupIdNo)
    End Function

    Public Function AddSecurityObject(securityObject As SecurityObject) As Int32
        Return Service.AddSecurityObject(securityObject)
    End Function

    Public Function UpdateSecurityObject(securityObject As SecurityObject) As Int32
        If Service.CountRecordWithKey(securityObject.SecurityObjectName, "SecurityObject", "SecurityObjectName") = 0 Then
            Return Service.AddSecurityObject(securityObject)
        Else
            Return Service.GetRecordFieldWithKeyG(Of Int32)(securityObject.SecurityObjectName, "SecurityObject", "SecurityObjectName", "IdNo")
        End If
    End Function

    Public Function InitializeSecurityObject() As Integer
        Return Service.InitializeSecurityObject()
    End Function

    Public Overridable Sub GoAddRecord()
        LastIdNo = Invoker.GetProperty(View, IdFieldName)
        Try
            AddRecordInitializer()
            AddMode = True
        Catch oEx As Exception
            MsgBox("Error:   " + oEx.Message)
            AddMode = False
            'CallByName(View, "AddMode", CallType.Set, False)
        End Try
    End Sub

    Private Sub AddRecordInitializer()
        Model = New TM
        GlobalVariables.Mapper.Map(Model, View)
        RaiseEvent NewRecordInitialized()
    End Sub

    Public Overridable Function GoDeleteRecord() As Integer
        Dim record As New TM
        GlobalVariables.Mapper.Map(Of IView, TM)(View, record)
        Dim retValue = 0
        Dim currentIdNo = Invoker.GetProperty(View, IdFieldName)
        If IsOkToDeleteRecord() Then
            If Messaging.Show(True, "AskIfDeleteRecord", "Are you sure you want to delete this record?", "Please Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                RaiseEvent BeforeDelete()
                If _WithTreeView Then
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
                If _WithTreeView Then
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
        Invoker.SetProperty(View, "CancelClose", {False})
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
            UpdateViewData(TargetIdNo)
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
        If CheckIfUnique(cCtrl.Text, fldName, TargetIdNo) Then
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
            If _WithTreeView Then
                TreeViewAfterSave()
            End If
            RaiseEvent AfterSave()
        End If
        If retVal < 0 Then
        Else
            Messaging.Show(True, "MsgRecordSuccessfullySaved")
            If AddMode Then
                RecordPositionNumber = GetSortedRecordPosition(retVal)
            Else
                RecordPositionNumber = GetSortedRecordPosition(TargetIdNo)
            End If
            AddMode = False
            EditMode = False
            UpdateViewData(TargetIdNo)
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
        GlobalVariables.Mapper.Map(Of TV, TM)(View, OriginalModel)
    End Sub

    Public Sub ShowErrors(Optional ByVal additionalMessage As String = Nothing)
        If additionalMessage IsNot Nothing Then
            _errorList = additionalMessage + Environment.NewLine
        End If
        For Each bizError In Service.GetBizObjectErrors()
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
            UpdateViewData(TargetIdNo)
        End If
        If AddMode Then
            AddMode = False
        Else
            EditMode = False
        End If
    End Sub

    Public Overridable Sub UpdateViewData(idNo As Int32)
        If idNo <> 0 Then
            Dim modelData As TM
            RecordDateTimeStampValue = GetRecordDateTimeStamp(TargetIdNo)
            modelData = Service.GetRecordByIdNo(Of TM)(idNo)
            'RaiseEvent AfterRecordRetrieval(modelData)
            RaiseEvent BeforeMappingData(modelData)
            GlobalVariables.Mapper.Map(Of TM, TV)(modelData, View)
            For Each child In ChildPresenters
                child.UpdateViewDisplay(idNo)
            Next
            If _WithTreeView Then
                TreeViewUpdateViewDisplay(idNo)
            End If
            ClearAllErrorMessages()
        End If
    End Sub

    Protected Overridable Sub UpdateViewDisplay()
        'CallByName(View, "CurrentRecordChanged", CallType.Method, {EditMode, AddMode, RecordPositionNumber, TargetIdNo, RecordCount})
        Invoker.InvokeFunction(View, "UpdateViewDisplay", {EditMode, AddMode, RecordPositionNumber, TargetIdNo, RecordCount})
    End Sub

    Public Function UsePayGroups()
        Return Service.UsePayGroups()
    End Function

    Protected Overridable Function AdditionalChangesMadeCheck()
        Return False
    End Function

    Protected Overridable Function SaveAddedRecord(record As TM) As Integer
        Dim retVal As Integer
        NewlyAddedRecordIdNo = Service.AddRecord(record)
        retVal = NewlyAddedRecordIdNo
        CallByName(View, IdFieldName, CallType.Set, retVal)
        'Invoker.SetProperty(View, IdFieldName, retVal)
        Return retVal
    End Function

    'Protected Sub ComposeLookupParametersNew(listName As String)
    '    TableToGet = listName
    '    DisplayName = "Name"
    '    SortKey = DisplayName
    '    DisplayNameArabic = "NameAra"
    '    DisplayCode = "Code"
    'End Sub

    Protected Overridable Function DependentRecordsExist() As Boolean
        Return False
    End Function

    'Protected Function GetLookupByCodeName()
    '    ProcessLookupFields()
    '    Return Service.GetLookupByCodeName(LookUpTableToGet, LookUpSortExpression, LookUpFieldsToShow, LookUpFilterKey)
    'End Function

    'Protected Function GetLookupByName()
    '    ProcessLookupFields()
    '    Return Service.GetLookupByName(LookUpTableToGet, LookUpSortExpression, LookUpFieldsToShow, LookUpFilterKey)
    'End Function

    'Protected Function GetLookupByNameCode()
    '    ProcessLookupFields()
    '    Return Service.GetLookupByNameCode(LookUpTableToGet, LookUpSortExpression, LookUpFieldsToShow, LookUpFilterKey)
    'End Function

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
        GlobalVariables.Mapper.Map(Of TV, TM)(View, Model)
        If Not Service.IsValid(Model) Then
            retValue = False
        End If
        Dim rules = GetBizObjectRules()
        For Each rule In rules
            Dim control As Control = Nothing
            If Not rule.Valid Then
                If MainFieldsDictionary.TryGetValue(rule.Property, control) Then
                    FormatError(control, rule.Error)
                End If
            End If
        Next
        Return retValue
    End Function

    Private Sub FormatError(ctrl As Object, ctrlError As String)
        If DirectCast(ctrl, Control).Dock = DockStyle.Fill Then
            If TypeOf ctrl Is CaComboBox Then
                MyErrorProvider.SetIconPadding(ctrl, -27)
            Else
                MyErrorProvider.SetIconPadding(ctrl, -16)
            End If
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

    Protected Function UpdateChildData(ByRef childDataService As Service, updateTable As DataTable, insertTable As DataTable, passedValue As Integer, parentIdFieldName As String) As Integer
        Dim retVal As Integer
        Dim updateReturnValue As Object
        Dim insertReturnValue As Object
        Dim parentIdNo As Integer
        If AddMode Then
            parentIdNo = passedValue
        Else
            parentIdNo = Invoker.GetProperty(View, IdFieldName)
        End If
        updateReturnValue = childDataService.DelUpdateTvp(updateTable, parentIdNo)
        If updateReturnValue >= 0 AndAlso insertTable.Rows.Count > 0 Then
            If passedValue <> 0 Then
                For Each row As DataRow In insertTable.Rows
                    row.Item(parentIdFieldName) = parentIdNo
                Next
            End If
            insertReturnValue = childDataService.InsertTvp(insertTable)
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
        updateReturnValue = Service.DelUpdateTvp(updateTable, parentIdNo)
        If updateReturnValue >= 0 AndAlso insertTable.Rows.Count > 0 Then
            If parentIdNo <> 0 Then
                For Each row As DataRow In insertTable.Rows
                    row.Item(parentIdFieldName) = parentIdNo
                Next
            End If
            insertReturnValue = Service.InsertTvp(insertTable)
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
        'Return Service.UpdateRecord(record)
        Return Service.UpdateRecord(record)
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
                Dim idNo As Integer = Invoker.GetProperty(dataView, dataViewIdNoFieldName)
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
                newDateTimeStamp = Service.GetRecordDateTimeStamp(idNo, TableName, DateTimeStampField)
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
        Dim dataList As New List(Of Lookup.LookupData)
        For Each c In [Enum].GetValues(GetType(TE))
            Dim data As New Lookup.LookupData With {
                .IdNo = CInt(c),
                .Code = EnumToCode(c),
                .Name = Messaging.TranslateCaption(c.ToString().SplitCamelCase())
            }
            dataList.Add(data)
        Next
        Return dataList
    End Function

    Public Sub AddToParentError(errors As List(Of String))
        'Dim mainBizObj = DirectCast(DirectCast(DirectCast(Service, Service).DataService, ServicesLayer.Services.Service).DataBo, BusinessLayer.BusinessObject)
        Dim mainBizObj = DirectCast(DirectCast(Service, ServicesLayer.Services.Service).DataBo, BusinessLayer.BusinessObject)
        mainBizObj.AddError(errors)
    End Sub

    Public Sub OnFindFieldRequested_EventHandler(ByRef eventType As FindFieldRequested) Implements ISubscriber(Of FindFieldRequested).OnEventHandler
        Dim idNo = Service.FindFieldNew(TableName, eventType.FindableControl, SortOrderKey, DataFilter)
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
            If MainFieldsDictionary.TryGetValue(rule.Property, control) Then
                MyErrorProvider.Controls.AddValidation(control, rule.Property, rule.Error)
            End If
        Next
        Dim tableColumnPropertyList As List(Of TblColPropModel)
        tableColumnPropertyList = ModelTblColProp.GetMainTableColumnProperties(TableName)
        TableProperties = tableColumnPropertyList.ToArray
        SetAllControlsDynamicProperties(eventType.ViewControl)
        If _WithTreeView Then
            DisplayTree()
        End If
    End Sub

    Public Sub OnEventHandler(ByRef eventType As SaveDataRequested) Implements ISubscriber(Of SaveDataRequested).OnEventHandler
        ' Validate record first for errors before saving
        Dim validated As Boolean = True
        Dim noChanges As Boolean = False
        eventType.ValidData = False
        RaiseEvent BeforeValidate()
        PreValidate()
        ClearAllErrorMessages()
        _dataErrors = ""
        validated = CheckForDataErrors(eventType)
        If validated AndAlso (EditMode Or AddMode) Then
            If Not ChangesMade() Then
                Messaging.Show(True, "MsgNoChangesMadeNothingToSave", "No changes made, nothing to save!", "Nothing to save")
                noChanges = True
            Else
                If Not IsBizDataValid() Then
                    validated = False
                End If
            End If
        End If
        If noChanges Then
            GoUndoChanges()
        Else
            If validated Then
                Save(eventType.ViewControl)
                eventType.ValidData = True
            Else
                Beep()
                Messaging.MessageKey = "ValidationErrors"
                Messaging.Show("Record not saved!" & Environment.NewLine & _dataErrors, $"Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'ShowErrors("Record not saved!" & Environment.NewLine & _dataErrors)
            End If
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
            Dim errorMessage = Messaging.GetParametrizedMessage(True, "MsgDuplicateValuesNotAllowed", {"fieldValue", cCtrl.Text, "fieldDescription", ControlDescription(cCtrl)})
            FormatError(cCtrl, errorMessage)
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
        allControls = FindControlRecursive(allControls, sender)
        For Each cCtrl As Control In allControls
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
            ResetMenuSecurity(viewControl)
        End If
    End Sub

    Public Sub ResetMenuSecurity(viewControl As Control)

        Dim allControls As New List(Of Control)
        allControls = FindControlRecursive(allControls, viewControl)
        Dim resources = New ComponentResourceManager(Me.GetType())
        For Each cCtrl As Control In allControls
            'If cCtrl.Name = "dgvPcClosed" Then
            '    Debugger.Break()
            'End If
            SetControlDynamicProperties(cCtrl)
            SetObjectSecurity(cCtrl)
        Next
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
                    'If TypeOf cCtrl Is IFindableControl And Not (TypeOf cCtrl Is CForm) Then
                    '    Dim thisControl As IFindableControl = cCtrl
                    '    If thisControl.FindEnabled Then
                    '        thisControl = cCtrl
                    '        thisControl.FindDataType = GetObjectDataType(GetFieldType(cCtrl.Name.Substring(3)))
                    '    End If
                    'End If
                End If
            Next
        End If
    End Sub

    Public Sub SetObjectSecurity(ByRef cCtrl As Control)
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
                    If GlobalVariables.UserName.ToLower() = $"arnel" Then
                        isVisible = True
                        isEditable = True
                    Else
                        isVisible = False
                        isEditable = False
                    End If
                End If
                SetControlEditability(cCtrl, isEditable)
                SetControlVisibility(cCtrl, isVisible)
            End If
        End If
    End Sub

    Private Sub SetControlVisibility(ByRef cCtrl As Control, controlVisible As Boolean)
        ' if Visible is false, Don't show the controls content by masking content with '*' asterisk
        If Not controlVisible Then
            'If TypeOf cCtrl Is CTextBox OrElse TypeOf cCtrl Is TextBox Then
            '    SetPropertyValue(cCtrl, "PasswordChar", Convert.ToChar("*"))
            If TypeOf cCtrl Is CTabPage Then
                Dim tabControlObj As CTabControl
                Dim tabPageObj As CTabPage
                tabControlObj = cCtrl.Parent
                tabPageObj = cCtrl
                tabControlObj.TabPages.Remove(cCtrl)
            Else
                SetPropertyValue(cCtrl, "Visible", False)
            End If
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

    Private Function GetCdControlSecurityValues(ByRef controlSecurityKey As String, Optional menu As Boolean = False) As ArrayList
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
        Return Invoker.GetProperty(Me, fieldName, CallType.Get).GetType
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
    '    e.Result = Presenter.GetIdNoOfSortedPositionNumber(Presenter.RecordPositionNumber)
    'End Sub

    'Public Sub GotoTargetRecordWorker_DoWorkHandler(sender As Object, e As DoWorkEventArgs(Of String))
    '    If GotoTargetRecordWorker.CancellationPending Then
    '        e.Cancel = True
    '        Return
    '    End If
    '    Presenter.TargetIdNo = e.Argument
    '    Presenter.RecordPositionNumber = Presenter.GetSortedRecordPosition(Presenter.TargetIdNo)
    '    Presenter.TargetIdNo = Presenter.GetIdNoOfSortedPositionNumber(Presenter.RecordPositionNumber)
    '    Presenter.UpdateViewDisplay(Presenter.TargetIdNo)
    '    DoPaintEvents()
    'End Sub

    Public Sub OnGetDataSourceHandler(ByRef eventType As GetDataSource) Implements ISubscriber(Of GetDataSource).OnEventHandler
        SetDataSource(eventType.TableName, eventType.Control, eventType.Fields, eventType.SortKey, eventType.Filter)
    End Sub

    Protected Sub SetDataSource(dataTableName As String, control As Control, Optional dataFields As String() = Nothing, Optional sortKey As String = Nothing, Optional filter As String = Nothing)
        Dim data As List(Of Lookup.LookupData)
        Dim lookupObj As New Lookup(dataTableName)
        If dataFields IsNot Nothing Then
            lookupObj.FieldsToShow = dataFields
        End If
        If Not (sortKey Is Nothing OrElse sortKey = "") Then
            lookupObj.SortKey = sortKey
        End If
        If Not (filter Is Nothing OrElse filter = "") Then
            lookupObj.FilterKey = filter
        End If
        data = GetLookup(lookupObj)
        SetControlDataSource(control, data)
    End Sub

    Protected Sub SetControlDataSource(cControl As Control, data As List(Of Lookup.LookupData))
        Invoker.SetProperty(cControl, "DataSource", {data})
    End Sub

    Public Sub OnGetLookupDataRequestedHandler(ByRef eventType As GetLookupDataRequested) Implements ISubscriber(Of GetLookupDataRequested).OnEventHandler
        If eventType.View IsNot Nothing Then
            Dim data As List(Of Lookup.LookupData)
            If eventType.Fields Is Nothing Then
                data = GetLookup(eventType.TableName, eventType.Filter)
            Else
                data = GetLookup(eventType.TableName, eventType.SortKey, eventType.Fields, eventType.Filter)
            End If
            Invoker.SetProperty(eventType.View, eventType.TargetProperty, {data})
        End If
    End Sub

    'Public Sub OnEventHandlerValidatingData(ByRef e As ValidatingData) Implements ISubscriber(Of ValidatingData).OnEventHandler
    '    If Not ValidateView() Then
    '        e.Validated = False
    '    End If
    'End Sub

    'Public Overridable Function ValidateView()
    '    Dim validationsPassed As Boolean
    '    validationsPassed = True
    '    Dim allControls As New List(Of Control)
    '    Dim originalValue As String
    '    For Each cCtrl As Control In MainFieldsDictionary.Controls
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
    '                    If Not ValidateNumber(cCtrl) Then
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
    '    Presenter.AutoValidationsPassed = validationsPassed
    '    Return validationsPassed
    'End Function

    'Public Sub OnGetEnumListHandler(Of TE)(ByRef eventType As GetEnumListRequested) Implements ISubscriber(Of GetEnumListRequested).OnEventHandler
    '    Dim dataList As New List(Of Lookup.LookupData)
    '    For Each c In [Enum].GetValues(GetType(TE))
    '        Dim data As New Lookup.LookupData With {
    '                .IdNo = CInt(c),
    '                .Code = EnumToCode(c),
    '                .Name = Messaging.TranslateCaption(c.ToString().SplitCamelCase())
    '                }
    '        dataList.Add(data)
    '    Next
    '    eventType.Target = dataList
    'End Sub

    'Public Sub OnEventHandler(Of TE)(ByRef eventType As GetEnumListRequested) Implements ISubscriber(Of GetEnumListRequestedNew).OnEventHandler
    '    Dim dataList As New List(Of Lookup.LookupData)
    '    For Each c In [Enum].GetValues(GetType(TE))
    '        Dim data As New Lookup.LookupData With {
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
        Dim treeViewData As Object = GetTreeViewData()
        root.Text = Messaging.TranslateCaption(TableName)
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
        'Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of TM)(SortOrderKey, cModel)
        'Dim treeMainFieldName = TranslateField(Of TM)(TreeViewMainField, cModel)
        Dim lookupObj As New Lookup(TableName, DataFilter)
        lookupObj.NameField = TreeViewMainField
        If TreeViewSecondaryField IsNot Nothing Then
            lookupObj.CodeField = TreeViewSecondaryField
        End If
        If SortOrderKey IsNot Nothing Then
            lookupObj.SortKey = SortOrderKey
        End If
        'lookupObj.FieldsToShow = {"IdNo", lookupObj.NameField, lookupObj.CodeField}
        If ParentFieldName Is Nothing OrElse ParentFieldName = "" Then
            If String.IsNullOrEmpty(TreeViewSecondaryField) Then
                lookupObj.FieldsToShow = {IdFieldName, TreeViewMainField}
            Else
                lookupObj.FieldsToShow = {IdFieldName, TreeViewMainField, TreeViewSecondaryField}
            End If
            Return Service.GetLookup(lookupObj)
        Else
            lookupObj.SortKey = "SortKey"
            If String.IsNullOrEmpty(TreeViewSecondaryField) Then
                lookupObj.FieldsToShow = {IdFieldName, TreeViewMainField, ParentFieldName}
            Else
                lookupObj.FieldsToShow = {IdFieldName, TreeViewMainField, TreeViewSecondaryField, ParentFieldName}
            End If
            Return Service.GetHLookup(lookupObj)
        End If
    End Function

    Protected Overloads Sub AddRecordToTreeHierarchical(dataNode As Object, parentChanged As Boolean, treeViewTableName As TreeView)
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
            cText = Invoker.GetProperty(View, treeMainFieldName).Trim() + " | " + CType(Invoker.GetProperty(View, IdFieldName), String).Trim()
        Else
            Dim addText = Invoker.GetProperty(View, TreeViewSecondaryField)
            cText = Invoker.GetProperty(View, treeMainFieldName).Trim() + " | " + CType(Invoker.GetProperty(View, IdFieldName), String).Trim() +
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
            If e.Action = TreeViewAction.ByKeyboard Or e.Action = TreeViewAction.ByMouse Then
                'MessageBox.Show("You like the keyboard!")
                MessagingLibrary.Messaging.Show(True, "MsgTvSelectionNotAllowed")
            End If
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
        If _WithTreeView Then
            DisplayTree()
        End If
        Dim idNo = CallByName(View, IdFieldName, CallType.Get)
        TargetIdNo = idNo
        RecordPositionNumber = GetSortedRecordPosition(idNo)
        UpdateViewDisplay()
    End Sub

#End Region

End Class

Public Enum DataTypeSelection
    BooleanType = 0
    ByteType = 1
    AccountType = 2
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

'Public Class X
'    Public str As String

'    Public Function Clone() As Object
'        Return Me.MemberwiseClone()
'    End Function
'End Class

'Public Class Example
'    Public Shared Sub Main()
'        Dim obj As X = New X()
'        obj.str = "Hello!"
'        Dim copy As X = CType(obj.Clone(), X)
'        Console.WriteLine(copy.str)
'    End Sub
'End Class

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
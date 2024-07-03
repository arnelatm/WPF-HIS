Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Transactions
Imports System.Windows.Forms
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
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
Public MustInherit Class PresenterBase(Of TV As IView, TM As New)
    Implements ISubscriber(Of ViewButtonClicked),
               ISubscriber(Of EntryFormLoaded),
               ISubscriber(Of SaveDataRequested),
               ISubscriber(Of GetLookupDataTableRequested),
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
    Protected PromptOnSavedRecord As Boolean = False
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
    Private _undoMode As Boolean = False
    Private _ea As EventAggregator
    Private _dataErrors As String = ""
    Public Service As Object

    Public Event AfterDelete(retVal As Integer)

    Public Event AfterSave()

    Public Event AfterUpdateView()

    Public Event BeforeCompare()

    Public Event BeforeDelete()

    Public Event BeforeDisplayView()

    Public Event BeforeEdit()

    Public Event BeforeMappingData(dataModel As TM)

    Public Event BeforeSave()

    Public Event BeforeValidate()

    Public Event CancelChanges()

    Public Event EditingRecordChanged(editing As Boolean)

    Public Event LanguageChanged()

    Public Event NewRecordInitialized()

    Public Event RecordAddedSuccessfully(ByRef idNoOfRecord As Integer)
    Public Event GenerateCode(ByVal idNoOfRecord As Integer)

    Public Event RecordUpdatedSuccessfully(ByRef idNoOfRecord As Integer)

    Public Event SuccessfulDelete(idNoOfRecord As Integer)

    Public Event TextDisplayChanged()

    Public Event UndoEdits(addingRec As Boolean)

    Delegate Sub FillDataFunc(ByRef dataView As Object, ByRef workRow As DataRow)

    Public Sub New(itemView As IView)
        If itemView IsNot Nothing Then
            Me.View = itemView
            Me.DataFilter = View.DataFilter
            'Me.Model = New TM
            MyErrorProvider = GetErrorProvider()
            If Ea IsNot Nothing Then
                Ea.SubscribeEvent(Me)
            End If
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
    End Sub

    Public Sub MakeDefaultValues()
        For Each item In ViewDefaultFieldValues
            Select Case item.DataType
                Case DataTypeSelection.StringType
                    Invoker.SetProperty(View, item.FieldName, item.DefaultValue)
                Case DataTypeSelection.CharType
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

    Protected Function GetErrorProvider() As Object
        Return Invoker.GetField(View, "MyErrorProvider")
    End Function

    Protected Sub New()
        Service = New Service()
    End Sub

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

    Dim _mainFieldsDictionary As Dictionary(Of String, Object)

    Protected Property MainFieldsDictionary As Dictionary(Of String, Object)
        Get
            'Return CallByName(View, "MainFieldsDictionary", CallType.Get)
            Return Invoker.GetField(View, "MainFieldsDictionary")
        End Get
        Set(value As Dictionary(Of String, Object))
            _mainFieldsDictionary = value
        End Set
    End Property

    Public Sub CreateMainFieldsDictionary(fieldsDictionary As Dictionary(Of String, Object))
        MainFieldsDictionary = fieldsDictionary
    End Sub

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
    Public Property TableBaseName As String

    Public Property TableProperties As Array

    Public Property TargetIdNo As Int32
        Get
            Return _targetIdNo
        End Get
        Set(value As Integer)
            _targetIdNo = value
            UpdateView(value)
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

    Protected Shared Property ModelTblColProp As IModelTblColProp = New ModelTblColProp

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
            Messaging.ShowPmMessage(True, "MsgDateNotInRange", variables)
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
        'Dim result As ComparisonResult
        'If TypeOf OriginalModel Is UserSecurityModel Then
        '    Debugger.Break()
        '    If TypeOf View Is AATM.PresentationLayer.Views.Interfaces.IUserSecurityView Then
        '        Dim x As IUserSecurityView = View
        '        result = compareLogic.Compare(OriginalModel.UserAccesses, x.UserAccesses)
        '        ' note - if you encounter problems with comparison failure
        '        ' make sure that your model/view are 'Properties' and not 'Fields' because this
        '        ' comparison only compare 'Properties' excluding 'field' values
        '        If Not result.AreEqual Then
        '            CompareDifferences = result.DifferencesString
        '            retVal = True
        '        End If
        '    End If
        'Else
        Dim result As ComparisonResult = compareLogic.Compare(OriginalModel, View)
        ' note - if you encounter problems with comparison failure
        ' make sure that your model/view are 'Properties' and not 'Fields' because this
        ' comparison only compare 'Properties' excluding 'field' values
        If Not result.AreEqual Then
            CompareDifferences = result.DifferencesString
            retVal = True
        End If
        Return retVal
    End Function

    Public Function CheckIfUnique(textValue As String, fieldName As String, pTargetIdNo As Integer) As Boolean
        If Service.CheckIfUnique(textValue, TableName, fieldName, pTargetIdNo) Then
            Return True
        End If
        Return False
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
                Dim cTableName As String = TableBaseName
                If TableBaseName Is Nothing Or TableBaseName = "" Then
                    TableBaseName = TableName
                End If
                retValue = Service.DeleteRecord(idNo, TableBaseName)
                If retValue >= 0 Then
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

    Public Function GetAppSetting(ByVal settingCode As String, ByVal group As String, ByVal description As String)
        Dim retValue = Service.GetRecordFieldWithKey(settingCode, "Setting", "SettingCode", "Value")
        If retValue Is Nothing Then
            Dim setupName As String = Messaging.TranslateCaption(description)
            Dim groupSetting As String = group
            Messaging.ShowPmMessage(True, "MsgSettingNotSet", {"setupName", setupName, "groupSetting", groupSetting})
            Return Nothing
        End If
        Return retValue
    End Function


    Public Function GetRecordCount(tableName As String, Optional dataFilter As String = Nothing)
        Return Service.GetRecordCount(tableName, dataFilter)
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
            Messaging.ShowPmMessage(True, "MsgSettingNotSet", {"setupName", setupName, "groupSetting", groupSetting})
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

    Public Overloads Function GetListLookup(lookupObj As LookupTable) As DataTable
        Return Service.GetListLookup(lookupObj)
    End Function

    Public Overloads Function GetLookup(lookupObj As LookupTable) As List(Of LookupTable.LookupData)
        Return Service.GetLookup(lookupObj)
    End Function

    Public Overloads Function GetLookup(pTableName As String, Optional pFilter As String = Nothing) As List(Of LookupTable.LookupData)
        Dim lookupObj As New LookupTable(pTableName, pFilter)
        Return Service.GetLookup(lookupObj)
    End Function

    Public Overloads Function GetLookup(pTableName As String, pSortKey As String, Optional pFilter As String = Nothing) As List(Of LookupTable.LookupData)
        Dim lookupObj As New LookupTable(pTableName, pFilter)
        lookupObj.SortKey = pSortKey
        lookupObj.FilterKey = pFilter
        Return Service.GetLookup(lookupObj)
    End Function

    Public Overloads Function GetLookup(pTableName As String, pFieldsToShow As String(), Optional pFilter As String = Nothing) As List(Of LookupTable.LookupData)
        Dim lookupObj As New LookupTable(pTableName, pFilter)
        lookupObj.FieldsToShow = pFieldsToShow
        lookupObj.FilterKey = pFilter
        lookupObj.SortKey = pFieldsToShow(1)
        Return Service.GetLookup(lookupObj)
    End Function

    Public Overloads Function GetLookup(pTableName As String, pFieldsToShow As String(), pSortKey As String, Optional pFilter As String = Nothing) As List(Of LookupTable.LookupData)
        Dim lookupObj As New LookupTable(pTableName, pFilter)
        lookupObj.FieldsToShow = pFieldsToShow
        lookupObj.SortKey = pSortKey
        lookupObj.FilterKey = pFilter
        Return Service.GetLookup(lookupObj)
    End Function

    Public Function GetOriginalModel() As TM
        Return OriginalModel
    End Function

    Public Overloads Function GetLookupDataTable(lookupObj As DataTable) As DataTable
        Return Service.GetLookupDataTable(lookupObj)
    End Function

    Public Overloads Function GetLookupDataTable(pTableName As String, Optional pFilter As String = Nothing) As DataTable
        Dim lookupObj As New LookupTable(pTableName, pFilter)
        Return Service.GetLookupDataTable(lookupObj)
    End Function

    Public Overloads Function GetLookupDataTable(pTableName As String, pSortKey As String, Optional pFilter As String = Nothing) As DataTable
        Dim lookupObj As New LookupTable(pTableName, pFilter)
        lookupObj.SortKey = pSortKey
        lookupObj.FilterKey = pFilter
        Return Service.GetLookupDataTable(lookupObj)
    End Function

    Public Overloads Function GetLookupDataTable(pTableName As String, pFieldsToShow As String(), Optional pFilter As String = Nothing) As DataTable
        Dim lookupObj As New LookupTable(pTableName, pFilter)
        lookupObj.FieldsToShow = pFieldsToShow
        lookupObj.FilterKey = pFilter
        lookupObj.SortKey = pFieldsToShow(1)
        Return Service.GetLookupDataTable(lookupObj)
    End Function

    Public Overloads Function GetLookupDataTable(pTableName As String, pFieldsToShow As String(), pSortKey As String, Optional pFilter As String = Nothing) As DataTable
        Dim lookupObj As New LookupTable(pTableName, pFilter)
        lookupObj.FieldsToShow = pFieldsToShow
        lookupObj.SortKey = pSortKey
        lookupObj.FilterKey = pFilter
        Return Service.GetLookupDataTable(lookupObj)
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

    Public Function GetRecordDateTimeStamp(idNo As Int32) As Object
        Return Service.GetRecordDateTimeStamp(idNo, TableName)
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
        Return Service.GetRecordFieldWithKeyG(Of TT)(searchValue, cTableName, searchFieldName, returnFieldName)

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
            Messaging.ShowPmMessage(True, "MsgSettingNotSet", {"setupName", setupName, "groupSetting", groupSetting})
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

    Public Function GetFieldValue(Of TType)(returnFieldName As String, cTableName As String, condition As String) As TType
        Try
            Return Service.GetFieldValue(Of TType)(returnFieldName, cTableName, condition)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetFieldOnMaxField(searchFieldName As String, tableName As String, returnFieldName As String, Optional filter As String = Nothing) As Object
        Return Service.GetFieldOnMaxField(searchFieldName, tableName, returnFieldName, filter)
    End Function

    Public Function GetDtRecords(ByVal pTableName As String, ByVal fieldNames As String(), Optional filter As String = Nothing, Optional sortKey As String = Nothing, Optional ascending As Boolean = True)
        Return Service.GetDtRecords(pTableName, fieldNames, filter, sortKey, ascending)
    End Function

    Public Function GetDtRecords(ByVal pTableName As String, ByVal fieldNames As String, Optional filter As String = Nothing, Optional sortKey As String = Nothing, Optional ascending As Boolean = True)
        Return Service.GetDtRecords(pTableName, fieldNames, filter, sortKey, ascending)
    End Function

    Public Function GetRecords(ByVal pTableName As String, ByVal sortOrder As String, ByVal fieldNames As String(), Optional filter As String = Nothing)
        Return Service.GetRecords(pTableName, sortOrder, fieldNames, filter)
    End Function

    Public Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int16, userIdNo As Int16) As ArrayList
        Return Service.GetUserSecurity(securityObjectIdNo, securityGroupIdNo, userIdNo)
    End Function

    Public Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList
        Return Service.GetUserSecurityForKey(securityObjectName, securityGroupIdNo)
    End Function

    Public Function AddSecurityObject(securityObject As SecurityObject) As Int32
        Return Service.AddSecurityObject(securityObject)
    End Function

    Public Function UpdateSecurityObject(securityObject As SecurityObject) As Int32
        If Service.CountRecordWithKey(Of String)("SecurityObject", "SecurityObjectName", securityObject.SecurityObjectName) = 0 Then
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
        End Try
    End Sub

    Protected Sub AddRecordInitializer()
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
                retValue = DeleteRecord(currentIdNo)
                If retValue < 0 Then
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
            End If
        End If
        Return retValue
    End Function

    Protected Sub GoEditRecord()
        If IsOkToEditRecord() Then
            RaiseEvent BeforeEdit()
            If CancelEdit Then
                CancelEdit = False
            Else
                EditMode = True
            End If
        End If
    End Sub

    Public Sub GoFirstRecord()
        RecordPositionNumber = 1
    End Sub

    Public Sub GoLastRecord()
        RecordPositionNumber = RecordCount
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
        End If
        ClearAllErrorMessages()
    End Sub

    Public Overridable Function IsOkToEditRecord() As Boolean
        Return True
    End Function

    Public Overridable Function IsOkToDeleteRecord() As Boolean
        Dim retValue As Boolean = True
        If ChildRecordExist() Then
            retValue = False
        ElseIf DependentRecordExist() Then
            retValue = False
        End If
        Return retValue
    End Function

    Protected Overridable Function ChildRecordExist(Optional ByVal warn As Boolean = True) As Boolean
        Return False
    End Function

    Protected Overridable Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
        Return False
    End Function

    Public Function IsRecordNotUnique(cCtrl As Control, fldName As String) As Boolean
        If CheckIfUnique(cCtrl.Text, fldName, TargetIdNo) Then
            Return False
        End If
        Return True
    End Function

    Public Function CheckDependentRecords(Of T)(ByVal searchIdNo As T, ByVal dependentTableName As String, Optional searchFieldName As String = "", Optional returnIdFieldName As String = "IdNo") As Boolean
        If searchFieldName = "" Then
            searchFieldName = dependentTableName + "IdNo"
        End If
        Dim idNo = Service.GetRecordFieldWithKeyG(Of Integer, Integer)(searchIdNo, dependentTableName, searchFieldName, returnIdFieldName)
        If idNo > 0 Then
            Dim dependentTable = Messaging.TranslateCaption(dependentTableName)
            Dim additionalMessage = Messaging.GetParametrizedMessage(True, "MsgSeeTableEntry", {"tableName", dependentTable, "idNumber", idNo})
            Dim message = Messaging.GetParametrizedMessage(True, "MsgDependentRecordExists", {"additionalMessage", additionalMessage})
            Messaging.Show(message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        End If
        Return False
    End Function

    'Public Function CheckDependentRecords(Of TS)(ByVal searchValue As TS, ByVal dependentTableName As String, ByVal keyFieldName As String) As Boolean
    '    Dim idNo = Service.GetRecordFieldWithKeyG(Of Integer, Integer)(searchValue, dependentTableName, keyFieldName)
    '    If idNo > 0 Then
    '        Dim dependentTable = Messaging.TranslateCaption(dependentTableName)
    '        Dim additionalMessage = Messaging.GetParametrizedMessage(True, "MsgSeeTableEntry", {"tableName", dependentTable, "idNumber", idNo})
    '        Dim message = Messaging.GetParametrizedMessage(True, "MsgDependentRecordExists", {"additionalMessage", additionalMessage})
    '        Messaging.Show(message, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return True
    '    End If
    '    Return False
    'End Function

    Public Overridable Function Save(ByRef viewControl As Control) As Boolean
        CancelSave = False
        RaiseEvent BeforeSave()
        Dim retVal As Integer = 0
        If Not CancelSave Then
            Dim record As New TM
            GlobalVariables.Mapper.Map(Of IView, TM)(View, record)
            retVal = InitiateSave()
            If retVal < 0 Then
                Messaging.Show(True, "MsgSaveRecordFailed", "Something went wrong during saving, saving record failed", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                RaiseEvent AfterSave()
            End If
            If retVal < 0 Then
            Else
                If PromptOnSavedRecord Then
                    Messaging.Show(True, "MsgRecordSuccessfullySaved")
                Else
                    Messaging.MessageTimeOutNowait("Record Saved", "Record Saved", 1)
                End If
                If AddMode Then
                    RecordPositionNumber = GetSortedRecordPosition(retVal)
                Else
                    RecordPositionNumber = GetSortedRecordPosition(TargetIdNo)
                End If
                _addMode = False
                _editMode = False
                UpdateViewData(TargetIdNo)
                UpdateViewDisplay()
                ClearAllErrorMessages()
            End If
        Else
            retVal = -1
        End If
        Return retVal >= 0
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
        'If idNo <> 0 Then
        Dim modelData As TM
        Try
            RecordDateTimeStampValue = GetRecordDateTimeStamp(TargetIdNo)
        Catch ex As Exception
            RecordDateTimeStampValue = Nothing
        End Try
        modelData = Service.GetRecordByIdNo(Of TM)(idNo)

        RaiseEvent BeforeMappingData(modelData)
        GlobalVariables.Mapper.Map(Of TM, TV)(modelData, View)
        For Each child In ChildPresenters
            child.UpdateViewDisplay(idNo)
        Next
        'End If
        ClearAllErrorMessages()
    End Sub

    Protected Overridable Sub UpdateViewDisplay()
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
        Return retVal
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
            If TypeOf ctrl Is CtComboBox Then
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

    Protected Function TranslateFieldName(fieldToTranslate As String, tableName As String) As String
        Dim translatedField As String = fieldToTranslate
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            If GlobalVariables.RightToLeftLayout Then
                If Service.FieldExistInTable(fieldToTranslate + "ara", tableName) Then
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
        Return Service.UpdateRecord(record)
    End Function

    Protected Function CustomObjToDataTables(ByRef dataViews As Object, ByRef insertTable As DataTable, ByRef updateTable As DataTable, ByVal fillSub As FillDataFunc,
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

    Protected Function CustomObjToDataTable(ByRef dataObject As Object(), ByRef dataTable As DataTable) As DataRow
        If dataTable IsNot Nothing Then
            dataTable.Clear()
        End If
        Dim workRow As DataRow = Nothing
        For Each dataView In dataObject
            workRow = dataTable.NewRow()
            dataTable.Rows.Add(workRow)
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
            If AddMode Then
                RaiseEvent GenerateCode(retValue)
            End If

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
        Dim dataList As New List(Of LookupTable.LookupData)
        For Each c In [Enum].GetValues(GetType(TE))
            Dim data As New LookupTable.LookupData With {
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

    Public Overridable Sub OnViewButtonClicked_EventHandler(ByRef eventType As ViewButtonClicked) Implements ISubscriber(Of ViewButtonClicked).OnEventHandler
        Select Case eventType.SelectedButton
            Case ButtonClicked.Undo
                GoUndoChanges()
            Case ButtonClicked.Add
                GoAddRecord()
            Case ButtonClicked.Edit
                GoEditRecord()
            Case ButtonClicked.Print
                GoPrintRecord()
            Case ButtonClicked.Quit
                GoQuit()
            Case ButtonClicked.Translate
                GoTranslate()
            Case ButtonClicked.Filter
                GoFilter()
            Case Else
                ViewButtonClicked(eventType)
        End Select
    End Sub

    Public Overridable Sub ViewButtonClicked(ByRef eventType As ViewButtonClicked)

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
        CreateDataSources()
        EntryFormLoaded()
        eventType.AddingAllowed = UserHasAccess("Table" + TableName + "Adding")
        eventType.EditingAllowed = UserHasAccess("Table" + TableName + "Editing")
        eventType.DeletingAllowed = UserHasAccess("Table" + TableName + "Deleting")
        'GoFirstRecord()
        'GoLastRecord()
    End Sub

    Protected Overridable Sub CreateDataSources()
    End Sub

    Public Overridable Sub EntryFormLoaded()
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
                If Save(eventType.ViewControl) Then
                    eventType.ValidData = True
                Else
                    eventType.ValidData = False
                End If
            Else
                Beep()
                Messaging.MessageKey = "ValidationErrors"
                MessageBox.Show("Record not saved!" & Environment.NewLine & _dataErrors, $"Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                eventType.ValidData = False
                'ShowErrors("Record not saved!" & Environment.NewLine & _dataErrors)
            End If
        End If
    End Sub

    Private Function CheckForDataErrors(eventType As SaveDataRequested) As Boolean
        Dim validated As Boolean = True
        For Each item In MainFieldsDictionary
            Dim cCtrl = item.Value
            Dim fldName = item.Key
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

    Public Function IsNumberValid(ByRef viewControl As Control, ByRef obj As CTextBox)
        Dim returnValue As Boolean = True
        Dim objName = Strings.Mid(obj.Name, 4)
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
        allControls = GlobalFunctions.FindControlRecursive(allControls, sender)
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
        allControls = GlobalFunctions.FindControlRecursive(allControls, viewControl)
        Dim resources = New ComponentResourceManager(Me.GetType())
        For Each cCtrl As Control In allControls
            SetControlDynamicProperties(cCtrl)
            SetObjectSecurity(cCtrl)
        Next
    End Sub

    Protected Sub ClearAllErrorMessages()
        If MainFieldsDictionary.Count() > 0 Then
            Dim myDict = MainFieldsDictionary
            For Each cCtrl As Control In myDict.Values
                If cCtrl IsNot Nothing Then
                    MyErrorProvider.SetError(cCtrl, "")
                End If
            Next
        End If
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
                            Dim cTextBox As New CTextBox
                            Dim nMaxLength As Int16 = IIf(row.MaxLength = -1, 32767, row.MaxLength)
                            cTextBox = DirectCast(cCtrl, CTextBox)
                            If cTextBox.OverrideMaxLength = 0 Then
                                ' this command will limit the text length to the table field length so as not to have field length overflows.
                                ' if you don't want to follow this just enter the override length in the 'OverrideMaxLength' property
                                SetPropertyValue(cCtrl, "Maxlength", If(row.fldType.ToLower() = "nvarchar", Convert.ToInt16(nMaxLength / 2), nMaxLength))
                            Else
                                ' if you entered an overrideMaxLength value other than 0 then use that value. (Useful for barcode or QRCode scanning to get the 
                                ' full value of the barcode or qrcode and maybe process that data to just extract the value that you need. Say for Drug QRCodes
                                ' need to get the full qrcode text and just extract the GTIN value and discard the rest of the text
                                SetPropertyValue(cCtrl, "Maxlength", If(row.fldType.ToLower() = "nvarchar", Convert.ToInt16(nMaxLength / 2), cTextBox.OverrideMaxLength))
                            End If
                            SetPropertyValue(cCtrl, "ValueIsNullable", row.IsNullable)
                            If (Not row.IsIdentity) And (Not row.IsNullable) Then
                                If GetPropertyValue(cCtrl, "IgnoreNullCheck") Then
                                    MyErrorProvider.Controls.AddMandatory(cCtrl, ControlDescription(cCtrl))
                                End If
                            End If
                        End If
                        Exit For
                    ElseIf TypeOf cCtrl Is CtComboBox OrElse TypeOf cCtrl Is CComboBox Then
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
                'leave default values as is
            Else
                Dim controlSecurityValues As ArrayList
                Dim isEditable As Boolean
                Dim isVisible As Boolean
                controlSecurityValues = GetControlSecurityValues(objectSecurityKey)
                If controlSecurityValues.Count > 0 Then
                    isVisible = controlSecurityValues(0)
                    isEditable = controlSecurityValues(1)
                Else
                    If UserIsASuperAdmin() Then
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
            SetPropertyValue(cCtrl, "Visible", False)
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
        Return GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo, GlobalVariables.UserIdNo)
    End Function

    Private Function GetCdControlSecurityValues(ByRef controlSecurityKey As String, Optional menu As Boolean = False) As ArrayList
        Dim controlSecurityObjectIdNo As Int32
        controlSecurityObjectIdNo = GetControlSecurityIdNo(controlSecurityKey, menu)
        Return GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo, GlobalVariables.UserIdNo)
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
        If UserIsASuperAdmin() Then
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
                controlSecurityValues = GetUserSecurity(Convert.ToInt16(securityIdNo), GlobalVariables.SecurityGroupIdNo, GlobalVariables.UserIdNo)
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
                            controlSecurityValues = GetUserSecurity(securityIdNo, GlobalVariables.SecurityGroupIdNo, GlobalVariables.UserIdNo)
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


    Public Sub OnGetLookupDataRequestedTableHandler(ByRef eventType As GetLookupDataTableRequested) Implements ISubscriber(Of GetLookupDataTableRequested).OnEventHandler
        If eventType.Control IsNot Nothing Then
            Dim data As DataTable
            If eventType.Fields Is Nothing Then
                data = GetLookupDataTable(eventType.TableName, eventType.SortKey, eventType.Filter)
            Else
                data = GetLookupDataTable(eventType.TableName, eventType.Fields, eventType.SortKey, eventType.Filter)
            End If
            Invoker.SetProperty(eventType.Control, "DataSource", {data})
        End If
    End Sub

    Public Function UserHasAccess(securityKey As String, Optional inform As Boolean = False) As Boolean
        Dim hasAccess As Boolean
        If UserIsASuperAdmin() Then
            hasAccess = True
        Else
            Dim controlSecurityValues As ArrayList
            Dim controlSecurityObjectIdNo As Int32
            controlSecurityObjectIdNo = GetControlSecurityIdNo(securityKey)
            If controlSecurityObjectIdNo = 0 Then
                hasAccess = True
            Else
                controlSecurityValues = GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo, GlobalVariables.UserIdNo)
                If controlSecurityValues.Count > 0 Then
                    hasAccess = controlSecurityValues(1)
                Else
                    hasAccess = False
                End If
            End If
            If inform Then
                Dim securityKeyMessage = Messaging.TranslateCaption(securityKey)
                Dim message = Messaging.GetParametrizedMessage(True, "MsgNoAccessToSecurity", {"securityKey", securityKeyMessage})
                Messaging.Show(message)
            End If
        End If
        Return hasAccess
    End Function

    Public Sub OnPresenterBase_LanguageChangedEventHandler(ByRef eventType As LanguageChanged) Implements ISubscriber(Of LanguageChanged).OnEventHandler
        Dim type As Type = View.GetType
        If type.GetProperty("UpdateViewDisplay") IsNot Nothing Then
            UpdateViewDisplay()
            CreateDataSources()
            'RaiseEvent LanguageChanged()
        End If
        RaiseEvent LanguageChanged()
    End Sub

    'Public Sub CreateListDataSource(ByVal sourceTableName As String, ByVal fieldName As String, ByVal listName As String)
    '    SetListDataSource(sourceTableName, GetControlName(fieldName), listName)
    'End Sub

    Public Sub CreateListDataSource(ByVal sourceTableName As String, ByVal fieldName As String, ByVal listName As String)
        SetListDataSourceT(sourceTableName, GetControlName(fieldName), listName)
    End Sub

    'Public Sub CreateDataSource(ByVal sourceTableName As String, ByVal fieldName As String)
    '    CreateDataSource(sourceTableName, fieldName, Nothing, Nothing, Nothing)
    'End Sub

    'Public Sub CreateDataSource(ByVal sourceTableName As String, ByVal fieldName As String, ByVal list As Boolean, ByVal ListName As String)
    '    CreateDataSource(sourceTableName, fieldName, Nothing, Nothing, Nothing)
    'End Sub

    'Public Sub CreateDataSource(ByVal sourceTableName As String, ByVal fieldName As String, Optional filter As String = Nothing)
    '    CreateDataSource(sourceTableName, fieldName, Nothing, Nothing, filter)
    'End Sub

    'Public Sub CreateDataSource(ByVal sourceTableName As String, ByVal fieldName As String, Optional sortKey As String = Nothing, Optional filter As String = Nothing)
    '    CreateDataSource(sourceTableName, fieldName, Nothing, sortKey, filter)
    'End Sub

    'Public Sub CreateDataSource(ByVal sourceTableName As String, ByVal fieldName As String, fieldsArray As String(), Optional sortKey As String = Nothing, Optional filter As String = Nothing)
    '    SetDataSource(sourceTableName, GetControlName(fieldName), fieldsArray, sortKey, filter)
    'End Sub

    'Public Sub CreateDataSource(ByVal sourceTableName As String, ByVal fieldName As String, list As Boolean, fieldsArray As String(), Optional sortKey As String = Nothing, Optional filter As String = Nothing)
    '    SetDataSource(sourceTableName, GetControlName(fieldName), fieldsArray, sortKey, filter)
    'End Sub

    'Public Sub CreateDataSource(ByVal sourceTableName As String, ByVal control As Control, fieldsArray As String(), Optional sortKey As String = Nothing, Optional filter As String = Nothing)
    '    SetDataSource(sourceTableName, control, fieldsArray, sortKey, filter)
    'End Sub

    'Public Sub CreateDataSource(ByVal sourceTableName As String, ByVal control As Control)
    '    SetDataSource(sourceTableName, control, Nothing, Nothing, Nothing)
    'End Sub

    'Public Sub CreateDataSource(ByVal sourceTableName As String, ByVal control As Control, Optional ByVal filter As String = Nothing)
    '    SetDataSource(sourceTableName, control, Nothing, Nothing, filter)
    'End Sub

    'Public Sub CreateDataSourceGroupCode(ByVal fieldName As String, groupCode As String)
    '    Dim idNo As Int16
    '    idNo = Service.GetRecordFieldWithKeyG(Of Int16, String)(groupCode, "CodeGroup", "CodeGroupCode", "IdNo")
    '    CreateDataSource("ItemCode", fieldName, Nothing, Nothing, "CodeGroupIdNo = " & idNo.ToString())
    'End Sub

    Protected Function GetControlName(ByVal fieldName As String) As CtComboBox
        Dim control As Control = Nothing
        If Not MainFieldsDictionary.TryGetValue(fieldName, control) Then
            Debugger.Break()
            System.Windows.Forms.MessageBox.Show($"Field '" & fieldName & $"' is not present in the MainFieldsDictionary.")
        End If
        Return control
    End Function

    Protected Function GetFieldControlName(ByVal propertyName As String) As CtComboBox
        Dim control As CtComboBox = Nothing
        Try
            If Not MainFieldsDictionary.TryGetValue(propertyName, control) Then
                Debugger.Break()
                System.Windows.Forms.MessageBox.Show($"Field '" & propertyName & $"' is not present in the MainFieldsDictionary.")
            End If
        Catch ex As Exception
            Debugger.Break()
        End Try
        Return control
    End Function

    'Public Sub MakeControlDtDataSource(dataTableName As String, control As Control, Optional dataFields As String() = Nothing, Optional sortKey As String = Nothing, Optional filter As String = Nothing, Optional ascending As Boolean = True)
    '    Dim data As DataTable
    '    Dim lookupObj As LookupTable
    '    lookupObj = SetLookupObjectT(dataTableName, control,,, filter)
    '    data = GetLookupDT(lookupObj)
    '    Dim Task1
    '    Task1 = Task.Factory.StartNew(Sub() GetLookup(lookupObj))
    '    Task.WaitAll(Task1)
    '    Invoker.SetProperty(control, "DataSource", {data})
    'End Sub

    Protected Sub SetListDataSourceT(dataTableName As String, control As Control, listName As String)
        Dim data As DataTable
        Dim lookupObj As LookupTable
        lookupObj = SetLookupListObjectT(dataTableName, control, listName)
        data = GetListLookup(lookupObj)
        Invoker.SetProperty(control, "DataSource", {data})
    End Sub

    Protected Function SetLookupListObjectT(dataTableName As String, control As Control, listName As String) As LookupTable
        Dim lookupObj As New LookupTable(dataTableName)
        Dim dataFields = {"ListIdNo", "ListName", "ListCode"}
        lookupObj.SortKey = "ListName"
        Dim listIdNo As Int16 = Service.GetField(Of Int16, String)(listName, "ListGroup", "ListName", "IdNo")
        lookupObj.FilterKey = "ListIdNo=" & listIdNo.ToString()
        Return lookupObj
    End Function

    Public Sub CreateEnumDataSource(Of TE)(ByVal fieldName As String)
        Dim control As CtComboBox = Nothing
        Dim x = MainFieldsDictionary
        If MainFieldsDictionary.TryGetValue(fieldName, control) Then
            control.DataSource = GetEnumData(Of TE)()
            control.DisplayMember = "Name"
            control.ValueMember = "Code"
        Else
            Debugger.Break()
            MessageBox.Show($"Field '" & fieldName & $"' is not valid!")
        End If
    End Sub

    Public Sub CreateEnumData(Of TE)(ByRef dataTarget As Object)
        dataTarget = GetEnumData(Of TE)()
    End Sub

    Private Function GetEnumData(Of TE)()
        Dim dt As New DataTable
        CreateDataTable(dt, {{"IdNo", GetType(Int16)},
                             {"Name", GetType(String)},
                             {"Code", GetType(String)}})
        For Each c In [Enum].GetValues(GetType(TE))
            Dim workRow As DataRow = dt.NewRow()
            workRow("IdNo") = CInt(c)
            workRow("Name") = Messaging.TranslateCaption(c.ToString().SplitCamelCase())
            workRow("Code") = EnumToCode(c)
            dt.Rows.Add(workRow)
        Next
        Return dt  '.DefaultView
    End Function

    Public Function GetService()
        Return Service
    End Function

    Public Function FirstFieldDuplicate(Of T1, T2)(ByRef items As List(Of T1), ByVal fieldName As String) As Integer?
        Dim [set] As HashSet(Of T2) = New HashSet(Of T2)()
        Dim i As Integer = 0
        Dim x As T2
        For Each item As T1 In items
            x = Invoker.GetProperty(item, fieldName)
            If [set].Contains(x) Then
                Return i
            End If
            [set].Add(x)
            i += 1
        Next
        Return Nothing
    End Function

    Protected Sub CreateControlDataSources(dataSourceSpecs As ArrayList)
        Dim dataLookupSpecs As List(Of DataLookupSpecs)
        dataLookupSpecs = CreateDataLookups(dataSourceSpecs)
        For Each dataLookupSpec As DataLookupSpecs In dataLookupSpecs
            If TypeOf dataLookupSpec.PropertyName Is String Then
                dataLookupSpec.PropertyControl = GetFieldControlName(dataLookupSpec.PropertyName)
            End If
            Invoker.SetControlProperty(dataLookupSpec.PropertyControl, "DataSource", dataLookupSpec.LookUpTask.Result)
            Invoker.SetControlProperty(dataLookupSpec.PropertyControl, "DisplayMember", dataLookupSpec.DisplayMember)
            Invoker.SetControlProperty(dataLookupSpec.PropertyControl, "ValueMember", dataLookupSpec.ValueMember)
        Next
    End Sub

    Protected Sub CreateVarDataSources(dataSourceNames As ArrayList)
        Dim dataLookupSpecs As List(Of DataLookupSpecs)
        dataLookupSpecs = CreateDataLookups(dataSourceNames)
        For Each dataLookupSpec As DataLookupSpecs In dataLookupSpecs
            Invoker.SetProperty(Me.View, dataLookupSpec.PropertyName, dataLookupSpec.LookUpTask.Result)
            'Invoker.SetProperty(dataLookupSpec.PropertyControl, "DisplayMember", dataLookupSpec.DisplayMember)
            'Invoker.SetProperty(dataLookupSpec.PropertyControl, "ValueMember", dataLookupSpec.ValueMember)
        Next
    End Sub

    'Protected Function CreateVarDataSources1(dataSourceNames As ArrayList) As DataTable
    '    Dim result As DataTable
    '    result = CreateDataLookUp1(dataSourceNames)
    '    Return result
    'End Function

    'Protected Sub CreateDataSourceThreadT(dataSourceNames As ArrayList)
    '    Dim luItems As List(Of DataLookupSpecs)
    '    luItems = CreateDataLookupsT(dataSourceNames)
    '    For Each luItem As DataLookupSpecs In luItems
    '        Dim displayColumnNo As Integer = Nothing
    '        Dim valueColumnNo As Integer = Nothing
    '        MakeLookupItemT(luItem, displayColumnNo, valueColumnNo)
    '        Invoker.SetPropertyR(luItem.PropertyControl, "DisplayMember", luItem.Data.Columns(displayColumnNo).ColumnName)
    '        Invoker.SetPropertyR(luItem.PropertyControl, "ValueMember", luItem.Data.Columns(valueColumnNo).ColumnName)
    '    Next
    'End Sub

    Private Sub MakeLookupItem(ByRef luItem As DataLookupSpecs, ByRef displayColumnNo As Integer, ByRef valueColumnNo As Integer)
        If TypeOf luItem.PropertyName Is String Then
            luItem.PropertyControl = GetFieldControlName(luItem.PropertyName)
        End If
        'luItem.Data = luItem.LookUpTask.Result
        'luItem.DataView = luItem.Data.DefaultView
        Invoker.SetControlProperty(luItem.PropertyControl, "DataSource", luItem.LookUpTask.Result)
        'displayColumnNo = 0
        'valueColumnNo = 0

        'If luItem.DisplayMember = "Name" Then
        '    If luItem.Data.Columns.Count() = 1 Then
        '        displayColumnNo = 0
        '        valueColumnNo = 0
        '    Else
        '        displayColumnNo = 1
        '    End If
        'ElseIf luItem.DisplayMember = "Code" Then
        '    If luItem.Data.Columns.Count() = 1 Then
        '        displayColumnNo = 0
        '    ElseIf luItem.Data.Columns.Count() = 2 Then
        '        displayColumnNo = 1
        '    Else
        '        displayColumnNo = 2
        '    End If
        'Else
        '    If luItem.Data.Columns.Count() = 1 Then
        '        displayColumnNo = 0
        '    Else
        '        displayColumnNo = 1
        '    End If
        'End If
        'If luItem.ValueMember = "Name" Then
        '    If luItem.Data.Columns.Count() = 1 Then
        '        valueColumnNo = 0
        '    Else
        '        valueColumnNo = 1
        '    End If
        'ElseIf luItem.DisplayMember = "Code" Then
        '    If luItem.Data.Columns.Count() = 1 Then
        '        valueColumnNo = 0
        '    ElseIf luItem.Data.Columns.Count() = 2 Then
        '        valueColumnNo = 1
        '    Else
        '        valueColumnNo = 2
        '    End If
        'Else
        '    valueColumnNo = 0
        'End If
    End Sub

    'Private Sub MakeLookupItemT(ByRef luItem As DataLookupSpecs, ByRef displayColumnNo As Integer, ByRef valueColumnNo As Integer)
    '    luItem.PropertyControl = luItem.PropertyControl
    '    luItem.Data = luItem.LookUpTask.Result
    '    luItem.DataView = luItem.Data.DefaultView
    '    Invoker.SetControlProperty(luItem.PropertyControl, "DataSource", luItem.Data)
    '    displayColumnNo = 0
    '    valueColumnNo = 0

    '    If luItem.DisplayMember = "Name" Then
    '        If luItem.Data.Columns.Count() = 1 Then
    '            displayColumnNo = 0
    '            valueColumnNo = 0
    '        Else
    '            displayColumnNo = 1
    '        End If
    '    ElseIf luItem.DisplayMember = "Code" Then
    '        If luItem.Data.Columns.Count() = 1 Then
    '            displayColumnNo = 0
    '        ElseIf luItem.Data.Columns.Count() = 2 Then
    '            displayColumnNo = 1
    '        Else
    '            displayColumnNo = 2
    '        End If
    '    Else
    '        If luItem.Data.Columns.Count() = 1 Then
    '            displayColumnNo = 0
    '        Else
    '            displayColumnNo = 1
    '        End If
    '    End If
    '    If luItem.ValueMember = "Name" Then
    '        If luItem.Data.Columns.Count() = 1 Then
    '            valueColumnNo = 0
    '        Else
    '            valueColumnNo = 1
    '        End If
    '    ElseIf luItem.DisplayMember = "Code" Then
    '        If luItem.Data.Columns.Count() = 1 Then
    '            valueColumnNo = 0
    '        ElseIf luItem.Data.Columns.Count() = 2 Then
    '            valueColumnNo = 1
    '        Else
    '            valueColumnNo = 2
    '        End If
    '    Else
    '        valueColumnNo = 0
    '    End If
    'End Sub

    'Protected Sub CreateDataSourceLookup(dataSourceNames As ArrayList)
    '    Dim luItems As List(Of DataLookupSpecs)
    '    luItems = CreateDataLookups(dataSourceNames)
    '    For Each luItem As DataLookupSpecs In luItems
    '        luItem.PropertyControl = GetFieldControlName(luItem.PropertyName)
    '        luItem.Data = luItem.LookUpTask.Result
    '        luItem.DataView = luItem.Data.DefaultView
    '        Invoker.SetPropertyR(luItem.PropertyControl, "DataSource", luItem.Data)
    '        Dim displayColumnNo As Integer = 0
    '        Dim valueColumnNo As Integer = 0
    '        If luItem.DisplayMember = "Name" Then
    '            If luItem.Data.Columns.Count() = 1 Then
    '                displayColumnNo = 0
    '                valueColumnNo = 0
    '            Else
    '                displayColumnNo = 1
    '            End If
    '        ElseIf luItem.DisplayMember = "Code" Then
    '            If luItem.Data.Columns.Count() = 1 Then
    '                displayColumnNo = 0
    '            ElseIf luItem.Data.Columns.Count() = 2 Then
    '                displayColumnNo = 1
    '            Else
    '                displayColumnNo = 2
    '            End If
    '        Else
    '            If luItem.Data.Columns.Count() = 1 Then
    '                displayColumnNo = 0
    '            Else
    '                displayColumnNo = 1
    '            End If
    '        End If
    '        If luItem.ValueMember = "Name" Then
    '            If luItem.Data.Columns.Count() = 1 Then
    '                valueColumnNo = 0
    '            Else
    '                valueColumnNo = 1
    '            End If
    '        ElseIf luItem.DisplayMember = "Code" Then
    '            If luItem.Data.Columns.Count() = 1 Then
    '                valueColumnNo = 0
    '            ElseIf luItem.Data.Columns.Count() = 2 Then
    '                valueColumnNo = 1
    '            Else
    '                valueColumnNo = 2
    '            End If
    '        Else
    '            valueColumnNo = 0
    '        End If

    '        Invoker.SetPropertyR(luItem.PropertyControl, "DisplayMember", luItem.Data.Columns(displayColumnNo).ColumnName)
    '        Invoker.SetPropertyR(luItem.PropertyControl, "ValueMember", luItem.Data.Columns(valueColumnNo).ColumnName)

    '    Next
    'End Sub

    'Protected Sub CreateDvLookupDataThread(dataSourceNames As ArrayList)
    '    Dim luItems As List(Of DataLookupSpecs)
    '    luItems = CreateDataLookups(dataSourceNames)
    '    For Each luItem As DataLookupSpecs In luItems
    '        luItem.Data = luItem.LookUpTask.Result
    '        luItem.DataView = luItem.Data.DefaultView
    '        Invoker.SetProperty(Me.View, luItem.PropertyName, luItem.DataView)
    '    Next
    'End Sub

    Protected Sub CreateDataSourceGroupCodeThread(GroupCodeCodes As Object)
        Dim nCount = GroupCodeCodes.Length()
        Dim dataSourceNames As New ArrayList
        For i = 0 To nCount / 2 - 1
            Dim idNo As Int16
            idNo = Service.GetRecordFieldWithKeyG(Of Int16, String)(GroupCodeCodes(i, 1), "CodeGroup", "CodeGroupCode", "IdNo")
            dataSourceNames.Add({"ItemCode", GroupCodeCodes(i, 0), "ItemCodeCode,ItemCodeName", "CodeGroupIdNo = " & idNo.ToString()})
        Next
        CreateControlDataSources(dataSourceNames)
    End Sub

    Public Sub MakeControlDataSources(dataObject As Object)
        'dataObject must be in the form of an Array {{LookupTableName,LookupControl,LookupFieldNames,LookupFilter,LookupSortKey,ValueMember,DisplayMember,Ascending},
        '                                            {LookupTableName,LookupControl,LookupFieldNames,LookupFilter,LookupSortKey,ValueMember,DisplayMember,Ascending}}
        ' compose the ArrayList from the given dataObject
        Dim data As New ArrayList
        For Each aItem As Object In dataObject
            data.Add(aItem)
        Next
        ' create the actual datasources from the given ArrayList
        CreateControlDataSources(data)
    End Sub

    Public Sub MakeVarDataSources(dataObject As Object)
        Dim data As New ArrayList
        For Each item As Object() In dataObject
            data.Add(item)
        Next
        CreateVarDataSources(data)
    End Sub

    Public Function GetDataLookupTable(dataObject As Object) As DataTable
        Dim dataLookupSpecs As DataTableLookupSpec
        dataLookupSpecs = CreateDataLookupTable(dataObject)
        Dim cd As New DataCreator(Service)
        Dim data As DataTable = cd.CreateDataTable(dataLookupSpecs)
        Return data
    End Function

    Public Function MakeVarDataSource(item As Object) As DataTable
        Dim dtl As New DataLookupSpecs
        Const LookupTableName As Int32 = 0
        Const PropertyFieldName As Int32 = 1
        Const LookupFieldNames As Int32 = 2
        Const LookupFilter As Int32 = 3
        Const LookupSortKey As Int32 = 4
        Const ValueMember As Int32 = 5
        Const DisplayMember As Int32 = 6
        Const Ascending As Int32 = 7
        dtl.TableName = item(LookupTableName)
        dtl.PropertyName = item(PropertyFieldName)
        dtl.Ascending = True
        If item.Length - 1 > 1 Then
            dtl.LuFields = item(LookupFieldNames)
        End If
        If item.Length - 1 > 2 Then
            dtl.Filter = item(LookupFilter)
        End If
        If item.Length - 1 > 3 Then
            dtl.SortKey = item(LookupSortKey)
        End If
        If item.Length - 1 > 4 Then
            dtl.ValueMember = item(ValueMember)
        End If
        If item.Length - 1 > 5 Then
            dtl.DisplayMember = item(DisplayMember)
        End If
        If item.Length - 1 > 6 Then
            dtl.Ascending = item(Ascending)
        End If
        ComposeLookupProperties(dtl)
        Return GetDtRecords(dtl.TableName, dtl.LuFields, dtl.Filter, dtl.SortKey)
    End Function

    Private Function CreateDataLookups(dataSourceNames As ArrayList) As List(Of DataLookupSpecs)
        Dim lookups As New List(Of DataLookupSpecs)
        For Each dataSourceName In dataSourceNames
            Dim dtl As DataLookupSpecs
            dtl = CreateDataLookUp(dataSourceName)
            lookups.Add(dtl)
        Next
        Return lookups
    End Function

    Private Function CreateDataLookUp(item As Object) As DataLookupSpecs
        Const LookupTableName As Int32 = 0
        Const LookupControl As Int32 = 1
        Const LookupFieldNames As Int32 = 2
        Const LookupFilter As Int32 = 3
        Const LookupSortKey As Int32 = 4
        Const Ascending As Int32 = 5
        Const ValueMember As Int32 = 6
        Const DisplayMember As Int32 = 7

        Dim dtl As New DataLookupSpecs
        dtl.TableName = item(LookupTableName)
        If TypeOf item(LookupControl) Is String Then
            dtl.PropertyName = item(LookupControl)
        Else
            dtl.PropertyControl = item(LookupControl)
        End If
        dtl.Ascending = True
        If item.Length - 1 > 1 Then
            dtl.LuFields = item(LookupFieldNames)
        End If
        If item.Length - 1 > 2 Then
            dtl.Filter = item(LookupFilter)
        End If
        If item.Length - 1 > 3 Then
            dtl.SortKey = item(LookupSortKey)
        End If
        If item.Length - 1 > 4 Then
            dtl.Ascending = item(Ascending)
        End If
        If item.Length - 1 > 5 Then
            dtl.ValueMember = item(ValueMember)
        End If
        If item.Length - 1 > 6 Then
            dtl.DisplayMember = item(DisplayMember)
        End If
        ComposeLookupProperties(dtl)
        dtl.LookUpTask = Task(Of DataTable).Factory.StartNew(Function() LookupDataTableCreator(dtl))
        Return dtl
    End Function

    Private Function CreateDataLookupTable(item As Object) As DataTableLookupSpec
        Const LookupTableName As Int32 = 0
        Const LookupFieldNames As Int32 = 1
        Const LookupFilter As Int32 = 2
        Const LookupSortKey As Int32 = 3
        Const Ascending As Int32 = 4
        Const ValueMember As Int32 = 5
        Const DisplayMember As Int32 = 6
        Dim dtl As New DataTableLookupSpec
        dtl.TableName = item(LookupTableName)
        dtl.Ascending = True
        If item.Length - 1 > 0 Then
            dtl.LuFields = item(LookupFieldNames)
        End If
        If item.Length - 1 > 1 Then
            dtl.Filter = item(LookupFilter)
        End If
        If item.Length - 1 > 2 Then
            dtl.SortKey = item(LookupSortKey)
        End If
        If item.Length - 1 > 3 Then
            dtl.Ascending = item(Ascending)
        End If
        If item.Length - 1 > 4 Then
            dtl.ValueMember = item(ValueMember)
        End If
        If item.Length - 1 > 5 Then
            dtl.DisplayMember = item(DisplayMember)
        End If
        ComposeLookupProperties(dtl)
        Return dtl
    End Function

    Private Sub ComposeLookupProperties(dtl As DataTableLookupSpec)
        Dim RightToLeftFormat = GlobalFunctions.IsRightToLeft(CultureInfo.CurrentCulture.ToString())
        If dtl.LuFields Is Nothing Then
            dtl.NameFieldOrig = dtl.TableName + "Name"
            dtl.NameField = TranslateNameField(dtl.TableName, dtl.NameFieldOrig)
            dtl.NameDisplayValue = dtl.NameField + "+'-'+" + dtl.TableName + "Code"
            If dtl.ValueMember Is Nothing Then
                dtl.ValueMember = "IdNo"
            End If
            If dtl.DisplayMember Is Nothing Then
                dtl.DisplayMember = "Name"
            End If
            dtl.LuFields = "IdNo, " + dtl.NameDisplayValue + " COLLATE SQL_Latin1_General_CP1_CI_AS As Name"
            If dtl.SortKey Is Nothing Then
                dtl.SortKey = dtl.NameField
            End If
        Else
            Dim fieldNames = dtl.LuFields.Split(",")
            If fieldNames.Count() = 1 Then
                dtl.NameFieldOrig = fieldNames(0)
                dtl.NameField = TranslateNameField(dtl.TableName, dtl.NameFieldOrig)
                dtl.NameDisplayValue = dtl.NameField
                dtl.ValueMember = "Name"
                dtl.DisplayMember = "Name"
                dtl.LuFields = dtl.NameField + " as Name"
                If dtl.SortKey Is Nothing Then
                    dtl.SortKey = fieldNames(0)
                End If
            ElseIf fieldNames.Count() = 2 Then
                ' assumed the first field is the value member and the second field as the display Value
                dtl.NameFieldOrig = fieldNames(1)
                dtl.NameField = TranslateNameField(dtl.TableName, dtl.NameFieldOrig)
                dtl.NameDisplayValue = "Concat(" + dtl.NameField + " COLLATE SQL_Latin1_General_CP1_CI_AS,'-'," + fieldNames(0) + ") COLLATE SQL_Latin1_General_CP1_CI_AS"
                If dtl.ValueMember Is Nothing Then
                    dtl.ValueMember = "IdNo"
                End If
                If dtl.DisplayMember Is Nothing Then
                    dtl.NameDisplayValue = "Concat(" + dtl.NameField + " COLLATE SQL_Latin1_General_CP1_CI_AS,'-'," + fieldNames(0) + ") COLLATE SQL_Latin1_General_CP1_CI_AS"
                    dtl.DisplayMember = "Name"
                End If
                dtl.LuFields = fieldNames(0) + " as IdNo," + dtl.NameDisplayValue + " as Name"
                If dtl.SortKey Is Nothing Then
                    dtl.SortKey = dtl.NameField
                End If
            ElseIf fieldNames.Count() = 3 Then
                dtl.NameField = fieldNames(1).Trim()
                dtl.NameDisplayValue = "Concat(" + TranslateNameField(dtl.TableName, dtl.NameField) + " COLLATE SQL_Latin1_General_CP1_CI_AS,'-'," + fieldNames(2) + ") COLLATE SQL_Latin1_General_CP1_CI_AS"
                If dtl.ValueMember Is Nothing Then
                    dtl.ValueMember = "IdNo"
                End If
                If dtl.DisplayMember Is Nothing Then
                    dtl.DisplayMember = "Name"
                End If
                dtl.LuFields = fieldNames(0) + " As IdNo," + dtl.NameDisplayValue + " as Name," + fieldNames(2).ToString() + " as Code"
                If dtl.SortKey Is Nothing Then
                    dtl.SortKey = dtl.NameField
                End If
            ElseIf fieldNames.Count() = 4 Then
                dtl.NameField = fieldNames(1).Trim()
                dtl.NameDisplayValue = "Concat(" + TranslateNameField(dtl.TableName, dtl.NameField) + " COLLATE SQL_Latin1_General_CP1_CI_AS,'-'," + fieldNames(2) + ") COLLATE SQL_Latin1_General_CP1_CI_AS"
                If dtl.ValueMember Is Nothing Then
                    dtl.ValueMember = "IdNo"
                End If
                If dtl.DisplayMember Is Nothing Then
                    dtl.DisplayMember = "Name"
                End If
                dtl.LuFields = fieldNames(0) + " As IdNo," + dtl.NameDisplayValue + " as Name," + fieldNames(2).ToString() + " as Code" + ", " + fieldNames(3)
                If dtl.SortKey Is Nothing Then
                    dtl.SortKey = dtl.NameField
                End If
            Else
                MessageBox.Show("Too much parameters passed!")
                Debugger.Break()
            End If
        End If
    End Sub

    Private Function TranslateNameField(tableName As String, fieldName As String) As String
        Dim retValue As String = fieldName
        If GlobalFunctions.IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
            Dim nameFieldArabic As String = fieldName + "Ara"
            If Service.FieldExistInTable(tableName, nameFieldArabic) Then
                retValue = fieldName + "Ara"
            End If
        End If
        Return retValue
    End Function

    Public Function CurrentLanguage() As String
        If GlobalFunctions.IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
            Return "arabic"
        End If
        Return CultureInfo.CurrentCulture.ToString()
    End Function


    Private Function LookupDataTableCreator(dtl As DataLookupSpecs) As DataTable
        Dim cd As New DataCreator(Service)
        Dim data As DataTable = cd.CreateDataTable(dtl)
        cd = Nothing
        Return data
    End Function

    'Private Function LookupDataViewCreator(dtl As DataLookupSpecs) As DataView
    '    Dim cd As New DataViewCreator(Service)
    '    Dim data As DataView = cd.CreateDataView(dtl)
    '    cd = Nothing
    '    Return data
    'End Function

    Protected Sub SetDataSourceInstalledPrinter(controlName As String)
        Dim data As New List(Of LookupTable.LookupData)
        ' Find all printers installed
        Dim index As Int16 = 0
        For Each item In PrinterSettings.InstalledPrinters
            Dim dbLookup = New LookupTable.LookupData
            dbLookup.IdNo = index
            dbLookup.Name = item
            dbLookup.Code = item
            dbLookup.Index = index
            data.Add(dbLookup)
            index += 1
        Next
        GetControlName(controlName).DataSource = data
    End Sub

    Protected Sub SetPrinterSupportedSources(pPrinterName As String, ByRef paperSource As Int16)
        Dim data = GlobalFunctions.GetPrinterPageInfo(pPrinterName)
        Dim paperSourceLookup As New List(Of LookupTable.LookupData)
        Dim index As Int16 = 0
        For Each item As Drawing.Printing.PaperSource In data.PrinterSettings.PaperSources
            Dim dbLookup = New LookupTable.LookupData
            dbLookup.IdNo = item.RawKind
            dbLookup.Name = item.SourceName
            dbLookup.Code = item.Kind
            dbLookup.Index = index
            paperSourceLookup.Add(dbLookup)
            index += 1
        Next
        Dim savedPaperSource As Integer = paperSource
        GetControlName("PaperSource").DataSource = paperSourceLookup
        paperSource = savedPaperSource
        If savedPaperSource = 0 Then
            paperSource = data.PrinterSettings.DefaultPageSettings.PaperSource.RawKind
        End If
    End Sub

    Protected Sub SetPrinterSupportedPaperSize(pPrinterName As String, ByRef paperSize As Int16?)
        Dim data = GetPrinterPageInfo(pPrinterName)
        Dim paperSizeLookup As New List(Of LookupTable.LookupData)
        Dim index As Int16 = 0
        For Each item As Drawing.Printing.PaperSize In data.PrinterSettings.PaperSizes
            Dim dbLookup = New LookupTable.LookupData
            dbLookup.IdNo = item.RawKind
            dbLookup.Name = item.PaperName
            dbLookup.Code = item.Kind
            dbLookup.Index = index
            paperSizeLookup.Add(dbLookup)
            index += 1
        Next
        Dim savedDefaultPaperSize As Int16? = paperSize
        GetControlName("PaperSize").DataSource = paperSizeLookup
        paperSize = savedDefaultPaperSize
        If savedDefaultPaperSize Is Nothing OrElse savedDefaultPaperSize = 0 Then
            paperSize = data.PrinterSettings.DefaultPageSettings.PaperSize.RawKind
        End If
    End Sub

    Protected Sub SetPrinterSupportedPaperOrientation(pPrinterName As String, ByRef paperOrientation As Int16?)
        'Dim data = GetPrinterPageInfo(pPrinterName)
        Dim paperOrientationLookup As New List(Of LookupTable.LookupData)
        Dim index As Int16 = 0
        Dim dbLookup = New LookupTable.LookupData
        dbLookup.IdNo = 0 'CInt(CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation)
        dbLookup.Name = "DefaultPaperOrientation"
        dbLookup.Code = "DefaultPaperOrientation"
        dbLookup.Index = 0 'CInt(CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation)
        paperOrientationLookup.Add(dbLookup)
        dbLookup = New LookupTable.LookupData
        dbLookup.IdNo = 1 'CInt(CrystalDecisions.Shared.PaperOrientation.Landscape)
        dbLookup.Name = "Landscape"
        dbLookup.Code = "Landscape"
        dbLookup.Index = 1 'CInt(CrystalDecisions.Shared.PaperOrientation.Landscape)
        paperOrientationLookup.Add(dbLookup)
        dbLookup = New LookupTable.LookupData
        dbLookup.IdNo = 2 ' CInt(CrystalDecisions.Shared.PaperOrientation.Portrait)
        dbLookup.Name = "Portrait"
        dbLookup.Code = "Portrait"
        dbLookup.Index = 2 'CInt(CrystalDecisions.Shared.PaperOrientation.Portrait)
        paperOrientationLookup.Add(dbLookup)
        Dim savedDefaultPaperOrientation As Int16? = paperOrientation
        GetControlName("PaperOrientation").DataSource = paperOrientationLookup
        paperOrientation = savedDefaultPaperOrientation
        If savedDefaultPaperOrientation Is Nothing OrElse savedDefaultPaperOrientation = 0 Then
            paperOrientation = 0 'CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation
        End If
    End Sub

End Class

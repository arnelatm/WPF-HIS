Imports System.ComponentModel
Imports System.Globalization
Imports System.Threading
Imports System.Transactions
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Languages

Public Class CFormEntry
    Inherits BfMain

    Public FieldsDictionary As New Dictionary(Of String, Object)
    Public GotoTargetRecordWorker As BackgroundWorker(Of String)
    Public ShowWaitForm As BackgroundWorker(Of String)
    Protected Const TurnOff As Boolean = False
    Protected Shared _resetEvent As AutoResetEvent = New AutoResetEvent(False)
    Protected DataChangesMade As Boolean = False
    Protected DtInsert As DataTable
    Protected DtTable As DataTable
    Protected DtUpdate As DataTable
    Protected FirstControl As Control
    Protected IdFieldName As String = "IdNo"
    Protected ParentFieldName As String = ""
    Protected RecordDateTimeStampValue As Object
    Protected RecordPositionNumber As Integer = 0
    Protected SortOrderKey As String = "IdNo"
    Private Const TurnOn As Boolean = True
    Private ReadOnly _currentCulture As CultureInfo = GlobalVariables.AppCurrentCultureInfo
    Private _addMode As Boolean = False
    Private _editMode As Boolean = False
    Private _debugSwitch As Byte = 0
    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (hProcess As IntPtr,
                                                                          dwMinimumWorkingSetSize As Int32,
                                                                          dwMaximumWorkingSetSize As Int32) As Int32

    Delegate Sub SafeCallDelegate(ByRef controlObject As Control, textString As String)

    Public Event AddingRecordChanged(adding As Boolean)

    Public Event AfterAdd()

    Public Event AfterDelete()

    Public Event AfterEdit()

    Public Event AfterLoad()

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

    Public Event InputsTurnedOff()

    Public Event InputsTurnedOn()

    Public Event ParentRecordAddedSuccessfully(idNoOfRecord As Integer)

    Public Event ParentRecordUpdatedSuccessfully(idNoOfRecord As Integer)

    Public Event SuccessfulAdd(idNoOfSavedRecord As Integer)

    Public Event SuccessfulDelete(idNoOfDeletedRecord As Integer)

    Public Event SuccessfulUpdate(idNoOfAddedRecord As Integer)

    Public Event UndoEdits(addingRec As Boolean)

    Public Event TextDisplayChanged()

    '    Private _waitProcessFinished As Boolean = False

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        KeyPreview = True

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Property AddMode As Boolean
        Set
            If _addMode <> Value Then
                _addMode = Value
                RaiseEvent AddingRecordChanged(Value)
            End If
        End Set
        Get
            Return _addMode
        End Get
    End Property

    Public Property CancelDelete As Boolean = False

    Public Property CancelEdit As Boolean = False

    Public Property CancelSave As Boolean = False

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Type here the Child Table name if any, otherwise leave it blank.")>
    <Browsable(True)>
    Public Property ChildTableName As String = ""

    'Private Property SearchFieldDescription() As String
    '    Get
    '        Return _searchfieldDescription
    '    End Get
    '    Set(ByVal Value As String)
    '        _searchfieldDescription = Value
    '    End Set
    'End Property
    Public Property CurrentSortKeyValue As String

    'Private Property SearchField() As String
    '    Get
    '        Return _searchfield
    '    End Get
    '    Set(ByVal Value As String)
    '        _searchfield = Value
    '    End Set
    'End Property
    Public Property EditMode As Boolean
        Set
            If _editMode <> Value Then
                _editMode = Value
                RaiseEvent EditingRecordChanged(Value)
            End If
        End Set
        Get
            Return _editMode
        End Get
    End Property

    'Protected Property _recordNumber() As Integer
    '    Get
    '        Return _RecordNumber
    '    End Get
    '    Set(ByVal Value As Integer)
    '        _RecordNumber = Value
    '    End Set
    'End Property
    '<Description("This is the last IDNo of the Displayed record before moving to a different record.")>
    'Public Property CurrentIdNo As Integer
    Public Property LastIdNo As Integer

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Type here the Table name usually the Master (Parent) Table name as shown in the Database ")>
    <Browsable(True)>
    Public Property MainTableName As String = ""

    Public Property TableProperties As Array

    Public Property UndoMode As Boolean = False

    'Public Property TableDefaultFieldValues
    <Description("This is the value of the current IDNo in the TxtIDNo Field ")>
    Protected Property TargetIdNo As Integer

    'Public Property KeyField() As String
    '    Get
    '        Return _keyfield
    '    End Get
    '    Set(ByVal Value As String)
    '        _keyfield = Value
    '    End Set
    'End Property

    Private Property RecordCount As Integer

    Public Function AutomaticValidationsOk() As Boolean
        Dim validationsPassed As Boolean
        validationsPassed = True
        Dim allControls As New List(Of Control)
        Dim originalValue As String
        For Each cCtrl As Control In FindControlRecursive(allControls, Me)
            If TypeOf cCtrl Is IEntryControl Then
                If TypeOf cCtrl Is CTextBoxIdNo Then
                    ' no validations for this type of control. These are Identity Columns and are filled automatically
                    ' by the Data Server.
                ElseIf TypeOf cCtrl Is CTextBox AndAlso GetPropertyValue(cCtrl, "ComputedValue") Then
                    ' ignore this also computed values don't need to be validated for empty values
                ElseIf TypeOf cCtrl Is CTextBoxArabic Then
                    Dim thisControl As CTextBoxArabic
                    thisControl = cCtrl
                    If thisControl.EnglishControl Is Nothing Then
                        MessageBox.Show($"EnglishControl for  CTextBoxArabic control <{thisControl.Name}> not set.")
                    End If
                    originalValue = PresenterObj.GetOriginalValue(thisControl.EnglishControl)
                    Dim englishText As String = GetPropertyValue(thisControl.EnglishControl, "Text")
                    If String.IsNullOrEmpty(cCtrl.Text) OrElse cCtrl.Text.Trim() = originalValue Then
                        thisControl.Text = englishText
                    End If
                ElseIf TypeOf cCtrl Is CTextBox OrElse TypeOf cCtrl Is CTextBoxArabic Then
                    ' check for duplicate values
                    If GetPropertyValue(cCtrl, "ValueIsUnique") Then
                        Dim fldName As String = cCtrl.Name.Substring(3)
                        Dim fieldDescription As String
                        If GetPropertyValue(cCtrl, "LinkedLabel") Is Nothing Then
                            fieldDescription = fldName
                        Else
                            Dim cTextCtrl As CTextBox
                            cTextCtrl = cCtrl
                            fieldDescription = GetPropertyValue(cTextCtrl.LinkedLabel, "Text")
                        End If
                        Dim recordIsNotUnique = False
                        If AddMode Then
                            If IsRecordNotUnique(cCtrl, fldName) Then
                                recordIsNotUnique = True
                            End If
                        Else
                            originalValue = PresenterObj.GetOriginalValue(cCtrl)
                            ' if value did not change no need to check for duplicate values.
                            If cCtrl.Text <> originalValue Then
                                If IsRecordNotUnique(cCtrl, fldName) Then
                                    recordIsNotUnique = True
                                End If
                            End If
                        End If
                        If recordIsNotUnique Then
                            _MBUniqueConstraintViolated.Show(Me, {cCtrl.Text, fieldDescription})
                            validationsPassed = False
                        End If
                    End If
                End If
            End If
        Next
        Return validationsPassed
    End Function

    Public Overridable Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.ClickButtonArea
        EditData()
        Dim currentIdNo = GetPropertyValue(Me, IdFieldName)
        If _MBDeleteRecordAsk.Show(Me) = DialogResult.Yes Then
            Dim retValue As Integer
            retValue = DeleteRecord(currentIdNo)
            If retValue <= 0 Then
                '' Something went wrong during the deletion since no record was/were deleted
                '' retValue = -1 , for unsuccessful delete
            Else
                TargetIdNo = PresenterObj.GetSortedRecordNumber(RecordPositionNumber)
                GetRecordInfoForIdNo()
            End If
        End If
    End Sub

    Public Overridable Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.ClickButtonArea
        EditData()
    End Sub

    Public Sub EditData()
        RaiseEvent BeforeEdit()
        If CancelEdit Then
            CancelEdit = False
            'EditMode = False
        Else
            EditMode = True
            AddMode = False
            TurnOnInputs()
            UpdateButtonDisplays(False, True)
        End If
        RaiseEvent AfterEdit()
    End Sub

    Public Sub CheckDataChanges()
    End Sub

    Public Overridable Function DeleteRecord(idNo As Integer) As Integer
        Dim retValue = 0
        RaiseEvent BeforeDelete()
        If CancelDelete Then
            CancelDelete = False
        Else
            If Not DependentRecordsExist(idNo) Then
                retValue = PresenterObj.DeleteRecord(idNo)
                If retValue <= 0 Then
                    _MBDeleteRecordFailed.Show(Me)
                Else
                    RaiseEvent SuccessfulDelete(idNo)
                    _MBRecordSuccessfullyDeleted.Show(Me)
                    GetAndDisplayRecordForGivenRecordPosition()
                End If
            End If
        End If
        RaiseEvent AfterDelete()
        Return retValue
    End Function

    Public Function FindField(txtControl As Control) As Integer
        If OkToMove("FindField") Then
            Dim idNoOfFoundRecord As Integer
            idNoOfFoundRecord = PresenterObj.FindField(txtControl)
            If idNoOfFoundRecord = 0 Then
                _MBTextToFindNotFound.Show(Me, GetPropertyValue(txtControl, "GetTextToSearch"))
                BtnFind.Enabled = False
            Else
                BtnFind.Enabled = True
                TargetIdNo = idNoOfFoundRecord
                GetAndSetRecordPositionNumber()
                GetAndDisplayRecordForGivenRecordPosition()
                If EditMode Then
                    '' in editing mode but no changes found so reset the EditMode to false
                    EditMode = False
                End If
            End If
            CancelClose = True
        End If
        Return TargetIdNo
    End Function

    Public Sub FindFieldContinue(recIdKey As Integer)
        If OkToMove("Continue Find") Then
            TargetIdNo = PresenterObj.FindFieldContinue(TargetIdNo)
            If TargetIdNo <> 0 Then
                GetAndSetRecordPositionNumber()
                GetAndDisplayRecordForGivenRecordPosition()
            End If
            CancelClose = True
        End If
    End Sub

    Public Function GetFieldsDictionary()
        Return FieldsDictionary
    End Function

    Public Sub gotoTargetRecordWorker_DoWorkHandler(sender As Object, e As DoWorkEventArgs(Of String))
        If GotoTargetRecordWorker.CancellationPending Then
            e.Cancel = True
            Return
        End If
        TargetIdNo = e.Argument
        GetAndSetRecordPositionNumber()
        GetAndDisplayRecordForGivenRecordPosition()
        DoPaintEvents()
    End Sub

    Public Overridable Function SaveDataEntry()
        Dim retValue As Int16
        RaiseEvent BeforeSave()
        If CancelSave Then
            CancelSave = False
            retValue = -1
        Else
            'If AddMode Then
            retValue = InitiateSave(retValue)
            'Else
            '    If PresenterObj.HasRecordChanged(TargetIdNo, RecordDateTimeStampValue) Then
            '        MessageBox.Show("Record Has Changed since you last retrieved the record, cannot save your modifications. Please refresh the record and try again.")
            '        retValue = -1
            '    Else
            '        retValue = InitiateSave(retValue)
            '    End If
            'End If
        End If
        If retValue > 0 Then
            RaiseEvent AfterSave()
        End If
        If retValue > 0 Then
            _MBRecordSuccessfullySaved.Show(Me)
        End If
        Return retValue
    End Function

    Public Sub showWaitForm_DoWorkHandler(sender As Object, e As DoWorkEventArgs(Of String))
        'Dim progress As Int32 = 0
        'Dim IdNoTarget as Int32 = 0
        'waitMessageSetter.RunWorkerAsync(e.Argument)
        'Debugger.Break()
        'Do While IdNoTarget = 0
        If ShowWaitForm.CancellationPending Then
            e.Cancel = True
            Return
        End If
        'Thread.Sleep(10)
        'showWaitForm.ReportProgress(progress)
        'Debugger.Break()
        e.Result = PresenterObj.GetSortedRecordNumber(RecordPositionNumber)
        '_resetEvent.Set()
        'Thread.Sleep(10)
        'loop
        'showWaitForm.ReportProgress(progress)
    End Sub

    Public Sub TurnOffInputs()
        Inputs(False)
        RaiseEvent InputsTurnedOff()
    End Sub

    Public Sub TurnOnInputs()
        Inputs(True)
        RaiseEvent InputsTurnedOn()
    End Sub

    Protected Overridable Function AdditionalChangesMadeCheck()
        Return False
    End Function

    Protected Overridable Sub AddMandatoryFieldCHeck()
    End Sub

    Protected Overridable Function ChangesMade()
        If DataChangesMade Then
            Return True
        Else
            Return PresenterObj.ChangesMade()
        End If
    End Function

    Protected Overridable Sub CreateDataSources()
        '
    End Sub

    Protected Overridable Sub CreateFieldsDictionary()
        '
    End Sub

    Protected Overridable Function DependentRecordsExist(masterIdNo As Integer) As Integer
        Return 0
    End Function

    Protected Overridable Sub DisplayView()
        RaiseEvent BeforeDisplayView()
        PresenterObj.Display(TargetIdNo, UndoMode)
    End Sub

    Protected Sub GetAndDisplayRecordForGivenRecordPosition()
        Dim savedTargetIdNo As Integer = TargetIdNo
        ' RecordPositionNumber is the position no. of the record in the sorted order
        TargetIdNo = PresenterObj.GetSortedRecordNumber(RecordPositionNumber)
        GetRecordInfoForIdNo()
        DataChangesMade = False
        If TargetIdNo <> savedTargetIdNo Then
            RaiseEvent DisplayedRecordChanged()
        End If
    End Sub

    Protected Sub GetAndSetRecordPositionNumber()
        RecordPositionNumber = PresenterObj.GetSortedRecordPosition(TargetIdNo)
    End Sub

    Protected Sub GetRecordInfoForIdNo()
        Dim tmpUndoMode As Boolean = UndoMode
        UndoMode = tmpUndoMode
        RecordCount = PresenterObj.GetRecordCount()
        RecordDateTimeStampValue = PresenterObj.GetRecordDateTimeStamp(TargetIdNo)
        LblRecordCount.Text = $"{_MsgRecordNo.Value} {RecordPositionNumber} {_MsgOf.Value}{RecordCount}"
        EditMode = False
        AddMode = False
        UndoMode = False
        UpdateButtonDisplays(False, False)
        MyErrorProvider.ClearAllErrorMessages()
        MyErrorProvider.Clear()
        DisplayView()
        PresenterObj.SaveOriginalValues()
        TurnOffInputs()
        Refresh()
    End Sub

    Protected Overridable Function OkToMove(ByVal Optional buttonName As String = "")
        Dim retValue As Boolean
        If Not (EditMode OrElse AddMode) Then
            retValue = True
        Else
            Try
                If AddMode Then
                    retValue = True
                Else
                    If ChangesMade() Then
                        retValue = SaveOrAbandonChanges(buttonName)
                    Else
                        retValue = True
                    End If
                End If
            Catch ex As Exception
                '' need to do this to catch error in design mode (No idea why error is appearing)
                retValue = True
            End Try

        End If
        Return retValue
    End Function

    Protected Overridable Sub OnTextDisplayLanguageChanged() Handles Me.TextDisplayLanguageChanged
        CultureInfo.CurrentCulture = New CultureInfo(TextDisplayLanguage, False)
        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            GlobalVariables.RightToLeftLayout = True
        Else
            GlobalVariables.RightToLeftLayout = False
        End If
        CreateDataSources()
    End Sub

    Protected Function SaveOrAbandonChanges(buttonName As String)
        Dim retValue As Boolean
        Dim result As DialogResult
        If buttonName = "Undo" Then
            result = _MBUndoEdits.Show(Me)
            If result = DialogResult.Yes Then
                'TargetIdNo = CurrentIdNo
                RaiseEvent UndoEdits(False)
                DataChangesMade = False
                EditMode = False
            End If
        Else
            result = _MBSaveChangesBeforeMoving.Show(Me)
        End If
        If result = DialogResult.Yes And buttonName = "Undo" Then
            retValue = True
        ElseIf result = DialogResult.No And buttonName = "Undo" Then
            retValue = False
        ElseIf result = DialogResult.Yes Then
            If MyErrorProvider.CheckAndShowSummaryErrorMessage() = True Then
                BtnSave.PerformClick()
                retValue = True
            Else
                retValue = False
            End If
        ElseIf result = DialogResult.No Then
            retValue = True
            RaiseEvent CancelChanges()
        ElseIf result = DialogResult.Cancel Then
            retValue = False
        Else
            retValue = False
        End If
        Return retValue
    End Function

    Protected Sub UpdateButtonDisplays(editing As Boolean, adding As Boolean)
        If RecordCount = 0 Then
            BtnFirst.Enabled = False
            BtnPrev.Enabled = False
            BtnNext.Enabled = False
            BtnLast.Enabled = False
            BtnEdit.Enabled = False
            BtnDelete.Enabled = False
            BtnUndo.Enabled = False
            BtnSave.Enabled = False
            BtnFind.Enabled = False
            RecordPositionNumber = 0
            If Not AddMode Then
                BtnUndo.Enabled = False
                BtnSave.Enabled = False
                MessageBox.Show("No records found for this table!",
                                "Empty Table",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            Else
                BtnSave.Enabled = True
                BtnUndo.Enabled = True
            End If
        Else
            If RecordPositionNumber = 1 Then
                BtnFirst.Enabled = False
                BtnPrev.Enabled = False
                BtnLast.Enabled = True
                BtnNext.Enabled = True
            Else
                BtnFirst.Enabled = True
                BtnPrev.Enabled = True
                BtnLast.Enabled = True
                BtnNext.Enabled = True
            End If
            If RecordPositionNumber = RecordCount Then
                BtnLast.Enabled = False
                BtnNext.Enabled = False
                BtnFirst.Enabled = True
                BtnPrev.Enabled = True
            Else
                BtnLast.Enabled = True
                BtnNext.Enabled = True
            End If
            If editing OrElse adding Then
                BtnEdit.Enabled = False
                BtnAdd.Enabled = False
                BtnDelete.Enabled = False
                BtnUndo.Enabled = True
                BtnSave.Enabled = True
            Else
                BtnEdit.Enabled = True
                BtnDelete.Enabled = True
                BtnAdd.Enabled = True
                BtnUndo.Enabled = False
                BtnSave.Enabled = False
            End If
        End If
        LblRecordCount.Text = $"{_MsgRecordNo.Value} {RecordPositionNumber} {_MsgOf.Value} {RecordCount}"
    End Sub

    Private Shared Sub SetControlVisibility(ByRef cCtrl As Control, controlVisible As Boolean)
        ' if Visible is false, Don't show the controls content by masking content with '*' asterisk
        If Not controlVisible Then
            SetPropertyValue(cCtrl, "PasswordChar", Convert.ToChar("*"))
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.ClickButtonArea
        LastIdNo = GetPropertyValue(Me, IdFieldName)
        Try
            If _debugSwitch Then
                Debugger.Break()
            End If
            ClearData()
            MakeDefaultValues()
            AddMode = True
            EditMode = False
            TurnOnInputs()
            UpdateButtonDisplays(False, True)
            RaiseEvent BeforeAdd()
        Catch oEx As Exception
            MsgBox("Error:   " + oEx.Message)
            AddMode = False
        End Try
    End Sub

    Private Sub btnArabic_Click(sender As Object, e As EventArgs) Handles btnArabic.ClickButtonArea
        TextDisplayLanguage = GlobalVariables.DefaultMirroredCultureInfoStr
        TranslateForm()
        btnArabic.Visible = False
        btnOriginal.Visible = True
    End Sub

    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles BtnFind.ClickButtonArea
        FindRecord()
    End Sub

    Private Sub FindRecord()
        If OkToMove() Then
            Dim idNoOfFoundRecord As Integer
            idNoOfFoundRecord = PresenterObj.FindFieldContinue(TargetIdNo)
            If idNoOfFoundRecord = 0 Then
                If _MBLastRecordReachedStartFromBeginning.Show(Me) = DialogResult.Yes Then
                    BtnFirst.PerformClick()
                    BtnFind.PerformClick()
                Else
                    '' stay on the current record
                End If
            Else
                TargetIdNo = idNoOfFoundRecord
                GetAndSetRecordPositionNumber()
                GetAndDisplayRecordForGivenRecordPosition()
            End If
            If EditMode Then
                EditMode = False
            End If
            GetRecordInfoForIdNo()
            'DisplayView()
        End If
    End Sub

    Private Sub BtnFirst_Click(sender As Object, e As EventArgs) Handles BtnFirst.ClickButtonArea
        If _debugSwitch Then
            Debugger.Break()
        End If
        GoFirstRecord()
    End Sub

    Private Sub GoFirstRecord()
        If _debugSwitch Then
            Debugger.Break()
        End If
        If OkToMove("First") Then
            RecordPositionNumber = 1
            GetAndDisplayRecordForGivenRecordPosition()
        End If
    End Sub

    Private Sub BtnLast_Click(sender As Object, e As EventArgs) Handles BtnLast.ClickButtonArea
        If _debugSwitch Then
            Debugger.Break()
        End If
        If Not PresenterObj Is Nothing Then
            If OkToMove("Last") Then
                RecordPositionNumber = PresenterObj.GetRecordCount()
                GetAndDisplayRecordForGivenRecordPosition()
                'DisplayView()
                'RaiseEvent DisplayedRecordChanged()
            End If
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.ClickButtonArea
        If _debugSwitch Then
            Debugger.Break()
        End If
        If OkToMove("Next") Then
            If RecordPositionNumber = RecordCount Then
                _MBLastRecordAlready.Show(Me)
            Else
                RecordPositionNumber += 1
                GetAndDisplayRecordForGivenRecordPosition()
            End If
        End If
    End Sub

    Private Sub btnOriginal_Click(sender As Object, e As EventArgs) Handles btnOriginal.ClickButtonArea
        TextDisplayLanguage = GlobalVariables.DefaultUnmirroredCultureInfoStr
        TranslateForm()
        btnArabic.Visible = True
        btnOriginal.Visible = False
    End Sub

    Private Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles BtnPrev.Click
        If _debugSwitch Then
            Debugger.Break()
        End If
        If OkToMove("Previous") Then
            If RecordPositionNumber = 1 Or RecordPositionNumber = 0 Then
                _MBFirstRecordAlready.Show(Me)
            Else
                RecordPositionNumber -= 1
                GetAndDisplayRecordForGivenRecordPosition()
                'DisplayView()
                'RaiseEvent DisplayedRecordChanged()
            End If
        End If
    End Sub

    Private Sub BtnQuit_Click(sender As Object, e As EventArgs) Handles BtnQuit.ClickButtonArea
        If _debugSwitch Then
            Debugger.Break()
        End If
        If OkToMove("Quit") Then
            CancelClose = False
            Close()
            GC.Collect()
            GC.WaitForPendingFinalizers()
            If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
            End If
            Dispose()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.ClickButtonArea
        If _debugSwitch Then
            Debugger.Break()
        End If
        Save()
    End Sub

    Public Sub Save()
        If AddMode OrElse ChangesMade() Then
            Dim errorList As String = ""
            Dim retValue As Integer = -1
            If AutomaticValidationsOk() AndAlso DataIsValid() Then
                If AddMode Then
                    retValue = SaveDataEntry()
                Else
                    If PresenterObj.HasRecordChanged(TargetIdNo, RecordDateTimeStampValue) Then
                        MessageBox.Show("Record Has Changed since you last retrieved the record, cannot save your modifications. Please refresh the record and try again.")
                        retValue = -1
                    Else
                        retValue = SaveDataEntry()
                    End If
                End If
                If AddMode Then
                    ' retValue will be the IDNo of the newly saved record
                    If retValue > 0 Then
                        '' redisplay the record, need to do this to get an updated record
                        '' and to display the added record in the TreeView if one is present.
                        '' retValue now holds the Identity Column of the added record
                        AddMode = False
                        TargetIdNo = retValue
                        GetRecordInfoForIdNo()
                        RaiseEvent AfterAdd()
                        'DisplayView()
                    End If
                Else
                    If retValue <= 0 Then
                        '' Something went wrong during the saving since no record was/were updated
                        '' retValue = -1 , for unsuccessful save
                        '_MBSaveRecordFailed.Show(Me)
                    Else
                        '' redisplay the record, need to do this to get an updated record
                        '' and to re-display the added record in the TreeView if one is present.
                        '' because if ever something was changed in the record that affects the TreeView
                        '' display this next command will get an updated record and display the correct data
                        'TargetIdNo = currentIdNo
                        GetRecordInfoForIdNo()
                        'DisplayView()
                        EditMode = False
                    End If
                End If
            End If
            If retValue < 1 Then
                MyErrorProvider.ClearAllErrorMessages()
                Dim lErrors = PresenterObj.GetErrors()
                For Each _err In lErrors
                    For Each ctrl In MyErrorProvider.Controls
                        If ctrl.errormessage = _err Then
                            MyErrorProvider.SetError(ctrl.ControlObj, _err)
                        End If
                    Next
                Next
                PresenterObj.ShowErrors("Record not saved!")
            End If
        Else
            _MBNoChangesMadeNothingToSave.Show(Me)
        End If
    End Sub

    Protected Overridable Function DataIsValid() As Boolean
        Dim retValue As Boolean = False
        RaiseEvent BeforeValidate()
        If PresenterObj.DataIsValid() Then
            retValue = True
        End If
        Return retValue
    End Function

    Private Sub BtnUndo_Click(sender As Object, e As EventArgs) Handles BtnUndo.ClickButtonArea
        If OkToMove("Undo") Then
            'RaiseEvent UndoEdits(True)
            UndoMode = True
            If AddMode Then
                AddMode = False
                TargetIdNo = LastIdNo
                GetRecordInfoForIdNo()
                'DisplayView()
            Else
                EditMode = False
                GetRecordInfoForIdNo()
                'DisplayView()
            End If
        End If
        UndoMode = False
        CancelClose = True
    End Sub

    Private Sub CButton1_Click(sender As Object, e As EventArgs) Handles CButton1.ClickButtonArea
        Dim frm As New TranslationTableManager()
        frm.FormIdNoToTranslate = FormIdNo
        frm.AppDataDAC = AppDataDAC
        frm.TranslatorDAC = TranslatorDAC
        frm.Show()
    End Sub

    Private Sub CFormEntry_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        If CancelClose Then
            e.Cancel = True
        Else
            CancelClose = False
        End If
    End Sub

    Private Sub CFormEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not DesignMode Then
            AddHandler TextDisplayLanguageChanged, AddressOf OnTextDisplayLanguageChanged
            TextDisplayLanguage = CultureInfo.CurrentCulture.Name
            CreateDataSources()
            CreateFieldsDictionary()
            TurnOffInputs()

            Try
                RecordPositionNumber = PresenterObj.GetRecordCount()
                If RecordPositionNumber <> 0 Then
                    GetAndDisplayRecordForGivenRecordPosition()
                    BtnFind.Enabled = False
                Else
                    UpdateButtonDisplays(False, False)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message + Name)
                Debugger.Break()
            End Try

            'TableDefaultFieldValues = PresenterObj.GetDefaultFieldValues()
            Dim rules = PresenterObj.GetBizObjectRules()
            For Each rule In rules
                Dim control As Control = Nothing
                FieldsDictionary.TryGetValue(rule.Property, control)
                MyErrorProvider.Controls.AddValidation(control, rule.Property, rule.Error)
            Next
            SetAllControlsDynamicProperties()
            RaiseEvent AfterLoad()
            AddMandatoryFieldCHeck()
            FirstControl.Focus()
            If GlobalVariables.RightToLeftLayout Then
                btnArabic.Visible = False
                btnOriginal.Visible = True
            Else
                btnArabic.Visible = True
                btnOriginal.Visible = False
            End If

            'AddHandler BtnNext.DoubleClick, AddressOf BtnNext.MyDoubleClick
            'AddHandler BtnNext.DoubleClick, AddressOf TurnOnDebugger
        End If
    End Sub

    'Protected Async Sub GetRecordInfoForIdNo()
    '    Dim tasks As New List(Of Task)
    '    Dim taskRecordCount As New Task(Of Integer)(AddressOf PresenterObj.GetRecordCount)
    '    Dim taskRecordDateTimeStampValue As New Task(Of Object)(AddressOf GetRecordDateTimeStamp2)
    '    Dim tmpUndoMode as Boolean = UndoMode
    '    tasks.Add(taskRecordCount)
    '    tasks.Add(taskRecordDateTimeStampValue)
    '    taskRecordCount.Start()
    '    taskRecordDateTimeStampValue.Start()
    '    Await Task.WhenAll(tasks)
    '    UndoMode = tmpUndoMode
    '    RecordCount = Await taskRecordCount
    '    RecordDateTimeStampValue = Await taskRecordDateTimeStampValue
    '    LblRecordCount.Text = $"{_MsgRecordNo.Value} {RecordPositionNumber} {_MsgOf.Value}{RecordCount}"
    '    MyErrorProvider.ClearAllErrorMessages()
    '    EnableAddOrEditMode(TurnOff, TurnOff)
    '    DisplayView()
    '    UndoMode = False
    'End Sub

    Private Sub ClearData()
        Dim allCtrl As New List(Of Control)
        Dim initValue = ""
        For Each cCtrl As Control In FindControlRecursive(allCtrl, Me)
            Try
                If TypeOf cCtrl Is CTextBox OrElse TypeOf cCtrl Is CMaskedTextBox Then
                    Try
                        initValue = GetPropertyValue(cCtrl, "DefaultValue")
                    Catch ex As Exception
                        '' ignore error if no 'DefaultValue' property
                    End Try
                    cCtrl.Text = initValue
                ElseIf TypeOf cCtrl Is TxtComboBox Then
                    CallByName(cCtrl, "MakeDefault", CallType.Method)
                ElseIf TypeOf cCtrl Is CComboBox Or TypeOf cCtrl Is CaComboBox Then
                    'SetPropertyValue(cCtrl, "Text", "")
                    SetPropertyValue(cCtrl, "SelectedItem", Nothing)
                    SetPropertyValue(cCtrl, "SelectedIndex", -1)
                    SetPropertyValue(cCtrl, "Text", "")
                ElseIf _
                    TypeOf cCtrl Is CCustomDateTimePicker OrElse TypeOf cCtrl Is CDTPHijriDate OrElse
                    TypeOf cCtrl Is tdpGregorian OrElse TypeOf cCtrl Is CDtpGregorianDate Then
                    SetPropertyValue(cCtrl, "Value", Nothing)
                End If
            Catch ' ignore fields that don't have a column to bind to
                ''
            End Try
        Next
    End Sub

    Private Function GetControlSecurityIdNo(ByRef controlSecurityKey As String) As Int64
        Return SecurityPresenterObj.GetControlSecurityIdNo(controlSecurityKey)
    End Function

    Private Function GetControlSecurityKey(ByRef cCtrl As Control)
        If Not DesignMode Then
            If cCtrl.GetType().GetProperty("SecurityKey") IsNot Nothing Then
                Return GetPropertyValue(cCtrl, "SecurityKey")
            End If
        End If
        Return ""
    End Function

    Private Function GetControlSecurityValues(ByRef controlSecurityKey As String) As ArrayList
        Dim controlSecurityObjectIdNo As Int32
        controlSecurityObjectIdNo = GetControlSecurityIdNo(controlSecurityKey)
        Return SecurityPresenterObj.GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo)
    End Function

    'Private Sub InitiateSave(ByVal sender As Object, ByVal e As WaitWindowEventArgs)
    Private Function InitiateSave(retValue As Short) ' As Short
        Try
            Using scope As New TransactionScope(TransactionScopeOption.Required, New TimeSpan(0, 1, 0))
                retValue = PresenterObj.Save(AddMode)
                If retValue <= 0 Then
                    '_MBRecordNotSaved.Show(Me)
                Else
                    If AddMode Then
                        RaiseEvent ParentRecordAddedSuccessfully(retValue)
                        TargetIdNo = retValue
                        RaiseEvent SuccessfulAdd(retValue)
                        'AddMode = False
                    Else
                        ' Using scope As New TransactionScope(TransactionScopeOption.RequiresNew)
                        RaiseEvent ParentRecordUpdatedSuccessfully(retValue)
                        RaiseEvent SuccessfulUpdate(retValue)
                        'EditMode = False
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

    'Public Property SortOrderKey As String
    '    Set
    '        _SortOrderKey = value
    '    End Set
    '    Get
    '        Return _SortOrderKey
    '    End Get
    'End Property
    Private Sub Inputs(onOff As Boolean)
        Dim allCtrl As New List(Of Control)
        Dim ctrl As Control
        'Dim dsSchema As New DataSet
        For Each ctrl In FindControlRecursive(allCtrl, Me)
            If TypeOf ctrl Is IEntryControl Then
                'If ctrl.Name.ToLower = "datagridviewgeneraljournalitems" Then
                '    Debugger.Break()
                'End If
                SetPropertyValue(ctrl, "EditingMode", Not onOff)
            End If
            'Dim y =  ctrl.GetType().BaseType
            'Select Case y
            '    Case TypeOf y is TextBox
            '        Y = 2
            '    Case System.Windows.Forms.ComboBox
            '        Y = 1
            '    Case else
            '        Try
            '            SetPropertyValue(ctrl, "EditingMode", Not onOff, True)
            '        Catch ex As Exception
            '            ' ignore errors
            '        End Try
            '        If onOff Then
            '            ctrl.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            '            ctrl.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
            '        Else
            '            ctrl.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            '            ctrl.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            '        End If
            'End Select

            'If (TypeOf ctrl Is TxtComboBox AndAlso GetPropertyValue(ctrl, "DisplayOnly")) Then
            '    Dim cCtrl As TxtComboBox = ctrl
            '    cCtrl.TcbComboBox.DropDownStyle = ComboBoxStyle.Simple
            '    cCtrl.TcbComboBox.ReadOnlyCombo = True
            '    ctrl.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            '    ctrl.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            'ElseIf TypeOf ctrl Is CComboBox AndAlso TypeOf ctrl.Parent Is TxtComboBox AndAlso GetPropertyValue(ctrl.Parent, "DisplayOnly") Then
            '    Dim cCtrl As CComboBox = ctrl
            '    cCtrl.DropDownStyle = ComboBoxStyle.Simple
            '    cCtrl.ReadOnlyCombo = True
            '    ctrl.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            '    ctrl.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            'ElseIf _
            '    TypeOf ctrl Is CTextBox OrElse TypeOf ctrl Is CMaskedTextBox OrElse TypeOf ctrl Is CComboBox OrElse
            '    TypeOf ctrl Is TxtComboBox OrElse
            '    TypeOf ctrl Is CDataGridView OrElse TypeOf ctrl Is CDateTimePicker OrElse TypeOf ctrl Is TdpDateTime OrElse
            '    TypeOf ctrl Is tdpGregorian OrElse TypeOf ctrl Is CDTPHijriDate OrElse TypeOf ctrl Is CDtpGregorianDate OrElse
            '    TypeOf ctrl Is CMaskedTextBox OrElse TypeOf ctrl Is CCustomDateTimePicker OrElse
            '    TypeOf ctrl Is CCheckBox Then
            '    'If CallByName(Ctrl, "DisplayOnly", CallType.Get) Then
            '    If GetPropertyValue(ctrl, "DisplayOnly") Then
            '        'If ctrl.Name = "tcbAccountGroup" Then
            '        '    Debugger.Break()
            '        'End If
            '        If TypeOf ctrl Is CComboBox Then
            '            If TypeOf ctrl.Parent Is TxtComboBoxReadOnly Then

            '                '' ignore this already evaluated on the parent
            '            Else
            '                SetPropertyValue(ctrl, "DropDownStyle", ComboBoxStyle.Simple)
            '                SetPropertyValue(ctrl, "ReadOnlyCombo", True)
            '            End If
            '        ElseIf TypeOf ctrl Is TxtComboBox Then
            '            Dim cc As TxtComboBox = ctrl
            '            cc.ReadOnlyTcb = True
            '        ElseIf TypeOf ctrl Is DataGridView Then
            '            Dim dgv As DataGridView = ctrl
            '            ' Loop through your datagridview columns
            '            For Each column As DataGridViewColumn In dgv.Columns
            '                SetPropertyValue(column, "ReadOnly", True)
            '            Next
            '        ElseIf _
            '            TypeOf ctrl Is CCustomDateTimePicker OrElse TypeOf ctrl Is tdpGregorian OrElse
            '            TypeOf ctrl Is CDtpGregorianDate OrElse TypeOf ctrl Is CDTPHijriDate OrElse
            '            TypeOf ctrl Is TdpDateTime OrElse TypeOf ctrl Is CDateTimePicker Then
            '            SetPropertyValue(ctrl, "ReadOnlyDP", True)
            '        ElseIf TypeOf ctrl Is CCheckBox Then
            '            SetPropertyValue(ctrl, "ReadOnlyCk", True)
            '        Else
            '            SetPropertyValue(ctrl, "ReadOnly", True)
            '        End If
            '        If GetPropertyValue(ctrl, "PasswordChar") = "*" Then
            '            SetPropertyValue(ctrl, "BackColor", ctrl.ForeColor)
            '        Else
            '            ctrl.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            '            ctrl.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            '        End If
            '    Else
            '        If TypeOf ctrl Is CComboBox Then
            '            Dim hideMe As Boolean
            '            'HideMe = GetPropertyValue(Ctrl, "HideWhenNotEditingOrAdding")
            '            If onOff Then
            '                SetPropertyValue(ctrl, "DropDownStyle", GetPropertyValue(ctrl, "OriginalDropDownStyle"))
            '                ctrl.Visible = True
            '            Else
            '                hideMe = GetPropertyValue(ctrl, "HideWhenNotEditingOrAdding")
            '                If hideMe Then
            '                    ctrl.Visible = True
            '                Else
            '                    ctrl.Visible = False
            '                End If
            '                SetPropertyValue(ctrl, "DropDownStyle", ComboBoxStyle.Simple)
            '            End If
            '            SetPropertyValue(ctrl, "ReadOnlyCombo", Not onOff)
            '        ElseIf TypeOf ctrl Is TxtComboBox Then
            '            SetPropertyValue(ctrl, "ReadOnlyTcb", False)
            '        ElseIf TypeOf ctrl Is CDataGridView Then
            '            Dim dgv As DataGridView = ctrl
            '            ' Loop through your datagridview columns
            '            SetPropertyValue(ctrl, "ReadOnly", Not onOff)
            '            For Each column As DataGridViewColumn In dgv.Columns
            '                Try
            '                    If GetPropertyValue(column.CellTemplate, "DisplayOnly") Then
            '                        SetPropertyValue(column, "ReadOnly", True)
            '                    Else
            '                        SetPropertyValue(column, "ReadOnly", Not onOff)
            '                    End If
            '                Catch ex As Exception
            '                    'SetPropertyValue(column, "ReadOnly", Not onOff)
            '                End Try
            '            Next
            '        ElseIf _
            '            TypeOf ctrl Is CCustomDateTimePicker OrElse TypeOf ctrl Is CDtpGregorianDate OrElse
            '            TypeOf ctrl Is TdpDateTime OrElse TypeOf ctrl Is tdpGregorian OrElse
            '            TypeOf ctrl Is CDtpGregorianDate OrElse TypeOf ctrl Is CDTPHijriDate OrElse
            '            TypeOf ctrl Is CDateTimePicker Then
            '            SetPropertyValue(ctrl, "ReadOnlyDP", Not onOff)

            '        ElseIf TypeOf ctrl Is CCheckBox Then
            '            SetPropertyValue(ctrl, "ReadOnlyCk", Not onOff)
            '        Else
            '            If ctrl.Name = "DGVSecurityObjectName" Then
            '                SetPropertyValue(ctrl, "ReadOnly", Not onOff)
            '            Else
            '                Try
            '                    SetPropertyValue(ctrl, "ReadOnly", Not onOff)
            '                Catch ex As Exception

            '                End Try
            '            End If
            '        End If
            '        If GetPropertyValue(ctrl, "PasswordChar") = "*" Then
            '            SetPropertyValue(ctrl, "BackColor", ctrl.ForeColor)
            '        Else
            '            If onOff Then
            '                ctrl.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            '                ctrl.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
            '            Else
            '                ctrl.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            '                ctrl.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            '            End If
            '        End If
            '    End If
            'End If

        Next
        FirstControl.Focus()
    End Sub

    Private Function IsRecordNotUnique(cCtrl As Control, fldName As String) As Boolean
        If PresenterObj.CheckIfUnique(cCtrl.Text, fldName, TargetIdNo) Then
            Return False
        End If
        Return True
    End Function

    Private Sub MakeDefaultValues()
        'Dim allCtrl As New List(Of Control)
        'Dim initValue = ""
        PresenterObj.MakeDefaultValues()
    End Sub

    Private Sub SetAllControlsDynamicProperties()
        If Not DesignMode Then
            Dim allControls As New List(Of Control)
            Dim resources = New ComponentResourceManager(Me.GetType())
            TableProperties = PresenterObj.TableProperties
            For Each cCtrl As Control In FindControlRecursive(allControls, Me)
                SetControlDynamicProperties(cCtrl)
                SetControlSecurity(cCtrl)
                resources.ApplyResources(cCtrl, cCtrl.Name, _currentCulture)
            Next
        End If
    End Sub

    Private Sub SetControlDynamicProperties(ByRef cCtrl As Control)
        'If cCtrl.GetType().GetProperty("DataBoundControl") IsNot Nothing Then
        If TypeOf cCtrl Is IEntryControl Then
            ' get FieldName from control : by convention when using this system
            ' all DataBoundControls TextBox & Combobox that will hold field variables are named by convention in this format
            ' textboxes  = txt<FieldName>
            ' combobox   = cbo<FieldName>
            ' datetimepicker = dtp<FieldName>
            ' so to get the field name just get the characters from the control starting at the 4th character onwards
            Dim fldName As String
            fldName = cCtrl.Name.Substring(3) ' get control name starting from the 3rd character (0 based)

            For Each row In TableProperties
                'If fldName.ToLower() = "amount" Then
                '    Debugger.Break()
                'End If
                If fldName.ToLower() = row.FldName.ToLower Then
                    If TypeOf cCtrl Is CTextBox OrElse TypeOf cCtrl Is CComboBox OrElse TypeOf cCtrl Is CMaskedTextBox OrElse
                       TypeOf cCtrl Is CTextBoxArabic Then
                        'Dim mm As TextBox = CCtrl
                        If row.FldType.ToLower = "int" OrElse row.FldType.ToLower = "numeric" OrElse row.FldType.ToLower = "decimal" OrElse row.FldType.ToLower = "single" OrElse row.FldType.ToLower = "money" Then
                            If row.FldType.ToLower = "money" Then
                                SetPropertyValue(cCtrl, "Maxlength", 19)
                            Else
                                SetPropertyValue(cCtrl, "Maxlength", row.MaxLength)
                            End If

                            SetPropertyValue(cCtrl, "ValueIsNumeric", True)
                            'If CommonDaoOld.IsFieldUnique(MainTableName, fldName) Then
                            '    If TypeOf cCtrl Is CTextBox Or TypeOf cCtrl Is CTextBoxArabic Then
                            '        SetPropertyValue(cCtrl, "ValueIsUnique", True)
                            '    End If
                            'Else
                            '    If TypeOf cCtrl Is CTextBox Or TypeOf cCtrl Is CTextBoxArabic Then
                            '        SetPropertyValue(cCtrl, "ValueIsUnique", False)
                            '    End If
                            'End If
                        Else
                            'If cCtrl.Name.ToLower() = "txtnotes" then
                            '    debugger.Break()
                            'End If
                            SetPropertyValue(cCtrl, "Maxlength", If(row.fldType.ToLower() = "nvarchar", Convert.ToInt16(row.MaxLength / 2), row.MaxLength))
                            SetPropertyValue(cCtrl, "ValueIsNullable", row.IsNullable)
                            If (Not row.IsIdentity) And (Not row.IsNullable) Then
                                'Add this controls in error provider for mandatory fields.
                                'MyErrorProvider.Controls.AddMandatory(CCtrl, CCtrl.Name)
                                'Dim thisCtrl As CTextBox
                                'thisCtrl = cCtrl
                                If GetPropertyValue(cCtrl, "IgnoreNullCheck") Then
                                    'If Not thisCtrl.IgnoreNullCheck Then
                                    If GetPropertyValue(cCtrl, "LinkedLabel") Is Nothing Then
                                        ''If thisCtrl.LinkedLabel Is Nothing Then
                                        MyErrorProvider.Controls.AddMandatory(cCtrl, cCtrl.Name)
                                    Else
                                        MyErrorProvider.Controls.AddMandatory(cCtrl, GetPropertyValue(cCtrl, "LinkedLabel"))
                                        'MyErrorProvider.Controls.AddMandatory(cCtrl, thisCtrl.LinkedLabel.Text)
                                    End If
                                End If
                                'If CommonDaoOld.IsFieldUnique(MainTableName, fldName) Then
                                '    If TypeOf cCtrl Is CTextBox Or TypeOf cCtrl Is CTextBoxArabic Then
                                '        SetPropertyValue(cCtrl, "ValueIsUnique", True)
                                '    End If
                                'Else
                                '    If TypeOf cCtrl Is CTextBox Or TypeOf cCtrl Is CTextBoxArabic Then
                                '        SetPropertyValue(cCtrl, "ValueIsUnique", False)
                                '    End If
                                'End If
                            End If
                        End If
                        Exit For
                    ElseIf _
                        TypeOf cCtrl Is CCustomDateTimePicker OrElse TypeOf cCtrl Is CDateTimePicker OrElse
                        TypeOf cCtrl Is CDTPHijriDate OrElse TypeOf cCtrl Is tdpGregorian OrElse
                        TypeOf cCtrl Is CDtpGregorianDate Then
                        SetPropertyValue(cCtrl, "ValueIsNullable", row.IsNullable)
                        If Not row.IsNullable Then
                            'Add this controls to the Mandatory fields error provider.
                            MyErrorProvider.Controls.AddMandatory(cCtrl, cCtrl.Name)
                        End If
                        Exit For
                    End If

                End If
            Next
        End If
    End Sub

    Private Sub SetControlEditability(ByRef cCtrl As Control, ByRef editable As Boolean)
        ' if Editable is False, make the control readonly property so that it can't be edited
        If Not editable Then
            SetPropertyValue(cCtrl, "DisplayOnly", True)
        End If
    End Sub

    Private Sub SetControlMaskability(ByRef cCtrl As Control, ByRef viewable As Boolean)
        ' if Editable is False, make the control readonly property so that it can't be edited
        If Not viewable Then
            SetPropertyValue(cCtrl, "Viewable", True)
        End If
    End Sub

    Private Sub SetControlSelectability(ByRef cCtrl As Control, ByRef selectable As Boolean)
        ' if Editable is False, make the control readonly property so that it can't be edited
        If Not selectable Then
            SetPropertyValue(cCtrl, "Enabled", selectable)
        End If
    End Sub

    'Private Sub OnButtonDoubleCLick(sender As Object, e As EventArgs) Handles BtnFirst.DoubleClick, BtnNext.DoubleClick,
    '            BtnPrev.DoubleClick, BtnLast.DoubleClick, BtnDelete.DoubleClick, BtnAdd.DoubleClick, BtnEdit.DoubleClick,
    '            BtnSave.DoubleClick, BtnUndo.DoubleClick
    '    Debugger.Break()
    '    sender.PerformClick()
    'End Sub

    Private Sub btnDebugSave_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnDebugSwitch.ClickButtonArea
        If _debugSwitch = 0 Then
            _debugSwitch = 1
            btnDebugSwitch.Text = "Turn Off Debugger"
        Else
            _debugSwitch = 0
            btnDebugSwitch.Text = "Turn On Debugger"
        End If
    End Sub

End Class
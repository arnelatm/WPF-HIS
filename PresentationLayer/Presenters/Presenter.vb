Imports System.Globalization
Imports System.Reflection
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

''' <summary>
'''     Base class for all presenter classes. Keeps track of Service and View classes.
'''     Notice that Service is static and View is set in the constructor.
''' </summary>
''' <remarks>
'''     MV Patterns: MVP design pattern.
''' </remarks>
''' <typeparam name="TV">Type of itemView.</typeparam>
Public MustInherit Class Presenter(Of TV As IView, TM As New)
    Inherits PresenterBase(Of TV, TM)
    Implements ISubscriber(Of FindFieldRequested),
               ISubscriber(Of ViewButtonClicked)

    Private _tableDefaultFieldValueList As List(Of DefaultFieldValueModel)
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
    Public Event BeforeChangeRecord()
    Public Event AfterChangeRecord()

    'Public Shadows Event AfterDelete(retVal As Integer)

    'Public Shadows Event BeforeDelete()

    'Public Shadows Event BeforeEdit()

    'Public Shadows Event BeforeMappingData(dataModel As TM)

    Public Sub New()
    End Sub

    Public Sub New(itemView As IView)
        MyBase.New(itemView)
        InitializeTreeViewIfPresent()
        WithTreeView = True
    End Sub

    Private Sub InitializeTreeViewIfPresent()
        Dim pi As PropertyInfo = View.GetType().GetProperty("FormTreeView")
        If pi IsNot Nothing Then
            _WithTreeView = True
            FormTreeView = pi.GetValue(View)
        End If
    End Sub

    Public Property WithTreeView As Boolean

    Public Sub OnAfterSave() Handles Me.AfterSave
        If _WithTreeView Then
            TreeViewAfterSave()
        End If
    End Sub

    Public Sub OnBeforeDelete() Handles Me.BeforeDelete
        If _WithTreeView Then
            TreeViewBeforeDelete()
        End If
    End Sub

    Public Sub OnAfterDelete(retValue) Handles Me.AfterDelete
        If _WithTreeView Then
            TreeViewAfterDelete(retValue)
        End If
    End Sub

    Public Overrides Sub UpdateViewData(idNo As Int32)
        MyBase.UpdateViewData(idNo)
        If _WithTreeView Then
            TreeViewUpdateViewDisplay(idNo)
        End If
    End Sub

    Public Sub OnFindFieldRequested_EventHandler(ByRef eventType As FindFieldRequested) Implements ISubscriber(Of FindFieldRequested).OnEventHandler
        Dim idNo = Service.FindFieldNew(TableName, eventType.FindableControl, SortOrderKey, DataFilter)
        If idNo <> 0 Then
            RecordPositionNumber = GetSortedRecordPosition(idNo)
        Else
            Messaging.Show(True, "MsgNoMatchingRecordFound")
        End If
    End Sub

    Public Overrides Sub ViewButtonClicked(ByRef eventType As ViewButtonClicked)
        RaiseEvent BeforeChangeRecord()

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
            Case ButtonClicked.Delete
                GoDeleteRecord()
        End Select
        RaiseEvent AfterChangeRecord()
    End Sub

    Public Overrides Sub EntryFormLoaded()
        If _WithTreeView Then
            DisplayTree()
        End If
    End Sub

    Protected Overrides Function ChildRecordExist(Optional ByVal warn As Boolean = True) As Boolean
        Dim returnValue As Boolean = False
        If ParentFieldName IsNot Nothing AndAlso ParentFieldName <> "" Then
            Dim filter As String
            filter = ParentFieldName + " = " + CallByName(View, IdFieldName, CallType.Get).ToString()
            If Service.GetRecordCount(TableName, filter) > 0 Then
                If warn Then
                    Messaging.Show(True, "MsgChildRecordsExists")
                End If
                returnValue = True
            End If
        End If
        Return returnValue
    End Function

#Region "TreeView"

    Protected TreeViewList
    Protected TreeViewMainField As String
    Protected TreeViewSecondaryField As String
    Protected ParentFieldName As String = ""
    Protected WithEvents FormTreeView As TreeView
    Protected NodeToDelete As TreeNode

    Public Sub DisplayTree(Optional IdNo As Int64 = 0)
        If WithTreeView Then
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
            If IdNo <> 0 Then
                TargetIdNo = IdNo
            End If
            GotoRecordInTreeView()
        End If
    End Sub

    Public Function GetTreeViewData()
        Dim cModel As New TM
        Dim lookupObj As New Lookup(TableName, DataFilter)
        lookupObj.NameField = TreeViewMainField

        ComposeSecondaryField()
        If SortOrderKey IsNot Nothing Then
            lookupObj.SortKey = SortOrderKey
        End If
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

    Private Sub ComposeSecondaryField()
        If Len(TableName) >= 5 AndAlso Right(TableName, 5) = "_View" Then
            If TreeViewSecondaryField Is Nothing Then
                If TableBaseName Is Nothing Then
                    TreeViewSecondaryField = Left(TableName, TableName.Length - 5) + "Code"
                Else
                    TreeViewSecondaryField = Left(TableBaseName, TableName.Length - 5) + "Code"
                End If
            End If
        Else
            If TreeViewSecondaryField Is Nothing Then
                If TableBaseName Is Nothing Then
                    TreeViewSecondaryField = TableName + "Code"
                Else
                    TreeViewSecondaryField = TableBaseName + "Code"
                End If
            End If
        End If
        If String.IsNullOrEmpty(TreeViewSecondaryField) Then
            TreeViewSecondaryField = ""
        End If
    End Sub

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
        Dim secondaryValue As String = GetPropertyValue(dataNode, "IdNo")
        Dim treeNode As TreeNode = MakeTreeNode(mainValue, secondaryValue, idNo)
        FormTreeView.Nodes(0).Nodes.Add(treeNode)
    End Sub

    Protected Function MakeTreeNode(mainFieldValue As String, secondaryFieldValue As String, idNo As Int32) _
        As TreeNode
        Dim treeTextDisplay As String
        If TreeViewSecondaryField Is Nothing OrElse TreeViewSecondaryField <> "" Then
            treeTextDisplay = TreeNodeTextDisplay(mainFieldValue, secondaryFieldValue)
        Else
            treeTextDisplay = TreeNodeTextDisplay(mainFieldValue)
        End If
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
        RaiseEvent BeforeChangeRecord()
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
        RaiseEvent AfterChangeRecord()
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

#End Region

    'Public Sub OnPresenter_LanguageChangedEventHandler(ByRef eventType As LanguageChanged) Implements ISubscriber(Of LanguageChanged).OnEventHandler
    Public Sub OnLanguageChanged() Handles MyBase.LanguageChanged
        If _WithTreeView Then
            DisplayTree()
        End If
        Dim idNo = CallByName(View, IdFieldName, CallType.Get)
        TargetIdNo = idNo
        RecordPositionNumber = GetSortedRecordPosition(idNo)
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

    Public ReadOnly Property EstablishmentName As String
        Get
            Return GetRecordField("Establishment", "EstablishmentName")
        End Get
    End Property

    Public ReadOnly Property EstablishmentNameAra As String
        Get
            Return GetRecordField("Establishment", "EstablishmentNameAra")
        End Get
    End Property

End Class
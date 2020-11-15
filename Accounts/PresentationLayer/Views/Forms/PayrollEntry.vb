Imports System.ComponentModel
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Forms

    Public Class PayrollEntry
        Implements IPayPeriodView

        Protected TvMainFieldName As String
        Protected TvSecondaryFieldName As String
        Protected TvSortKey As String
        Private _bypassSelectedChange As Boolean = False
        Private _employees
        Private _payGroups 

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            ' GlobalVariables.EventAggregator.SubscribeEvent(Me)
            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "PayPeriod"
            TvMainFieldName = "PayPeriodName"
            TvSecondaryFieldName = "PayPeriodCode"
            SortOrderKey = "SortKey"
            FirstControl = txtPayrollIdNo
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New PayPeriodPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
            _employees = PresenterObj.GetLookup("Employee")
            _payGroups = PresenterObj.GetLookup("PayGroups")
        End Sub

#Region "Fields"

        Public Property EndDate As Date Implements IPayPeriodView.EndDate
        Public Property IdNo As Int32 Implements IPayPeriodView.IdNo

        Public Property PayCycleIdNo As Int16 Implements IPayPeriodView.PayCycleIdNo

        Public Property PayPeriodCode As String Implements IPayPeriodView.PayPeriodCode
        Public Property PayPeriodName As String Implements IPayPeriodView.PayPeriodName
        Public Property PayPeriodNameAra As String Implements IPayPeriodView.PayPeriodNameAra
        Public Property StartDate As Date Implements IPayPeriodView.StartDate

#End Region

        Public Sub DisplayTree(ByRef treeViewData As Object)
            Dim root As TreeNode = trvPayroll.Nodes(0)
            'Dim displayMainFieldName = GetTranslatedField(TvMainFieldName)
            root.Nodes.Clear()
            ' create the tree
            If GlobalVariables.RightToLeftLayout Then
                trvPayroll.RightToLeftLayout = True
            Else
                trvPayroll.RightToLeftLayout = False
            End If
            trvPayroll.RightToLeft = RightToLeft.Inherit
            If ParentFieldName Is Nothing OrElse ParentFieldName = "" Then
                For Each dataNode In treeViewData
                    AddRecordToTree(dataNode)
                Next
            Else
                For Each dataNode In treeViewData
                    AddRecordToTreeHierarchical(dataNode, True)
                Next
            End If
        End Sub

        Private Sub LoadPayGroups(ByRef node As TreeNode)
            For Each payGroup In _payGroups
                node.Nodes.Add(New TreeNode With { .Text = payGroup.Name,
                                                   .Tag = payGroup.idNo,
                                                   .Name = payGroup.idNo
                                                 }
                              )
            Next payGroup
        End Sub

        Private Sub LoadEmployees(ByRef node As TreeNode)
            For Each employee In _employees
                node.Nodes.Add(New TreeNode With { .Text = employee.Name,
                                                   .Tag = employee.idNo,
                                                   .Name = employee.idNo
                                                 }
                              )
            Next employee
        End Sub

        Protected Overloads Sub AddRecordToTree(dataNode As Object) ', mainFieldName As String)
            Dim idNo As Int32 = GetPropertyValue(dataNode, PresenterObj.IdFieldName)
            Dim mainValue As String = GetPropertyValue(dataNode, "Name")
            Dim secondaryValue As String = GetPropertyValue(dataNode, "Code")
            Dim treeNode As TreeNode = MakeTreeNode(mainValue, secondaryValue, idNo)
            trvPayroll.Nodes(0).Nodes.Add(treeNode)
        End Sub

        Protected Overloads Sub AddRecordToTreeHierarchical(dataNode As Object, parentChanged As Boolean)
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
                        trvPayroll.Nodes(trvPayroll.Nodes.Count - 1).Nodes.Add(treeNode)
                    Else
                        trvPayroll.Nodes(0).Nodes.Add(treeNode)
                    End If
                Else
                    If parentChanged Then
                        Dim foundNode As TreeNode() = trvPayroll.Nodes.Find(parentIdValue.ToString(), True)
                        If foundNode.Length <> 0 Then
                            foundNode(0).Nodes.Add(treeNode)
                        End If
                    End If
                End If
            End If
        End Sub

        Protected Sub BfTvEntry_AfterSelect(sender As Object, e As TreeViewEventArgs) _
            Handles trvPayroll.AfterSelect
            If Not _bypassSelectedChange Then
                Select Case (e.Action)
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
                If Not PresenterObj.OkToMove() Then
                    Exit Sub
                End If
                Dim nTag As Integer
                trvPayroll.ImageIndex = 1
                If trvPayroll.SelectedNode.Tag.ToString = "root" Then
                    PresenterObj.RecordPositionNumber = 1
                Else
                    nTag = trvPayroll.SelectedNode.Tag
                    PresenterObj.RecordPositionNumber = PresenterObj.GetSortedRecordPosition(nTag)
                End If
                If Not trvPayroll.SelectedNode.IsVisible Then
                    trvPayroll.SelectedNode.EnsureVisible()
                End If
            End If
        End Sub

        Protected Sub DisplayTreeViewData()
            Dim treeViewData = PresenterObj.GetTreeViewData()
            DisplayTree(treeViewData)
            trvPayroll.ExpandAll()
            GotoRecordInTreeView()
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

        Protected Overrides Sub OnTextDisplayLanguageChanged() Handles Me.TextDisplayLanguageChanged
            MyBase.OnTextDisplayLanguageChanged()
            DisplayTreeViewData()
        End Sub

        Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
            MyBase.RecordPositionChanged(e)
            GotoRecordInTreeView()
        End Sub

        Protected Overrides Sub RecordSaved(ByRef e As RecordSaved)
            DisplayTreeViewData()
        End Sub

        Protected Sub RemoveCurrentNode(bypassChange As Boolean)
            If bypassChange Then
                _bypassSelectedChange = True
            End If
            trvPayroll.Nodes.Remove(trvPayroll.SelectedNode)
            _bypassSelectedChange = False
        End Sub

        Protected Overridable Function TreeNodeTextDisplay(tvName As String, ByVal Optional tvAdditionalText As String = "") _
            As String
            Return tvName + If(String.IsNullOrEmpty(tvAdditionalText), "", " (" + tvAdditionalText.ToString() + ")")
        End Function

        Private Sub BfTvEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
                trvPayroll.Nodes(0).Text = MainTableName
                trvPayroll.ExpandAll()
                DisplayTreeViewData()
            End If
        End Sub

        Private Sub BfTvEntry_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            _bypassSelectedChange = True
            If GlobalVariables.RightToLeftLayout Then
                RightToLeftLayout = True
                trvPayroll.RightToLeftLayout = True
                trvPayroll.RightToLeft = RightToLeft.Yes
            Else
                RightToLeftLayout = False
                trvPayroll.RightToLeftLayout = False
                trvPayroll.RightToLeft = RightToLeft.No
            End If
            trvPayroll.ExpandAll()
            _bypassSelectedChange = False
        End Sub

        Private Function GetMainFieldName(mainFieldName As String) As String
            If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
                If GlobalVariables.RightToLeftLayout Then
                    mainFieldName = mainFieldName + "Ara"
                End If
            End If
            Return mainFieldName
        End Function

        Private Sub GotoRecordInTreeView()
            Dim found As TreeNode() = trvPayroll.Nodes.Find(PresenterObj.TargetIdNo, True)
            If found.Length <> 0 Then
                With trvPayroll
                    _bypassSelectedChange = True
                    .SelectedNode = found(0)
                    _bypassSelectedChange = False
                    .HideSelection = False
                    .Select()
                End With
            End If
            ' update treeview text if ever name is changed
            'If Not TreeViewTableName.SelectedNode Is Nothing Then
            'TreeViewTableName.SelectedNode.Text = TreeNodeText
            'End If
            If trvPayroll.SelectedNode IsNot Nothing AndAlso trvPayroll.SelectedNode.IsVisible Then
                trvPayroll.SelectedNode.EnsureVisible()
            End If
        End Sub

    End Class

End Namespace
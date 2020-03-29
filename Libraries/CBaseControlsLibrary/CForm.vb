Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CForm

    Public Property FixedLtrRtlLayout As Boolean

    Public Property UseGlobalFormColor As Boolean = True
    Public Property DefaultFormBackColor As Color = Color.White
    Public Property DefaultFormForeColor As Color = Color.Black
    Public Property DefaultFormControlsBackColor As Color = Color.White
    Public Property DefaultFormControlsForeColor As Color = Color.Black
    Public Property DefaultFormControlsReadOnlyBackColor As Color = Color.White
    Public Property DefaultFormControlsReadOnlyForeColor As Color = Color.Gray

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        KeyPreview = True
    End Sub

    Public Property MenuFormName As String

    Private Sub CForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim allControls As New List(Of Control)

        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            If UseGlobalFormColor Then
                BackColor = GlobalVariables.DefaultFormBackgroundColor
                ForeColor = GlobalVariables.DefaultFormForegroundColor
                DefaultFormControlsBackColor = GlobalVariables.DefaultFormBackgroundColor
                DefaultFormControlsForeColor = GlobalVariables.DefaultFormForegroundColor
                DefaultFormControlsBackColor = GlobalVariables.DefaultFormControlBackgroundColor
                DefaultFormControlsForeColor = GlobalVariables.DefaultFormControlForegroundColor
                DefaultFormControlsReadOnlyBackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                DefaultFormControlsReadOnlyForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            End If
            'If System.Globalization.CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            If GlobalVariables.RightToLeftLayout Then
                RightToLeftLayout = True
                RightToLeft = RightToLeft.Yes
                'If GetPropertyValue(Me, "RightToLeftLayout") IsNot Nothing Then
                '    Me.RightToLeftLayout = True
                '    If GetPropertyValue(Me, "RightToLeft") IsNot Nothing Then
                '       Me.RightToLeft = RightToLeft.Yes
                '    End If
                'End If
                For Each cCtrl As Control In FindControlRecursive(allControls, Me)
                    If TypeOf cCtrl Is CButton OrElse TypeOf cCtrl Is Button Then
                        If GetPropertyValue(cCtrl, "Image") IsNot Nothing Then
                            Dim btnImageName As String
                            btnImageName = (cCtrl.Name.ToString() + "_" + Strings.Left(CultureInfo.CurrentCulture.Name, 2)).ToLower()
                            Dim resource As Object = My.Resources.ResourceManager.GetObject(btnImageName)
                            If Not (resource Is Nothing) Then
                                Dim i = CType(cCtrl, CButton)
                                i.Image = DirectCast(resource, Image)
                            End If
                        ElseIf TypeOf cCtrl Is CTabControl OrElse TypeOf cCtrl Is TabControl Then
                            Dim c = CType(cCtrl, CTabControl)
                            c.RightToLeftLayout = True
                            c.RightToLeft = RightToLeft.No
                        End If
                    End If
                Next cCtrl
            Else
                RightToLeftLayout = False
                RightToLeft = RightToLeft.No
            End If
        End If
    End Sub

    Public Function FindControlRecursive(ByVal list As List(Of Control), ByVal parentControl As Control) As List(Of Control)
        If parentControl Is Nothing Then Return list
        list.Add(parentControl)
        For Each child As Control In parentControl.Controls
            FindControlRecursive(list, child)
        Next
        Return list
    End Function

    ' ReSharper disable once UnusedMember.Local
    Private Sub SetToolStripItems(dropDownItems As ToolStripItemCollection) ', formName As String)
        Try
            For Each obj As Object In dropDownItems
                ' ReSharper disable once VBPossibleMistakenCallToGetType.2
                If obj.GetType().ToString() = "System.Windows.Forms.ToolStripButton" Then
                    Dim toolStripButton As ToolStripButton = obj
                    If toolStripButton.Text IsNot Nothing Then
                        'Dim securityName = formName + ".ToolStripButton." + toolStripButton.Name.Substring(15)
                        toolStripButton.Enabled = True
                        toolStripButton.Visible = True
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, $"SetToolStripItems", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    ' ReSharper disable once UnusedParameter.Local
    ' ReSharper disable once UnusedMember.Local
    Private Sub SetMenuStripItems(dropDownItems As ToolStripItemCollection, formName As String)
        Try

            For Each obj As Object In dropDownItems
                Dim subMenu = TryCast(obj, ToolStripMenuItem)

                If subMenu IsNot Nothing Then

                    If subMenu.HasDropDownItems Then
                        SetMenuStripItems(subMenu.DropDownItems, formName)
                    Else

                        If subMenu.Text IsNot Nothing Then
                            'Dim securityName = formName + ".ToolStripMenu." + subMenu.Name.Substring(17)
                            subMenu.Enabled = True
                            subMenu.Visible = True
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, $"SetMenuStripItems", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    ' The form will handle all key events before the control with
    ' focus handles them
    Private Sub CForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            e.Handled = True
            'Me.SelectNextControl(Me, True, True, true, true)
            SendKeys.Send("{TAB}")
            'SendWait("{TAB}")
            'ElseIf (e.KeyCode And Not Keys.Modifiers) = Keys.X AndAlso e.Modifiers = Keys.Control Then
        ElseIf e.KeyCode = Keys.X And e.Modifiers = Keys.Control Then

            If Me.ActiveControl.[GetType]() = GetType(TextBox) Then
                Dim textBox As TextBox = CType(Me.ActiveControl, TextBox)
                textBox.Cut()
            End If
            e.SuppressKeyPress = True

        ElseIf e.KeyCode = Keys.V And e.Modifiers = Keys.Control Then

            e.Handled = False
        ElseIf e.KeyCode = Keys.Z And e.Modifiers = Keys.Control Then

            e.Handled = False
        ElseIf e.KeyCode = Keys.A And e.Modifiers = Keys.Control Then

            e.Handled = False
        End If
    End Sub

    'Private Sub CForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    '    'If System.ComponentModel.LicenseManager.UsageMode <> System.ComponentModel.LicenseUsageMode.Designtime Then
    '    '    If GlobalVariables.RightToLeftLayout Then
    '    '        If GetPropertyValue(Me, "RightToLeftLayout") IsNot Nothing Then
    '    '            'Me.RightToLeftLayout = True
    '    '            'If GetPropertyValue(Me, "RightToLeft") IsNot Nothing Then
    '    '            '    'Me.RightToLeft = RightToLeft.Yes
    '    '            'End If
    '    '        End If
    '    '    Else
    '    '        If GetPropertyValue(Me, "RightToLeftLayout") IsNot Nothing Then
    '    '            'Me.RightToLeftLayout = False
    '    '            'If GetPropertyValue(Me, "RightToLeft") IsNot Nothing Then
    '    '            '    Me.RightToLeft = RightToLeft.No
    '    '            'End If
    '    '        End If
    '    '    End If
    '    'End If
    'End Sub

    'Public Sub ApplyFormResources(Of T)(ByRef obj As Object)
    '    Dim currentCulture As CultureInfo
    '    currentCulture = CultureInfo.CurrentCulture
    '    Dim allCtrl As New List(Of Control)
    '    Dim resources = New ComponentResourceManager(GetType(T))
    '    For Each c In FindControlRecursive(allCtrl, Me)
    '        resources.ApplyResources(c, c.Name, currentCulture)
    '    Next
    'End Sub
End Class
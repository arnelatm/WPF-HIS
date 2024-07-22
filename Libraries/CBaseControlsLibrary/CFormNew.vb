Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CFormNew

    Public Property FixedLtrRtlLayout As Boolean

    Public Property UseGlobalFormColor As Boolean = True
    Public Property DefaultFormBackColor As Color = Color.White
    Public Property DefaultFormForeColor As Color = Color.Black
    Public Property DefaultFormControlsBackColor As Color = Color.White
    Public Property DefaultFormControlsForeColor As Color = Color.Black
    Public Property DefaultFormControlsReadOnlyBackColor As Color = Color.White
    Public Property DefaultFormControlsReadOnlyForeColor As Color = Color.Gray
    Public Property AllControls As New List(Of Control)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        KeyPreview = False
    End Sub

    Public Property MenuFormName As String

    Public Property ViewDisplayName As String

    Private Sub CForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AllControls = GlobalFunctions.FindControlRecursive(AllControls, Me)
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
            If GlobalVariables.RightToLeftLayout Then
                LayoutControls(AllControls)
            Else
                'RightToLeftLayout = False
                'RightToLeft = RightToLeft.No
            End If
        End If
    End Sub

    Private Sub LayoutControls(allControls As List(Of Control))
        For Each cCtrl As Control In allControls
            If TypeOf cCtrl Is CButton OrElse TypeOf cCtrl Is Button Then
                If GetPropertyValue(cCtrl, "Image") IsNot Nothing Then
                    Dim btnImageName As String
                    btnImageName = (cCtrl.Name.ToString() + "_" + Strings.Left(CultureInfo.CurrentCulture.Name, 2)).ToLower()
                    Dim resource As Object = My.Resources.ResourceManager.GetObject(btnImageName)
                    If Not (resource Is Nothing) Then
                        Dim i = CType(cCtrl, CButton)
                        i.Image = DirectCast(resource, Image)
                    End If
                End If
            ElseIf TypeOf cCtrl Is CTabControl OrElse TypeOf cCtrl Is TabControl Then
                Dim c = CType(cCtrl, CTabControl)
                c.RightToLeftLayout = True
                c.RightToLeft = RightToLeft.No
            End If
        Next cCtrl
    End Sub

    ' The form will handle all key events before the control With
    ' focus handles them
    Private Sub CForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            e.Handled = True
            ProcessTabKey(True)
        End If
    End Sub

    Protected Sub SelectAllText()
        If ActiveControl.[GetType]() = GetType(TextBox) OrElse ActiveControl.[GetType]() = GetType(CTextBox) Then
            Dim textBox As TextBox = CType(ActiveControl, TextBox)
            textBox.SelectAll()
        End If
    End Sub

    Protected Sub CutText()
        If ActiveControl.[GetType]() = GetType(TextBox) OrElse ActiveControl.[GetType]() = GetType(CTextBox) Then
            Dim textBox As TextBox = CType(ActiveControl, TextBox)
            textBox.Cut()
        End If
    End Sub

    Protected Sub CopyText()
        Dim textBox = TryCast(ActiveControl, TextBox)
        If textBox IsNot Nothing Then
            textBox.Copy()
        Else
            Dim comboBox = TryCast(ActiveControl, ComboBox)
            If comboBox IsNot Nothing Then
                Clipboard.SetText(comboBox.Text)
            End If
        End If
    End Sub

    Protected Sub PasteText()
        If ActiveControl.[GetType]() = GetType(TextBox) OrElse ActiveControl.[GetType]() = GetType(CTextBox) Then
            Dim textBox As TextBox = CType(ActiveControl, TextBox)
            textBox.Paste()
        End If
    End Sub

End Class
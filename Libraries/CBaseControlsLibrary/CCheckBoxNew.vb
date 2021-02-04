Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CCheckBoxNew
    Inherits CheckBox
    Implements IEntryControl

    Private _displayOnly As Boolean
    Private _editingMode As Boolean = True
    Private _noLabel As Boolean
    Private _oldValue As String

    Public Sub New()
        MyBase.New()
        Appearance = Appearance.Normal
        UseVisualStyleBackColor = True
        FlatStyle = FlatStyle.Flat
        TextAlign = ContentAlignment.MiddleRight
        BackColor = System.Drawing.Color.Transparent
        Size = New Size(24, 24)
        Margin = New Padding(1)
        FlatAppearance.BorderSize = 0
        NoLabel = True
        Text = ""
    End Sub

    <Bindable(True)>
    <Category("Custom Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is read only.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set(value As Boolean)
            'If _displayOnly = value Then Exit Property
            _displayOnly = value
            If value Then
                Me.Enabled = False
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                'BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            Else
                Me.Enabled = True
                ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                'BackColor = GlobalVariables.DefaultFormControlBackgroundColor
            End If
        End Set
    End Property

    <Bindable(True)>
    <Category("Custom Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this checkbox has no label.")>
    <Browsable(True)>
    Public Property NoLabel As Boolean
        Get
            Return _noLabel
        End Get
        Set(value As Boolean)
            If value Then
                Me.Text = " "
            End If
            _noLabel = value
        End Set
    End Property

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
            If value Then
                If DisplayOnly Then
                    AutoCheck = False
                    ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                    'BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                Else
                    AutoCheck = True
                    ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                    'BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                End If
            Else
                AutoCheck = False
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                'BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            End If
        End Set
    End Property

    'End Sub
    <Category("Custom Properties")>
    <Description("Select the label to which this control is linked.")>
    <Browsable(True)>
    Public Property LinkedLabel As CLabel

    '    If Checked Then
    '        e.Graphics.FillRectangle(New SolidBrush(_checkRegionColor), checkRegion)
    '    End If
    Public Property OldValue() As String
        Get
            Return _oldValue
        End Get
        Set(ByVal value As String)
            _oldValue = value
        End Set
    End Property

    Public ReadOnly Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
    End Property

    '    MyBase.OnPaint(e)
    Public Sub EnterHandler(sender As Object, e As EventArgs) Handles MyBase.Enter
        _oldValue = Text
        If EditingMode And Not DisplayOnly Then
            ForeColor = GlobalVariables.DefaultFormControlEditingForegroundColor
            'BackColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
        Else
            ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            'BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
        End If
    End Sub

    'Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    '    Dim checkRegion As New Rectangle(2, 3, 9, 9)
    Public Sub LeaveHandler(sender As Object, e As EventArgs) Handles MyBase.Leave
        If EditingMode And Not DisplayOnly Then
            ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            ' BackColor = GlobalVariables.DefaultFormControlBackgroundColor
        Else
            ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            'BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
        End If
    End Sub

    Public Sub OnKeyDownPressed(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.SendWait("{TAB}")
        End If
    End Sub

    'Private ReadOnly _checkRegionColor As Color = Color.Coral
    'Public Sub MakeEditable(editableControl As Boolean) Implements IEntryControl.MakeEditable
    '    EditingMode = Not editableControl
    'End Sub

    'Public Sub MakeVisible(visibleControl As Boolean) Implements IEntryControl.MakeVisible
    '    Visible = visibleControl
    'End Sub
    'Public Sub MakeViewable(ViewableControl As Boolean) Implements IEntryControl.MakeViewable
    '    Throw New NotImplementedException()
    'End Sub

    'Public Sub MakeSelectable(selectableControl As Boolean) Implements IEntryControl.MakeSelectable
    '    Throw New NotImplementedException()
    'End Sub
End Class
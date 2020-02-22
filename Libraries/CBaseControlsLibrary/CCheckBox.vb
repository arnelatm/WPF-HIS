Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CCheckBox
    Inherits CheckBox
    Implements IEntryControl

    Private _editingMode As Boolean = False

    Public Sub New()
        MyBase.New()
        Text = ""
        Width = 200
        Margin = New Padding(1)
        UseVisualStyleBackColor = True

        Appearance = Appearance.Button
        FlatStyle = FlatStyle.Flat
        TextAlign = ContentAlignment.MiddleRight
        FlatAppearance.BorderSize = 0
        AutoSize = False
    End Sub

    Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
        pevent.Graphics.Clear(BackColor)

        Using brush As SolidBrush = New SolidBrush(ForeColor)
            pevent.Graphics.DrawString(Text, Font, brush, 27, 4)
        End Using

        Dim pt As Point = New Point(0, 0)
        Dim rect As Rectangle = New Rectangle(pt, New Size(22, 20))
        pevent.Graphics.FillRectangle(Brushes.White, rect)

        If Checked Then
            Dim cCol As Color
            If _editingMode Then
                cCol = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            Else
                cCol = GlobalVariables.DefaultFormControlForegroundColor
            End If
            Using brush As SolidBrush = New SolidBrush(cCol)

                Using wing As Font = New Font("Wingdings", 12.0F)
                    pevent.Graphics.DrawString("ü", wing, brush, 1, 2)
                End Using
            End Using
        End If

        pevent.Graphics.DrawRectangle(Pens.Gray, rect)
        Dim fRect As Rectangle = ClientRectangle

        If Focused Then
            fRect.Inflate(-1, -1)

            Using pen As Pen = New Pen(Brushes.Gray) With {
                .DashStyle = DashStyle.Dot
                }
                pevent.Graphics.DrawRectangle(pen, fRect)
            End Using
        End If
    End Sub

    'Private ReadOnly _checkRegionColor As Color = Color.Coral

    'Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    '    Dim checkRegion As New Rectangle(2, 3, 9, 9)

    '    MyBase.OnPaint(e)

    '    If Checked Then
    '        e.Graphics.FillRectangle(New SolidBrush(_checkRegionColor), checkRegion)
    '    End If

    'End Sub

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is read only.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean

    <Category("Custom Properties")>
    <Description("Select the label to which this control is linked.")>
    <Browsable(True)>
    Public Property LinkedLabel As CLabel

    Public Sub EnterHandler(sender As Object, e As EventArgs) Handles MyBase.Enter
        If Not DisplayOnly Then
            If Not _editingMode Then
                ForeColor = GlobalVariables.DefaultFormControlEditingForegroundColor
                BackColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
            End If
        End If
    End Sub

    Public Sub LeaveHandler(sender As Object, e As EventArgs) Handles MyBase.Leave
        If Not DisplayOnly Then
            If Not _editingMode Then
                ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                BackColor = GlobalVariables.DefaultFormControlBackgroundColor
            End If
        End If
    End Sub

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
            If value Or DisplayOnly Then
                AutoCheck = False
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                Enabled = False
            Else
                AutoCheck = True
                ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                Enabled = True
            End If
        End Set
    End Property

    Public ReadOnly Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
    End Property

    'Public Sub MakeEditable(editableControl As Boolean) Implements IEntryControl.MakeEditable
    '    EditingMode = Not editableControl
    'End Sub

    'Public Sub MakeVisible(visibleControl As Boolean) Implements IEntryControl.MakeVisible
    '    Visible = visibleControl
    'End Sub

    Public Sub OnKeyDownPressed(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.SendWait("{TAB}")
        End If
    End Sub

    'Public Sub MakeViewable(ViewableControl As Boolean) Implements IEntryControl.MakeViewable
    '    Throw New NotImplementedException()
    'End Sub

    'Public Sub MakeSelectable(selectableControl As Boolean) Implements IEntryControl.MakeSelectable
    '    Throw New NotImplementedException()
    'End Sub
End Class
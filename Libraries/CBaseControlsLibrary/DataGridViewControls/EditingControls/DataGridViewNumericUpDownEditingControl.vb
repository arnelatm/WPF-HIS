Imports System.Drawing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

''' <summary>
''' Defines the editing control for the DataGridViewNumericUpDownCell custom cell type.
''' </summary>
Class DataGridViewNumericUpDownEditingControl
    Inherits NumericUpDown
    Implements IDataGridViewEditingControl

    ''' <summary>
    ''' Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.  To send a message and return immediately, use the SendMessageCallback or SendNotifyMessage function. To post a message to a thread's message queue and return immediately, use the PostMessage or PostThreadMessage function.
    ''' </summary>
    ''' <param name="hWnd">[in] Handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.  Microsoft Windows Vista and later. Message sending is subject to User Interface Privilege Isolation (UIPI). The thread of a process can send messages only to message queues of threads in processes of lesser or equal integrity level.</param>
    ''' <param name="Msg">[in] Specifies the message to be sent.</param>
    ''' <param name="wParam">[in] Specifies additional message-specific information.</param>
    ''' <param name="lParam">[in] Specifies additional message-specific information.</param>
    ''' <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
    ''' <remarks>Microsoft Windows Vista and later. When a message is blocked by UIPI the last error, retrieved with GetLastError, is set to 5 (access denied).  Applications that need to communicate using HWND_BROADCAST should use the RegisterWindowMessage function to obtain a unique message for inter-application communication.  The system only does marshalling for system messages (those in the range 0 to (WM_USER-1)). To send other messages (those >= WM_USER) to another process, you must do custom marshalling.  If the specified window was created by the calling thread, the window procedure is called immediately as a subroutine. If the specified window was created by a different thread, the system switches to that thread and calls the appropriate window procedure. Messages sent between threads are processed only when the receiving thread executes message retrieval code. The sending thread is blocked until the receiving thread processes the message. However, the sending thread will process incoming nonqueued messages while waiting for its message to be processed. To prevent this, use SendMessageTimeout with SMTO_BLOCK set. For more information on nonqueued messages, see Nonqueued Messages.  Windows 95/98/Me: SendMessageW is supported by the Microsoft Layer for Unicode (MSLU). To use this, you must add certain files to your application, as outlined in Microsoft Layer for Unicode on Windows 95/98/Me Systems.</remarks>
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    ' The grid that owns this editing control
    Private dataGridView As DataGridView
    ' Stores whether the editing control's value has changed or not
    Private _valueChanged As Boolean
    ' Stores the row index in which the editing control resides
    Private rowIndex As Integer

    ''' <summary>
    ''' Constructor of the editing control class
    ''' </summary>
    Public Sub New()
        ' The editing control must not be part of the tabbing loop
        Me.TabStop = False
        Me.TextAlign = HorizontalAlignment.Right
    End Sub

    ' Beginning of the IDataGridViewEditingControl interface implementation

    ''' <summary>
    ''' Property which caches the grid that uses this editing control
    ''' </summary>
    Public Overridable Property EditingControlDataGridView() As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return Me.dataGridView
        End Get
        Set(ByVal value As DataGridView)
            Me.dataGridView = value
        End Set
    End Property

    ''' <summary>
    ''' Property which represents the current formatted value of the editing control
    ''' </summary>
    Public Overridable Property EditingControlFormattedValue() As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting)
        End Get
        Set(ByVal value As Object)
            Me.Text = DirectCast(value, String)
        End Set
    End Property

    ''' <summary>
    ''' Property which represents the row in which the editing control resides
    ''' </summary>
    Public Overridable Property EditingControlRowIndex() As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return Me.rowIndex
        End Get
        Set(ByVal value As Integer)
            Me.rowIndex = value
        End Set
    End Property

    ''' <summary>
    ''' Property which indicates whether the value of the editing control has changed or not
    ''' </summary>
    Public Overridable Property EditingControlValueChanged() As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return Me._valueChanged
        End Get
        Set(ByVal value As Boolean)
            Me._valueChanged = value
        End Set
    End Property

    ''' <summary>
    ''' Property which determines which cursor must be used for the editing panel,
    ''' i.e. the parent of the editing control.
    ''' </summary>
    Public Overridable ReadOnly Property EditingPanelCursor() As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return Cursors.[Default]
        End Get
    End Property

    ''' <summary>
    ''' Property which indicates whether the editing control needs to be repositioned 
    ''' when its value changes.
    ''' </summary>
    Public Overridable ReadOnly Property RepositionEditingControlOnValueChange() As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    ''' <summary>
    ''' Method called by the grid before the editing control is shown so it can adapt to the 
    ''' provided cell style.
    ''' </summary>
    Public Overridable Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Me.Font = dataGridViewCellStyle.Font
        If dataGridViewCellStyle.BackColor.A < 255 Then
            ' The NumericUpDown control does not support transparent back colors
            Dim opaqueBackColor As Color = Color.FromArgb(255, dataGridViewCellStyle.BackColor)
            Me.BackColor = opaqueBackColor
            Me.dataGridView.EditingPanel.BackColor = opaqueBackColor
        Else
            Me.BackColor = dataGridViewCellStyle.BackColor
        End If
        Me.ForeColor = dataGridViewCellStyle.ForeColor
        Me.TextAlign = DataGridViewNumericUpDownCell.TranslateAlignment(dataGridViewCellStyle.Alignment)
    End Sub

    ''' <summary>
    ''' Method called by the grid on keystrokes to determine if the editing control is
    ''' interested in the key or not.
    ''' </summary>
    Public Overridable Function EditingControlWantsInputKey(ByVal keyData As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        Select Case keyData And Keys.KeyCode
            Case Keys.Right
                If True Then
                    Dim textBox As TextBox = TryCast(Me.Controls(1), TextBox)
                    If textBox IsNot Nothing Then
                        ' If the end of the selection is at the end of the string,
                        ' let the DataGridView treat the key message
                        If (Me.RightToLeft = RightToLeft.No AndAlso Not (textBox.SelectionLength = 0 AndAlso textBox.SelectionStart = textBox.Text.Length)) OrElse (Me.RightToLeft = RightToLeft.Yes AndAlso Not (textBox.SelectionLength = 0 AndAlso textBox.SelectionStart = 0)) Then
                            Return True
                        End If
                    End If
                    Exit Select
                End If

            Case Keys.Left
                If True Then
                    Dim textBox As TextBox = TryCast(Me.Controls(1), TextBox)
                    If textBox IsNot Nothing Then
                        ' If the end of the selection is at the begining of the string
                        ' or if the entire text is selected and we did not start editing,
                        ' send this character to the dataGridView, else process the key message
                        If (Me.RightToLeft = RightToLeft.No AndAlso Not (textBox.SelectionLength = 0 AndAlso textBox.SelectionStart = 0)) OrElse (Me.RightToLeft = RightToLeft.Yes AndAlso Not (textBox.SelectionLength = 0 AndAlso textBox.SelectionStart = textBox.Text.Length)) Then
                            Return True
                        End If
                    End If
                    Exit Select
                End If

            Case Keys.Down
                ' If the current value hasn't reached its minimum yet, handle the key. Otherwise let
                ' the grid handle it.
                If Me.Value > Me.Minimum Then
                    Return True
                End If
                Exit Select

            Case Keys.Up
                ' If the current value hasn't reached its maximum yet, handle the key. Otherwise let
                ' the grid handle it.
                If Me.Value < Me.Maximum Then
                    Return True
                End If
                Exit Select

            Case Keys.Home, Keys.[End]
                If True Then
                    ' Let the grid handle the key if the entire text is selected.
                    Dim textBox As TextBox = TryCast(Me.Controls(1), TextBox)
                    If textBox IsNot Nothing Then
                        If textBox.SelectionLength <> textBox.Text.Length Then
                            Return True
                        End If
                    End If
                    Exit Select
                End If

            Case Keys.Delete
                If True Then
                    ' Let the grid handle the key if the carret is at the end of the text.
                    Dim textBox As TextBox = TryCast(Me.Controls(1), TextBox)
                    If textBox IsNot Nothing Then
                        If textBox.SelectionLength > 0 OrElse textBox.SelectionStart < textBox.Text.Length Then
                            Return True
                        End If
                    End If
                    Exit Select
                End If
        End Select
        Return Not dataGridViewWantsInputKey
    End Function

    ''' <summary>
    ''' Returns the current value of the editing control.
    ''' </summary>
    Public Overridable Function GetEditingControlFormattedValue(ByVal context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        Dim userEdit As Boolean = Me.UserEdit
        Try
            ' Prevent the Value from being set to Maximum or Minimum when the cell is being painted.
            Me.UserEdit = (context And DataGridViewDataErrorContexts.Display) = 0
            Return Me.Value.ToString((If(Me.ThousandsSeparator, "N", "F")) + Me.DecimalPlaces.ToString())
        Finally
            Me.UserEdit = userEdit
        End Try
    End Function

    ''' <summary>
    ''' Called by the grid to give the editing control a chance to prepare itself for
    ''' the editing session.
    ''' </summary>
    Public Overridable Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        Dim textBox As TextBox = TryCast(Me.Controls(1), TextBox)
        textBox.TextAlign = HorizontalAlignment.Right
        If textBox IsNot Nothing Then
            If selectAll Then
                textBox.SelectAll()
            Else
                ' Do not select all the text, but
                ' position the caret at the end of the text
                textBox.SelectionStart = textBox.Text.Length
            End If
        End If
    End Sub

    ' End of the IDataGridViewEditingControl interface implementation

    ''' <summary>
    ''' Small utility function that updates the local dirty state and 
    ''' notifies the grid of the value change.
    ''' </summary>
    Private Sub NotifyDataGridViewOfValueChange()
        If Not Me._valueChanged Then
            Me._valueChanged = True
            Me.dataGridView.NotifyCurrentCellDirty(True)
        End If
    End Sub

    ''' <summary>
    ''' Listen to the KeyPress notification to know when the value changed, and 
    ''' notify the grid of the change.
    ''' </summary>
    Protected Overloads Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
        MyBase.OnKeyPress(e)

        ' The value changes when a digit, the decimal separator, the group separator or
        ' the negative sign is pressed.
        Dim notifyValueChange As Boolean = False
        If Char.IsDigit(e.KeyChar) Then
            notifyValueChange = True
        Else
            Dim numberFormatInfo As System.Globalization.NumberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat
            Dim decimalSeparatorStr As String = numberFormatInfo.NumberDecimalSeparator
            Dim groupSeparatorStr As String = numberFormatInfo.NumberGroupSeparator
            Dim negativeSignStr As String = numberFormatInfo.NegativeSign
            If Not String.IsNullOrEmpty(decimalSeparatorStr) AndAlso decimalSeparatorStr.Length = 1 Then
                notifyValueChange = decimalSeparatorStr(0) = e.KeyChar
            End If
            If Not notifyValueChange AndAlso Not String.IsNullOrEmpty(groupSeparatorStr) AndAlso groupSeparatorStr.Length = 1 Then
                notifyValueChange = groupSeparatorStr(0) = e.KeyChar
            End If
            If Not notifyValueChange AndAlso Not String.IsNullOrEmpty(negativeSignStr) AndAlso negativeSignStr.Length = 1 Then
                notifyValueChange = negativeSignStr(0) = e.KeyChar
            End If
        End If

        If notifyValueChange Then
            ' Let the DataGridView know about the value change
            NotifyDataGridViewOfValueChange()
        End If
    End Sub

    ''' <summary>
    ''' Listen to the ValueChanged notification to forward the change to the grid.
    ''' </summary>
    Protected Overloads Overrides Sub OnValueChanged(ByVal e As EventArgs)
        MyBase.OnValueChanged(e)
        If Me.Focused Then
            ' Let the DataGridView know about the value change
            NotifyDataGridViewOfValueChange()
        End If
    End Sub

    ''' <summary>
    ''' A few keyboard messages need to be forwarded to the inner textbox of the
    ''' NumericUpDown control so that the first character pressed appears in it.
    ''' </summary>
    Protected Overloads Overrides Function ProcessKeyEventArgs(ByRef m As Message) As Boolean
        Dim textBox As TextBox = TryCast(Me.Controls(1), TextBox)
        If textBox IsNot Nothing Then
            SendMessage(textBox.Handle, m.Msg, m.WParam, m.LParam)
            Return True
        Else
            Return MyBase.ProcessKeyEventArgs(m)
        End If
    End Function
End Class
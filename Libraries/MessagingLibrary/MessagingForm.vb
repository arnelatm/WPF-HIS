Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.Linq
Imports System.Windows.Forms

Public Class FlexibleMessageBox

    '<summary>
    '    Defines the maximum width for all FlexibleMessageBox instances in percent of the working area.

    '    Allowed values are 0.2 - 1.0 where:
    '    0.2 means:  The FlexibleMessageBox can be at most half as wide as the working area.
    '    1.0 means:  The FlexibleMessageBox can be as wide as the working area.

    '    Default is: 70% of the working area width.
    '</summary>
    Public Shared MaxWidthFactor As Double = 0.7

    '<summary>
    '    Defines the maximum height for all FlexibleMessageBox instances in percent of the working area.

    '    Allowed values are 0.2 - 1.0 where:
    '    0.2 means:  The FlexibleMessageBox can be at most half as high as the working area.
    '    1.0 means:  The FlexibleMessageBox can be as high as the working area.

    '    Default is: 90% of the working area height.
    '</summary>
    Public Shared MaxHeightFactor As Double = 0.9

    ' <summary>
    '     Defines the font for all FlexibleMessageBox instances.
    '
    '     Default is: SystemFonts.MessageBoxFont
    ' </summary>
    Public Shared DesiredFont As Font = SystemFonts.MessageBoxFont

    '<summary>
    '    Shows the specified message box.
    '    </summary>
    '<param name="text">The text.</param>
    '<returns>The dialog result.</returns>
    Public Shared Function Show(ByVal text As String) As DialogResult
        Return FlexibleMessageBoxForm.Show(Nothing, text, String.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1)
    End Function

    ' <summary>
    '     Shows the specified message box.
    '     </summary>
    ' <param name="owner">The owner.</param>
    ' <param name="text">The text.</param>
    ' <returns>The dialog result.</returns>
    Public Shared Function Show(ByVal owner As IWin32Window, ByVal text As String) As DialogResult
        Return FlexibleMessageBoxForm.Show(owner, text, String.Empty, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1)
    End Function

    ' <summary>
    '     Shows the specified message box.
    '     </summary>
    ' <param name="text">The text.</param>
    ' <param name="caption">The caption.</param>
    ' <returns>The dialog result.</returns>
    Public Shared Function Show(ByVal text As String, ByVal caption As String) As DialogResult
        Return FlexibleMessageBoxForm.Show(Nothing, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1)
    End Function

    ' <summary>
    '     Shows the specified message box.
    '     </summary>
    ' <param name="owner">The owner.</param>
    ' <param name="text">The text.</param>
    ' <param name="caption">The caption.</param>
    ' <returns>The dialog result.</returns>
    Public Shared Function Show(ByVal owner As IWin32Window, ByVal text As String, ByVal caption As String) As DialogResult
        Return FlexibleMessageBoxForm.Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1)
    End Function

    ' <summary>
    '     Shows the specified message box.
    '     </summary>
    ' <param name="text">The text.</param>
    ' <param name="caption">The caption.</param>
    ' <param name="buttons">The buttons.</param>
    ' <returns>The dialog result.</returns>

    Public Shared Function Show(ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons) As DialogResult
        Return FlexibleMessageBoxForm.Show(Nothing, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1)
    End Function

    '<summary>
    '    Shows the specified message box.
    '    </summary>
    '<param name="owner">The owner.</param>
    '<param name="text">The text.</param>
    '<param name="caption">The caption.</param>
    '<param name="buttons">The buttons.</param>
    '<returns>The dialog result.</returns>
    Public Shared Function Show(ByVal owner As IWin32Window, ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons) As DialogResult
        Return FlexibleMessageBoxForm.Show(owner, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1)
    End Function

    ' <summary>
    '     Shows the specified message box.
    '     </summary>
    ' <param name="text">The text.</param>
    ' <param name="caption">The caption.</param>
    ' <param name="buttons">The buttons.</param>
    ' <param name="icon">The icon.</param>
    ' <returns></returns>
    Public Shared Function Show(ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon) As DialogResult
        Return FlexibleMessageBoxForm.Show(Nothing, text, caption, buttons, icon, MessageBoxDefaultButton.Button1)
    End Function

    ' <summary>
    '     Shows the specified message box.
    '     </summary>
    ' <param name="owner">The owner.</param>
    ' <param name="text">The text.</param>
    ' <param name="caption">The caption.</param>
    ' <param name="buttons">The buttons.</param>
    ' <param name="icon">The icon.</param>
    ' <returns>The dialog result.</returns>
    Public Shared Function Show(ByVal owner As IWin32Window, ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon) As DialogResult
        Return FlexibleMessageBoxForm.Show(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1)
    End Function

    '<summary>
    '    Shows the specified message box.
    '    </summary>
    '<param name="text">The text.</param>
    '<param name="caption">The caption.</param>
    '<param name="buttons">The buttons.</param>
    '<param name="icon">The icon.</param>
    '<param name="defaultButton">The default button.</param>
    '<returns>The dialog result.</returns>
    Public Shared Function Show(ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
        Return FlexibleMessageBoxForm.Show(Nothing, text, caption, buttons, icon, defaultButton)
    End Function

    ' <summary>
    '     Shows the specified message box.
    '     </summary>
    ' <param name="owner">The owner.</param>
    ' <param name="text">The text.</param>
    ' <param name="caption">The caption.</param>
    ' <param name="buttons">The buttons.</param>
    ' <param name="icon">The icon.</param>
    ' <param name="defaultButton">The default button.</param>
    ' <returns>The dialog result.</returns>
    Public Shared Function Show(ByVal owner As IWin32Window, ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
        Return FlexibleMessageBoxForm.Show(owner, text, caption, buttons, icon, defaultButton)
    End Function

    ' <summary>
    '     The form to show the customized message box.
    '     It is defined as an internal class to keep the public interface of the FlexibleMessageBox clean.
    ' </summary>
    Class FlexibleMessageBoxForm
        Inherits Form

        Private components As IContainer = Nothing

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            components = New Container()
            button1 = New Button()
            Me.richTextBoxMessage = New RichTextBox()
            Me.FlexibleMessageBoxFormBindingSource = New BindingSource(Me.components)
            Me.panel1 = New Panel()
            Me.pictureBoxForIcon = New PictureBox()
            Me.button2 = New Button()
            Me.button3 = New Button()
            CType((Me.FlexibleMessageBoxFormBindingSource), ISupportInitialize).BeginInit()
            Me.panel1.SuspendLayout()
            CType((Me.pictureBoxForIcon), ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            Me.button1.Anchor = (CType(((AnchorStyles.Bottom Or AnchorStyles.Right)), AnchorStyles))
            Me.button1.AutoSize = True
            Me.button1.DialogResult = DialogResult.OK
            Me.button1.Location = New Point(11, 67)
            Me.button1.MinimumSize = New Size(0, 24)
            Me.button1.Name = "button1"
            Me.button1.Size = New Size(75, 24)
            Me.button1.TabIndex = 2
            Me.button1.Text = "OK"
            Me.button1.UseVisualStyleBackColor = True
            Me.button1.Visible = False
            Me.richTextBoxMessage.Anchor = (CType(((((AnchorStyles.Top Or AnchorStyles.Bottom) Or AnchorStyles.Left) Or AnchorStyles.Right)), AnchorStyles))
            Me.richTextBoxMessage.BackColor = Color.White
            Me.richTextBoxMessage.BorderStyle = BorderStyle.None
            Me.richTextBoxMessage.DataBindings.Add(New Binding("Text", Me.FlexibleMessageBoxFormBindingSource, "MessageText", True, DataSourceUpdateMode.OnPropertyChanged))
            Me.richTextBoxMessage.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Regular, GraphicsUnit.Point, (CByte((0))))
            Me.richTextBoxMessage.Location = New Point(50, 26)
            Me.richTextBoxMessage.Margin = New Padding(0)
            Me.richTextBoxMessage.Name = "richTextBoxMessage"
            Me.richTextBoxMessage.[ReadOnly] = True
            Me.richTextBoxMessage.ScrollBars = RichTextBoxScrollBars.Vertical
            Me.richTextBoxMessage.Size = New Size(200, 20)
            Me.richTextBoxMessage.TabIndex = 0
            Me.richTextBoxMessage.TabStop = False
            Me.richTextBoxMessage.Text = "<Message>"
            AddHandler Me.richTextBoxMessage.LinkClicked, AddressOf Me.richTextBoxMessage_LinkClicked
            Me.panel1.Anchor = (CType(((((AnchorStyles.Top Or AnchorStyles.Bottom) Or AnchorStyles.Left) Or AnchorStyles.Right)), AnchorStyles))
            Me.panel1.BackColor = Color.White
            Me.panel1.Controls.Add(Me.pictureBoxForIcon)
            Me.panel1.Controls.Add(Me.richTextBoxMessage)
            Me.panel1.Location = New Point(-3, -4)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New Size(268, 59)
            Me.panel1.TabIndex = 1
            Me.pictureBoxForIcon.BackColor = Color.Transparent
            Me.pictureBoxForIcon.Location = New Point(15, 19)
            Me.pictureBoxForIcon.Name = "pictureBoxForIcon"
            Me.pictureBoxForIcon.Size = New Size(32, 32)
            Me.pictureBoxForIcon.TabIndex = 8
            Me.pictureBoxForIcon.TabStop = False
            Me.button2.Anchor = (CType(((AnchorStyles.Bottom Or AnchorStyles.Right)), AnchorStyles))
            Me.button2.DialogResult = DialogResult.OK
            Me.button2.Location = New Point(92, 67)
            Me.button2.MinimumSize = New Size(0, 24)
            Me.button2.Name = "button2"
            Me.button2.Size = New Size(75, 24)
            Me.button2.TabIndex = 3
            Me.button2.Text = "OK"
            Me.button2.UseVisualStyleBackColor = True
            Me.button2.Visible = False
            Me.button3.Anchor = (CType(((AnchorStyles.Bottom Or AnchorStyles.Right)), AnchorStyles))
            Me.button3.AutoSize = True
            Me.button3.DialogResult = DialogResult.OK
            Me.button3.Location = New Point(173, 67)
            Me.button3.MinimumSize = New Size(0, 24)
            Me.button3.Name = "button3"
            Me.button3.Size = New Size(75, 24)
            Me.button3.TabIndex = 0
            Me.button3.Text = "OK"
            Me.button3.UseVisualStyleBackColor = True
            Me.button3.Visible = False
            Me.AutoScaleDimensions = New SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.ClientSize = New Size(260, 102)
            Me.Controls.Add(Me.button3)
            Me.Controls.Add(Me.button2)
            Me.Controls.Add(Me.panel1)
            Me.Controls.Add(Me.button1)
            Me.DataBindings.Add(New Binding("Text", Me.FlexibleMessageBoxFormBindingSource, "CaptionText", True))
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.MinimumSize = New Size(276, 140)
            Me.Name = "FlexibleMessageBoxForm"
            Me.ShowIcon = False
            Me.SizeGripStyle = SizeGripStyle.Show
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Text = "<Caption>"
            AddHandler Me.Shown, New EventHandler(AddressOf Me.FlexibleMessageBoxForm_Shown)
            CType((Me.FlexibleMessageBoxFormBindingSource), ISupportInitialize).EndInit()
            Me.panel1.ResumeLayout(False)
            CType((Me.pictureBoxForIcon), ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Private button1 As Button
        Private FlexibleMessageBoxFormBindingSource As BindingSource
        Private richTextBoxMessage As RichTextBox
        Private panel1 As Panel
        Private pictureBoxForIcon As PictureBox
        Private button2 As Button
        Private button3 As Button
        Private Shared ReadOnly STANDARD_MESSAGEBOX_SEPARATOR_LINES As String = "---------------------------" & vbLf
        Private Shared ReadOnly STANDARD_MESSAGEBOX_SEPARATOR_SPACES As String = "   "

        Private Enum ButtonID
            OK = 0
            CANCEL
            YES
            NO
            ABORT
            RETRY
            IGNORE
        End Enum

        Private Enum TwoLetterISOLanguageID
            en
            de
            es
            it
        End Enum

        Private Shared ReadOnly BUTTON_TEXTS_ENGLISH_EN As String() = {"OK", "Cancel", "&Yes", "&No", "&Abort", "&Retry", "&Ignore"}
        Private Shared ReadOnly BUTTON_TEXTS_GERMAN_DE As String() = {"OK", "Abbrechen", "&Ja", "&Nein", "&Abbrechen", "&Wiederholen", "&Ignorieren"}
        Private Shared ReadOnly BUTTON_TEXTS_SPANISH_ES As String() = {"Aceptar", "Cancelar", "&Sí", "&No", "&Abortar", "&Reintentar", "&Ignorar"}
        Private Shared ReadOnly BUTTON_TEXTS_ITALIAN_IT As String() = {"OK", "Annulla", "&Sì", "&No", "&Interrompi", "&Riprova", "&Ignora"}
        Private defaultButton As MessageBoxDefaultButton
        Private visibleButtonsCount As Integer
        Private languageID As TwoLetterISOLanguageID = TwoLetterISOLanguageID.en

        Private Sub New()
            InitializeComponent()
            [Enum].TryParse(Of TwoLetterISOLanguageID)(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName, Me.languageID)
            Me.KeyPreview = True
            AddHandler Me.KeyUp, AddressOf FlexibleMessageBoxForm_KeyUp
        End Sub

        Private Shared Function GetStringRows(ByVal message As String) As String()
            If String.IsNullOrEmpty(message) Then Return Nothing
            Dim messageRows = message.Split(New Char() {vbLf}, StringSplitOptions.None)
            Return messageRows
        End Function

        Private Function GetButtonText(ByVal buttonID As ButtonID) As String
            Dim buttonTextArrayIndex = Convert.ToInt32(buttonID)

            Select Case Me.languageID
                Case TwoLetterISOLanguageID.de
                    Return BUTTON_TEXTS_GERMAN_DE(buttonTextArrayIndex)
                Case TwoLetterISOLanguageID.es
                    Return BUTTON_TEXTS_SPANISH_ES(buttonTextArrayIndex)
                Case TwoLetterISOLanguageID.it
                    Return BUTTON_TEXTS_ITALIAN_IT(buttonTextArrayIndex)
                Case Else
                    Return BUTTON_TEXTS_ENGLISH_EN(buttonTextArrayIndex)
            End Select
        End Function

        Private Shared Function GetCorrectedWorkingAreaFactor(ByVal workingAreaFactor As Double) As Double
            Const MIN_FACTOR As Double = 0.2
            Const MAX_FACTOR As Double = 1.0
            If workingAreaFactor < MIN_FACTOR Then Return MIN_FACTOR
            If workingAreaFactor > MAX_FACTOR Then Return MAX_FACTOR
            Return workingAreaFactor
        End Function

        Private Shared Sub SetDialogStartPosition(ByVal flexibleMessageBoxForm As FlexibleMessageBoxForm, ByVal owner As IWin32Window)
            If owner Is Nothing Then
                Dim screen = System.Windows.Forms.Screen.FromPoint(Cursor.Position)
                flexibleMessageBoxForm.StartPosition = FormStartPosition.Manual
                flexibleMessageBoxForm.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - flexibleMessageBoxForm.Width / 2
                flexibleMessageBoxForm.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - flexibleMessageBoxForm.Height / 2
            End If
        End Sub

        Private Shared Sub SetDialogSizes(ByVal flexibleMessageBoxForm As FlexibleMessageBoxForm, ByVal text As String, ByVal caption As String)
            flexibleMessageBoxForm.MaximumSize = New Size(Convert.ToInt32(SystemInformation.WorkingArea.Width * GetCorrectedWorkingAreaFactor(MaxWidthFactor)), Convert.ToInt32(SystemInformation.WorkingArea.Height * GetCorrectedWorkingAreaFactor(MaxHeightFactor)))
            Dim stringRows = GetStringRows(text)
            If stringRows Is Nothing Then Return
            Dim textHeight = TextRenderer.MeasureText(text, DesiredFont).Height
            Const SCROLLBAR_WIDTH_OFFSET As Integer = 15
            Dim longestTextRowWidth = stringRows.Max(Function(textForRow) TextRenderer.MeasureText(textForRow, DesiredFont).Width)
            Dim captionWidth = TextRenderer.MeasureText(caption, SystemFonts.CaptionFont).Width
            Dim textWidth = Math.Max(longestTextRowWidth + SCROLLBAR_WIDTH_OFFSET, captionWidth)
            Dim marginWidth = flexibleMessageBoxForm.Width - flexibleMessageBoxForm.richTextBoxMessage.Width
            Dim marginHeight = flexibleMessageBoxForm.Height - flexibleMessageBoxForm.richTextBoxMessage.Height
            flexibleMessageBoxForm.Size = New Size(textWidth + marginWidth, textHeight + marginHeight)
        End Sub

        Private Shared Sub SetDialogIcon(ByVal flexibleMessageBoxForm As FlexibleMessageBoxForm, ByVal icon As MessageBoxIcon)
            Select Case icon
                Case MessageBoxIcon.Information
                    flexibleMessageBoxForm.pictureBoxForIcon.Image = SystemIcons.Information.ToBitmap()
                Case MessageBoxIcon.Warning
                    flexibleMessageBoxForm.pictureBoxForIcon.Image = SystemIcons.Warning.ToBitmap()
                Case MessageBoxIcon.[Error]
                    flexibleMessageBoxForm.pictureBoxForIcon.Image = SystemIcons.[Error].ToBitmap()
                Case MessageBoxIcon.Question
                    flexibleMessageBoxForm.pictureBoxForIcon.Image = SystemIcons.Question.ToBitmap()
                Case Else
                    flexibleMessageBoxForm.pictureBoxForIcon.Visible = False
                    flexibleMessageBoxForm.richTextBoxMessage.Left -= flexibleMessageBoxForm.pictureBoxForIcon.Width
                    flexibleMessageBoxForm.richTextBoxMessage.Width += flexibleMessageBoxForm.pictureBoxForIcon.Width
            End Select
        End Sub

        Private Shared Sub SetDialogButtons(ByVal flexibleMessageBoxForm As FlexibleMessageBoxForm, ByVal buttons As MessageBoxButtons, ByVal defaultButton As MessageBoxDefaultButton)
            Select Case buttons
                Case MessageBoxButtons.AbortRetryIgnore
                    flexibleMessageBoxForm.visibleButtonsCount = 3
                    flexibleMessageBoxForm.button1.Visible = True
                    flexibleMessageBoxForm.button1.Text = flexibleMessageBoxForm.GetButtonText(ButtonID.ABORT)
                    flexibleMessageBoxForm.button1.DialogResult = DialogResult.Abort
                    flexibleMessageBoxForm.button2.Visible = True
                    flexibleMessageBoxForm.button2.Text = flexibleMessageBoxForm.GetButtonText(ButtonID.RETRY)
                    flexibleMessageBoxForm.button2.DialogResult = DialogResult.Retry
                    flexibleMessageBoxForm.button3.Visible = True
                    flexibleMessageBoxForm.button3.Text = flexibleMessageBoxForm.GetButtonText(ButtonID.IGNORE)
                    flexibleMessageBoxForm.button3.DialogResult = DialogResult.Ignore
                    flexibleMessageBoxForm.ControlBox = False
                Case MessageBoxButtons.OKCancel
                    flexibleMessageBoxForm.visibleButtonsCount = 2
                    flexibleMessageBoxForm.button2.Visible = True
                    flexibleMessageBoxForm.button2.Text = flexibleMessageBoxForm.GetButtonText(ButtonID.OK)
                    flexibleMessageBoxForm.button2.DialogResult = DialogResult.OK
                    flexibleMessageBoxForm.button3.Visible = True
                    flexibleMessageBoxForm.button3.Text = flexibleMessageBoxForm.GetButtonText(ButtonID.CANCEL)
                    flexibleMessageBoxForm.button3.DialogResult = DialogResult.Cancel
                    flexibleMessageBoxForm.CancelButton = flexibleMessageBoxForm.button3
                Case MessageBoxButtons.RetryCancel
                    flexibleMessageBoxForm.visibleButtonsCount = 2
                    flexibleMessageBoxForm.button2.Visible = True
                    flexibleMessageBoxForm.button2.Text = flexibleMessageBoxForm.GetButtonText(ButtonID.RETRY)
                    flexibleMessageBoxForm.button2.DialogResult = DialogResult.Retry
                    flexibleMessageBoxForm.button3.Visible = True
                    flexibleMessageBoxForm.button3.Text = flexibleMessageBoxForm.GetButtonText(ButtonID.CANCEL)
                    flexibleMessageBoxForm.button3.DialogResult = DialogResult.Cancel
                    flexibleMessageBoxForm.CancelButton = flexibleMessageBoxForm.button3
                Case MessageBoxButtons.YesNo
                    flexibleMessageBoxForm.visibleButtonsCount = 2
                    flexibleMessageBoxForm.button2.Visible = True
                    flexibleMessageBoxForm.button2.Text = flexibleMessageBoxForm.GetButtonText(ButtonID.YES)
                    flexibleMessageBoxForm.button2.DialogResult = DialogResult.Yes
                    flexibleMessageBoxForm.button3.Visible = True
                    flexibleMessageBoxForm.button3.Text = flexibleMessageBoxForm.GetButtonText(ButtonID.NO)
                    flexibleMessageBoxForm.button3.DialogResult = DialogResult.No
                    flexibleMessageBoxForm.ControlBox = False
                Case MessageBoxButtons.YesNoCancel
                    flexibleMessageBoxForm.visibleButtonsCount = 3
                    flexibleMessageBoxForm.button1.Visible = True
                    flexibleMessageBoxForm.button1.Text = flexibleMessageBoxForm.GetButtonText(ButtonID.YES)
                    flexibleMessageBoxForm.button1.DialogResult = DialogResult.Yes
                    flexibleMessageBoxForm.button2.Visible = True
                    flexibleMessageBoxForm.button2.Text = flexibleMessageBoxForm.GetButtonText(ButtonID.NO)
                    flexibleMessageBoxForm.button2.DialogResult = DialogResult.No
                    flexibleMessageBoxForm.button3.Visible = True
                    flexibleMessageBoxForm.button3.Text = flexibleMessageBoxForm.GetButtonText(ButtonID.CANCEL)
                    flexibleMessageBoxForm.button3.DialogResult = DialogResult.Cancel
                    flexibleMessageBoxForm.CancelButton = flexibleMessageBoxForm.button3
                Case Else
                    flexibleMessageBoxForm.visibleButtonsCount = 1
                    flexibleMessageBoxForm.button3.Visible = True
                    flexibleMessageBoxForm.button3.Text = flexibleMessageBoxForm.GetButtonText(ButtonID.OK)
                    flexibleMessageBoxForm.button3.DialogResult = DialogResult.OK
                    flexibleMessageBoxForm.CancelButton = flexibleMessageBoxForm.button3
            End Select

            flexibleMessageBoxForm.defaultButton = defaultButton
        End Sub

        Private Sub FlexibleMessageBoxForm_Shown(ByVal sender As Object, ByVal e As EventArgs)
            Dim buttonIndexToFocus As Integer = 1
            Dim buttonToFocus As Button

            Select Case Me.defaultButton
                Case MessageBoxDefaultButton.Button2
                    buttonIndexToFocus = 2
                Case MessageBoxDefaultButton.Button3
                    buttonIndexToFocus = 3
                Case Else
                    buttonIndexToFocus = 1
            End Select

            If buttonIndexToFocus > Me.visibleButtonsCount Then buttonIndexToFocus = Me.visibleButtonsCount

            If buttonIndexToFocus = 3 Then
                buttonToFocus = Me.button3
            ElseIf buttonIndexToFocus = 2 Then
                buttonToFocus = Me.button2
            Else
                buttonToFocus = Me.button1
            End If

            buttonToFocus.Focus()
        End Sub

        Private Sub richTextBoxMessage_LinkClicked(ByVal sender As Object, ByVal e As LinkClickedEventArgs)
            Try
                Cursor.Current = Cursors.WaitCursor
                Process.Start(e.LinkText)
            Catch __unusedException1__ As Exception
                Throw
            Finally
                Cursor.Current = Cursors.[Default]
            End Try
        End Sub

        Private Sub FlexibleMessageBoxForm_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
            If e.Control AndAlso (e.KeyCode = Keys.C OrElse e.KeyCode = Keys.Insert) Then
                Dim buttonsTextLine = (If(Me.button1.Visible, Me.button1.Text & STANDARD_MESSAGEBOX_SEPARATOR_SPACES, String.Empty)) + (If(Me.button2.Visible, Me.button2.Text & STANDARD_MESSAGEBOX_SEPARATOR_SPACES, String.Empty)) + (If(Me.button3.Visible, Me.button3.Text & STANDARD_MESSAGEBOX_SEPARATOR_SPACES, String.Empty))
                Dim textForClipboard = STANDARD_MESSAGEBOX_SEPARATOR_LINES & Me.Text & Environment.NewLine & STANDARD_MESSAGEBOX_SEPARATOR_LINES + Me.richTextBoxMessage.Text & Environment.NewLine & STANDARD_MESSAGEBOX_SEPARATOR_LINES + buttonsTextLine.Replace("&", String.Empty) & Environment.NewLine & STANDARD_MESSAGEBOX_SEPARATOR_LINES
                Clipboard.SetText(textForClipboard)
            End If
        End Sub

        Public Property CaptionText As String
        Public Property MessageText As String

        Public Shared Function Show(ByVal owner As IWin32Window, ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
            Dim flexibleMessageBoxForm = New FlexibleMessageBoxForm()
            flexibleMessageBoxForm.ShowInTaskbar = False
            flexibleMessageBoxForm.CaptionText = caption
            flexibleMessageBoxForm.MessageText = text
            flexibleMessageBoxForm.FlexibleMessageBoxFormBindingSource.DataSource = flexibleMessageBoxForm
            SetDialogButtons(flexibleMessageBoxForm, buttons, defaultButton)
            SetDialogIcon(flexibleMessageBoxForm, icon)
            flexibleMessageBoxForm.Font = DesiredFont
            flexibleMessageBoxForm.richTextBoxMessage.Font = DesiredFont
            SetDialogSizes(flexibleMessageBoxForm, text, caption)
            SetDialogStartPosition(flexibleMessageBoxForm, owner)
            Return flexibleMessageBoxForm.ShowDialog(owner)
        End Function

    End Class

End Class
Imports System.ComponentModel
Imports System.Globalization

'Imports AATM.Libraries.GlobalFuncNSub

Public Class MessagingForm

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
        Return FlexibleMessageBoxForm.Show(Nothing, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
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

        Protected Overrides Sub Dispose(ByVal lDisposing As Boolean)
            If lDisposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If

            MyBase.Dispose(lDisposing)
        End Sub

        Private Sub InitializeComponent()
            components = New Container()
            _button1 = New Button()
            _richTextBoxMessage = New RichTextBox()
            _flexibleMessageBoxFormBindingSource = New BindingSource(components)
            _panel1 = New Panel()
            _pictureBoxForIcon = New PictureBox()
            _button2 = New Button()
            _button3 = New Button()
            CType((_flexibleMessageBoxFormBindingSource), ISupportInitialize).BeginInit()
            _panel1.SuspendLayout()
            CType((_pictureBoxForIcon), ISupportInitialize).BeginInit()
            SuspendLayout()
            _button1.Anchor = (((AnchorStyles.Bottom Or AnchorStyles.Right)))
            _button1.AutoSize = True
            _button1.DialogResult = DialogResult.OK
            _button1.Location = New Point(11, 67)
            _button1.MinimumSize = New Size(0, 24)
            _button1.Name = "_button1"
            _button1.Size = New Size(75, 24)
            _button1.TabIndex = 2
            _button1.Text = $"OK"
            _button1.UseVisualStyleBackColor = True
            _button1.Visible = False
            _richTextBoxMessage.Anchor = ((AnchorStyles.Top Or AnchorStyles.Bottom) Or AnchorStyles.Left) Or AnchorStyles.Right
            _richTextBoxMessage.BackColor = Color.White
            _richTextBoxMessage.BorderStyle = BorderStyle.None
            _richTextBoxMessage.DataBindings.Add(New Binding("Text", _flexibleMessageBoxFormBindingSource, "MessageText", True, DataSourceUpdateMode.OnPropertyChanged))
            _richTextBoxMessage.Font = New Font("Microsoft Sans Serif", 9.0F, FontStyle.Regular, GraphicsUnit.Point, (CByte((0))))
            _richTextBoxMessage.Location = New Point(50, 26)
            _richTextBoxMessage.Margin = New Padding(0)
            _richTextBoxMessage.Name = "_richTextBoxMessage"
            _richTextBoxMessage.[ReadOnly] = True
            _richTextBoxMessage.ScrollBars = RichTextBoxScrollBars.Vertical
            _richTextBoxMessage.Size = New Size(200, 20)
            _richTextBoxMessage.TabIndex = 0
            _richTextBoxMessage.TabStop = False
            _richTextBoxMessage.Text = $"<Message>"
            AddHandler _richTextBoxMessage.LinkClicked, AddressOf richTextBoxMessage_LinkClicked
            _panel1.Anchor = ((AnchorStyles.Top Or AnchorStyles.Bottom) Or AnchorStyles.Left) Or AnchorStyles.Right
            _panel1.BackColor = Color.White
            _panel1.Controls.Add(_pictureBoxForIcon)
            _panel1.Controls.Add(_richTextBoxMessage)
            _panel1.Location = New Point(-3, -4)
            _panel1.Name = "_panel1"
            _panel1.Size = New Size(268, 59)
            _panel1.TabIndex = 1
            _pictureBoxForIcon.BackColor = Color.Transparent
            _pictureBoxForIcon.Location = New Point(15, 19)
            _pictureBoxForIcon.Name = "_pictureBoxForIcon"
            _pictureBoxForIcon.Size = New Size(32, 32)
            _pictureBoxForIcon.TabIndex = 8
            _pictureBoxForIcon.TabStop = False
            _button2.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
            _button2.DialogResult = DialogResult.OK
            _button2.Location = New Point(92, 67)
            _button2.MinimumSize = New Size(0, 24)
            _button2.Name = "_button2"
            _button2.Size = New Size(75, 24)
            _button2.TabIndex = 3
            _button2.Text = $"OK"
            _button2.UseVisualStyleBackColor = True
            _button2.Visible = False
            _button3.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
            _button3.AutoSize = True
            _button3.DialogResult = DialogResult.OK
            _button3.Location = New Point(173, 67)
            _button3.MinimumSize = New Size(0, 24)
            _button3.Name = "_button3"
            _button3.Size = New Size(75, 24)
            _button3.TabIndex = 0
            _button3.Text = $"OK"
            _button3.UseVisualStyleBackColor = True
            _button3.Visible = False
            AutoScaleDimensions = New SizeF(6.0F, 13.0F)
            AutoScaleMode = AutoScaleMode.Font
            ClientSize = New Size(260, 102)
            Controls.Add(_button3)
            Controls.Add(_button2)
            Controls.Add(_panel1)
            Controls.Add(_button1)
            DataBindings.Add(New Binding("Text", _flexibleMessageBoxFormBindingSource, "CaptionText", True))
            MaximizeBox = False
            MinimizeBox = False
            MinimumSize = New Size(276, 140)
            Name = "FlexibleMessageBoxForm"
            ShowIcon = False
            SizeGripStyle = SizeGripStyle.Show
            StartPosition = FormStartPosition.CenterParent
            Text = $"<Caption>"
            AddHandler Shown, New EventHandler(AddressOf FlexibleMessageBoxForm_Shown)
            CType((_flexibleMessageBoxFormBindingSource), ISupportInitialize).EndInit()
            _panel1.ResumeLayout(False)
            CType((_pictureBoxForIcon), ISupportInitialize).EndInit()
            ResumeLayout(False)
            PerformLayout()
        End Sub

        Private _button1 As Button
        Private _flexibleMessageBoxFormBindingSource As BindingSource
        Private _richTextBoxMessage As RichTextBox
        Private _panel1 As Panel
        Private _pictureBoxForIcon As PictureBox
        Private _button2 As Button
        Private _button3 As Button
        Private Shared ReadOnly STANDARD_MESSAGEBOX_SEPARATOR_LINES As String = "---------------------------" & vbLf
        Private Shared ReadOnly STANDARD_MESSAGEBOX_SEPARATOR_SPACES As String = "   "

        Private Enum ButtonId
            Ok = 0
            Cancel
            Yes
            No
            Abort
            Retry
            Ignore
        End Enum

        Private Enum TwoLetterIsoLanguageId
            En
            De
            Es
            It
            Ar
        End Enum

        Private Shared ReadOnly ButtonTextsEnglishEn As String() = {"Ok", "Cancel", "&Yes", "&No", "&Abort", "&Retry", "&Ignore"}
        Private Shared ReadOnly ButtonTextsGermanDe As String() = {"OK", "Abbrechen", "&Ja", "&Nein", "&Abbrechen", "&Wiederholen", "&Ignorieren"}
        Private Shared ReadOnly ButtonTextsSpanishEs As String() = {"Aceptar", "Cancelar", "&Sí", "&No", "&Abortar", "&Reintentar", "&Ignorar"}
        Private Shared ReadOnly ButtonTextsItalianIt As String() = {"OK", "Annulla", "&Sì", "&No", "&Interrompi", "&Riprova", "&Ignora"}
        Private Shared ReadOnly ButtonTextsArabicAr As String() = {"موافق", "إلغاء", "نعم", "لا", "إجهاض", " حاول مجدداً", "تجاهل"}
        Private _defaultButton As MessageBoxDefaultButton
        Private _visibleButtonsCount As Integer
        Private ReadOnly languageID As TwoLetterIsoLanguageId = TwoLetterIsoLanguageId.En

        Private Sub New()
            InitializeComponent()
            Dim textInformation As TextInfo = CultureInfo.CurrentCulture.TextInfo

            If textInformation.IsRightToLeft Then
                RightToLeftLayout = True
                RightToLeft = RightToLeft.Yes
            Else
                RightToLeftLayout = False
                RightToLeft = RightToLeft.No
            End If

            [Enum].TryParse(Of TwoLetterIsoLanguageId)(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName, languageID)
            KeyPreview = True
            AddHandler KeyUp, AddressOf FlexibleMessageBoxForm_KeyUp
        End Sub

        Private Shared Function GetStringRows(ByVal message As String) As String()
            If String.IsNullOrEmpty(message) Then Return Nothing
            Dim messageRows = message.Split(New Char() {vbLf}, StringSplitOptions.None)
            Return messageRows
        End Function

        'Private Function GetButtonText(ByVal buttonId As ButtonId) As String
        '    Dim buttonTextArrayIndex = Convert.ToInt32(buttonId)
        '    Return Messaging.TranslateCaption(ButtonTextsEnglishEn(buttonTextArrayIndex))
        'End Function

        Private Function GetButtonText(ByVal buttonId As ButtonId) As String
            Dim buttonTextArrayIndex = Convert.ToInt32(buttonId)

            Select Case languageID
                Case TwoLetterIsoLanguageId.De
                    Return ButtonTextsGermanDe(buttonTextArrayIndex)
                Case TwoLetterIsoLanguageId.Es
                    Return ButtonTextsSpanishEs(buttonTextArrayIndex)
                Case TwoLetterIsoLanguageId.It
                    Return ButtonTextsItalianIt(buttonTextArrayIndex)
                Case TwoLetterIsoLanguageId.Ar
                    Return ButtonTextsArabicAr(buttonTextArrayIndex)
                Case Else
                    Return ButtonTextsEnglishEn(buttonTextArrayIndex)
            End Select
        End Function

        Private Shared Function GetCorrectedWorkingAreaFactor(ByVal workingAreaFactor As Double) As Double
            Const minFactor As Double = 0.2
            Const maxFactor As Double = 1.0
            If workingAreaFactor < minFactor Then Return minFactor
            If workingAreaFactor > maxFactor Then Return maxFactor
            Return workingAreaFactor
        End Function

        Private Shared Sub SetDialogStartPosition(ByVal flexibleMessageBoxForm As FlexibleMessageBoxForm, ByVal owner As IWin32Window)
            If owner Is Nothing Then
                Dim screen = Windows.Forms.Screen.FromPoint(Cursor.Position)
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
            Const scrollbarWidthOffset As Integer = 15
            Dim longestTextRowWidth = stringRows.Max(Function(textForRow) TextRenderer.MeasureText(textForRow, DesiredFont).Width)
            Dim captionWidth = TextRenderer.MeasureText(caption, SystemFonts.CaptionFont).Width
            Dim textWidth = Math.Max(longestTextRowWidth + scrollbarWidthOffset, captionWidth)
            Dim marginWidth = flexibleMessageBoxForm.Width - flexibleMessageBoxForm._richTextBoxMessage.Width
            Dim marginHeight = flexibleMessageBoxForm.Height - flexibleMessageBoxForm._richTextBoxMessage.Height
            flexibleMessageBoxForm.Size = New Size(textWidth + marginWidth, textHeight + marginHeight)
        End Sub

        Private Shared Sub SetDialogIcon(ByVal flexibleMessageBoxForm As FlexibleMessageBoxForm, ByVal icon As MessageBoxIcon)
            Select Case icon
                Case MessageBoxIcon.Information
                    flexibleMessageBoxForm._pictureBoxForIcon.Image = SystemIcons.Information.ToBitmap()
                Case MessageBoxIcon.Warning
                    flexibleMessageBoxForm._pictureBoxForIcon.Image = SystemIcons.Warning.ToBitmap()
                Case MessageBoxIcon.[Error]
                    flexibleMessageBoxForm._pictureBoxForIcon.Image = SystemIcons.[Error].ToBitmap()
                Case MessageBoxIcon.Question
                    flexibleMessageBoxForm._pictureBoxForIcon.Image = SystemIcons.Question.ToBitmap()
                Case Else
                    flexibleMessageBoxForm._pictureBoxForIcon.Visible = False
                    flexibleMessageBoxForm._richTextBoxMessage.Left -= flexibleMessageBoxForm._pictureBoxForIcon.Width
                    flexibleMessageBoxForm._richTextBoxMessage.Width += flexibleMessageBoxForm._pictureBoxForIcon.Width
            End Select
        End Sub

        Private Shared Sub SetDialogButtons(ByVal flexibleMessageBoxForm As FlexibleMessageBoxForm, ByVal buttons As MessageBoxButtons, ByVal defaultButton As MessageBoxDefaultButton)
            Select Case buttons
                Case MessageBoxButtons.AbortRetryIgnore
                    flexibleMessageBoxForm._visibleButtonsCount = 3
                    flexibleMessageBoxForm._button1.Visible = True
                    flexibleMessageBoxForm._button1.Text = flexibleMessageBoxForm.GetButtonText(ButtonId.Abort)
                    flexibleMessageBoxForm._button1.DialogResult = DialogResult.Abort
                    flexibleMessageBoxForm._button2.Visible = True
                    flexibleMessageBoxForm._button2.Text = flexibleMessageBoxForm.GetButtonText(ButtonId.Retry)
                    flexibleMessageBoxForm._button2.DialogResult = DialogResult.Retry
                    flexibleMessageBoxForm._button3.Visible = True
                    flexibleMessageBoxForm._button3.Text = flexibleMessageBoxForm.GetButtonText(ButtonId.Ignore)
                    flexibleMessageBoxForm._button3.DialogResult = DialogResult.Ignore
                    flexibleMessageBoxForm.ControlBox = False
                Case MessageBoxButtons.OKCancel
                    flexibleMessageBoxForm._visibleButtonsCount = 2
                    flexibleMessageBoxForm._button2.Visible = True
                    flexibleMessageBoxForm._button2.Text = flexibleMessageBoxForm.GetButtonText(ButtonId.Ok)
                    flexibleMessageBoxForm._button2.DialogResult = DialogResult.OK
                    flexibleMessageBoxForm._button3.Visible = True
                    flexibleMessageBoxForm._button3.Text = flexibleMessageBoxForm.GetButtonText(ButtonId.Cancel)
                    flexibleMessageBoxForm._button3.DialogResult = DialogResult.Cancel
                    flexibleMessageBoxForm.CancelButton = flexibleMessageBoxForm._button3
                Case MessageBoxButtons.RetryCancel
                    flexibleMessageBoxForm._visibleButtonsCount = 2
                    flexibleMessageBoxForm._button2.Visible = True
                    flexibleMessageBoxForm._button2.Text = flexibleMessageBoxForm.GetButtonText(ButtonId.Retry)
                    flexibleMessageBoxForm._button2.DialogResult = DialogResult.Retry
                    flexibleMessageBoxForm._button3.Visible = True
                    flexibleMessageBoxForm._button3.Text = flexibleMessageBoxForm.GetButtonText(ButtonId.Cancel)
                    flexibleMessageBoxForm._button3.DialogResult = DialogResult.Cancel
                    flexibleMessageBoxForm.CancelButton = flexibleMessageBoxForm._button3
                Case MessageBoxButtons.YesNo
                    flexibleMessageBoxForm._visibleButtonsCount = 2
                    flexibleMessageBoxForm._button2.Visible = True
                    flexibleMessageBoxForm._button2.Text = flexibleMessageBoxForm.GetButtonText(ButtonId.Yes)
                    flexibleMessageBoxForm._button2.DialogResult = DialogResult.Yes
                    flexibleMessageBoxForm._button3.Visible = True
                    flexibleMessageBoxForm._button3.Text = flexibleMessageBoxForm.GetButtonText(ButtonId.No)
                    flexibleMessageBoxForm._button3.DialogResult = DialogResult.No
                    flexibleMessageBoxForm.ControlBox = False
                Case MessageBoxButtons.YesNoCancel
                    flexibleMessageBoxForm._visibleButtonsCount = 3
                    flexibleMessageBoxForm._button1.Visible = True
                    flexibleMessageBoxForm._button1.Text = flexibleMessageBoxForm.GetButtonText(ButtonId.Yes)
                    flexibleMessageBoxForm._button1.DialogResult = DialogResult.Yes
                    flexibleMessageBoxForm._button2.Visible = True
                    flexibleMessageBoxForm._button2.Text = flexibleMessageBoxForm.GetButtonText(ButtonId.No)
                    flexibleMessageBoxForm._button2.DialogResult = DialogResult.No
                    flexibleMessageBoxForm._button3.Visible = True
                    flexibleMessageBoxForm._button3.Text = flexibleMessageBoxForm.GetButtonText(ButtonId.Cancel)
                    flexibleMessageBoxForm._button3.DialogResult = DialogResult.Cancel
                    flexibleMessageBoxForm.CancelButton = flexibleMessageBoxForm._button3
                Case Else
                    flexibleMessageBoxForm._visibleButtonsCount = 1
                    flexibleMessageBoxForm._button3.Visible = True
                    flexibleMessageBoxForm._button3.Text = flexibleMessageBoxForm.GetButtonText(ButtonId.Ok)
                    flexibleMessageBoxForm._button3.DialogResult = DialogResult.OK
                    flexibleMessageBoxForm.CancelButton = flexibleMessageBoxForm._button3
            End Select

            flexibleMessageBoxForm._defaultButton = defaultButton
        End Sub

        Private Sub FlexibleMessageBoxForm_Shown(ByVal sender As Object, ByVal e As EventArgs)
            Dim buttonIndexToFocus As Integer
            Dim buttonToFocus As Button

            Select Case _defaultButton
                Case MessageBoxDefaultButton.Button2
                    buttonIndexToFocus = 2
                Case MessageBoxDefaultButton.Button3
                    buttonIndexToFocus = 3
                Case Else
                    buttonIndexToFocus = 1
            End Select

            If buttonIndexToFocus > _visibleButtonsCount Then buttonIndexToFocus = _visibleButtonsCount

            If buttonIndexToFocus = 3 Then
                buttonToFocus = _button3
            ElseIf buttonIndexToFocus = 2 Then
                buttonToFocus = _button2
            Else
                buttonToFocus = _button1
            End If

            buttonToFocus.Focus()
        End Sub

        Private Sub richTextBoxMessage_LinkClicked(ByVal sender As Object, ByVal e As LinkClickedEventArgs)
            Try
                Cursor.Current = Cursors.WaitCursor
                Process.Start(e.LinkText)
            Catch unusedException1 As Exception
                Throw
            Finally
                Cursor.Current = Cursors.[Default]
            End Try
        End Sub

        Private Sub FlexibleMessageBoxForm_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
            If e.Control AndAlso (e.KeyCode = Keys.C OrElse e.KeyCode = Keys.Insert) Then
                Dim buttonsTextLine = (If(_button1.Visible, _button1.Text & STANDARD_MESSAGEBOX_SEPARATOR_SPACES, String.Empty)) + (If(_button2.Visible, _button2.Text & STANDARD_MESSAGEBOX_SEPARATOR_SPACES, String.Empty)) + (If(_button3.Visible, _button3.Text & STANDARD_MESSAGEBOX_SEPARATOR_SPACES, String.Empty))
                Dim textForClipboard = STANDARD_MESSAGEBOX_SEPARATOR_LINES & Text & Environment.NewLine & STANDARD_MESSAGEBOX_SEPARATOR_LINES + _richTextBoxMessage.Text & Environment.NewLine & STANDARD_MESSAGEBOX_SEPARATOR_LINES + buttonsTextLine.Replace("&", String.Empty) & Environment.NewLine & STANDARD_MESSAGEBOX_SEPARATOR_LINES
                Clipboard.SetText(textForClipboard)
            End If
        End Sub

        Public Property CaptionText As String
        Public Property MessageText As String

        Public Overloads Shared Function Show(ByVal owner As IWin32Window, ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
            Dim flexibleMessageBoxForm = New FlexibleMessageBoxForm()
            flexibleMessageBoxForm.ShowInTaskbar = False
            flexibleMessageBoxForm.CaptionText = caption
            flexibleMessageBoxForm.MessageText = text
            flexibleMessageBoxForm._flexibleMessageBoxFormBindingSource.DataSource = flexibleMessageBoxForm
            SetDialogButtons(flexibleMessageBoxForm, buttons, defaultButton)
            SetDialogIcon(flexibleMessageBoxForm, icon)
            flexibleMessageBoxForm.Font = DesiredFont
            flexibleMessageBoxForm._richTextBoxMessage.Font = DesiredFont
            SetDialogSizes(flexibleMessageBoxForm, text, caption)
            SetDialogStartPosition(flexibleMessageBoxForm, owner)
            Return flexibleMessageBoxForm.ShowDialog(owner)
        End Function

    End Class

End Class
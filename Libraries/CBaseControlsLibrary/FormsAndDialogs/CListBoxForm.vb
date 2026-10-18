Imports System.Windows.Forms

Imports System.Drawing
Imports System.Globalization
Imports System.Resources

Public Class CListBoxForm

    Private _suggestionStatus As Label
    Private Shared ReadOnly SuggestionResources As New ResourceManager(GetType(CComboBox).Namespace & ".ComboBoxStrings", GetType(CComboBox).Assembly)

    Friend Sub SetSuggestionStatus(total As Integer, shown As Integer, rtl As Boolean)
        If total <= shown Then
            If _suggestionStatus IsNot Nothing Then _suggestionStatus.Visible = False
            Return
        End If
        If _suggestionStatus Is Nothing Then
            _suggestionStatus = New Label With {.Dock = DockStyle.Bottom, .AutoSize = False,
                                               .AutoEllipsis = True, .TabStop = False,
                                               .BackColor = SystemColors.Info, .ForeColor = SystemColors.InfoText}
            Controls.Add(_suggestionStatus)
        End If
        Dim arabic = rtl OrElse CultureInfo.CurrentUICulture.TwoLetterISOLanguageName = "ar" OrElse CultureInfo.CurrentCulture.TwoLetterISOLanguageName = "ar"
        Dim culture = If(arabic, CultureInfo.GetCultureInfo("ar"), CultureInfo.GetCultureInfo("en"))
        _suggestionStatus.Text = String.Format(culture, SuggestionResources.GetString("MoreResults", culture), shown, total)
        _suggestionStatus.AccessibleName = _suggestionStatus.Text
        _suggestionStatus.Padding = New Padding(CInt(4 * DeviceDpi / 96.0))
        _suggestionStatus.RightToLeft = If(arabic, RightToLeft.Yes, RightToLeft.No)
        _suggestionStatus.TextAlign = If(arabic, ContentAlignment.MiddleRight, ContentAlignment.MiddleLeft)
        _suggestionStatus.Height = Math.Max(CInt(Math.Ceiling(Font.GetHeight(CSng(DeviceDpi)))) * 2 + CInt(8 * DeviceDpi / 96.0), 1)
        _suggestionStatus.Visible = True
        SuggestListBox.BringToFront()
    End Sub

    Protected Overrides ReadOnly Property ShowWithoutActivation As Boolean
        Get
            Return True
        End Get
    End Property

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H8
            Return cp
        End Get
    End Property

End Class

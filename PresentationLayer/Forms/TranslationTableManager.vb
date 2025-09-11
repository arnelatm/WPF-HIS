Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Presentation.Forms.Services.SystemView

Public Class TranslationTableManager

#Region " Declarations and Property Procedures "

    Private Const TurnOn As Boolean = True
    Private Const TurnOff As Boolean = False
    Friend Row As Integer
    Friend Cmd As String
    Friend Msg As String
    Friend Result As String
    Friend TransTable As New DataTable

    Private MenuLevel As String = ""

    Private _originalAppTextLanguage As String
    Public Property Editing As Boolean
    Public Property SystemViewIdNoToTranslate As Int16

    Private Event GridClick()
    Private _systemViewIdProvider As SystemViewIdProvider

#End Region

    Public Sub New()
        InitializeComponent()
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            ' Add any initialization after the InitializeComponent() call.
            TransTable.Columns.Add("Original")
            TransTable.Columns.Add("Translated")
            _originalAppTextLanguage = GlobalVariables.OriginalAppTextLanguage

            AddHandler GridClick, AddressOf OnGridClick
        End If
        cmbLanguage.Enabled = False
        cmbLanguagePicker.Enabled = False
        cmbLanguage.Visible = False
        cmbLanguagePicker.Visible = False
    End Sub

#Region " Form Load event code "

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If IsDesignMode() Then Return

        StoreCaptions1.StoreCaptions(Me)

        EnsureSystemViewIdProvider()

        If SystemViewIdNoToTranslate = 0 Then
            SystemViewIdNoToTranslate = CShort(_systemViewIdProvider.GetId())
        End If

        LoadLanguages(cmbLanguage)
        cmbLanguage.SelectedValue = TranslatorDAC.DefaultMirroredLanguageIdNo

        LoadLanguagePicker()

        LoadColumn("Original")
        LoadColumn("Translation")

        'If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
        '    StoreCaptions1.StoreCaptions(Me)
        '    Cmd = "Select IdNo from SystemView where SystemViewName ='" + Name.Trim() + "'"
        '    VSystemViewIdNo = TranslatorDAC.ExecScalar(Of Int16)(Cmd)
        '    LoadLanguages(cmbLanguage)
        '    'Dim defaultMirroredLanguageIdNo As Int16
        '    'Cmd = "Select IdNo from Languages where cultureinfocode = '" + GlobalVariables.DefaultMirroredCultureInfoStr + "'"
        '    'defaultMirroredLanguageIdNo = TranslatorDAC.ExecScalar(Of Int16)(Cmd)
        '    cmbLanguage.SelectedValue = TranslatorDAC.DefaultMirroredLanguageIdNo

        '    Dim dsLanguages As DataSet
        '    Cmd = "SELECT idNo,Concat(Language,'-',LTrim(RTrim(Country))) as LanguageName FROM languages order by LanguageName"
        '    dsLanguages = TranslatorDAC.ReturnDs(Cmd)
        '    cmbLanguagePicker.DisplayMember = "LanguageName"
        '    cmbLanguagePicker.ValueMember = "IdNo"
        '    cmbLanguagePicker.DataSource = dsLanguages.Tables("Table")

        '    'Dim dsLanguages As DataSet
        '    'dsLanguages = TranslatorDAC.ReturnDs("SELECT IdNo,Concat(Language,'-',RTrim(LTrim(Country))) as LanguageName FROM languages order by LanguageName")
        '    'cmbLanguagePicker.DisplayMember = "LanguageName"
        '    'cmbLanguagePicker.ValueMember = "IdNo"
        '    'cmbLanguagePicker.DataSource = dsLanguages.Tables("Table")

        '    LoadColumn("Original")
        '    LoadColumn("Translation")

        'End If
    End Sub

#End Region

#Region "Helpers / Providers"

    ' Safe design mode check
    Private Function IsDesignMode() As Boolean
        Return System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime
    End Function

    ' Initialize the SystemViewIdProvider once
    Private Sub EnsureSystemViewIdProvider()
        If _systemViewIdProvider Is Nothing AndAlso TranslatorDAC IsNot Nothing Then
            _systemViewIdProvider = New SystemViewIdProvider(TranslatorDAC, Function() Me.Name)
        End If
    End Sub

    ' Basic string sanitization (replace with true parameter use if DAC supports it)
    Private Function Q(value As String) As String
        If value Is Nothing Then Return "NULL"
        Return "'" & value.Replace("'", "''") & "'"
    End Function

#End Region


#Region "UI Events"

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
        If IsDesignMode() Then Return
        txtTranslation.Size = txtCaption.Size
        Dim p As Point = txtCaption.Location
        p.X = txtCaption.Right + 3
        txtTranslation.Location = p
    End Sub

    Private Sub cmbLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLanguage.SelectedIndexChanged
        If IsDesignMode() OrElse cmbLanguage.SelectedIndex < 0 Then Return
        LoadColumn(cmbLanguage.Text)
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
        If IsDesignMode() OrElse DataGrid1.CurrentRow Is Nothing Then Return

        Editing = False
        Dim originalValue = SafeCellValue(DataGrid1.CurrentRow, 0)
        If String.IsNullOrEmpty(originalValue) Then Return

        Dim captionIdNo = GetCaptionId(originalValue)
        If captionIdNo = 0 Then
            MessageBox.Show("Caption not found.")
            Return
        End If

        Select Case CInt(cmbLanguage.SelectedValue)
            Case 1 ' Original language chosen (delete everywhere)
                Msg = $"Delete {originalValue} for all languages?"
                If Confirm(Msg) Then
                    ExecNonQuery($"DELETE FROM TranslatedCaption WHERE CaptionIdNo = {captionIdNo}")
                    ExecNonQuery($"DELETE FROM OriginalCaptions WHERE Caption = {Q(originalValue)}")
                    ReloadAll()
                End If
            Case Else
                Dim transVal = SafeCellValue(DataGrid1.CurrentRow, 1)
                If String.IsNullOrWhiteSpace(transVal) Then
                    MessageBox.Show("Nothing to delete!")
                    Return
                End If
                Msg = $"Delete {originalValue} translation for {cmbLanguage.Text}?"
                If Confirm(Msg) Then
                    ExecNonQuery("DELETE FROM TranslatedCaption WHERE CaptionIdNo = " & captionIdNo &
                                 " AND LanguageIdNo = " & CInt(cmbLanguage.SelectedValue))
                    ReloadAll()
                End If
        End Select

        SetFocusToRowWithText(originalValue, DataGrid1)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
        Editing = False
        ToggleEditControls(False)
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEdit.Click
        If DataGrid1.CurrentRow Is Nothing Then Return
        Editing = True
        txtCaption.Text = SafeCellValue(DataGrid1.CurrentRow, 0)
        txtTranslation.Text = SafeCellValue(DataGrid1.CurrentRow, 1)
        ToggleEditControls(True)
        txtTranslation.Focus()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave.Click
        If DataGrid1.CurrentRow Is Nothing Then Return
        Editing = False
        SaveRow(SafeCellValue(DataGrid1.CurrentRow, 0), txtTranslation.Text.Trim())
        ToggleEditControls(False)
    End Sub

    Private Sub DataGrid1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid1.CellValueChanged
        If IsDesignMode() OrElse Editing Then Return ' Grid inline edit mode -> Save handled when toggled
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = 1 Then
            Dim row = DataGrid1.Rows(e.RowIndex)
            SaveRow(SafeCellValue(row, 0), SafeCellValue(row, 1))
        End If
    End Sub

    Private Sub cmbLanguagePicker_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLanguagePicker.SelectedIndexChanged
        'Reserved for future UI preview logic
    End Sub

    Private Sub cmdGridEdit_Click(sender As Object, e As EventArgs) Handles cmdGridEdit.Click
        If DataGrid1.Columns.Count > 1 Then
            DataGrid1.Columns(1).ReadOnly = False
            cmdSave.Enabled = False
            cmdCancel.Enabled = True
            cmdEdit.Enabled = False
        End If
    End Sub

    Private Sub DataGrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid1.CellClick
        RaiseEvent GridClick()
    End Sub

    Private Sub OnGridClick()
        If DataGrid1.CurrentRow Is Nothing Then Return
        txtCaption.Text = SafeCellValue(DataGrid1.CurrentRow, 0)
        txtTranslation.Text = SafeCellValue(DataGrid1.CurrentRow, 1)
        txtCaption.Visible = True
        txtTranslation.Visible = True
        txtTranslation.Enabled = False
    End Sub

    'Private Sub Form1_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
    '    txtTranslation.Size = txtCaption.Size
    '    Dim p As Point = txtCaption.Location
    '    p.X = txtCaption.Location.X + txtCaption.Width + 3
    '    txtTranslation.Location = p
    'End Sub

    'Private Sub cmdDeleteLanguage_Click(ByVal sender As Object, ByVal e As EventArgs)

    '    If cmbLanguage.Text.TrimEnd = "Original" Then
    '        MessageBox.Show("You can't delete this entry")
    '        Return
    '    End If

    '    If MessageBox.Show(
    '     "Are you Sure you want to Delete all entries for this language? You will lose all your " + cmbLanguage.Text.TrimEnd + " translations!",
    '     "Not undoable",
    '      MessageBoxButtons.OKCancel,
    '      MessageBoxIcon.Warning,
    '      MessageBoxDefaultButton.Button2) = DialogResult.OK Then
    '        Cmd = "DELETE from TranslatedCaption" _
    '      + " WHERE CultureInfoCode='" + cmbLanguage.Text.TrimEnd + "'"
    '        Result = TranslatorDAC.ExecCmd(Cmd)
    '        If cmbLanguage.Text.TrimEnd <> "Arabic" Then
    '            Cmd = "DELETE from languages" _
    '          + " WHERE CultureInfoCode='" + cmbLanguage.Text.TrimEnd + "'"
    '            Result = TranslatorDAC.ExecCmd(Cmd)
    '        End If
    '    End If
    '    LoadLanguages(cmbLanguage)
    '    LoadColumn("Original")
    '    LoadColumn("Translation")

    ''End Sub

    'Private Sub cmbLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLanguage.SelectedIndexChanged
    '    If IsDesignMode() OrElse cmbLanguage.SelectedIndex < 0 Then Return
    '    LoadColumn(cmbLanguage.Text)
    'End Sub

    'Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
    'End Sub


    '    If IsDesignMode() OrElse DataGrid1.CurrentRow Is Nothing Then Return

    '    Editing = False
    '    Dim nIndex = DataGrid1.CurrentRow.Index
    '    Dim originalValue As String
    '    Dim captionIdNo As Int32
    '    originalValue = DataGrid1.Rows(nIndex).Cells(0).Value.TrimEnd
    '    Cmd = "Select IdNo From OriginalCaptions where Caption ='" + originalValue + "'"
    '    captionIdNo = TranslatorDAC.ExecScalar(Of Int32)(Cmd)
    '    Select Case cmbLanguage.SelectedValue
    '        Case 1
    '            Msg = String.Format("Delete {0} for all languages?", originalValue)
    '            If MessageBox.Show(Msg, "Permanent",
    '                               MessageBoxButtons.OKCancel,
    '                               MessageBoxIcon.Question,
    '                               MessageBoxDefaultButton.Button2) = DialogResult.OK Then

    '                Cmd = "DELETE from TranslatedCaption WHERE CaptionIdNo =" + captionIdNo.ToString()
    '                Result = TranslatorDAC.ExecCmd(Cmd)
    '                Cmd = "DELETE From OriginalCaptions WHERE Caption = '" + originalValue + "'"
    '                Result = TranslatorDAC.ExecCmd(Cmd)
    '                LoadColumn("original")
    '                LoadColumn("translated")
    '            End If
    '        Case Else
    '            Dim transVal As String = DataGrid1.Rows(nIndex).Cells(1).Value
    '            If transVal.TrimEnd.Length = 0 Then
    '                MessageBox.Show("Nothing to delete!")
    '                Return
    '            End If
    '            Msg = String.Format("Delete {0} translation for {1} languages?", originalValue, cmbLanguage.Text.ToString())
    '            If MessageBox.Show(Msg, "Permanent",
    '                               MessageBoxButtons.OKCancel,
    '                               MessageBoxIcon.Question,
    '                               MessageBoxDefaultButton.Button2) = DialogResult.OK Then

    '                Cmd = "DELETE from TranslatedCaption WHERE CaptionIdNo ='" + captionIdNo.ToString + "'" +
    '                      " AND LanguageIdNo = " + cmbLanguage.SelectedValue.ToString()
    '                Result = TranslatorDAC.ExecCmd(Cmd)
    '                LoadColumn("original")
    '                LoadColumn("translated")
    '            End If
    '    End Select
    '    LoadColumn("Original")
    '    LoadColumn("Translation")
    '    SetFocusToRowWithText(originalValue, DataGrid1)

    'End Sub

    'Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
    '    Editing = False
    '    txtTranslation.Visible = False
    '    txtCaption.Visible = False
    '    Buttons(TurnOff)
    'End Sub

    'Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEdit.Click
    '    Editing = True
    '    With DataGrid1
    '        Dim nIndex = .CurrentRow.Index
    '        txtCaption.Text = .Rows(nIndex).Cells(0).Value
    '        txtTranslation.Text = .Rows(nIndex).Cells(1).Value
    '    End With
    '    Buttons(TurnOn)
    '    txtTranslation.Visible = True
    '    txtCaption.Visible = True
    '    txtTranslation.Focus()
    '    cmdSave.Enabled = True
    'End Sub

    'Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave.Click
    '    Editing = False
    '    SaveCurrent()
    '    Buttons(TurnOff)
    '    txtTranslation.Visible = False
    '    txtCaption.Visible = False
    '    DataGrid1.Columns(1).ReadOnly = True
    'End Sub

    'Private Sub DataGrid1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid1.CellValueChanged
    '    SaveCurrentCell()
    'End Sub

    'Private Sub cmbLanguagePicker_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLanguagePicker.SelectedIndexChanged
    '    'If cmbLanguagePicker.SelectedValue <> "_Original" Then
    '    '   TranslateCaptions(cmbLanguagePicker.SelectedValue)
    '    'End If
    '    'Cmd = "Select Caption, translated from TranslatedCaption" _
    '    '  + " where CultureInfoCode = '" + cmbLanguagePicker.Text + "'"
    '    'Dim translations As DataSet
    '    'translations = TranslatorDAC.ReturnDs(Cmd)
    '    'dv = translations.Tables(0).DefaultView
    '    'dv.Sort = "original"
    '    'Dim r As Integer
    '    'For Each ctrl As Control In Controls
    '    '    If TypeOf ctrl Is Label _
    '    ' Or TypeOf ctrl Is Button _
    '    ' Or TypeOf ctrl Is CheckBox _
    '    ' Or TypeOf ctrl Is RadioButton _
    '    ' Or TypeOf ctrl Is DataGrid _
    '    ' Then
    '    '        r = dv.Find(ctrl.Tag)
    '    '        If TypeOf ctrl Is DataGrid Then
    '    '            If r >= 0 Then
    '    '                CType(ctrl, DataGrid).CaptionText = dv(r).Item(1)
    '    '            Else
    '    '                CType(ctrl, DataGrid).CaptionText = ctrl.Tag
    '    '            End If
    '    '        Else
    '    '            If r >= 0 Then
    '    '                ctrl.Text = dv(r).Item(1)
    '    '            Else
    '    '                ctrl.Text = ctrl.Tag
    '    '            End If
    '    '        End If
    '    '    End If
    '    'Next
    '    'if cmbLanguagePicker.Text <> "Original" Then
    '    '    TranslateCaptions(cmbLanguagePicker.Text)
    '    'End If
    'End Sub

#End Region

#Region "Data Loading"

    Private Sub LoadLanguagePicker()
        Cmd = "SELECT IdNo, Concat(Language,'-', LTrim(RTrim(Country))) AS LanguageName FROM languages ORDER BY LanguageName"
        Dim ds = TranslatorDAC.ReturnDs(Cmd)
        cmbLanguagePicker.DisplayMember = "LanguageName"
        cmbLanguagePicker.ValueMember = "IdNo"
        cmbLanguagePicker.DataSource = ds.Tables(0)
    End Sub

    Private Sub LoadLanguages(ByRef cmb As ComboBox)
        If IsDesignMode() Then Return
        Dim sql = "SELECT IdNo, Concat(Language,'-', LTrim(RTrim(Country))) AS LanguageName " &
                  "FROM languages WHERE CultureInfoCode <> '_Original' ORDER BY LanguageName"
        Dim ds = TranslatorDAC.ReturnDs(sql)
        cmb.DisplayMember = "LanguageName"
        cmb.ValueMember = "IdNo"
        cmb.DataSource = ds.Tables(0)
        cmb.Enabled = True
        cmb.Visible = True
    End Sub

    Public Sub LoadColumn(Optional ByVal language As String = "Original")
        If IsDesignMode() Then Return
        SuspendLayout()
        Try
            If language.Equals("original", StringComparison.OrdinalIgnoreCase) Then
                LoadOriginalColumn()
            Else
                LoadTranslatedColumn()
            End If
            DataGrid1.Refresh()
        Finally
            ResumeLayout()
        End Try
    End Sub

    Private Sub LoadOriginalColumn()
        Dim sql As String =
            If(SystemViewIdNoToTranslate = 0,
               "SELECT Caption FROM OriginalCaptions",
               "SELECT Caption FROM SystemViewItemOriginal_View WHERE SystemViewIdNo = " & SystemViewIdNoToTranslate)

        Dim ds = TranslatorDAC.ReturnDs(sql)
        TransTable.Clear()
        If ds.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("No Data Found")
            Return
        End If
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim newRow = TransTable.NewRow()
            newRow("Original") = dr(0).ToString()
            newRow("Translated") = String.Empty
            TransTable.Rows.Add(newRow)
        Next

        BindGrid(readonlyTranslation:=True)
    End Sub

    Private Sub LoadTranslatedColumn()
        If cmbLanguage.SelectedValue Is Nothing Then Return
        Dim langId = CInt(cmbLanguage.SelectedValue)

        Dim sql As String =
            If(SystemViewIdNoToTranslate = 0,
               "SELECT Caption, TranslatedCaption FROM TranslatedCaption_View WHERE LanguageIdNo = " & langId,
               "SELECT Caption, TranslatedCaption FROM SystemViewItemOriginal_View WHERE LanguageIdNo = " & langId &
               " AND SystemViewIdNo = " & SystemViewIdNoToTranslate)

        Dim ds = TranslatorDAC.ReturnDs(sql)

        Dim view = TransTable.DefaultView
        view.Sort = "Original"

        ' Reset translations
        For Each dr As DataRow In TransTable.Rows
            dr("Translated") = String.Empty
        Next

        If ds.Tables.Count > 0 Then
            For Each dr As DataRow In ds.Tables(0).Rows
                Dim idx = view.Find(dr(0))
                If idx >= 0 Then
                    view(idx)("Translated") = If(dr.IsNull(1), "", dr(1).ToString())
                End If
            Next
        End If

        BindGrid(readonlyTranslation:=True)
    End Sub

    Private Sub BindGrid(readonlyTranslation As Boolean)
        If DataGrid1.DataSource Is Nothing Then
            DataGrid1.DataSource = TransTable
        End If
        If DataGrid1.Columns.Count >= 2 Then
            DataGrid1.Columns(0).Width = 410
            DataGrid1.Columns(0).ReadOnly = True
            DataGrid1.Columns(1).Width = 435
            DataGrid1.Columns(1).ReadOnly = readonlyTranslation
        End If
    End Sub

#End Region
    '#Region " Auxiliary routines "

    '    Sub LoadLanguages(ByRef cmb As ComboBox)
    '        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
    '            Dim dsLanguages As DataSet
    '            Dim sql As String
    '            sql = "SELECT IdNo,Concat(Language,'-',LTrim(RTrim(Country))) as LanguageName FROM languages where CultureInfoCode<>'_Original' order by LanguageName"
    '            dsLanguages = TranslatorDAC.ReturnDs(sql)
    '            cmb.DisplayMember = "LanguageName"
    '            cmb.ValueMember = "IdNo"
    '            cmb.DataSource = dsLanguages.Tables("Table")
    '        End If
    '    End Sub

    '    Sub LoadFormDesiredLanguage(ByRef cmb As ComboBox)
    '        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
    '            Dim dsLanguages As DataSet
    '            dsLanguages = TranslatorDAC.ReturnDs(
    '                "SELECT IdNo,Concat(Language,'-',RTrim(LTrim(Country))) as LanguageName FROM languages order by LanguageName")
    '            cmb.DisplayMember = "LanguageName"
    '            cmb.ValueMember = "IdNo"
    '            cmb.DataSource = dsLanguages.Tables("Table")
    '        End If
    '    End Sub

    '    Public Sub LoadColumn(Optional ByVal language As String = "Original")
    '        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
    '            SuspendLayout()
    '            If language.ToLower = "original" Then
    '                Dim dsColumn As DataSet
    '                If SystemViewIdNoToTranslate = 0 Then
    '                    dsColumn = TranslatorDAC.ReturnDs("Select Caption FROM OriginalCaptions")
    '                Else
    '                    dsColumn = TranslatorDAC.ReturnDs("Select Caption FROM SystemViewItemOriginal_View where SystemViewIdNo = " + SystemViewIdNoToTranslate.ToString())
    '                End If
    '                If dsColumn.Tables(0).Rows.Count = 0 Then
    '                    MessageBox.Show("No Data Found")
    '                    Return
    '                End If
    '                TransTable.Clear()
    '                For Each dr As DataRow In dsColumn.Tables(0).Rows
    '                    Dim newRow As DataRow = TransTable.NewRow
    '                    newRow(0) = dr.Item(0)
    '                    newRow(1) = ""
    '                    TransTable.Rows.Add(newRow)
    '                Next
    '                DataGrid1.DataSource = TransTable
    '                DataGrid1.Columns(0).Width = 410
    '                DataGrid1.Columns(0).ReadOnly = True
    '                DataGrid1.Columns(1).Width = 435
    '                DataGrid1.Columns(1).ReadOnly = True
    '            Else
    '                Dim dsColumn As DataSet
    '                If SystemViewIdNoToTranslate = 0 Then

    '                    dsColumn = TranslatorDAC.ReturnDs("Select Caption, translatedCaption FROM TranslatedCaption_View Where LanguageIdNo = " + cmbLanguage.SelectedValue.ToString())
    '                Else
    '                    dsColumn = TranslatorDAC.ReturnDs("Select Caption, translatedCaption FROM SystemViewItemOriginal_View Where LanguageIdNo=" + cmbLanguage.SelectedValue.ToString() +
    '                                                      " and SystemViewIdNo = " + SystemViewIdNoToTranslate.ToString())
    '                End If
    '                Dv = TransTable.DefaultView
    '                Dv.Sort = "original"
    '                ' Clear the second column
    '                For Each dr As DataRow In TransTable.Rows
    '                    dr.Item(1) = ""
    '                Next
    '                If dsColumn.Tables.Count() <> 0 Then
    '                    For Each dr As DataRow In dsColumn.Tables(0).Rows
    '                        Dim rowNum As Integer = Dv.Find(dr(0))
    '                        If rowNum >= 0 Then _
    '                            Dv(rowNum).Item(1) =
    '                                IIf(rowNum >= 0, dr(1), "Not found")
    '                    Next
    '                End If
    '            End If

    '            DataGrid1.Refresh()
    '            ResumeLayout()
    '        End If

    '    End Sub

    '    Public Sub SaveCurrent()

    '        ' Remove the translated record if it already exists
    '        Dim originalValue As String = DataGrid1.CurrentRow.Cells(0).Value.TrimEnd()
    '        Dim translatedValue As String = txtTranslation.Text.TrimEnd()
    '        Dim captionIdNo As Int32
    '        Cmd = "Select IdNo From OriginalCaptions where Caption ='" + originalValue + "'"
    '        captionIdNo = TranslatorDAC.ExecScalar(Of Int32)(Cmd)

    '        Cmd = "DELETE from TranslatedCaption WHERE CaptionIdNo = " + captionIdNo.ToString() +
    '              " AND languageIdNo = " + cmbLanguage.SelectedValue.ToString()
    '        Result = TranslatorDAC.ExecCmd(Cmd)
    '        ' Insert the translated entry if Original isn't selected
    '        If cmbLanguage.Text <> "_Original" AndAlso Not String.IsNullOrEmpty(translatedValue) Then
    '            Cmd = "INSERT INTO TranslatedCaption ( CaptionIdNo , TranslatedCaption, LanguageIdNo) VALUES ( " _
    '                  + captionIdNo.ToString() + ", '" + translatedValue + "'," + cmbLanguage.SelectedValue.ToString() + " )"
    '            Result = TranslatorDAC.ExecCmd(Cmd)
    '        End If

    '        LoadColumn("Original")
    '        LoadColumn("Translation")

    '        SetFocusToRowWithText(txtCaption.Text.TrimEnd(), DataGrid1)

    '    End Sub

    '    Private Sub SetFocusToRowWithText(ByVal textToFind As String, ByRef dataGrid As DataGridView)
    '        For Each dgvRow In dataGrid.Rows
    '            If dgvRow.Cells(0).FormattedValue.ToString().TrimEnd() = textToFind Then
    '                Dim rowIndex = dgvRow.Index
    '                dgvRow.Selected = True
    '                dataGrid.FirstDisplayedScrollingRowIndex = rowIndex
    '                dataGrid.CurrentCell = dataGrid.Rows(rowIndex).Cells(1)
    '            End If
    '        Next
    '    End Sub

    '    Sub SaveCurrentCell()

    '        ' Remove the translated record if it already exists
    '        Dim originalValue As String = DataGrid1.CurrentRow.Cells(0).Value.ToString().Trim()
    '        Dim translatedValue As String = DataGrid1.CurrentRow.Cells(1).Value.ToString().Trim()
    '        Dim captionIdNo As Int32
    '        Cmd = "Select IdNo From OriginalCaptions where Caption ='" + originalValue.Trim() + "'"
    '        captionIdNo = TranslatorDAC.ExecScalar(Of Int32)(Cmd)
    '        Cmd = "DELETE from TranslatedCaption WHERE CaptionIdNo = " + captionIdNo.ToString() +
    '              " AND languageIdNo = " + cmbLanguage.SelectedValue.ToString()
    '        Result = TranslatorDAC.ExecCmd(Cmd)
    '        ' Insert the translated entry if Original isn't selected
    '        If cmbLanguage.Text <> "_Original" AndAlso Not String.IsNullOrEmpty(translatedValue) Then
    '            Cmd = "INSERT INTO TranslatedCaption ( CaptionIdNo , TranslatedCaption, LanguageIdNo) VALUES ( " _
    '                  + captionIdNo.ToString() + ", '" + translatedValue.Trim() + "'," + cmbLanguage.SelectedValue.ToString() + " )"
    '            Result = TranslatorDAC.ExecCmd(Cmd)
    '        End If

    '        ' If the original entry doesn't already exist, add it now
    '        'Cmd = "SELECT count(*) From OriginalCaptions where Caption = '" _
    '        '      + originalValue + "'"
    '        'Dim howMany As Integer = TranslatorDAC.ExecScalar(Cmd)
    '        'If howMany = 0 Then
    '        '    Cmd = "INSERT INTO original ( original ) VALUES ( " _
    '        '          + "'" + originalValue + " ')"
    '        '    Result = TranslatorDAC.ExecCmd(Cmd)
    '        'End If

    '        'SetFocusToRowWithText(DataGrid1.CurrentRow.Cells(0).Value, DataGrid1)

    '        'LoadColumn("Original")
    '        'LoadColumn("Translation")

    '    End Sub

    '    Sub Buttons(ByVal onOff As Boolean)
    '        If _Editing Then
    '            cmdEdit.Enabled = False
    '            cmdDelete.Enabled = False
    '            cmdCancel.Enabled = True
    '            cmdSave.Enabled = True
    '            txtTranslation.Enabled = True
    '            DataGrid1.Enabled = False
    '            cmdGridEdit.Enabled = False
    '        Else
    '            cmdEdit.Enabled = True
    '            cmdDelete.Enabled = True
    '            cmdCancel.Enabled = False
    '            cmdSave.Enabled = False
    '            txtTranslation.Enabled = False
    '            DataGrid1.Enabled = True
    '            cmdGridEdit.Enabled = True
    '        End If
    '    End Sub

    '    Private Sub cmdGridEdit_Click(sender As Object, e As EventArgs) Handles cmdGridEdit.Click
    '        cmdSave.Enabled = False
    '        cmdCancel.Enabled = True
    '        cmdEdit.Enabled = False
    '        cmdDelete.Enabled = True
    '        DataGrid1.Columns(1).ReadOnly = False
    '    End Sub

    '    Private Sub DataGrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid1.CellClick
    '        RaiseEvent GridClick()
    '    End Sub

    '    Private Sub OnGridClick()
    '        With DataGrid1
    '            Dim nIndex = .CurrentRow.Index
    '            txtCaption.Text = .Rows(nIndex).Cells(0).Value.ToString()
    '            txtTranslation.Text = .Rows(nIndex).Cells(1).Value.ToString()
    '        End With
    '        txtTranslation.Visible = True
    '        txtCaption.Visible = True
    '        txtTranslation.Enabled = False
    '    End Sub

    '    '    'Private Sub InitializeComponent()
    '    '    '    CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
    '    '    '    Me.SuspendLayout()
    '    '    '    '
    '    '    '    'TranslationTableManager
    '    '    '    '
    '    '    '    Me.ClientSize = New System.Drawing.Size(1114, 709)
    '    '    '    Me.Name = "TranslationTableManager"
    '    '    '    CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
    '    '    '    Me.ResumeLayout(False)

    '    '    'End Sub

    '#End Region

#Region "Persistence / Save Logic"

    Private Sub SaveRow(originalValue As String, translatedValue As String)
        If String.IsNullOrWhiteSpace(originalValue) OrElse cmbLanguage.SelectedValue Is Nothing Then Return

        Dim captionId = GetCaptionId(originalValue)
        If captionId = 0 Then
            ' ADD optional auto-create original caption row if missing:
            ' ExecNonQuery($"INSERT INTO OriginalCaptions (Caption) VALUES ({Q(originalValue)})")
            ' captionId = GetCaptionId(originalValue)
            Return
        End If

        ' Remove any existing translation for this caption/language
        ExecNonQuery("DELETE FROM TranslatedCaption WHERE CaptionIdNo = " & captionId &
                     " AND LanguageIdNo = " & CInt(cmbLanguage.SelectedValue))

        If cmbLanguage.Text <> "_Original" AndAlso Not String.IsNullOrWhiteSpace(translatedValue) Then
            ExecNonQuery("INSERT INTO TranslatedCaption (CaptionIdNo, TranslatedCaption, LanguageIdNo) VALUES (" &
                         captionId & ", " & Q(translatedValue) & ", " & CInt(cmbLanguage.SelectedValue) & ")")
        End If

        ' Refresh the translation column only (avoid re-query original twice)
        LoadColumn("Translation")
        SetFocusToRowWithText(originalValue, DataGrid1)
    End Sub

    Private Function GetCaptionId(originalValue As String) As Integer
        If String.IsNullOrWhiteSpace(originalValue) Then Return 0
        Dim sql = "SELECT IdNo FROM OriginalCaptions WHERE Caption = " & Q(originalValue)
        Return SafeScalarInt(sql)
    End Function

    Private Function SafeScalarInt(sql As String) As Integer
        Try
            Return TranslatorDAC.ExecScalar(Of Integer)(sql)
        Catch
            Return 0
        End Try
    End Function

    Private Sub ExecNonQuery(sql As String)
        Try
            TranslatorDAC.ExecCmd(sql)
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message)
        End Try
    End Sub

#End Region

#Region "UI State / Helpers"

    Private Sub ToggleEditControls(isEdit As Boolean)
        Editing = isEdit
        cmdEdit.Enabled = Not isEdit
        cmdDelete.Enabled = Not isEdit
        cmdCancel.Enabled = isEdit
        cmdSave.Enabled = isEdit
        txtTranslation.Enabled = isEdit
        txtTranslation.Visible = isEdit
        txtCaption.Visible = isEdit
        DataGrid1.Enabled = Not isEdit
        cmdGridEdit.Enabled = Not isEdit
    End Sub

    Private Function Confirm(message As String) As Boolean
        Return MessageBox.Show(message,
                               "Confirm",
                               MessageBoxButtons.OKCancel,
                               MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) = DialogResult.OK
    End Function

    Private Function SafeCellValue(row As DataGridViewRow, cellIndex As Integer) As String
        If row Is Nothing OrElse cellIndex >= row.Cells.Count Then Return String.Empty
        Dim val = row.Cells(cellIndex).Value
        Return If(val Is Nothing, String.Empty, val.ToString())
    End Function

    Private Sub ReloadAll()
        LoadColumn("Original")
        LoadColumn("Translation")
    End Sub

    Private Sub SetFocusToRowWithText(ByVal textToFind As String, ByRef dataGrid As DataGridView)
        If String.IsNullOrWhiteSpace(textToFind) Then Return
        For Each dgvRow As DataGridViewRow In dataGrid.Rows
            If Not dgvRow.IsNewRow AndAlso
               dgvRow.Cells(0).FormattedValue.ToString().TrimEnd().Equals(textToFind, StringComparison.OrdinalIgnoreCase) Then
                dgvRow.Selected = True
                dataGrid.FirstDisplayedScrollingRowIndex = dgvRow.Index
                dataGrid.CurrentCell = dgvRow.Cells(1)
                Exit For
            End If
        Next
    End Sub

#End Region

End Class
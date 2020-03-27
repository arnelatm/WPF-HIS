Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Languages

Public Class TranslationTableManager

#Region " Declarations and Property Procedures "

    Const TurnOn As Boolean = True
    Const TurnOff As Boolean = False
    Friend Row As Integer
    Friend Cmd As String
    Friend Msg As String
    Friend Result As String
    Friend TransTable As New DataTable

    'Private CaptionCollection As New Collection
    Private MenuLevel As String = ""

    Private _originalAppTextLanguage As String
    Public Property Editing As Boolean
    Public Property FormIdNoToTranslate As Int16

    Private Event GridClick()

#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        If Not DesignMode Then
            ' Add any initialization after the InitializeComponent() call.
            TransTable.Columns.Add("Original")
            TransTable.Columns.Add("Translated")
            _originalAppTextLanguage = GlobalVariables.OriginalAppTextLanguage

            AddHandler GridClick, AddressOf OnGridClick
        End If
    End Sub

#Region " Form Load event code "

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If Not DesignMode Then
            StoreCaptions1.StoreCaptions(Me)
            Cmd = "Select IdNo from systemForms where FormName ='" + Name + "'"
            FormIdNo = TranslatorDAC.ExecScalar(Of Int16)(Cmd)
            LoadLanguages(cmbLanguage)
            'Dim defaultMirroredLanguageIdNo As Int16
            'Cmd = "Select IdNo from Languages where cultureinfocode = '" + GlobalVariables.DefaultMirroredCultureInfoStr + "'"
            'defaultMirroredLanguageIdNo = TranslatorDAC.ExecScalar(Of Int16)(Cmd)
            cmbLanguage.SelectedValue = DefaultMirroredLanguageIdNo

            Dim dsLanguages As DataSet
            Cmd = "SELECT idNo,Concat(Language,'-',LTrim(RTrim(Country))) as LanguageName FROM languages order by LanguageName"
            dsLanguages = TranslatorDAC.ReturnDs(Cmd)
            cmbLanguagePicker.DisplayMember = "LanguageName"
            cmbLanguagePicker.ValueMember = "IdNo"
            cmbLanguagePicker.DataSource = dsLanguages.Tables("Table")

            'Dim dsLanguages As DataSet
            'dsLanguages = TranslatorDAC.ReturnDs("SELECT IdNo,Concat(Language,'-',RTrim(LTrim(Country))) as LanguageName FROM languages order by LanguageName")
            'cmbLanguagePicker.DisplayMember = "LanguageName"
            'cmbLanguagePicker.ValueMember = "IdNo"
            'cmbLanguagePicker.DataSource = dsLanguages.Tables("Table")

            LoadColumn("Original")
            LoadColumn("Translation")

        End If
    End Sub

#End Region

#Region " Miscellaneous event handlers "

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
        txtTranslation.Size = txtCaption.Size
        Dim p As Point = txtCaption.Location
        p.X = txtCaption.Location.X + txtCaption.Width + 3
        txtTranslation.Location = p
    End Sub

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
    '        Cmd = "DELETE from TranslatedCaptions" _
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

    'End Sub

    Private Sub cmbLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLanguage.SelectedIndexChanged

        LoadColumn(cmbLanguage.Text)

    End Sub

    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
        Editing = False
        Dim nIndex = DataGrid1.CurrentRow.Index
        Dim originalValue As String
        Dim captionIdNo As Int16
        originalValue = DataGrid1.Rows(nIndex).Cells(0).Value.TrimEnd
        Cmd = "Select IdNo From OriginalCaptions where Caption ='" + originalValue + "'"
        captionIdNo = TranslatorDAC.ExecScalar(Of Int16)(Cmd)
        Select Case cmbLanguage.SelectedValue
            Case 1
                Msg = String.Format(StringWords.Delete0ForAllLanguages, originalValue)
                If MessageBox.Show(Msg, StringWords.Permanent,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) = DialogResult.OK Then

                    Cmd = "DELETE from TranslatedCaptions WHERE CaptionIdNo =" + captionIdNo.ToString()
                    Result = TranslatorDAC.ExecCmd(Cmd)
                    Cmd = "DELETE From OriginalCaptions WHERE Caption = '" + originalValue + "'"
                    Result = TranslatorDAC.ExecCmd(Cmd)
                    LoadColumn("original")
                    LoadColumn("translated")
                End If
            Case Else
                Dim transVal As String = DataGrid1.Rows(nIndex).Cells(1).Value
                If transVal.TrimEnd.Length = 0 Then
                    MessageBox.Show(Messages.NothingToDelete)
                    Return
                End If
                Msg = String.Format(Messages.Delete0TranslationFor1, cmbLanguage.Text.ToString(), originalValue)
                If MessageBox.Show(Msg, StringWords.Permanent,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) = DialogResult.OK Then

                    Cmd = "DELETE from TranslatedCaptions WHERE CaptionIdNo ='" + captionIdNo.ToString + "'" +
                          " AND LanguageIdNo = " + cmbLanguage.SelectedValue.ToString()
                    Result = TranslatorDAC.ExecCmd(Cmd)
                    LoadColumn("original")
                    LoadColumn("translated")
                End If
        End Select
        LoadColumn("Original")
        LoadColumn("Translation")
        SetFocusToRowWithText(originalValue, DataGrid1)

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
        Editing = False
        txtTranslation.Visible = False
        txtCaption.Visible = False
        Buttons(TurnOff)
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEdit.Click
        Editing = True
        With DataGrid1
            Dim nIndex = .CurrentRow.Index
            txtCaption.Text = .Rows(nIndex).Cells(0).Value
            txtTranslation.Text = .Rows(nIndex).Cells(1).Value
        End With
        Buttons(TurnOn)
        txtTranslation.Visible = True
        txtCaption.Visible = True
        txtTranslation.Focus()
        cmdSave.Enabled = True
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave.Click
        Editing = False
        SaveCurrent()
        Buttons(TurnOff)
        txtTranslation.Visible = False
        txtCaption.Visible = False
        DataGrid1.Columns(1).ReadOnly = True
    End Sub

    Private Sub DataGrid1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid1.CellValueChanged
        SaveCurrentCell()
    End Sub

    Private Sub cmbLanguagePicker_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLanguagePicker.SelectedIndexChanged
        'If cmbLanguagePicker.SelectedValue <> "_Original" Then
        TranslateCaptions(cmbLanguagePicker.SelectedValue)
        'End If
        'Cmd = "Select Caption, translated from TranslatedCaptions" _
        '  + " where CultureInfoCode = '" + cmbLanguagePicker.Text + "'"
        'Dim translations As DataSet
        'translations = TranslatorDAC.ReturnDs(Cmd)
        'dv = translations.Tables(0).DefaultView
        'dv.Sort = "original"
        'Dim r As Integer
        'For Each ctrl As Control In Controls
        '    If TypeOf ctrl Is Label _
        ' Or TypeOf ctrl Is Button _
        ' Or TypeOf ctrl Is CheckBox _
        ' Or TypeOf ctrl Is RadioButton _
        ' Or TypeOf ctrl Is DataGrid _
        ' Then
        '        r = dv.Find(ctrl.Tag)
        '        If TypeOf ctrl Is DataGrid Then
        '            If r >= 0 Then
        '                CType(ctrl, DataGrid).CaptionText = dv(r).Item(1)
        '            Else
        '                CType(ctrl, DataGrid).CaptionText = ctrl.Tag
        '            End If
        '        Else
        '            If r >= 0 Then
        '                ctrl.Text = dv(r).Item(1)
        '            Else
        '                ctrl.Text = ctrl.Tag
        '            End If
        '        End If
        '    End If
        'Next
        'if cmbLanguagePicker.Text <> "Original" Then
        '    TranslateCaptions(cmbLanguagePicker.Text)
        'End If
    End Sub

#End Region

#Region " Auxiliary routines "

    Sub LoadLanguages(ByRef cmb As ComboBox)
        If Not DesignMode Then
            Dim dsLanguages As DataSet
            Dim sql As String
            sql = "SELECT IdNo,Concat(Language,'-',LTrim(RTrim(Country))) as LanguageName FROM languages where CultureInfoCode<>'_Original' order by LanguageName"
            dsLanguages = TranslatorDAC.ReturnDs(sql)
            cmb.DisplayMember = "LanguageName"
            cmb.ValueMember = "IdNo"
            cmb.DataSource = dsLanguages.Tables("Table")
        End If
    End Sub

    Sub LoadFormDesiredLanguage(ByRef cmb As ComboBox)
        If Not DesignMode Then
            Dim dsLanguages As DataSet
            dsLanguages = TranslatorDAC.ReturnDs(
                "SELECT IdNo,Concat(Language,'-',RTrim(LTrim(Country))) as LanguageName FROM languages order by LanguageName")
            cmb.DisplayMember = "LanguageName"
            cmb.ValueMember = "IdNo"
            cmb.DataSource = dsLanguages.Tables("Table")
        End If
    End Sub

    Public Sub LoadColumn(Optional ByVal language As String = "Original")
        If Not DesignMode Then
            SuspendLayout()
            If language.ToLower = "original" Then
                Dim dsColumn As DataSet
                If FormIdNoToTranslate = 0 Then
                    dsColumn = TranslatorDAC.ReturnDs("Select Caption FROM OriginalCaptions")
                Else
                    dsColumn = TranslatorDAC.ReturnDs("Select Caption FROM FormItemsOriginal_View where FormIdNo = " + FormIdNoToTranslate.ToString())
                End If
                If dsColumn.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show(Messages.NoDataFound)
                    Return
                End If
                TransTable.Clear()
                For Each dr As DataRow In dsColumn.Tables(0).Rows
                    Dim newrow As DataRow = TransTable.NewRow
                    newrow(0) = dr.Item(0)
                    newrow(1) = ""
                    TransTable.Rows.Add(newrow)
                Next
                DataGrid1.DataSource = TransTable
                DataGrid1.Columns(0).Width = 410
                DataGrid1.Columns(0).ReadOnly = True
                DataGrid1.Columns(1).Width = 435
                DataGrid1.Columns(1).ReadOnly = True
            Else
                Dim dsColumn As DataSet
                If FormIdNoToTranslate = 0 Then

                    dsColumn = TranslatorDAC.ReturnDs("Select Caption, translated FROM TranslatedCaptions_View Where LanguageIdNo = " + cmbLanguage.SelectedValue.ToString())
                Else
                    dsColumn = TranslatorDAC.ReturnDs("Select Caption, translated FROM FormItemsOriginal_View Where LanguageIdNo=" + cmbLanguage.SelectedValue.ToString() +
                                                      " and FormIdNo = " + FormIdNoToTranslate.ToString())
                End If
                Dv = TransTable.DefaultView
                Dv.Sort = "original"
                ' Clear the second column
                For Each dr As DataRow In TransTable.Rows
                    dr.Item(1) = ""
                Next
                For Each dr As DataRow In dsColumn.Tables(0).Rows
                    Dim rowNum As Integer = Dv.Find(dr(0))
                    If rowNum >= 0 Then _
                        Dv(rowNum).Item(1) =
                            IIf(rowNum >= 0, dr(1), "Not found")
                Next
            End If

            DataGrid1.Refresh()
            ResumeLayout()
        End If

    End Sub

    Public Sub SaveCurrent()

        ' Remove the translated record if it already exists
        Dim originalValue As String = DataGrid1.CurrentRow.Cells(0).Value.TrimEnd()
        Dim translatedValue As String = txtTranslation.Text.TrimEnd()
        Dim captionIdNo As Int16
        Cmd = "Select IdNo From OriginalCaptions where Caption ='" + originalValue + "'"
        captionIdNo = TranslatorDAC.ExecScalar(Of Int16)(Cmd)

        Cmd = "DELETE from TranslatedCaptions WHERE CaptionIdNo = " + captionIdNo.ToString() +
              " AND languageIdNo = " + cmbLanguage.SelectedValue.ToString()
        Result = TranslatorDAC.ExecCmd(Cmd)
        ' Insert the translated entry if Original isn't selected
        If cmbLanguage.Text <> "_Original" AndAlso Not String.IsNullOrEmpty(translatedValue) Then
            Cmd = "INSERT INTO TranslatedCaptions ( CaptionIdNo , Translated, LanguageIdNo) VALUES ( " _
                  + captionIdNo.ToString() + ", '" + translatedValue + "'," + cmbLanguage.SelectedValue.ToString() + " )"
            Result = TranslatorDAC.ExecCmd(Cmd)
        End If

        LoadColumn("Original")
        LoadColumn("Translation")

        SetFocusToRowWithText(txtCaption.Text.TrimEnd(), DataGrid1)

    End Sub

    Private Sub SetFocusToRowWithText(ByVal textToFind As String, ByRef dataGrid As DataGridView)
        For Each dgvRow In dataGrid.Rows
            If dgvRow.Cells(0).FormattedValue.ToString().TrimEnd() = textToFind Then
                Dim rowIndex = dgvRow.Index
                dgvRow.Selected = True
                dataGrid.FirstDisplayedScrollingRowIndex = rowIndex
                dataGrid.CurrentCell = dataGrid.Rows(rowIndex).Cells(1)
            End If
        Next
    End Sub

    Sub SaveCurrentCell()

        ' Remove the translated record if it already exists
        Dim originalValue As String = DataGrid1.CurrentRow.Cells(0).Value.ToString().Trim()
        Dim translatedValue As String = DataGrid1.CurrentRow.Cells(1).Value.ToString().Trim()
        Dim captionIdNo As Int16
        Cmd = "Select IdNo From OriginalCaptions where Caption ='" + originalValue.Trim() + "'"
        captionIdNo = TranslatorDAC.ExecScalar(Of Int16)(Cmd)
        Cmd = "DELETE from TranslatedCaptions WHERE CaptionIdNo = " + captionIdNo.ToString() +
              " AND languageIdNo = " + cmbLanguage.SelectedValue.ToString()
        Result = TranslatorDAC.ExecCmd(Cmd)
        ' Insert the translated entry if Original isn't selected
        If cmbLanguage.Text <> "_Original" AndAlso Not String.IsNullOrEmpty(translatedValue) Then
            Cmd = "INSERT INTO TranslatedCaptions ( CaptionIdNo , Translated, LanguageIdNo) VALUES ( " _
                  + captionIdNo.ToString() + ", '" + translatedValue.Trim() + "'," + cmbLanguage.SelectedValue.ToString() + " )"
            Result = TranslatorDAC.ExecCmd(Cmd)
        End If

        ' If the original entry doesn't already exist, add it now
        'Cmd = "SELECT count(*) From OriginalCaptions where Caption = '" _
        '      + originalValue + "'"
        'Dim howMany As Integer = TranslatorDAC.ExecScalar(Cmd)
        'If howMany = 0 Then
        '    Cmd = "INSERT INTO original ( original ) VALUES ( " _
        '          + "'" + originalValue + " ')"
        '    Result = TranslatorDAC.ExecCmd(Cmd)
        'End If

        'SetFocusToRowWithText(DataGrid1.CurrentRow.Cells(0).Value, DataGrid1)

        'LoadColumn("Original")
        'LoadColumn("Translation")

    End Sub

    Sub Buttons(ByVal onOff As Boolean)
        If _Editing Then
            cmdEdit.Enabled = False
            cmdDelete.Enabled = False
            cmdCancel.Enabled = True
            cmdSave.Enabled = True
            txtTranslation.Enabled = True
            DataGrid1.Enabled = False
            cmdGridEdit.Enabled = False
        Else
            cmdEdit.Enabled = True
            cmdDelete.Enabled = True
            cmdCancel.Enabled = False
            cmdSave.Enabled = False
            txtTranslation.Enabled = False
            DataGrid1.Enabled = True
            cmdGridEdit.Enabled = True
        End If
    End Sub

    Private Sub cmdGridEdit_Click(sender As Object, e As EventArgs) Handles cmdGridEdit.Click
        cmdSave.Enabled = False
        cmdCancel.Enabled = True
        cmdEdit.Enabled = False
        cmdDelete.Enabled = True
        DataGrid1.Columns(1).ReadOnly = False
    End Sub

    Private Sub DataGrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid1.CellClick
        RaiseEvent GridClick()
    End Sub

    Private Sub OnGridClick()
        With DataGrid1
            Dim nIndex = .CurrentRow.Index
            txtCaption.Text = .Rows(nIndex).Cells(0).Value.ToString()
            txtTranslation.Text = .Rows(nIndex).Cells(1).Value.ToString()
        End With
        txtTranslation.Visible = True
        txtCaption.Visible = True
        txtTranslation.Enabled = False
    End Sub

    '    'Private Sub InitializeComponent()
    '    '    CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
    '    '    Me.SuspendLayout()
    '    '    '
    '    '    'TranslationTableManager
    '    '    '
    '    '    Me.ClientSize = New System.Drawing.Size(1114, 709)
    '    '    Me.Name = "TranslationTableManager"
    '    '    CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
    '    '    Me.ResumeLayout(False)

    '    'End Sub

#End Region

End Class
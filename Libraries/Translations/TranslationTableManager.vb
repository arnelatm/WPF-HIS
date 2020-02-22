Imports System.Drawing
Imports System.Windows.Forms


Public Class TranslationTableManager

#Region " Declarations and Property Procedures "

    Const TurnOn As Boolean = True
    Const TurnOff As Boolean = False
    Friend Row As Integer
    Friend Cmd As String
    Friend Msg As String
    Friend Result As String
    Friend TransTable As New DataTable
    Private _language As String = "Arabic"

    Public Property Editing As Boolean

#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        TransTable.Columns.Add("Original")
        TransTable.Columns.Add("Translated")

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region " Form Load event code "

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        If Not DesignMode Then
            StoreCaptions1.StoreCaptions(Me)
            LoadLanguages1(cmbLanguage)
            'LoadLanguages2(cmbLanguagePicker)
            LoadColumn("Original")
            LoadColumn("Translation")
        End If
    End Sub
#End Region


#Region " Miscellaneous event handlers "

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
        txtTranslation.Size = txtOriginal.Size
        Dim p As Point = txtOriginal.Location
        p.X = txtOriginal.Location.X + txtOriginal.Width + 3
        txtTranslation.Location = p
    End Sub

    Private Sub cmdDeleteLanguage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDeleteLanguage.Click

        If cmbLanguage.Text.TrimEnd = "Original" Then
            MessageBox.Show("You can't delete this entry")
            Return
        End If

        If MessageBox.Show(
            "Delete all entries for this language?",
            "Not undoable",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2) = DialogResult.OK Then
            Cmd = "DELETE from translated" _
                  + " WHERE original='" + txtOriginal.Text.TrimEnd + "'" _
                  + " AND lang='" + cmbLanguage.Text.TrimEnd + "'"
            Result = TranslatorDAC.ExecCmd(Cmd)
            Cmd = "DELETE from languages" _
                  + " WHERE lang='" + cmbLanguage.Text.TrimEnd + "'"
            Result = TranslatorDAC.ExecCmd(Cmd)
        End If
        LoadLanguages1(cmbLanguage)
        LoadColumn("Original")
        LoadColumn("Translation")

    End Sub

    Private Sub cmbLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLanguage.SelectedIndexChanged

        LoadColumn(cmbLanguage.Text)

    End Sub

    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
        Editing = False
        Select Case cmbLanguage.Text.TrimEnd
            Case "Original"
                Dim nIndex = DataGrid1.CurrentRow.Index
                Dim origval As String = DataGrid1.Rows(nIndex).Cells(0).Value
                origval = origval.TrimEnd
                Msg = "Delete " + origval + " for all languages?"
                If MessageBox.Show(Msg, "Permanent",
                                   MessageBoxButtons.OKCancel,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) _
                   = DialogResult.OK Then
                    Cmd = "DELETE from translated" _
                          + " WHERE original='" + origval + "'"
                    Result = TranslatorDAC.ExecCmd(Cmd)
                    Cmd = "DELETE from original" _
                          + " WHERE original='" + origval + "'"
                    Result = TranslatorDAC.ExecCmd(Cmd)
                    LoadColumn("original")
                    LoadColumn("translated")
                End If
            Case Else
                Dim nIndex = DataGrid1.CurrentRow.Index
                Dim transVal As String = DataGrid1.Rows(nIndex).Cells(1).Value
                If transVal.TrimEnd.Length = 0 Then
                    MessageBox.Show("Nothing to delete")
                    Return
                End If
                Dim origval As String
                origval = DataGrid1.Rows(nIndex).Cells(0).Value
                origval = origval.TrimEnd
                Msg = "Delete " + origval + "?"
                If MessageBox.Show(Msg, "Permanent",
                                   MessageBoxButtons.OKCancel,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) =
                   DialogResult.OK Then
                    Cmd = "DELETE from translated" _
                          + " WHERE original='" + origval + "'" _
                          + " AND lang='" + cmbLanguage.Text.TrimEnd + "'"
                    Result = TranslatorDAC.ExecCmd(Cmd)
                    LoadColumn("original")
                    LoadColumn("translated")
                End If
        End Select
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
        Editing = False
        txtTranslation.Visible = False
        txtOriginal.Visible = False
        Buttons(TurnOff)
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEdit.Click
        Editing = True
        With DataGrid1
            Dim nIndex = .CurrentRow.Index
            txtOriginal.Text = .Rows(nIndex).Cells(0).Value
            txtTranslation.Text = .Rows(nIndex).Cells(1).Value
        End With
        Buttons(TurnOn)
        txtTranslation.Visible = True
        txtOriginal.Visible = True
        txtTranslation.Focus()
        cmdSave.Enabled = True
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave.Click
        Editing = False
        SaveCurrent()
        Buttons(TurnOff)
        txtTranslation.Visible = False
        txtOriginal.Visible = False
        DataGrid1.Columns(1).ReadOnly = True
    End Sub

    Private Sub DataGrid1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid1.CellValueChanged
        SaveCurrentCell()
    End Sub


    Private Sub txtNewLanguage_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtNewLanguage.Leave

        txtNewLanguage.Visible = False
        cmdDeleteLanguage.Visible = True

        If Not DesignMode And txtNewLanguage.Text <> "" Then
            Cmd = "SELECT COUNT(*) FROM languages WHERE lang = '" _
                  + txtNewLanguage.Text.TrimEnd + "'"
            Dim howMany As Integer = TranslatorDAC.ExecScalar(Cmd)
            If howMany > 0 Then
                MessageBox.Show(
                    "Already exists",
                    "Language already in system",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
                Return
            End If
            Cmd = "INSERT INTO Languages VALUES ( '" _
                  + txtNewLanguage.Text.TrimEnd + "')"
            TranslatorDAC.ExecCmd(Cmd)
            Me.LoadLanguages1(cmbLanguage)
        End If

    End Sub

    Private Sub cmdAddLanguage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAddLanguage.Click

        cmdDeleteLanguage.Visible = False
        txtNewLanguage.Text = ""
        txtNewLanguage.Visible = True
        txtNewLanguage.Focus()

    End Sub

    Private Sub cmbLanguagePicker_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)


        Cmd = "select original, translated from translated" _
              + " where lang = '" '+ cmbLanguagePicker.Text + "'"
        Dim translations As New DataSet
        translations = TranslatorDAC.ReturnDs(Cmd)
        Dim dv As DataView = translations.Tables(0).DefaultView
        dv.Sort = "original"
        Dim r As Integer
        For Each ctrl As Control In Controls
            If TypeOf ctrl Is Label _
               Or TypeOf ctrl Is Button _
               Or TypeOf ctrl Is CheckBox _
               Or TypeOf ctrl Is RadioButton _
               Or TypeOf ctrl Is DataGrid _
                Then
                r = dv.Find(ctrl.Tag)
                If TypeOf ctrl Is DataGrid Then
                    If r >= 0 Then
                        CType(ctrl, DataGrid).CaptionText = dv(r).Item(1)
                    Else
                        CType(ctrl, DataGrid).CaptionText = ctrl.Tag
                    End If
                Else
                    If r >= 0 Then
                        ctrl.Text = dv(r).Item(1)
                    Else
                        ctrl.Text = ctrl.Tag
                    End If
                End If
            End If
        Next

    End Sub

#End Region



#Region " Auxiliary routines "

    Sub LoadLanguages1(ByVal cmb As ComboBox)
        If Not DesignMode Then
            Dim dsLanguages As DataSet
            dsLanguages = TranslatorDAC.ReturnDs(
                "SELECT * FROM languages where Lang<>'Original'")
            cmb.DisplayMember = "lang"
            cmb.ValueMember = "lang"
            cmb.DataSource = dsLanguages.Tables("Table")
        End If
    End Sub

    Sub LoadLanguages2(ByVal cmb As ComboBox)
        If Not DesignMode Then
            Dim dsLanguages = TranslatorDAC.ReturnDs(
                "SELECT * FROM languages")
            cmb.DisplayMember = "lang"
            cmb.ValueMember = "lang"
            cmb.DataSource = dsLanguages.Tables("Table")
        End If
    End Sub

    Public Sub LoadColumn(Optional ByVal language As String = "Original")
        If Not DesignMode Then
            SuspendLayout()
            If language.ToLower = "original" Then
                Dim dsColumn As DataSet
                dsColumn = TranslatorDAC.ReturnDs("SELECT original FROM original")
                If dsColumn.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("No data found")
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
                DataGrid1.Columns(0).Width = 322
                DataGrid1.Columns(0).ReadOnly = True
                DataGrid1.Columns(1).Width = 320
                DataGrid1.Columns(1).ReadOnly = True
            Else
                Dim dsColumn As DataSet
                dsColumn = TranslatorDAC.ReturnDs("SELECT original, translated FROM translated WHERE lang='" & cmbLanguage.Text & "'")
                Dim dv As DataView
                dv = TransTable.DefaultView
                dv.Sort = "original"
                ' Clear the second column
                For Each dr As DataRow In TransTable.Rows
                    dr.Item(1) = ""
                Next
                For Each dr As DataRow In dsColumn.Tables(0).Rows
                    Dim rownum As Integer = dv.Find(dr(0))
                    If rownum >= 0 Then _
                        dv(rownum).Item(1) =
                            IIf(rownum >= 0, dr(1), "Not found")
                Next
            End If

            DataGrid1.Refresh()
            ResumeLayout()
        End If

    End Sub

    Sub SaveCurrent()

        ' Remove the translated record if it already exists

        Cmd = "DELETE from translated" _
              + " WHERE original='" + txtOriginal.Text.TrimEnd + "'" _
              + " AND lang='" + cmbLanguage.Text.TrimEnd + "'"
        Result = TranslatorDAC.ExecCmd(Cmd)

        ' Insert the translated entry if Original isn't selected
        If cmbLanguage.Text <> "Original" Then
            Cmd = "INSERT INTO translated (" _
                  + " original, translated, lang ) VALUES ( " _
                  + "'" + txtOriginal.Text.TrimEnd + " '," _
                  + "'" + txtTranslation.Text.TrimEnd + " '," _
                  + "'" + cmbLanguage.Text + " ')"
            Result = TranslatorDAC.ExecCmd(Cmd)
        End If

        ' If the original entry doesn't already exist, add it now
        Cmd = "SELECT count(*) FROM original WHERE original = '" _
              + txtOriginal.Text.TrimEnd + "'"
        Dim howMany As Integer = TranslatorDAC.ExecScalar(Cmd)
        If howMany = 0 Then
            Cmd = "INSERT INTO original ( original ) VALUES ( " _
                  + "'" + txtOriginal.Text.TrimEnd + " ')"
            Result = TranslatorDAC.ExecCmd(Cmd)
        End If

        LoadColumn("Original")
        LoadColumn("Translation")

        For Each dgvRow In DataGrid1.Rows
            If dgvRow.Cells(0).FormattedValue.ToString().TrimEnd() = txtOriginal.Text.TrimEnd() Then
                Dim rowIndex = dgvRow.Index
                DataGrid1.ClearSelection()
                DataGrid1.MultiSelect = False
                dgvRow.Selected = True
                DataGrid1.FirstDisplayedScrollingRowIndex = rowIndex
                DataGrid1.CurrentCell = DataGrid1.Rows(rowIndex).Cells(1)
            End If
        Next

    End Sub

    Sub SaveCurrentCell()

        ' Remove the translated record if it already exists
        Dim originalValue As String = DataGrid1.CurrentRow.Cells(0).Value.TrimEnd
        Dim translatedValue As String = DataGrid1.CurrentRow.Cells(1).Value.TrimEnd
        Dim languageValue As String = cmbLanguage.Text.TrimEnd
        Cmd = "DELETE from translated" _
              + " WHERE original='" + originalValue + "'" _
              + " AND lang='" + languageValue + "'"
        Result = TranslatorDAC.ExecCmd(Cmd)

        ' Insert the translated entry if Original isn't selected
        If cmbLanguage.Text <> "Original" Then
            Cmd = "INSERT INTO translated (" _
                  + " original, translated, lang ) VALUES ( " _
                  + "'" + originalValue + " '," _
                  + "'" + translatedValue + " '," _
                  + "'" + languageValue + " ')"
            Result = TranslatorDAC.ExecCmd(Cmd)
        End If

        ' If the original entry doesn't already exist, add it now
        Cmd = "SELECT count(*) FROM original WHERE original = '" _
              + originalValue + "'"
        Dim howMany As Integer = TranslatorDAC.ExecScalar(Cmd)
        If howMany = 0 Then
            Cmd = "INSERT INTO original ( original ) VALUES ( " _
                  + "'" + originalValue + " ')"
            Result = TranslatorDAC.ExecCmd(Cmd)
        End If

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

    Private Sub CButton1_Click(sender As Object, e As EventArgs) Handles cmdGridEdit.Click
        cmdSave.Enabled = False
        cmdCancel.Enabled = True
        cmdEdit.Enabled = False
        cmdDelete.Enabled = True
        DataGrid1.Columns(1).ReadOnly = False
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
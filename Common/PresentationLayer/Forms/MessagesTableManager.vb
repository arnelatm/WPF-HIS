Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class MessagesTableManager

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

        Private Event GridClick()

#End Region

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
                ' Add any initialization after the InitializeComponent() call.
                TransTable.Columns.Add("Original")
                TransTable.Columns.Add("Translated")
                _originalAppTextLanguage = GlobalVariables.OriginalAppTextLanguage

                AddHandler GridClick, AddressOf OnGridClick
            End If
        End Sub

#Region " Form Load event code "

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
                StoreCaptions1.StoreCaptions(Me)
                LoadLanguages(cmbLanguage)

                'Cmd = "Select IdNo from Languages where cultureInfoCode = '" + GlobalVariables.DefaultMirroredCultureInfoStr + "'"
                'Dim defaultMirroredLanguageIdNo As Short = TranslatorDAC.ExecScalar(Of Int16)(Cmd)
                ' defaultMirroredLanguageIdNo As Short
                'defaultMirroredLanguageIdNo = TranslatorDAC.DefaultMirroredLanguageIdNo
                cmbLanguage.SelectedValue = DefaultMirroredLanguageIdNo

                Dim dsLanguages As DataSet
                Cmd = "SELECT idNo,Concat(Language,'-',LTrim(RTrim(Country))) as LanguageName FROM languages order by LanguageName"
                dsLanguages = TranslatorDAC.ReturnDs(Cmd)
                cmbLanguagePicker.DisplayMember = "LanguageName"
                cmbLanguagePicker.ValueMember = "IdNo"
                cmbLanguagePicker.DataSource = dsLanguages.Tables("Table")

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

        Private Sub cmbLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLanguage.SelectedIndexChanged

            LoadColumn(cmbLanguage.Text)

        End Sub

        Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
            Editing = False
            Dim nIndex = DataGrid1.CurrentRow.Index
            Dim originalValue As String
            Dim messageIdNo As Int16
            originalValue = DataGrid1.Rows(nIndex).Cells(0).Value.TrimEnd
            Cmd = "Select IdNo from originalMessages where Caption ='" + originalValue + "'"
            messageIdNo = TranslatorDAC.ExecScalar(Of Int16)(Cmd)
            Select Case cmbLanguage.SelectedValue
                Case 1
                    Msg = String.Format("Delete {0} for all languages?", originalValue)
                    If MessageBox.Show(Msg, "Permanent",
                                       MessageBoxButtons.OKCancel,
                                       MessageBoxIcon.Question,
                                       MessageBoxDefaultButton.Button2) = DialogResult.OK Then

                        Cmd = "DELETE from TranslatedMessages WHERE MessageIdNo =" + messageIdNo.ToString()
                        Result = TranslatorDAC.ExecCmd(Cmd)
                        Cmd = "DELETE from OriginalMessages WHERE message = '" + originalValue + "'"
                        Result = TranslatorDAC.ExecCmd(Cmd)
                        LoadColumn("original")
                        LoadColumn("translated")
                    End If
                Case Else
                    Dim transVal As String = DataGrid1.Rows(nIndex).Cells(1).Value
                    If transVal.TrimEnd.Length = 0 Then
                        MessageBox.Show("Nothing to delete!")
                        Return
                    End If
                    Msg = String.Format("Delete {0} translation for {1} Language?", originalValue, cmbLanguage.Text.ToString())
                    If MessageBox.Show(Msg, "Permanent",
                                       MessageBoxButtons.OKCancel,
                                       MessageBoxIcon.Question,
                                       MessageBoxDefaultButton.Button2) = DialogResult.OK Then

                        Cmd = "DELETE from TranslatedMessages WHERE MessageIdNo ='" + messageIdNo.ToString + "'" +
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

        Private Sub cmbLanguagePicker_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLanguagePicker.SelectedIndexChanged
            TranslateCaptions(cmbLanguagePicker.SelectedValue)
        End Sub

#End Region

#Region " Auxiliary routines "

        Sub LoadLanguages(ByRef cmb As ComboBox)
            If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
                Dim dsLanguages As DataSet
                Dim cmd As String
                cmd = "SELECT IdNo,Concat(Language,'-',LTrim(RTrim(Country))) as LanguageName FROM languages where CultureInfoCode<>'_Original' order by LanguageName"
                dsLanguages = TranslatorDAC.ReturnDs(cmd)
                cmb.DisplayMember = "LanguageName"
                cmb.ValueMember = "IdNo"
                cmb.DataSource = dsLanguages.Tables("Table")
            End If
        End Sub

        Sub LoadFormDesiredLanguage(ByRef cmb As ComboBox)
            If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
                Dim dsLanguages As DataSet
                dsLanguages = TranslatorDAC.ReturnDs(
                    "SELECT IdNo,Concat(Language,'-',RTrim(LTrim(Country))) as LanguageName FROM languages order by LanguageName")
                cmb.DisplayMember = "LanguageName"
                cmb.ValueMember = "IdNo"
                cmb.DataSource = dsLanguages.Tables("Table")
            End If
        End Sub

        Public Sub LoadColumn(Optional ByVal language As String = "Original")
            If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
                SuspendLayout()
                If language.ToLower = "original" Then
                    Dim dsColumn As DataSet
                    dsColumn = TranslatorDAC.ReturnDs("Select Caption FROM originalMessages")
                    If dsColumn.Tables(0).Rows.Count = 0 Then
                        MessageBox.Show("No Data Found")
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
                    dsColumn = TranslatorDAC.ReturnDs("Select Caption, TranslatedCaption FROM TranslatedMessages_View Where LanguageIdNo = " + cmbLanguage.SelectedValue.ToString())
                    Dv = TransTable.DefaultView
                    Dv.Sort = "original"
                    ' Clear the second column
                    For Each dr As DataRow In TransTable.Rows
                        dr.Item(1) = ""
                    Next
                    For Each dr As DataRow In dsColumn.Tables(0).Rows
                        Dim rownum As Integer = Dv.Find(dr(0))
                        If rownum >= 0 Then _
                            Dv(rownum).Item(1) =
                                IIf(rownum >= 0, dr(1), "Not found")
                    Next
                End If

                DataGrid1.Refresh()
                ResumeLayout()
            End If

        End Sub

        Sub SaveCurrent()

            ' Remove the translated record if it already exists
            Dim originalValue As String = DataGrid1.CurrentRow.Cells(0).Value.TrimEnd
            Dim translatedValue As String = txtTranslation.Text.TrimEnd
            Dim messageIdNo As Int16
            Cmd = "Select IdNo from originalMessages where Caption ='" + originalValue + "'"
            messageIdNo = TranslatorDAC.ExecScalar(Of Int16)(Cmd)

            Cmd = "DELETE from TranslatedMessages WHERE MessageIdNo = " + messageIdNo.ToString() +
                  " AND languageIdNo = " + cmbLanguage.SelectedValue.ToString()
            Result = TranslatorDAC.ExecCmd(Cmd)
            ' Insert the translated entry if Original isn't selected
            If cmbLanguage.Text <> "_Original" Then
                Cmd = "INSERT INTO TranslatedMessages ( MessageIdNo , TranslatedCaption, LanguageIdNo) VALUES ( " _
                      + messageIdNo.ToString() + ", '" + translatedValue + "'," + cmbLanguage.SelectedValue.ToString() + " )"
                Result = TranslatorDAC.ExecCmd(Cmd)
            End If

            LoadColumn("Original")
            LoadColumn("Translation")

            SetFocusToRowWithText(txtOriginal.Text.TrimEnd(), DataGrid1)

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
            Dim originalValue As String = DataGrid1.CurrentRow.Cells(0).Value.TrimEnd
            Dim translatedValue As String = DataGrid1.CurrentRow.Cells(1).Value.TrimEnd
            Dim messageIdNo As Int16
            Cmd = "Select IdNo from originalMessages where Caption ='" + originalValue + "'"
            messageIdNo = TranslatorDAC.ExecScalar(Of Int16)(Cmd)
            Cmd = "DELETE from TranslatedMessages WHERE MessageIdNo = " + messageIdNo.ToString() +
                  " AND languageIdNo = " + cmbLanguage.SelectedValue.ToString()
            Result = TranslatorDAC.ExecCmd(Cmd)
            ' Insert the translated entry if Original isn't selected
            If cmbLanguage.Text <> $"_Original" Then
                Cmd = "INSERT INTO TranslatedMessages ( MessageIdNo , TranslatedCaption, LanguageIdNo) VALUES ( " _
                      + messageIdNo.ToString() + ", '" + translatedValue + "'," + cmbLanguage.SelectedValue.ToString() + " )"
                Result = TranslatorDAC.ExecCmd(Cmd)
            End If

            SetFocusToRowWithText(DataGrid1.CurrentRow.Cells(0).Value, DataGrid1)

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
                txtOriginal.Text = .Rows(nIndex).Cells(0).Value
                txtTranslation.Text = .Rows(nIndex).Cells(1).Value
            End With
            txtTranslation.Visible = True
            txtOriginal.Visible = True
            txtTranslation.Enabled = False
        End Sub

        Private Sub txtOriginal_TextChanged(sender As Object, e As EventArgs) Handles txtOriginal.TextChanged

        End Sub

#End Region

    End Class
End NameSpace
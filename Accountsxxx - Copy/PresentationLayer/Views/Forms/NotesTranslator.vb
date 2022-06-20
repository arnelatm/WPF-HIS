Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class NotesTranslator

#Region " Declarations and Property Procedures "

        Const TurnOn As Boolean = True
        Const TurnOff As Boolean = False
        Friend Row As Integer
        Friend Cmd As String
        Friend Msg As String
        Friend Result As String
        Friend TransactionNotesTable As New DataTable

        Private Event GridClick()

#End Region

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            TransactionNotesTable.Columns.Add("Notes")
            AddHandler GridClick, AddressOf OnGridClick
        End Sub

        Private Sub DataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewTransactionNotes.CellClick
            RaiseEvent GridClick()
        End Sub

        Private Sub OnGridClick()
            With DataGridViewTransactionNotes
                Dim nIndex = .CurrentRow.Index
                txtOriginalNote.Text = .Rows(nIndex).Cells(0).Value.ToString()
                txtTranslation.Text = .Rows(nIndex).Cells(0).Value.ToString()
            End With
        End Sub

        Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
            Close()
        End Sub

        Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave.Click
            Dim retVal As Int16 = TranslateNote(True)

        End Sub

        Private Sub btnTranslateWord_Click(sender As Object, e As EventArgs) Handles btnTranslateWord.Click
            TranslateNote(False)
        End Sub

        Private Function TranslateNote(wholeNote As Boolean)
            Dim retVal As Integer = 0
            If txtOriginalNote.Text IsNot Nothing AndAlso txtTranslation.Text IsNot Nothing AndAlso
               txtOriginalNote.Text <> "" AndAlso txtTranslation.Text <> "" Then
                Dim originalValue As String = txtOriginalNote.Text
                Dim translatedValue As String = txtTranslation.Text
                If wholeNote Then
                    retVal = TranslatorDAC.ExecuteSp2Param("spTranslateTransactionNotes", txtOriginalNote.Text, txtTranslation.Text)
                Else
                    retVal = TranslatorDAC.ExecuteSp2Param("spTranslateTransactionWordNotes", txtOriginalNote.Text, txtTranslation.Text)
                End If
            End If
            If retVal > 0 Then
                MessageBox.Show(retVal.ToString() + " records translated.")
            Else
                MessageBox.Show("No records were found with the entered note.")
            End If
            Return retVal
        End Function

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
                LoadColumn()
            End If
            If GlobalVariables.UserName.ToLower() = "arnel" Then
                btnTranslateWord.Enabled = True
            End If
        End Sub

        Public Sub LoadColumn()
            If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
                SuspendLayout()
                Dim dsColumn As DataSet
                dsColumn = TranslatorDAC.ReturnDs("Select distinct TransactionNotes FROM TransactionNotes_View order by TransactionNotes ")
                If dsColumn.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("No Data Found")
                    Return
                End If
                TransactionNotesTable.Clear()
                For Each dr As DataRow In dsColumn.Tables(0).Rows
                    Dim newRow As DataRow = TransactionNotesTable.NewRow
                    newRow(0) = dr.Item(0)
                    TransactionNotesTable.Rows.Add(newRow)
                Next
                With DataGridViewTransactionNotes
                    .DataSource = TransactionNotesTable
                    .Columns(0).ReadOnly = True
                End With
                DataGridViewTransactionNotes.Refresh()
                ResumeLayout()
            End If

        End Sub

        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            LoadColumn()
        End Sub

    End Class

End Namespace
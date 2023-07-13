Imports System.Drawing
Imports System.Windows.Controls
Imports System.Windows.Forms
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Public Class DosageTableManager
    Implements IDosageMasterListView

#Region " Declarations and Property Procedures "

    Const TurnOn As Boolean = True
    Const TurnOff As Boolean = False
    Friend Row As Integer
    Friend Cmd As String
    Friend Msg As String
    Friend Result As String
    Friend TransTable As New DataTable
    Private Event LoadAll(sortKey As String) Implements IDosageMasterListView.LoadAll
    Private Event SaveCurrent(idNo As Int32, translation As String) Implements IDosageMasterListView.SaveCurrent
    Private MenuLevel As String = ""
    Private _dosageMasterList As List(Of IDosageMasterView)
    Private _originalAppTextLanguage As String
    Public Property SystemViewIdNoToTranslate As Int16

    Public Property DosageMasterList As List(Of IDosageMasterView) Implements IDosageMasterListView.DosageMasterList
        Get
            Return _dosageMasterList
        End Get
        Set(value As List(Of IDosageMasterView))
            _dosageMasterList = value
            BindDosage()
        End Set
    End Property

    Public Property DosageMasterCode As String Implements IDosageMasterView.DosageMasterCode

    Public Property DosageMasterName As String Implements IDosageMasterView.DosageMasterName

    Public Property DosageMasterNameAra As String Implements IDosageMasterView.DosageMasterNameAra

    Public Property IdNo As Integer Implements IDosageMasterView.IdNo


#End Region

    Public Sub New()

        ' This call is required by the designer.

        InitializeComponent()
        InitializationMode = False
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            ' Add any initialization after the InitializeComponent() call.
            TransTable.Columns.Add("Original")
            TransTable.Columns.Add("Translated")
            _originalAppTextLanguage = GlobalVariables.OriginalAppTextLanguage
        End If

    End Sub

    Private Sub BindDosage()
        bsDosageMaster.DataSource = Nothing
        bsDosageMaster.DataSource = DosageMasterList
        bsDosageMaster.AllowNew = False
        With DataGridViewDosageMaster
            .Refresh()
            .AutoGenerateColumns = False
            .DataSource = bsDosageMaster
            .Refresh()
        End With
        With DataGridViewDosageMaster.Columns

        End With
    End Sub


#Region " Form Load event code "

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        RaiseEvent LoadAll("DosageMasterName")
    End Sub

#End Region

#Region " Miscellaneous event handlers "

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
        txtTranslation.Size = txtOriginal.Size
        Dim p As Point = txtOriginal.Location
        p.X = txtOriginal.Location.X + txtOriginal.Width + 3
        txtTranslation.Location = p
    End Sub


    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
        AllowEditing(False)
    End Sub

    Private Sub AllowEditing(AllowEdit As Boolean)
        DataGridViewDosageMaster.Columns(2).ReadOnly = Not AllowEdit
        AllowEdits(AllowEdit)
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEdit.Click
        With DataGridViewDosageMaster
            Dim nIndex = .CurrentRow.Index
            txtOriginal.Text = .Rows(nIndex).Cells(1).Value
            txtTranslation.Text = .Rows(nIndex).Cells(2).Value
        End With
        AllowEdits(True)
        'txtTranslation.Visible = True
        'txtOriginal.Visible = True
        txtTranslation.Focus()
        cmdSave.Enabled = True
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave.Click
        RaiseEvent SaveCurrent(CInt(DataGridViewDosageMaster.CurrentRow.Cells(3).Value), txtTranslation.Text)
        UpdateDisplay()
    End Sub

    Private Sub UpdateDisplay()
        'txtTranslation.Visible = False
        'txtOriginal.Visible = False
        With DataGridViewDosageMaster
            .Rows(.CurrentRow.Index).Cells(2).Value = txtTranslation.Text
        End With
        AllowEdits(False)
        'DataGridViewDosageMaster.Columns(2).ReadOnly = True
        DataGridViewDosageMaster.Refresh()
    End Sub

    Private Sub SetFocusToRowWithText(ByVal textToFind As String, ByRef dataGrid As DataGridView)
        For Each dgvRow In dataGrid.Rows
            If dgvRow.Cells(1).FormattedValue.ToString().TrimEnd() = textToFind Then
                Dim rowIndex = dgvRow.Index
                dgvRow.Selected = True
                dataGrid.FirstDisplayedScrollingRowIndex = rowIndex
                dataGrid.CurrentCell = dataGrid.Rows(rowIndex).Cells(2)
                Exit For
            End If
        Next
    End Sub

    Private Sub DataGridViewCellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDosageMaster.CellValueChanged
        If Not InitializationMode Then
            RaiseEvent SaveCurrent(sender.Rows(e.RowIndex).Cells(3).Value, sender.Rows(e.RowIndex).Cells(2).Value)
        End If
    End Sub


#End Region

#Region " Auxiliary routines "

    Sub AllowEdits(allow As Boolean)
        If allow Then
            cmdEdit.Enabled = False
            cmdDelete.Enabled = False
            cmdCancel.Enabled = True
            cmdSave.Enabled = True
            txtTranslation.Enabled = True
            cmdGridEdit.Enabled = False
        Else
            cmdEdit.Enabled = True
            cmdDelete.Enabled = False 'True
            cmdCancel.Enabled = False
            cmdSave.Enabled = False
            txtTranslation.Enabled = False
            cmdGridEdit.Enabled = True
        End If
    End Sub

    Private Sub cmdGridEdit_Click(sender As Object, e As EventArgs) Handles cmdGridEdit.Click
        AllowEditing(True)
        'cmdSave.Enabled = False
        'cmdCancel.Enabled = True
        'cmdEdit.Enabled = False
        'cmdDelete.Enabled = False ' True
        'DataGridViewDosageMaster.Columns(2).ReadOnly = False
    End Sub

    Private Sub DataGrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDosageMaster.CellClick
        With DataGridViewDosageMaster
            Dim nIndex = .CurrentRow.Index
            txtDosageCode.Text = .Rows(nIndex).Cells(0).Value
            txtOriginal.Text = .Rows(nIndex).Cells(1).Value
            txtTranslation.Text = .Rows(nIndex).Cells(2).Value
            txtIdNo.Text = .Rows(nIndex).Cells(3).Value
        End With
    End Sub

    'Private Sub txtTranslation_Leave(sender As Object, e As EventArgs) Handles txtTranslation.Leave
    '    AllowEdits(False)
    'End Sub

#End Region

End Class
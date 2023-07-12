Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
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
    Private MenuLevel As String = ""
    Private _dosageMasterList As List(Of IDosageMasterView)
    Private _originalAppTextLanguage As String
    Public Property Editing As Boolean
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
        txtTranslation.Size = txtCaption.Size
        Dim p As Point = txtCaption.Location
        p.X = txtCaption.Location.X + txtCaption.Width + 3
        txtTranslation.Location = p
    End Sub


    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
        Editing = False
        txtTranslation.Visible = False
        txtCaption.Visible = False
        Buttons(TurnOff)
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEdit.Click
        Editing = True
        With DataGridViewDosageMaster
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
        'SaveCurrent()
        Buttons(TurnOff)
        txtTranslation.Visible = False
        txtCaption.Visible = False
        DataGridViewDosageMaster.Columns(1).ReadOnly = True
    End Sub

    Private Sub DataGrid1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDosageMaster.CellValueChanged
        'SaveCurrentCell()
    End Sub


#End Region

#Region " Auxiliary routines "

    Sub Buttons(ByVal onOff As Boolean)
        If _Editing Then
            cmdEdit.Enabled = False
            cmdDelete.Enabled = False
            cmdCancel.Enabled = True
            cmdSave.Enabled = True
            txtTranslation.Enabled = True
            DataGridViewDosageMaster.Enabled = False
            cmdGridEdit.Enabled = False
        Else
            cmdEdit.Enabled = True
            cmdDelete.Enabled = True
            cmdCancel.Enabled = False
            cmdSave.Enabled = False
            txtTranslation.Enabled = False
            DataGridViewDosageMaster.Enabled = True
            cmdGridEdit.Enabled = True
        End If
    End Sub

    Private Sub cmdGridEdit_Click(sender As Object, e As EventArgs) Handles cmdGridEdit.Click
        cmdSave.Enabled = False
        cmdCancel.Enabled = True
        cmdEdit.Enabled = False
        cmdDelete.Enabled = True
        DataGridViewDosageMaster.Columns(1).ReadOnly = False
    End Sub

    Private Sub DataGrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDosageMaster.CellClick
        RaiseEvent GridClick()
    End Sub

    Private Sub OnGridClick()
        'With DataGrid1
        '    Dim nIndex = .CurrentRow.Index
        '    txtCaption.Text = .Rows(nIndex).Cells(0).Value.ToString()
        '    txtTranslation.Text = .Rows(nIndex).Cells(1).Value.ToString()
        'End With
        'txtTranslation.Visible = True
        'txtCaption.Visible = True
        'txtTranslation.Enabled = False
    End Sub

#End Region

End Class
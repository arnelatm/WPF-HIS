Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.CBaseControlsLibrary

Partial Public Class TestForm3
    Inherits Form

    Private CBFullList As Dictionary(Of String, System.Int32)
    Private CBFilteredList As Dictionary(Of String, System.Int32)
    Private ComboBoxBusy As Boolean

    Public Sub New()
        InitializeComponent()
        ComboBoxBusy = False
        CBFullList = New Dictionary(Of String, Int32)()
        CBFilteredList = New Dictionary(Of String, Int32)()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        CBFullList.Add("None", 0)
        CBFullList.Add("123 abc", 1)
        CBFullList.Add("12 ab", 2)
        CBFullList.Add("abc 123", 3)
        CBFullList.Add("def", 4)
        CBFullList.Add("ghm 123", 5)
        CBFullList.Add("None1", 6)
        CBFullList.Add("1231 abc", 7)
        CBFullList.Add("121 ab", 8)
        CBFullList.Add("abc1 123", 9)
        CBFullList.Add("def1", 10)
        CBFullList.Add("ghm1 123", 11)
        CBFullList.Add("None2", 12)
        CBFullList.Add("1232 abc", 13)
        CBFullList.Add("122 ab", 14)
        CBFullList.Add("abc2 123", 15)
        CBFullList.Add("def2", 16)
        CBFullList.Add("ghm2 123", 17)
        CBFullList.Add("None3", 18)
        CBFullList.Add("1233 abc", 19)
        CBFullList.Add("123 ab", 20)
        CBFullList.Add("abc3 123", 21)
        CBFullList.Add("def3", 22)
        CBFullList.Add("ghm3 123", 23)
        CBFullList.Add("None4", 24)
        CBFullList.Add("1234 abc", 25)
        CBFullList.Add("124 ab", 26)
        CBFullList.Add("abc4 123", 27)
        CBFullList.Add("def4", 28)
        CBFullList.Add("ghm4 123", 29)
        CBFullList.Add("None5", 30)
        CBFullList.Add("1235 abc", 31)
        CBFullList.Add("125 ab", 32)
        CBFullList.Add("abc5 123", 33)
        CBFullList.Add("def5", 34)
        CBFullList.Add("ghm5 123", 35)
        CBFullList.Add("None6", 36)
        CBFullList.Add("1236 abc", 37)
        CBFullList.Add("126 ab", 38)
        CBFullList.Add("abc6 123", 39)
        CBFullList.Add("def6", 40)
        CBFullList.Add("ghm6 123", 41)
        CBFullList.Add("None7", 42)
        CBFullList.Add("1237 abc", 43)
        CBFullList.Add("127 ab", 44)
        CBFullList.Add("abc7 123", 45)
        CBFullList.Add("def7", 46)
        CBFullList.Add("ghm7 123", 47)
        FilterList(False)
    End Sub

    Private Sub FilterList(ByVal show As Boolean)
        If ComboBoxBusy = False Then
            Dim orgText As String
            ComboBoxBusy = True
            orgText = cComboBox1.Text
            cComboBox1.DroppedDown = False
            CBFilteredList.Clear()

            For Each item As KeyValuePair(Of String, Int32) In CBFullList
                If item.Key.ToUpper().Contains(orgText.ToUpper()) Then CBFilteredList.Add(item.Key, item.Value)
            Next

            If CBFilteredList.Count < 1 Then CBFilteredList.Add("None", 0)
            cComboBox1.BeginUpdate()
            cComboBox1.DataSource = New BindingSource(CBFilteredList, Nothing)
            cComboBox1.DisplayMember = "Key"
            cComboBox1.ValueMember = "Value"
            cComboBox1.DroppedDown = show
            cComboBox1.SelectedIndex = -1
            cComboBox1.Text = orgText
            cComboBox1.[Select](cComboBox1.Text.Length, 0)
            cComboBox1.EndUpdate()
            Cursor.Current = Cursors.[Default]
            ComboBoxBusy = False
        End If
    End Sub

    Private Sub comboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cComboBox1.SelectedIndexChanged
        If ComboBoxBusy = False Then
            FilterList(False)
        End If
    End Sub

    Private Sub comboBox1_TextUpdate(ByVal sender As Object, ByVal e As EventArgs) Handles cComboBox1.TextUpdate
        FilterList(True)
    End Sub


End Class

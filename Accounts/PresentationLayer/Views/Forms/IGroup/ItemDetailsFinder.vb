Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub

Public Class ItemDetailsFinder

    Private _dgv As DataGridView
    Private _service As Object

    Public Sub New(textToFind As String, dgvObj As DataGridView)


        ' This call is required by the designer.
        InitializeComponent()
        Me.ShowIcon = False
        Me.ControlBox = True
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.Text = ""
        Me.TopMost = False
        _dgv = dgvObj
        txtFinder.Text = textToFind
        Dim pnt As Point
        Dim dgvLocation As Point
        Dim screenRectangle As Rectangle
        screenRectangle = Screen.PrimaryScreen.WorkingArea
        StartPosition = FormStartPosition.Manual
        pnt = _dgv.PointToScreen(Location)
        Location = New Point(pnt.X, pnt.Y)
        If dgvLocation.Y + Height > screenRectangle.Height Then
            dgvLocation.Y = pnt.Y - Height
        End If
        DataGridViewItemDetails.MultiSelect = False
        _service = New AccountsService("ItemDetails")

        DataGridViewItemDetails.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        DataGridViewItemDetails.DefaultCellStyle.SelectionForeColor = Color.Black


    End Sub

    Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs)
        _findText = ""
    End Sub

    'Private Sub ItemDetailsFinder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'ISPDATADataSet.ItemDetails' table. You can move, or remove it, as needed.
    '    Me.ItemDetailsTableAdapter.Fill(Me.ISPDATADataSet.ItemDetails)
    '    'TODO: This line of code loads data into the 'ISPDATADataSet.PurchaseDetail' table. You can move, or remove it, as needed.
    '    Me.PurchaseDetailTableAdapter.Fill(Me.ISPDATADataSet.PurchaseDetail)
    '    'txtFinder.Select()

    '    '' for columns    
    '    'DataGridViewAccGridComboBoxColumn1.ComboDataGridView = ProgramaticalyCreatedDataGridView
    '    '' selection is done by single click, i.e. not double click
    '    'DataGridViewAccGridComboBoxColumn1.CloseOnSingleClick = True
    '    '' binding is trigered on value change, i.e. not on validating
    '    'DataGridViewAccGridComboBoxColumn1.InstantBinding = True

    '    '' for comboboxes (second param is CloseOnSingleClick property setter)
    '    'Dim ProgramaticalyCreatedDataGridView As DataGridView = CreateDataGridViewForPersonInfo()
    '    'AccGridComboBox1.AddDataGridView(ProgramaticalyCreatedDataGridView, True)
    '    'AccGridComboBox1.InstantBinding = True

    'End Sub

    Private SearchString As String = ""

    Private Sub txtFinder_TextChanged(sender As Object, e As EventArgs) Handles txtFinder.TextChanged
        Dim dao As New ItemDetailsDao
        If txtFinder.Text.Length() < 3 Then
            DataGridViewItemDetails.DataSource = Nothing
            'AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgText2Short")
        Else
            DataGridViewItemDetails.DataSource = dao.GetItemDetailBySearchString(txtFinder.Text)
            _findText = txtFinder.Text
        End If
    End Sub

    Private Sub SubDataGridViewItemDetailss_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs) Handles DataGridViewItemDetails.CellPainting
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 AndAlso DataGridViewItemDetails.Columns(e.ColumnIndex).Name <> "Id" Then

            If Not String.IsNullOrWhiteSpace(_findText.Trim()) Then
                Dim gridCellValue As String = e.FormattedValue.ToString()
                Dim startIndexInCellValue As Integer = gridCellValue.ToLower().IndexOf(_findText.Trim().ToLower())

                If startIndexInCellValue >= 0 Then
                    e.Handled = True
                    e.PaintBackground(e.CellBounds, True)
                    Dim hl_rect As Rectangle = New Rectangle With {
                        .Y = e.CellBounds.Y + 2,
                        .Height = e.CellBounds.Height - 5
                    }
                    Dim sBeforeSearchword As String = gridCellValue.Substring(0, startIndexInCellValue)
                    Dim sSearchWord As String = gridCellValue.Substring(startIndexInCellValue, _findText.Trim().Length)
                    Dim s1 As Size = TextRenderer.MeasureText(e.Graphics, sBeforeSearchword, e.CellStyle.Font, e.CellBounds.Size)
                    Dim s2 As Size = TextRenderer.MeasureText(e.Graphics, sSearchWord, e.CellStyle.Font, e.CellBounds.Size)

                    If s1.Width > 5 Then
                        hl_rect.X = e.CellBounds.X + s1.Width - 5
                        hl_rect.Width = s2.Width - 6
                    Else
                        hl_rect.X = e.CellBounds.X + 2
                        hl_rect.Width = s2.Width - 6
                    End If

                    Dim hl_brush As SolidBrush
                    hl_brush = New SolidBrush(Color.Yellow)
                    e.Graphics.FillRectangle(hl_brush, hl_rect)
                    hl_brush.Dispose()
                    e.PaintContent(e.CellBounds)
                End If
            End If
        End If
    End Sub


    Private _findText As String = ""


    Private Sub dataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs)

        e.CellStyle.BackColor = Color.Aquamarine

    End Sub


    Public Property SelectedId As Int32
    Public Property SelectedName As String
    Public Property SelectedCode As String
    Public Property NoOfUnits As Int16
    Public Property ItemDetails As ItemDetailsModel

    Private Sub btnOk_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
        If DataGridViewItemDetails.CurrentRow IsNot Nothing Then
            SelectedId = DataGridViewItemDetails.CurrentRow.Cells("IdNo").Value
            ItemDetails = _service.GetRecordByIdNo(Of ItemDetailsModel)(SelectedId)
            'Dim ItemDetailsModel = _service.GetRecordByIdNo(Of ItemDetailsModel)(SelectedId)
            'ItemDetails = GlobalFunctions.ManualMap(ItemDetailsModel, ItemDetails)
            'ItemDetails = ItemDetailsModel
            'NoOfUnits = _service.CountRecordWithKey(Of Int32)("ItemDetailsUnit", "ItemDetailsIdNo", SelectedId) + 1
        End If
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btnCancel_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
    Private Sub dgv_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewItemDetails.CellEnter
        If Me.DataGridViewItemDetails.CurrentCell IsNot Nothing Then
            Me.DataGridViewItemDetails.CurrentCell.Style.BackColor = Color.White
            Me.DataGridViewItemDetails.CurrentCell.Style.ForeColor = Color.Black
        End If
    End Sub

    Private Sub DataGridViewItemDetailss_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles DataGridViewItemDetails.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            btnOk.PerformClick()
        End If
    End Sub

    Private Sub ItemBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles bsItemDetails.CurrentChanged

    End Sub
End Class


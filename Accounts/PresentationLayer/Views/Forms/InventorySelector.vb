Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub

Public Class InventorySelector
    Implements IInventorySelectorView

    Private _control As Control
    Private _service As Object
    Private _formPosition As Point
    Private _controlHeight As Int16
    Private _controlWidth As Int16
    Public SelectedInvIndex As Int32

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(productInventory As List(Of InventoryModel), ctrl As Control)
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()
        Me.ShowIcon = False
        Me.ControlBox = True
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.Text = ""
        Me.TopMost = False
        Dim formPoint As Point
        _control = ctrl
        _formPosition.X = formPoint.X
        _formPosition.Y = formPoint.Y
        _controlHeight = ctrl.Height
        _controlWidth = ctrl.Width

        Dim pnt As Point = ctrl.PointToScreen(New Point(0 + ctrl.Width, 0))
        _formPosition.X = pnt.X
        _formPosition.Y = pnt.Y

        DataGridViewProducts.MultiSelect = False
        _service = New AccountsService("Product")
        Dim productIdNo As Int32 = productInventory(0).ProductIdNo
        Dim productName As String = _service.GetField(Of String, Int32)(productIdNo, "Product", "IdNo", "ProductName")
        Dim baseUnitIdNo As String = _service.GetField(Of String, Int32)(productIdNo, "Product", "IdNo", "BaseUnitIdNo")
        lblProductName.Text = productName
        DataGridViewProducts.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        DataGridViewProducts.DefaultCellStyle.SelectionForeColor = Color.Black
        DataGridViewProducts.DataSource = productInventory

    End Sub

    Private Sub CFindForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetFormLocation()
    End Sub


    Private Sub SetFormLocation()
        Dim pnt As Point
        Dim formLocation As Point
        Dim screenRectangle As Rectangle
        screenRectangle = Screen.PrimaryScreen.WorkingArea
        StartPosition = FormStartPosition.Manual
        pnt = _formPosition
        If GlobalVariables.RightToLeftLayout Then
            formLocation = New Point(pnt.X - Width - _controlWidth, pnt.Y)
        Else
            formLocation = New Point(pnt.X, pnt.Y)
        End If
        Dim horizontalCoordinateOutsideScreen As Boolean = False
        If formLocation.X < 0 Then
            formLocation.X = 0
            horizontalCoordinateOutsideScreen = True
        End If

        If formLocation.X + Width > screenRectangle.Width Then
            formLocation.X = screenRectangle.Width - Width
            horizontalCoordinateOutsideScreen = True
            ' set to true if form will not fit on the right
        End If
        If formLocation.Y < 0 Then
            formLocation.Y = 0
        End If
        If formLocation.Y + Height > screenRectangle.Height Then
            formLocation.Y = formLocation.Y - Height
        Else
            If horizontalCoordinateOutsideScreen Then
                ' move down so as not to cover the field to be searched
                formLocation.Y = formLocation.Y + _controlHeight
            End If
        End If
        Location = formLocation
    End Sub


    Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs)
        _findText = ""
    End Sub

    'Private Sub InventorySelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'ISPDATADataSet.Product' table. You can move, or remove it, as needed.
    '    Me.ProductTableAdapter.Fill(Me.ISPDATADataSet.Product)
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

    'Private Sub txtFinder_TextChanged(sender As Object, e As EventArgs)
    '    Dim dao As New ProductDao
    '    If txtFinder.Text.Length() < 3 Then
    '        DataGridViewProducts.DataSource = Nothing
    '        'AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgText2Short")
    '    Else
    '        DataGridViewProducts.DataSource = dao.GetProductsBySearchString(txtFinder.Text)
    '        _findText = txtFinder.Text
    '    End If
    'End Sub

    Private Sub SubDataGridViewProducts_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs) Handles DataGridViewProducts.CellPainting
        If e.RowIndex > -1 AndAlso e.ColumnIndex > -1 AndAlso DataGridViewProducts.Columns(e.ColumnIndex).Name <> "Id" Then

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
    Public Property Inventory As InventoryModel

    'Public Property SelectedInventory As IInventoryView Implements IInventorySelectorView.SelectedInventory
    '    Get
    '        Throw New NotImplementedException()
    '    End Get
    '    Set(value As IInventoryView)
    '        Throw New NotImplementedException()
    '    End Set
    'End Property

    Private Sub btnOk_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
        If DataGridViewProducts.CurrentRow IsNot Nothing Then
            SelectedInvIndex = DataGridViewProducts.CurrentRow.Index
        End If
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btnCancel_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
    Private Sub dgv_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewProducts.CellEnter
        If Me.DataGridViewProducts.CurrentCell IsNot Nothing Then
            Me.DataGridViewProducts.CurrentCell.Style.BackColor = Color.White
            Me.DataGridViewProducts.CurrentCell.Style.ForeColor = Color.Black
        End If
    End Sub

    Private Sub DataGridViewProducts_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles DataGridViewProducts.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            btnOk.PerformClick()
        End If
    End Sub
End Class


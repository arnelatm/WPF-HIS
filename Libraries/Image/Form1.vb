Imports AATM.Libraries.ReadingImagesFromSqlServer.Classes

Public Class Form1
    Private _ops As DataOperations = New DataOperations
    Private bs As BindingSource = New BindingSource

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        '
        ' Load ListBox with IdNo and EmployeeName, no picture
        '
        ListBoxForButtonClickExample.DataSource = _ops.GetEmployees()

        cmdGetSingleImage.PerformClick()

        '
        ' Load ListBox with IdNo, EmployeeName and picture
        '
        ListBoxForLoadAlImageslExample.DataSource = _ops.GetEmployeesWithImagesFromList()

        '
        ' Load DataGridView via BindingSource set to a DataTable with IdNo, EmployeeName and picture
        '
        bs.DataSource = _ops.DataTable()
        dgvEmployeePictures.DataSource = bs
        dgvEmployeePictures.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        '
        ' Setup PictureBox for displaying current image of
        ' our BindingSource assigned to the DataGridView
        '
        Dim imageBinding As New Binding("Image", bs, "Picture")
        AddHandler imageBinding.Format, AddressOf BindImage
        PictureBoxForDataGridView.DataBindings.Add(imageBinding)

    End Sub

    Private Sub cmdGetSingleImage_Click(sender As Object, e As EventArgs) Handles cmdGetSingleImage.Click
        Dim primaryKey = CType(ListBoxForButtonClickExample.SelectedItem, Employee).IdNo
        PictureBoxForSingleClick.Image = _ops.GetImage(primaryKey)
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxForLoadAlImageslExample.SelectedIndexChanged
        PictureBoxForDynamicLoad.Image = CType(ListBoxForLoadAlImageslExample.SelectedItem, Employee).Picture
    End Sub

    Private Sub BindImage(ByVal sender As Object, ByVal e As ConvertEventArgs)

        If e.DesiredType Is GetType(Image) Then
            Dim ms As New IO.MemoryStream(CType(e.Value, Byte()))
            Dim Logo As Image = Image.FromStream(ms)
            e.Value = Logo
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String = Nothing

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
            PictureBoxForSingleClick.Image = Image.FromFile(strFileName)
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        _ops.SaveImage(idNo, PictureBoxForSingleClick.Image)
    End Sub

End Class
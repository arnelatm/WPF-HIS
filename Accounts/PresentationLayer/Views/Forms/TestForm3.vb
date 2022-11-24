Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.CBaseControlsLibrary

Public Class TestForm3
    Inherits System.Windows.Forms.Form

    Private WithEvents dataGridView1 As New CDataGridView()
    Private memoryCache As Cache

    ' Specify a connection string. Replace the given value with a
    ' valid connection string for a Northwind SQL Server sample
    ' database accessible to your system.
    Private connectionString As String = ConfigurationManager.ConnectionStrings("IGroupClinic").ConnectionString

    Private table As String = "ItemDetails"

    Private Sub VirtualJustInTimeDemo_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' Initialize the form.
        With Me
            .AutoSize = True
            .Controls.Add(Me.dataGridView1)
            .Text = "DataGridView virtual-mode just-in-time demo"
        End With

        ' Complete the initialization of the DataGridView.
        With Me.dataGridView1
            .Size = New Size(800, 250)
            .Dock = DockStyle.Fill
            .VirtualMode = True
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToOrderColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With

        ' Create a DataRetriever and use it to create a Cache object
        ' and to initialize the DataGridView columns and rows.
        Try
            Dim retriever As New DataRetriever(table, "Primary_Key,Item_Code,GTin,ItemNameEnglish,Price_Cash,Pack1,Pack2,Pack3", "IGroupClinic")
            memoryCache = New Cache(retriever, 16)
            For Each column As DataColumn In retriever.Columns
                dataGridView1.Columns.Add(
                    column.ColumnName, column.ColumnName)
            Next
            Me.dataGridView1.RowCount = retriever.RowCount
        Catch ex As SqlException
            MessageBox.Show("Connection could not be established. " &
                "Verify that the connection string is valid.")
            Application.Exit()
        End Try

        ' Adjust the column widths based on the displayed values.
        Me.dataGridView1.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.DisplayedCells)

    End Sub

    Private Sub dataGridView1_CellValueNeeded(
        ByVal sender As Object, ByVal e As DataGridViewCellValueEventArgs) _
        Handles dataGridView1.CellValueNeeded

        e.Value = memoryCache.RetrieveElement(e.RowIndex, e.ColumnIndex)

    End Sub

End Class
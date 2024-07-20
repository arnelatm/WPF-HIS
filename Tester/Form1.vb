Imports System.IO
Imports AATM.Libraries.CBaseControlsLibrary

Public Class Form1

    Private Countries As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Dim tb As New CustomDataTables

        ' Add any initialization after the InitializeComponent() call.
        Countries = tb.Countries

        AtmComboBox2.DataSource = Countries
        AtmComboBox2.SelectedIndex = -1


    End Sub

End Class
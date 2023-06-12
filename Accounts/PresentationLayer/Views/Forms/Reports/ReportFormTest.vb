Namespace PresentationLayer.Views.Forms.Reports

    Public Class ReportFormTest

        Public Sub New(ByVal fileName As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Text = fileName
            ReportFileName = fileName
            MainTableName = "Account"
            GetReportProperties()
            ReportDocument.DataSourceConnections.Clear()
            WindowState = FormWindowState.Maximized
            With CrystalReportViewer1
                .Visible = True
                .BringToFront()
                .ReportSource = ReportDocument
                .Refresh()
            End With
            btnQuit.Visible = True

        End Sub

        Public Property MainTableName As String

    End Class

End Namespace
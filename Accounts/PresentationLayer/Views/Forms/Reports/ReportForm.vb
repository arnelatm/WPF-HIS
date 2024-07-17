Imports System.Globalization
Imports AATM.Common
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Forms.Reports

    Public Class ReportForm
        Implements ICrPrintableReportView


        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Public Sub New(ByVal fileName As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Text = fileName
            'ReportFileName = fileName
            MainTableName = "Account"
            'GetReportProperties()
            'ReportDocument.DataSourceConnections.Clear()
            'WindowState = FormWindowState.Maximized
            'With CrystalReportViewer1
            '    .Visible = True
            '    .BringToFront()
            '    .ReportSource = ReportDocument
            '    .Refresh()
            'End With
        End Sub

        Public Property MainTableName As String
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property DataFilter As String Implements IView.DataFilter

        Private Property FormCulture As CultureInfo Implements IView.FormCulture
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As CultureInfo)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Event PrintReport As ICrPrintableReportView.PrintReportEventHandler Implements ICrPrintableReportView.PrintReport
    End Class

End Namespace
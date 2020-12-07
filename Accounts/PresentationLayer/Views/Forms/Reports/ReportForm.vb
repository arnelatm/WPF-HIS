Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms.Reports

    Public Class ReportForm

        Public Sub New(ByVal fileName As String, ByVal ParamArray args() As Object)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Text = fileName
            ReportFileName = fileName
            MainTableName = "Account"
            GetReportProperties()
            For i = 0 To args.Length - 1 Step 2
                Dim value = args(i)
                Report.SetParameterValue(args(i + 1).ToString(), ConvertObjectToType(value))
            Next
            Report.DataSourceConnections.Clear()
            ProcessReport()

        End Sub

        Public Property MainTableName As String

    End Class

End Namespace
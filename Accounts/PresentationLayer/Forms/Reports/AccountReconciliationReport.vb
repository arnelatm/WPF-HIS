Imports System.Configuration

Namespace PresentationLayer.Forms.Reports

    Public Class AccountReconciliationReport

        Public Sub New(ByVal idNo As Int32)

            InitializeComponent()

            'AddHandler OkButtonClicked, AddressOf OnOkButtonClicked
            'myReportDocument.SetDatabaseLogon("user", "pass", "dbserver", "database1"

            Dim reportPaths As String = ConfigurationManager.AppSettings.Get("ReportPaths")

            Report.Load(reportPaths & "Account Reconciliation Report.rpt")
            Report.SetParameterValue("ReconciliationNumber", idNo)
            Report.DataSourceConnections.Clear()
            Report.SetDatabaseLogon("iGroupAdmin", "igss@123", "IBN-SERVER", "ISPDATA")
            ProcessReport()

        End Sub

        Private Sub btnOk_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Close()
        End Sub

        'Private Sub AccountReconciliationReport_Load() Handles MyBase.Load
        '    Dim dateToday As DateTime
        '    dateToday = Now

        '    ' Only include the path to the dbf file not the file itself in the connection string
        '    'Dim ConnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Data\Test-Databases\DBase;Extended Properties=dBase III"
        '    'Dim ConnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Sample\abc.dbf;Extended Properties=abc.dbf"
        '    Dim ConnString As String = "Provider=vfpoledb;Data Source=\\IBNSINAP\CLINIC\Accounts\SUPPLIER.DBF;Collating Sequence=machine;"
        '    Dim conn As New OleDbConnection(ConnString)
        '    ' Select the file to open here
        '    Dim cmdString As String = "select count(*) from Supplier"
        '    Dim cmd As New OleDbCommand(cmdString, conn)
        '    conn.Open()
        '    cmd.ExecuteScalar()
        '    cmdString = "select suppcode, suppname from Supplier"
        '    cmd = New OleDbCommand(cmdString, conn)
        '    Dim reader As OleDbDataReader = cmd.ExecuteReader()
        '    While reader.Read()

        '    End While
        '    conn.Close()
        'End Sub

        'Private Sub OnOkButtonClicked()
        '    cSuppCode = cacSupplierCode.GetValue()
        '        'Report.SetDatabaseLogon("iGroupAdmin", "igss@123", "ibn-server", "IGroupClinic")
        '        Report.Load("Reports\Statement of Accounts Payable Arabic.rpt")
        '        Report.SetParameterValue("SupplierCode", cSuppCode)
        '        Report.SetParameterValue("BeginningDate", dtpBeginningDate.Value)
        '        Report.SetParameterValue("EndingDate", dtpEndingDate.Value)
        '        ProcessReport()
        '    End If
        'End Sub

    End Class

End Namespace
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports AATM.Libraries

Namespace PresentationLayer.Forms.Reports

    Public Class ArStatementReport

        Private ReadOnly _customerNames As New List(Of String)
        Private ReadOnly _customerCodes As New List(Of String)

        Public Sub New()

            InitializeComponent()

            AddHandler MyBase.OkButtonClicked, AddressOf OnOkButtonClicked

        End Sub

        Private Sub ArStatementReport_Load() Handles MyBase.Load
            Dim dateToday As DateTime
            dateToday = Now
            dtpBeginningDate.Value = DateSerial(dateToday.Year, 1, 1)
            dtpEndingDate.Value = Now
            dtpBeginningDate.Refresh()
            dtpEndingDate.Refresh()

            ' Only include the path to the dbf file not the file itself in the connection string
            'Dim ConnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Data\Test-Databases\DBase;Extended Properties=dBase III"
            'Dim ConnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Sample\abc.dbf;Extended Properties=abc.dbf"
            Dim ConnString As String = "Provider=vfpoledb;Data Source=\\IBNSINAP\CLINIC\Accounts\Customer.DBF;Collating Sequence=machine;"
            Dim conn As New OleDbConnection(ConnString)
            ' Select the file to open here
            Dim cmdString As String = "select count(*) from Customer"
            Dim cmd As New OleDbCommand(cmdString, conn)
            conn.Open()
            cmd.ExecuteScalar()
            Dim cCustCode As String
            Dim cCustName As String
            cmdString = "select CustCode, CustName from Customer"
            cmd = New OleDbCommand(cmdString, conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            While reader.Read()
                cCustCode = reader("CustCode")
                cCustName = reader("CustName")
                _customerNames.Add(cCustCode)
                _customerCodes.Add(cCustCode)
                cboCustomerCode.Items.Add(cCustCode + "-" + cCustName)
            End While
            conn.Close()
            cboCustomerCode.Sorted = True
        End Sub

        Private Sub OnOkButtonClicked()
            If IsNothing(dtpBeginningDate.Value) Then
                MessageBox.Show(Languages.Messages.PleaseEnterTheBeginningDateForTheReport)
            ElseIf IsNothing(dtpEndingDate.Value) Then
                MessageBox.Show(Languages.Messages.PleaseEnterTheEndingDateForTheReport)
            ElseIf dtpBeginningDate.Value > dtpEndingDate.Value Then
                MessageBox.Show(Languages.Messages.SorryBeginningDateCanTBeLaterThanEndingDate)
            ElseIf dtpBeginningDate.Value < DateSerial(2018, 1, 1) Then
                MessageBox.Show(Languages.Messages.DateCanTBeLessThan + " 2018/01/01!")
            ElseIf dtpEndingDate.Value > Today Then
                MessageBox.Show(Languages.Messages.DateCanTBeGreaterThanTodaySDate)
            Else
                Dim cCustCode As String
                cCustCode = cboCustomerCode.Text.Substring(0, 4)
                'Report.SetDatabaseLogon("iGroupAdmin", "igss@123", "ibn-server", "IGroupClinic")
                Report.Load("\\IBN-SERVER\ISP\Accounts\Reports\Statement of Accounts Receivable Arabic.rpt")
                Report.SetParameterValue("CustomerCode", cCustCode)
                Report.SetParameterValue("BeginningDate", dtpBeginningDate.Value)
                Report.SetParameterValue("EndingDate", dtpEndingDate.Value)
                ProcessReport()
            End If
        End Sub

    End Class

End Namespace
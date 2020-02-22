Imports System.Data.OleDb
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub.GlobalFunctions

Namespace PresentationLayer.Forms.Reports

    Public Class ApStatementReport

        Public Sub New()

            InitializeComponent()

            AddHandler OkButtonClicked, AddressOf OnOkButtonClicked

        End Sub

        Private Sub ApStatementReport_Load() Handles MyBase.Load
            Dim dateToday As DateTime
            dateToday = Now
            dtpBeginningDate.Value = GbDateSerial(dateToday.Year, 1, 1)
            dtpEndingDate.Value = Now
            dtpBeginningDate.Refresh()
            dtpEndingDate.Refresh()

            ' Only include the path to the dbf file not the file itself in the connection string
            'Dim ConnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Data\Test-Databases\DBase;Extended Properties=dBase III"
            'Dim ConnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Sample\abc.dbf;Extended Properties=abc.dbf"
            Dim ConnString As String = "Provider=vfpoledb;Data Source=\\IBNSINAP\CLINIC\Accounts\SUPPLIER.DBF;Collating Sequence=machine;"
            Dim conn As New OleDbConnection(ConnString)
            ' Select the file to open here
            Dim cmdString As String = "select count(*) from Supplier"
            Dim cmd As New OleDbCommand(cmdString, conn)
            conn.Open()
            cmd.ExecuteScalar()
            cmdString = "select suppcode, suppname from Supplier"
            cmd = New OleDbCommand(cmdString, conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim cLookupData As New ClassesLibrary.LookupData
                cLookupData.Name = reader("SuppCode")
                cLookupData.Code = reader("SuppName")
                cacSupplierCode.Items.Add(cLookupData)
            End While
            conn.Close()
        End Sub

        Private Sub OnOkButtonClicked()
            If IsNothing(dtpBeginningDate.Value) Then
                MessageBox.Show(Languages.Messages.PleaseEnterTheBeginningDateForTheReport)
            ElseIf IsNothing(dtpEndingDate.Value) Then
                MessageBox.Show(Languages.Messages.PleaseEnterTheEndingDateForTheReport)
            ElseIf dtpBeginningDate.Value > dtpEndingDate.Value Then
                MessageBox.Show(Languages.Messages.SorryBeginningDateCanTBeLaterThanEndingDate)
            ElseIf dtpBeginningDate.Value < GbDateSerial(2018, 1, 1) Then
                MessageBox.Show(Languages.Messages.DateCanTBeLessThan + " 2018/01/01!")
            ElseIf dtpEndingDate.Value > Today Then
                MessageBox.Show(Languages.Messages.DateCanTBeGreaterThanTodaySDate)
            Else
                Dim cSuppCode As String
                cSuppCode = cacSupplierCode.GetValue()
                'Report.SetDatabaseLogon("iGroupAdmin", "igss@123", "ibn-server", "IGroupClinic")
                Report.Load("\\IBN-SERVER\ISP\Accounts\Reports\Statement of Accounts Payable Arabic.rpt")
                Report.SetParameterValue("SupplierCode", cSuppCode)
                Report.SetParameterValue("BeginningDate", dtpBeginningDate.Value)
                Report.SetParameterValue("EndingDate", dtpEndingDate.Value)
                ProcessReport()
            End If
        End Sub

    End Class

End Namespace
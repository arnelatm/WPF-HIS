' GeneralJournal business object as seen by the Service client.
Imports System.Dynamic
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Forms
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class GeneratePayrollBankCsvPresenter(Of TM As New)
        Inherits PresenterNew(Of IPayrollView, TM)

        Private _nfi As NumberFormatInfo

        Public Sub New(view As IPayrollView)
            MyBase.New(view)
            Service = New AccountsService("Payroll")
            TableName = "Payroll"
            SortOrderKey = "EndDate"
            WithTreeView = False
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            AddHandler view.GenerateCsvFile, AddressOf OnGenerateCsvFile
        End Sub

        Public Sub OnGenerateCsvFile(idNo As Int32)
            Dim csvFilePath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\CSV.csv" 'Path to create or existing file
            Dim outFile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(csvFilePath, False)
            Dim sortKey As String = "EmpName"
            Dim fieldList As String = $"BankName,AcctNo,NetPay,Notes,EmpName,IqamaNo,Address,SalaryEr,Housing,OtherWage,Deductions"
            Dim payroll As Object = Service.GetSpRecords("fnGetBankPayrollCsv", fieldList, sortKey, idNo.ToString())
            outFile.WriteLine($"bankname,acctno,netpay,notes,empname,iqamano,address,salaryer,housing,otherwage,deductions")
            Dim fieldCount As Int32 = 11
            Dim i As Int32 = 0
            Dim lineText As String = ""
            Dim lineNumber As Int32 = 2
            Dim errors As String = ""
            Dim errorNumber As Int32 = 0
            For Each item In payroll
                If i = 11 Then
                    outFile.WriteLine(lineText)
                    lineText = item.ToString()
                    lineNumber += 1
                    i = 0
                Else
                    If i = 0 Then
                        lineText = item.ToString()
                    Else
                        If TypeOf item Is Decimal Then
                            lineText += "," & Math.Round(item, 2).ToString()
                        Else
                            lineText += "," & item.ToString()
                        End If
                    End If
                End If
                Select Case i + 1
                    Case 1
                        If item Is Nothing Or item.ToString() = "" Then
                            errorNumber += 1
                            errors += errorNumber.ToString() + ". Invalid Bank Code for line number " + lineNumber.ToString() + "." + Environment.NewLine
                        End If
                    Case 2
                        If item Is Nothing Or item.ToString() = "" Then
                            errorNumber += 1
                            errors += errorNumber.ToString() + ". Missing IBAN Number for line number " + lineNumber.ToString() + "." + Environment.NewLine
                        ElseIf Trim(item.ToString()).Length <> 24 Then
                            errorNumber += 1
                            errors += errorNumber.ToString() + ". Invalid IBAN Number <" + item.ToString() + "> for line number " + lineNumber.ToString() + "." + Environment.NewLine
                        End If
                    Case 6
                        If item Is Nothing Or item.ToString() = "" Then
                            errorNumber += 1
                            errors += errorNumber.ToString() + ". Missing National ID Number for line number " + lineNumber.ToString() + "." + Environment.NewLine
                        ElseIf Trim(item.ToString()).Length <> 10 Then
                            errorNumber += 1
                            errors += errorNumber.ToString() + ". Invalid National ID number <" + item.ToText() + "> for line number " + lineNumber.ToString() + "." + Environment.NewLine
                        End If
                End Select
                i += 1
            Next
            outFile.Close()
            Console.WriteLine(My.Computer.FileSystem.ReadAllText(csvFilePath))
            Messaging.Show(True, "MsgShowCsvOutputFile")
            If lineText <> "" Then
                MessageBox.Show("[ " + errorNumber.ToString() + " Errors Found in Output file see list below. ]" + Environment.NewLine + errors)
            End If
        End Sub

    End Class

End Namespace
Imports System.Data.SqlClient
Imports System.IO
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Presenters

    Public Class EmployeeIdPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IEmployeeIdListView, TM)

        Protected DtInsertTable As New DataTable

        Public Sub New(itemView As IEmployeeIdListView)
            MyBase.New(itemView)
            Service = New AccountsService("Employee")
            TableName = "Employee"
            TreeViewMainField = "EmployeeName"
            TreeViewSecondaryField = "EmployeeCode"
            SortOrderKey = "EmployeeName"
            WithTreeView = False
            DisableSaveMemento = True

            DtInsertTable.Columns.Add("EmployeeidNo", GetType(Int32))
            DtInsertTable.Columns.Add("TransactionNumber", GetType(Int32))

            AddHandler View.EmployeeIdCheckedEvent, AddressOf OnEmployeeIdCheckedEvent
            AddHandler View.ClearAllEmployee, AddressOf OnClearAllEmployee
        End Sub

        Private Sub OnEmployeeIdCheckedEvent(sender As Object)
            If EditMode Or AddMode Then
                sender.Print = Not sender.Print
            End If
        End Sub

        Public Function GetEmployeeIdList() As List(Of EmployeeIdView)
            Dim records As List(Of EmployeeIdModel) = Service.GetEmployeeIdList()
            Dim data As New List(Of EmployeeIdView)
            GlobalVariables.Mapper.Map(records, data)
            Return data
        End Function

        Private Sub OnClearAllEmployee(ByVal bsEmployeeIdList As BindingSource, clear As Boolean)
            For Each item In bsEmployeeIdList
                item.Print = clear
            Next item
        End Sub

        Public Overrides Sub GoPrintRecord()
            Dim retVal As Int32
            Dim nTransactionNumber = Service.GetLastSeriesNumber("IdPrinting")
            Dim saveImagePath = "C:\temp\"
            DtInsertTable.Clear()
            If nTransactionNumber > 0 Then
                For Each item In View.EmployeeIdList
                    If item.Print Then
                        Dim workRow As DataRow
                        workRow = DtInsertTable.NewRow()
                        workRow("EmployeeIdNo") = item.IdNo
                        workRow("TransactionNumber") = nTransactionNumber
                        DtInsertTable.Rows.Add(workRow)

                        Using ms As MemoryStream = New MemoryStream()
                            If item.Picture IsNot Nothing Then
                                Dim saveImage As New Bitmap(item.Picture)
                                Dim saveImageName As String = "Employee" + item.IdNo.ToString.Trim() + ".jpg"
                                saveImage.Save(saveImagePath + saveImageName, Imaging.ImageFormat.Jpeg)
                                saveImage.Dispose()
                            End If
                        End Using

                    End If
                Next
                Dim insertReturnValue As Int32
                If DtInsertTable.Rows.Count > 0 Then
                    insertReturnValue = Service.EmployeeIdInsertTvp(DtInsertTable)
                    If insertReturnValue >= 0 Then
                        retVal = insertReturnValue
                    Else
                        retVal = -1
                    End If
                Else
                    retVal = 0
                End If
                If retVal > 0 Then
                    For Each item In DtInsertTable.Rows

                    Next
                    Dim cForm
                    cForm = New ReportForm("Employee ID Printing Report.Rpt", nTransactionNumber, "TransactionNumber")
                    cForm.Show()
                End If
            End If
        End Sub

    End Class

End Namespace
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class SalesJournalPresenter
        Inherits AccountsPresenter(Of ISalesJournalView, SalesJournalModel)

        Protected DtInsertTable As New DataTable
        Protected DtSalesDepositTypeInsertTable As New DataTable
        Protected DtSalesDepositTypeUpdateTable As New DataTable
        Protected DtUpdateTable As New DataTable

        Private ReadOnly _salesDepositModel As New ModelAccounts("SalesDeposit")
        Private ReadOnly _salesJournalItemModel As New ModelAccounts("SalesJournalItem")

        Private _depositTypesModel As List(Of DepositTypeModel)
        Private ReadOnly _oldSalesDepositTypeItem As List(Of SalesDepositModel)
        Private ReadOnly _vatRate As Decimal '= GlobalFunctions.GetVatPercentage()

        Public Sub New(view As ISalesJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("SalesJournal")
            TableName = "SalesJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New SalesJournalModel()
            DataModel = New SalesJournalModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
            _vatRate = My.Settings.VatRate / 100D
            DepositTypesModel = GetDepositTypeModel()

            DtInsertTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Credit", GetType(Decimal))
            DtInsertTable.Columns.Add("Debit", GetType(Decimal))
            DtInsertTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Notes", GetType(String))
            DtInsertTable.Columns.Add("RevCostCenterIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtUpdateTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Credit", GetType(Decimal))
            DtUpdateTable.Columns.Add("Debit", GetType(Decimal))
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Notes", GetType(String))
            DtUpdateTable.Columns.Add("RevCostCenterIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))

            DtSalesDepositTypeInsertTable.Columns.Add("DepositTypeIdNo", GetType(Int16))
            DtSalesDepositTypeInsertTable.Columns.Add("DepositAmount", GetType(Decimal))
            DtSalesDepositTypeInsertTable.Columns.Add("SaleAmount", GetType(Decimal))
            DtSalesDepositTypeInsertTable.Columns.Add("SalesJournalIdNo", GetType(Int32))
            DtSalesDepositTypeInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtSalesDepositTypeUpdateTable.Columns.Add("DepositTypeIdNo", GetType(Int16))
            DtSalesDepositTypeUpdateTable.Columns.Add("DepositAmount", GetType(Decimal))
            DtSalesDepositTypeUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtSalesDepositTypeUpdateTable.Columns.Add("SaleAmount", GetType(Decimal))
            DtSalesDepositTypeUpdateTable.Columns.Add("SalesJournalIdNo", GetType(Int32))
            DtSalesDepositTypeUpdateTable.Columns.Add("Sequence", GetType(Int16))

        End Sub

        Public Property DepositTypesModel As List(Of DepositTypeModel)
            Get
                Return _depositTypesModel
            End Get
            Set
                _depositTypesModel = Value
            End Set
        End Property

        Public Function GetJournalItems(journalIdNo As Int32) As List(Of JournalItemModel)
            Return _salesJournalItemModel.GetRecordsWithIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Function

        Public Function GetSalesDeposits(salesDepositTypeIdNo As Int32) As List(Of SalesDepositModel)
            Return _salesDepositModel.GetRecordsWithIdNo(Of SalesDepositModel)(salesDepositTypeIdNo, "Sequence")
        End Function

        Public Function GetDepositType(ByVal pDepositTypeIdNo As Int16)
            Dim depositType As New DepositTypeModel
            For Each item As DepositTypeModel In DepositTypesModel
                If item.IdNo = pDepositTypeIdNo Then
                    depositType = item
                    Exit For
                End If
            Next
            Return depositType
        End Function

        Public Sub OnBeforeAdd() Handles MyBase.BeforeAdd
            View.TransactionDate = Date.Now()
            If View.JournalItems IsNot Nothing Then
                View.JournalItems.Clear()
            Else
                View.JournalItems = New List(Of JournalItemView)
            End If
            If View.SalesDeposits IsNot Nothing Then
                View.SalesDeposits.Clear()
            Else
                View.SalesDeposits = New List(Of SalesDepositView)
            End If
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            MakeJournalItems()
            SetAsideJournalItems()
            Dim nRowCount As Integer
            nRowCount = 1
            For Each sc In View.SalesDeposits
                If sc.SaleAmount <> 0 Or sc.DepositAmount <> 0 Then
                    Dim workRow As DataRow
                    If sc.IdNo <= 0 Then
                        workRow = DtSalesDepositTypeInsertTable.NewRow()
                    Else
                        workRow = DtSalesDepositTypeUpdateTable.NewRow()
                        workRow("IdNo") = sc.IdNo
                    End If
                    workRow("DepositTypeIdNo") = sc.DepositTypeIdNo
                    workRow("SalesJournalIdNo") = View.IdNo
                    workRow("Sequence") = nRowCount
                    workRow("SaleAmount") = sc.SaleAmount
                    workRow("DepositAmount") = sc.DepositAmount
                    If sc.IdNo <= 0 Then
                        DtSalesDepositTypeInsertTable.Rows.Add(workRow)
                    Else
                        DtSalesDepositTypeUpdateTable.Rows.Add(workRow)
                    End If
                    nRowCount += 1
                    View.TotalDebits += sc.SaleAmount
                End If
            Next
            View.TotalCredits = View.TotalDebits
        End Sub

        Public Sub OnBeforeValidate() Handles MyBase.BeforeValidate
            View.TotalDebits = 0
            View.TotalCredits = 0
            For Each ji In View.SalesDeposits
                View.TotalDebits += ji.DepositAmount
            Next
            View.TotalCredits = View.TotalDebits
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordUpdatedSuccessfully, MyBase.RecordAddedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_salesJournalItemModel, DtUpdateTable, DtInsertTable, passedValue, "JournalIdNo")
            If retVal > 0 Then
                retVal = UpdateChildData(_salesDepositModel, DtSalesDepositTypeUpdateTable, DtSalesDepositTypeInsertTable, passedValue, "SalesJournalIdNo")
            End If
            If retVal >= 0 Then
                GlobalVariables.Mapper.Map(View, DataModel)
                retVal = ModelPresenter.UpdateGlReferenceNumber(DataModel)
            End If
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Model.GetRecordFieldWithKeyG(Of DateTime?)("Sales Journal", "LastPosting", "TransactionName", "LastPostingDate")
                If IsDateRangeValid("Sales Journal", View.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
                    retValue = False
                End If
            End If
            Return retValue
        End Function

        Private Sub MakeJournalItems()
            Dim oldJournalItems = GetJournalItems(View.IdNo)
            Dim counter As Integer = 0
            View.TotalSales = 0
            For Each item In View.SalesDeposits
                View.TotalSales = View.TotalSales + item.SaleAmount
            Next
            MakeSalesJournal(oldJournalItems, counter, View.AccountIdNo, 0, View.TotalSales, "Sales", Messaging.TranslateCaption("Sales"))
            For Each item As SalesDepositView In View.SalesDeposits
                If item.DepositTypeIdNo <> 0 Then
                    Dim depositType = _depositTypesModel.Find(Function(c) c.IdNo = item.DepositTypeIdNo())
                    MakeSalesJournal(oldJournalItems, counter, depositType.AccountIdNo, item.DepositAmount, 0, depositType.DepositTypeName, depositType.DepositTypeNameAra)
                    If depositType.WithBankCharges Then
                        MakeSalesJournal(oldJournalItems, counter, depositType.BankChargesAccountIdNo, item.ActualBankCharge, 0, depositType.DepositTypeName, depositType.DepositTypeNameAra)
                        MakeSalesJournal(oldJournalItems, counter, depositType.BankChargesVatAccountIdNo, item.ActualBankChargeVat, 0, depositType.DepositTypeName, depositType.DepositTypeNameAra)
                    End If
                End If
            Next
            If counter < View.JournalItems.Count() Then
                While View.JournalItems.Count() > counter
                    View.JournalItems.RemoveAt(counter)
                End While
            End If
        End Sub

        Private Sub MakeSalesJournal(ByRef oldJournalItems As List(Of JournalItemModel), ByRef counter As Integer,
                                     pAccountIdNo As Int16, debitAmount As Decimal, creditAmount As Decimal, note As String, noteAra As String)
            If debitAmount <> 0 Or creditAmount <> 0 Then
                counter += 1
                If counter <= oldJournalItems.Count() Then
                    View.JournalItems.Item(counter - 1).AccountIdNo = pAccountIdNo
                    View.JournalItems.Item(counter - 1).Debit = debitAmount
                    View.JournalItems.Item(counter - 1).Credit = creditAmount
                    View.JournalItems.Item(counter - 1).Sequence = counter
                    View.JournalItems.Item(counter - 1).Notes = RTrim(LTrim(note)) + IIf(note = noteAra, "", "-" + noteAra)
                Else
                    Dim ji As New JournalItemView With {
                            .AccountIdNo = pAccountIdNo,
                            .Credit = creditAmount,
                            .Debit = debitAmount,
                            .IdNo = 0,
                            .JournalIdNo = View.IdNo,
                            .Notes = Trim(note + IIf(note = noteAra, "", "-" + noteAra)),
                            .Sequence = counter
                            }
                    View.JournalItems.Add(ji)
                End If
            End If
        End Sub

        Private Sub SetAsideJournalItems()
            If DtInsertTable IsNot Nothing Then
                DtInsertTable.Clear()
            End If
            If DtUpdateTable IsNot Nothing Then
                DtUpdateTable.Clear()
            End If
            If DtSalesDepositTypeInsertTable IsNot Nothing Then
                DtSalesDepositTypeInsertTable.Clear()
            End If
            If DtSalesDepositTypeUpdateTable IsNot Nothing Then
                DtSalesDepositTypeUpdateTable.Clear()
            End If
            Dim nRowCount As Integer = 1
            For Each ji In View.JournalItems
                ' loop through the journal entries but ignore zero values
                Dim workRow As DataRow
                If ji.IdNo <= 0 Then
                    workRow = DtInsertTable.NewRow()
                Else
                    workRow = DtUpdateTable.NewRow()
                    workRow("IdNo") = ji.IdNo
                End If
                workRow("JournalIdNo") = View.IdNo
                workRow("Sequence") = nRowCount
                workRow("AccountIdNo") = ji.AccountIdNo
                workRow("Debit") = ji.Debit
                workRow("Credit") = ji.Credit
                workRow("RevCostCenterIdNo") = ji.RevCostCenterIdNo
                workRow("Notes") = If(ji.Notes, "")
                If ji.IdNo <= 0 Then
                    DtInsertTable.Rows.Add(workRow)
                Else
                    DtUpdateTable.Rows.Add(workRow)
                End If
                nRowCount += 1
            Next
        End Sub

        Public Function GetActualBankCharge(ByVal saleAmount As Decimal, ByVal depositAmount As Decimal) As Decimal
            Return Math.Round((saleAmount - depositAmount) / (1D + _vatRate), 2)
        End Function

        Public Function GetActualBankChargeVat(saleAmount As Decimal, depositAmount As Decimal, actualBankCharge As Decimal) As Decimal
            Return (saleAmount - depositAmount - actualBankCharge)
        End Function

        Public Function GetSupplierOpenInvoices(ByVal supplierIdNo As Int32) As List(Of SalesDepositModel)
            Return ModelPresenter.GetSupplierOpenInvoices(supplierIdNo)
        End Function

        Public Overrides Sub GoPrintRecord()
            Dim totalCreditAmount As String
            Dim currencies As New List(Of CurrencyInfo)()
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim language As String
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-"))
            currencies.Add(New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia))
            If language = "ar" Then
                totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToArabic()
            Else
                totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToEnglish()
            End If
            View.TotalCredits = 0
            For Each item In View.JournalItems
                View.TotalCredits = View.TotalCredits + item.Credit
            Next
            Dim cForm As New ReportForm("Sales Journal.Rpt", View.IdNo, "SalesJournalIdNo", totalCreditAmount, "TotalLineAmountInWords", language, "Language")
            cForm.Show()
        End Sub

    End Class

End Namespace
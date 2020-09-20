Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Forms
Imports AATM.Accounts.PresentationLayer.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class SalesJournalPresenter
        Inherits AccountsPresenter(Of ISalesJournalView, SalesJournalModel)

        Protected DtInsertTable As New DataTable
        Protected DtSalesCashInsertTable As New DataTable
        Protected DtSalesCashUpdateTable As New DataTable
        Protected DtUpdateTable As New DataTable

        Private ReadOnly _salesCashItemModel As New ModelAccounts("SalesCashItem")
        Private ReadOnly _salesJournalItemModel As New ModelAccounts("SalesJournalItem")

        Private _cashCodesModel As List(Of CashCodeModel)
        Private _oldSalesCashItem As List(Of SalesCashItemModel)
        Private ReadOnly _vatRate As Decimal = GlobalFunctions.GetVatPercentage()

        Public Sub New(view As ISalesJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("SalesJournal")
            TableName = "SalesJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New SalesJournalModel()
            DataModel = New SalesJournalModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

            CashCodesModel = GetCashCodesModel()

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

            DtSalesCashInsertTable.Columns.Add("CashCode", GetType(String))
            DtSalesCashInsertTable.Columns.Add("DepositAmount", GetType(Decimal))
            DtSalesCashInsertTable.Columns.Add("SaleAmount", GetType(Decimal))
            DtSalesCashInsertTable.Columns.Add("SalesJournalIdNo", GetType(Int32))
            DtSalesCashInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtSalesCashUpdateTable.Columns.Add("CashCode", GetType(String))
            DtSalesCashUpdateTable.Columns.Add("DepositAmount", GetType(Decimal))
            DtSalesCashUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtSalesCashUpdateTable.Columns.Add("SaleAmount", GetType(Decimal))
            DtSalesCashUpdateTable.Columns.Add("SalesJournalIdNo", GetType(Int32))
            DtSalesCashUpdateTable.Columns.Add("Sequence", GetType(Int16))

        End Sub

        Public Property CashCodesModel As List(Of CashCodeModel)
            Get
                Return _cashCodesModel
            End Get
            Set
                _cashCodesModel = Value
            End Set
        End Property

        'Public Function SalesCashItemDataIsValid() As Boolean
        '    Return True
        'End Function

        Public Function GetJournalItems(journalIdNo As Int32) As List(Of JournalItemModel)
            Return _salesJournalItemModel.GetRecordsWithIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Function

        Public Function GetSalesCashItems(salesCashIdNo As Int32) As List(Of SalesCashItemModel)
            Return _salesCashItemModel.GetRecordsWithIdNo(Of SalesCashItemModel)(salesCashIdNo, "Sequence")
        End Function

        'Public Sub OnAfterSave() Handles MyBase.AfterSave
        '    If IsEmpty(View.ReferenceNo) Then
        '        UpdateGlReferenceNumber()
        '    End If
        'End Sub

        Public Sub OnBeforeAdd() Handles MyBase.BeforeAdd
            View.TransactionDate = Date.Now()
            If View.JournalItems IsNot Nothing Then
                View.JournalItems.Clear()
            Else
                View.JournalItems = New List(Of JournalItemView)
            End If
            If View.SalesCashItems IsNot Nothing Then
                View.SalesCashItems.Clear()
            Else
                View.SalesCashItems = New List(Of SalesCashItemView)
            End If
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            MakeJournalItems()
            SetAsideJournalItems()
            Dim nRowCount As Integer
            nRowCount = 1
            For Each sc In View.SalesCashItems
                If sc.SaleAmount <> 0 Or sc.DepositAmount <> 0 Then
                    Dim workRow As DataRow
                    If sc.IdNo <= 0 Then
                        workRow = DtSalesCashInsertTable.NewRow()
                    Else
                        workRow = DtSalesCashUpdateTable.NewRow()
                        workRow("IdNo") = sc.IdNo
                    End If
                    workRow("CashCode") = sc.CashCode
                    workRow("SalesJournalIdNo") = View.IdNo
                    workRow("Sequence") = nRowCount
                    workRow("SaleAmount") = sc.SaleAmount
                    workRow("DepositAmount") = sc.DepositAmount
                    If sc.IdNo <= 0 Then
                        DtSalesCashInsertTable.Rows.Add(workRow)
                    Else
                        DtSalesCashUpdateTable.Rows.Add(workRow)
                    End If
                    nRowCount = nRowCount + 1
                    View.TotalDebits += sc.SaleAmount
                End If
            Next
            View.TotalCredits = View.TotalDebits
        End Sub

        Public Sub OnBeforeValidate() Handles MyBase.BeforeValidate
            View.TotalDebits = 0
            View.TotalCredits = 0
            For Each ji In View.SalesCashItems
                View.TotalDebits += ji.DepositAmount
            Next
            View.TotalCredits = View.TotalDebits
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordUpdatedSuccessfully, MyBase.RecordAddedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_salesJournalItemModel, DtUpdateTable, DtInsertTable, passedValue, "JournalIdNo")
            If retVal > 0 Then
                retVal = UpdateChildData(_salesCashItemModel, DtSalesCashUpdateTable, DtSalesCashInsertTable, passedValue, "SalesJournalIdNo")
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
            For Each item In View.SalesCashItems
                View.TotalSales = View.TotalSales + item.SaleAmount
            Next
            MakeSalesJournal(oldJournalItems, counter, View.AccountIdNo, 0, View.TotalSales, "Sales", Messaging.TranslateCaption("Sales"))
            For Each item As SalesCashItemView In View.SalesCashItems
                If item.CashCode IsNot Nothing Then
                    Dim cashCode = _cashCodesModel.Find(Function(c) c.CashCode.Trim() = item.CashCode.Trim())
                    MakeSalesJournal(oldJournalItems, counter, cashCode.AccountIdNo, item.DepositAmount, 0, cashCode.CashName, cashCode.CashNameAra)
                    MakeSalesJournal(oldJournalItems, counter, cashCode.BankChargesAccountIdNo, item.ActualBankCharge, 0, cashCode.CashName, cashCode.CashNameAra)
                    MakeSalesJournal(oldJournalItems, counter, cashCode.BankChargesVatAccountIdNo, item.ActualBankChargeVat, 0, cashCode.CashName, cashCode.CashNameAra)
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
                counter = counter + 1
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
            If DtSalesCashInsertTable IsNot Nothing Then
                DtSalesCashInsertTable.Clear()
            End If
            If DtSalesCashUpdateTable IsNot Nothing Then
                DtSalesCashUpdateTable.Clear()
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
                nRowCount = nRowCount + 1
            Next
        End Sub

        Public Function GetActualBankCharge(ByVal saleAmount As Decimal, ByVal depositAmount As Decimal) As Decimal
            Return Math.Round((saleAmount - depositAmount) / (1D + _vatRate), 2)
        End Function

        Public Function GetActualBankChargeVat(saleAmount As Decimal, depositAmount As Decimal, actualBankCharge As Decimal) As Decimal
            Return (saleAmount - depositAmount - actualBankCharge)
        End Function

        Public Function GetSupplierOpenInvoices(ByVal supplierIdNo As Int32) As List(Of SalesCashItemModel)
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
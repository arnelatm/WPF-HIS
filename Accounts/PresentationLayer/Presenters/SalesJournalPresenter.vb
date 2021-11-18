Imports System.Globalization
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Presenters

    Public Class SalesJournalPresenter(Of TM As New)
        Inherits TransactionsPresenterNew(Of ISalesJournalView, TM)
        Implements ISubscriber(Of DataChanged)

        Protected DtInsertTable As New DataTable
        Protected DtSalesDepositInsertTable As New DataTable
        Protected DtSalesDepositUpdateTable As New DataTable
        Protected DtUpdateTable As New DataTable

        Private ReadOnly _salesDepositService As New AccountsService("SalesDeposit")
        Private ReadOnly _salesJournalItemService As New AccountsService("JournalItem", Nothing, {"SalesJournalItem_View", "dbo.UpdateSalesJournalItemTVP", "dbo.InsertSalesJournalItemTVP"})

        Private _depositTypesModel As List(Of DepositTypeModel)
        Private ReadOnly _oldSalesDepositTypeItem As List(Of TM)
        Private ReadOnly _vatRate As Decimal = GlobalVariables.VatRate() / 100D

        Public Sub New(view As ISalesJournalView)
            MyBase.New(view)
            WithTreeView = False
            Service = New AccountsService("SalesJournal")
            TableName = "SalesJournal"
            SortOrderKey = "IdNo"

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

            DtSalesDepositInsertTable.Columns.Add("DepositTypeIdNo", GetType(Int16))
            DtSalesDepositInsertTable.Columns.Add("DepositAmount", GetType(Decimal))
            DtSalesDepositInsertTable.Columns.Add("SaleAmount", GetType(Decimal))
            DtSalesDepositInsertTable.Columns.Add("SalesJournalIdNo", GetType(Int32))
            DtSalesDepositInsertTable.Columns.Add("Sequence", GetType(Int16))
            DtSalesDepositInsertTable.Columns.Add("VatAmount", GetType(Decimal))

            DtSalesDepositUpdateTable.Columns.Add("DepositTypeIdNo", GetType(Int16))
            DtSalesDepositUpdateTable.Columns.Add("DepositAmount", GetType(Decimal))
            DtSalesDepositUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtSalesDepositUpdateTable.Columns.Add("SaleAmount", GetType(Decimal))
            DtSalesDepositUpdateTable.Columns.Add("SalesJournalIdNo", GetType(Int32))
            DtSalesDepositUpdateTable.Columns.Add("Sequence", GetType(Int16))
            DtSalesDepositUpdateTable.Columns.Add("VatAmount", GetType(Decimal))

        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateLookupData("Account", "AccountsByCode", "DetailAccount=1")
            CreateLookupData("DepositType", "DepositTypesByCode")
            CreateLookupData("RevCostCenter", "RevCostCentersByCode")
            CreateSpecialAccountDataSource("AccountIdNo", {EnumToCode(SpecialAccountSelection.Sales)})
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
            Return _salesJournalItemService.GetRecordsWithGroupIdNo(Of JournalItemModel)(journalIdNo, "Sequence")
        End Function

        Public Function GetSalesDeposits(salesDepositTypeIdNo As Int32) As List(Of SalesDepositModel)
            Return _salesDepositService.GetRecordsWithGroupIdNo(Of SalesDepositModel)(salesDepositTypeIdNo, "Sequence")
        End Function

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
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
                        workRow = DtSalesDepositInsertTable.NewRow()
                    Else
                        workRow = DtSalesDepositUpdateTable.NewRow()
                        workRow("IdNo") = sc.IdNo
                    End If
                    workRow("DepositTypeIdNo") = sc.DepositTypeIdNo
                    workRow("SalesJournalIdNo") = View.IdNo
                    workRow("Sequence") = nRowCount
                    workRow("SaleAmount") = sc.SaleAmount
                    workRow("DepositAmount") = sc.DepositAmount
                    workRow("VatAmount") = sc.VatAmount
                    If sc.IdNo <= 0 Then
                        DtSalesDepositInsertTable.Rows.Add(workRow)
                    Else
                        DtSalesDepositUpdateTable.Rows.Add(workRow)
                    End If
                    nRowCount += 1
                    'View.TotalDebits += sc.SaleAmount
                End If
            Next
            'View.TotalCredits = View.TotalDebits
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
            retVal = UpdateChildData(_salesJournalItemService, DtUpdateTable, DtInsertTable, passedValue, "JournalIdNo")
            If retVal > 0 Then
                retVal = UpdateChildData(_salesDepositService, DtSalesDepositUpdateTable, DtSalesDepositInsertTable, passedValue, "SalesJournalIdNo")
            End If
            If retVal >= 0 Then
                Dim dataModel = New TM
                GlobalVariables.Mapper.Map(View, dataModel)
                retVal = Service.UpdateGlReferenceNumber(dataModel)
            End If
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = False
            If MyBase.IsBizDataValid() Then
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Service.GetRecordFieldWithKeyG(Of DateTime?)("Sales Journal", "LastPosting", "TransactionName", "LastPostingDate")
                If IsDateRangeValid("Sales Journal", View.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
                    retValue = False
                End If
            End If
            Return retValue
        End Function

        Private Sub MakeJournalItems()
            Dim oldJournalItems = GetJournalItems(View.IdNo)
            Dim counter As Integer = 0
            'View.TotalSales = 0
            'For Each item In View.SalesDeposits
            '    View.TotalSales = View.TotalSales + item.SaleAmount
            'Next
            MakeSalesJournal(oldJournalItems, counter, View.AccountIdNo, 0, View.TotalSales, "Sales", Messaging.TranslateCaption("Sales"))
            For Each item As SalesDepositView In View.SalesDeposits
                If item.DepositTypeIdNo <> 0 Then
                    Dim depositType = _depositTypesModel.Find(Function(c) c.IdNo = item.DepositTypeIdNo())
                    MakeSalesJournal(oldJournalItems, counter, depositType.AccountIdNo, item.DepositAmount, 0, depositType.DepositTypeName, depositType.DepositTypeNameAra)
                    If depositType.WithBankCharges Then
                        MakeSalesJournal(oldJournalItems, counter, depositType.BankChargesAccountIdNo, item.ActualBankCharge, 0, depositType.DepositTypeName, depositType.DepositTypeNameAra)
                        MakeSalesJournal(oldJournalItems, counter, depositType.BankChargesVatAccountIdNo, item.VatAmount, 0, depositType.DepositTypeName, depositType.DepositTypeNameAra)
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
                                     pAccountIdNo As Int16?, debitAmount As Decimal, creditAmount As Decimal, note As String, noteAra As String)
            If debitAmount <> 0 Or creditAmount <> 0 Then
                counter += 1
                If counter <= oldJournalItems.Count() Then
                    View.JournalItems.Item(counter - 1).AccountIdNo = pAccountIdNo
                    View.JournalItems.Item(counter - 1).Debit = If(debitAmount - creditAmount < 0, 0, debitAmount - creditAmount)
                    View.JournalItems.Item(counter - 1).Credit = If(creditAmount - debitAmount > 0, creditAmount - debitAmount, 0)
                    View.JournalItems.Item(counter - 1).Sequence = counter
                    View.JournalItems.Item(counter - 1).Notes = RTrim(LTrim(note)) + IIf(note = noteAra, "", "-" + noteAra)
                Else
                    Dim ji As New JournalItemView With {
                            .AccountIdNo = pAccountIdNo,
                            .Credit = If(creditAmount - debitAmount > 0, creditAmount - debitAmount, 0),
                            .Debit = If(debitAmount - creditAmount < 0, 0, debitAmount - creditAmount),
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
            If DtSalesDepositInsertTable IsNot Nothing Then
                DtSalesDepositInsertTable.Clear()
            End If
            If DtSalesDepositUpdateTable IsNot Nothing Then
                DtSalesDepositUpdateTable.Clear()
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
            Dim cForm As New ReportForm("Sales Journal.Rpt", View.IdNo, "SalesJournalIdNo", totalCreditAmount, "TotalLineAmountInWords", language, "Language")
            cForm.Show()
        End Sub

        Public Sub RecomputeBankCharges(salesDeposit As SalesDepositView)
            If salesDeposit.DepositTypeIdNo <> 0 Then
                Dim depositType As New DepositTypeModel
                depositType = GetDepositType(salesDeposit.DepositTypeIdNo)
                With salesDeposit
                    .Rate = depositType.Rate
                    .DepositAmount = .SaleAmount - .ComputedBankCharge - .ComputedBankChargeVat
                    .ActualBankCharge = .ComputedBankCharge
                    .VatAmount = .ComputedBankChargeVat
                End With
            End If
        End Sub

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

        Public Sub OnPayElementDataChangedEventHandler(ByRef eventType As DataChanged) Implements ISubscriber(Of DataChanged).OnEventHandler
            With eventType.BindingSource
                If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
                    Select Case eventType.PropertyName
                        Case $"DepositTypeIdNo"
                            RecomputeBankCharges(eventType.BindingSource.Current)
                        Case $"SaleAmount"
                            RecomputeBankCharges(eventType.BindingSource.Current)
                    End Select
                    eventType.BindingSource.ResetBindings(False)
                End If
            End With
        End Sub

        Public Overrides Function IsOkToEditRecord() As Boolean
            Dim result As Boolean = True
            Dim reconciledDao = New ReconciledDao
            For Each item In View.JournalItems
                If reconciledDao.IsItemReconciled("SJ", item.IdNo) Then
                    Messaging.Show(True, "MsgEditingOfReconciledNotAllowed")
                    result = False
                    Exit For
                End If
            Next
            Return result
        End Function

    End Class

End Namespace
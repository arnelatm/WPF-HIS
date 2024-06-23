Imports System.Globalization
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class GeneralJournalPresenter(Of TM As New)
        Inherits TransactionsPresenter(Of IGeneralJournalView, TM)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _gjJournalItemService As New AccountsService("JournalItem", Nothing, {"GeneralJournalItem_View", "UpdateGeneralJournalItemTVP", "InsertGeneralJournalItemTVP"})
        Private ReadOnly _closingEntry As Boolean

        Public Sub New(view As IGeneralJournalView, closingEntry As Boolean)
            MyBase.New(view)
            WithTreeView = False
            _closingEntry = closingEntry
            Service = New AccountsService("GeneralJournal")
            TableBaseName = "GeneralJournal"
            If Not view.ClosingJournal Then
                TableName = "GeneralJournalNormal_View"
            Else
                TableName = "GeneralJournalClosing_View"
            End If
            SortOrderKey = "IdNo"

            DtInsertTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Credit", GetType(Decimal))
            DtInsertTable.Columns.Add("Debit", GetType(Decimal))
            DtInsertTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Notes", GetType(String))
            DtInsertTable.Columns.Add("PayIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("RevCostCenterIdNo", GetType(Int16))
            DtInsertTable.Columns.Add("Sequence", GetType(Int16))

            DtUpdateTable.Columns.Add("AccountIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Credit", GetType(Decimal))
            DtUpdateTable.Columns.Add("Debit", GetType(Decimal))
            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Notes", GetType(String))
            DtUpdateTable.Columns.Add("PayIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("RevCostCenterIdNo", GetType(Int16))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int16))

            AddHandler view.AccountIdChanged, AddressOf OnPayeeIdNoChanged

        End Sub

        Private Sub OnPayeeIdNoChanged(bs As BindingSource)
            bs.Current.SpecialAccount = Service.GetFieldWithIdNo(bs.Current.AccountIdNo, "Account", "SpecialAccount")
        End Sub

        Protected Overrides Sub CreateDataSources()
            MakeVarDataSources({New Object() {"Account", "AccountsByCode", Nothing, "DetailAccount=1"},
            New Object() {"RevCostCenter", "RevCostCentersByCode", Nothing, Nothing},
            New Object() {"Contact_View", "PayeeByCode", "IdNo,ContactName,ContactCode", Nothing, Nothing},
            New Object() {"Contact_View", "CustomerByCode", "IdNo,ContactName,ContactCode", "PayeeType = 'C'", Nothing},
            New Object() {"Contact_View", "SupplierByCode", "IdNo,ContactName,ContactCode", "PayeeType = 'S'", Nothing},
            New Object() {"Contact_View", "EmployeeByCode", "IdNo,ContactName,ContactCode", "PayeeType = 'E'", Nothing}})
        End Sub


        Public Overrides Sub GoPrintRecord()
            Dim totalCreditAmount As String
            Dim currencies As New List(Of CurrencyInfo)()
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim language As String
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))

            currencies.Add(New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia))
            If language = "ar" Then
                totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToArabic()
            Else
                totalCreditAmount = New ToWord(View.TotalCredits, currencies(0)).ConvertToEnglish()
            End If

            Dim cForm As New ReportForm("General Journal.Rpt", View.IdNo, "GeneralJournalIdNo", totalCreditAmount, "TotalLineAmountInWords", language, "Language")

            cForm.Show()
        End Sub

        Private Sub OnSuccessfulDelete(ByVal idNo As Int32) Handles MyBase.SuccessfulDelete
            If View.JournalItems IsNot Nothing And View.JournalItems.Count() > 0 Then
                DtUpdateTable.Clear()
                _gjJournalItemService.DelUpdateTvp(DtUpdateTable, idNo)
            End If
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                CustomObjToDataTables(View.JournalItems, DtInsertTable, DtUpdateTable, AddressOf FillData, AddressOf JournalItemFilter)
            End If
        End Sub

        Private Sub FillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("JournalIdNo") = View.IdNo
            workRow("AccountIdNo") = itemDataView.AccountIdNo
            workRow("Debit") = itemDataView.Debit
            workRow("Credit") = itemDataView.Credit
            workRow("PayIdNo") = itemDataView.PayIdNo
            workRow("RevCostCenterIdNo") = itemDataView.RevCostCenterIdNo
            workRow("Notes") = If(itemDataView.Notes, "")
        End Sub

        Public Function JournalItemFilter(ByVal obj As Object) As Boolean
            If (obj.AccountIdNo Is Nothing Or obj.AccountIdNo = 0) AndAlso obj.Debit = 0 AndAlso obj.Credit = 0 Then
                Return False
            End If
            Return True
        End Function

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_gjJournalItemService, DtUpdateTable, DtInsertTable, passedValue, "JournalIdNo")
            If retVal >= 0 And IsEmpty(View.ReferenceNo) Then
                Dim dataModel = New TM
                GlobalVariables.Mapper.Map(View, dataModel)
                retVal = Service.UpdateGlReferenceNumber(dataModel)
            End If
        End Sub

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue As Boolean = False
            If MyBase.IsBizDataValid() Then
                Dim specialAccount As String
                Dim account As AccountModel
                Dim dateToday As DateTime = Now()
                retValue = True
                Dim lastPostingDate As DateTime? = Service.GetRecordFieldWithKeyG(Of DateTime?)("General Journal", "LastPosting", "TransactionName", "LastPostingDate")
                If View.JournalItems Is Nothing OrElse View.JournalItems.Count() = 0 Then
                    Messaging.Show(True, "MsgCannotSaveAnEmptyTransaction", "Sorry, cannot save an empty transaction!", "Error")
                    retValue = False
                ElseIf IsDateRangeValid("General Journal", View.TransactionDate, lastPostingDate, dateToday) = DialogResult.No Then
                    retValue = False
                Else
                    For Each item As JournalItemView In View.JournalItems
                        If item.AccountIdNo Is Nothing OrElse item.AccountIdNo = 0 Then
                            specialAccount = Nothing
                        Else
                            account = GetAccount(item.AccountIdNo)
                            specialAccount = account.SpecialAccount
                        End If
                        If item.AccountIdNo Is Nothing Or item.AccountIdNo = 0 AndAlso (item.Debit <> 0 Or item.Credit <> 0) Then
                            MessageBox.Show(String.Format("Error in line {0:N0}. Cannot save entries with blank account id.", item.Sequence.ToString()))
                            retValue = False
                            Exit For
                        ElseIf item.SpecialAccount IsNot Nothing AndAlso item.PayIdNo = 0 Then
                            Dim lineNumber As String = item.Sequence.ToString()
                            Dim messageString As String = ""
                            If item.SpecialAccount = EnumToCode(SpecialAccountSelection.AccountsPayable) Then
                                messageString = Messaging.TranslateCaption("Accounts Payable")
                            ElseIf item.SpecialAccount = EnumToCode(SpecialAccountSelection.AccountsReceivable) Then
                                messageString = Messaging.TranslateCaption("Accounts Receivable")
                            ElseIf item.SpecialAccount = EnumToCode(SpecialAccountSelection.EmployeeLoan) Then
                                messageString = Messaging.TranslateCaption("Employee Loan")
                            End If
                            If messageString <> "" Then
                                MessageBox.Show(String.Format("Error in line {0:N0}. Cannot save because {1} must have payee entered.", item.Sequence.ToString(), messageString))
                                retValue = False
                            End If
                        End If
                    Next
                End If
            End If
            Return retValue
        End Function

        Public Overrides Function IsOkToEditRecord() As Boolean
            If Not MyBase.IsOkToEditRecord() Then
                Return False
            End If
            Dim result As Boolean = True
            Dim reconciledDao = New ReconciledDao
            For Each item In View.JournalItems
                If reconciledDao.IsItemReconciled("GJ", item.IdNo) Then
                    Messaging.Show(True, "MsgEditingOfReconciledNotAllowed")
                    result = False
                    Exit For
                End If
            Next
            Return result
        End Function


        Public Overrides Function IsOkToDeleteRecord() As Boolean
            Dim retValue As Boolean = True
            If MyBase.IsOkToDeleteRecord Then
                If ReconciledEntriesExist(View.JournalItems, "GJ") Then
                    retValue = False
                End If
            End If
            Return retValue
        End Function

    End Class

End Namespace
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class AccountsPresenterNew(Of T As IView, TM As New)
        Inherits PresenterTv(Of T, TM)
        Implements IAccountsPresenter

        Public Sub New(itemView As T)
            MyBase.New(itemView)
            'FormTreeView = CallByName(View, "FormTreeView", CallType.Get)
        End Sub

        'Public Function GetDepositTypeModel() As List(Of DepositTypeModel) Implements IAccountsPresenter.GetDepositTypeModel
        '    Dim modelDepositType As New ModelAccounts("DepositType")
        '    Return modelDepositType.GetAll(Of DepositTypeModel)("DepositTypeName")
        'End Function

        'Public Function GetAccount(idNo As String) Implements IAccountsPresenter.GetAccount
        '    Dim accountModel As New ModelAccounts("Account")
        '    Return accountModel.GetRecordByIdNo(Of AccountModel)(idNo)
        'End Function

        'Public Function AddArOpenInvoice(ByVal journalItem As JournalItemModel, ByVal journalCode As String) As Integer Implements IAccountsPresenter.AddArOpenInvoice
        '    Dim modelArOpenInvoice As New ModelAccounts("ArOpenInvoice")
        '    Dim arOpenInvoiceModel As New ArOpenInvoiceModel With {
        '            .JournalCode = journalCode,
        '            .JournalIdNo = journalItem.JournalIdNo,
        '            .JournalItemIdNo = journalItem.IdNo
        '            }
        '    Return modelArOpenInvoice.AddRecord(Of ArOpenInvoiceModel)(arOpenInvoiceModel)
        'End Function

        'Public Function AddApOpenInvoice(ByVal journalItem As JournalItemModel, ByVal journalCode As String) As Integer Implements IAccountsPresenter.AddApOpenInvoice
        '    Dim modelApOpenInvoice As New ModelAccounts("ApOpenInvoice")
        '    Dim apOpenInvoiceModel As New ApOpenInvoiceModel With {
        '            .JournalCode = journalCode,
        '            .JournalIdNo = journalItem.JournalIdNo,
        '            .JournalItemIdNo = journalItem.IdNo
        '            }
        '    Return modelApOpenInvoice.AddRecord(Of ApOpenInvoiceModel)(apOpenInvoiceModel)
        'End Function

        'Public Function DeleteApOpenInvoice(ByRef idNo As Int32) Implements IAccountsPresenter.DeleteApOpenInvoice
        '    Dim retVal As Integer = 0
        '    If idNo <> 0 Then
        '        Dim modelApOpenInvoice As New ModelAccounts("ApOpenInvoice")
        '        retVal = modelApOpenInvoice.DeleteRecord(idNo, "ApOpenInvoice")
        '    End If
        '    Return retVal
        'End Function

        'Public Function UpdateInputVatAmount(journalItems As List(Of IJournalItemView)) Implements IAccountsPresenter.UpdateInputVatAmount
        '    Dim tiVatAmount As Decimal = 0
        '    Dim inputVatAccount As String = GlobalFunctions.EnumToCode(SpecialAccountSelection.VatInput)
        '    For Each item In journalItems
        '        If item.SpecialAccount = inputVatAccount Then
        '            tiVatAmount = tiVatAmount + item.Debit - item.Credit
        '        End If
        '    Next
        '    Return tiVatAmount
        'End Function

        'Public Function UpdateOutputVatAmount(journalItems As List(Of IJournalItemView)) Implements IAccountsPresenter.UpdateOutputVatAmount
        '    Dim toVatAmount As Decimal = 0
        '    Dim outputVatAccount As String = GlobalFunctions.EnumToCode(SpecialAccountSelection.VatOutput)
        '    For Each item In journalItems
        '        If item.SpecialAccount = outputVatAccount Then
        '            toVatAmount = toVatAmount + item.Credit - item.Debit
        '        End If
        '    Next
        '    Return toVatAmount
        'End Function

        'Public Sub MakeDebitAmount(journalItem As IJournalItemView, amount As Decimal?) Implements IAccountsPresenter.MakeDebitAmount
        '    If amount Is Nothing OrElse amount >= 0 Then
        '        journalItem.Credit = 0
        '    ElseIf amount < 0 Then
        '        journalItem.Credit = amount * -1
        '        journalItem.Debit = 0
        '    End If
        'End Sub

        'Public Sub MakeCreditAmount(journalItem As IJournalItemView, amount As Decimal?) Implements IAccountsPresenter.MakeCreditAmount
        '    If amount Is Nothing OrElse amount >= 0 Then
        '        journalItem.Debit = 0
        '    ElseIf amount < 0 Then
        '        journalItem.Debit = amount * -1
        '        journalItem.Credit = 0
        '    End If
        'End Sub

        'Public Sub MakePayTypeAndSpecialAccount(journalItem As IJournalItemView, accountIdNo As Int16?) Implements IAccountsPresenter.MakePayTypeAndSpecialAccount
        '    Dim account As AccountModel
        '    If accountIdNo Is Nothing Or accountIdNo <= 0 Then
        '        journalItem.JournalIdNo = 0
        '        journalItem.SpecialAccount = Nothing
        '        journalItem.PayeeType = Nothing
        '    Else
        '        account = GetAccount(accountIdNo)
        '        journalItem.AccountIdNo = accountIdNo
        '        journalItem.SpecialAccount = account.SpecialAccount
        '        journalItem.PayeeType = account.PayeeType
        '    End If
        'End Sub

        'Public Sub AddNewItemOnBindingSource(Of TS As New)(ByVal e As System.ComponentModel.AddingNewEventArgs, bindingSource As BindingSource, dataGridView As DataGridView) Implements IAccountsPresenter.AddNewItemOnBindingSource
        '    e.NewObject = New TS
        '    ' work around for error on datagrid entry on lastrow please do not remove.
        '    ' The reason it works Is because On a DataGridView where AllowUserToAddRows Is True,
        '    ' it adds an empty row at the end of its rows which if bound to a list creates a null element at the end of the list.
        '    ' The code removes that element And then the AddNew in the BindingList will trigger the DataGridView to add it again
        '    If dataGridView.Rows.Count = bindingSource.Count Then
        '        bindingSource.RemoveAt(bindingSource.Count - 1)
        '    End If
        'End Sub

        'Public Function GetBizRules(childProperty) Implements IAccountsPresenter.GetBizRules
        '    Dim viewName = childProperty.GetType.GenericTypeArguments(0).Name
        '    Dim bizName As String = Strings.Left(viewName, Len(viewName) - 4)
        '    ' is standard naming convention to name the view as the object with 'View' as appended name so to get value just remove 'View'
        '    Dim bModel As New ModelAccounts(bizName)
        '    Return bModel.GetBizObjectRules()
        'End Function

        'Public Function GetBizObject(childProperty) Implements IAccountsPresenter.GetBizObject
        '    Dim viewName = childProperty.GetType.GenericTypeArguments(0).Name
        '    Dim bizName As String = Strings.Left(viewName, Len(viewName) - 4)
        '    ' is standard naming convention to name the view as the object with 'View' as appended name so to get value just remove 'View'
        '    Dim bModel As New ModelAccounts(bizName)
        '    Return bModel.DataService.DataBo
        'End Function

        'Public Function ValidateDataBoundGrid(Of TMG As New)(viewProperty As Object, dataGridView As DataGridView, dictionary As Dictionary(Of String, Object), Optional tabPage As TabPage = Nothing) Implements IAccountsPresenter.ValidateDataBoundGrid
        '    Dim errorFound As Boolean = False
        '    Dim rules = GetBizRules(viewProperty)
        '    Dim bo = GetBizObject(viewProperty)
        '    For Each rule In rules
        '        For Each col In dataGridView.Columns()
        '            Dim colName = col.DataPropertyName
        '            If rule.Property = colName Then
        '                For Each row As DataGridViewRow In dataGridView.Rows
        '                    Dim model As New TMG
        '                    If row.Index() >= 0 AndAlso row.Index() < dataGridView.RowCount() - 1 Then
        '                        GlobalVariables.Mapper.Map(viewProperty(row.Index()), model)
        '                        GlobalVariables.Mapper.Map(model, bo)
        '                        If Not bo.IsRuleValid(rule) Then
        '                            Dim obj As New Object
        '                            dictionary.TryGetValue(rule.Property, obj)
        '                            row.Cells(obj.Name).ErrorText = rule.Error
        '                            errorFound = True
        '                        End If
        '                    End If
        '                Next
        '            End If
        '        Next
        '    Next
        '    If errorFound Then
        '        If tabPage IsNot Nothing Then
        '            tabPage.ImageIndex = 0
        '        Else
        '            tabPage.ImageIndex = -1
        '        End If
        '    Else
        '        If tabPage IsNot Nothing Then
        '            tabPage.ImageIndex = -1
        '        End If
        '    End If
        '    Return Not errorFound
        'End Function

        Private ReadOnly _monthType = EnumToCode(PayRateUnitSelection.Month)
        Private ReadOnly _semiMonthType = EnumToCode(PayRateUnitSelection.SemiMonth)
        Private ReadOnly _yearType = EnumToCode(PayRateUnitSelection.Year)
        Private ReadOnly _semiYearType = EnumToCode(PayRateUnitSelection.SemiYear)
        Private ReadOnly _quarterType = EnumToCode(PayRateUnitSelection.Quarter)
        Private ReadOnly _weekType = EnumToCode(PayRateUnitSelection.Week)
        Private ReadOnly _dayType = EnumToCode(PayRateUnitSelection.Day)
        Private ReadOnly _biWeekType = EnumToCode(PayRateUnitSelection.BiWeek)

        Public Function ComputePayAmount(payFrequency As PayFrequencySelection, amount As Decimal, unit As String) As Decimal Implements IAccountsPresenter.ComputePayAmount
            Dim factor As Decimal
            Select Case payFrequency
                Case PayFrequencySelection.Monthly
                    If unit = _monthType Then
                        factor = 1D
                    ElseIf unit = _semiMonthType Then
                        factor = 2D
                    ElseIf unit = _yearType Then
                        factor = 1D / 12D
                    ElseIf unit = _semiYearType Then
                        factor = 1D / 6D
                    ElseIf unit = _quarterType Then
                        factor = 1D / 3D
                    ElseIf unit = _weekType Then
                        factor = 13D / 2D
                    ElseIf unit = _dayType Then
                        factor = 30D
                    ElseIf unit = _biWeekType Then
                        factor = 13D / 6D
                    End If
                Case PayFrequencySelection.Yearly
                    If unit = _monthType Then
                        factor = 12D
                    ElseIf unit = _semiMonthType Then
                        factor = 24D
                    ElseIf unit = _yearType Then
                        factor = 1D
                    ElseIf unit = _semiYearType Then
                        factor = 2D
                    ElseIf unit = _quarterType Then
                        factor = 4D
                    ElseIf unit = _weekType Then
                        factor = 52D
                    ElseIf unit = _dayType Then
                        factor = 365D
                    ElseIf unit = _biWeekType Then
                        factor = 26D
                    End If
                Case PayFrequencySelection.SemiYearly
                    If unit = _monthType Then
                        factor = 6D
                    ElseIf unit = _semiMonthType Then
                        factor = 12D
                    ElseIf unit = _yearType Then
                        factor = 1D / 2D
                    ElseIf unit = _semiYearType Then
                        factor = 1D
                    ElseIf unit = _quarterType Then
                        factor = 2D
                    ElseIf unit = _weekType Then
                        factor = 26D
                    ElseIf unit = _dayType Then
                        factor = 365D / 2D
                    ElseIf unit = _biWeekType Then
                        factor = 13D
                    End If
                Case PayFrequencySelection.Quarterly
                    If unit = _monthType Then
                        factor = 3D
                    ElseIf unit = _semiMonthType Then
                        factor = 6D
                    ElseIf unit = _yearType Then
                        factor = 1D / 4D
                    ElseIf unit = _semiYearType Then
                        factor = 1D / 2D
                    ElseIf unit = _quarterType Then
                        factor = 1D
                    ElseIf unit = _weekType Then
                        factor = 13D
                    ElseIf unit = _dayType Then
                        factor = 365D / 4D
                    ElseIf unit = _biWeekType Then
                        factor = 13D / 2D
                    End If
                Case PayFrequencySelection.SemiMonthly
                    If unit = _monthType Then
                        factor = 1D / 2D
                    ElseIf unit = _semiMonthType Then
                        factor = 1D
                    ElseIf unit = _yearType Then
                        factor = 1D / 24D
                    ElseIf unit = _semiYearType Then
                        factor = 1D / 12D
                    ElseIf unit = _quarterType Then
                        factor = 1D / 6D
                    ElseIf unit = _weekType Then
                        factor = 13D / 4D
                    ElseIf unit = _dayType Then
                        factor = 15D
                    ElseIf unit = _biWeekType Then
                        factor = 13D / 12D
                    End If
                Case PayFrequencySelection.Weekly
                    If unit = _monthType Then
                        factor = 12D / 52D
                    ElseIf unit = _semiMonthType Then
                        factor = 24D / 52D
                    ElseIf unit = _yearType Then
                        factor = 1D / 52D
                    ElseIf unit = _semiYearType Then
                        factor = 1D / 26D
                    ElseIf unit = _quarterType Then
                        factor = 1D / 13D
                    ElseIf unit = _weekType Then
                        factor = 1D
                    ElseIf unit = _dayType Then
                        factor = 7D
                    ElseIf unit = _biWeekType Then
                        factor = 1D / 2D
                    End If
                Case PayFrequencySelection.Daily
                    If unit = _monthType Then
                        factor = 1D / 30D
                    ElseIf unit = _semiMonthType Then
                        factor = 1D / 15D
                    ElseIf unit = _yearType Then
                        factor = 1D / 360D
                    ElseIf unit = _semiYearType Then
                        factor = 1D / 180D
                    ElseIf unit = _quarterType Then
                        factor = 1D / 90D
                    ElseIf unit = _weekType Then
                        factor = 1D / 7D
                    ElseIf unit = _dayType Then
                        factor = 1D
                    ElseIf unit = _biWeekType Then
                        factor = 1D / 14D
                    End If

            End Select
            Return amount * factor
        End Function

        'Protected Function IsChildValid2(Of Tcm)(bizName, childProperty) As Boolean
        '    Dim retValue As Boolean = True
        '    Dim sModel As New List(Of Tcm)
        '    Dim esModel As New ModelAccounts(bizName)
        '    Dim dModel = GlobalVariables.Mapper.Map(childProperty, sModel)
        '    For Each item In sModel
        '        If Not esModel.IsValid(item) Then
        '            retValue = False
        '        End If
        '    Next
        '    If Not retValue Then
        '        AddToParentError(esModel.GetBizObjectErrors)
        '    End If
        '    Return retValue
        'End Function

        'Public Sub SetSupplierVatNumber(ByRef currentVatNumber As String, idNo As String, override As Boolean)
        '    If IsEmpty(currentVatNumber) Or override Then
        '        If idNo IsNot Nothing Then
        '            Dim supplierVatNumber = GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "VatNumber")
        '            currentVatNumber = supplierVatNumber
        '        Else
        '            currentVatNumber = Nothing
        '        End If
        '    End If
        'End Sub

        'Public Function GetSupplierPaymentDueDays(idNo As String)
        '    Return GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "PaymentDueDays")
        'End Function

        'Public Function GetSupplierSettlementDiscount(idNo As String)
        '    Return GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "SettlementDiscount")
        'End Function

        'Public Function GetSupplierSettlementDueDays(idNo As String)
        '    Return GetRecordFieldWithKey(idNo, "Supplier", "IdNo", "SettlementDueDays")
        'End Function

        'Public Function GetCustomerPaymentDueDays(idNo As String)
        '    Return GetRecordFieldWithKey(idNo, "Customer", "IdNo", "PaymentDueDays")
        'End Function

        'Public Function GetCustomerSettlementDiscount(idNo As String)
        '    Return GetRecordFieldWithKey(idNo, "Customer", "IdNo", "SettlementDiscount")
        'End Function

        'Public Function GetCustomerSettlementDueDays(idNo As String)
        '    Return GetRecordFieldWithKey(idNo, "Customer", "IdNo", "SettlementDueDays")
        'End Function

        'Public Function IsAccountsPayableAccount(ByVal accountIdNo As Int16)
        '    Return GetRecordFieldWithKey(accountIdNo, "Account", "IdNo", "SpecialAccount") = "AP"
        'End Function

        'Public Function IsAccountsReceivableAccount(ByVal accountIdNo As Int16)
        '    Return GetRecordFieldWithKey(accountIdNo, "Account", "IdNo", "SpecialAccount") = "AR"
        'End Function

        'Public Function IsInputVatAccount(ByVal accountIdNo As Int16)
        '    Return GetRecordFieldWithKey(accountIdNo, "Account", "IdNo", "SpecialAccount") = "VI"
        'End Function

        'Public Function GetAdvancesToSupplierAccountIdNo()
        '    Return GetRecordFieldWithKey("AS", "Account", "SpecialAccount", "IdNo")
        'End Function

        'Public Function GetCustomerAdvancesAccountIdNo()
        '    Return GetRecordFieldWithKey("CA", "Account", "SpecialAccount", "IdNo")
        'End Function

        'Public Function ArOpenInvoiceExists(ByVal journalCode As String, ByVal idNo As Integer) As Boolean
        '    Return Model.CountRecordWith2Key(journalCode, idNo, "ArOpenInvoice", "JournalCode", "JournalItemIdNo")
        'End Function

        'Public Function ArCollectionExists(ByVal journalCode As String, ByVal idNo As Integer) As Boolean
        '    Dim arOpenInvoiceIdNo As Integer
        '    arOpenInvoiceIdNo = Model.GetRecordFieldWith2Key(journalCode, idNo, "ArOpenInvoice", "JournalCode",
        '                                                     "JournalItemIdNo", "IdNo")
        '    Return Model.CountRecordWithKey(arOpenInvoiceIdNo, "CsrOiItem", "ArOpenInvoiceIdNo") > 0
        'End Function

        'Public Function ApPaymentExists(ByVal journalCode As String, ByVal idNo As Integer) As Boolean
        '    Dim apOpenInvoiceIdNo As Integer
        '    apOpenInvoiceIdNo = Model.GetRecordFieldWith2Key(journalCode, idNo, "ArOpenInvoice", "JournalCode",
        '                                                     "JournalItemIdNo", "IdNo")
        '    If Model.CountRecordWithKey(apOpenInvoiceIdNo, "CdOiItem", "ApOpenInvoiceIdNo") > 0 Then
        '        Return True
        '    ElseIf Model.CountRecordWithKey(apOpenInvoiceIdNo, "CkOiItem", "ApOpenInvoiceIdNo") > 0 Then
        '        Return True
        '    ElseIf Model.CountRecordWithKey(apOpenInvoiceIdNo, "PcOiItem", "ApOpenInvoiceIdNo") > 0 Then
        '        Return True
        '    End If
        '    Return False
        'End Function

        'Public Function DeleteArOpenInvoice(ByRef idNo As Int32) As String
        '    Dim modelArOpenInvoice As New ModelAccounts("ArOpenInvoice")
        '    If Model.CountRecordWithKey(idNo, "CsrOiItem", "ArOpenInvoiceIdNo") = 0 Then
        '        Return modelArOpenInvoice.DeleteRecord(idNo, "ArOpenInvoice")
        '    End If
        '    Return 0
        'End Function

        Public Function GetIntPhoneCodes(Optional ByVal sortKey As String = "CountryName") Implements IAccountsPresenter.GetIntPhoneCodes
            Return GetLookup("Country", "CountryName", {"IdNo", "CountryName", "CountryTelCode"})
        End Function

        'Public Function GetEndingGlBalance(ByVal accountIdNo As Int16, ByVal reconciliationDate As Date) As Decimal
        '    Return DataModel.GetEndingGlBalance(accountIdNo, reconciliationDate)
        'End Function

        'Public Function GetAdvancePaymentOpenInvoice(ByVal journalCode As String, ByVal idNo As Int32)
        '    Return _
        '        Model.GetRecordFieldWith2Key(idNo, journalCode, "ApOpenInvoice", "JournalItemIdNo", "JournalCode",
        '                                     "IdNo")
        'End Function

        'Public Function GetAdvanceCollectionOpenInvoice(ByVal journalCode As String, ByVal idNo As Int32)
        '    Return _
        '        Model.GetRecordFieldWith2Key(idNo, journalCode, "ArOpenInvoice", "JournalItemIdNo", "JournalCode",
        '                                     "IdNo")
        'End Function

        'Protected Function IsChildValid(Of Tcm)(childProperty) As Boolean
        '    Dim retValue As Boolean = True
        '    Dim bizObjectList As New List(Of Tcm)
        '    Dim viewName = childProperty.GetType.GenericTypeArguments(0).Name
        '    Dim bizName As String = Strings.Left(viewName, Len(viewName) - 4)
        '    ' is standard naming convention to name the view as the object with 'View' as appended name so to get value just remove 'View'
        '    Dim model As New ModelAccounts(bizName)
        '    Dim dModel = GlobalVariables.Mapper.Map(childProperty, bizObjectList)
        '    For Each item In bizObjectList
        '        If Not model.IsValid(item) Then
        '            retValue = False
        '            AddToParentError(model.GetBizObjectErrors)
        '            Exit For
        '        End If
        '    Next
        '    Return retValue
        'End Function

    End Class

End Namespace
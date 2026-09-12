Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports AATM.Accounts.DataLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models

Namespace ServiceLayer
    Public Class CashFlowService
        Private ReadOnly _dao As ICashFlowDao
        Private Shared ReadOnly FixedAssetPrefixes = {"136", "137", "138", "140", "142", "143", "144", "146", "148", "150", "152"}
        Private Shared ReadOnly FinancingPrefixes = {"193", "224", "251", "310"}

        Public Sub New()
            Me.New(New CashFlowDao())
        End Sub

        Public Sub New(dao As ICashFlowDao)
            If dao Is Nothing Then Throw New ArgumentNullException(NameOf(dao))
            _dao = dao
        End Sub

        Public Function GetAccounts() As List(Of CashFlowAccountModel)
            Return _dao.GetAccounts().AsEnumerable().Select(Function(r) New CashFlowAccountModel With {
                .IdNo = Convert.ToInt16(r("IdNo")), .AccountCode = Convert.ToString(r("AccountCode")),
                .AccountName = Convert.ToString(r("AccountName")), .AccountNameAra = Convert.ToString(r("AccountNameAra")),
                .Active = Not r.IsNull("Active") AndAlso Convert.ToBoolean(r("Active"))}).ToList()
        End Function

        Public Function GetAllAccounts() As List(Of CashFlowAccountModel)
            Return _dao.GetAllAccounts().AsEnumerable().Select(Function(r) New CashFlowAccountModel With {.IdNo = Convert.ToInt16(r("IdNo")), .AccountCode = Convert.ToString(r("AccountCode")), .AccountName = Convert.ToString(r("AccountName")), .AccountNameAra = Convert.ToString(r("AccountNameAra")), .Active = Not r.IsNull("Active") AndAlso Convert.ToBoolean(r("Active"))}).ToList()
        End Function

        Public Function GetAccountRules() As List(Of CashFlowRuleModel)
            Return _dao.GetAccountRules().AsEnumerable().Select(Function(r) New CashFlowRuleModel With {.AccountIdNo = Convert.ToInt16(r("AccountIdNo")), .AccountCode = Convert.ToString(r("AccountCode")), .AccountName = Convert.ToString(r("AccountName")), .ClassificationCode = Convert.ToString(r("ClassificationCode")), .CategoryCode = Convert.ToString(r("CategoryCode")), .IsCashEquivalent = Convert.ToBoolean(r("IsCashEquivalent"))}).ToList()
        End Function

        Public Function GetClassifications() As List(Of String)
            Return _dao.GetClassifications().AsEnumerable().Select(Function(r) Convert.ToString(r("Code"))).ToList()
        End Function

        Public Sub SaveAccountRule(rule As CashFlowRuleModel)
            _dao.SaveAccountRule(rule.AccountIdNo, rule.ClassificationCode, rule.CategoryCode, rule.IsCashEquivalent)
        End Sub

        Public Function GetTransaction(code As String, journalId As Integer, itemId As Integer) As CashPositionTransactionModel
            Return New CashPositionService().GetTransaction(code, journalId, itemId)
        End Function

        Public Function GetStatement(beginningDate As Date, endingDate As Date, selectedIds As IEnumerable(Of Short)) As CashFlowModel
            If beginningDate.Date > endingDate.Date Then Throw New ArgumentException("CashFlowInvalidDates")
            Dim ids = If(selectedIds, Enumerable.Empty(Of Short)()).Distinct().ToHashSet()
            If ids.Count = 0 Then Throw New ArgumentException("CashFlowSelectAccounts")
            Dim table = _dao.GetLedger(beginningDate.Date, endingDate.Date)
            Dim accountRules = _dao.GetAccountRules()
            Dim approvedAllocations = _dao.GetApprovedAllocations()
            Dim result As New CashFlowModel With {.BeginningDate = beginningDate.Date, .EndingDate = endingDate.Date}
            Dim accounts = table.AsEnumerable().GroupBy(Function(r) Convert.ToInt16(r("IdNo"))).ToDictionary(Function(g) g.Key, Function(g) g.First())
            Dim opening As New Dictionary(Of Short, Decimal), closing As New Dictionary(Of Short, Decimal)
            For Each pair In accounts
                Dim r = pair.Value
                Dim value = Money(r, "SnapshotDebit") - Money(r, "SnapshotCredit")
                For Each line In table.AsEnumerable().Where(Function(x) Convert.ToInt16(x("IdNo")) = pair.Key AndAlso HasMovement(x))
                    If Convert.ToDateTime(line("TransactionDate")) < beginningDate.Date Then value += Money(line, "Debit") - Money(line, "Credit")
                Next
                opening(pair.Key) = value
                closing(pair.Key) = value + table.AsEnumerable().Where(Function(x) Convert.ToInt16(x("IdNo")) = pair.Key AndAlso HasMovement(x) AndAlso Convert.ToDateTime(x("TransactionDate")) >= beginningDate.Date AndAlso Convert.ToDateTime(x("TransactionDate")) <= endingDate.Date).Sum(Function(x) Money(x, "Debit") - Money(x, "Credit"))
            Next
            result.OpeningCash = ids.Sum(Function(id) If(opening.ContainsKey(id), opening(id), 0D))
            result.ClosingCash = ids.Sum(Function(id) If(closing.ContainsKey(id), closing(id), 0D))
            result.NetProfit = CalculateNetProfit(table, beginningDate, endingDate)
            AddLine(result, "Operating", "Net Profit / (Loss)", "صافي الربح / (الخسارة)", result.NetProfit)
            Dim depreciation = SumConfiguredAccounts(table, accountRules, "NonCashAdjustment", "NonCashAdjustment", beginningDate, endingDate, True)
            If Math.Abs(depreciation) < 0.005D Then depreciation = SumAccount(table, "565", beginningDate, endingDate, True)
            AddLine(result, "Operating", "Depreciation Expense", "مصروف الإهلاك", depreciation, False)
            Dim operating As Decimal = result.NetProfit + result.Lines.Last().Amount
            Dim specs As Object() = {New Object() {"Accounts Receivable", "الذمم المدينة", "AccountsReceivable", "7", False}, New Object() {"Inventory", "المخزون", "Inventory", "8", False}, New Object() {"Other Current Assets", "الأصول المتداولة الأخرى", "OtherCurrentAssets", "126", False}, New Object() {"Prepaid Expenses", "المصروفات المدفوعة مقدماً", "PrepaidExpenses", "188", False}, New Object() {"Accounts Payable", "الذمم الدائنة", "AccountsPayable", "15", True}, New Object() {"VAT Payable", "ضريبة القيمة المضافة المستحقة", "VATPayable", "16", True}, New Object() {"Accrued Expenses", "المصروفات المستحقة", "AccruedExpenses", "17", True}}
            For Each spec As Object In specs
                Dim delta = NormalDeltaForCategory(table, accounts, accountRules, CStr(spec(2)), beginningDate, endingDate)
                If Math.Abs(delta) < 0.005D Then delta = NormalDeltaForRoot(table, accounts, beginningDate, endingDate, CStr(spec(3)))
                Dim adjustment = If(CBool(spec(4)), delta, -delta)
                AddLine(result, "Operating", CStr(spec(0)), CStr(spec(1)), adjustment)
                operating += adjustment
            Next
            Dim operatingTotal = AddLine(result, "Operating", "NET CASH FROM OPERATING ACTIVITIES", "صافي التدفق النقدي من الأنشطة التشغيلية", operating, True)

            Dim journals = table.AsEnumerable().Where(Function(r) HasMovement(r) AndAlso InPeriod(r, beginningDate, endingDate) AndAlso Not Bool(r, "ClosingJournal")).GroupBy(Function(r) Convert.ToString(r("JournalCode")) & ":" & Convert.ToString(r("JournalIdNo")))
            Dim investing As Decimal = 0D, financing As Decimal = 0D
            Dim unclassifiedSources As New List(Of DataRow)
            For Each journal In journals
                Dim cash = journal.Where(Function(r) ids.Contains(Convert.ToInt16(r("IdNo")))).Sum(Function(r) Money(r, "Debit") - Money(r, "Credit"))
                Dim others = journal.Where(Function(r) Not ids.Contains(Convert.ToInt16(r("IdNo")))).ToList()
                If Math.Abs(cash) < 0.005D OrElse others.Count = 0 Then Continue For
                Dim approved = approvedAllocations.AsEnumerable().Where(Function(r) Convert.ToString(r("JournalCode")) = Convert.ToString(journal.First()("JournalCode")) AndAlso Convert.ToInt32(r("JournalIdNo")) = Convert.ToInt32(journal.First()("JournalIdNo"))).ToList()
                Dim useApproved = approved.Count > 0 AndAlso IsCompleteAllocation(approved, cash)
                If approved.Count > 0 AndAlso Not useApproved Then result.ReviewMessages.Add("Incomplete approved allocation requires review for " & Convert.ToString(journal.First()("JournalCode")) & "-" & Convert.ToString(journal.First()("JournalIdNo")) & ".")
                Dim inv = If(useApproved, ApprovedAmount(approved, "InvestingAsset"), CounterpartAmountByRules(others, accountRules, "InvestingAsset", cash))
                Dim fin = If(useApproved, ApprovedAmount(approved, "FinancingLiability") + ApprovedAmount(approved, "FinancingEquity"), CounterpartAmountByRules(others, accountRules, "FinancingLiability", cash) + CounterpartAmountByRules(others, accountRules, "FinancingEquity", cash))
                If Math.Abs(inv) > 0.005D Then
                    investing += inv
                    AddLine(result, "Investing", "Fixed asset purchases / disposals", "شراء / استبعاد الأصول الثابتة", inv, False, journal)
                End If
                If Math.Abs(fin) > 0.005D Then
                    financing += fin
                    AddLine(result, "Financing", "Loans and owner's capital", "القروض ورأس مال المالك", fin, False, journal)
                End If
            Next
            AddLine(result, "Investing", "NET CASH FROM/(USED IN) INVESTING ACTIVITIES", "صافي التدفق النقدي من الأنشطة الاستثمارية", investing, True)
            AddLine(result, "Financing", "NET CASH FROM/(USED IN) FINANCING ACTIVITIES", "صافي التدفق النقدي من الأنشطة التمويلية", financing, True)
            For Each journal In journals
                Dim cash = journal.Where(Function(r) ids.Contains(Convert.ToInt16(r("IdNo")))).Sum(Function(r) Money(r, "Debit") - Money(r, "Credit"))
                If Math.Abs(cash) < 0.005D Then Continue For
                Dim others = journal.Where(Function(r) Not ids.Contains(Convert.ToInt16(r("IdNo")))).ToList()
                If others.Count = 0 Then Continue For
                Dim approved = approvedAllocations.AsEnumerable().Where(Function(r) Convert.ToString(r("JournalCode")) = Convert.ToString(journal.First()("JournalCode")) AndAlso Convert.ToInt32(r("JournalIdNo")) = Convert.ToInt32(journal.First()("JournalIdNo"))).ToList()
                Dim useApproved = approved.Count > 0 AndAlso IsCompleteAllocation(approved, cash)
                Dim inv = If(useApproved, ApprovedAmount(approved, "InvestingAsset"), CounterpartAmountByRules(others, accountRules, "InvestingAsset", cash))
                Dim fin = If(useApproved, ApprovedAmount(approved, "FinancingLiability") + ApprovedAmount(approved, "FinancingEquity"), CounterpartAmountByRules(others, accountRules, "FinancingLiability", cash) + CounterpartAmountByRules(others, accountRules, "FinancingEquity", cash))
                If Math.Abs(inv) <= 0.005D AndAlso Math.Abs(fin) <= 0.005D Then unclassifiedSources.AddRange(journal)
            Next
            Dim unclassified = result.ClosingCash - result.OpeningCash - operating - investing - financing
            If Math.Abs(unclassified) > 0.005D Then
                result.ReviewMessages.Add("Unclassified cash-flow adjustment: SAR " & Decimal.Round(unclassified, 2).ToString("N2") & ". Review source journals before relying on activity classification.")
                AddLine(result, "Operating", "Unclassified cash movements (requires review)", "حركات نقدية غير مصنفة (تتطلب المراجعة)", unclassified, False, unclassifiedSources, True)
                operating += unclassified
                operatingTotal.Amount = Decimal.Round(operating, 2)
            End If
            If result.ReviewMessages.Count > 0 Then result.ReviewMessages.Add("The statement is reconciled to Cash Position, but its automatic activity classification is provisional.")
            result.InvestingCashFlow = investing : result.FinancingCashFlow = financing
            result.OperatingCashFlow = operating
            result.CalculatedClosingCash = result.OpeningCash + operating + investing + financing
            result.ReconciliationDifference = Decimal.Round(result.CalculatedClosingCash - result.ClosingCash, 2)
            AddLine(result, "Summary", "NET INCREASE/(DECREASE) IN CASH", "صافي الزيادة / (النقص) في النقد", operating + investing + financing, True)
            AddLine(result, "Summary", "CASH & CASH EQUIVALENTS - BEGINNING", "النقد وما في حكمه - بداية الفترة", result.OpeningCash, True)
            AddLine(result, "Summary", "CASH & CASH EQUIVALENTS - ENDING", "النقد وما في حكمه - نهاية الفترة", result.ClosingCash, True)
            AddLine(result, "Summary", "Reconciliation Difference", "فرق التسوية", result.ReconciliationDifference, True, Nothing, Math.Abs(result.ReconciliationDifference) > 0.005D)
            Return result
        End Function

        Private Shared Function CalculateNetProfit(t As DataTable, b As Date, e As Date) As Decimal
            Return -t.AsEnumerable().Where(Function(r) HasMovement(r) AndAlso InPeriod(r, b, e) AndAlso Not Bool(r, "ClosingJournal") AndAlso {"R", "X"}.Contains(Convert.ToString(r("AccountGroup"))) AndAlso IsIncomeStatementLine(r, b, e)).Sum(Function(r) Money(r, "Debit") - Money(r, "Credit"))
        End Function

        Private Shared Function IsIncomeStatementLine(r As DataRow, b As Date, e As Date) As Boolean
            Dim special = Convert.ToString(r("SpecialAccount"))
            If special = "BI" Then Return Convert.ToDateTime(r("TransactionDate")).Month = b.Month AndAlso Convert.ToDateTime(r("TransactionDate")).Year = b.Year
            If special = "EI" Then Return Convert.ToDateTime(r("TransactionDate")).Month = e.Month AndAlso Convert.ToDateTime(r("TransactionDate")).Year = e.Year
            Return special <> "BI" AndAlso special <> "EI"
        End Function

        Private Shared Function SumAccount(t As DataTable, prefix As String, b As Date, e As Date, positive As Boolean) As Decimal
            Dim value = t.AsEnumerable().Where(Function(r) HasMovement(r) AndAlso InPeriod(r, b, e) AndAlso Not Bool(r, "ClosingJournal") AndAlso Convert.ToString(r("AccountCode")).StartsWith(prefix)).Sum(Function(r) Money(r, "Debit") - Money(r, "Credit"))
            Return If(positive, value, -value)
        End Function

        Private Shared Function NormalDeltaForRoot(t As DataTable, a As Dictionary(Of Short, DataRow), b As Date, e As Date, rootCode As String) As Decimal
            Dim root = a.FirstOrDefault(Function(p) String.Equals(Convert.ToString(p.Value("AccountCode")), rootCode, StringComparison.OrdinalIgnoreCase))
            If root.Value Is Nothing Then Return 0D
            Return t.AsEnumerable().Where(Function(r) HasMovement(r) AndAlso InPeriod(r, b, e) AndAlso Not Bool(r, "ClosingJournal") AndAlso IsDescendantOrSelf(Convert.ToInt16(r("IdNo")), root.Key, a)).Sum(Function(r) Money(r, "Debit") - Money(r, "Credit"))
        End Function

        Private Shared Function NormalDeltaForCategory(t As DataTable, a As Dictionary(Of Short, DataRow), rules As DataTable, category As String, b As Date, e As Date) As Decimal
            Dim roots = rules.AsEnumerable().Where(Function(r) String.Equals(Convert.ToString(r("CategoryCode")), category, StringComparison.OrdinalIgnoreCase)).Select(Function(r) Convert.ToInt16(r("AccountIdNo"))).Distinct().ToList()
            If roots.Count = 0 Then Return 0D
            Return t.AsEnumerable().Where(Function(r) HasMovement(r) AndAlso InPeriod(r, b, e) AndAlso Not Bool(r, "ClosingJournal") AndAlso roots.Any(Function(root) IsDescendantOrSelf(Convert.ToInt16(r("IdNo")), root, a))).Sum(Function(r) Money(r, "Debit") - Money(r, "Credit"))
        End Function

        Private Shared Function SumConfiguredAccounts(t As DataTable, rules As DataTable, classification As String, category As String, b As Date, e As Date, positive As Boolean) As Decimal
            Dim ids = rules.AsEnumerable().Where(Function(r) String.Equals(Convert.ToString(r("ClassificationCode")), classification, StringComparison.OrdinalIgnoreCase) AndAlso String.Equals(Convert.ToString(r("CategoryCode")), category, StringComparison.OrdinalIgnoreCase)).Select(Function(r) Convert.ToInt16(r("AccountIdNo"))).ToHashSet()
            If ids.Count = 0 Then Return 0D
            Dim value = t.AsEnumerable().Where(Function(r) HasMovement(r) AndAlso InPeriod(r, b, e) AndAlso Not Bool(r, "ClosingJournal") AndAlso ids.Contains(Convert.ToInt16(r("IdNo")))).Sum(Function(r) Money(r, "Debit") - Money(r, "Credit"))
            Return If(positive, value, -value)
        End Function

        Private Shared Function IsDescendantOrSelf(id As Short, rootId As Short, accounts As Dictionary(Of Short, DataRow)) As Boolean
            Dim current = id
            Dim guard = 0
            While accounts.ContainsKey(current) AndAlso guard < 100
                If current = rootId Then Return True
                Dim parent = accounts(current).Item("ParentIdNo")
                If IsDBNull(parent) OrElse parent Is Nothing Then Return False
                current = Convert.ToInt16(parent) : guard += 1
            End While
            Return False
        End Function

        Private Shared Function CounterpartAmount(rows As List(Of DataRow), prefixes As String(), cash As Decimal) As Decimal
            Dim value = If(cash > 0D, rows.Where(Function(r) prefixes.Any(Function(p) Convert.ToString(r("AccountCode")).StartsWith(p))).Sum(Function(r) Money(r, "Credit")), -rows.Where(Function(r) prefixes.Any(Function(p) Convert.ToString(r("AccountCode")).StartsWith(p))).Sum(Function(r) Money(r, "Debit")))
            Return Math.Sign(cash) * Math.Min(Math.Abs(cash), Math.Abs(value))
        End Function

        Private Shared Function CounterpartAmountByRules(rows As List(Of DataRow), rules As DataTable, classification As String, cash As Decimal) As Decimal
            Dim ids = rules.AsEnumerable().Where(Function(r) String.Equals(Convert.ToString(r("ClassificationCode")), classification, StringComparison.OrdinalIgnoreCase)).Select(Function(r) Convert.ToInt16(r("AccountIdNo"))).ToHashSet()
            If ids.Count = 0 Then Return 0D
            Dim value = If(cash > 0D, rows.Where(Function(r) ids.Contains(Convert.ToInt16(r("IdNo")))).Sum(Function(r) Money(r, "Credit")), -rows.Where(Function(r) ids.Contains(Convert.ToInt16(r("IdNo")))).Sum(Function(r) Money(r, "Debit")))
            Return Math.Sign(cash) * Math.Min(Math.Abs(cash), Math.Abs(value))
        End Function

        Private Shared Function IsCompleteAllocation(rows As List(Of DataRow), cash As Decimal) As Boolean
            Return Math.Abs(rows.Sum(Function(r) Money(r, "Amount")) - cash) <= 0.005D
        End Function

        Private Shared Function ApprovedAmount(rows As List(Of DataRow), classification As String) As Decimal
            Return rows.Where(Function(r) String.Equals(Convert.ToString(r("ClassificationCode")), classification, StringComparison.OrdinalIgnoreCase)).Sum(Function(r) Money(r, "Amount"))
        End Function

        Private Shared Function AddLine(m As CashFlowModel, section As String, label As String, labelAra As String, amount As Decimal, Optional total As Boolean = False, Optional journal As IEnumerable(Of DataRow) = Nothing, Optional warning As Boolean = False) As CashFlowLineModel
            Dim line As New CashFlowLineModel With {.Section = section, .Label = label, .LabelAra = labelAra, .Amount = Decimal.Round(amount, 2), .IsTotal = total, .IsWarning = warning}
            If journal IsNot Nothing Then For Each r In journal : line.JournalLines.Add(New CashFlowSourceLineModel With {.JournalCode = Convert.ToString(r("JournalCode")), .JournalIdNo = Convert.ToInt32(r("JournalIdNo")), .ItemIdNo = Convert.ToInt32(r("ItemIdNo")), .TransactionDate = Convert.ToDateTime(r("TransactionDate")), .AccountCode = Convert.ToString(r("AccountCode")), .AccountName = Convert.ToString(r("AccountName")), .Debit = Money(r, "Debit"), .Credit = Money(r, "Credit")}) : Next
            m.Lines.Add(line) : Return line
        End Function

        Private Shared Function HasMovement(r As DataRow) As Boolean
            Return Not r.IsNull("ItemIdNo") AndAlso Not r.IsNull("TransactionDate")
        End Function
        Private Shared Function InPeriod(r As DataRow, b As Date, e As Date) As Boolean
            Return HasMovement(r) AndAlso Convert.ToDateTime(r("TransactionDate")) >= b.Date AndAlso Convert.ToDateTime(r("TransactionDate")) <= e.Date
        End Function
        Private Shared Function Money(r As DataRow, name As String) As Decimal
            Return If(r.IsNull(name), 0D, Convert.ToDecimal(r(name)))
        End Function
        Private Shared Function Bool(r As DataRow, name As String) As Boolean
            Return Not r.IsNull(name) AndAlso Convert.ToBoolean(r(name))
        End Function
    End Class
End Namespace

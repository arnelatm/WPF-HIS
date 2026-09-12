# Proposed cash-flow module for Accounts

Prepared 7 September 2026 from repository code and schema definitions at commit
`8f441df40`. This is a design proposal, not an implemented feature or an assessment
of production data. No database connections or changes were made during this review.

The proposed scope covers actual cash movements first, followed by forecasting.
This scope is an assumption pending the owner's preference.

Implementation update, 8 September 2026: the owner authorized the first
[Cash Position screen](Cash-Position-Screen.md), including SAR, posted and unposted
transactions, and petty-cash fund 113. Classified cash-flow reporting and the
13-week forecast remain subsequent stages. The December validation and test-copy
findings are recorded separately in [validation notes](Cash-Flow-Validation-Dec-2025.md).

## Recommendation

Add a Cash Flow module inside the existing Accounts WinForms application. Reuse
the accounting transactions already entered by staff. Build a direct cash-flow
report and cash-position screen first, then a rolling 13-week forecast using
outstanding invoices and explicitly entered plans.

The direct presentation answers practical questions: how much cash came in, where
it went, which account holds it, and what payments are approaching. A separate
indirect financial statement can follow if required. It should share reconciled
cash totals but would need additional noncash and working-capital reconciliation.

Operating, investing, and financing are suitable top-level categories for a
statement of cash flows. IAS 7 permits direct or indirect reporting of operating
cash flows and requires reconciliation to cash and cash equivalents in the
statement of financial position. Classification policies and disclosures must be
confirmed for the applicable reporting framework before treating this module's
output as a statutory statement. See the
[IFRS Foundation IAS 7 overview](https://www.ifrs.org/issued-standards/list-of-standards/ias-7-statement-of-cash-flows/).

## What is already available

| Existing component | Finding and proposed use |
| --- | --- |
| [Account classifications](../Accounts/MyEnums.vb) | `SpecialAccountSelection` identifies Bank (`BA`), Cash (`CS`), Checking Account (`CK`), and Petty Cash (`PC`). Suggest these as candidates for cash-account setup; allow explicit review rather than assuming every tagged account qualifies. |
| [Account table](../IspDataDb/dbo/Tables/Account.sql) and [BankAccount](../IspDataDb/dbo/Tables/BankAccount.sql) | Account names, Arabic names, hierarchy, reconciliation flag, and bank-to-ledger relationships already exist. Cash-flow inclusion, restrictions, and minimum-balance settings do not appear in these definitions. |
| [GlLedgers_View](../IspDataDb/dbo/Views/GlLedgers_View.sql) | Combines GJ, AP, AR, ER, CK, CD, CR, PC, and SJ detail lines. Includes account, debit, credit, date, reference, journal identity, cost center, and line posting state. It filters cancelled journals but does not impose a posted-only filter. |
| [CashReceiptJournalPresenter](../Accounts/PresentationLayer/Presenters/CashReceiptJournalPresenter.vb) | Builds the cash debit in the journal items. Count those ledger lines; do not add the receipt header amount again. |
| [FinancialReportPresenter](../Accounts/PresentationLayer/Presenters/FinancialReportPresenter.vb) | Provides date-period and bilingual Crystal reporting patterns. Its report-code list contains no cash-flow report. |
| [AccountBalance](../IspDataDb/dbo/Tables/AccountBalance.sql) and [LastPosting](../IspDataDb/dbo/Tables/LastPosting.sql) | Provide fiscal opening balances and closing boundaries. Their meaning must be validated against a selected historical period before reuse. |
| [AP open invoices](../IspDataDb/dbo/Views/ApOpenInvoice_View.sql) and [AR open invoices](../IspDataDb/dbo/Views/ArOpenInvoice_View.sql) | Expose balances, invoice identity, counterparties, and due dates: a useful starting point for forecast commitments. They are not historical as-of balance queries. |
| [AP payment items](../IspDataDb/dbo/Views/ApPaymentItems_View.sql) and [CsrOiItem](../IspDataDb/dbo/Tables/CsrOiItem.sql) | Link disbursements and collections to open invoices. These links can help explain cash movements and prevent invoice/forecast duplication. |
| [AccountReconciliation](../IspDataDb/dbo/Tables/AccountReconciliation.sql) and [its items](../IspDataDb/dbo/Tables/AccountReconciliationItem.sql) | Store reconciliation dates, statement balances, cleared lines, and review/finalization status. Useful for a reconciliation indicator, not a live bank balance feed. |

The relevant forms/services are explicitly included in `Accounts/Accounts.vbproj`,
and the listed schema objects are included in `IspDataDb/IspDataDb.sqlproj`.
The review found no cash-flow/forecast entry in the searched Accounts sources and
project definitions. Database-configured external reports were not inspected.

## Proposed screens

| Screen | Main behavior |
| --- | --- |
| Cash Position | Opening balance, receipts, payments, transfers, and closing book balance by selected cash/bank account. Show latest finalized reconciliation date separately and disclose the posting basis. |
| Cash Flow Statement | Date range, previous-period comparison, operating/investing/financing totals, and opening-to-closing reconciliation. Expand categories into source transactions and open the originating journal through existing permissions. |
| Classification Review | List unclassified or ambiguous cash movements. Let authorized staff assign/split amounts and record a reason. Show source document, cash amount, counterpart lines, and existing allocations together. |
| Cash Flow Setup | Select included cash accounts, bilingual categories, account defaults, restrictions, and minimum balances. Version mappings so changes do not silently rewrite approved reports. |
| Cash Forecast, second stage | Weekly receipts/payments for 13 weeks, expected closing cash, threshold alerts, and base/optimistic/conservative scenarios. Allow separate plans for payroll, rent, tax payments, equipment, and financing. |

The report and review grids should display English and Arabic labels and respect
existing RTL conventions. Use Crystal for printable reports. Export should use
an established repository export mechanism after confirming which one is active.

## Actual cash-flow calculation

1. Establish a reviewed set of cash/cash-equivalent ledger accounts for the report
   scope and period. Include inactive accounts with historical balances when
   appropriate. Do not select accounts by their English names or code prefix.
2. Read eligible ledger lines for those accounts across all supported journals.
   For normal cash asset accounts, `Debit - Credit` is the signed movement. Keep
   source debit/credit and document identity available for drill-down.
3. Use one normalized posting/cancellation policy for opening balances, movements,
   and closing balances. Owner decision on 8 September 2026: include posted and
   unposted transactions for the initial release, excluding cancelled journals.
   Label the basis "Posted and unposted" and retain posting status in drill-down.
   Apply this basis to pre-period movements as well as the report period. Flag
   header/detail posting disagreements for review; they do not exclude an otherwise
   eligible transaction in this mode. Unknown cancellation states and orphan or
   undated records require review and are not silently included.
4. Calculate opening cash from the validated fiscal balance snapshot plus eligible
   movements from that snapshot up to, but excluding, the report start. Add the
   snapshot once. Never treat beginning-balance rows as receipts. Exclude routine
   closing entries from cash-flow categories and review any closing entry that
   changes a selected cash account.
5. Identify transfers between the entity's included cash accounts before calculating
   external receipts/payments. Show each transfer in account-level movement
   schedules, eliminate matched principal from entity-wide cash flows, and retain
   transfer fees as external payments. A transfer to an account outside a selected
   subset still needs to explain that subset's closing balance. Unmatched transfers
   through clearing accounts go to review; do not infer matches solely from amount.
6. Classify the external cash portions, retaining amounts that cannot yet be
   classified in an explicit Unclassified category. Reconciliation must include
   them even while the report remains provisional.
7. Check opening cash plus net external flows equals closing cash for a single-
   currency scope without other reconciling movements. Where applicable, show
   exchange effects and changes in scope separately; do not hide them in operating
   cash. Account-level schedules also include transfers.

Count each source line once using a composite identity including journal code,
journal ID, and journal-item ID. IDs from separate journal tables are not globally
unique. Do not sum header amounts together with their corresponding ledger items.

Cash-account tags are not sufficient to establish available liquidity. Restricted
funds, cash equivalents, overdrafts, and clearing accounts require explicit setup
and accounting policy. The reviewed core journal/account tables do not expose a
transaction-currency/exchange-rate model sufficient to promise multicurrency cash
flow. Start with SAR: the owner confirmed on 8 September 2026 that all Accounts
ledger amounts are in Saudi riyals. This confirms the reporting currency, not a
multicurrency transaction model.

## Classification rules and examples

Use reviewed transaction allocations first, reliable source-document links second,
and account defaults for unambiguous cases. The cash account determines where the
money moved; the economic purpose determines its category.

| Example, illustrative SAR amounts | Expected treatment |
| --- | --- |
| Customer pays 10,000 against an invoice | 10,000 customer collection; the invoice itself is not an additional cash receipt. |
| Pay 6,000 rent directly from bank | 6,000 operating payment. |
| Pay 50,000 for equipment | 50,000 investing payment, including when settled through AP, subject to the confirmed policy. |
| Pay a 100,000 invoice using 98,000 cash and 2,000 discount | Cash outflow is 98,000. The discount is not another cash movement. |
| Transfer 20,000 bank-to-petty-cash with a separate 25 fee | Transfer principal is eliminated in the combined cash statement; 25 remains an external fee payment. |
| Pay 12,000 covering loan principal and interest | Split using the repayment schedule and the applicable classification policy. |
| Record depreciation or an unpaid supplier invoice | No actual cash flow until a qualifying cash movement occurs. |

AP control accounts can settle both supplies and fixed assets. Assigning every AP
payment to operating activities would therefore be unreliable. Mixed settlements,
partial payments, VAT, credit notes, and discounts need source-aware allocations
or a review step. Do not join every cash line to every counterpart line and sum
the result; that multiplies amounts in multi-line journals.

Require allocations for each cash movement to total its allocatable cash amount,
using `Decimal` and established money precision. Automatic splitting is permitted
only for a documented, reviewable rule; ambiguous transactions remain unclassified.
Changes to rules or source journals invalidate affected draft classifications.
Approved period output should retain its mapping version and calculation snapshot.

## Forecast calculation

Use a fixed as-of date, opening cash on the same basis, and one scenario. Build
future receipts from outstanding AR and payments from outstanding AP, then layer
in planned commitments not already represented by those invoices.

Keep contractual due date separate from expected receipt/payment date. Overdue
invoices need an explicit expected date or an unscheduled-overdue bucket; placing
all of them into tomorrow would overstate confidence. Expected dates can be based
on staff knowledge first, with payment-history estimates added after data quality
is established. Show gross scheduled values separately from probability-weighted
scenario values.

Existing open-invoice views aggregate payments without an as-of date. Historical
forecasts must either store the inputs when saved or use date-aware source queries
that join collections/payments to eligible transaction headers. Do not use today's
remaining invoice balance as the balance for last month's forecast.

Track source invoice/plan IDs and realized amounts so a planned payment is replaced
or reduced when an invoice/payment appears. This is also necessary when an unposted
payment has already affected the existing open-invoice allocation tables: the
forecast must include the pending cash event once, not lose it or count it twice.
Keep draft/unapproved commitments visibly separate.

Start the forecast from book cash for the selected basis. Do not subtract a posted
but uncleared cheque again: it has already affected book cash. A future bank-value-
date forecast would require its own reconciled opening and clearance model.

Weekly formula: opening cash + expected receipts - expected payments = closing
cash. The following week's opening equals the previous week's closing. Show bank
transfers in individual-account forecasts while eliminating them in combined totals.

## Fit with the existing application

Add the new vertical slice under Accounts, following the nearest active MVP screen:
view/interface, presenter, model, business objects, focused DAO, and Accounts service.
Use `MainForm.RunForm`, existing security keys, resource translation, and AutoMapper
registrations where the selected pattern needs them. Preserve .NET Framework 4.7.2
and the existing parameterized ADO.NET approach.

Create dedicated cash-flow read queries and result DTOs. Avoid adding cash-flow
classification logic to the widely shared ledger views, `Db.vb`, or journal save
procedures. Keep current atomic receipt/disbursement persistence and posted,
closed-period, approval, and reconciliation protections intact.

Candidate schema additions, to be finalized during implementation:

| Object | Purpose |
| --- | --- |
| `CashFlowAccount` | Reviewed cash scope, policy flags, effective dates, optional minimum balance; FK type aligned with `Account.IdNo` (`SMALLINT`). |
| `CashFlowCategory` | Bilingual category tree, operating/investing/financing classification, order, active state. |
| `CashFlowAccountRule` | Effective-dated defaults for counterpart accounts and supported transaction contexts. |
| `CashFlowAllocation` | Per-source movement/category split, amount, explanation, reviewer, mapping version, source fingerprint, and concurrency token. |
| `CashFlowReportRun` and detail snapshots | Reproducible reviewed period totals, parameters, mapping version, and source cutoff. |
| `CashFlowForecast` and `CashFlowForecastItem`, stage two | Scenario, as-of date, horizon, expected date, direction, amount, category, source links, realization, and review status. |

These are proposed names, not existing objects. Some journal updates replace detail
rows, so allocation keys must be checked against current source identity/content;
stale allocations must be surfaced for review rather than silently reassigned.
Save multi-row allocations and forecast edits transactionally. Add all new VB and
SQL files explicitly to their owning projects. Add indexes based on measured
date/account/source query plans on a restored test database.

Permissions should distinguish viewing, export/printing, setup changes,
classification review, and forecast editing/approval. Reading a report must never
post a journal or modify reconciliation state.

## Specific checks before implementation

* `GlLedgers_View` excludes cancelled journals but includes unposted lines.
  `GlStatementNew_View`, used by the account-activity functions, carries cancellation
  flags without the same filtering. The functions reviewed do not themselves impose
  a posted-only policy. Reconcile cash-flow results using identical filters.
* `GlLedgersNew_View` has an opening-balance join on `AccountBalance.IdNo = Account.IdNo`,
  while `GlStatementNew_View` joins `AccountBalance.AccountIdNo = Account.IdNo`.
  Do not adopt the similarly named view without checking which definition and
  opening-balance convention is authoritative in the target database. This review
  did not alter either view.
* Receipt headers and lines both have posting flags, and the inspected atomic insert
  accepts header posting state while inserting details without explicitly copying
  that flag. Trace posting operations and profile discrepancies on the restored
  database before defining the report filter.
* `BankAccount.AccountIdNo` is `INT`, while the account primary key is `SMALLINT`.
  New FKs and DTOs must follow the actual referenced type; avoid copying inconsistent
  widths from a nearby table.
* Validate whether external clinic/Kizen receipts are fully posted into Accounts.
  The cash-flow source should include their ledger postings once. Unposted external
  receipts would need a separately labelled integration stage.

## Delivery sequence and acceptance

1. **Data validation and setup:** confirm cash accounts, ledger currency, posting
   basis, one representative closed month, and classification policies. Reconcile
   opening/closing balances and profile cancelled, unbalanced, and duplicate lines.
2. **Actual cash position:** ship the account movement screen, date filters,
   transfer treatment, reconciliation indicators, and journal drill-down.
3. **Classified cash-flow reporting:** add category setup, allocation review,
   comparisons, reproducible period output, and bilingual Crystal printing.
4. **Forecasting:** add the 13-week schedule, AP/AR inputs, manual commitments,
   scenarios, threshold indicators, and actual-versus-forecast comparison.

Acceptance examples must cover new/existing receipts and payments, mixed-purpose
AP settlements, partial payments and discounts, transfers with fees, refunds,
reversals, cancelled/unposted journals, fiscal-year boundaries, zero-activity cash
accounts, and classification changes after source edits. Confirm report totals
against the ledger and explain differences from finalized bank reconciliations.
For forecasts, test historical cutoff behavior, invoice-to-payment matching,
overdue dates, and elimination of duplicate commitments. Test English and Arabic/RTL
layouts and permissions with realistic restored data.

Build the affected Accounts graph and ISPDATA DACPAC, then perform these workflow
checks. Production rollout requires the separately authorized deployment process,
a backup, and restored-test validation. No implementation schedule is committed by
this proposal; the data-validation stage determines the size of the classification
and forecast work.

Decisions for the owner: actuals versus forecast priority; included bank/petty-cash
accounts; posting basis; report currency; desired categories and reviewer; and
whether the first release is a management report or a formal financial statement.

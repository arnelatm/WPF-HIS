# Cash Position screen

The first cash-flow screen is implemented under **Reports > Cash Position** in
`HIS.sln` / `Accounts`. It reads existing tables through the Accounts DAO/service/
presenter stack. It does not create database objects or save journal, account,
reconciliation, or classification changes.

## Using the screen

1. Log in with access to the Cash Position report menu.
2. Open Reports > Cash Position. The initial dates are December 1-31, 2025, the
   agreed validation period. Change them when reporting another period.
3. Review the selected cash-account candidates. Bank, cash, checking and petty-cash
   tags provide candidates, including inactive accounts. All candidates initially
   appear selected; selections apply only to the current screen session.
4. Click Load balances. The grid shows opening, debit, credit and closing amounts
   in SAR, including both posted and unposted transactions. Cancelled journals
   are excluded. Debits and credits include internal transfers.
5. Select an account row to see its period transactions, including journal code,
   journal ID, line ID, reference, notes, and both header/detail posting states.
   The detail grid is read-only; use its horizontal scrollbar for further columns.
6. Double-click a transaction cell to inspect the complete source journal in a
   popup. It reloads the journal by code, journal ID and cash-line ID, and shows
   all account lines (including non-cash accounts), header notes, posting,
   approval/cancellation states, and total debits, credits and difference.
   The clicked line is selected. Close the popup or press Escape to return.
   This is a read-only inspection; it does not edit, post or print the journal.

Changing dates or account checks clears the previous results so old balances are
not displayed under new filters. All amounts are book balances. There is no bank
feed, transfer classification, export/printing, forecast, or journal edit action
in this first screen. Labels and account names follow English/Arabic culture and
RTL layout. Filter and transaction dates both display Gregorian dates.

## Calculation and review flags

The query uses the opening snapshot for the start date's calendar year and adds
eligible source lines from January 1 through the report end. Lines before the
report start contribute to opening cash; lines within the period contribute to
debits and credits. Closing = opening + debits - credits. A report crossing into
another year continues from the first snapshot; it does not add the next opening
snapshot again.

A missing or unbalanced start-year snapshot stops the report. A missing individual
account snapshot row is provisionally zero and visibly flagged. Negative opening/
closing balances, cash-affecting closing entries, and header/detail posting
disagreements are flagged for review. Posting disagreements do not exclude lines
under the owner-selected inclusive basis. Duplicate source identities stop the
calculation. Identities include journal code, journal ID and item ID.

Undated records, orphan detail rows and unknown cancellation states are excluded
from dated balances and require separate investigation. See the
[December validation notes](Cash-Flow-Validation-Dec-2025.md) for existing data
exceptions, including petty-cash account 113's negative opening. This screen does
not repair those records or certify available liquidity.

## Integration

- The menu is added before MainForm's normal security traversal. Its name is
  `ToolStripMenuItemCashPosition`. Existing super-admin rules apply; ordinary
  users need the corresponding Reports > CashPosition menu security permission.
  Missing permission remains denied. No security rows were created or granted.
- A standalone result model is populated explicitly by `CashPositionService`.
  No view/business-object AutoMapper mapping or reflection-created cash-flow
  business object is used for these read-only query results.
- All new VB files and English/Arabic resources are explicitly included in
  `Accounts.vbproj`. The form uses BFMain's language hooks and programmatic layout,
  following the existing standalone reporting/utility screen pattern.
- No application configuration was changed for this feature. Queries use the
  application's selected Accounts connection; the verification harness builds
  its explicitly selected test connection in memory.

## Verification

Build the affected graph in Developer PowerShell:

```powershell
msbuild Accounts\Accounts.vbproj /m /p:Configuration=Debug
```

Run offline calculation checks in a fresh Windows PowerShell process:

```powershell
powershell -NoProfile -File tools\Test-CashPosition.ps1
```

For the owner-authorized ISPADMIN2 / ISPDATA test copy, add the read-only baseline
and offscreen visual checks:

```powershell
powershell -NoProfile -File tools\Test-CashPosition.ps1 -Server ispadmin2 -Database ispdata -ReadOnlyTestDatabase -Render
```

The database checks assert the reviewed December baseline, so a restored copy
with different source data can legitimately fail those expectations. The harness
does not read or replace `app.config`. Rendered images are saved under `.tmp`.
Rendering bypasses the inherited application startup/load handlers and does not
substitute for an integrated login/menu/language-switch smoke test.

Add `-CheckCaptions -CheckTransactions` to verify all grid headers, double-click
dispatch, full-voucher mapping, missing source handling, and English/Arabic popup
rendering. With `-ReadOnlyTestDatabase`, it also checks all nine journal query
schemas and compares the clicked cash lines with their complete source journals.
Use `-BinaryDirectory <path>` when verifying a separate build directory. Popup
renders are saved as `.tmp/cash-transaction-en-GB.png` and
`.tmp/cash-transaction-ar-SA.png`.

Completed on 8 September 2026: Accounts project graph built with 0 errors and
20 existing dependency/interop/member-shadowing warnings. Offline checks and
read-only test-copy checks passed, including the 661 December cash lines,
SAR 42,520.50 opening and SAR 158,918.23 closing. English and Arabic renders
were visually reviewed. The checks also verify the Gregorian date display and
that changing filters clears previously loaded results.

Before rollout, verify the menu under the normal user and denied-access user,
switch languages through the application, and review the selected account scope
and balances with the owner. Production deployment and permission changes remain
separate from this implementation.

# December 2025 cash-flow validation

Reference period selected by the owner: **1-31 December 2025**.
SQL uses `>= 2025-12-01 AND < 2026-01-01` to include the whole final day.

Executed 8 September 2026 against **ISPADMIN2 / ISPDATA**, confirmed by the owner
as a test copy. Windows authentication succeeded and the server/database identity
matched. Only read-only queries were executed; no application implementation,
database data changes, or schema changes were made.

The [discovery queries](Cash-Flow-Validation-Dec-2025.sql) and
[balance and exception queries](Cash-Flow-Balance-Dec-2025.sql) are standalone
diagnostics, intentionally outside the SQL project's build/deployment list.
The latter were executed in two batches as the investigation progressed.
Its balance query was then rerun with posted and unposted included after the
owner selected that basis. All 12 candidate account results matched the earlier
posted-only results, including opening balances, December movements, closing
balances, and differences from the 2026 snapshot.

## Source findings

- `GlLedgers_View` is included in `IspDataDb.sqlproj`. It reads item-level posting
  flags and requires header `Cancelled=0`, excluding NULL cancellation states too.
- Included `PostMonthlyJournalEntries` and `PostFiscalYearJournalEntries` update
  both header and detail posting states. The executed checks found agreement for
  dated 2025 detail rows with existing headers; exceptions below are separate.
- Included `FinalizeFiscalYearClose` uses `AccountBalance.Year=FiscalYear` as the
  opening snapshot and writes `FiscalYear+1` after closing. It omits zero balances
  from the proposed next-year snapshot. A missing account row therefore needs
  investigation; it does not automatically prove a missing opening balance.
- `FinancialReportPresenter` selects the snapshot year differently depending on
  report type and the current fiscal close boundary. Its latest-year selection
  must not be copied into the December 2025 calculation without validation.
- Cash transfers cannot be inferred reliably from equal amounts. The diagnostic
  lists all counterpart lines for candidate cash journals for manual review.

## Validation sequence

1. Confirm the restored test server/database and authorize the SELECT diagnostics.
2. Review the full account list, including inactive accounts and accounts without
   cash tags. Confirm the cash scope, ledger currency, and posting basis.
3. Inspect close boundaries, available 2025/2026 snapshots, empty/unbalanced
   journals, invalid items, posting disagreements, and cancellation states.
4. After confirming the snapshot convention and source eligibility, calculate
   December opening from the 2025 opening snapshot plus January-November eligible
   movements. Add December eligible movements once to obtain December closing.
   Reconcile against independently trusted balances at November 30 and December 31;
   use the 2026 opening snapshot as an additional check if available and validated.
5. Review cash-affecting closing entries, transfers, fees, mixed settlements,
   source-identity duplicates, and clearing-account transfers across documents.
   Explain bank reconciliation differences separately from book cash.

The initial queries support discovery; they do not calculate approved cash totals,
detect every orphan detail row, or establish a complete historical posting policy.
After the account scope is confirmed, extend the checks to January-November and
undated/orphan rows before accepting the December opening balance.

Confirmed by the owner: account **113 - Imprest Fund is a petty-cash fund** and
belongs in the cash-flow account scope. Replenishments from other included cash
accounts are internal transfers; payments from the fund require classification
by their purpose. Matching and allocation still require transaction review.

The owner also confirmed on 8 September 2026 that all Accounts ledger amounts
are in **Saudi riyals (SAR)**. Use SAR for the initial cash-position and cash-flow
reports.

The owner selected **posted and unposted transactions** for the initial release
on 8 September 2026. Exclude cancelled journals and label the report basis
"Posted and unposted". Apply the same policy to pre-period and period movements.
Retain posting status in transaction detail. Orphan/undated records and unknown
cancellation states remain review exceptions; this decision does not authorize
posting, correcting, or restoring journal records.

Pending owner inputs: remaining cash account selection, trusted
comparison balances, and classification reviewer.
Do not run posting/closing procedures to make validation differences disappear.

## Executed results

- Both `Closed Period` and `LastFiscalYearEnd` are 2025-12-31.
- All 493 December journal headers are posted and noncancelled. No empty journals,
  unbalanced journals, posting disagreements, or invalid items were returned for
  December. Counts: AP 25, AR 25, CD 90, CR 18, ER 19, GJ 27, PC 231, SJ 58;
  no CK journals were returned for the month.
- The full-year query returned no unbalanced dated 2025 journals, no duplicate
  source identities in `GlLedgers_View`, and no cash-tagged closing-journal lines.
- The 2025 opening snapshot has 50 rows and balances at 8,128,217.22 per side.
  The 2026 opening snapshot has 39 rows and balances at 8,552,997.40 per side.
- There are 12 cash-tagged account candidates. Five have December activity;
  the remaining seven have no December movements and no 2025/2026 snapshot
  rows. Those missing rows are provisionally treated as zero, pending scope review.

### Candidate cash position

All amounts below are in **SAR**, as confirmed by the owner.
Initial validation used posted headers and items. The selected reporting basis
includes posted and unposted, with header cancellation explicitly false and
transaction date in 2025, plus the 2025 opening snapshot once.
Debits/credits include transfers
and are not classified external receipts/payments. All five calculated closing
balances agree with the 2026 opening snapshot, treating the omitted zero balance
for account 113 as zero. This is internal consistency, not independent proof of
cash on hand or bank balances.

| Code | Account | December opening | December debits | December credits | December closing |
| --- | --- | ---: | ---: | ---: | ---: |
| 104 | Cash on Hand | 37,513.66 | 158,351.86 | 158,757.04 | 37,108.48 |
| 106 | Cash in Bank NCB (PC) | 1,494.70 | 229,884.09 | 216,167.44 | 15,211.35 |
| 107 | Cash in Bank Riyad Bank | 12,958.63 | 84,126.40 | 0.00 | 97,085.03 |
| 113 | Imprest Fund | -11,143.41 | 89,664.54 | 78,521.13 | 0.00 |
| 127 | Cash in bank Riyad (Pharmacy) | 1,696.92 | 7,816.45 | 0.00 | 9,513.37 |
| | Provisional total | 42,520.50 | 569,843.34 | 453,445.61 | 158,918.23 |

Other candidates: 105 Cash in Cash Register, 108 Petty Cash, 109 Cash in Bank NCB
(Phar.), 110 Cash in Bank AlBilad, 115 NCB Marwan (inactive), 122 Cash in Bank SBB
(Old) (inactive), and 125 NCB (WALISET). Do not decide historical inclusion from
current active state alone. The full 223-account list was retrieved for owner
review; tags cannot prove that this candidate list is complete.

### Exceptions and decisions

1. **Account 113:** the owner confirmed it is a petty-cash fund. Include it in the
   cash-flow scope. Its negative opening of 11,143.41 remains a reconciliation
   exception; confirmation of the account's purpose does not resolve that balance.
   All dated 2025 ledger movements for this account are CD debits and PC credits.
   The net December increase of 11,143.41 clears its negative opening. Preserve
   the recorded balance while investigating; no correcting entries are authorized.
2. **Orphan detail rows:** 42 items (ER 28, GJ 6, PC 8) have no matching journal
   header. All have item `Posted=0`; their dates cannot be established, so they
   must not be described as December or even 2025 transactions. Eight are on
   tagged cash accounts, with total credits of 6,215.00 (106: 270.00; 113: 5,945.00).
   They are excluded from the provisional balance and need separate investigation.
3. **Empty/undated headers:** 15 posted, noncancelled dated headers have no items,
   all before December: CR 4078; ER 9328, 9329, 9338; GJ 11463, 12501, 12503;
   PC 10768, 10772, 10775, 10777, 10782, 10810, 12352, 12701. AP 14361 is an
   additional cancelled, unposted, undated empty header. The initial aggregate
   query counts missing detail/header states in its review columns; those counts
   do not indicate disagreements between two existing posted records.
4. **Remaining validation:** confirm the remaining account scope, compare November
   30 and December 31 balances to independently trusted reports/reconciliations,
   then review transfers, restrictions, and category policies. Source totals alone
   do not establish usable liquidity or approved external cash-flow totals.

Raw local outputs are under `.tmp/cashflow-dec2025-*-20260908.*` and are not intended
for version control. Existing unrelated working-tree changes were preserved.

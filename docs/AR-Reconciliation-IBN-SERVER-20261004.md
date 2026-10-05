# Live AR reconciliation - 4 October 2026

Read-only checks executed against **IBN-SERVER.ISPDATA**, confirmed by server/database guards. Initial audit server time was 2026-10-04 10:33:12. Cutoff: 4 October 2026; summary period begins 1 January 2026 and includes the function's prior-period carry-forward. Follow-up queries ran later in the same session. A fresh direct live recheck at server time 2026-10-04 11:34:36 found the same totals and exceptions; the account-level and cancelled-allocation checks were also rerun. No production schema/data changes, stored-procedure executions, or deployment were performed. The actual allocation table is `dbo.CsrOiItem`.

## Later live recheck: 18:24 server time

The AR/CA difference recorded below is now zero. Read-only queries against **IBN-SERVER.ISPDATA** at 2026-10-04 18:24:09 found no customer/account difference between `ArStatement_View` and `ArOpenInvoice_View` above 0.005. AR is **114,043.57** in both sources; CA is **-9,080.50** in both. `FuncArSummary`, `ArStatement_View`, `ArAging_View`, and `ArOpenInvoice_View` each total **104,963.07**. These are application-source balances including unposted activity, not posted GL certification.

Receipt details for 4076, 4105, 4157, and 4158 now credit AR rather than leaving the earlier CA amounts. Audit events at 15:09-15:12 UTC record account and amount changes to the affected receipt details, including removal of the extra CA lines on 4076 and 4105. The earlier 2,752.50 analysis remains below as an audit snapshot; no further reclassification of those receipts is proposed from this recheck. The dates of allocations to later invoices still need separate historical/cutoff review.

All four changed receipts have equal total debits and credits. Their current AR/CA credits equal their CsrOiItem allocation sums: 4076 **16,445.00**, 4105 **5,945.50**, 4157 **756.00**, and 4158 **253.00**; each header has the same Applied amount and zero UnApplied.

The cancelled receipt 2285 remains unresolved. At 18:24:51 server time its three allocations were still present and still cleared open items 57, 65, and 76. It is the only cancelled receipt with allocations in the current database (rechecked at 18:27:34). The source has no audit events for the 2017 receipt or those allocations, so its intended historical status could not be established from the current database audit trail. The incorrect marker header links 1150 and 1152 also remain unchanged at 18:28:26.

## What is now corrected

| Source | Combined customer balance |
|---|---:|
| FuncArSummary | 104,963.07 |
| ArStatement_View | 104,963.07 |
| ArAging_View | 104,963.07 |
| ArOpenInvoice_View | 104,963.07 |

There are no combined statement/open-item customer differences and no summary/statement customer differences.

The live resolver function now exists. AR 11198 correctly attributes marker 2820/detail 10209 to customer 373 (Al-Malik), +51.75, and marker 2821/detail 10210 to customer 1381 (Tahlia), -51.75. Both markers remain in place; no extra marker is required.

| Receipt | Customer | Amount | Applied | UnApplied | CsrOiItem total | Detail credit |
|---|---|---:|---:|---:|---:|---|
| 4162 | MWAFQ / 1388 | 3,058.00 | 3,058.00 | 0.00 | 3,058.00 | AR 3,058.00 |
| 4211 | Major Drilling Arabia / 1390 | 956.52 | 956.52 | 0.00 | 956.52 | AR 956.52 |

These two receipts are unposted/unapproved and now internally consistent. Allocations 3176, 3177, 3178 still reference the intended invoices. Open items 2698 and 2765 have zero balance; 2814 has 1,235.98 remaining. Across active customer receipts, no header Applied/UnApplied equation, allocated amount, or discount-total mismatch was found.

## Earlier account-level discrepancy: 2,752.50 (11:34 snapshot)

Combined customer balances hide an AR/CA classification mismatch. Here CA means customer advances. The following comparison uses the same cutoff and separates each special account in the statement and open-item views.

| Customer | Account | Statement ledger | Open-item balance | Ledger minus open items |
|---|---|---:|---:|---:|
| Stars Smiles Clinic (Al-Rehaily) / 381 | AR | 3,736.00 | 2,980.00 | +756.00 |
| Stars Smiles Clinic (Al-Rehaily) / 381 | CA | -756.00 | 0.00 | -756.00 |
| MWAFQ / 1388 | AR | 1,996.50 | 0.00 | +1,996.50 |
| MWAFQ / 1388 | CA | -1,996.50 | 0.00 | -1,996.50 |

| Account | Statement total | Open-item total | Difference |
|---|---:|---:|---:|
| AR | 116,796.07 | 114,043.57 | +2,752.50 |
| CA | -11,833.00 | -9,080.50 | -2,752.50 |

These are application-source balances including unposted activity, not a certification of posted GL control-account balances.

### Receipt details explaining the classification

- Receipt **4157**, customer 381, dated 6 May 2026: 756.00 cash, Applied 756.00, UnApplied zero, allocation 2853 clears AR open item 2713/invoice journal 11107. Detail 2908 still credits CA 756.00. The invoice date is 11 May, after the receipt. No offsetting 2026 CA debit was found for this customer in the statement view.
- Receipt **4158**, MWAFQ, dated 24 May: 253.00 cash, Applied 253.00, UnApplied zero, allocations 2854/2855 total 253.00 against open items 2698/2716. Detail 2910 still credits CA 253.00.
- Receipt **4105**, MWAFQ, dated 23 April: cash 5,945.50 plus CA debit 808.50, offset by AR credit 5,010.50 and CA credit 1,743.50. Allocations now total 5,945.50, including a later 935.00 application. The remaining CA credit 1,743.50, plus receipt 4158's 253.00, equals MWAFQ's 1,996.50 discrepancy.
- Receipt **4076** originally credits CA 808.50, which receipt 4105's CA debit offsets. Treat those receipts as a linked advance/application chain; do not independently reclassify every flagged receipt.

Proposed next case work: review the documents and effective application dates for 4157, 4158, 4105 and the linked 4076. On a restored test copy, correct the AR/CA application representation while keeping cash totals, existing invoice IDs and CsrOiItem allocations intact. If correcting original unposted receipt details is appropriate, use the atomic receipt workflow and verify both account-level and invoice-level balances afterward. If the application needs a later dated transaction, the posting/allocation workflow must explicitly avoid introducing another open credit for amounts already allocated. A normal additional AR credit marker or another cash receipt would risk counting the payment twice. Do not change only header Applied figures: these already match allocations.

## Cancelled receipt still affects invoice clearing

Cancelled, posted receipt **2285**, dated 17 July 2017, customer 313 (SAMAR SWEETS), has amount zero and no receipt details, but retains three allocations:

| Allocation | Open item | Source AR journal | Allocation | Current balance | Balance excluding cancelled allocations |
|---|---:|---:|---:|---:|---:|
| 56 | 57 | 7552 | -1,100.00 | 0.00 | -1,100.00 |
| 57 | 65 | 7638 | +200.00 | 0.00 | +200.00 |
| 58 | 76 | 7650 | +900.00 | 0.00 | +900.00 |

Live `ArCollections_View` sums all CsrOiItem allocations without joining to the receipt cancellation flag. Consequently, these rows still clear individual invoices and the credit. Their net is zero, so removing their effect would leave the customer grand total unchanged while reopening the three items.

Proposed solution: establish whether this was an intended credit application or a genuinely cancelled application. If intended, preserve its history through a valid active application record; if cancelled, reverse/exclude its clearing effect. Define cancellation behavior consistently in saving, allocation lookup, and collections. Test the change against this exact case and active partial/negative allocations. Do not merely toggle a historical posted receipt or silently delete its allocation history.

## Historical source-link problems remain

1. **Two incorrect marker headers**: marker 1150 points to header 9573 but detail 6353 belongs to 9574 (345.00); marker 1152 points to 9575 but detail 6356 belongs to 9576 (275.00). Both have zero allocations. Correct the existing source link after test verification and uniqueness/reference checks; do not insert replacement markers.
2. **37 unresolved markers**: 11 AR markers reference missing details; 25 CR markers reference missing details; one CR marker, 900, references receipt 2629 whose PayorType is O, not A. No allocations or discounts are linked to these markers. Review archived/source documents before deciding whether to relink or archive them. Do not recreate invoice amounts from marker IDs.
3. **One repeated AR detail key**: markers 1133/1134 both reference missing detail 6279. There are no duplicate complete code/header/detail keys. The partial-key duplicate is part of the unresolved-marker review.
4. **Six active AR headers with no details**, all with matching populated header candidates:

| Empty header | Matching populated candidate(s) | Amount |
|---|---|---:|
| 9573 | 9574 | 345.00 |
| 9575 | 9576 | 275.00 |
| 9647 | 9648 | 2,976.00 |
| 10959 | 10958, 10960 | 6,113.83 |
| 10970 | 10969, 10971 | 6,017.69 |
| 11134 | 11135 | 810.00 |

Matching candidates share customer, date, reference, invoice number and header amount. This is evidence of possible superseded/duplicate headers, not proof that every candidate is interchangeable. AR 11134 and 11135 both show White Flame customer 1385, 31 May 2026, reference 05-038, invoice i-290, amount 810.00; 11135 has five balanced details. Do not add another 810.00 invoice to compensate for 11134.

5. **34 historical unbalanced AR journals**, 2017-2020, net -6,059.50. Earlier grouping work found many offset across same-date/reference journals. Retain document/other-journal review; no automatic balancing entries are proposed.

## Findings that should not trigger automatic repairs

- No orphan AR/CR details, no active CR headers without details, and no unbalanced active CR journals were found.
- No CsrOiItem lacks its marker or receipt header; no active allocation has an unresolved/wrong customer; no zero-value allocation rows and no overapplied/sign-reversed open balances were detected.
- No populated active AR selected contact fails the customer/contact resolution check; no active A-type receipt has a missing customer.
- Six repeated receipt/invoice pairs are explained by offsetting allocations in receipt 2759 (three pairs) or split positive allocations in 4023, 4109 and 4187. These do not prove duplicate payments. Deleting repeated pairs or adding a blanket unique receipt/invoice constraint would break existing valid patterns.
- Eight nonzero CR candidates without exact markers remain in ARInvoices_View, down from ten after 4162/4211 were corrected: receipts 2454, 2457, 2671, 2858, 2977, 2979, 3956 and 4067. Candidate amounts represent entire detail lines and are not automatically missing remaining credit balances. Do not insert them wholesale.
- Fourteen receipt-level AR/CA review candidates remain, but their per-receipt differences include legitimate advance/credit applications. Account-level reconciliation isolates the current combined discrepancy to customers 381 and 1388.

## Reporting and future integrity work

- Aging currently groups net statement activity by **transaction date**, not invoice remaining balance by **due date**. There are 270 positive-balance AR open items, with no missing due dates; 178 have due dates different from transaction dates. Agreement of the total is not validation of overdue buckets.
- CsrOiItem has no effective application-date column. There are 149 allocations to later-dated invoices, including 17 whose receipt date is in 2026. These may include legitimate advances or migration dates; they are review flags, not automatically wrong payments. Filtering invoice dates alone cannot produce reliable historical open balances because current collection sums are not cutoff-aware.
- Live receipt Save/Update atomic procedures both have header-equation, allocation-total, customer-ownership checks, and a 2026 date gate. These checks do not repair older rows. Preserve their transaction, posted and reconciled protections in any future change.
- Suggested future work: separate active clearing from cancelled/reversed applications, record effective application dates, build cutoff-aware invoice balances, and derive overdue buckets from remaining balances and due dates. Keep unapplied credits visible and support legitimate negative/split allocations.

## Recommended order

1. Review the later AR/CA reclassification against source documents and application dates on a restored test copy; the current live account totals agree, so no further amount adjustment is indicated by this comparison.
2. Determine the intended status of receipt 2285's credit application and test cancellation-aware clearing.
3. Test correcting the two existing marker header links; then classify/archive superseded empty headers and unresolved markers with evidence.
4. Address cutoff-aware collections and due-date invoice aging separately from historical data cleanup.

The database audit does not certify rendered Crystal reports or posted GL balances. Queries used committed reads, not one database-wide point-in-time snapshot. No changes were committed or pushed as part of this investigation.

# AR reconciliation ? ISPADMIN2.ISPDATA ? 3 October 2026

Read-only audit of the restored test database after the detail-party fix. No data, schema, or reports were changed during this audit. "CroiItem" is treated as `dbo.CsrOiItem`, the receipt-to-open-item allocation table. Period parameters were 1 January?3 October 2026; opening balances include earlier activity as implemented by the report functions. Open items were compared through the same cutoff; there are no allocations after that date in this restored copy. These results describe the restored database, not a newly queried live production database.

## Reconciled totals

| Source | Balance |
|---|---:|
| FuncArSummary | 104,963.07 |
| FuncArStatement across customers | 104,963.07 |
| ArAging_View | 104,963.07 |
| ArOpenInvoice_View | 108,977.59 |
| Open items minus summary/statement | **4,014.52** |

Summary versus statement differs for **zero customers**. The checked local Crystal summary/statement reports call these functions. Their SQL commands and balance formulas were inspected without refreshing, printing, or modifying reports; final rendered reports and site-deployed report copies were not verified. Totals include the AR and customer-advance activity used by the reports and are not a posted-only general-ledger reconciliation.

## Confirmed balance difference

| Customer | Statement/summary | Open items | Difference | Missing unapplied receipt |
|---|---:|---:|---:|---|
| MWAFQ (1388 / code 1636) | 0.00 | 3,058.00 | 3,058.00 | CR 4162, ref 06-078, 23 June 2026; detail 2918, CA account 128 |
| Major Drilling Arabia (1390 / code 1647) | 1,235.98 | 2,192.50 | 956.52 | CR 4211, ref 08-130, 20 August 2026; detail 3030, CA account 128 |

Both receipts have Applied=0 and UnApplied equal to the full amount. Their bank/cash debits and customer-advance credits balance. The missing credit open items explain the entire current difference. Recommended future repair: verify these details and create one negative CR open-item marker per actual unapplied credit, preserving source links and preventing duplicates. The cash-receipt save/update path should maintain eligible unapplied-credit markers atomically. Do not create markers for every applied AR receipt credit; that would count payments twice.

## Structural and historical findings

- **37 unresolved open markers:** 11 AR markers point to missing detail rows; of 26 CR markers, 25 point to missing details and one is excluded because its receipt has a different payer type. None has allocated cash/discount in CsrOiItem. Review the raw history before removing or reattaching them.
- **Two wrong AR journal links:** marker 1150 belongs to detail 6353 in journal 9574 but stores journal 9573; marker 1152 belongs to detail 6356 in journal 9576 but stores journal 9575. Amounts are 345.00 and 275.00, customer 354. The empty headers 9573/9575 share the invoice/date/reference/amount with 9574/9576. The open view currently joins on code/detail without checking journal ID, which hides these header-link errors. Correct links after verifying the replacements; do not insert additional markers.
- **One duplicated code/detail key:** AR detail 6279 appears in markers 1133 and 1134 under different headers. The detail is missing; the full source-key unique constraint does not detect this duplicate.
- **Six active headers without detail rows:** 9573, 9575, 9647, 10959, 10970, 11134. The first two have evident replacement headers; the remaining four need document-level investigation. Their amounts are respectively 2,976.00, 6,113.83, 6,017.69 and 810.00. Journal 11134 is a current-year exception dated 31 May 2026, customer 1385. Header amount alone does not prove an omitted legitimate invoice.
- **34 individually unbalanced AR journals, all dated 2017?2020.** Thirty-one balance when grouped by transaction date/reference, consistent with separately stored historical debit/credit halves. Three remain unmatched in the AR journal grouping: 7846 (+400.00), 8657 (-2,016.50), 8959 (-4,443.00), net -6,059.50. Check original documents and other journal types before changing historical accounting.
- **Two header/detail amount mismatches:** journals 8291 and 8566 (31 January 2019, ref 01-092) have header Amount=13,859.70 but first-detail magnitude=14,223.87, difference 364.17 each. They may be related adjustments; amounts alone do not establish which value is correct.
- **14 receipt classification exceptions** compare header Applied/UnApplied to AR/CA detail totals. Some shift prior advances into AR or otherwise reclassify balances and can be legitimate. Their allocations match their headers; they are review candidates, not confirmed erroneous payments.
- **Ten unmarked receipt candidates** from ARInvoices_View. Only the two above produce the present customer-level discrepancy. Other candidates involve historical advances later applied or reclassified. Their full detail amount must not be used automatically as a missing credit amount.
- **1,172 raw PaidAmount/DiscountTaken cache differences.** ArOpenInvoice table totals are PaidAmount=984,714.05 and DiscountTaken=1,196.15; values derived from allocations are 3,902,664.23 and 26,474.12. The active open-item view uses derived allocation values, so these stale table fields do not cause the 4,014.52 difference. Avoid treating the raw fields as authoritative or refreshing them without assessing consumers.

## Checks without detected exceptions

No allocation lacks an open marker or receipt header. No active AR receipt allocation belongs to a different resolved customer. Receipt Amount equals Applied+UnApplied, allocations equal Applied, and allocated discounts equal header discounts for active AR receipts. No overapplied/sign-reversed open balances were detected. No active AR control line has an invalid selected contact, and no AR detail lacks its header. Three allocation rows on a cancelled receipt have zero amount and discount, so they currently have no balance effect.

AR 11198 remains correct after the deployed fix: marker 2820/customer 373/+51.75 and marker 2821/customer 1381/-51.75.

## Aging limitation

ArAging_View groups net journal activity by transaction date rather than aging the remaining balance of each invoice by its due date. Its grand total matches the statement, but that does not establish accurate overdue invoice buckets: a later receipt can appear as a recent negative bucket instead of reducing the old invoice bucket. A future invoice-aging design should use correctly attributed open items, dated applications for the requested cutoff, due dates, and separately identifiable unapplied credits.

## Suggested order of work

1. Correct the two unapplied-credit omissions on the restored test database and prevent recurrence in receipt save/update.
2. Investigate current-year empty header 11134 and the two wrong journal links; preserve markers and payment identities.
3. Classify broken historical markers, duplicate source keys, header-only records, and legacy journal splits before any historical repair.
4. Align invoice-level aging with the reconciled open-item model, then verify the rendered reports in English and Arabic.

No repairs were executed. Detailed query results follow.

## Detailed exception results


### CUSTOMER BALANCE DIFFERENCES

| IdNo | CustomerCode | CustomerName | StatementBalance | OpenBalance | Difference | AdvanceBalance |
| --- | --- | --- | --- | --- | --- | --- |
| 1388 | 1636 | MWAFQ | .0000 | 3058.0000 | 3058.0000 | -5054.5000 |
| 1390 | 1647 | Major Drilling Arabia | 1235.9800 | 2192.5000 | 956.5200 | -956.5200 |

### AR MARKER LINK MISMATCHES

| IdNo | StoredJournal | JournalItemIdNo | ActualJournal | TransactionDate | ReferenceNo | Amount | Allocations |
| --- | --- | --- | --- | --- | --- | --- | --- |
| 709 | 9145 | 4045 | NULL | NULL | NULL | NULL | 0 |
| 717 | 9153 | 4111 | NULL | NULL | NULL | NULL | 0 |
| 724 | 9160 | 4142 | NULL | NULL | NULL | NULL | 0 |
| 1040 | 9467 | 5823 | NULL | NULL | NULL | NULL | 0 |
| 1133 | 9557 | 6279 | NULL | NULL | NULL | NULL | 0 |
| 1134 | 9558 | 6279 | NULL | NULL | NULL | NULL | 0 |
| 1209 | 9628 | 6607 | NULL | NULL | NULL | NULL | 0 |
| 1272 | 9685 | 6884 | NULL | NULL | NULL | NULL | 0 |
| 1276 | 9689 | 6898 | NULL | NULL | NULL | NULL | 0 |
| 2620 | 11019 | 9448 | NULL | NULL | NULL | NULL | 0 |
| 2693 | 11089 | 9721 | NULL | NULL | NULL | NULL | 0 |
| 1150 | 9573 | 6353 | 9574 | 2024-01-31 | 01-139 | 345.0000 | 0 |
| 1152 | 9575 | 6356 | 9576 | 2024-02-29 | 02-138 | 275.0000 | 0 |

### UNRESOLVED OPEN MARKERS

| JournalCode | Records | AllocatedAmount | Discount |
| --- | --- | --- | --- |
| AR | 11 | .0000 | .0000 |
| CR | 26 | .0000 | .0000 |

### AR LINES WITHOUT EXACT MARKERS

| IdNo | TransactionDate | ReferenceNo | ItemId | Sequence | Amount | CustomerIdNo |
| --- | --- | --- | --- | --- | --- | --- |
| 9574 | 2024-01-31 | 01-139 | 6353 | 1 | 345.0000 | 354 |
| 9576 | 2024-02-29 | 02-138 | 6356 | 1 | 275.0000 | 354 |

### STRUCTURAL COUNTS

| Issue | Records |
| --- | --- |
| Duplicate full source keys | 0 |
| Duplicate code/detail keys | 1 |
| Allocation missing open marker | 0 |
| Allocation missing receipt header | 0 |
| Allocation wrong customer | 0 |
| Invalid selected AR contact | 0 |
| AR header without details | 6 |
| AR detail without header | 0 |

### RECEIPT ALLOCATION TOTAL MISMATCHES

| IdNo | TransactionDate | ReferenceNo | PayorIdNo | Amount | Applied | UnApplied | Allocated | AllocatedDiscount | HeaderDiscount |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |

No exceptions found.

### OVERAPPLIED OR SIGN-REVERSED OPEN ITEMS

| IdNo | JournalCode | JournalIdNo | CustomerIdNo | Amount | PaidAmount | DiscountTaken | Balance |
| --- | --- | --- | --- | --- | --- | --- | --- |

No exceptions found.

### UNBALANCED AR JOURNALS

| IdNo | TransactionDate | ReferenceNo | Amount | Posted | Debit | Credit | Difference |
| --- | --- | --- | --- | --- | --- | --- | --- |
| 7846 | 2017-10-20 | 8802 | 400.0000 | 1 | 400.0000 | .0000 | 400.0000 |
| 8108 | 2018-01-31 | 01-092 | 6954.0000 | 1 | .0000 | 6954.0000 | -6954.0000 |
| 8109 | 2018-01-31 | 01-092 | 6954.0000 | 1 | 6954.0000 | .0000 | 6954.0000 |
| 8104 | 2018-04-30 | 04-093 | 106937.0000 | 1 | .0000 | 106937.0000 | -106937.0000 |
| 8105 | 2018-04-30 | 04-093 | 106937.0000 | 1 | 106937.0000 | .0000 | 106937.0000 |
| 8106 | 2018-09-20 | 09-024 | 3666.0000 | 1 | .0000 | 3666.0000 | -3666.0000 |
| 8107 | 2018-09-20 | 09-024 | 3666.0000 | 1 | 3666.0000 | .0000 | 3666.0000 |
| 8110 | 2018-09-23 | 09-044 | 11417.9500 | 1 | 11417.9500 | .0000 | 11417.9500 |
| 8111 | 2018-09-23 | 09-044 | 5492.2700 | 1 | 5492.2700 | .0000 | 5492.2700 |
| 8112 | 2018-09-23 | 09-044 | 27687.5300 | 1 | 27687.5300 | .0000 | 27687.5300 |
| 8113 | 2018-09-23 | 09-044 | 39068.8400 | 1 | 39068.8400 | .0000 | 39068.8400 |
| 8114 | 2018-09-23 | 09-044 | 2088.0300 | 1 | .0000 | 2088.0300 | -2088.0300 |
| 8115 | 2018-09-23 | 09-044 | 5350.0000 | 1 | .0000 | 5350.0000 | -5350.0000 |
| 8116 | 2018-09-23 | 09-044 | 9419.0000 | 1 | .0000 | 9419.0000 | -9419.0000 |
| 8117 | 2018-09-23 | 09-044 | 630.3500 | 1 | .0000 | 630.3500 | -630.3500 |
| 8118 | 2018-09-23 | 09-044 | 5181.6800 | 1 | .0000 | 5181.6800 | -5181.6800 |
| 8119 | 2018-09-23 | 09-044 | 42773.2300 | 1 | .0000 | 42773.2300 | -42773.2300 |
| 8120 | 2018-09-23 | 09-044 | 109.0000 | 1 | .0000 | 109.0000 | -109.0000 |
| 8121 | 2018-09-23 | 09-044 | 8244.0000 | 1 | .0000 | 8244.0000 | -8244.0000 |
| 8122 | 2018-09-23 | 09-044 | 250.0000 | 1 | .0000 | 250.0000 | -250.0000 |
| 8123 | 2018-09-23 | 09-044 | 1650.0000 | 1 | .0000 | 1650.0000 | -1650.0000 |
| 8124 | 2018-09-23 | 09-044 | 4665.0000 | 1 | .0000 | 4665.0000 | -4665.0000 |
| 8258 | 2018-09-23 | 09-044 | 3306.3000 | 1 | .0000 | 3306.3000 | -3306.3000 |
| 8548 | 2019-08-30 | 08-073 | 550.0000 | 1 | .0000 | 550.0000 | -550.0000 |
| 8549 | 2019-08-30 | 08-073 | 2500.0000 | 1 | .0000 | 2500.0000 | -2500.0000 |
| 8550 | 2019-08-30 | 08-073 | 572.2500 | 1 | .0000 | 572.2500 | -572.2500 |
| 8551 | 2019-08-30 | 08-073 | 2301.9900 | 1 | .0000 | 2301.9900 | -2301.9900 |
| 8552 | 2019-08-30 | 08-073 | 8865.0000 | 1 | .0000 | 8865.0000 | -8865.0000 |
| 8553 | 2019-08-30 | 08-073 | 15.0000 | 1 | .0000 | 15.0000 | -15.0000 |
| 8554 | 2019-08-30 | 08-073 | 18511.4700 | 1 | 18511.4700 | .0000 | 18511.4700 |
| 8555 | 2019-08-30 | 08-073 | 1822.3000 | 1 | .0000 | 1822.3000 | -1822.3000 |
| 8556 | 2019-08-30 | 08-073 | 1884.9300 | 1 | .0000 | 1884.9300 | -1884.9300 |
| 8657 | 2019-12-31 | 12-159 | 2016.5000 | 1 | .0000 | 2016.5000 | -2016.5000 |
| 8959 | 2020-12-28 | 12-097 | 4443.0000 | 1 | .0000 | 4443.0000 | -4443.0000 |

### RECEIPT AR/ADVANCE LEDGER COMPARED TO ALLOCATIONS

| IdNo | TransactionDate | ReferenceNo | PayorIdNo | Amount | Applied | UnApplied | DiscountTaken | ARCredit | CACredit |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 2454 | 2022-02-06 | 02-025 | 329 | 9859.0000 | 9858.5000 | .5000 | .0000 | 9859.0000 | .0000 |
| 2457 | 2022-03-07 | 03-029 | 325 | 3933.0000 | 3363.0000 | 570.0000 | .0000 | 3933.0000 | .0000 |
| 2760 | 2023-12-31 | 12-181 | 318 | 5650.0000 | 5650.0000 | .0000 | .0000 | 7192.0000 | -1542.0000 |
| 2905 | 2024-12-02 | 12-055 | 329 | 20694.5000 | 20694.5000 | .0000 | .0000 | 21025.5000 | -331.0000 |
| 2979 | 2025-06-12 | 06-032 | 365 | 175.0000 | -149.0000 | 324.0000 | .0000 | .0000 | 175.0000 |
| 3002 | 2025-07-07 | 07-045 | 365 | 620.0000 | 620.0000 | .0000 | .0000 | 944.0000 | -324.0000 |
| 3966 | 2025-09-24 | 09-075 | 336 | 9166.4800 | 9166.4800 | .0000 | .0000 | 9236.5200 | -70.0400 |
| 4050 | 2025-12-09 | 12-039 | 374 | .0000 | .0000 | .0000 | .0000 | 10010.0000 | -10010.0000 |
| 4046 | 2026-01-27 | 01-098 | 1385 | 540.0000 | 540.0000 | .0000 | .0000 | 10644.0000 | -10104.0000 |
| 4076 | 2026-02-23 | 02-130 | 1388 | 16445.0000 | 16445.0000 | .0000 | .0000 | 15636.5000 | 808.5000 |
| 4105 | 2026-04-23 | 04-015 | 1388 | 5945.5000 | 5945.5000 | .0000 | .0000 | 5010.5000 | 935.0000 |
| 4157 | 2026-05-06 | 05-108 | 381 | 756.0000 | 756.0000 | .0000 | .0000 | .0000 | 756.0000 |
| 4158 | 2026-05-24 | 05-109 | 1388 | 253.0000 | 253.0000 | .0000 | .0000 | .0000 | 253.0000 |
| 4231 | 2026-09-03 | 09-083 | 380 | 1418.0000 | 1418.0000 | .0000 | .0000 | 2773.6300 | -1355.6300 |

### UNMARKED NONZERO OPEN-INVOICE CANDIDATES

| JournalCode | JournalIdNo | ItemId | CustomerIdNo | Amount | TransactionDate | UnApplied |
| --- | --- | --- | --- | --- | --- | --- |
| CR | 2454 | 431 | 329 | -9858.5000 | 2022-02-06 | .5000 |
| CR | 2457 | 439 | 325 | -3363.0000 | 2022-03-07 | 570.0000 |
| CR | 2671 | 877 | 318 | -8894.5000 | 2023-06-19 | 1542.0000 |
| CR | 2858 | 1270 | 329 | -2559.0000 | 2024-09-19 | 331.0000 |
| CR | 2977 | 1528 | 365 | -411.0000 | 2025-06-02 | 149.0000 |
| CR | 2979 | 1533 | 365 | 149.0000 | 2025-06-12 | 324.0000 |
| CR | 3956 | 2485 | 336 | -13336.4700 | 2025-08-20 | 70.0400 |
| CR | 4067 | 2718 | 380 | -7577.3700 | 2026-02-04 | 1355.6300 |
| CR | 4162 | 2918 | 1388 | -3058.0000 | 2026-06-23 | 3058.0000 |
| CR | 4211 | 3030 | 1390 | -956.5200 | 2026-08-20 | 956.5200 |

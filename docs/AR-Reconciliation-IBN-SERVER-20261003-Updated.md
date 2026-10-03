# Updated live AR reconciliation - IBN-SERVER.ISPDATA

Rechecked on 3 October 2026 after the user's MWAFQ and Major Drilling corrections. All database checks were read-only. Period parameters were 1 January through 3 October 2026, with prior activity carried forward by the summary function. These are live results; the previous report concerned the restored ISPADMIN2 database. No production schema or data was changed by this recheck.

## Overall result

| Source | Current total |
|---|---:|
| AR Summary function | 104,963.07 |
| AR Statement view | 104,963.07 |
| AR Aging view | 104,963.07 |
| AROpenInvoice view | 104,963.07 |
| Open items minus statement | **0.00** |

The previous 4,014.52 grand-total difference has been eliminated. Summary and statement agree for every customer. However, agreement of grand totals does not establish that all receipt headers, detail classifications, or customer open-item ownership are correct.

## The two corrected receipts

The changes added three CsrOiItem allocations against existing AR invoices, rather than creating CR open-item markers:

| Receipt | Allocation row | Open item | Invoice journal | Allocation |
|---|---:|---:|---:|---:|
| 4162 / MWAFQ | 3176 | 2698 | 11092 | 756.00 |
| 4162 / MWAFQ | 3177 | 2765 | 11153 | 2,302.00 |
| 4211 / Major Drilling Arabia | 3178 | 2814 | 11196 | 956.52 |

MWAFQ's current customer balance is 0.00 in both statement and open items; Major Drilling's is 1,235.98 in both. Open items 2698 and 2765 are now fully cleared; 2814 has 1,235.98 remaining. All allocations point to the correct customer and valid open items; no overapplication was detected.

### Remaining receipt inconsistencies

| Receipt | Amount | Header Applied | Header UnApplied | Actual allocations | Detail classification |
|---|---:|---:|---:|---:|---|
| 4162 | 3,058.00 | 0.00 | 3,058.00 | 3,058.00 | CA credit 3,058.00 |
| 4211 | 956.52 | 0.00 | 956.52 | 956.52 | CA credit 956.52 |

Both are unposted and unapproved. Their receipt totals remain balanced, and Amount=Applied+UnApplied still holds, but Applied does not equal allocated cash. The headers still present the full receipts as available advances although the money has been allocated to invoices. This may permit misleading unapplied displays or a future duplicate use of the same credit.

Recommended next step is a consistent application of those advances: synchronize the receipt header amounts with allocations and reflect the advance-to-AR application in the detail ledger, either through a correctly updated receipt or a dated advance-application transaction. Do not only change header figures while leaving the AR/CA classification inconsistent. No extra cash receipt and no duplicate payment allocations are needed. Exercise the correction on the restored test database first, preserving invoice/payment identities and reconciliation restrictions.

Two allocations also apply receipts to invoices dated after the receipt: 4162 (23 June) to invoice journal 11153 (30 June), and 4211 (20 August) to invoice journal 11196 (9 September). These can represent legitimate advance applications, but their effective application date needs confirmation for historical cutoffs. CsrOiItem has no separate application-date column, and the current open-item view subtracts all allocations; it is not a reliable historical as-of open-item calculation merely by filtering invoice dates.

## Remaining customer balance mismatch: AR 11198

The live database has not received the detail-party resolution fix deployed on ISPADMIN2. `FnResolveOpenInvoiceParty` is absent, and open item 2821 still resolves to the Al-Malik header customer instead of its Tahlia detail contact.

| Customer | Statement/summary | Open items | Open minus statement |
|---|---:|---:|---:|
| Al-Malik / 373 | 1,280.00 | 1,228.25 | -51.75 |
| Tahlia / 1381 | 1,566.50 | 1,618.25 | +51.75 |

The differences cancel at grand-total level but remain wrong for individual customer tracking. Detail 10210 has contact 2107/customer 1381; its open item 2821 returns customer 373. Both open-item entries already exist. The proposed resolution fix should correct ownership without inserting another entry. Production deployment remains a separate action requiring backup/test verification and authorization.

## Other findings still present

- 37 unresolved markers (11 AR, 26 CR), with no linked payment/discount amounts.
- Two incorrect source-header links: marker 1150 stores header 9573 for detail 6353 actually in journal 9574; marker 1152 stores 9575 for detail 6356 actually in 9576. Amounts are 345.00 and 275.00. Do not insert replacement markers without correcting/classifying these existing links.
- One duplicate AR code/detail key for missing detail 6279 (markers 1133/1134).
- Six active AR headers without details: 9573, 9575, 9647, 10959, 10970, 11134. Current-year header 11134 requires particular review.
- 34 individually unbalanced historical journals, all 2017-2020; earlier review found 31 offset in date/reference groups, with 7846, 8657 and 8959 unmatched within AR, net -6,059.50. These historical findings require document/other-journal review, not automatic balancing entries.
- Ten unmarked CR candidates still appear in ARInvoices_View, including the two now allocated receipts. A candidate's full receipt detail amount is not automatically a missing unapplied credit and must not be blindly inserted into open items.
- Fourteen AR/CA classification review candidates remain from the earlier audit. Some represent legitimate advance reclassifications rather than incorrect payments.

No allocations lack their open marker or receipt header, no active allocations resolve to a different customer, no overapplied/sign-reversed open item was found, and no active AR selected contact fails the Contact_View type check. The two newly corrected receipts are now the only header-versus-allocation total mismatches found by this check.

## Reporting limits

The audit checks database sources and does not certify a rendered/printed Crystal report. Summary and statement sources include their configured AR/customer-advance activity and are not a posted-only GL reconciliation. Aging still groups net journal activity by transaction date instead of each invoice's remaining balance by due date; its matching total does not prove invoice aging buckets are correct.

## Detailed live query results


### CUSTOMER BALANCE DIFFERENCES

| IdNo | CustomerCode | CustomerName | StatementBalance | OpenBalance | Difference | AdvanceBalance |
| --- | --- | --- | --- | --- | --- | --- |
| 373 | 1626 | Stars Smile Clinic (Al-Malik) | 1280.0000 | 1228.2500 | -51.7500 | -7402.5000 |
| 1381 | 1629 | Stars Smile Clinic (Tahlia) | 1566.5000 | 1618.2500 | 51.7500 | .0000 |

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
| 4162 | 2026-06-23 | 06-078 | 1388 | 3058.0000 | .0000 | 3058.0000 | 3058.0000 | .0000 | .0000 |
| 4211 | 2026-08-20 | 08-130 | 1390 | 956.5200 | .0000 | 956.5200 | 956.5200 | .0000 | .0000 |

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

### LIVE TOTALS

| Source | Balance |
| --- | --- |
| Summary function | 104963.0700 |
| Statement view | 104963.0700 |
| Aging view | 104963.0700 |
| Open invoice view | 104963.0700 |

### SUMMARY VS STATEMENT BY CUSTOMER

MismatchedCustomers: 0

### CORRECTED RECEIPT HEADERS AND CURRENT DETAILS

| IdNo | TransactionDate | ReferenceNo | PayorIdNo | Amount | Applied | UnApplied | DiscountTaken | Cancelled | DetailId | AccountIdNo | SpecialAccount | Debit | Credit | PayIdNo |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 4162 | 2026-06-23 | 06-078 | 1388 | 3058.0000 | .0000 | 3058.0000 | .0000 | 0 | 2917 | 106 | CK | 3058.0000 | .0000 | NULL |
| 4162 | 2026-06-23 | 06-078 | 1388 | 3058.0000 | .0000 | 3058.0000 | .0000 | 0 | 2918 | 128 | CA | .0000 | 3058.0000 | NULL |
| 4211 | 2026-08-20 | 08-130 | 1390 | 956.5200 | .0000 | 956.5200 | .0000 | 0 | 3030 | 128 | CA | .0000 | 956.5200 | 0 |
| 4211 | 2026-08-20 | 08-130 | 1390 | 956.5200 | .0000 | 956.5200 | .0000 | 0 | 3029 | 110 | BA | 956.5200 | .0000 | 0 |

### ALLOCATIONS FOR CORRECTED RECEIPTS

| IdNo | CsrIdNo | ArOpenInvoiceIdNo | Amount | DiscountTaken | JournalCode | JournalIdNo | CustomerIdNo | OriginalAmount | CurrentBalance |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 3176 | 4162 | 2698 | 756.0000 | .0000 | AR | 11092 | 1388 | 1743.5000 | .0000 |
| 3177 | 4162 | 2765 | 2302.0000 | .0000 | AR | 11153 | 1388 | 16126.0000 | .0000 |
| 3178 | 4211 | 2814 | 956.5200 | .0000 | AR | 11196 | 1390 | 2192.5000 | 1235.9800 |

### AR 11198 OWNERSHIP

| IdNo | Sequence | PayIdNo | DetailCustomer | OpenItemId | OpenItemCustomer | Amount | Balance |
| --- | --- | --- | --- | --- | --- | --- | --- |
| 10209 | 1 | 1095 | 373 | 2820 | 373 | 51.7500 | 51.7500 |
| 10210 | 2 | 2107 | 1381 | 2821 | 373 | -51.7500 | -51.7500 |

### CUTOFF CHECK

AllocationsAfterCutoff: 0

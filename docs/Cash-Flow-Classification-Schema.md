# Cash-flow classification schema

This is the schema foundation for the cash-flow review stage. It is included in
the `IspDataDb` SQL project and was published to the owner-confirmed ISPADMIN2 / ISPDATA test target on 2026-09-10.

## Objects

- `CashFlowClassification` stores bilingual sections and categories.
- `CashFlowAccountRule` stores reviewed account defaults, including the explicit
  cash-equivalent scope. Rules are effective-dated so a later review does not
  silently rewrite an earlier report.
- `CashFlowAllocation` stores source journal-item allocations. Journal identity
  is polymorphic because the application has nine journal tables; therefore no
  single journal foreign key is used. Multiple allocations allow one cash line
  to be split between categories.

`Amount` is signed using the selected cash-account movement convention: debit is
positive and credit is negative. Allocations explain existing source lines and
must be validated to sum to each eligible cash movement before approval.

The nine generic classifications were seeded in the owner-confirmed test
database on 2026-09-10. Thirty-two provisional account rules were then added:
five cash-equivalent accounts, working-capital groups, known fixed-asset
accounts, depreciation, loan/capital accounts, and explicit review rules for
mixed or closing-related accounts. No transaction allocations were seeded.
Account 193, AP settlements, asset disposals, interest/principal splits, and
closing entries still require review of the actual source journal before final
approval.

# AR/AP detail ownership fix

The open-item views previously attributed every AR/AP journal detail to the header customer/supplier. Statements already used detail payees. AR 11198 therefore showed its Tahlia credit under Al-Malik in open-item lookup.

`dbo.FnResolveOpenInvoiceParty` now resolves a selected `PayIdNo` through `Contact`, checks the customer/supplier type and entity existence, and returns NULL for an invalid selected contact. Only NULL/zero historical payees fall back to a valid header party. The AR/AP journal branches of the details and statement ledger views share this function; AR invoice lookup also uses it. Existing open-item IDs and allocation links are preserved.

Atomic AR/AP save/update procedures reject nonzero control-account lines without a valid customer/supplier contact. Existing UI payee defaults and validation already enforce this rule. The existing one-marker-per-control-account-line insertion and payment/reconciliation protections remain in place.

Scope is AR/AP journal detail ownership. Other journal branches, historical record repairs, credit application workflows, invoice/due-date entry, and aging bucket calculations are unchanged. For multi-party adjustments, the journal still supplies invoice/date/due-date metadata; linking a credit to a specific original invoice is separate work.

## Verification completed

The SQL120 schema project built successfully with existing unresolved SQL system-procedure warnings. Nine read-only checks executed the resolver body against live Contact/Customer/Supplier data without creating a function or changing records: both AR 11198 contacts, wrong contact type, invalid contact, historical missing contact, valid AP supplier overriding a different header, AP wrong type, AP historical fallback, and invalid historical header all passed. This does not substitute for deploying and exercising the views and save procedures on a restored test database. No Accounts executable changes were needed because the existing forms already default only missing payees and validate contacts through Contact_View.

## Deployment

Do not publish the entire DACPAC for this focused change. `tools/Deploy-ArApOpenInvoiceParty.sql` contains only the new function and eight changed views/procedures, in dependency order, inside a transaction. Run it with SQLCMD using `-b` and explicit `TargetServer` and `TargetDatabase` variables. It checks the connection target before making any changes. Save definitions of the affected live objects for rollback before deployment.

First obtain authorization for a confirmed restored test database, deploy the focused script there, and run `tools/Verify-ArApOpenInvoiceParty.sql`. Its AR assertions require an unchanged restored copy containing AR 11198 and open items 2820/2821. Then exercise these application scenarios in that test database:

- Open AR 11198: Al-Malik has +51.75 and Tahlia has -51.75 in statements and open-item lookup; verify the customer aging report includes each correctly.
- Save a new balanced AR journal with two different customer contacts, and an equivalent AP journal with two supplier contacts. Each control-account line must create exactly one open item for its own party, with AR debit-minus-credit and AP credit-minus-debit signs.
- Edit an unpaid test journal and verify marker completeness; verify paid, posted, approved, closed-period, and reconciled restrictions remain effective.
- Attempt a blank, wrong-type, and nonexistent contact through the UI and directly through the atomic procedure; saves must fail without partial headers/details/markers.
- Verify receipt/disbursement allocation accepts the matching party and rejects a different party. Existing negative-credit allocation behavior must be checked separately; this fix does not add a new credit-application mechanism.
- Check English and Arabic/RTL display. No forms, captions, or report binaries changed.

Before production deployment, verify a current backup and obtain explicit authorization for IBN-SERVER.ISPDATA. This deployment changes definitions only; it does not insert/delete open items or resave AR 11198. Existing historical selected contacts that do not identify a valid Contact are exposed as unresolved instead of silently assigned to another party; review deployment impact on a restored copy.

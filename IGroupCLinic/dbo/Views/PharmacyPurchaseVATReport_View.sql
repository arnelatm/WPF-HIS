CREATE VIEW [dbo].[PharmacyPurchaseVATReport_View] (
    [BranchID],
    [TransType],
    [TransNo],
    [TransNBR],
    [TransDate],
    [TransDateEnglish],
    [SupplierID],
    [SupplierNameEnglish],
    [VATNo],
    [InvoiceNo],
    [InvoiceDate],
    [NonTaxableAmount],
    [TaxableAmount],
    [VATAmt],
    [Reject]
)
WITH ENCRYPTION
AS
SELECT NULL AS [NullColumn]
--The script body was encrypted and cannot be reproduced here.;


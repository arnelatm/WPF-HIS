CREATE VIEW [dbo].[CsrOiItemCustomer_View]
AS
SELECT
    oiItem.[IdNo],
    oiItem.[CsrIdNo],
    oiItem.[ArOpenInvoiceIdNo],
    oiItem.[Sequence],
    oiItem.[Amount],
    oiItem.[DiscountTaken],
    openInvoice.[JournalCode],
    openInvoice.[JournalIdNo],
    customer.[IdNo] AS [CustomerIdNo]
FROM [dbo].[CsrOiItem] AS oiItem
INNER JOIN [dbo].[ArOpenInvoice] AS openInvoice
    ON oiItem.[ArOpenInvoiceIdNo] = openInvoice.[IdNo]
INNER JOIN [dbo].[ARDetails_View] AS arDetail
    ON openInvoice.[JournalItemIdNo] = arDetail.[IdNo]
    AND openInvoice.[JournalCode] COLLATE SQL_Latin1_General_CP1_CI_AS = arDetail.[JournalCode]
INNER JOIN [dbo].[Customer] AS customer
    ON arDetail.[CustomerIdNo] = customer.[IdNo];

GO

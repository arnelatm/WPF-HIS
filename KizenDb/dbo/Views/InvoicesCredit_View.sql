CREATE VIEW [dbo].[InvoicesCredit_View]
AS

/* =========================================================
   Main invoice header
   ========================================================= */

SELECT 
    a.ID AS InvoiceNo,
    CAST(a.[Date] AS DATE) AS InvoiceDate,
    a.CustID,
    a.CustName,
    a.Type,
    a.DrName,
    a.DrID,
    a.IsInsurance,
    a.InsuranceCompany AS CompanyCode,

/* =========================================================
   Company information
   ========================================================= */

    e.LatinName,
    a.CustIdentity,
    a.CustNat,
    a.Clinic,
    a.IsReturn,

/* =========================================================
   Invoice item details (main detail table)
   Each row = one service/item in invoice
   ========================================================= */

    c.ID AS InvoiceDetailId,
    d.Code,
    d.Name AS ItemName,
    c.[Count],
    c.Price,
    c.Total,
    c.DiscNet AS DiscountAmount,

/* =========================================================
   Financial calculations
   ========================================================= */

    ROUND(c.InsuranceTahamal,2) AS AmountBeforeVat,
    ROUND(c.InsuranceTahamalAfterVAT,2) AS NetAmount,
    c.VATPer,

/* VATable amounts depending on nationality */

    IIF(c.VATPer <> 0 AND a.CustNat = 'سعودي Saudi Arabian',
        c.InsuranceTahamal,0) AS VatableAmountSA,

    IIF(c.VATPer <> 0 AND a.CustNat <> 'سعودي Saudi Arabian',
        c.InsuranceTahamal,0) AS VatableAmountNS,

/* VAT calculations */

    ROUND(c.InsuranceTahamal * ABS(c.VATPer / 100.0),2) AS VatValue,

    ROUND(
        IIF(a.CustNat = 'سعودي Saudi Arabian',
            c.InsuranceTahamal * ABS(c.VATPer / 100.0),
            0
        ),2
    ) AS VatExemption,

/* =========================================================
   Additional reference data
   ========================================================= */

    e.LatinName AS CompanyName,
    f.CustomField1 AS DrCode,

/* VAT exempt amount */

    IIF(c.VATPer = 0,c.InsuranceTahamal,0) AS VatExemptAmt,

/* Parent invoice flag */

    IIF(ch.ParentId IS NULL,0,ch.ParentId) AS ParentId


/* =========================================================
   Base table
   ========================================================= */

FROM dbo.A1_Invoces a


/* =========================================================
   Invoice detail rows
   ========================================================= */

LEFT JOIN dbo.A1_OrderWorks c
    ON c.OrderID = a.ID


/* =========================================================
   Service / item definition
   ========================================================= */

LEFT JOIN dbo.A1_Works d
    ON d.Code = c.WorkID


/* =========================================================
   Insurance company information
   ========================================================= */

LEFT JOIN dbo.Insurance_Company e
    ON e.Code = a.InsuranceCompany


/* =========================================================
   Doctor information
   ========================================================= */

LEFT JOIN dbo.Drs f
    ON f.DrNmae = a.DrName


/* =========================================================
   Detect if invoice has children
   (pre-grouped to avoid row multiplication)
   ========================================================= */

LEFT JOIN
(
    SELECT ParentId
    FROM dbo.A1_Invoces
    WHERE ParentId IS NOT NULL
    GROUP BY ParentId
) ch
    ON ch.ParentId = a.ID


/* =========================================================
   Insurance policy
   (grouped to avoid duplicates)
   ========================================================= */

LEFT JOIN
(
    SELECT Code, CompanyCode, MAX(UpToPer) AS UpToPer
    FROM dbo.Insurance_Policy
    GROUP BY Code, CompanyCode
) g
    ON g.Code = a.InsurancePolicy
   AND g.CompanyCode = a.InsuranceCompany


/* =========================================================
   Filters
   ========================================================= */

WHERE
    ISNULL(a.HideFromInsurance,0) = 0
    AND ISNULL(g.UpToPer,0) = 0
CREATE TABLE [dbo].[ClinicVATForNationals] (
    [ServiceID]     VARCHAR (15)   NULL,
    [VATPercent]    NUMERIC (7, 2) NULL,
    [VATApplicable] INT            NULL
);


GO
CREATE NONCLUSTERED INDEX [IDX_ClinicVATForNationals]
    ON [dbo].[ClinicVATForNationals]([ServiceID] ASC);


CREATE TABLE [dbo].[InsuranceInvoiceReturnDetail] (
    [ID]                           INT             IDENTITY (1, 1) NOT NULL,
    [InsuranceInvoiceReturnID]     INT             NOT NULL,
    [DoctorID]                     INT             NULL,
    [Reason]                       INT             NULL,
    [Note]                         NVARCHAR (MAX)  NULL,
    [DiscPercent]                  DECIMAL (18, 2) NULL,
    [AmountWithoutVAT]             DECIMAL (18, 2) NULL,
    [CarryFromAmountIncludeVAT]    DECIMAL (18, 2) NULL,
    [CarryFromAmountNotIncludeVAT] DECIMAL (18, 2) NULL,
    [VATValue]                     DECIMAL (18, 2) NULL,
    [Net]                          DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_InsuranceInvoiceReturnDetail] PRIMARY KEY CLUSTERED ([ID] ASC)
);


CREATE TABLE [dbo].[A1_OfferInvoice] (
    [ID]                  INT             IDENTITY (1, 1) NOT NULL,
    [Title]               NVARCHAR (255)  NULL,
    [Description]         NVARCHAR (MAX)  NULL,
    [DateTime]            DATETIME        NULL,
    [UserName]            NVARCHAR (255)  NULL,
    [StartDate]           DATETIME        NULL,
    [EndDate]             DATETIME        NULL,
    [StartTime]           TIME (0)        NULL,
    [EndTime]             TIME (0)        NULL,
    [Type]                INT             NULL,
    [DiscountValue]       DECIMAL (18, 2) NULL,
    [DiscountType]        INT             NULL,
    [Disabled]            BIT             NULL,
    [Category]            NVARCHAR (255)  NULL,
    [AllowCustomSelect]   BIT             NULL,
    [AllowMergeWithOther] BIT             NULL,
    [HideWorkWhenPrint]   BIT             NULL,
    CONSTRAINT [PK_A1_OfferInvoice] PRIMARY KEY CLUSTERED ([ID] ASC)
);


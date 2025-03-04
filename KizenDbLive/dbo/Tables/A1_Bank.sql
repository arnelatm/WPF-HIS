CREATE TABLE [dbo].[A1_Bank] (
    [ID]             INT             IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50)   NULL,
    [Number]         NVARCHAR (MAX)  NULL,
    [Note]           NVARCHAR (MAX)  NULL,
    [IBAN]           NVARCHAR (MAX)  NULL,
    [IsATMBank]      BIT             NULL,
    [ConvertPercent] DECIMAL (18, 2) NULL,
    [ConvertMoney]   DECIMAL (18, 2) NULL,
    [Type]           INT             NULL,
    CONSTRAINT [PK_A1_Bank] PRIMARY KEY CLUSTERED ([ID] ASC)
);


CREATE TABLE [dbo].[Bank] (
    [IdNo]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [BankCode]      VARCHAR (10)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [BankName]      VARCHAR (50)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [BankNameAra]   NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Notes]         NVARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp] ROWVERSION     NULL,
    CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_BankCode]
    ON [dbo].[Bank]([BankCode] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_BankName]
    ON [dbo].[Bank]([BankName] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_BankNameAra]
    ON [dbo].[Bank]([BankNameAra] ASC);


CREATE TABLE [dbo].[TransactionPrefix] (
    [IdNo]              SMALLINT      IDENTITY (1, 1) NOT NULL,
    [TransactionName]   VARCHAR (50)  NULL,
    [TransactionNameAr] NVARCHAR (50) NULL,
    [Prefix]            NCHAR (2)     NULL,
    CONSTRAINT [PK_TransactionPrefix] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);




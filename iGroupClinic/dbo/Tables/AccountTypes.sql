CREATE TABLE [dbo].[AccountTypes] (
    [IdNo]         SMALLINT     IDENTITY (1, 1) NOT NULL,
    [AccountIdNo]  INT          NOT NULL,
    [AccountTypes] VARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    CONSTRAINT [PK_AccountTypesIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_AccountTypesAcctIdNo]
    ON [dbo].[AccountTypes]([IdNo] ASC);


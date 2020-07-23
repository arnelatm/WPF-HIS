CREATE TABLE [dbo].[GLLEDGERVIEW] (
    [JournalCode]       VARCHAR (2)    NOT NULL,
    [IdNo]              INT            NOT NULL,
    [Sequence]          INT            NOT NULL,
    [JournalIdNo]       INT            NOT NULL,
    [AccountIdNo]       INT            NOT NULL,
    [AccountCode]       VARCHAR (5)    COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Debit]             MONEY          NOT NULL,
    [Credit]            MONEY          NOT NULL,
    [ProfitCenterIdNo]  INT            NULL,
    [Notes]             NVARCHAR (300) NOT NULL,
    [Posted]            BIT            NOT NULL,
    [TransactionDate]   DATE           NULL,
    [ReferenceNo]       NVARCHAR (15)  NULL,
    [DocumentNumber]    VARCHAR (36)   NULL,
    [PayDescription]    NVARCHAR (300) NULL,
    [PayDescriptionAra] NVARCHAR (300) NULL,
    [ClosingJournal]    BIT            NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_GLLEDGERVIEW_4]
    ON [dbo].[GLLEDGERVIEW]([IdNo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_GLLEDGERVIEW_3]
    ON [dbo].[GLLEDGERVIEW]([JournalIdNo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_GLLEDGERVIEW]
    ON [dbo].[GLLEDGERVIEW]([JournalCode] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_GLLEDGERVIEW_2]
    ON [dbo].[GLLEDGERVIEW]([AccountIdNo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_GLLEDGERVIEW_1]
    ON [dbo].[GLLEDGERVIEW]([Sequence] ASC);


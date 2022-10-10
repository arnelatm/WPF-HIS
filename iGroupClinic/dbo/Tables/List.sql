CREATE TABLE [dbo].[List] (
    [IdNo]        INT            IDENTITY (1, 1) NOT NULL,
    [ListIdNo]    SMALLINT       NULL,
    [ListCode]    VARCHAR (5)    NULL,
    [ListName]    VARCHAR (100)  NULL,
    [ListNameAra] NVARCHAR (100) NULL,
    CONSTRAINT [PK_List] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [IX_ListIdNoCode] UNIQUE NONCLUSTERED ([ListIdNo] ASC, [ListCode] ASC),
    CONSTRAINT [IX_ListIdNoName] UNIQUE NONCLUSTERED ([ListIdNo] ASC, [ListName] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_List]
    ON [dbo].[List]([ListIdNo] ASC, [ListNameAra] ASC);


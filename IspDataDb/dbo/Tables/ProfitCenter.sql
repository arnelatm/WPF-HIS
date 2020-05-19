CREATE TABLE [dbo].[ProfitCenter] (
    [IdNo]                INT           IDENTITY (1, 1) NOT NULL,
    [ProfitCenterCode]    VARCHAR (5)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ProfitCenterName]    VARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ParentIdNo]          INT           NULL,
    [ProfitCenterNameAra] NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ProfitCenterType]    CHAR (1)      COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Notes]               VARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp]       ROWVERSION    NULL,
    CONSTRAINT [PK__ProfitCenterID] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [FK__ProfitCen__Paren__6BAEFA67] FOREIGN KEY ([ParentIdNo]) REFERENCES [dbo].[ProfitCenter] ([IdNo]),
    CONSTRAINT [IX_ProfitCenterCode] UNIQUE NONCLUSTERED ([ProfitCenterCode] ASC),
    CONSTRAINT [IX_ProfitCenterNameAra] UNIQUE NONCLUSTERED ([ProfitCenterNameAra] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ProfitCenterName]
    ON [dbo].[ProfitCenter]([ProfitCenterName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProfitCenterParent]
    ON [dbo].[ProfitCenter]([ParentIdNo] ASC);


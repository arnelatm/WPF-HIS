CREATE TABLE [dbo].[CustomReport] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [TypeID]   INT            NULL,
    [PatID]    INT            NULL,
    [PatName]  NVARCHAR (MAX) NULL,
    [UserName] NVARCHAR (255) NULL,
    [Date]     DATE           NULL,
    [Time]     TIME (0)       NULL,
    [DrID]     INT            NULL,
    [DrName]   NVARCHAR (255) NULL,
    [Info]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_CustomReport] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_CustomReport_AppWait]
    ON [dbo].[CustomReport]([PatID] ASC, [Date] ASC, [Time] ASC, [DrID] ASC);


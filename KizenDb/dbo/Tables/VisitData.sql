CREATE TABLE [dbo].[VisitData] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [Number]           INT            NULL,
    [Date]             DATE           NULL,
    [Time]             TIME (0)       NULL,
    [UserName]         NVARCHAR (MAX) NULL,
    [CustID]           INT            NULL,
    [CustName]         NVARCHAR (MAX) NULL,
    [Note]             NVARCHAR (MAX) NULL,
    [LastDateEdit]     DATETIME       NULL,
    [LastDateUserName] NVARCHAR (MAX) NULL,
    [SpecializationID] INT            NULL,
    [DrID]             INT            NULL,
    [DrName]           NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_VisitData] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_VisitData_AppWait]
    ON [dbo].[VisitData]([CustID] ASC, [Date] ASC, [Time] ASC, [DrID] ASC);


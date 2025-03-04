CREATE TABLE [dbo].[Licenses] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [FaunName]   NVARCHAR (MAX) NULL,
    [FaunNumber] NVARCHAR (MAX) NULL,
    [StartDate]  DATE           NULL,
    [EndDate]    DATE           NULL,
    [Disable]    BIT            NULL,
    [GroupName]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Licenses] PRIMARY KEY CLUSTERED ([ID] ASC)
);


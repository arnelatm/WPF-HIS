CREATE TABLE [dbo].[A1_LocalProductionIncome] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [WorkCat]     NVARCHAR (MAX) NULL,
    [WorkName]    NVARCHAR (MAX) NULL,
    [WorkCode]    NVARCHAR (MAX) NULL,
    [Count]       FLOAT (53)     NULL,
    [Note]        NVARCHAR (MAX) NULL,
    [UserName]    NVARCHAR (50)  NULL,
    [Date]        DATE           NULL,
    [Time]        TIME (0)       NULL,
    [StoreID]     INT            NULL,
    [SeqNumber]   NVARCHAR (50)  NULL,
    [ExpierdDate] DATE           NULL,
    [Note1]       NVARCHAR (MAX) NULL,
    [Note2]       NVARCHAR (MAX) NULL,
    [Note3]       NVARCHAR (MAX) NULL,
    [Note4]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_A1_LocalProductionIncome] PRIMARY KEY CLUSTERED ([ID] ASC)
);


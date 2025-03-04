CREATE TABLE [dbo].[VisitAnalysesResult] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [VisitAnalysesID] INT            NULL,
    [Code]            NVARCHAR (255) NULL,
    [Data]            NVARCHAR (MAX) NULL,
    [LastResult]      NVARCHAR (MAX) NULL,
    [IsHide]          BIT            CONSTRAINT [DF_VisitAnalysesResult_IsHide] DEFAULT ((0)) NULL,
    [Date]            DATE           NULL,
    [Time]            TIME (0)       NULL,
    [UserName]        NVARCHAR (MAX) NULL,
    [Name]            NVARCHAR (MAX) NULL,
    [Parent]          NVARCHAR (MAX) NULL,
    [RV]              NVARCHAR (MAX) NULL,
    [Unit]            NVARCHAR (MAX) NULL,
    [WorkCode]        NVARCHAR (MAX) NULL,
    [ImageIndex]      TINYINT        NULL,
    [PropertyGroup]   NVARCHAR (MAX) NULL,
    [OrderID]         INT            NULL,
    [Sort]            INT            NULL,
    [LonicCode]       NVARCHAR (50)  NULL,
    [Kind]            INT            NULL,
    [Note]            NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_VisitAnalyeseResult] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_VisitAnalysesResult_Code]
    ON [dbo].[VisitAnalysesResult]([Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_VisitAnalysesResult_OrderID]
    ON [dbo].[VisitAnalysesResult]([OrderID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_VisitAnalysesResult_Sort]
    ON [dbo].[VisitAnalysesResult]([Sort] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_VisitAnalysesResult_VisitAnalysesID]
    ON [dbo].[VisitAnalysesResult]([VisitAnalysesID] ASC);


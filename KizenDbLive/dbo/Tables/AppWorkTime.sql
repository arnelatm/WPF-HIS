CREATE TABLE [dbo].[AppWorkTime] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [DateFrom]     DATE           NULL,
    [DateTo]       DATE           NULL,
    [Time]         NVARCHAR (MAX) NULL,
    [Comment]      NVARCHAR (MAX) NULL,
    [IsInterval]   BIT            NULL,
    [ResourceName] NVARCHAR (50)  NULL,
    [ResourceID]   INT            NULL,
    [Sat]          NVARCHAR (MAX) NULL,
    [Sun]          NVARCHAR (MAX) NULL,
    [Mon]          NVARCHAR (MAX) NULL,
    [Tue]          NVARCHAR (MAX) NULL,
    [Wed]          NVARCHAR (MAX) NULL,
    [Thu]          NVARCHAR (MAX) NULL,
    [Fri]          NVARCHAR (MAX) NULL,
    [Disabled]     BIT            NULL,
    CONSTRAINT [PK_AppWorkTime] PRIMARY KEY CLUSTERED ([ID] ASC)
);


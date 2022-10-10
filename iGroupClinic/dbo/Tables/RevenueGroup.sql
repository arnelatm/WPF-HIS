CREATE TABLE [dbo].[RevenueGroup] (
    [IdNo]                SMALLINT      IDENTITY (1, 1) NOT NULL,
    [RevenueGroupCode]    VARCHAR (5)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [RevenueGroupName]    VARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ParentIdNo]          SMALLINT      NULL,
    [RevenueGroupNameAra] NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Notes]               VARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp]       ROWVERSION    NULL,
    CONSTRAINT [PK__RevenueGroupID] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


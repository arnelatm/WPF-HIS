CREATE TABLE [dbo].[COMP_PrintHistory] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (255) NULL,
    [UserName]   NVARCHAR (255) NULL,
    [DateTime]   DATETIME       NULL,
    [SourceID]   INT            NULL,
    [DeviceName] NVARCHAR (255) NULL,
    CONSTRAINT [PK_COMP_PrintHistory] PRIMARY KEY CLUSTERED ([ID] ASC)
);


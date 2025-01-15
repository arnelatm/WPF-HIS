CREATE TABLE [dbo].[ThtProcedureType] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (MAX) NULL,
    [Parent]          NVARCHAR (50)  NULL,
    [RelatedWorkCode] INT            NULL,
    [DefaultValue]    NVARCHAR (MAX) NULL,
    [Image]           IMAGE          NULL,
    [UserID]          INT            NULL,
    [UserName]        NVARCHAR (50)  NULL,
    CONSTRAINT [PK_ThtProcedureType] PRIMARY KEY CLUSTERED ([ID] ASC)
);


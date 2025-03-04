CREATE TABLE [dbo].[A1_QucikInvoice] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [UserID]   INT            NULL,
    [Location] NVARCHAR (50)  NULL,
    [WorksId]  NVARCHAR (MAX) NULL,
    [Name]     NVARCHAR (50)  NULL,
    [Level]    NVARCHAR (50)  NULL,
    CONSTRAINT [PK_A1_QucikInvoice] PRIMARY KEY CLUSTERED ([ID] ASC)
);


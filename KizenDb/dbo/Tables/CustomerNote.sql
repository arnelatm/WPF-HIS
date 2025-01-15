CREATE TABLE [dbo].[CustomerNote] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [UserName] NVARCHAR (255) NULL,
    [Disabled] BIT            NULL,
    [Titile]   NVARCHAR (255) NULL,
    [Comment]  NVARCHAR (MAX) NULL,
    [CustID]   INT            NULL,
    [CustName] NVARCHAR (255) NULL,
    [DateTime] DATETIME       NULL,
    CONSTRAINT [PK_CustomerNote] PRIMARY KEY CLUSTERED ([ID] ASC)
);


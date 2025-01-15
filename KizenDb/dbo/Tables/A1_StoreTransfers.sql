CREATE TABLE [dbo].[A1_StoreTransfers] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [UserName]         NVARCHAR (MAX) NULL,
    [UserID]           INT            NULL,
    [UserIDLastEdit]   INT            NULL,
    [UserNameLastEdit] NVARCHAR (MAX) NULL,
    [DateTime]         DATETIME       NULL,
    [DateTimeLastEdit] DATETIME       NULL,
    [Cause]            NVARCHAR (MAX) NULL,
    [Type]             NVARCHAR (255) NULL,
    [FromStore]        INT            NULL,
    [ToStore]          INT            NULL,
    CONSTRAINT [PK_A1_StoreTransfers] PRIMARY KEY CLUSTERED ([ID] ASC)
);


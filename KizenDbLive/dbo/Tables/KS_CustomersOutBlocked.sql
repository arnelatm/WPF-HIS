CREATE TABLE [dbo].[KS_CustomersOutBlocked] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (255) NULL,
    [Mobile]           NVARCHAR (255) NULL,
    [Phone]            NVARCHAR (255) NULL,
    [PersonalIdentity] NVARCHAR (255) NULL,
    [Cause]            NVARCHAR (MAX) NULL,
    [UserName]         NVARCHAR (255) NULL,
    [UserUpdate]       NVARCHAR (255) NULL,
    [Enabled]          BIT            NULL,
    CONSTRAINT [PK_CustomersOutBlocked] PRIMARY KEY CLUSTERED ([ID] ASC)
);


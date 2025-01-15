CREATE TABLE [dbo].[A1_Works_Wishlist] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [PatID]    INT            NULL,
    [PatName]  NVARCHAR (255) NULL,
    [Mobile]   NVARCHAR (255) NULL,
    [WorkCode] NVARCHAR (255) NULL,
    [Note]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_A1_Works_Wishlist] PRIMARY KEY CLUSTERED ([ID] ASC)
);


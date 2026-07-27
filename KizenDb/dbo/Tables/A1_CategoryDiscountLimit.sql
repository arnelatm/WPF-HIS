CREATE TABLE [dbo].[A1_CategoryDiscountLimit] (
    [ID]          INT             IDENTITY (1, 1) NOT NULL,
    [UserRoles]   NVARCHAR (MAX)  NULL,
    [UserIDs]     NVARCHAR (MAX)  NULL,
    [CategoryIDs] NVARCHAR (MAX)  NULL,
    [MinLimit]    DECIMAL (19, 4) NULL,
    [MaxLimit]    DECIMAL (19, 4) NULL,
    CONSTRAINT [PK_A1_CategoryDiscountLimit] PRIMARY KEY CLUSTERED ([ID] ASC)
);


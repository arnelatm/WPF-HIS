CREATE TABLE [dbo].[ItemCode] (
    [IdNo]            INT            IDENTITY (1, 1) NOT NULL,
    [ItemCodeCode]    NVARCHAR (5)   NOT NULL,
    [ItemCodeName]    NVARCHAR (50)  NOT NULL,
    [ItemCodeNameAra] NVARCHAR (50)  NULL,
    [CodeGroupIdNo]   SMALLINT       NOT NULL,
    [Note]            NVARCHAR (100) NULL,
    [DateTimeStamp]   ROWVERSION     NULL,
    CONSTRAINT [PK_ItemCode] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);














GO
CREATE NONCLUSTERED INDEX [IX_ItemCode]
    ON [dbo].[ItemCode]([ItemCodeCode] ASC);




GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_ItemCodeNameAra]
    ON [dbo].[ItemCode]([CodeGroupIdNo] ASC, [ItemCodeNameAra] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_ItemCodeName]
    ON [dbo].[ItemCode]([CodeGroupIdNo] ASC, [ItemCodeName] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_ItemCodeCode]
    ON [dbo].[ItemCode]([CodeGroupIdNo] ASC, [ItemCodeCode] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ItemNameAra]
    ON [dbo].[ItemCode]([ItemCodeNameAra] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ItemName]
    ON [dbo].[ItemCode]([ItemCodeName] ASC);


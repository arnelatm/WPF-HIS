CREATE TABLE [dbo].[ItemCode] (
    [IdNo]            INT            IDENTITY (1, 1) NOT NULL,
    [ItemCodeCode]    NVARCHAR (4)   NOT NULL,
    [ItemCodeName]    NVARCHAR (50)  NOT NULL,
    [ItemCodeNameAra] NVARCHAR (50)  NULL,
    [CodeGroupIdNo]   TINYINT        NOT NULL,
    [Note]            NVARCHAR (100) NULL,
    [DateTimeStamp]   ROWVERSION     NULL,
    CONSTRAINT [PK_ItemCode] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [UQ_ItemCodeName] UNIQUE NONCLUSTERED ([ItemCodeCode] ASC, [ItemCodeName] ASC)
);










GO
CREATE NONCLUSTERED INDEX [IX_ItemCode]
    ON [dbo].[ItemCode]([IdNo] ASC);


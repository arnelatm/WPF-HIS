CREATE TABLE [dbo].[ItemCode] (
    [IdNo]            INT           IDENTITY (1, 1) NOT NULL,
    [ItemCodeName]    NVARCHAR (50) NULL,
    [ItemCodeNameAra] NVARCHAR (50) NULL,
    [ItemCodeCode]    NVARCHAR (5)  NULL,
    [CodeGroupIdNo]   TINYINT       NULL,
    [DateTimeStamp]   ROWVERSION    NULL,
    CONSTRAINT [PK_ItemCode] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);




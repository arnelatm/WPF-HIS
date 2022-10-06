CREATE TABLE [dbo].[ItemCode] (
    [IdNo]            INT           NULL,
    [ItemCodeName]    NVARCHAR (50) NULL,
    [ItemCodeNameAra] NVARCHAR (50) NULL,
    [ItemCodeCode]    NVARCHAR (5)  NULL,
    [CodeGroupIdNo]   TINYINT       NULL,
    [DateTimeStamp]   ROWVERSION    NULL
);


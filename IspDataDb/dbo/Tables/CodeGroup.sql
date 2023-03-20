CREATE TABLE [dbo].[CodeGroup] (
    [IdNo]             SMALLINT       IDENTITY (1, 1) NOT NULL,
    [CodeGroupCode]    VARCHAR (4)    NULL,
    [CodeGroupName]    NVARCHAR (50)  NULL,
    [CodeGroupNameAra] NVARCHAR (50)  NULL,
    [Notes]            NVARCHAR (200) NULL,
    [DateTimeStamp]    ROWVERSION     NULL,
    CONSTRAINT [PK_CodeGroup] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);










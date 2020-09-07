CREATE TABLE [dbo].[TableName] (
    [IdNo]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [DatabaseTableIdNo] SMALLINT       NULL,
    [TableIdNo]         INT            NULL,
    [Name]              NVARCHAR (100) NULL,
    CONSTRAINT [PK_TableName] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_TableName_DbTbIdNo]
    ON [dbo].[TableName]([IdNo] ASC);


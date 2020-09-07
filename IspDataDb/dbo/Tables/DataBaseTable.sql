CREATE TABLE [dbo].[DataBaseTable] (
    [IdNo]          SMALLINT     IDENTITY (1, 1) NOT NULL,
    [TableName]     VARCHAR (30) NULL,
    [TableNameCode] CHAR (3)     NULL,
    CONSTRAINT [PK__DataBase] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_DataBaseTable_Name]
    ON [dbo].[DataBaseTable]([TableName] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_DataBaseTable_Code]
    ON [dbo].[DataBaseTable]([TableNameCode] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'DataBaseTable Code', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DataBaseTable', @level2type = N'INDEX', @level2name = N'IX_DataBaseTable_Code';


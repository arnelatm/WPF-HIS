CREATE TABLE [dbo].[PayElementGroup] (
    [IdNo]                   TINYINT       IDENTITY (1, 1) NOT NULL,
    [PayElementGroupCode]    NCHAR (10)    NULL,
    [PayElementGroupName]    NVARCHAR (25) NOT NULL,
    [PayElementGroupNameAra] NVARCHAR (25) NOT NULL,
    [PayElementKind]         CHAR (1)      NOT NULL,
    CONSTRAINT [PK_PayElementGroup] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


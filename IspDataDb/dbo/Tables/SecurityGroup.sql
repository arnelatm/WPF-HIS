CREATE TABLE [dbo].[SecurityGroup] (
    [IdNo]                 INT           IDENTITY (1, 1) NOT NULL,
    [SecurityGroupName]    VARCHAR (50)  NULL,
    [ParentIdNo]           SMALLINT      NULL,
    [Notes]                VARCHAR (100) NULL,
    [DateTimeStamp]        ROWVERSION    NULL,
    [SecurityGroupCode]    VARCHAR (10)  NULL,
    [SecurityGroupNameAra] NVARCHAR (50) NULL,
    CONSTRAINT [PK_IDNo] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [IX_SecurityGroupName] UNIQUE NONCLUSTERED ([SecurityGroupName] ASC)
);






CREATE TABLE [dbo].[PayGroup] (
    [IdNo]            SMALLINT      IDENTITY (1, 1) NOT NULL,
    [PayGroupCode]    VARCHAR (5)   NOT NULL,
    [PayGroupName]    VARCHAR (50)  NOT NULL,
    [ParentIdNo]      SMALLINT      NULL,
    [PayGroupNameAra] NVARCHAR (50) NOT NULL,
    [Notes]           VARCHAR (255) NULL,
    [DateTimeStamp]   ROWVERSION    NULL,
    CONSTRAINT [PK__PayGroupID] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


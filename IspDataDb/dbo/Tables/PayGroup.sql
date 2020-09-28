CREATE TABLE [dbo].[PayGroup] (
    [IDNo]            SMALLINT      IDENTITY (1, 1) NOT NULL,
    [PayGroupCode]    VARCHAR (5)   NOT NULL,
    [PayGroupName]    VARCHAR (50)  NOT NULL,
    [PayGroupNameAra] NVARCHAR (50) NOT NULL,
    [ParentIdNo]      SMALLINT      NULL,
    [Notes]           VARCHAR (255) NULL,
    [DateTimeStamp]   ROWVERSION    NOT NULL
);


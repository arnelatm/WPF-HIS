CREATE TABLE [dbo].[SecurityObject] (
    [IdNo]                  INT            IDENTITY (1, 1) NOT NULL,
    [SecurityObjectName]    VARCHAR (100)  NOT NULL,
    [SecurityObjectNameAra] NVARCHAR (200) NULL,
    [ParentIdNo]            INT            NULL,
    [Notes]                 VARCHAR (255)  NULL,
    [DateTimeStamp]         ROWVERSION     NULL,
    CONSTRAINT [PK_SecurityObject] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


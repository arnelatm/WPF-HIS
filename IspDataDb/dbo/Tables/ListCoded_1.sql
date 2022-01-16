CREATE TABLE [dbo].[ListCoded] (
    [IdNo]        INT            IDENTITY (1, 1) NOT NULL,
    [ListIdNo]    SMALLINT       NULL,
    [ListName]    VARCHAR (100)  NULL,
    [ListNameAra] NVARCHAR (100) NULL,
    CONSTRAINT [PK_ListCoded_1] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


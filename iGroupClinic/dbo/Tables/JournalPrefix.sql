CREATE TABLE [dbo].[JournalPrefix] (
    [IdNo]           SMALLINT      IDENTITY (1, 1) NOT NULL,
    [JournalCode]    CHAR (2)      NULL,
    [JournalName]    VARCHAR (50)  NULL,
    [JournalNameAra] NVARCHAR (50) NULL,
    [JournalCodeAra] NVARCHAR (2)  NULL,
    [DateTimeStamp]  ROWVERSION    NULL,
    CONSTRAINT [PK_JournalPrefix] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


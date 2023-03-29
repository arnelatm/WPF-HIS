CREATE TABLE [dbo].[Computer] (
    [IdNo]            SMALLINT      IDENTITY (1, 1) NOT NULL,
    [ComputerCode]    VARCHAR (20)  NULL,
    [ComputerName]    VARCHAR (50)  NULL,
    [ComputerNameAra] NVARCHAR (50) NULL,
    [DateTimeStamp]   ROWVERSION    NULL,
    CONSTRAINT [PK_Computer] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);




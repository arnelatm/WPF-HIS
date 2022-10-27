CREATE TABLE [dbo].[Computer] (
    [IdNo]          SMALLINT      IDENTITY (1, 1) NOT NULL,
    [ComputerName]  VARCHAR (50)  NULL,
    [ComputerCode]  VARCHAR (20)  NULL,
    [Notes]         NVARCHAR (50) NULL,
    [DateTimeStamp] ROWVERSION    NULL,
    CONSTRAINT [PK_Computer] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


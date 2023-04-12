CREATE TABLE [dbo].[Unitxx] (
    [IdNo]          SMALLINT      IDENTITY (1, 1) NOT NULL,
    [Code]          NVARCHAR (10) NULL,
    [Name]          VARCHAR (20)  NULL,
    [NameAra]       NVARCHAR (20) NULL,
    [datetimestamp] ROWVERSION    NULL,
    CONSTRAINT [PK_Unit1] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


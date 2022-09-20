CREATE TABLE [dbo].[Category] (
    [IdNo]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (50)   NULL,
    [NameAra]       NVARCHAR (50)  NULL,
    [Code]          VARCHAR (5)    NULL,
    [Notes]         NVARCHAR (255) NULL,
    [datetimestamp] ROWVERSION     NULL,
    CONSTRAINT [PK_Category_1] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);




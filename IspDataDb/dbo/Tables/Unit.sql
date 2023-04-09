CREATE TABLE [dbo].[Unit] (
    [IdNo]        SMALLINT      IDENTITY (1, 1) NOT NULL,
    [UnitCode]    NVARCHAR (10) NULL,
    [UnitName]    VARCHAR (20)  NULL,
    [UnitNameAra] NVARCHAR (20) NULL,
    CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);






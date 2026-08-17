CREATE TABLE [dbo].[Unit] (
    [IdNo]          SMALLINT      IDENTITY (1, 1) NOT NULL,
    [UnitCode]      NVARCHAR (10) NULL,
    [UnitName]      VARCHAR (20)  NOT NULL,
    [UnitNameAra]   NVARCHAR (20) NOT NULL,
    [DateTimeStamp] ROWVERSION    NULL,
    CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_UnitCode]
    ON [dbo].[Unit]([UnitCode] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_UnitName]
    ON [dbo].[Unit]([UnitName] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_UnitNameAra]
    ON [dbo].[Unit]([UnitNameAra] ASC);


GO


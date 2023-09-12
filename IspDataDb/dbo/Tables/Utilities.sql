CREATE TABLE [dbo].[Utilities] (
    [IdNo]            SMALLINT     IDENTITY (1, 1) NOT NULL,
    [UtilityName]     VARCHAR (30) NULL,
    [StoredProcedure] BIT          NULL,
    CONSTRAINT [PK_Utilities] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Utilities]
    ON [dbo].[Utilities]([UtilityName] ASC);


CREATE TABLE [dbo].[PayElementItem] (
    [IdNo]           SMALLINT        IDENTITY (1, 1) NOT NULL,
    [ParentIdNo]     SMALLINT        NOT NULL,
    [PayElementIdNo] SMALLINT        NOT NULL,
    [FactorValue]    DECIMAL (10, 4) NOT NULL,
    [FactorType]     CHAR (1)        NOT NULL,
    [Sequence]       SMALLINT        NOT NULL,
    CONSTRAINT [PK_PayElementItem] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


CREATE TYPE [dbo].[PayElementItemInsert] AS TABLE (
    [ParentIdNo]     SMALLINT        NOT NULL,
    [PayElementIdNo] SMALLINT        NOT NULL,
    [FactorType]     CHAR (1)        NOT NULL,
    [FactorValue]    DECIMAL (10, 4) NOT NULL,
    [Sequence]       SMALLINT        NOT NULL);


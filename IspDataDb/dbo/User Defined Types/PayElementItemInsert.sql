CREATE TYPE [dbo].[PayElementItemInsert] AS TABLE (
    [FactorType]     CHAR (1)        NOT NULL,
    [FactorValue]    DECIMAL (10, 4) NOT NULL,
    [ParentIdNo]     SMALLINT        NOT NULL,
    [PayElementIdNo] SMALLINT        NOT NULL,
    [Sequence]       SMALLINT        NOT NULL);




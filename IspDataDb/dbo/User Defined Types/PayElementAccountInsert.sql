CREATE TYPE [dbo].[PayElementAccountInsert] AS TABLE (
    [AccountIdNo]    SMALLINT NOT NULL,
    [PayElementIdNo] SMALLINT NOT NULL,
    [PayGroupIdNo]   SMALLINT NOT NULL,
    [Sequence]       SMALLINT NOT NULL);


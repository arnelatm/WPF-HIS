CREATE TYPE [dbo].[PayElementAccountUpdate] AS TABLE (
    [AccountIdNo]    SMALLINT NOT NULL,
    [PayElementIdNo] SMALLINT NOT NULL,
    [IdNo]           INT      NOT NULL,
    [PayGroupIdNo]   SMALLINT NOT NULL,
    [Sequence]       SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdNo] ASC));


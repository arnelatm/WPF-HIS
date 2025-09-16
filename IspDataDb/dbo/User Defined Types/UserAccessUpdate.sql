CREATE TYPE [dbo].[UserAccessUpdate] AS TABLE (
    [Editable]           BIT      NOT NULL,
    [IDNo]               INT      NOT NULL,
    [SecurityObjectIdNo] INT      NOT NULL,
    [UserIdNo]           SMALLINT NOT NULL,
    [Visible]            BIT      NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));


CREATE TYPE [dbo].[UserAccessInsert] AS TABLE (
    [Editable]           BIT NOT NULL,
    [UserIdNo]           INT NOT NULL,
    [SecurityObjectIdNo] INT NOT NULL,
    [Visible]            BIT NOT NULL);


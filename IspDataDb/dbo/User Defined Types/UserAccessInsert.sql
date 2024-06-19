CREATE TYPE [dbo].[UserAccessInsert] AS TABLE (
    [Editable]           BIT NOT NULL,
    [SecurityObjectIdNo] INT NOT NULL,
    [UserIdNo]           INT NOT NULL,
    [Visible]            BIT NOT NULL);




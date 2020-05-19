CREATE TYPE [dbo].[GroupAccessInsert] AS TABLE (
    [SecurityGroupIDNo]  INT NOT NULL,
    [SecurityObjectIDNo] INT NOT NULL,
    [Visible]            BIT NOT NULL,
    [Editable]           BIT NOT NULL);


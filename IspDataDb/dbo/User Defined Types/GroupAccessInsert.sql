CREATE TYPE [dbo].[GroupAccessInsert] AS TABLE (
    [Editable]           BIT NOT NULL,
    [SecurityGroupIDNo]  INT NOT NULL,
    [SecurityObjectIDNo] INT NOT NULL,
    [Visible]            BIT NOT NULL);




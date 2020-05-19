CREATE TYPE [dbo].[GroupAccessUpdate] AS TABLE (
    [IDNo]               INT NOT NULL,
    [SecurityGroupIDNo]  INT NOT NULL,
    [SecurityObjectIDNo] INT NOT NULL,
    [Visible]            BIT NOT NULL,
    [Editable]           BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));


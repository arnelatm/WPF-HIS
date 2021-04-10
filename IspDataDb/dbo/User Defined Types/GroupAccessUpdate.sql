CREATE TYPE [dbo].[GroupAccessUpdate] AS TABLE (
    [Editable]           BIT NOT NULL,
    [IDNo]               INT NOT NULL,
    [SecurityGroupIDNo]  INT NOT NULL,
    [SecurityObjectIDNo] INT NOT NULL,
    [Visible]            BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));




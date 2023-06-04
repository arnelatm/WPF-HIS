CREATE TABLE [dbo].[SecurityBranch] (
    [IdNo]              SMALLINT IDENTITY (1, 1) NOT NULL,
    [BranchIdNo]        TINYINT  NULL,
    [SecurityGroupIdNo] SMALLINT NULL,
    CONSTRAINT [PK_SecurityBranch] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


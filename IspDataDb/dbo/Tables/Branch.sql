CREATE TABLE [dbo].[Branch] (
    [IDNo]          SMALLINT      IDENTITY (1, 1) NOT NULL,
    [BranchCode]    VARCHAR (5)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [BranchName]    VARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [BranchNameAra] NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Notes]         VARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Active]        BIT           NULL,
    [CreateDate]    DATETIME2 (7) NULL,
    [DateTimeStamp] ROWVERSION    NULL,
    CONSTRAINT [PK__BranchIdNo] PRIMARY KEY CLUSTERED ([IDNo] ASC),
    CONSTRAINT [IX_BranchCode] UNIQUE NONCLUSTERED ([BranchCode] ASC),
    CONSTRAINT [IX_BranchName] UNIQUE NONCLUSTERED ([BranchName] ASC),
    CONSTRAINT [IX_BranchNameAra] UNIQUE NONCLUSTERED ([BranchNameAra] ASC)
);




CREATE TABLE [dbo].[DocumentDetail] (
    [IdNo]           INT             IDENTITY (1, 1) NOT NULL,
    [BranchIdNo]     TINYINT         NULL,
    [ContactIdNo]    INT             NULL,
    [DocumentIdNo]   SMALLINT        NULL,
    [DataImageIdNo]  INT             NULL,
    [DocumentNumber] VARCHAR (30)    NULL,
    [IssueDate]      DATE            NULL,
    [ExpiryDate]     DATE            NULL,
    [UserIdNo]       SMALLINT        NULL,
    [Active]         BIT             NULL,
    [Picture]        VARBINARY (MAX) NULL,
    [DateCreated]    DATE            CONSTRAINT [DF_DocumentDetail_DatedCreated] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_DocumentDetail] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


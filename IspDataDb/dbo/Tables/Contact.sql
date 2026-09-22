CREATE TABLE [dbo].[Contact] (
    [IdNo]    INT      IDENTITY (1, 1) NOT NULL,
    [CSEIdNo] INT      NOT NULL,
    [CSECode] CHAR (1) NOT NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [UQ_Contact_CSECode_CSEIdNo] UNIQUE NONCLUSTERED ([CSECode] ASC, [CSEIdNo] ASC),
    CONSTRAINT [CK_Contact_CSECode] CHECK ([CSECode] IN ('C', 'S', 'E'))
);


GO


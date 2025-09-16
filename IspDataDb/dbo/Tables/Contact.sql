CREATE TABLE [dbo].[Contact] (
    [IdNo]    INT      IDENTITY (1, 1) NOT NULL,
    [CSEIdNo] INT      NULL,
    [CSECode] CHAR (1) NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


CREATE TABLE [dbo].[User] (
    [IdNo]              INT           IDENTITY (18, 1) NOT NULL,
    [UserName]          VARCHAR (20)  NOT NULL,
    [Password]          VARCHAR (50)  NULL,
    [EmployeeIdNo]      INT           NULL,
    [SecurityGroupIDNo] SMALLINT      NULL,
    [FullName]          VARCHAR (50)  NULL,
    [FullNameAra]       NVARCHAR (50) NULL,
    [SecurityLevel]     TINYINT       NULL,
    [DateTimeStamp]     ROWVERSION    NULL,
    CONSTRAINT [PK_UserIDNo] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [FK_User_User] FOREIGN KEY ([IdNo]) REFERENCES [dbo].[User] ([IdNo])
);










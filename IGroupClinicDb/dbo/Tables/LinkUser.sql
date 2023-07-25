CREATE TABLE [dbo].[LinkUser] (
    [IdNo]            INT           IDENTITY (1, 1) NOT NULL,
    [UserId]          VARCHAR (15)  NULL,
    [UserNameEnglish] VARCHAR (100) NULL,
    [UserIdNo]        INT           NULL,
    CONSTRAINT [PK_LinkUser] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


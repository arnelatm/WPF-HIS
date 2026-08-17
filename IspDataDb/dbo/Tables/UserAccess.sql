CREATE TABLE [dbo].[UserAccess] (
    [IdNo]               INT      IDENTITY (1, 1) NOT NULL,
    [UserIdNo]           SMALLINT NOT NULL,
    [SecurityObjectIdNo] INT      NOT NULL,
    [Visible]            BIT      NOT NULL,
    [Editable]           BIT      NOT NULL,
    CONSTRAINT [PK_UserAccessIDNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO


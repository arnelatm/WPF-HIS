CREATE TABLE [dbo].[UsersTemplte] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (MAX) NULL,
    [NameLatine]       NVARCHAR (MAX) NULL,
    [Note]             NVARCHAR (MAX) NULL,
    [UserRoles]        NVARCHAR (MAX) NULL,
    [UserRolesOther]   NVARCHAR (MAX) NULL,
    [UserLocalSetting] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_UsersTemplte] PRIMARY KEY CLUSTERED ([ID] ASC)
);


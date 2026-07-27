CREATE TABLE [dbo].[JC_ED_Document] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [CreatedDateTime]    DATETIME       NOT NULL,
    [CreatedUserId]      INT            NOT NULL,
    [LastEditedDateTime] DATETIME       NULL,
    [LastEditedUserId]   INT            NULL,
    [Type]               INT            NOT NULL,
    [ReferenceId]        INT            NULL,
    [Values]             NVARCHAR (MAX) NOT NULL,
    [Status]             INT            DEFAULT ((0)) NOT NULL,
    [DoctorId]           INT            NULL,
    [BarcodeDateTime]    DATETIME       NULL,
    [BarcodeUserId]      INT            NULL,
    CONSTRAINT [PK_dbo.JC_ED_Document] PRIMARY KEY CLUSTERED ([Id] ASC)
);


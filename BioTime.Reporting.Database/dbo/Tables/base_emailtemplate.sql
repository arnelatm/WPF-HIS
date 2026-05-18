CREATE TABLE [dbo].[base_emailtemplate] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [create_time]  DATETIME2 (7)  NULL,
    [create_user]  NVARCHAR (150) NULL,
    [change_time]  DATETIME2 (7)  NULL,
    [change_user]  NVARCHAR (150) NULL,
    [status]       SMALLINT       NOT NULL,
    [category]     INT            NOT NULL,
    [sub_category] INT            NOT NULL,
    [event]        INT            NOT NULL,
    [receiver]     INT            NOT NULL,
    [subject]      NVARCHAR (100) NULL,
    [template]     NVARCHAR (MAX) NOT NULL,
    [enable]       BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


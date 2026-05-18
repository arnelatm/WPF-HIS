CREATE TABLE [dbo].[accounts_adminbiodata] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [create_time] DATETIME2 (7)  NULL,
    [create_user] NVARCHAR (150) NULL,
    [change_time] DATETIME2 (7)  NULL,
    [change_user] NVARCHAR (150) NULL,
    [status]      SMALLINT       NOT NULL,
    [bio_tmp]     NVARCHAR (MAX) NOT NULL,
    [bio_no]      INT            NULL,
    [bio_index]   INT            NULL,
    [bio_type]    INT            NOT NULL,
    [major_ver]   NVARCHAR (30)  NOT NULL,
    [minor_ver]   NVARCHAR (30)  NULL,
    [bio_format]  INT            NULL,
    [valid]       BIT            NOT NULL,
    [duress]      BIT            NOT NULL,
    [admin_id]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [accounts_adminbiodata_admin_id_1e6d2d45_fk_auth_user_id] FOREIGN KEY ([admin_id]) REFERENCES [dbo].[auth_user] ([id])
);


GO
CREATE NONCLUSTERED INDEX [accounts_adminbiodata_admin_id_1e6d2d45]
    ON [dbo].[accounts_adminbiodata]([admin_id] ASC);


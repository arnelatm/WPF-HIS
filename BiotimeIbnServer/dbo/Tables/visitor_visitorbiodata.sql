CREATE TABLE [dbo].[visitor_visitorbiodata] (
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
    [valid]       INT            NOT NULL,
    [duress]      INT            NOT NULL,
    [update_time] DATETIME2 (7)  NULL,
    [sn]          NVARCHAR (50)  NULL,
    [visitor_id]  INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [visitor_visitorbiodata_visitor_id_b944ed37_fk_visitor_visitor_id] FOREIGN KEY ([visitor_id]) REFERENCES [dbo].[visitor_visitor] ([id])
);


GO
CREATE NONCLUSTERED INDEX [visitor_visitorbiodata_visitor_id_b944ed37]
    ON [dbo].[visitor_visitorbiodata]([visitor_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [visitor_visitorbiodata_visitor_id_bio_no_bio_index_bio_type_bio_format_major_ver_minor_ver_225ce182_uniq]
    ON [dbo].[visitor_visitorbiodata]([visitor_id] ASC, [bio_no] ASC, [bio_index] ASC, [bio_type] ASC, [bio_format] ASC, [major_ver] ASC, [minor_ver] ASC) WHERE ([visitor_id] IS NOT NULL AND [bio_no] IS NOT NULL AND [bio_index] IS NOT NULL AND [bio_type] IS NOT NULL AND [bio_format] IS NOT NULL AND [major_ver] IS NOT NULL AND [minor_ver] IS NOT NULL);


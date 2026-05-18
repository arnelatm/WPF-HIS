CREATE TABLE [dbo].[iclock_biodata] (
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
    [minor_ver]   NVARCHAR (30)  NOT NULL,
    [bio_format]  INT            NULL,
    [valid]       INT            NOT NULL,
    [duress]      INT            NOT NULL,
    [update_time] DATETIME2 (7)  NULL,
    [sn]          NVARCHAR (50)  NULL,
    [employee_id] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [iclock_biodata_employee_id_ff748ea7_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [iclock_biodata_employee_id_bio_no_bio_index_bio_type_bio_format_major_ver_minor_ver_bc5286ed_uniq]
    ON [dbo].[iclock_biodata]([employee_id] ASC, [bio_no] ASC, [bio_index] ASC, [bio_type] ASC, [bio_format] ASC, [major_ver] ASC, [minor_ver] ASC) WHERE ([employee_id] IS NOT NULL AND [bio_no] IS NOT NULL AND [bio_index] IS NOT NULL AND [bio_type] IS NOT NULL AND [bio_format] IS NOT NULL AND [major_ver] IS NOT NULL AND [minor_ver] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [iclock_biodata_employee_id_ff748ea7]
    ON [dbo].[iclock_biodata]([employee_id] ASC);


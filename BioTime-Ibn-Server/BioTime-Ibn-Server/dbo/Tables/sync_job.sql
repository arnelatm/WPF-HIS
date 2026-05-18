CREATE TABLE [dbo].[sync_job] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [post_time]   DATETIME2 (7)  NULL,
    [flag]        SMALLINT       NOT NULL,
    [update_time] DATETIME2 (7)  NULL,
    [sync_ret]    NVARCHAR (200) NULL,
    [job_code]    NVARCHAR (50)  NOT NULL,
    [job_name]    NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [sync_job_job_code_job_name_4ec5619e_uniq]
    ON [dbo].[sync_job]([job_code] ASC, [job_name] ASC) WHERE ([job_code] IS NOT NULL AND [job_name] IS NOT NULL);


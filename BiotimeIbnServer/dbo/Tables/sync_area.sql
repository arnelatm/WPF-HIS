CREATE TABLE [dbo].[sync_area] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [post_time]   DATETIME2 (7)  NULL,
    [flag]        SMALLINT       NOT NULL,
    [update_time] DATETIME2 (7)  NULL,
    [sync_ret]    NVARCHAR (200) NULL,
    [area_code]   NVARCHAR (30)  NOT NULL,
    [area_name]   NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [sync_area_area_code_area_name_200046d1_uniq]
    ON [dbo].[sync_area]([area_code] ASC, [area_name] ASC) WHERE ([area_code] IS NOT NULL AND [area_name] IS NOT NULL);


CREATE TABLE [dbo].[personnel_area] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [area_code]      NVARCHAR (30)  NOT NULL,
    [area_name]      NVARCHAR (100) NOT NULL,
    [is_default]     BIT            NOT NULL,
    [employee_count] INT            NOT NULL,
    [device_count]   INT            NOT NULL,
    [company_id]     INT            NOT NULL,
    [parent_area_id] INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [personnel_area_company_id_59750eb5_fk_personnel_company_id] FOREIGN KEY ([company_id]) REFERENCES [dbo].[personnel_company] ([id]),
    CONSTRAINT [personnel_area_parent_area_id_39028fda_fk_personnel_area_id] FOREIGN KEY ([parent_area_id]) REFERENCES [dbo].[personnel_area] ([id])
);


GO
CREATE NONCLUSTERED INDEX [personnel_area_company_id_59750eb5]
    ON [dbo].[personnel_area]([company_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [personnel_area_company_id_area_code_aa39c55c_uniq]
    ON [dbo].[personnel_area]([company_id] ASC, [area_code] ASC) WHERE ([company_id] IS NOT NULL AND [area_code] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [personnel_area_parent_area_id_39028fda]
    ON [dbo].[personnel_area]([parent_area_id] ASC);


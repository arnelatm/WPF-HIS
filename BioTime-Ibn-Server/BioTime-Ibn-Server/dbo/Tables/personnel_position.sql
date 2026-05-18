CREATE TABLE [dbo].[personnel_position] (
    [id]                 INT            IDENTITY (1, 1) NOT NULL,
    [position_code]      NVARCHAR (50)  NOT NULL,
    [position_name]      NVARCHAR (100) NOT NULL,
    [is_default]         BIT            NOT NULL,
    [company_id]         INT            NOT NULL,
    [parent_position_id] INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [personnel_position_company_id_f06c5d2a_fk_personnel_company_id] FOREIGN KEY ([company_id]) REFERENCES [dbo].[personnel_company] ([id]),
    CONSTRAINT [personnel_position_parent_position_id_a496a36b_fk_personnel_position_id] FOREIGN KEY ([parent_position_id]) REFERENCES [dbo].[personnel_position] ([id])
);


GO
CREATE NONCLUSTERED INDEX [personnel_position_company_id_f06c5d2a]
    ON [dbo].[personnel_position]([company_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [personnel_position_company_id_position_code_4708726e_uniq]
    ON [dbo].[personnel_position]([company_id] ASC, [position_code] ASC) WHERE ([company_id] IS NOT NULL AND [position_code] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [personnel_position_parent_position_id_a496a36b]
    ON [dbo].[personnel_position]([parent_position_id] ASC);


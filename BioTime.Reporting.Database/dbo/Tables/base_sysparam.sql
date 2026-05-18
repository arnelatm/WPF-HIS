CREATE TABLE [dbo].[base_sysparam] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [para_name]  NVARCHAR (30)  NOT NULL,
    [para_type]  NVARCHAR (10)  NULL,
    [para_value] NVARCHAR (250) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [base_sysparam_para_name_para_type_3086789a_uniq]
    ON [dbo].[base_sysparam]([para_name] ASC, [para_type] ASC) WHERE ([para_name] IS NOT NULL AND [para_type] IS NOT NULL);


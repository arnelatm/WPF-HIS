CREATE TABLE [dbo].[workflow_workflowrole] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [role_code]      NVARCHAR (30)  NOT NULL,
    [role_name]      NVARCHAR (50)  NOT NULL,
    [description]    NVARCHAR (200) NULL,
    [company_id]     INT            NOT NULL,
    [parent_role_id] INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [workflow_workflowrole_company_id_bbb75590_fk_personnel_company_id] FOREIGN KEY ([company_id]) REFERENCES [dbo].[personnel_company] ([id]),
    CONSTRAINT [workflow_workflowrole_parent_role_id_91433355_fk_workflow_workflowrole_id] FOREIGN KEY ([parent_role_id]) REFERENCES [dbo].[workflow_workflowrole] ([id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [workflow_workflowrole_company_id_role_name_afcc5f2b_uniq]
    ON [dbo].[workflow_workflowrole]([company_id] ASC, [role_name] ASC) WHERE ([company_id] IS NOT NULL AND [role_name] IS NOT NULL);


GO
CREATE UNIQUE NONCLUSTERED INDEX [workflow_workflowrole_company_id_role_code_a4e809d7_uniq]
    ON [dbo].[workflow_workflowrole]([company_id] ASC, [role_code] ASC) WHERE ([company_id] IS NOT NULL AND [role_code] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [workflow_workflowrole_parent_role_id_91433355]
    ON [dbo].[workflow_workflowrole]([parent_role_id] ASC);


GO
CREATE NONCLUSTERED INDEX [workflow_workflowrole_company_id_bbb75590]
    ON [dbo].[workflow_workflowrole]([company_id] ASC);


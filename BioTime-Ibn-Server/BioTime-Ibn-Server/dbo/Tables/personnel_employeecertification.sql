CREATE TABLE [dbo].[personnel_employeecertification] (
    [id]                 INT            IDENTITY (1, 1) NOT NULL,
    [expire_on]          DATE           NULL,
    [email_alert]        BIT            NOT NULL,
    [before]             INT            NULL,
    [certification_code] NVARCHAR (20)  NULL,
    [file_name]          NVARCHAR (200) NULL,
    [file]               NVARCHAR (200) NULL,
    [certification_id]   INT            NOT NULL,
    [employee_id]        INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [personnel_employeecertification_certification_id_faabed40_fk_personnel_certification_id] FOREIGN KEY ([certification_id]) REFERENCES [dbo].[personnel_certification] ([id]),
    CONSTRAINT [personnel_employeecertification_employee_id_b7bd3867_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [personnel_employeecertification_certification_id_faabed40]
    ON [dbo].[personnel_employeecertification]([certification_id] ASC);


GO
CREATE NONCLUSTERED INDEX [personnel_employeecertification_employee_id_b7bd3867]
    ON [dbo].[personnel_employeecertification]([employee_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [personnel_employeecertification_employee_id_certification_id_7bcf4c7d_uniq]
    ON [dbo].[personnel_employeecertification]([employee_id] ASC, [certification_id] ASC) WHERE ([employee_id] IS NOT NULL AND [certification_id] IS NOT NULL);


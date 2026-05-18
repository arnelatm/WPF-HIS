CREATE TABLE [dbo].[att_deptattrule] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [alias]         NVARCHAR (50)  NOT NULL,
    [rule]          NVARCHAR (MAX) NULL,
    [department_id] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_deptattrule_department_id_f333c8f0_fk_personnel_department_id] FOREIGN KEY ([department_id]) REFERENCES [dbo].[personnel_department] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_deptattrule_department_id_f333c8f0]
    ON [dbo].[att_deptattrule]([department_id] ASC);


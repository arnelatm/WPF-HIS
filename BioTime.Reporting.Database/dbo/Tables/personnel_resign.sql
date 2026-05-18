CREATE TABLE [dbo].[personnel_resign] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [resign_date] DATE           NOT NULL,
    [resign_type] INT            NULL,
    [disableatt]  BIT            NOT NULL,
    [reason]      NVARCHAR (200) NULL,
    [employee_id] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [personnel_resign_employee_id_dd9b7e08_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    UNIQUE NONCLUSTERED ([employee_id] ASC)
);


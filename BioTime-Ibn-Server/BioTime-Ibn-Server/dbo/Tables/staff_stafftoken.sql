CREATE TABLE [dbo].[staff_stafftoken] (
    [key]     NVARCHAR (40) NOT NULL,
    [created] DATETIME2 (7) NOT NULL,
    [user_id] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([key] ASC),
    CONSTRAINT [staff_stafftoken_user_id_39c937fa_fk_personnel_employee_id] FOREIGN KEY ([user_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    UNIQUE NONCLUSTERED ([user_id] ASC)
);


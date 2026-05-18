CREATE TABLE [dbo].[mobile_gpsforemployee] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [create_time] DATETIME2 (7)  NULL,
    [create_user] NVARCHAR (150) NULL,
    [change_time] DATETIME2 (7)  NULL,
    [change_user] NVARCHAR (150) NULL,
    [status]      SMALLINT       NOT NULL,
    [distance]    INT            NOT NULL,
    [start_date]  DATE           NOT NULL,
    [end_date]    DATE           NOT NULL,
    [employee_id] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [mobile_gpsforemployee_employee_id_982b7cef_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [mobile_gpsforemployee_employee_id_982b7cef]
    ON [dbo].[mobile_gpsforemployee]([employee_id] ASC);


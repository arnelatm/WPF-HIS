CREATE TABLE [dbo].[mobile_gpsfordepartment] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [create_time]   DATETIME2 (7)  NULL,
    [create_user]   NVARCHAR (150) NULL,
    [change_time]   DATETIME2 (7)  NULL,
    [change_user]   NVARCHAR (150) NULL,
    [status]        SMALLINT       NOT NULL,
    [distance]      INT            NOT NULL,
    [start_date]    DATE           NOT NULL,
    [end_date]      DATE           NOT NULL,
    [department_id] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [mobile_gpsfordepartment_department_id_988ccf22_fk_personnel_department_id] FOREIGN KEY ([department_id]) REFERENCES [dbo].[personnel_department] ([id])
);


GO
CREATE NONCLUSTERED INDEX [mobile_gpsfordepartment_department_id_988ccf22]
    ON [dbo].[mobile_gpsfordepartment]([department_id] ASC);


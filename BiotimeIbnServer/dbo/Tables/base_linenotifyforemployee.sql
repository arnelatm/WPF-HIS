CREATE TABLE [dbo].[base_linenotifyforemployee] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [line_notify_token] NVARCHAR (200) NULL,
    [send_photo]        BIT            NOT NULL,
    [push_time]         TIME (7)       NULL,
    [is_valid]          INT            NULL,
    [remark]            NVARCHAR (200) NULL,
    [message_type]      INT            NULL,
    [message_head]      NVARCHAR (100) NULL,
    [message_tail]      NVARCHAR (100) NULL,
    [employee_id]       INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [base_linenotifyforemployee_employee_id_42fb91f8_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    UNIQUE NONCLUSTERED ([employee_id] ASC)
);


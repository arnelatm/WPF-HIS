CREATE TABLE [dbo].[base_linenotifysetting] (
    [id]                     INT            IDENTITY (1, 1) NOT NULL,
    [line_notify_token]      NVARCHAR (200) NULL,
    [send_photo]             BIT            NOT NULL,
    [push_time]              TIME (7)       NULL,
    [is_valid]               INT            NULL,
    [remark]                 NVARCHAR (200) NULL,
    [include_sub_department] INT            NULL,
    [message_type]           INT            NULL,
    [message_head]           NVARCHAR (100) NULL,
    [message_tail]           NVARCHAR (100) NULL,
    [line_notify_dept_id]    INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [base_linenotifysetting_line_notify_dept_id_0643a5ed_fk_personnel_department_id] FOREIGN KEY ([line_notify_dept_id]) REFERENCES [dbo].[personnel_department] ([id])
);


GO
CREATE NONCLUSTERED INDEX [base_linenotifysetting_line_notify_dept_id_0643a5ed]
    ON [dbo].[base_linenotifysetting]([line_notify_dept_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [base_linenotifysetting_line_notify_dept_id_line_notify_token_message_type_dd79374f_uniq]
    ON [dbo].[base_linenotifysetting]([line_notify_dept_id] ASC, [line_notify_token] ASC, [message_type] ASC) WHERE ([line_notify_dept_id] IS NOT NULL AND [line_notify_token] IS NOT NULL AND [message_type] IS NOT NULL);


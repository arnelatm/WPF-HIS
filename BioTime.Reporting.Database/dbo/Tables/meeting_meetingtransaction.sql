CREATE TABLE [dbo].[meeting_meetingtransaction] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [emp_code]       NVARCHAR (50) NOT NULL,
    [punch_datetime] DATETIME2 (7) NOT NULL,
    [punch_date]     DATE          NOT NULL,
    [punch_time]     TIME (7)      NOT NULL,
    [punch_state]    NVARCHAR (5)  NOT NULL,
    [source]         SMALLINT      NOT NULL,
    [upload_time]    DATETIME2 (7) NOT NULL,
    [emp_id]         INT           NULL,
    [meeting_id]     INT           NULL,
    [terminal_id]    INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [meeting_meetingtransaction_emp_id_fbcdd686_fk_personnel_employee_id] FOREIGN KEY ([emp_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [meeting_meetingtransaction_meeting_id_e4e505e5_fk_meeting_meetingentity_workflowinstance_ptr_id] FOREIGN KEY ([meeting_id]) REFERENCES [dbo].[meeting_meetingentity] ([workflowinstance_ptr_id]),
    CONSTRAINT [meeting_meetingtransaction_terminal_id_047426f2_fk_iclock_terminal_id] FOREIGN KEY ([terminal_id]) REFERENCES [dbo].[iclock_terminal] ([id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [meeting_meetingtransaction_emp_id_punch_datetime_65665dce_uniq]
    ON [dbo].[meeting_meetingtransaction]([emp_id] ASC, [punch_datetime] ASC) WHERE ([emp_id] IS NOT NULL AND [punch_datetime] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [meeting_meetingtransaction_terminal_id_047426f2]
    ON [dbo].[meeting_meetingtransaction]([terminal_id] ASC);


GO
CREATE NONCLUSTERED INDEX [meeting_meetingtransaction_emp_id_fbcdd686]
    ON [dbo].[meeting_meetingtransaction]([emp_id] ASC);


GO
CREATE NONCLUSTERED INDEX [meeting_meetingtransaction_meeting_id_e4e505e5]
    ON [dbo].[meeting_meetingtransaction]([meeting_id] ASC);


CREATE TABLE [dbo].[meeting_meetingpayloadbase] (
    [id]                CHAR (32)     NOT NULL,
    [start_time]        DATETIME2 (7) NOT NULL,
    [end_time]          DATETIME2 (7) NOT NULL,
    [duration]          INT           NOT NULL,
    [meeting_date]      DATE          NOT NULL,
    [clock_in]          DATETIME2 (7) NULL,
    [clock_out]         DATETIME2 (7) NULL,
    [attended_duration] INT           NOT NULL,
    [late_in]           INT           NOT NULL,
    [early_out]         INT           NOT NULL,
    [absent]            INT           NOT NULL,
    [emp_id]            INT           NOT NULL,
    [meeting_id]        INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [meeting_meetingpayloadbase_emp_id_ed6ec148_fk_personnel_employee_id] FOREIGN KEY ([emp_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [meeting_meetingpayloadbase_meeting_id_ca9d20cc_fk_meeting_meetingentity_workflowinstance_ptr_id] FOREIGN KEY ([meeting_id]) REFERENCES [dbo].[meeting_meetingentity] ([workflowinstance_ptr_id])
);


GO
CREATE NONCLUSTERED INDEX [meeting_meetingpayloadbase_meeting_id_ca9d20cc]
    ON [dbo].[meeting_meetingpayloadbase]([meeting_id] ASC);


GO
CREATE NONCLUSTERED INDEX [meeting_meetingpayloadbase_emp_id_ed6ec148]
    ON [dbo].[meeting_meetingpayloadbase]([emp_id] ASC);


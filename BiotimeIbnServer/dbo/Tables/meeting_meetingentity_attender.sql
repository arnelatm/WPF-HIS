CREATE TABLE [dbo].[meeting_meetingentity_attender] (
    [id]               INT IDENTITY (1, 1) NOT NULL,
    [meetingentity_id] INT NOT NULL,
    [employee_id]      INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [meeting_meetingentity_attender_employee_id_ee898064_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [meeting_meetingentity_attender_meetingentity_id_b96dbc7d_fk_meeting_meetingentity_workflowinstance_ptr_id] FOREIGN KEY ([meetingentity_id]) REFERENCES [dbo].[meeting_meetingentity] ([workflowinstance_ptr_id])
);


GO
CREATE NONCLUSTERED INDEX [meeting_meetingentity_attender_employee_id_ee898064]
    ON [dbo].[meeting_meetingentity_attender]([employee_id] ASC);


GO
CREATE NONCLUSTERED INDEX [meeting_meetingentity_attender_meetingentity_id_b96dbc7d]
    ON [dbo].[meeting_meetingentity_attender]([meetingentity_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [meeting_meetingentity_attender_meetingentity_id_employee_id_b556fc2d_uniq]
    ON [dbo].[meeting_meetingentity_attender]([meetingentity_id] ASC, [employee_id] ASC) WHERE ([meetingentity_id] IS NOT NULL AND [employee_id] IS NOT NULL);


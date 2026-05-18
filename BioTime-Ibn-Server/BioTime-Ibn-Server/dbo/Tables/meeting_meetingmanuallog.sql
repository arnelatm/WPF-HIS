CREATE TABLE [dbo].[meeting_meetingmanuallog] (
    [workflowinstance_ptr_id] INT            NOT NULL,
    [punch_time]              DATETIME2 (7)  NOT NULL,
    [punch_state]             NVARCHAR (5)   NOT NULL,
    [apply_reason]            NVARCHAR (200) NOT NULL,
    [apply_time]              DATETIME2 (7)  NOT NULL,
    [meeting_id]              INT            NULL,
    PRIMARY KEY CLUSTERED ([workflowinstance_ptr_id] ASC),
    CONSTRAINT [meeting_meetingmanuallog_meeting_id_a672eaaf_fk_meeting_meetingentity_workflowinstance_ptr_id] FOREIGN KEY ([meeting_id]) REFERENCES [dbo].[meeting_meetingentity] ([workflowinstance_ptr_id]),
    CONSTRAINT [meeting_meetingmanuallog_workflowinstance_ptr_id_bd514862_fk_workflow_workflowinstance_id] FOREIGN KEY ([workflowinstance_ptr_id]) REFERENCES [dbo].[workflow_workflowinstance] ([id])
);


GO
CREATE NONCLUSTERED INDEX [meeting_meetingmanuallog_meeting_id_a672eaaf]
    ON [dbo].[meeting_meetingmanuallog]([meeting_id] ASC);


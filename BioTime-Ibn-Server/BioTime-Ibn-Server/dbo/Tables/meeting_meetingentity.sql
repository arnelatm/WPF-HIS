CREATE TABLE [dbo].[meeting_meetingentity] (
    [workflowinstance_ptr_id] INT            NOT NULL,
    [code]                    NVARCHAR (32)  NOT NULL,
    [alias]                   NVARCHAR (50)  NOT NULL,
    [content]                 NVARCHAR (200) NULL,
    [meeting_date]            DATE           NOT NULL,
    [start_time]              DATETIME2 (7)  NOT NULL,
    [end_time]                DATETIME2 (7)  NOT NULL,
    [duration]                INT            NOT NULL,
    [in_required]             BIT            NOT NULL,
    [in_start]                DATETIME2 (7)  NOT NULL,
    [in_end]                  DATETIME2 (7)  NOT NULL,
    [out_required]            BIT            NOT NULL,
    [out_start]               DATETIME2 (7)  NOT NULL,
    [out_end]                 DATETIME2 (7)  NOT NULL,
    [enable_virtual]          BIT            NOT NULL,
    [virutal_uuid]            NVARCHAR (50)  NULL,
    [time_zone]               SMALLINT       NOT NULL,
    [preferences]             NVARCHAR (MAX) NULL,
    [link_data]               NVARCHAR (MAX) NULL,
    [apply_reason]            NVARCHAR (200) NOT NULL,
    [apply_time]              DATETIME2 (7)  NOT NULL,
    [calculation_time]        DATETIME2 (7)  NULL,
    [sync_time]               DATETIME2 (7)  NULL,
    [view_date]               DATE           NOT NULL,
    [host_video]              BIT            NOT NULL,
    [participant_video]       BIT            NOT NULL,
    [enable_waiting_room]     BIT            NOT NULL,
    [jbh_anytime]             BIT            NOT NULL,
    [mute_upon_entry]         BIT            NOT NULL,
    [auto_recording]          NVARCHAR (50)  NOT NULL,
    [room_id]                 INT            NULL,
    [zoom_id]                 INT            NULL,
    PRIMARY KEY CLUSTERED ([workflowinstance_ptr_id] ASC),
    CONSTRAINT [meeting_meetingentity_room_id_bc2c738e_fk_meeting_meetingroom_id] FOREIGN KEY ([room_id]) REFERENCES [dbo].[meeting_meetingroom] ([id]),
    CONSTRAINT [meeting_meetingentity_workflowinstance_ptr_id_dbd9ab40_fk_workflow_workflowinstance_id] FOREIGN KEY ([workflowinstance_ptr_id]) REFERENCES [dbo].[workflow_workflowinstance] ([id]),
    CONSTRAINT [meeting_meetingentity_zoom_id_7f87d666_fk_base_zoomsetting_id] FOREIGN KEY ([zoom_id]) REFERENCES [dbo].[base_zoomsetting] ([id]),
    UNIQUE NONCLUSTERED ([code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [meeting_meetingentity_room_id_bc2c738e]
    ON [dbo].[meeting_meetingentity]([room_id] ASC);


GO
CREATE NONCLUSTERED INDEX [meeting_meetingentity_zoom_id_7f87d666]
    ON [dbo].[meeting_meetingentity]([zoom_id] ASC);


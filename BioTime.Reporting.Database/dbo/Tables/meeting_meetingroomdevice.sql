CREATE TABLE [dbo].[meeting_meetingroomdevice] (
    [id]        INT IDENTITY (1, 1) NOT NULL,
    [device_id] INT NOT NULL,
    [room_id]   INT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [meeting_meetingroomdevice_device_id_a09e8a7d_fk_iclock_terminal_id] FOREIGN KEY ([device_id]) REFERENCES [dbo].[iclock_terminal] ([id]),
    CONSTRAINT [meeting_meetingroomdevice_room_id_e000d78d_fk_meeting_meetingroom_id] FOREIGN KEY ([room_id]) REFERENCES [dbo].[meeting_meetingroom] ([id]),
    UNIQUE NONCLUSTERED ([device_id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [meeting_meetingroomdevice_room_id_e000d78d]
    ON [dbo].[meeting_meetingroomdevice]([room_id] ASC);


CREATE TABLE [dbo].[django_celery_beat_solarschedule] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [event]     NVARCHAR (24)  NOT NULL,
    [latitude]  NUMERIC (9, 6) NOT NULL,
    [longitude] NUMERIC (9, 6) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [django_celery_beat_solarschedule_event_latitude_longitude_ba64999a_uniq]
    ON [dbo].[django_celery_beat_solarschedule]([event] ASC, [latitude] ASC, [longitude] ASC) WHERE ([event] IS NOT NULL AND [latitude] IS NOT NULL AND [longitude] IS NOT NULL);


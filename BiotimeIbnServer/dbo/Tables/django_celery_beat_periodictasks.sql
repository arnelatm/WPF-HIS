CREATE TABLE [dbo].[django_celery_beat_periodictasks] (
    [ident]       SMALLINT      NOT NULL,
    [last_update] DATETIME2 (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([ident] ASC)
);


CREATE TABLE [dbo].[visitor_visitorlog] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [create_time]    DATETIME2 (7)  NULL,
    [create_user]    NVARCHAR (150) NULL,
    [change_time]    DATETIME2 (7)  NULL,
    [change_user]    NVARCHAR (150) NULL,
    [status]         SMALLINT       NOT NULL,
    [visitor_status] SMALLINT       NULL,
    [visitor_id]     INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [visitor_visitorlog_visitor_id_ebaafde1_fk_visitor_visitor_id] FOREIGN KEY ([visitor_id]) REFERENCES [dbo].[visitor_visitor] ([id])
);


GO
CREATE NONCLUSTERED INDEX [visitor_visitorlog_visitor_id_ebaafde1]
    ON [dbo].[visitor_visitorlog]([visitor_id] ASC);


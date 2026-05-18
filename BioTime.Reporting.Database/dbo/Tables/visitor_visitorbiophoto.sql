CREATE TABLE [dbo].[visitor_visitorbiophoto] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [create_time]    DATETIME2 (7)  NULL,
    [create_user]    NVARCHAR (150) NULL,
    [change_time]    DATETIME2 (7)  NULL,
    [change_user]    NVARCHAR (150) NULL,
    [status]         SMALLINT       NOT NULL,
    [first_name]     NVARCHAR (100) NULL,
    [last_name]      NVARCHAR (100) NULL,
    [email]          NVARCHAR (254) NULL,
    [enroll_sn]      NVARCHAR (50)  NULL,
    [register_photo] NVARCHAR (100) NOT NULL,
    [register_time]  DATETIME2 (7)  NOT NULL,
    [approval_photo] NVARCHAR (100) NULL,
    [approval_state] SMALLINT       NOT NULL,
    [approval_time]  DATETIME2 (7)  NULL,
    [remark]         NVARCHAR (100) NULL,
    [visitor_id]     INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [visitor_visitorbiophoto_visitor_id_9816daf7_fk_visitor_visitor_id] FOREIGN KEY ([visitor_id]) REFERENCES [dbo].[visitor_visitor] ([id])
);


GO
CREATE NONCLUSTERED INDEX [visitor_visitorbiophoto_visitor_id_9816daf7]
    ON [dbo].[visitor_visitorbiophoto]([visitor_id] ASC);


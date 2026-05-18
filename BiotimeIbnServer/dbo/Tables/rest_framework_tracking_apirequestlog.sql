CREATE TABLE [dbo].[rest_framework_tracking_apirequestlog] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [requested_at]        DATETIME2 (7)  NOT NULL,
    [response_ms]         INT            NOT NULL,
    [path]                NVARCHAR (200) NOT NULL,
    [remote_addr]         NVARCHAR (39)  NOT NULL,
    [host]                NVARCHAR (200) NOT NULL,
    [method]              NVARCHAR (10)  NOT NULL,
    [query_params]        NVARCHAR (MAX) NULL,
    [data]                NVARCHAR (MAX) NULL,
    [response]            NVARCHAR (MAX) NULL,
    [status_code]         INT            NULL,
    [user_id]             INT            NULL,
    [view]                NVARCHAR (200) NULL,
    [view_method]         NVARCHAR (200) NULL,
    [errors]              NVARCHAR (MAX) NULL,
    [username_persistent] NVARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [rest_framework_tracking_apirequestlog_response_ms_57693beb_check] CHECK ([response_ms]>=(0)),
    CONSTRAINT [rest_framework_tracking_apirequestlog_status_code_3c9e2003_check] CHECK ([status_code]>=(0)),
    CONSTRAINT [rest_framework_tracking_apirequestlog_user_id_671b70b7_fk_auth_user_id] FOREIGN KEY ([user_id]) REFERENCES [dbo].[auth_user] ([id])
);


GO
CREATE NONCLUSTERED INDEX [rest_framework_tracking_apirequestlog_path_fe81f91b]
    ON [dbo].[rest_framework_tracking_apirequestlog]([path] ASC);


GO
CREATE NONCLUSTERED INDEX [rest_framework_tracking_apirequestlog_requested_at_b6f1c2f2]
    ON [dbo].[rest_framework_tracking_apirequestlog]([requested_at] ASC);


GO
CREATE NONCLUSTERED INDEX [rest_framework_tracking_apirequestlog_status_code_3c9e2003]
    ON [dbo].[rest_framework_tracking_apirequestlog]([status_code] ASC);


GO
CREATE NONCLUSTERED INDEX [rest_framework_tracking_apirequestlog_user_id_671b70b7]
    ON [dbo].[rest_framework_tracking_apirequestlog]([user_id] ASC);


GO
CREATE NONCLUSTERED INDEX [rest_framework_tracking_apirequestlog_view_5bd1e407]
    ON [dbo].[rest_framework_tracking_apirequestlog]([view] ASC);


GO
CREATE NONCLUSTERED INDEX [rest_framework_tracking_apirequestlog_view_method_dd790881]
    ON [dbo].[rest_framework_tracking_apirequestlog]([view_method] ASC);


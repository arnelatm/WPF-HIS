CREATE TABLE [dbo].[mobile_mobileapirequestlog] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [username_persistent] NVARCHAR (200) NULL,
    [requested_at]        DATETIME2 (7)  NOT NULL,
    [response_ms]         INT            NOT NULL,
    [path]                NVARCHAR (200) NOT NULL,
    [view]                NVARCHAR (200) NULL,
    [view_method]         NVARCHAR (200) NULL,
    [remote_addr]         NVARCHAR (39)  NOT NULL,
    [host]                NVARCHAR (200) NOT NULL,
    [method]              NVARCHAR (10)  NOT NULL,
    [query_params]        NVARCHAR (MAX) NULL,
    [data]                NVARCHAR (MAX) NULL,
    [response]            NVARCHAR (MAX) NULL,
    [errors]              NVARCHAR (MAX) NULL,
    [status_code]         INT            NULL,
    [user_id]             INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [mobile_mobileapirequestlog_response_ms_2a25ef98_check] CHECK ([response_ms]>=(0)),
    CONSTRAINT [mobile_mobileapirequestlog_status_code_c2de0c48_check] CHECK ([status_code]>=(0)),
    CONSTRAINT [mobile_mobileapirequestlog_user_id_dfd3ded1_fk_personnel_employee_id] FOREIGN KEY ([user_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [mobile_mobileapirequestlog_path_830043b5]
    ON [dbo].[mobile_mobileapirequestlog]([path] ASC);


GO
CREATE NONCLUSTERED INDEX [mobile_mobileapirequestlog_requested_at_a8c85067]
    ON [dbo].[mobile_mobileapirequestlog]([requested_at] ASC);


GO
CREATE NONCLUSTERED INDEX [mobile_mobileapirequestlog_status_code_c2de0c48]
    ON [dbo].[mobile_mobileapirequestlog]([status_code] ASC);


GO
CREATE NONCLUSTERED INDEX [mobile_mobileapirequestlog_user_id_dfd3ded1]
    ON [dbo].[mobile_mobileapirequestlog]([user_id] ASC);


GO
CREATE NONCLUSTERED INDEX [mobile_mobileapirequestlog_view_50dbf600]
    ON [dbo].[mobile_mobileapirequestlog]([view] ASC);


GO
CREATE NONCLUSTERED INDEX [mobile_mobileapirequestlog_view_method_2e13cf95]
    ON [dbo].[mobile_mobileapirequestlog]([view_method] ASC);


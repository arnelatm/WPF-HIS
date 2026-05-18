CREATE TABLE [dbo].[att_custom_report] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [name]            NVARCHAR (100) NOT NULL,
    [description]     NVARCHAR (MAX) NULL,
    [data_source]     NVARCHAR (50)  NULL,
    [date_range]      NVARCHAR (50)  NULL,
    [selected_fields] NVARCHAR (MAX) NOT NULL,
    [created_at]      DATETIME2 (7)  NOT NULL,
    [updated_at]      DATETIME2 (7)  NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


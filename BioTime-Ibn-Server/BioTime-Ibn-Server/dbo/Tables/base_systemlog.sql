CREATE TABLE [dbo].[base_systemlog] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [execute_time]   DATETIME2 (7)  NOT NULL,
    [operation]      SMALLINT       NOT NULL,
    [execute_status] SMALLINT       NOT NULL,
    [description]    NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


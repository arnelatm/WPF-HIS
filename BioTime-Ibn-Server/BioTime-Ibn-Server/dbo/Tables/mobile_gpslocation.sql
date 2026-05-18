CREATE TABLE [dbo].[mobile_gpslocation] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [create_time] DATETIME2 (7)  NULL,
    [create_user] NVARCHAR (150) NULL,
    [change_time] DATETIME2 (7)  NULL,
    [change_user] NVARCHAR (150) NULL,
    [status]      SMALLINT       NOT NULL,
    [alias]       NVARCHAR (100) NOT NULL,
    [location]    NVARCHAR (100) NOT NULL,
    [longitude]   FLOAT (53)     NOT NULL,
    [latitude]    FLOAT (53)     NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


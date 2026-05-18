CREATE TABLE [dbo].[base_whatsapplog] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [receiver]  NVARCHAR (50)  NOT NULL,
    [content]   NVARCHAR (300) NOT NULL,
    [result]    SMALLINT       NOT NULL,
    [push_time] DATETIME2 (7)  NOT NULL,
    [reason]    NVARCHAR (300) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


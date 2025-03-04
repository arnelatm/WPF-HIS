CREATE TABLE [dbo].[SmsTemplte] (
    [Title] NVARCHAR (50)  NULL,
    [Txt]   NVARCHAR (MAX) NULL,
    [ID]    INT            IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_SmsTemplte] PRIMARY KEY CLUSTERED ([ID] ASC)
);


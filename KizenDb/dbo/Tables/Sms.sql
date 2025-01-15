CREATE TABLE [dbo].[Sms] (
    [SmsID]             INT            IDENTITY (1, 1) NOT NULL,
    [SmsFrom]           NVARCHAR (50)  NULL,
    [SmsToName]         NVARCHAR (50)  NULL,
    [SmsToNum]          NVARCHAR (MAX) NULL,
    [SmsText]           NVARCHAR (MAX) NULL,
    [SmsType]           NVARCHAR (50)  NULL,
    [SmsEvent]          NVARCHAR (MAX) NULL,
    [SmsDateTime]       DATE           NULL,
    [SmsStatue]         BIT            NULL,
    [SmsToID]           NVARCHAR (50)  NULL,
    [SmsAppID]          INT            NULL,
    [Code]              NVARCHAR (50)  NULL,
    [IsScheduled]       BIT            NULL,
    [Time]              TIME (0)       NULL,
    [AccountSenderName] NVARCHAR (MAX) NULL,
    [Disabled]          BIT            NULL,
    [APIResponse]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Sms] PRIMARY KEY CLUSTERED ([SmsID] ASC)
);


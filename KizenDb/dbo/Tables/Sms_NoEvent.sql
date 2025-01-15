CREATE TABLE [dbo].[Sms_NoEvent] (
    [SmsID]             INT            IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [SmsToName]         NVARCHAR (100) NULL,
    [SmsToNum]          NVARCHAR (100) NULL,
    [SmsText]           NVARCHAR (100) NULL,
    [SmsType]           NVARCHAR (100) NULL,
    [SmsDateTime]       DATETIME       NULL,
    [SmsStatue]         BIT            NULL,
    [SmsToID]           NVARCHAR (100) NULL,
    [SmsAppID]          INT            NULL,
    [SmsFrom]           NVARCHAR (100) NULL,
    [Code]              NVARCHAR (100) NULL,
    [IsScheduled]       BIT            NULL,
    [Time]              FLOAT (53)     NULL,
    [AccountSenderName] NVARCHAR (100) NULL,
    [Disabled]          BIT            NULL,
    CONSTRAINT [PK_Sms_NoEvent] PRIMARY KEY CLUSTERED ([SmsID] ASC)
);


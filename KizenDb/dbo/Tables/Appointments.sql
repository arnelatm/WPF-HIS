CREATE TABLE [dbo].[Appointments] (
    [UniqueID]                     INT             IDENTITY (1, 1) NOT NULL,
    [Type]                         INT             NULL,
    [StartDate]                    SMALLDATETIME   NULL,
    [EndDate]                      SMALLDATETIME   NULL,
    [AllDay]                       BIT             NULL,
    [Subject]                      NVARCHAR (MAX)  NULL,
    [Location]                     NVARCHAR (255)  NULL,
    [Description]                  NVARCHAR (MAX)  NULL,
    [Status]                       INT             NULL,
    [Label]                        INT             NULL,
    [ResourceID]                   INT             NULL,
    [ResourceIDs]                  NVARCHAR (MAX)  NULL,
    [ReminderInfo]                 NVARCHAR (MAX)  NULL,
    [RecurrenceInfo]               NVARCHAR (MAX)  NULL,
    [CutName]                      NVARCHAR (MAX)  NULL,
    [CustID]                       INT             NULL,
    [DrName]                       NVARCHAR (MAX)  NULL,
    [CustPhone]                    NVARCHAR (255)  NULL,
    [CustReminderSmsEnab]          BIT             NULL,
    [CustReminderSms1]             BIT             NULL,
    [CustReminderSms2]             BIT             NULL,
    [UserName]                     NVARCHAR (255)  NULL,
    [OutApp]                       BIT             NULL,
    [OutAppString]                 NVARCHAR (255)  NULL,
    [RecordingDate]                DATETIME        NULL,
    [CustIDXtra]                   NVARCHAR (MAX)  NULL,
    [CustGender]                   NVARCHAR (255)  NULL,
    [CustPhone2]                   NVARCHAR (255)  NULL,
    [Priority]                     BIT             NULL,
    [LastModfyedUser]              NVARCHAR (255)  NULL,
    [StatuName]                    NVARCHAR (MAX)  NULL,
    [LabelName]                    NVARCHAR (MAX)  NULL,
    [WorkTimeType]                 NVARCHAR (255)  NULL,
    [confirmedBit]                 INT             NULL,
    [confirmedUser]                NVARCHAR (255)  NULL,
    [confirmedDate]                DATETIME        NULL,
    [LastModfyedUserLabel]         NVARCHAR (MAX)  NULL,
    [AutoMoveCount]                INT             NULL,
    [AutoMoveDone]                 BIT             NULL,
    [CustResource]                 NVARCHAR (100)  NULL,
    [WorkID]                       NVARCHAR (255)  NULL,
    [IsOnline]                     BIT             NULL,
    [SessionDetailId]              INT             NULL,
    [SessionDetailIsReview]        BIT             NULL,
    [SessionDetailCode]            NVARCHAR (50)   NULL,
    [JME_ServiceID]                INT             NULL,
    [JME_ServicePrice]             DECIMAL (19, 4) NULL,
    [JME_ServiceDurationInMinutes] INT             NULL,
    [JME_ServiceName]              NVARCHAR (MAX)  NULL,
    [JME_PatientID]                INT             NULL,
    [JME_Latitude]                 FLOAT (53)      NULL,
    [JME_Longitude]                FLOAT (53)      NULL,
    [InvoiceId]                    INT             NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED ([UniqueID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [iCustID_Appointments]
    ON [dbo].[Appointments]([CustID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Appointments_SessionDetailId]
    ON [dbo].[Appointments]([SessionDetailId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Appointments_SessionDetailId_SessionDetailIsReview (ASC)]
    ON [dbo].[Appointments]([SessionDetailId] ASC, [SessionDetailIsReview] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Appointments_SessionDetailIsReview]
    ON [dbo].[Appointments]([SessionDetailIsReview] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Appointments_StartDateEndDateResourceID]
    ON [dbo].[Appointments]([StartDate] ASC, [EndDate] ASC, [ResourceID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Appointments_StartDate]
    ON [dbo].[Appointments]([StartDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Appointments_ResourceID]
    ON [dbo].[Appointments]([ResourceID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Appointments_IsOnline]
    ON [dbo].[Appointments]([IsOnline] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Appointments_EndDate]
    ON [dbo].[Appointments]([EndDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Appointments_CustMobile1]
    ON [dbo].[Appointments]([CustPhone] ASC);


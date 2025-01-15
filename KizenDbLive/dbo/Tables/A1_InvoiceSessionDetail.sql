CREATE TABLE [dbo].[A1_InvoiceSessionDetail] (
    [ID]                     INT            IDENTITY (1, 1) NOT NULL,
    [InvoiceSessionID]       INT            NOT NULL,
    [Code]                   NVARCHAR (50)  NOT NULL,
    [Description]            NVARCHAR (MAX) NOT NULL,
    [ExpectedDate]           DATE           NOT NULL,
    [SessionDate]            DATETIME       NULL,
    [HasFollowUp]            BIT            NOT NULL,
    [FollowUpDescription]    NVARCHAR (MAX) NULL,
    [FollowUpExpectedDate]   DATE           NULL,
    [FollowUpDays]           INT            NULL,
    [FollowUpIsExpired]      BIT            NULL,
    [FollowUpDate]           DATETIME       NULL,
    [Note]                   NVARCHAR (MAX) NULL,
    [AttendanceDate]         DATETIME       NULL,
    [FollowUpAttendanceDate] DATETIME       NULL,
    CONSTRAINT [PK_A1_InvoiceSessionDetail] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_A1_InvoiceSessionDetail_AttendanceDate]
    ON [dbo].[A1_InvoiceSessionDetail]([AttendanceDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_InvoiceSessionDetail_Code]
    ON [dbo].[A1_InvoiceSessionDetail]([Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_InvoiceSessionDetail_ExpectedDate]
    ON [dbo].[A1_InvoiceSessionDetail]([ExpectedDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_InvoiceSessionDetail_FollowUpAttendanceDate]
    ON [dbo].[A1_InvoiceSessionDetail]([FollowUpAttendanceDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_InvoiceSessionDetail_FollowUpDate]
    ON [dbo].[A1_InvoiceSessionDetail]([FollowUpDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_InvoiceSessionDetail_FollowUpExpectedDate]
    ON [dbo].[A1_InvoiceSessionDetail]([FollowUpExpectedDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_InvoiceSessionDetail_HasFollowUp]
    ON [dbo].[A1_InvoiceSessionDetail]([HasFollowUp] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_InvoiceSessionDetail_InvoiceSessionID]
    ON [dbo].[A1_InvoiceSessionDetail]([InvoiceSessionID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_InvoiceSessionDetail_SessionDate]
    ON [dbo].[A1_InvoiceSessionDetail]([SessionDate] ASC);


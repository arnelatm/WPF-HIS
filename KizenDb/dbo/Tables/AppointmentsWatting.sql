CREATE TABLE [dbo].[AppointmentsWatting] (
    [ID]                   INT            IDENTITY (1, 1) NOT NULL,
    [PatName]              NVARCHAR (255) NULL,
    [PatID]                INT            NULL,
    [DrName]               NVARCHAR (255) NULL,
    [PatOust]              BIT            NULL,
    [DrID]                 INT            NULL,
    [Clinic]               NVARCHAR (255) NULL,
    [RegUser]              NVARCHAR (255) NULL,
    [RegDate]              DATETIME       NULL,
    [RegTime]              TIME (0)       NULL,
    [EntredEnab]           BIT            NULL,
    [Note]                 NVARCHAR (MAX) NULL,
    [Order]                INT            NULL,
    [Type]                 NVARCHAR (255) NULL,
    [AppointmentID]        INT            NULL,
    [CallPatientEnab]      BIT            NULL,
    [CallPatientDateTime]  DATETIME       NULL,
    [CallPatientExecuted]  BIT            NULL,
    [EntredTime]           TIME (0)       NULL,
    [FinishTime]           TIME (0)       NULL,
    [FinishDateTime]       DATETIME       NULL,
    [EntredDateTime]       DATETIME       NULL,
    [WaitingMinutes]       INT            NULL,
    [WaitingTxt]           NVARCHAR (255) NULL,
    [Code]                 NVARCHAR (50)  NULL,
    [InsuranceCompanyCode] NVARCHAR (255) NULL,
    CONSTRAINT [PK_AppointmentsWatting] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_AppointmentsWatting_PatID]
    ON [dbo].[AppointmentsWatting]([PatID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AppointmentsWatting_RegDate]
    ON [dbo].[AppointmentsWatting]([RegDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AppointmentsWatting_CallPatientDateTime]
    ON [dbo].[AppointmentsWatting]([CallPatientDateTime] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AppointmentsWatting_CallPatientEnab]
    ON [dbo].[AppointmentsWatting]([CallPatientEnab] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AppointmentsWatting_Clinic]
    ON [dbo].[AppointmentsWatting]([Clinic] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AppointmentsWatting_EntredDateTime]
    ON [dbo].[AppointmentsWatting]([EntredDateTime] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AppointmentsWatting_FinishDateTime]
    ON [dbo].[AppointmentsWatting]([FinishDateTime] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AppointmentsWatting_EntredEnab]
    ON [dbo].[AppointmentsWatting]([EntredEnab] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AppointmentsWatting_DrID]
    ON [dbo].[AppointmentsWatting]([DrID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AppointmentsWatting_DrName]
    ON [dbo].[AppointmentsWatting]([DrName] ASC);


CREATE TABLE [dbo].[Empvisa] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [EmpID]          INT            NULL,
    [EmpName]        NVARCHAR (50)  NULL,
    [StartDate]      DATE           NULL,
    [EndDate]        DATE           NULL,
    [StartDateHijri] NVARCHAR (50)  NULL,
    [EndDateHijri]   NVARCHAR (50)  NULL,
    [DurationDays]   INT            NULL,
    [BackDate]       DATE           NULL,
    [BackEnab]       BIT            NULL,
    [VisaNumber]     NVARCHAR (50)  NULL,
    [Note]           NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Empvisa] PRIMARY KEY CLUSTERED ([ID] ASC)
);


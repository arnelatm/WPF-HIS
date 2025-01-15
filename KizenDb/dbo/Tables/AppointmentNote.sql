CREATE TABLE [dbo].[AppointmentNote] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (50)  NULL,
    [Descryption] NVARCHAR (MAX) NULL,
    [Date]        DATE           NULL,
    [Time]        DATETIME       NULL,
    [UserName]    NVARCHAR (50)  NULL,
    CONSTRAINT [PK_C1_AppointmentNote] PRIMARY KEY CLUSTERED ([ID] ASC)
);


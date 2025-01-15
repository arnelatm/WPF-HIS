CREATE TABLE [dbo].[AppointmentsCheckList] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [CustID]       INT            NULL,
    [DateTime]     DATETIME       NULL,
    [Note]         NVARCHAR (MAX) NULL,
    [SpecialtieID] INT            NULL,
    [Done]         BIT            NULL,
    [UserName]     NVARCHAR (255) NULL,
    [Number]       INT            NULL,
    [AppID]        INT            NULL,
    CONSTRAINT [PK_AppointmentsCheckList] PRIMARY KEY CLUSTERED ([ID] ASC)
);


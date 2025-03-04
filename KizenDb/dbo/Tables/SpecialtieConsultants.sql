CREATE TABLE [dbo].[SpecialtieConsultants] (
    [ID]                   INT            IDENTITY (1, 1) NOT NULL,
    [SpecialtieID]         INT            NULL,
    [InsuranceCompanyCode] NVARCHAR (255) NULL,
    [Code]                 NVARCHAR (255) NULL,
    [ReviewCode]           NVARCHAR (255) NULL,
    [IsInsurance]          BIT            NULL,
    [Days]                 INT            NULL,
    [LimitNumbers]         INT            NULL,
    [Customize]            BIT            NULL,
    [DoctorIds]            NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_SpecialtieConsultants] PRIMARY KEY CLUSTERED ([ID] ASC)
);


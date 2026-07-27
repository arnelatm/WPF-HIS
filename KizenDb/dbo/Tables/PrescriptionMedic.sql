CREATE TABLE [dbo].[PrescriptionMedic] (
    [ID]                             INT             IDENTITY (1, 1) NOT NULL,
    [Date]                           DATE            NULL,
    [Time]                           TIME (0)        NULL,
    [PresID]                         INT             NULL,
    [User]                           NVARCHAR (MAX)  NULL,
    [Code]                           NVARCHAR (255)  NULL,
    [SourceCode]                     NVARCHAR (255)  NULL,
    [Name]                           NVARCHAR (MAX)  NULL,
    [ScientificName]                 NVARCHAR (MAX)  NULL,
    [Price]                          DECIMAL (18, 2) NULL,
    [Amount]                         NVARCHAR (255)  NULL,
    [Note]                           NVARCHAR (MAX)  NULL,
    [Count]                          DECIMAL (18, 2) NULL,
    [InsuranceApprovalType]          NVARCHAR (4)    NULL,
    [InsuranceApprovalID]            INT             NULL,
    [Duration]                       NVARCHAR (255)  NULL,
    [Unit]                           NVARCHAR (50)   NULL,
    [Frequency]                      NVARCHAR (50)   NULL,
    [ICD10]                          NVARCHAR (50)   NULL,
    [DrugSelectionReason]            NVARCHAR (255)  NULL,
    [InsuranceApprovedAmountWithVat] DECIMAL (18, 2) NULL,
    [Morphology]                     NVARCHAR (50)   NULL,
    [IsMaternity]                    BIT             NULL,
    [LastMenstrualPeriod]            DATETIME        NULL,
    CONSTRAINT [PK_PrescriptionMedic] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PrescriptionMedic_InsuranceApproval]
    ON [dbo].[PrescriptionMedic]([InsuranceApprovalID] ASC, [InsuranceApprovalType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PrescriptionMedic_PresID]
    ON [dbo].[PrescriptionMedic]([PresID] ASC);


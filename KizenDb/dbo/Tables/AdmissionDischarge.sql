CREATE TABLE [dbo].[AdmissionDischarge] (
    [ID]                     INT            IDENTITY (1, 1) NOT NULL,
    [SourceReferralType]     INT            NULL,
    [SourceReferralOtherTxt] NVARCHAR (255) NULL,
    [InternalTxt]            NVARCHAR (255) NULL,
    [AdmissionDateTime]      DATETIME       NULL,
    [PatientConditionType]   INT            NULL,
    [Secretariats]           NVARCHAR (255) NULL,
    [TreatmentEligibility]   NVARCHAR (255) NULL,
    [ReceiptNo]              NVARCHAR (255) NULL,
    [EntryDate]              DATE           NULL,
    [ICDNo]                  NVARCHAR (255) NULL,
    [ProvisionalDiagnosis]   NVARCHAR (255) NULL,
    [FinalDiagnosis]         NVARCHAR (255) NULL,
    [OtherDiagnosis]         NVARCHAR (255) NULL,
    [SurgicalOperation]      NVARCHAR (255) NULL,
    [AnesthesiaType]         INT            NULL,
    [AnesthesiaTxt]          NVARCHAR (255) NULL,
    [DischargeDateTime]      DATETIME       NULL,
    [DischargeConditionType] INT            NULL,
    [DischargeConditionTxt]  NVARCHAR (255) NULL,
    [DrName]                 NVARCHAR (255) NULL,
    [DrID]                   INT            NULL,
    [ConsultantName]         NVARCHAR (255) NULL,
    [PatID]                  INT            NULL,
    [PatName]                NVARCHAR (255) NULL,
    [DateTime]               DATETIME       NULL,
    [UserName]               NVARCHAR (255) NULL,
    [InsuranceApprovalType]  NVARCHAR (4)   NULL,
    [InsuranceApprovalID]    INT            NULL,
    [OperativeNote]          NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AdmissionDischargeRep] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_AdmissionDischarge_InsuranceApproval]
    ON [dbo].[AdmissionDischarge]([InsuranceApprovalID] ASC, [InsuranceApprovalType] ASC);


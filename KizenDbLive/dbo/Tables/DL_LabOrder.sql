CREATE TABLE [dbo].[DL_LabOrder] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [DateTime]        DATETIME       NULL,
    [DeliverDateTime] DATETIME       NULL,
    [UserID]          INT            NULL,
    [UserName]        NVARCHAR (255) NULL,
    [PatID]           INT            NULL,
    [PatName]         NVARCHAR (255) NULL,
    [DrID]            INT            NULL,
    [DrName]          NVARCHAR (255) NULL,
    [ColorChartType]  NVARCHAR (MAX) NULL,
    [ColorType]       NVARCHAR (MAX) NULL,
    [LabName]         NVARCHAR (255) NULL,
    [LabOrderNum]     NVARCHAR (50)  NULL,
    [LabInvoiceNum]   NVARCHAR (255) NULL,
    [Note]            NVARCHAR (MAX) NULL,
    [RecivedDate]     DATETIME       NULL,
    [RecivedUser]     NVARCHAR (255) NULL,
    CONSTRAINT [PK_DL_LabOrder] PRIMARY KEY CLUSTERED ([ID] ASC)
);


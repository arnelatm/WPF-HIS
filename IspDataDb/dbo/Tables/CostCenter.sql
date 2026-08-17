CREATE TABLE [dbo].[CostCenter] (
    [IDNo]              SMALLINT      NOT NULL,
    [CostCenterCode]    VARCHAR (5)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [CostCenterName]    VARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ParentIdNo]        SMALLINT      NULL,
    [ProfitCenterIdNo]  SMALLINT      NULL,
    [CostCenterNameAra] NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Notes]             VARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Doctor]            VARCHAR (20)  NULL,
    [DateTimeStamp]     ROWVERSION    NULL,
    CONSTRAINT [PK_CostCenterIdNo] PRIMARY KEY CLUSTERED ([IDNo] ASC)
);


GO

CREATE NONCLUSTERED INDEX [IX_CostCenterCode]
    ON [dbo].[CostCenter]([CostCenterCode] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_CostCenterName]
    ON [dbo].[CostCenter]([CostCenterName] ASC);


GO

CREATE NONCLUSTERED INDEX [IX_CostCenterNameAra]
    ON [dbo].[CostCenter]([CostCenterNameAra] ASC);


GO


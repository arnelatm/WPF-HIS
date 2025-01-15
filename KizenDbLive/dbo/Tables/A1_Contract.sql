CREATE TABLE [dbo].[A1_Contract] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [CreatedtDateTime] DATETIME       NULL,
    [ContractDateTime] DATETIME       NULL,
    [CustID]           INT            NULL,
    [UserID]           INT            NULL,
    [UserName]         NVARCHAR (255) NULL,
    [DrID]             INT            NULL,
    [ClinicID]         INT            NULL,
    [Note]             NVARCHAR (MAX) NULL,
    [ContractText]     NVARCHAR (MAX) NULL,
    [IsCancelCredit]   BIT            NULL,
    [Disabled]         BIT            NULL,
    CONSTRAINT [PK_A1_Contract] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Contract_ClinicID]
    ON [dbo].[A1_Contract]([ClinicID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Contract_ContractDateTime]
    ON [dbo].[A1_Contract]([ContractDateTime] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Contract_ContractDateTime_Desc]
    ON [dbo].[A1_Contract]([ContractDateTime] DESC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Contract_CreatedtDateTime]
    ON [dbo].[A1_Contract]([CreatedtDateTime] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Contract_CreatedtDateTime_Dec]
    ON [dbo].[A1_Contract]([CreatedtDateTime] DESC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Contract_CustID]
    ON [dbo].[A1_Contract]([CustID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Contract_Disabled]
    ON [dbo].[A1_Contract]([Disabled] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Contract_DrID]
    ON [dbo].[A1_Contract]([DrID] ASC);


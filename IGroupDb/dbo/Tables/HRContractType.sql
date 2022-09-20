CREATE TABLE [dbo].[HRContractType] (
    [ContractID]        VARCHAR (15)  NOT NULL,
    [Description]       VARCHAR (50)  NOT NULL,
    [DescriptionArabic] NVARCHAR (50) NULL,
    [Activate]          INT           NULL,
    [Remarks]           VARCHAR (100) NULL
);


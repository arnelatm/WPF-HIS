CREATE TABLE [dbo].[A1_WorksVAT] (
    [ID]             INT             IDENTITY (1, 1) NOT NULL,
    [GroupWorkCode]  NVARCHAR (MAX)  NULL,
    [VATPer]         DECIMAL (18, 2) NULL,
    [VarDescPer]     DECIMAL (18, 2) NULL,
    [IsNotExemption] BIT             NULL,
    CONSTRAINT [PK_A1_WorksVAT] PRIMARY KEY CLUSTERED ([ID] ASC)
);


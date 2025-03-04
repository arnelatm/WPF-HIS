CREATE TABLE [dbo].[A1_PaymentMethod] (
    [ID]               INT             IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (255)  NOT NULL,
    [OperationPercent] DECIMAL (19, 4) NULL,
    [OperationAmount]  DECIMAL (19, 4) NULL,
    CONSTRAINT [PK_A1_PaymentMethod] PRIMARY KEY CLUSTERED ([ID] ASC)
);


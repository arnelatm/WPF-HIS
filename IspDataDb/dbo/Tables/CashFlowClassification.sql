CREATE TABLE [dbo].[CashFlowClassification] (
    [Code]         VARCHAR (40)    NOT NULL,
    [Section]      VARCHAR (20)    NOT NULL,
    [Name]         NVARCHAR (100)  NOT NULL,
    [NameAra]      NVARCHAR (100)  NULL,
    [DisplayOrder] SMALLINT        CONSTRAINT [DF_CashFlowClassification_DisplayOrder] DEFAULT ((0)) NOT NULL,
    [IsActive]     BIT             CONSTRAINT [DF_CashFlowClassification_IsActive] DEFAULT ((1)) NOT NULL,
    [Notes]        NVARCHAR (500)  NULL,
    CONSTRAINT [PK_CashFlowClassification] PRIMARY KEY CLUSTERED ([Code] ASC),
    CONSTRAINT [CK_CashFlowClassification_Section] CHECK ([Section] IN ('Operating', 'Investing', 'Financing', 'Excluded', 'Review'))
);

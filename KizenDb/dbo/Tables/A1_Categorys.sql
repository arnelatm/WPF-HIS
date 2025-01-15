CREATE TABLE [dbo].[A1_Categorys] (
    [ID]                    INT            IDENTITY (1, 1) NOT NULL,
    [Name]                  NVARCHAR (MAX) NULL,
    [Parent]                NVARCHAR (MAX) NULL,
    [IsService]             BIT            NULL,
    [Code]                  NVARCHAR (255) NULL,
    [IsAnalyses]            BIT            NULL,
    [CodeLink]              NVARCHAR (255) NULL,
    [IsInsurance]           BIT            NULL,
    [IsDrug]                BIT            NULL,
    [RootParent]            NVARCHAR (MAX) NULL,
    [IsHidePrush]           BIT            NULL,
    [IsHideSell]            BIT            NULL,
    [Sort]                  INT            NULL,
    [Specialties]           NVARCHAR (MAX) NULL,
    [ShowCashEvenInsurance] BIT            NULL,
    [IsStore]               BIT            NULL,
    [IsEmergency]           BIT            NULL,
    CONSTRAINT [PK_A1_categorys] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Categorys_Code]
    ON [dbo].[A1_Categorys]([Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Categorys_CodeLink]
    ON [dbo].[A1_Categorys]([CodeLink] ASC);


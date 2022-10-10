CREATE TABLE [dbo].[RevCostCenter] (
    [IDNo]                 SMALLINT      IDENTITY (1, 1) NOT NULL,
    [RevCostCenterCode]    VARCHAR (5)   NOT NULL,
    [RevCostCenterName]    VARCHAR (50)  NOT NULL,
    [RevCostCenterNameAra] NVARCHAR (50) NOT NULL,
    [ParentIdNo]           SMALLINT      NULL,
    [RCType]               CHAR (1)      NOT NULL,
    [Notes]                VARCHAR (255) NULL,
    [DateTimeStamp]        ROWVERSION    NULL,
    CONSTRAINT [PK_RevCostCenterIdNo] PRIMARY KEY CLUSTERED ([IDNo] ASC)
);


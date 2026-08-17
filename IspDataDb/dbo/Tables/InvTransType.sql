CREATE TABLE [dbo].[InvTransType] (
    [IdNo]                SMALLINT       IDENTITY (1, 1) NOT NULL,
    [BranchIdNo]          SMALLINT       NULL,
    [InvTransTypeCode]    VARCHAR (10)   NULL,
    [InvTransTypeName]    VARCHAR (50)   NULL,
    [InvTransTypeNameAra] NVARCHAR (50)  NULL,
    [InventoryAction]     CHAR (1)       NULL,
    [AccountIdNo]         INT            NULL,
    [Active]              BIT            NULL,
    [Notes]               NVARCHAR (100) NULL,
    CONSTRAINT [PK_InventoryTransaction] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_InvTransTypeBranchIdNoCode]
    ON [dbo].[InvTransType]([BranchIdNo] ASC, [InvTransTypeCode] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_InvTransTypeBranchIdNoName]
    ON [dbo].[InvTransType]([BranchIdNo] ASC, [InvTransTypeName] ASC);


GO


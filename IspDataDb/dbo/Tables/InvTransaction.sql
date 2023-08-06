CREATE TABLE [dbo].[InvTransaction] (
    [IdNo]             INT            IDENTITY (1, 1) NOT NULL,
    [BranchIdNo]       TINYINT        NOT NULL,
    [ReferenceNo]      VARCHAR (10)   NULL,
    [TransactionDate]  DATE           NULL,
    [InvTransTypeIdNo] TINYINT        NULL,
    [WarehouseIdNo]    SMALLINT       NOT NULL,
    [WarehouseToIdNo]  SMALLINT       NOT NULL,
    [Amount]           DECIMAL (9, 2) NULL,
    [Cancelled]        BIT            NULL,
    [Notes]            NVARCHAR (100) NOT NULL,
    [Posted]           BIT            NULL,
    [DateCreated]      DATE           CONSTRAINT [DF_InvTransaction_DateCreated] DEFAULT (getdate()) NULL,
    [UserIdNo]         SMALLINT       NOT NULL,
    [DateTimeStamp]    ROWVERSION     NULL,
    CONSTRAINT [PK_InvTransaction] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);






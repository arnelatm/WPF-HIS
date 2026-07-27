CREATE TABLE [dbo].[A1_StoreRequest] (
    [ID]                INT            IDENTITY (1, 1) NOT NULL,
    [EmpID]             INT            NULL,
    [UserID]            INT            NULL,
    [UserName]          NVARCHAR (255) NULL,
    [UserIDLastEdit]    INT            NULL,
    [UserNameLastEdit]  NVARCHAR (MAX) NULL,
    [DateTime]          DATETIME       NULL,
    [DateTimeLastEdit]  DATETIME       NULL,
    [Priority]          INT            NULL,
    [Note1]             NVARCHAR (MAX) NULL,
    [Note2]             NVARCHAR (MAX) NULL,
    [FavoriteSupplier]  INT            NULL,
    [OrderStatu]        INT            NULL,
    [FromStore]         INT            NULL,
    [ToStore]           INT            NULL,
    [Type]              INT            NULL,
    [FromDrID]          INT            NULL,
    [FromClinicID]      INT            NULL,
    [ExpenseCategoryId] INT            NULL,
    [TempStoreEnb]      BIT            NULL,
    [TempStore]         INT            NULL,
    [ReceivedEnb]       BIT            NULL,
    [ReceivedDateTime]  DATETIME       NULL,
    [ReceivedUserId]    INT            NULL,
    [ReceivedUserName]  NVARCHAR (255) NULL,
    [ParentId]          INT            NULL,
    CONSTRAINT [PK_A1_StoreRequest] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_A1_StoreRequest_FromStore]
    ON [dbo].[A1_StoreRequest]([FromStore] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_StoreRequest_ToStore]
    ON [dbo].[A1_StoreRequest]([ToStore] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_StoreRequest_DateTime]
    ON [dbo].[A1_StoreRequest]([DateTime] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_StoreRequest_OrderStatu]
    ON [dbo].[A1_StoreRequest]([OrderStatu] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_StoreRequest_Type]
    ON [dbo].[A1_StoreRequest]([Type] ASC);


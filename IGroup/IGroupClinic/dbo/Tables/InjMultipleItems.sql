CREATE TABLE [dbo].[InjMultipleItems] (
    [IdNumber]  INT          IDENTITY (1, 1) NOT NULL,
    [ServiceID] VARCHAR (15) NULL,
    [Item_Code] VARCHAR (15) NULL,
    CONSTRAINT [PK_InjMultipleItems] PRIMARY KEY CLUSTERED ([IdNumber] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_InjMultipleItems]
    ON [dbo].[InjMultipleItems]([Item_Code] ASC, [ServiceID] ASC);


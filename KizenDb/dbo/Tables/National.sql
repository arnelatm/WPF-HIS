CREATE TABLE [dbo].[National] (
    [NatID]        INT            IDENTITY (1, 1) NOT NULL,
    [NatName]      NVARCHAR (255) NULL,
    [CustomField1] NVARCHAR (255) NULL,
    [CustomField2] NVARCHAR (255) NULL,
    [CustomField3] NVARCHAR (255) NULL,
    [CustomField4] NVARCHAR (255) NULL,
    [CustomField5] NVARCHAR (255) NULL,
    CONSTRAINT [PK_National] PRIMARY KEY CLUSTERED ([NatID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_National_NatName]
    ON [dbo].[National]([NatName] ASC);


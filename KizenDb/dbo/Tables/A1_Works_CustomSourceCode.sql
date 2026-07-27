CREATE TABLE [dbo].[A1_Works_CustomSourceCode] (
    [ID]     INT            IDENTITY (1, 1) NOT NULL,
    [WorkID] INT            NULL,
    [Code]   NVARCHAR (255) NULL,
    CONSTRAINT [PK_A1_Works_CustomSourceCode] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Works_CustomSourceCode_WorkID]
    ON [dbo].[A1_Works_CustomSourceCode]([WorkID] ASC)
    INCLUDE([Code]);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Works_CustomSourceCode_Code]
    ON [dbo].[A1_Works_CustomSourceCode]([Code] ASC)
    INCLUDE([WorkID]);


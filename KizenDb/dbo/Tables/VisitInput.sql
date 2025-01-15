CREATE TABLE [dbo].[VisitInput] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [VisitID]     INT            NULL,
    [VisitTypeID] INT            NULL,
    [Txt]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_VisitInput] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_VisitInput_VisitID]
    ON [dbo].[VisitInput]([VisitID] ASC)
    INCLUDE([VisitTypeID], [Txt]);


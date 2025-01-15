CREATE TABLE [dbo].[KS_ValuesByType] (
    [ID]     INT            IDENTITY (1, 1) NOT NULL,
    [Type]   INT            NULL,
    [Value1] NVARCHAR (MAX) NULL,
    [Value2] NVARCHAR (MAX) NULL,
    [Value3] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_KS_ValuesByType] PRIMARY KEY CLUSTERED ([ID] ASC)
);


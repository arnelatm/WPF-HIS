CREATE TABLE [dbo].[FeedBack] (
    [ID]     INT            IDENTITY (1, 1) NOT NULL,
    [UserID] INT            NULL,
    [Type]   NVARCHAR (50)  NULL,
    [Statu]  INT            NULL,
    [Txt]    NVARCHAR (MAX) NULL,
    [Date]   DATE           NULL,
    [Time]   TIME (0)       NULL,
    CONSTRAINT [PK_FeedBack] PRIMARY KEY CLUSTERED ([ID] ASC)
);


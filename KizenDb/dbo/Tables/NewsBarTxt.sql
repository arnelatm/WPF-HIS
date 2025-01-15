CREATE TABLE [dbo].[NewsBarTxt] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Type]         NVARCHAR (MAX) NULL,
    [TypeLatin]    NVARCHAR (MAX) NULL,
    [Txt]          NVARCHAR (MAX) NULL,
    [TxtLatin]     NVARCHAR (MAX) NULL,
    [Target]       NVARCHAR (MAX) NULL,
    [IsEnabled]    BIT            NULL,
    [LastEditDate] DATETIME       NULL,
    CONSTRAINT [PK_NewsBarTxt] PRIMARY KEY CLUSTERED ([ID] ASC)
);


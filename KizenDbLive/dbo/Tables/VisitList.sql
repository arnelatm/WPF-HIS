CREATE TABLE [dbo].[VisitList] (
    [ID]                    INT            IDENTITY (1, 1) NOT NULL,
    [Name]                  NVARCHAR (MAX) NULL,
    [LatinName]             NVARCHAR (MAX) NULL,
    [Note]                  NVARCHAR (MAX) NULL,
    [Icon]                  IMAGE          NULL,
    [Specialization]        NVARCHAR (MAX) NULL,
    [Disabled]              BIT            NULL,
    [PaintingImage]         IMAGE          NULL,
    [PaintingImageMode]     INT            NULL,
    [PaintingImageFontSize] INT            NULL,
    CONSTRAINT [PK_VisitList] PRIMARY KEY CLUSTERED ([ID] ASC)
);


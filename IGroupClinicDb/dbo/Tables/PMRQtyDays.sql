CREATE TABLE [dbo].[PMRQtyDays] (
    [id]                 VARCHAR (15) NULL,
    [DescriptionEnglish] VARCHAR (25) NULL,
    [DescriptionArabic]  VARCHAR (25) NULL,
    [IdNo]               INT          IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_PMRQtyDays] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);




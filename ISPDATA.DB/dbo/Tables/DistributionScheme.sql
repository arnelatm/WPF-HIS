CREATE TABLE [dbo].[DistributionScheme] (
    [IdNo]                      INT            IDENTITY (1, 1) NOT NULL,
    [DistributionSchemeCode]    VARCHAR (5)    COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [DistributionSchemeName]    VARCHAR (50)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [DistributionSchemeNameAra] NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ValidityStartDate]         DATE           NOT NULL,
    [ValidityEndDate]           DATE           NOT NULL,
    [Notes]                     NVARCHAR (256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DateTimeStamp]             ROWVERSION     NOT NULL,
    CONSTRAINT [PK_DistributionScheme] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_DistributionScheme]
    ON [dbo].[DistributionScheme]([IdNo] ASC);


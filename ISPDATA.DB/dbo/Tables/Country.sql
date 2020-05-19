CREATE TABLE [dbo].[Country] (
    [IDNo]           INT            IDENTITY (1, 1) NOT NULL,
    [ISOA2]          VARCHAR (2)    CONSTRAINT [DF__Countries__count__2A4B4B5E] DEFAULT ('') NOT NULL,
    [CountryName]    VARCHAR (100)  CONSTRAINT [DF__Countries__count__2B3F6F97] DEFAULT ('') NOT NULL,
    [CountryNameAra] NVARCHAR (200) CONSTRAINT [DF__Countries__count__2C3393D0] DEFAULT ('') NOT NULL,
    [Nationality]    VARCHAR (100)  CONSTRAINT [DF__Countries__count__2D27B809] DEFAULT ('') NOT NULL,
    [NationalityAra] NVARCHAR (200) CONSTRAINT [DF__Countries__count__2E1BDC42] DEFAULT ('') NOT NULL,
    [Flag32]         VARCHAR (256)  NULL,
    [Flag128]        VARCHAR (256)  NULL,
    [ISOA3]          VARCHAR (3)    NULL,
    [ISON]           INT            NULL,
    [PhoneCode]      VARCHAR (4)    NULL,
    [DateTimeStamp]  ROWVERSION     NULL,
    CONSTRAINT [PK_CountryIDNo] PRIMARY KEY CLUSTERED ([IDNo] ASC),
    CONSTRAINT [IX_ISOA2] UNIQUE NONCLUSTERED ([ISOA2] ASC),
    CONSTRAINT [IX_NameAra] UNIQUE NONCLUSTERED ([IDNo] ASC),
    CONSTRAINT [IX_NameEng] UNIQUE NONCLUSTERED ([CountryName] ASC)
);


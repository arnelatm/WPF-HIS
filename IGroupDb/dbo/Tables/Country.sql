CREATE TABLE [dbo].[Country] (
    [CountryID]      INT           IDENTITY (1, 1) NOT NULL,
    [ISOA2]          VARCHAR (2)   CONSTRAINT [DF__Countries__count__2A4B4B5E] DEFAULT ('') NOT NULL,
    [NameEng]        VARCHAR (100) CONSTRAINT [DF__Countries__count__2B3F6F97] DEFAULT ('') NOT NULL,
    [NameAra]        VARCHAR (100) CONSTRAINT [DF__Countries__count__2C3393D0] DEFAULT ('') NOT NULL,
    [NationalityEng] VARCHAR (100) CONSTRAINT [DF__Countries__count__2D27B809] DEFAULT ('') NOT NULL,
    [NationalityAra] VARCHAR (100) CONSTRAINT [DF__Countries__count__2E1BDC42] DEFAULT ('') NOT NULL,
    [Flag32]         VARCHAR (256) NULL,
    [Flag128]        VARCHAR (256) NULL,
    [ISOA3]          VARCHAR (3)   NULL,
    [ISON]           INT           NULL,
    [PhoneCode]      VARCHAR (4)   NULL,
    CONSTRAINT [PK__Countrie__3436E9A4153289ED] PRIMARY KEY CLUSTERED ([CountryID] ASC)
);


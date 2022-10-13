CREATE TABLE [dbo].[countryf] (
    [IdNo]          INT             IDENTITY (1, 1) NOT NULL,
    [enabled]       TINYINT         CONSTRAINT [DF__countryf__enable__44FF419A] DEFAULT ('1') NOT NULL,
    [code3l]        VARCHAR (3)     COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [code2l]        VARCHAR (2)     COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [name]          VARCHAR (64)    COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [name_official] VARCHAR (128)   COLLATE SQL_Latin1_General_CP1_CI_AS CONSTRAINT [DF__countryf__name_o__45F365D3] DEFAULT (NULL) NULL,
    [flag_32]       VARCHAR (255)   COLLATE SQL_Latin1_General_CP1_CI_AS CONSTRAINT [DF__countryf__flag_3__46E78A0C] DEFAULT (NULL) NULL,
    [flag_128]      VARCHAR (255)   COLLATE SQL_Latin1_General_CP1_CI_AS CONSTRAINT [DF__countryf__flag_1__47DBAE45] DEFAULT (NULL) NULL,
    [latitude]      DECIMAL (10, 8) CONSTRAINT [DF__countryf__latitu__48CFD27E] DEFAULT (NULL) NULL,
    [longitude]     DECIMAL (11, 8) CONSTRAINT [DF__countryf__longit__49C3F6B7] DEFAULT (NULL) NULL,
    [flag032]       IMAGE           NULL,
    [flag123]       IMAGE           NULL,
    [zoom]          TINYINT         CONSTRAINT [DF__countryf__zoom__4AB81AF0] DEFAULT (NULL) NULL,
    CONSTRAINT [PK_countryf] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);




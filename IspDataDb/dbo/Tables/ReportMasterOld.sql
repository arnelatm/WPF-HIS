CREATE TABLE [dbo].[ReportMasterOld] (
    [IdNo]         INT          IDENTITY (1, 1) NOT NULL,
    [ReportID]     VARCHAR (15) NOT NULL,
    [Department]   VARCHAR (50) NOT NULL,
    [Description]  VARCHAR (50) NOT NULL,
    [ReportOrder]  NUMERIC (4)  NULL,
    [TabOrder]     NUMERIC (4)  NULL,
    [ReportSource] VARCHAR (10) NULL,
    [Activate]     VARCHAR (1)  CONSTRAINT [DF__ReportMas__Activ__2AAB3E11] DEFAULT ('N') NULL,
    CONSTRAINT [PK_ReportMaster] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


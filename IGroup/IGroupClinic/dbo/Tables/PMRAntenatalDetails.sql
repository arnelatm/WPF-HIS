CREATE TABLE [dbo].[PMRAntenatalDetails] (
    [Group_Key]        BIGINT       NOT NULL,
    [Series]           CHAR (2)     DEFAULT ('B') NULL,
    [RegistrationNo]   NUMERIC (10) NOT NULL,
    [doctorID]         VARCHAR (15) NOT NULL,
    [TransDateEnglish] VARCHAR (10) NULL,
    [RowNBR]           NUMERIC (5)  DEFAULT (1) NULL,
    [PregnancyWeeks]   VARCHAR (15) NULL,
    [FundalHeight]     VARCHAR (15) NULL,
    [PresPosition]     VARCHAR (15) NULL,
    [Engaged]          VARCHAR (15) NULL,
    [FM_Fhs]           VARCHAR (15) NULL,
    [hb]               VARCHAR (15) NULL,
    [Sugar]            VARCHAR (15) NULL,
    [Albumin]          VARCHAR (15) NULL,
    [bp]               VARCHAR (15) NULL,
    [PtientWeight]     VARCHAR (15) NULL,
    [Oedema]           VARCHAR (15) NULL,
    [NextVisit]        VARCHAR (10) NULL,
    [FitNess]          CHAR (1)     DEFAULT (1) NULL,
    [USGKey]           BIGINT       NULL,
    [Remarks]          NTEXT        NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRAntenatalDetails]
    ON [dbo].[PMRAntenatalDetails]([Series] ASC, [RegistrationNo] ASC, [doctorID] ASC, [RowNBR] ASC);


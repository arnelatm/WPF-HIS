CREATE TABLE [dbo].[PMRAntenatalGroup] (
    [Trans_Key]        BIGINT       NOT NULL,
    [PatientType]      CHAR (15)    DEFAULT ('Insurance') NULL,
    [TransNBR]         NUMERIC (10) NOT NULL,
    [Series]           CHAR (2)     DEFAULT ('CR') NULL,
    [RegistrationNo]   NUMERIC (10) NOT NULL,
    [TransDateEnglish] VARCHAR (10) NULL,
    [DoctorID]         VARCHAR (15) NOT NULL,
    [BloodGroup]       VARCHAR (15) NULL,
    [Hus_bg]           VARCHAR (15) NULL,
    [StillBorn]        VARCHAR (15) NULL,
    [lmp]              VARCHAR (15) NULL,
    [Heart]            VARCHAR (15) NULL,
    [Lungs]            VARCHAR (15) NULL,
    [Edd]              VARCHAR (10) NULL,
    [GestationWeight]  VARCHAR (15) NULL,
    [Height]           VARCHAR (15) NULL,
    [Breast]           VARCHAR (15) NULL,
    [Thyroid]          VARCHAR (15) NULL,
    [Lymphnodes]       VARCHAR (15) NULL,
    [LastDelivery]     VARCHAR (25) NULL,
    [Gravida]          VARCHAR (15) NULL,
    [Term]             VARCHAR (15) NULL,
    [Preterm]          VARCHAR (15) NULL,
    [Abortion]         VARCHAR (15) NULL,
    [LivingChildren]   VARCHAR (15) NULL,
    [deliveries]       VARCHAR (15) NULL,
    [Nsvd]             CHAR (1)     DEFAULT ('0') NULL,
    [Lscs]             CHAR (1)     DEFAULT ('0') NULL,
    [PastHistory]      NTEXT        NULL,
    [Tt1]              VARCHAR (10) NULL,
    [Tt2]              VARCHAR (10) NULL,
    [PelvicAssess]     NTEXT        NULL,
    [UserID]           VARCHAR (15) NULL,
    [Create_Date]      DATETIME     DEFAULT (getdate()) NULL,
    [MachineID]        VARCHAR (20) DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRAntenatalGroup]
    ON [dbo].[PMRAntenatalGroup]([Series] ASC, [RegistrationNo] ASC, [DoctorID] ASC);


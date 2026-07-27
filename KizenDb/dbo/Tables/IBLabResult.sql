CREATE TABLE [dbo].[IBLabResult] (
    [IdNo]              INT          IDENTITY (1, 1) NOT NULL,
    [Trans_Key]         NUMERIC (10) NOT NULL,
    [PassportNumber]    VARCHAR (15) NULL,
    [Clinical]          BIT          NULL,
    [Xray]              BIT          NULL,
    [TBSputum]          BIT          NULL,
    [HIVEliza]          BIT          NULL,
    [HCVEliza]          BIT          NULL,
    [HBSAgEliza]        BIT          NULL,
    [Malaria]           BIT          NULL,
    [VDRL]              BIT          NULL,
    [Widal]             BIT          NULL,
    [Pregnancy]         BIT          NULL,
    [BilharziasisUrine] BIT          NULL,
    [BilharziasisStool] BIT          NULL,
    [Shigella]          BIT          NULL,
    [Cholera]           BIT          NULL,
    CONSTRAINT [PK_IBLabSampleResults] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


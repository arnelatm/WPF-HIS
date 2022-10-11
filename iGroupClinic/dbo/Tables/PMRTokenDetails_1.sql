CREATE TABLE [dbo].[PMRTokenDetails] (
    [Trans_Key]      BIGINT       NOT NULL,
    [PMRDateEnglish] VARCHAR (10) NULL,
    [Series]         VARCHAR (2)  NOT NULL,
    [RegistrationNo] NUMERIC (10) NOT NULL,
    [TokenNo]        NUMERIC (10) DEFAULT (0) NULL,
    [DoctorID]       VARCHAR (10) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRTokenDetails]
    ON [dbo].[PMRTokenDetails]([Trans_Key] ASC);


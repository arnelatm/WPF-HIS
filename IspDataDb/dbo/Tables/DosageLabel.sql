CREATE TABLE [dbo].[DosageLabel] (
    [IdNo]         INT          IDENTITY (1, 1) NOT NULL,
    [ComputerName] VARCHAR (50) NULL,
    [PatientName]  VARCHAR (50) NULL,
    [FileNo]       INT          NULL,
    [Age]          VARCHAR (5)  NULL,
    [AgeYMD]       CHAR (1)     NULL,
    [Gender]       CHAR (1)     NULL,
    [DoctorsName]  VARCHAR (50) NULL,
    CONSTRAINT [PK_DosageLabel] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);






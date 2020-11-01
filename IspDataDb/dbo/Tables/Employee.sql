CREATE TABLE [dbo].[Employee] (
    [IdNo]                INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeCode]        VARCHAR (10)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Title]               VARCHAR (25)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [EmployeeName]        VARCHAR (75)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [EmployeeNameAra]     NVARCHAR (75) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Gender]              VARCHAR (1)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [BirthDate]           DATE          NULL,
    [MaritalStatus]       CHAR (1)      COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [NationalityCode]     CHAR (2)      COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [NationalityId]       VARCHAR (15)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [ReligionIdNo]        INT           NULL,
    [ReligionId]          VARCHAR (15)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [NationalIdNo]        VARCHAR (10)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Street]              NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [District]            NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [TownCity]            NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [ProvinceState]       NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [CountryCode]         CHAR (2)      COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [PoBox]               VARCHAR (15)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [ZipCode]             VARCHAR (15)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Phone1]              VARCHAR (15)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Phone2]              VARCHAR (15)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Email]               VARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DepartmentIdNo]      SMALLINT      NULL,
    [DesignationIdNo]     SMALLINT      NULL,
    [HiredDate]           DATE          NULL,
    [ReleasedDate]        DATE          NULL,
    [ArAccountIdNo]       INT           NULL,
    [BankIdNo]            INT           NULL,
    [BankAccountNo]       VARCHAR (15)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [IBAN]                VARCHAR (20)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Notes]               VARCHAR (300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [OpeningBalance]      MONEY         NULL,
    [Balance]             MONEY         NULL,
    [PaymentMethod]       CHAR (1)      NULL,
    [PayFrequency]        CHAR (1)      NULL,
    [PaySalariedOrHourly] CHAR (1)      NULL,
    [PayRateType]         CHAR (1)      NULL,
    [PayRateAmount]       MONEY         NULL,
    [Active]              BIT           NULL,
    [Create_Date]         DATETIME      NULL,
    [DateTimeStamp]       ROWVERSION    NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);












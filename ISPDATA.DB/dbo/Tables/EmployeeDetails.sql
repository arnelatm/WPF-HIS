CREATE TABLE [dbo].[EmployeeDetails] (
    [IdNo]         INT           IDENTITY (1, 1) NOT NULL,
    [BranchID]     VARCHAR (4)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [EmployeeID]   VARCHAR (15)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [FIrstName]    VARCHAR (40)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [FirstNameAra] NVARCHAR (40) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [BirthDate]    DATE          NULL,
    [DateJoined]   DATE          NULL,
    [DateReleased] DATE          NULL,
    [Gender]       CHAR (1)      COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [NationalID]   VARCHAR (3)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [ReligionID]   VARCHAR (3)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [IQAMANo]      VARCHAR (20)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Create_Date]  DATETIME      NULL,
    CONSTRAINT [PK_EmployeeDetails] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


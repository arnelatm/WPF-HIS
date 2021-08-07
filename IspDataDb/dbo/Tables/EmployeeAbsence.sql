CREATE TABLE [dbo].[EmployeeAbsence] (
    [IdNo]            INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]    INT            NULL,
    [PayrollIdNo]     SMALLINT       NOT NULL,
    [EquivalentHours] DECIMAL (6, 2) NULL,
    [AbsenceType]     CHAR (1)       NULL,
    [AbsenceReason]   NVARCHAR (100) NULL,
    [AddedByUser]     SMALLINT       NULL,
    [DateCreated]     DATETIME       CONSTRAINT [DF_EmployeeAbsence_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]   ROWVERSION     NULL,
    CONSTRAINT [PK_EmployeeAbsence] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);




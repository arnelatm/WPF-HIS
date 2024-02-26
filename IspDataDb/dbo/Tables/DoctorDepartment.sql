CREATE TABLE [dbo].[DoctorDepartment] (
    [IdNo]              SMALLINT IDENTITY (1, 1) NOT NULL,
    [RevCostCenterIdNo] SMALLINT NULL,
    [Year]              SMALLINT NULL,
    [DoctorIdNo]        INT      NOT NULL,
    CONSTRAINT [PK_DoctorDepartment] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


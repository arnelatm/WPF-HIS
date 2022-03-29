CREATE TABLE [dbo].[EmpLeaveType] (
    [LeaveID]           VARCHAR (15)  NOT NULL,
    [Description]       VARCHAR (30)  NOT NULL,
    [DescriptionArabic] NVARCHAR (30) NULL,
    [WithoutPay]        INT           NULL
);


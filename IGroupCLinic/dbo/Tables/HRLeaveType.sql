CREATE TABLE [dbo].[HRLeaveType] (
    [LeaveID]           VARCHAR (15)  NOT NULL,
    [Description]       VARCHAR (50)  NOT NULL,
    [DescriptionArabic] NVARCHAR (50) NULL,
    [WithoutPay]        INT           NULL,
    [Remarks]           VARCHAR (100) NULL
);


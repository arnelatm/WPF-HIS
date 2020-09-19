CREATE TABLE [dbo].[EmployeeLeave] (
    [IdNo]               INT      IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]       INT      NULL,
    [LeaveIdNo]          SMALLINT NOT NULL,
    [DateStart]          DATE     NULL,
    [DateEnd]            DATE     NULL,
    [SupervisorApproved] BIT      NULL,
    [HRApproved]         BIT      NULL,
    CONSTRAINT [PK_EmployeeLeave] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);






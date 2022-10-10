CREATE TABLE [dbo].[EmployeeActions] (
    [IdNo]            INT            NULL,
    [EmployeeIdNo]    INT            NULL,
    [ActionType]      CHAR (1)       NULL,
    [DateOfAction]    DATE           NULL,
    [DesignationIdNo] SMALLINT       NULL,
    [BasicPay]        MONEY          NULL,
    [PayRateType]     CHAR (1)       NULL,
    [PayRateAmount]   MONEY          NULL,
    [PayFrequency]    CHAR (1)       NULL,
    [Notes]           NVARCHAR (100) NULL
);


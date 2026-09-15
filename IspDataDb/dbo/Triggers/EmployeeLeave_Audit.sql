CREATE TRIGGER [dbo].[EmployeeLeave_Audit]
ON [dbo].[EmployeeLeave]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Events TABLE (RecordIdNo INT NOT NULL, AuditEventId BIGINT NOT NULL);

    INSERT [dbo].[AuditEvent]
        ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    OUTPUT CONVERT(INT, inserted.[RecordIdNo]), inserted.[AuditEventId] INTO @Events
    SELECT c.[UserIdNo], c.[UserNameSnapshot],
           CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
           'EmployeeLeave', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), c.[BranchIdNo],
           'EmployeeLeave record changed', c.[ApplicationName], c.[MachineName]
    FROM inserted i FULL OUTER JOIN deleted d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() c
    WHERE d.[IdNo] IS NULL OR i.[IdNo] IS NULL OR EXISTS
      (SELECT i.[EmployeeIdNo], i.[LeaveIdNo], i.[HolidayIdNo], i.[StartDate], i.[EndDate], i.[NoOfDays], i.[FullDay], i.[LeaveReason], i.[Reason]
       EXCEPT SELECT d.[EmployeeIdNo], d.[LeaveIdNo], d.[HolidayIdNo], d.[StartDate], d.[EndDate], d.[NoOfDays], d.[FullDay], d.[LeaveReason], d.[Reason]);

    INSERT [dbo].[AuditFieldChange] ([AuditEventId], [FieldName], [OldValue], [NewValue])
    SELECT e.[AuditEventId], v.[FieldName], v.[OldValue], v.[NewValue]
    FROM inserted i JOIN deleted d ON d.[IdNo] = i.[IdNo] JOIN @Events e ON e.[RecordIdNo] = i.[IdNo]
    CROSS APPLY (VALUES
      (N'StartDate', CONVERT(NVARCHAR(MAX), d.[StartDate]), CONVERT(NVARCHAR(MAX), i.[StartDate])),
      (N'EndDate', CONVERT(NVARCHAR(MAX), d.[EndDate]), CONVERT(NVARCHAR(MAX), i.[EndDate])),
      (N'NoOfDays', CONVERT(NVARCHAR(MAX), d.[NoOfDays]), CONVERT(NVARCHAR(MAX), i.[NoOfDays])),
      (N'FullDay', CONVERT(NVARCHAR(MAX), d.[FullDay]), CONVERT(NVARCHAR(MAX), i.[FullDay])),
      (N'LeaveReason', CONVERT(NVARCHAR(MAX), d.[LeaveReason]), CONVERT(NVARCHAR(MAX), i.[LeaveReason])),
      (N'Reason', CONVERT(NVARCHAR(MAX), d.[Reason]), CONVERT(NVARCHAR(MAX), i.[Reason]))) v([FieldName], [OldValue], [NewValue])
    WHERE ISNULL(v.[OldValue], N'') <> ISNULL(v.[NewValue], N'');
END;
GO

CREATE TRIGGER [dbo].[EmployeeLeaveApprovalItem_Audit]
ON [dbo].[EmployeeLeaveApprovalItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Events TABLE (RecordIdNo INT NOT NULL, AuditEventId BIGINT NOT NULL);
    INSERT [dbo].[AuditEvent]
        ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    OUTPUT CONVERT(INT, inserted.[RecordIdNo]), inserted.[AuditEventId] INTO @Events
    SELECT c.[UserIdNo], c.[UserNameSnapshot], CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
           'EmployeeLeaveApprovalItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), c.[BranchIdNo], 'EmployeeLeaveApprovalItem record changed', c.[ApplicationName], c.[MachineName]
    FROM inserted i FULL OUTER JOIN deleted d ON d.[IdNo] = i.[IdNo] CROSS JOIN [dbo].[GetAuditSessionContext]() c
    WHERE d.[IdNo] IS NULL OR i.[IdNo] IS NULL OR EXISTS
      (SELECT i.[EmployeeLeaveApprovalIdNo], i.[EmployeeLeaveIdNo], i.[Approved], i.[Disapproved], i.[Status], i.[ApprovalNote]
       EXCEPT SELECT d.[EmployeeLeaveApprovalIdNo], d.[EmployeeLeaveIdNo], d.[Approved], d.[Disapproved], d.[Status], d.[ApprovalNote]);
    INSERT [dbo].[AuditFieldChange] ([AuditEventId], [FieldName], [OldValue], [NewValue])
    SELECT e.[AuditEventId], v.[FieldName], v.[OldValue], v.[NewValue]
    FROM inserted i JOIN deleted d ON d.[IdNo] = i.[IdNo] JOIN @Events e ON e.[RecordIdNo] = i.[IdNo]
    CROSS APPLY (VALUES (N'Approved', CONVERT(NVARCHAR(MAX), d.[Approved]), CONVERT(NVARCHAR(MAX), i.[Approved])),
                        (N'Disapproved', CONVERT(NVARCHAR(MAX), d.[Disapproved]), CONVERT(NVARCHAR(MAX), i.[Disapproved])),
                        (N'Status', CONVERT(NVARCHAR(MAX), d.[Status]), CONVERT(NVARCHAR(MAX), i.[Status])),
                        (N'ApprovalNote', CONVERT(NVARCHAR(MAX), d.[ApprovalNote]), CONVERT(NVARCHAR(MAX), i.[ApprovalNote]))) v([FieldName], [OldValue], [NewValue])
    WHERE ISNULL(v.[OldValue], N'') <> ISNULL(v.[NewValue], N'');
END;
GO

CREATE TRIGGER [dbo].[AttendanceItem_Audit]
ON [dbo].[AttendanceItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT [dbo].[AuditEvent] ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT c.[UserIdNo], c.[UserNameSnapshot], CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
           'AttendanceItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), c.[BranchIdNo], 'AttendanceItem record changed', c.[ApplicationName], c.[MachineName]
    FROM inserted i FULL OUTER JOIN deleted d ON d.[IdNo] = i.[IdNo] CROSS JOIN [dbo].[GetAuditSessionContext]() c
    WHERE d.[IdNo] IS NULL OR i.[IdNo] IS NULL OR EXISTS
      (SELECT i.[EmployeeIdNo], i.[PayrollIdNo], i.[DaysPresent], i.[DaysAbsentWithPay], i.[DaysAbsentWithoutPay], i.[DaysVacationLeave], i.[DaysOff], i.[DaysTotal], i.[Sequence]
       EXCEPT SELECT d.[EmployeeIdNo], d.[PayrollIdNo], d.[DaysPresent], d.[DaysAbsentWithPay], d.[DaysAbsentWithoutPay], d.[DaysVacationLeave], d.[DaysOff], d.[DaysTotal], d.[Sequence]);
END;
GO

CREATE TRIGGER [dbo].[OtWorkHour_Audit]
ON [dbo].[OtWorkHour]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT [dbo].[AuditEvent] ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT c.[UserIdNo], c.[UserNameSnapshot], CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
           'OtWorkHour', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), c.[BranchIdNo], 'OtWorkHour record changed', c.[ApplicationName], c.[MachineName]
    FROM inserted i FULL OUTER JOIN deleted d ON d.[IdNo] = i.[IdNo] CROSS JOIN [dbo].[GetAuditSessionContext]() c
    WHERE d.[IdNo] IS NULL OR i.[IdNo] IS NULL OR EXISTS
      (SELECT i.[EmployeeIdNo], i.[PayrollIdNo], i.[HoursWorked], i.[OvertimeRegular], i.[OvertimeHoliday], i.[OvertimeSpecial], i.[Sequence]
       EXCEPT SELECT d.[EmployeeIdNo], d.[PayrollIdNo], d.[HoursWorked], d.[OvertimeRegular], d.[OvertimeHoliday], d.[OvertimeSpecial], d.[Sequence]);
END;
GO

CREATE TRIGGER [dbo].[EmployeeAbsence_Audit]
ON [dbo].[EmployeeAbsence]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT [dbo].[AuditEvent] ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT c.[UserIdNo], c.[UserNameSnapshot], CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
           'EmployeeAbsence', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), c.[BranchIdNo], 'EmployeeAbsence record changed', c.[ApplicationName], c.[MachineName]
    FROM inserted i FULL OUTER JOIN deleted d ON d.[IdNo] = i.[IdNo] CROSS JOIN [dbo].[GetAuditSessionContext]() c
    WHERE d.[IdNo] IS NULL OR i.[IdNo] IS NULL OR EXISTS
      (SELECT i.[EmployeeIdNo], i.[PayrollIdNo], i.[EquivalentHours], i.[AbsenceType], i.[AbsenceReason], i.[AddedByUser]
       EXCEPT SELECT d.[EmployeeIdNo], d.[PayrollIdNo], d.[EquivalentHours], d.[AbsenceType], d.[AbsenceReason], d.[AddedByUser]);
END;
GO

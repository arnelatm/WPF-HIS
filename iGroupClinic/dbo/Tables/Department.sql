CREATE TABLE [dbo].[Department] (
    [IdNo]              SMALLINT       IDENTITY (1, 1) NOT NULL,
    [DepartmentCode]    VARCHAR (10)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [DepartmentName]    NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [DepartmentNameAra] NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ParentIdNo]        SMALLINT       NULL,
    [Notes]             NVARCHAR (250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [RevCostCenterIDNo] SMALLINT       NULL,
    [Active]            BIT            NULL,
    [DateTimeStamp]     ROWVERSION     NULL,
    CONSTRAINT [PK_DepartmentIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [IX_DepartmentCode] UNIQUE NONCLUSTERED ([DepartmentCode] ASC),
    CONSTRAINT [IX_DepartmentName] UNIQUE NONCLUSTERED ([DepartmentName] ASC),
    CONSTRAINT [IX_DepartmentNameAra] UNIQUE NONCLUSTERED ([DepartmentNameAra] ASC)
);


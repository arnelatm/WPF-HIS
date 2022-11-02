CREATE TABLE [dbo].[MedicalServices] (
    [BranchID]           VARCHAR (15)    NOT NULL,
    [ServiceID]          VARCHAR (15)    NOT NULL,
    [ServiceNameEnglish] VARCHAR (100)   NOT NULL,
    [ServiceNameArabic]  NVARCHAR (100)  NULL,
    [CashPrice]          NUMERIC (10, 2) DEFAULT (0) NULL,
    [CreditPrice]        NUMERIC (10, 2) DEFAULT (0) NULL,
    [StaffPrice]         NUMERIC (10, 2) DEFAULT (0) NULL,
    [DiscountAmt]        NUMERIC (10, 2) DEFAULT (0) NULL,
    [DiscountPercent]    NUMERIC (10, 2) DEFAULT (0) NULL,
    [CostPrice]          NUMERIC (10, 2) DEFAULT (0) NULL,
    [AcLedgerID]         VARCHAR (15)    NULL,
    [CostCentre]         VARCHAR (15)    NULL,
    [DepartmentID]       VARCHAR (15)    NULL,
    [DepartmentGroupID]  VARCHAR (15)    NULL,
    [ServiceGroup]       VARCHAR (15)    NULL,
    [Nature]             VARCHAR (20)    DEFAULT ('Service') NULL,
    [Status]             CHAR (1)        DEFAULT ('A') NULL,
    [NameChange]         INT             DEFAULT (0) NULL,
    [PriceChange]        INT             DEFAULT (0) NULL,
    [DiscountChange]     INT             DEFAULT (0) NULL,
    [ServiceListType]    VARCHAR (15)    DEFAULT (0) NULL,
    [Blocked]            CHAR (1)        DEFAULT ('N') NULL,
    [BlockedReason]      VARCHAR (50)    NULL,
    [Remarks]            NVARCHAR (150)  NULL,
    [UserID]             VARCHAR (15)    NULL,
    [Create_Date]        DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]          VARCHAR (20)    DEFAULT (host_name()) NULL,
    [VATApplicable]      INT             DEFAULT ((0)) NULL,
    [VATPercent]         NUMERIC (5, 2)  DEFAULT ((0)) NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_MedicalServices]
    ON [dbo].[MedicalServices]([BranchID] ASC, [ServiceID] ASC, [ServiceListType] ASC);


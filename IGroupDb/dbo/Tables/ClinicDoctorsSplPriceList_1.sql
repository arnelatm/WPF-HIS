CREATE TABLE [dbo].[ClinicDoctorsSplPriceList] (
    [BranchID]    VARCHAR (15)    NULL,
    [DoctorID]    VARCHAR (15)    NULL,
    [ServiceID]   VARCHAR (15)    NULL,
    [CashPrice]   NUMERIC (10, 2) NULL,
    [DiscountPer] NUMERIC (10, 2) NULL,
    [DiscountAmt] NUMERIC (10, 2) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_ClinicDoctorsSplPriceList]
    ON [dbo].[ClinicDoctorsSplPriceList]([DoctorID] ASC, [ServiceID] ASC);


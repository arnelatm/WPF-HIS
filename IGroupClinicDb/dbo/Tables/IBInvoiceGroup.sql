CREATE TABLE [dbo].[IBInvoiceGroup] (
    [Trans_Key]          NUMERIC (10)    NOT NULL,
    [BranchID]           VARCHAR (15)    NOT NULL,
    [IBType]             VARCHAR (4)     NOT NULL,
    [RegistrationNo]     NUMERIC (10)    NOT NULL,
    [PatientName]        NVARCHAR (75)   NOT NULL,
    [TransType]          VARCHAR (15)    NOT NULL,
    [TransNBR]           NUMERIC (10)    NOT NULL,
    [TransDateEnglish]   VARCHAR (10)    NOT NULL,
    [TransDateHijri]     VARCHAR (10)    NULL,
    [DeliveryDate]       VARCHAR (10)    NULL,
    [CompanyID]          VARCHAR (15)    NULL,
    [DoctorID]           VARCHAR (15)    NOT NULL,
    [Border_Iqama]       VARCHAR (15)    NULL,
    [SponsorID]          VARCHAR (20)    NULL,
    [Profession]         VARCHAR (50)    NULL,
    [CountryIOTA]        VARCHAR (15)    NOT NULL,
    [BaladiyaExpiration] VARCHAR (10)    NULL,
    [Phone]              VARCHAR (20)    NULL,
    [SponsorPhone]       VARCHAR (20)    NULL,
    [DOB]                VARCHAR (10)    NULL,
    [Age]                INT             NULL,
    [AgeYMD]             CHAR (1)        CONSTRAINT [DF__IBInvoice__AgeYM__26B08FFB] DEFAULT ('Y') NULL,
    [Sex]                CHAR (1)        CONSTRAINT [DF__IBInvoiceGr__Sex__27A4B434] DEFAULT ('M') NULL,
    [LabReportNo]        VARCHAR (15)    NULL,
    [LabReportResult]    VARCHAR (25)    NULL,
    [LabUnfitReason]     VARCHAR (40)    NULL,
    [XrayReportNo]       VARCHAR (15)    NULL,
    [XrayReportResult]   VARCHAR (25)    NULL,
    [CardStatus]         CHAR (1)        CONSTRAINT [DF__IBInvoice__CardS__2898D86D] DEFAULT ('N') NULL,
    [CardIssueDate]      VARCHAR (10)    NULL,
    [TokenNo]            INT             NULL,
    [GrossAmt]           NUMERIC (10, 2) CONSTRAINT [DF__IBInvoice__Gross__298CFCA6] DEFAULT ((0)) NULL,
    [DiscountAmt]        NUMERIC (10, 2) CONSTRAINT [DF__IBInvoice__Disco__2A8120DF] DEFAULT ((0)) NULL,
    [NetAmt]             NUMERIC (10, 2) CONSTRAINT [DF__IBInvoice__NetAm__2B754518] DEFAULT ((0)) NULL,
    [ExtraDiscountPer]   NUMERIC (10, 2) CONSTRAINT [DF__IBInvoice__Extra__2C696951] DEFAULT ((0)) NULL,
    [ExtraDiscountAmt]   NUMERIC (10, 2) CONSTRAINT [DF__IBInvoice__Extra__2D5D8D8A] DEFAULT ((0)) NULL,
    [Remarks]            VARCHAR (100)   NULL,
    [Posted]             INT             CONSTRAINT [DF__IBInvoice__Poste__2E51B1C3] DEFAULT ((0)) NULL,
    [Accepted]           INT             CONSTRAINT [DF__IBInvoice__Accep__2F45D5FC] DEFAULT ((0)) NULL,
    [AcceptedNo]         VARCHAR (10)    NULL,
    [Rejected]           INT             CONSTRAINT [DF__IBInvoice__Rejec__3039FA35] DEFAULT ((0)) NULL,
    [RejectedDate]       VARCHAR (10)    NULL,
    [Finishied]          CHAR (1)        CONSTRAINT [DF__IBInvoice__Finis__312E1E6E] DEFAULT ('N') NULL,
    [UserID]             VARCHAR (15)    NULL,
    [Create_Date]        DATETIME        CONSTRAINT [DF__IBInvoice__Creat__322242A7] DEFAULT (getdate()) NULL,
    [MachineID]          VARCHAR (20)    CONSTRAINT [DF__IBInvoice__Machi__331666E0] DEFAULT (host_name()) NULL,
    [SponsorName]        NVARCHAR (75)   NULL,
    [SalesmanID]         VARCHAR (15)    NULL,
    [LabSeries]          NUMERIC (10)    NULL,
    [VATAmt]             NUMERIC (10, 2) CONSTRAINT [DF__IBInvoice__VATAm__46D346CA] DEFAULT ((0)) NULL,
    [VATExemption]       NUMERIC (10, 2) CONSTRAINT [DF__IBInvoice__VATEx__42CDABBC] DEFAULT ((0)) NULL,
    [IdNo]               INT             IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_IBInvoiceGroup] PRIMARY KEY NONCLUSTERED ([IdNo] ASC)
);




GO
CREATE UNIQUE CLUSTERED INDEX [IDX_IBInvoiceGroup]
    ON [dbo].[IBInvoiceGroup]([Trans_Key] ASC, [RegistrationNo] ASC, [TransNBR] ASC);


GO
-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE TRIGGER [dbo].[trgIbInvGroupUpdRegNo] 
   ON  dbo.IBInvoiceGroup 
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	Declare @RegistrationNo as Int
	Declare @TransType as VarChar(2)
	Declare @PatientName as Varchar(100)
	Declare @TransKey as Int
	Declare @BranchId as Varchar(15)
	Declare @RegistrationDate as Date
	Declare @CompanyId as Varchar(15)
	Declare @newRegistrationNo as Int
	Declare @countryIota as Varchar(15)
	Declare @maxRegistrationNo as Int 
    SELECT @RegistrationNo = i.RegistrationNo, 
		   @TransType = Case When i.TransType ='Cash' then 'CA' When i.TransType ='Credit' then 'CR' End,
		   @TransKey = i.Trans_Key,
		   @BranchId = i.BranchID ,
		   @countryIota = i.CountryIOTA
		   FROM Inserted i
	
	If @TransType = 'CA' 
		Begin
			Select @newRegistrationNo = CurrentNo+1 from TransactionNoSeries where TransactionType = 'IBD' and  TransactionSeries = 'Out Patient'		
			Set @maxRegistrationNo = (Select Max(RegistrationNo) from IBPatientDetails where  BillType = 'CA')
			if @RegistrationNo > @maxRegistrationNo Update TransactionNoSeries set CurrentNo = @newRegistrationNo where TransactionType = 'IBD' and TransactionSeries = 'Out Patient' 
		End
	else IF @TransType = 'CR' 
		Begin
			Select @newRegistrationNo = CurrentNo+1 from TransactionNoSeries where TransactionType = 'IBD' and  TransactionSeries = 'Credit'
			Set @maxRegistrationNo = (Select Max(RegistrationNo) from IBPatientDetails where  BillType = 'CR' and PatientType = 'Credit')
			if @RegistrationNo > @maxRegistrationNo Update TransactionNoSeries set CurrentNo = @newRegistrationNo where TransactionType = 'IBD' and TransactionSeries = 'Credit' 
		END

END
GO
-- =============================================
-- Author:		Arnel Marcelo
-- Create date: 
-- Description:	
-- =============================================
CREATE TRIGGER [dbo].[trgIbInvGroupUpdNetAmt]
   ON  [dbo].[IBInvoiceGroup] 
   AFTER UPDATE,INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	Declare @countryIota as Varchar(15)
	Declare @NetAmt as Decimal(12,2)
	Declare @GrossAmt as Decimal(10,2)
	Declare @DiscountAmt as Decimal(10,2)
	Declare @ExtraDiscountAmt as Decimal(10,2)
	Declare @VATAmt as Decimal(10,2)
	Declare @VATExemption as Decimal(10,2)
	Declare @NewVatExemption as Decimal(10,2)
	Declare @NewNetAmt as Decimal(10,2)
	Declare @TransNbr as Int
    SELECT @TransNbr = i.TransNbr,
		   @countryIota = i.CountryIOTA,@NetAmt = i.NetAmt, @GrossAmt = i.GrossAmt, @DiscountAmt = i.DiscountAmt,
		   @ExtraDiscountAmt = i.ExtraDiscountAmt, @VATAmt = i.VatAmt, @VATExemption = i.VatExemption
		   FROM Inserted i

	 If (ABS(@NetAmt - (@GrossAmt - @DiscountAmt - @ExtraDiscountAmt + @VATAmt - @VATExemption)) > 0.01) or (@VATAmt <> @VATExemption) AND (@VATExemption <> 0)
		Begin
			if @CountryIota = 'SAU' 
				Begin
					if @VatAmt <> @VatExemption 
						Begin
							Set @NewVatExemption = @VatAmt
							Update IBInvoiceGroup Set @VatExemption = @VatAmt, NetAmt = (@GrossAmt - @DiscountAmt - @ExtraDiscountAmt + @VatAmt - @NewVatExemption) where TransNbr = @TransNbr 
						end
					else
						Begin
							Update IBInvoiceGroup Set NetAmt = (@GrossAmt - @DiscountAmt - @ExtraDiscountAmt) where TransNbr = @TransNbr 						
						end 
				end 
			else
				Update IBInvoiceGroup Set @VatExemption = 0, NetAmt = (@GrossAmt - @DiscountAmt - @ExtraDiscountAmt + @VatAmt) where TransNbr = @TransNbr 
		End



END
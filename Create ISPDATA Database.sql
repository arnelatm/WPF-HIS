USE [ISPDATA]
GO
/****** Object:  User [Arnel]    Script Date: 02/12/2020 15:42:52 ******/
CREATE USER [Arnel] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Arnel]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [Arnel]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [Arnel]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [Arnel]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [Arnel]
GO
ALTER ROLE [db_datareader] ADD MEMBER [Arnel]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [Arnel]
GO
/****** Object:  UserDefinedTableType [dbo].[AccountReconciliationItemInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[AccountReconciliationItemInsert] AS TABLE(
	[AccountReconciliationIdNo] [int] NULL,
	[Cleared] [bit] NULL,
	[JournalCode] [char](2) NULL,
	[JournalItemIdNo] [int] NULL,
	[Sequence] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[AccountReconciliationItemUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[AccountReconciliationItemUpdate] AS TABLE(
	[AccountReconciliationIdNo] [int] NULL,
	[Cleared] [bit] NULL,
	[IdNo] [int] NOT NULL,
	[JournalCode] [char](2) NULL,
	[JournalItemIdNo] [int] NULL,
	[Sequence] [int] NULL,
	PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[CdOiItemInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[CdOiItemInsert] AS TABLE(
	[Amount] [money] NULL,
	[ApOpenInvoiceIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[DjIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[CdOiItemUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[CdOiItemUpdate] AS TABLE(
	[Amount] [money] NULL,
	[ApOpenInvoiceIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[DjIdNo] [int] NOT NULL,
	[IDNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[CkdOiItemInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[CkdOiItemInsert] AS TABLE(
	[Amount] [money] NULL,
	[ApOpenInvoiceIdNo] [int] NOT NULL,
	[CkdIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[Sequence] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[CkdOiItemUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[CkdOiItemUpdate] AS TABLE(
	[Amount] [money] NULL,
	[ApOpenInvoiceIdNo] [int] NOT NULL,
	[CkdIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[IDNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[CkOiItemInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[CkOiItemInsert] AS TABLE(
	[Amount] [money] NULL,
	[ApOpenInvoiceIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[DjIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[CkOiItemUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[CkOiItemUpdate] AS TABLE(
	[Amount] [money] NULL,
	[ApOpenInvoiceIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[DjIdNo] [int] NOT NULL,
	[IDNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[CsrOiItemInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[CsrOiItemInsert] AS TABLE(
	[Amount] [money] NULL,
	[ArOpenInvoiceIdNo] [int] NOT NULL,
	[CsrIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[Sequence] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[CsrOiItemUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[CsrOiItemUpdate] AS TABLE(
	[Amount] [money] NULL,
	[ArOpenInvoiceIdNo] [int] NOT NULL,
	[CsrIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[IDNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[DeptTableType]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[DeptTableType] AS TABLE(
	[DNAME] [varchar](20) NULL,
	[LOC] [varchar](20) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[DistributionSchemeItemInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[DistributionSchemeItemInsert] AS TABLE(
	[DistributionSchemeIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[RevCostCenteridNo] [int] NOT NULL,
	[Percentage] [decimal](6, 2) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[DistributionSchemeItemMerge]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[DistributionSchemeItemMerge] AS TABLE(
	[IDNo] [int] NOT NULL,
	[Sequence] [int] NULL,
	[DistributionSchemeIdNo] [int] NOT NULL,
	[RevCostCenterIdNo] [int] NOT NULL,
	[Percentage] [decimal](6, 2) NULL,
	PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[DistributionSchemeItemUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[DistributionSchemeItemUpdate] AS TABLE(
	[IDNo] [int] NOT NULL,
	[DistributionSchemeIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[RevCostCenterIdNo] [int] NOT NULL,
	[Percentage] [decimal](6, 2) NULL,
	PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[EmployeeDeductionInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[EmployeeDeductionInsert] AS TABLE(
	[Amount] [money] NULL,
	[DeductionIdNo] [smallint] NOT NULL,
	[EmployeeIdNo] [int] NOT NULL,
	[Rate] decimal NOT NULL,
	[Sequence] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[EmployeeDeductionUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[EmployeeDeductionUpdate] AS TABLE(
	[Amount] [smallmoney] NULL,
	[DeductionIdNo] [smallint] NOT NULL,
	[EmployeeIdNo] [int] NOT NULL,
	[IDNo] [int] NOT NULL,
	[Rate] decimal NOT NULL,
	[Sequence] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[EmployeeEarningInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[EmployeeEarningInsert] AS TABLE(
	[Amount] [money] NULL,
	[EarningIdNo] [smallint] NOT NULL,
	[EmployeeIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[EmployeeEarningUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[EmployeeEarningUpdate] AS TABLE(
	[Amount] [smallmoney] NULL,
	[EarningIdNo] [smallint] NOT NULL,
	[EmployeeIdNo] [int] NOT NULL,
	[IdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[EmployeeLoanJournalItemInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[EmployeeLoanJournalItemInsert] AS TABLE(
	[JournalIDNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[Debit] [money] NULL,
	[Credit] [money] NULL,
	[RevCostCenterIdNo] [int] NULL,
	[Notes] [nvarchar](100) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[EmployeeLoanJournalItemUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[EmployeeLoanJournalItemUpdate] AS TABLE(
	[IDNo] [int] NOT NULL,
	[JournalIDNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[Debit] [money] NULL,
	[Credit] [money] NULL,
	[RevCostCenterIdNo] [int] NULL,
	[Notes] [nvarchar](100) NULL,
	PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[EmployeePhoneInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[EmployeePhoneInsert] AS TABLE(
	[AreaCode] [varchar](5) NULL,
	[CountryTelIdNo] [smallint] NOT NULL,
	[EmployeeIdNo] [int] NOT NULL,
	[PhoneNumber] [varchar](14) NOT NULL,
	[PhoneTypeIdNo] [smallint] NULL,
	[Sequence] [tinyint] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[EmployeePhoneUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[EmployeePhoneUpdate] AS TABLE(
	[AreaCode] [varchar](5) NULL,
	[CountryTelIdNo] [smallint] NULL,
	[EmployeeIdNo] [int] NOT NULL,
	[IDNo] [int] NOT NULL,
	[PhoneNumber] [varchar](14) NOT NULL,
	[PhoneTypeIdNo] [smallint] NOT NULL,
	[Sequence] [tinyint] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[GroupAccessInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[GroupAccessInsert] AS TABLE(
	[SecurityGroupIDNo] [int] NOT NULL,
	[SecurityObjectIDNo] [int] NOT NULL,
	[Visible] [bit] NOT NULL,
	[Editable] [bit] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[GroupAccessUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[GroupAccessUpdate] AS TABLE(
	[IDNo] [int] NOT NULL,
	[SecurityGroupIDNo] [int] NOT NULL,
	[SecurityObjectIDNo] [int] NOT NULL,
	[Visible] [bit] NOT NULL,
	[Editable] [bit] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[JournalItemInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[JournalItemInsert] AS TABLE(
	[AccountIdNo] [int] NOT NULL,
	[Credit] [money] NOT NULL,
	[Debit] [money] NOT NULL,
	[JournalIDNo] [int] NOT NULL,
	[Notes] [nvarchar](100) NOT NULL,
	[RevCostCenterIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[JournalItemUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[JournalItemUpdate] AS TABLE(
	[AccountIdNo] [int] NOT NULL,
	[Credit] [money] NOT NULL,
	[Debit] [money] NOT NULL,
	[IDNo] [int] NOT NULL,
	[JournalIDNo] [int] NOT NULL,
	[Notes] [nvarchar](100) NOT NULL,
	[RevCostCenterIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[PayrollDeductAccountInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[PayrollDeductAccountInsert] AS TABLE(
	[AccountIdNo] [int] NOT NULL,
	[DeductionIdNo] [int] NOT NULL,
	[PayGroupIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[PayrollDeductAccountUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[PayrollDeductAccountUpdate] AS TABLE(
	[AccountIdNo] [smallint] NOT NULL,
	[DeductionIdNo] [smallint] NOT NULL,
	[IdNo] [int] NOT NULL,
	[PayGroupIdNo] [smallint] NOT NULL,
	[Sequence] [smallint] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[PayrollEarnAccountInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[PayrollEarnAccountInsert] AS TABLE(
	[AccountIdNo] [smallint] NOT NULL,
	[EarningIdNo] [smallint] NOT NULL,
	[PayGroupIdNo] [smallint] NOT NULL,
	[Sequence] [smallint] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[PayrollEarnAccountUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[PayrollEarnAccountUpdate] AS TABLE(
	[AccountIdNo] [smallint] NOT NULL,
	[EarningIdNo] [smallint] NOT NULL,
	[IdNo] [int] NOT NULL,
	[PayGroupIdNo] [smallint] NOT NULL,
	[Sequence] [smallint] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[PcOiItemInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[PcOiItemInsert] AS TABLE(
	[Amount] [money] NULL,
	[ApOpenInvoiceIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[DjIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[PcOiItemUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[PcOiItemUpdate] AS TABLE(
	[Amount] [money] NULL,
	[ApOpenInvoiceIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[DjIdNo] [int] NOT NULL,
	[IDNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[PensionRateInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[PensionRateInsert] AS TABLE(
	[EmployeeShare] [decimal](8, 2) NOT NULL,
	[EmployerShare] [decimal](8, 2) NOT NULL,
	[HighRange] [money] NOT NULL,
	[LowRange] [money] NOT NULL,
	[MaxAmount] [money] NOT NULL,
	[PensionSchemeIdNo] [smallint] NOT NULL,
	[Sequence] [smallint] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[PensionRateUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[PensionRateUpdate] AS TABLE(
	[EmployeeShare] [decimal](8, 2) NOT NULL,
	[EmployerShare] [decimal](8, 2) NOT NULL,
	[HighRange] [money] NOT NULL,
	[IdNo] [int] NOT NULL,
	[LowRange] [money] NOT NULL,
	[MaxAmount] [money] NOT NULL,
	[PensionSchemeIdNo] [smallint] NOT NULL,
	[Sequence] [smallint] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[ReconciledInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[ReconciledInsert] AS TABLE(
	[JournalCode] [char](2) NULL,
	[JournalItemIdNo] [int] NULL,
	[ReconciliationIdNo] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[SalesDepositInsert]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[SalesDepositInsert] AS TABLE(
	[DepositTypeIdNo] [tinyint] NOT NULL,
	[DepositAmount] [money] NULL,
	[SaleAmount] [money] NULL,
	[SalesJournalIdNo] [int] NULL,
	[Sequence] [int] NOT NULL,
	[VatAmount] [money] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[SalesDepositUpdate]    Script Date: 02/12/2020 15:42:52 ******/
CREATE TYPE [dbo].[SalesDepositUpdate] AS TABLE(
	[DepositTypeIdNo] [tinyint] NOT NULL,
	[DepositAmount] [money] NULL,
	[IdNo] [int] NOT NULL,
	[SaleAmount] [money] NULL,
	[SalesJournalIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[VatAmount] [money] NULL,
	PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedFunction [dbo].[arabic_convert_single]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[arabic_convert_single] 
(
	@currency	VARCHAR(MAX)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE	@number		NVARCHAR(MAX)
	SET @number =(SELECT [number_string] 
	FROM [currencies] 
	WHERE [number]=@currency)
	
	RETURN @number	
END


GO
/****** Object:  UserDefinedFunction [dbo].[convert_handreds]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[convert_handreds] 
(
	@number		VARCHAR(MAX)
)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @number_string		VARCHAR(MAX)
	DECLARE @hundreds			INT
	DECLARE	@hundreds_string	VARCHAR(MAX)
	DECLARE @tens				INT
	DECLARE	@tens_string		VARCHAR(MAX)
	DECLARE @final_value		VARCHAR(MAX)
	DECLARE @temp01				VARCHAR(1)
	DECLARE @temp02				VARCHAR(2)
	
	SET @number_string = @number
	SET	@temp01 = SUBSTRING(@number_string,1,1)
	SET @temp02 = SUBSTRING(@number_string,2,2)
	SET @tens = CAST(@temp02 AS INT)
		
	------------ Special Case --------------------------------------------
	IF(LEN(@number_string) = 2)
	BEGIN
		SET @final_value = dbo.convert_last_two_digits(@number_string)
		GOTO FINAL
	END
	ELSE IF(LEN(@number_string) = 1)
	BEGIN
		SET @final_value = dbo.arabic_convert_single(@number_string)
		GOTO FINAL
	END
	----------------------------------------------------------------------
	ELSE IF(SUBSTRING(@number_string,2,1) = '0')
		BEGIN
			IF(SUBSTRING(@number_string,3,1) = '0')
			BEGIN
				SET @hundreds = dbo.put_zero(@temp01,2)
				SET	@hundreds_string = dbo.arabic_convert_single(@hundreds) + ' '
				SET @tens_string = ''
			END
			ELSE
			BEGIN
				SET @tens_string = [dbo].arabic_convert_single(CAST(SUBSTRING(@number_string,3,1) AS INT))
				SET @hundreds = dbo.put_zero(@temp01,2)
				SET	@hundreds_string = dbo.arabic_convert_single(@hundreds) 
			END
		END
	ELSE
		BEGIN
			SET @tens_string = dbo.convert_last_two_digits(@tens)
			SET @hundreds = dbo.put_zero(@temp01,2)
			SET	@hundreds_string = dbo.arabic_convert_single(@hundreds) 
		END
	IF(@tens =0 )
		SET @final_value = @hundreds_string --+ ' و ' + @tens_string
	ELSE
		SET @final_value = @hundreds_string + ' و ' + @tens_string

	FINAL:
	RETURN @final_value 

END




GO
/****** Object:  UserDefinedFunction [dbo].[convert_last_two_digits]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Wael Refaat
-- Create date: 2007-08-07 -- last modification 13-8-2007
-- Description:	Decompose the last two digits and 
--				returns the right value for it
-- =============================================
CREATE FUNCTION [dbo].[convert_last_two_digits] 
(
	@decimal VARCHAR(MAX)
)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @decimal_string	VARCHAR(MAX)
	DECLARE @inirts			VARCHAR(MAX)
	DECLARE	@tens			VARCHAR(MAX)
	DECLARE	@final_value	VARCHAR(MAX)
	
	SET @decimal_string = @decimal
	SET	@tens =	SUBSTRING(@decimal_string,1,1)
	SET @inirts = SUBSTRING(@decimal_string,2,1)	
	
	IF(LEN(@decimal) = 1)
		BEGIN
			SET @final_value = dbo.arabic_convert_single(@decimal)
		END
	ELSE
	BEGIN
		IF(@tens = 1)
			BEGIN
				DECLARE @temp1	VARCHAR(MAX)
				SET @temp1 = dbo.arabic_convert_single(@decimal)
				SET @final_value = @temp1
			END
		ELSE IF (@tens >= 2 AND @tens<=9)
			BEGIN
				DECLARE @tens_int		INT
				DECLARE @tens_int_2		INT
				DECLARE @temp_2	VARCHAR(MAX)
				SET @tens_int = CAST(@tens AS INT)
				SET @tens_int_2 = [dbo].put_zero(@tens_int,1)
				
				IF(@inirts != '0')
					SET @temp_2 = dbo.arabic_convert_single(@inirts) + ' و ' + dbo.arabic_convert_single(@tens_int_2)
				ELSE
					SET @temp_2 = dbo.arabic_convert_single(@tens_int_2)

	--			DECLARE	@temp_3	VARCHAR(MAX)
	--			DECLARE @temp_4	INT
	--			SET @temp_4 = CAST(@tens AS INT)
	--			SET @tens = [dbo].put_zero(@temp_4,1)	
			
				SET @final_value = @temp_2
				
			END
		END

	RETURN @final_value
END





GO
/****** Object:  UserDefinedFunction [dbo].[currency_conversion]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Wael Refaat
-- Create date: 13-8-2007
-- Description:	convert the given number to string
-- =============================================
CREATE FUNCTION [dbo].[currency_conversion]
(
	@currency	 VARCHAR(MAX)
)
RETURNS VARCHAR(MAX)
AS
BEGIN
	----------------Declaration--------------
	DECLARE @currency_string			VARCHAR(MAX)
	DECLARE @dot_position				INT
	DECLARE	@final_outpot_number		VARCHAR(MAX)
	DECLARE	@number_length				INT
	DECLARE @right_number_length		INT
	DECLARE	@fraction_number_length		INT
	DECLARE @right_number				VARCHAR(MAX)
	DECLARE @fraction_number			VARCHAR(MAX)
	DECLARE @right_number_simple		VARCHAR(MAX)		-- divided into 3 nubers groups
	DECLARE @right_number_simple_no		INT					-- Number of digits of the simple right digit
	DECLARE @fraction_number_simple		VARCHAR(MAX)		-- divided into 3 nubers groups
	DECLARE @fraction_number_simple_no	INT					-- Number of digits of the simple fraction digit
	DECLARE @right_number_front			VARCHAR(MAX)		-- The first number on the most left of the number
	DECLARE @fraction_number_front		VARCHAR(MAX)		-- The first number on the most left of the number
	DECLARE	@right_number_digit			INT
	DECLARE @fraction_number_digit		INT
	DECLARE @right_division				INT
	DECLARE @fraction_division			INT
	DECLARE @right_remainder			INT
	DECLARE @fraction_remainder			INT
	DECLARE @right_steps				INT
	DECLARE	@fraction_steps				INT
	DECLARE @test						VARCHAR(MAX)		-- Test Value to retrieve it in any time
	-----------------Initialization----------------

	SET @currency_string = CONVERT(VARCHAR(MAX) ,@currency)			-- Initialize the input to a vaiable to be used during the function
	SET @dot_position = dbo.dot_position(@currency)					-- returns the dot position of the input number
	SET @number_length = LEN(@currency)								-- The length of th einput number
		
	IF (@dot_position = -1)
	BEGIN
		SET @right_number_length = @number_length
		SET @right_number = @currency_string
		SET @fraction_number = 0
		SET @fraction_number_length = 0
		
		SET @right_division = @right_number_length/3 
		SET @right_remainder = @right_number_length%3
		SET @fraction_division = 0
		SET @fraction_remainder = 0
	END
	ELSE IF(@dot_position != -1)
	BEGIN
		SET @fraction_number_length = @number_length - @dot_position
		SET @right_number_length = @number_length - @fraction_number_length - 1
		SET @right_number = SUBSTRING(@currency_string, 0, @right_number_length + 1)
		SET @fraction_number = SUBSTRING(@currency_string,@dot_position + 1, @fraction_number_length)	
	
		SET @right_division = @right_number_length/3 
		SET @right_remainder = @right_number_length%3
		SET @fraction_division = @fraction_number_length/3
		SET @fraction_remainder = @fraction_number_length%3	
	END	
	
	
		----------- divide the right numbers ----------
	IF(@right_remainder = 1)
	BEGIN
		DECLARE @temp01 VARCHAR(1)
		DECLARE @temp02 VARCHAR(MAX)
		DECLARE @temp03	VARCHAR(MAX)
		
		SET @temp01 = SUBSTRING(@right_number,1,1)
		SET @temp02 = SUBSTRING(@right_number,2,@right_number_length-1)
		SET @temp03 = dbo.put_zero(@temp01,(3*@right_division))
		SET @right_number_simple = @temp02 
		SET @right_number_front = dbo.arabic_convert_single(@temp01) 
		IF(@right_division = 1)
		BEGIN
			SET @right_number_front = @right_number_front + ' الاف و '
		END
		ELSE IF(@right_division = 2)
		BEGIN
			SET @right_number_front = @right_number_front + ' مليون و '
		END
		ELSE IF(@right_division = 3)
		BEGIN
			SET @right_number_front = @right_number_front + ' مليار و ' 
		END
	END
	ELSE IF(@right_remainder = 2)
	BEGIN
		DECLARE @temp04 VARCHAR(2)
		DECLARE @temp05 VARCHAR(MAX)
		DECLARE @temp06	INT
		
		SET @temp04 = SUBSTRING(@right_number,1,2)
		SET @temp05 = SUBSTRING(@right_number,3,@right_number_length-2)
		--SET @temp06 = CAST(@temp04 AS INT)		
		SET @right_number_simple = @temp05
		SET @right_number_front = dbo.convert_last_two_digits(@temp04) --+  ' الف و '
		IF(@right_division = 1)
		BEGIN
			SET @right_number_front = @right_number_front + ' الف و '
		END
		ELSE IF(@right_division = 2)
		BEGIN
			SET @right_number_front = @right_number_front + ' مليون و '
		END
		ELSE IF(@right_division = 3)
		BEGIN
			SET @right_number_front = @right_number_front + ' مليار و ' 
		END
	END
	ELSE
	BEGIN
		SET @right_number_simple = @right_number
	END
	
	IF(@right_number_simple = '' OR @right_number_simple = NULL)
	BEGIN
		SET @right_number_simple = @right_number
	END
	
	SET @right_number_simple_no = LEN(@right_number_simple)
				----------- Divide The Fraction Numbers ----------
		IF(@fraction_remainder = 1)
		BEGIN
			DECLARE @temp07 VARCHAR(1)
			DECLARE @temp08 VARCHAR(MAX)
			DECLARE @temp09	INT
			
			SET @temp07 = SUBSTRING(@fraction_number,1,1)
			SET @temp08 = SUBSTRING(@fraction_number,2,@fraction_number_length -1)
			--SET @temp09 = CAST(@temp07 AS INT)		
			SET @fraction_number_simple = @temp08 
			
			SET @fraction_number_front = dbo.arabic_convert_single(@temp07)
		END
		ELSE IF(@fraction_remainder = 2)
		BEGIN
			DECLARE @temp10 VARCHAR(2)
			DECLARE @temp11 VARCHAR(MAX)
			DECLARE @temp12	INT
			
			SET @temp10 = SUBSTRING(@fraction_number,1,2)
			SET @temp11 = SUBSTRING(@fraction_number,3,@fraction_number_length -2)
			--SET @temp12 = CAST(@temp10 AS INT)		
			SET @fraction_number_simple = @temp11 
			SET @fraction_number_front = dbo.convert_last_two_digits(@temp10)
		END
		ELSE
		BEGIN
			SET @fraction_number_simple = @fraction_number
		END
	

	IF(@fraction_number_simple = '' OR @fraction_number_simple = NULL)
	BEGIN
		SET @fraction_number_simple = @fraction_number
	END
	
	SET @fraction_number_simple_no = LEN(@fraction_number_simple)
		---------------- Last Number ---------------------
	SET @final_outpot_number = @right_number_front
	DECLARE @i INT
	SET @i = 0
	WHILE(@i < @right_division AND @right_division > 0)
	BEGIN
		DECLARE @temp15		VARCHAR(MAX)
		DECLARE @temp16		VARCHAR(MAX)
		SET @temp15 = SUBSTRING(@right_number_simple, (3 * @i)+1 ,3)
		SET @temp16 = dbo.convert_handreds(@temp15)
		SET @final_outpot_number = @final_outpot_number + @temp16 + ' '
		--SET @test = (@i-@right_division)
		IF((@right_division-@i-1)=1)
		BEGIN			
			SET @final_outpot_number = @final_outpot_number + ' الف '
		END
		ELSE IF(((@right_division-@i-1) = 2))
		BEGIN
			SET @final_outpot_number = @final_outpot_number + ' مليون '
		END
		ELSE IF(((@right_division-@i-1) = 3))
		BEGIN
			SET @final_outpot_number = @final_outpot_number + ' مليار '
		END
		SET @i = @i + 1
	END
	SET @final_outpot_number = @final_outpot_number + ' ريال '
				-------- Piastres --------
	IF(@fraction_number_simple !='0' OR @fraction_number_simple != NULL)
	BEGIN
		DECLARE @temp20		VARCHAR(MAX)
		SET @temp20 = dbo.convert_last_two_digits(@fraction_number_simple)
		IF(@temp20 IS NULL)
			SET @temp20 = dbo.arabic_convert_single(SUBSTRING(@fraction_number_simple,2,1))
		SET @final_outpot_number = @final_outpot_number +  ' و '  + @temp20 + ' هللة‎ '
	END
	--SET @test = @right_number
	------------------------------- Special Case -----------------------------------------------
	IF(@right_remainder = 0 )																----
	BEGIN																					----				
		SET @final_outpot_number =''
		DECLARE @j INT																		----
		SET @j = 0																			----
		WHILE(@j < @right_division)															----
		BEGIN																				----
			DECLARE @temp22		VARCHAR(MAX)												----
			DECLARE @temp23		VARCHAR(MAX)												----
			SET @temp22 = SUBSTRING(@right_number, (3 * @j)+1 ,3)							----
			SET @test = @temp22
			SET @temp23 = dbo.convert_handreds(@temp22)										----
			SET @final_outpot_number = @final_outpot_number + @temp23 + ' '					----
			--SET @test = (@j-@right_division)												----
			IF((@right_division-@j-1)=1)													----
			BEGIN																			----
				SET @final_outpot_number = @final_outpot_number + ' الف '					----
			END																				----
			ELSE IF(((@right_division-@j-1) = 2))											----
			BEGIN																			----	
				SET @final_outpot_number = @final_outpot_number + ' مليون '					----
			END																				----
			ELSE IF(((@right_division-@j-1) = 3))											----
			BEGIN																			----	
				SET @final_outpot_number = @final_outpot_number + ' مليار '					----
			END		
			SET @j = @j + 1																	----
			--SET @final_outpot_number = 'Second Check'										----
			--SET @test = @j													     		----
		END																					----
		SET @final_outpot_number = @final_outpot_number + ' ريال '							----
																							----
		IF(@fraction_number_simple !=0 OR @fraction_number_simple != NULL)					----
		BEGIN																				----
			DECLARE @temp25		VARCHAR(MAX)												----
			SET @temp25 = dbo.convert_last_two_digits(@fraction_number_simple)				----
			SET @final_outpot_number = @final_outpot_number +  ' و '  + @temp25 + ' هللة‎ '	----
		END																					----
	END																						----
	--------------------------------------------------------------------------------------------
	-- Return the result of the function
	
	RETURN	@final_outpot_number   --@test	--@final_outpot_number  --CAST(@right_division AS VARCHAR(MAX)) + ' ' + CAST(@right_remainder AS VARCHAR(MAX)) + ' ' + CAST(@fraction_division AS VARCHAR(MAX)) + ' ' +	CAST(@fraction_remainder AS VARCHAR(MAX))

END
GO
/****** Object:  UserDefinedFunction [dbo].[DI_Tafkeet]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[DI_Tafkeet] (@TheNo  numeric(18,3))
returns varchar(1000) as


 
begin
if @TheNo <= 0   return 'zero'

declare @TheNoAfterReplicate varchar(15)
set @TheNoAfterReplicate = right(replicate('0',15)+cast(floor(@TheNo) as varchar(15)),15)
declare @ComWithWord varchar(1000),@TheNoWithDecimal as varchar(400),@ThreeWords as int
set @ThreeWords=0
set @ComWithWord  = ' فقط '
declare   @Tafket TABLE (num int,  NoName varchar(100))
INSERT INTO @Tafket VALUES (0,'') 
INSERT INTO @Tafket VALUES (1,'واحد')
INSERT INTO @Tafket VALUES (2,'اثنان')
INSERT INTO @Tafket VALUES (3,'ثلاثة')
INSERT INTO @Tafket VALUES (4,'اربعة')
INSERT INTO @Tafket VALUES (5,'خمسة')
INSERT INTO @Tafket VALUES (6,'ستة')
INSERT INTO @Tafket VALUES (7,'سبعة')
INSERT INTO @Tafket VALUES (8,'ثمانية')
INSERT INTO @Tafket VALUES (9,'تسعة')
INSERT INTO @Tafket VALUES (10,'عشرة')
INSERT INTO @Tafket VALUES (11,'احدى عشر')
INSERT INTO @Tafket VALUES (12,'اثنى عشر')
INSERT INTO @Tafket VALUES (13,'ثلاثة عشر')
INSERT INTO @Tafket VALUES (14,'اربعة عشر')
INSERT INTO @Tafket VALUES (15,'خمسة عشر')
INSERT INTO @Tafket VALUES (16,'ستة عشر')
INSERT INTO @Tafket VALUES (17,'سبعة عشر')
INSERT INTO @Tafket VALUES (18,'ثمانية عشر')
INSERT INTO @Tafket VALUES (19,'تسعة عشر')
INSERT INTO @Tafket VALUES (20,'عشرون')
INSERT INTO @Tafket VALUES (30,'ثلاثون')
INSERT INTO @Tafket VALUES (40,'اربعون')
INSERT INTO @Tafket VALUES (50,'خمسون')
INSERT INTO @Tafket VALUES (60,'ستون')
INSERT INTO @Tafket VALUES (70,'سبعون')
INSERT INTO @Tafket VALUES (80,'ثمانون')
INSERT INTO @Tafket VALUES (90,'تسعون')
INSERT INTO @Tafket VALUES (100,'مائة')
INSERT INTO @Tafket VALUES (200,'مائتان')
INSERT INTO @Tafket VALUES (300,'ثلاثمائة')
INSERT INTO @Tafket VALUES (400,'أربعمائة')
INSERT INTO @Tafket VALUES (500,'خمسمائة')
INSERT INTO @Tafket VALUES (600,'ستمائة')
INSERT INTO @Tafket VALUES (700,'سبعمائة')
INSERT INTO @Tafket VALUES (800,'ثمانمائة')
INSERT INTO @Tafket VALUES (900,'تسعمائة')
INSERT INTO @Tafket 
SELECT FirstN.num+LasteN.num,LasteN.NoName+' و '+FirstN.NoName FROM
(SELECT * FROM @Tafket WHERE num >= 20 AND num <= 90) FirstN
CROSS JOIN
(SELECT * FROM @Tafket WHERE num >= 1 AND num <= 9) LasteN

INSERT INTO @Tafket 
SELECT FirstN.num+LasteN.num,FirstN.NoName+' و '+LasteN.NoName FROM (SELECT * FROM @Tafket WHERE num >= 100 AND num <= 900) FirstN
CROSS JOIN
(SELECT * FROM @Tafket WHERE num >= 1 AND num <= 99) LasteN


if left(@TheNoAfterReplicate,3) > 0
set @ComWithWord = @ComWithWord + ISNULL((select NoName  from  @Tafket where num=left(@TheNoAfterReplicate,3)),'')+  ' ترليون'
if left(right(@TheNoAfterReplicate,12),3) > 0 and  left(@TheNoAfterReplicate,3) > 0
set @ComWithWord=@ComWithWord+ ' و '
if left(right(@TheNoAfterReplicate,12),3) > 0
set @ComWithWord = @ComWithWord +ISNULL((select NoName from @Tafket where num=left(right(@TheNoAfterReplicate,12),3)),'') +  ' بليون'
if left(right(@TheNoAfterReplicate,9),3) > 0

begin
set @ComWithWord=@ComWithWord + case  when @TheNo>999000000  then ' و'  else '' end
set @ThreeWords=left(right(@TheNoAfterReplicate,9),3)
set @ComWithWord = @ComWithWord + ISNULL((select case when   @ThreeWords>2 then NoName end  from @Tafket  where num=left(right(@TheNoAfterReplicate,9),3)),'')  + case when  @ThreeWords=2 then ' مليونان' when   @ThreeWords between 3 and 10 then ' ملايين' else ' مليون' end
end

if left(right(@TheNoAfterReplicate,6),3) > 0
begin
set @ComWithWord=@ComWithWord + case  when @TheNo>999000  then ' و'  else '' end
set @ThreeWords=left(right(@TheNoAfterReplicate,6),3)
set @ComWithWord = @ComWithWord + ISNULL((select case when  @ThreeWords>2 then NoName  end from @Tafket where num=left(right(@TheNoAfterReplicate,6),3)),'')+ case when  @ThreeWords=2 then ' الفان' when @ThreeWords between 3 and 10 then ' الاف'  else ' الف' end
end

if right(@TheNoAfterReplicate,3) > 0
begin

if @TheNo>999
begin
set @ComWithWord=@ComWithWord + ' و'
end

if right(@TheNoAfterReplicate, 2) = '01' or right(@TheNoAfterReplicate, 2) = '02'
begin
--set @ComWithWord=@ComWithWord + case  when @TheNo>1000  then ' و'  else '' end
--set @ThreeWords=left(right(@TheNoAfterReplicate,6),3)
set @ComWithWord = @ComWithWord + ' ' + ISNULL((select noname from @Tafket where num=right(@TheNoAfterReplicate, 3)),'')
end

set @ThreeWords=right(@TheNoAfterReplicate,2)

if @ThreeWords=0
begin
--   set @ComWithWord=@ComWithWord + ' و'
   set @ComWithWord = @ComWithWord + ISNULL((select NoName  from @Tafket where @ThreeWords=0 AND num=right(@TheNoAfterReplicate,3)),'')
end

end

set @ThreeWords=right(@TheNoAfterReplicate,2)
set @ComWithWord =  @ComWithWord  +   ISNULL((select  NoName  from @Tafket where @ThreeWords>2 AND num=right(@TheNoAfterReplicate,3)),'')
set @ComWithWord = @ComWithWord +' '+ case when  @ThreeWords=2 then ' ديناران' when @ThreeWords between 3 and 10 then ' دنانير'  else ' دينار' end
if right(rtrim(@ComWithWord),1)=',' set @ComWithWord = substring(@ComWithWord,1,len(@ComWithWord)-1)
if  right(@TheNo,len(@TheNo)-charindex('.',@TheNo)) >0 and charindex('.',@TheNo)<>0
    begin
        set @ThreeWords=left(right(round(@TheNo,3),3),3)
        SELECT @TheNoWithDecimal=  ' و' + ISNULL((SELECT NoName from @Tafket where num=left(right(round(@TheNo,3),3),3)  AND @ThreeWords >3),'')
        set @TheNoWithDecimal = @TheNoWithDecimal+  case when  @ThreeWords=2 then ' فلسان' when @ThreeWords between 3 and 10 then ' فلسات'  else '  فلس' end
set @ComWithWord = @ComWithWord + ' و '+ CONVERT(varchar(max),@ThreeWords)+ case when  @ThreeWords=2 then ' فلسان' when @ThreeWords between 3 and 10 then ' فلسات'  else '  فلس' end --@TheNoWithDecimal
END
set @ComWithWord = @ComWithWord + ' لا غير '

return rtrim(@ComWithWord)
end


GO
/****** Object:  UserDefinedFunction [dbo].[dot_position]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Wael Refaat
-- Create date: 13-8-2007
-- Description:	return the position of '.' on a float number
-- =============================================
CREATE FUNCTION [dbo].[dot_position] 
(
	@number		VARCHAR(50)
)
RETURNS INT
AS
BEGIN
	DECLARE @position	INT
	DECLARE	@found		BIT
	DECLARE	@number_string	VARCHAR(50)
	DECLARE @steps		INT
	
	SET @position = -1
	SET @steps = 0
	SET @found = 0
	SET @number_string = @number 
	
	WHILE(@steps<=50 AND (@found = 0))
	BEGIN
		DECLARE @temp VARCHAR(1)
		SET @temp = SUBSTRING(@number_string,@steps,1)
		IF(@temp = '.')
		BEGIN
			SET @position = @steps
			SET @found = 1
		END
		ELSE
		BEGIN
			SET @steps = @steps + 1
		END
	END
	
	RETURN @position

END


GO
/****** Object:  UserDefinedFunction [dbo].[generate_series]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Drop function if exists
--
--IF EXISTS (SELECT *
--             FROM dbo.sysobjects
--            WHERE id = object_id (N'[dbo].[generate_series]')
--              AND OBJECTPROPERTY(id, N'IsTableFunction') = 1)
--DROP FUNCTION [dbo].[generate_series]
--GO
--
-- Now let's create it
--
CREATE FUNCTION [dbo].[generate_series] ( @p_start INT, @p_end INT, @p_step INT=1 )
RETURNS @Integers TABLE ( [IntValue] INT )
AS
BEGIN
    DECLARE
      @v_i                 INT,
      @v_step              INT,
      @v_terminating_value INT;
    BEGIN
      SET @v_i = CASE WHEN @p_start IS NULL THEN 1 ELSE @p_start END;
      SET @v_step  = CASE WHEN @p_step IS NULL OR @p_step = 0 THEN 1 ELSE @p_step END;
      SET @v_terminating_value =  @p_start + CONVERT(INT,ABS(@p_start-@p_end) / ABS(@v_step) ) * @v_step;
      -- Check for impossible combinations
      IF NOT ( ( @p_start > @p_end AND SIGN(@p_step) = 1 )
               OR
               ( @p_start < @p_end AND SIGN(@p_step) = -1 ))
      BEGIN
        -- Generate values
        WHILE ( 1 = 1 )
        BEGIN
           INSERT INTO @Integers ( [IntValue] ) VALUES ( @v_i )
           IF ( @v_i = @v_terminating_value )
              BREAK
           SET @v_i = @v_i + @v_step;
        END;
      END;
    END;
    RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[number_conversation]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Wael Refaat
-- Create date: 13-8-2007
-- Description:	Analysis the given number, and convert
--				it in strig format
-- =============================================
CREATE FUNCTION [dbo].[number_conversation] 
(
	@currency	FLOAT
)
RETURNS VARCHAR(MAX)
AS
BEGIN
	------ Declarations ----------------------
	DECLARE @dot_position			INT
	DECLARE @currency_string		VARCHAR(12)
	DECLARE	@final_outpot_number	VARCHAR(MAX)
	DECLARE	@number_length			INT
	DECLARE @right_number_length	INT
	DECLARE	@fraction_number_length	INT
	DECLARE @right_number			VARCHAR(6)
	DECLARE @fraction_number		VARCHAR(6)
	DECLARE @right_number_simple	INT					-- divided into 3 nubers groups
	DECLARE @right_number_simple_No	INT					-- Number of digits of the simple right digit
	DECLARE @fraction_number_simple	INT					-- divided into 3 nubers groups
	DECLARE @fraction_number_simple_No	INT				-- Number of digits of the simple fraction digit
	DECLARE @right_number_front		NVARCHAR(MAX)		-- The first number on the most left of the number
	DECLARE @fraction_number_front	NVARCHAR(MAX)		-- The first number on the most left of the number
	DECLARE	@right_number_digit		INT
	DECLARE @fraction_number_digit	INT
	DECLARE @temp_1					FLOAT
	DECLARE @right_division			INT
	DECLARE @fraction_division		INT
	DECLARE @right_remainder		INT
	DECLARE @fraction_remainder		INT
	DECLARE @right_steps			INT
	DECLARE	@fraction_steps			INT	
	----------- Initialization --------------
	SET @temp_1 = @currency
	SET @dot_position = dbo.dot_position(@temp_1)
	SET @number_length = LEN(@currency)
	SET @fraction_number_length = @number_length - @dot_position
	SET @right_number_length = @number_length - @fraction_number_length - 1
	SET @currency_string = CAST(@currency AS VARCHAR(12))
	SET @right_number = SUBSTRING(@currency_string,0,@right_number_length)
	SET @fraction_number = SUBSTRING(@currency_string,@dot_position+1,@fraction_number_length)
	SET @right_number_digit = CAST(@right_number AS INT)
	SET	@fraction_number_digit = CAST(@fraction_number_digit AS INT)
	SET @right_division = @right_number_length/3 
	SET @right_remainder = @right_number_length%3
	SET @fraction_division = @fraction_number_length/3
	SET @fraction_remainder = @fraction_number_length%3	
	SET @right_number_front = ''
	SET @fraction_number_front = ''

			----------- divide the right numbers ----------
	IF(@right_remainder = 1)
	BEGIN
		DECLARE @temp01 NVARCHAR(1)
		DECLARE @temp02 NVARCHAR(MAX)
		DECLARE @temp03	INT
		
		SET @temp01 = SUBSTRING(@currency_string,0,1)
		SET @temp02 = SUBSTRING(@currency_string,1,@right_number_length-1)
		SET @temp03 = CAST(@temp01 AS INT)		
		SET @right_number_simple = CAST(@temp02 AS INT)
		SET @right_number_front = dbo.arabic_convert_single(@temp03)
	END
	ELSE IF(@right_remainder = 2)
	BEGIN
		DECLARE @temp04 NVARCHAR(1)
		DECLARE @temp05 NVARCHAR(MAX)
		DECLARE @temp06	INT
		
		SET @temp04 = SUBSTRING(@currency_string,0,2)
		SET @temp05 = SUBSTRING(@currency_string,2,@right_number_length-2)
		SET @temp06 = CAST(@temp04 AS INT)		
		SET @right_number_simple = CAST(@temp05 AS INT)
		SET @right_number_front = dbo.convert_last_two_digits(@temp06)
	END
	ELSE
	BEGIN
		SET @right_number_simple = @currency_string
	END
				----------- divide the right numbers ----------
	IF(@fraction_remainder = 1)
	BEGIN
		DECLARE @temp07 NVARCHAR(1)
		DECLARE @temp08 NVARCHAR(MAX)
		DECLARE @temp09	INT
		
		SET @temp07 = SUBSTRING(@currency_string,0,1)
		SET @temp08 = SUBSTRING(@currency_string,1,@fraction_number_length -1)
		SET @temp09 = CAST(@temp07 AS INT)		
		SET @fraction_number_simple = CAST(@temp08 AS INT)
		SET @fraction_number_simple = dbo.arabic_convert_single(@temp09)
	END
	ELSE IF(@right_remainder = 2)
	BEGIN
		DECLARE @temp10 NVARCHAR(1)
		DECLARE @temp11 NVARCHAR(MAX)
		DECLARE @temp12	INT
		
		SET @temp10 = SUBSTRING(@currency_string,0,2)
		SET @temp11 = SUBSTRING(@currency_string,2,@fraction_number_length -2)
		SET @temp12 = CAST(@temp10 AS INT)		
		SET @fraction_number_simple = CAST(@temp11 AS INT)
		SET @fraction_number_simple = dbo.convert_last_two_digits(@temp12)
	END
	ELSE
	BEGIN
		SET @fraction_number_simple = @currency_string
	END

				------------- Start ---------------------------
	DECLARE @right_string	VARCHAR(MAX)
	DECLARE @fraction_string	VARCHAR(MAX)
	SET @right_string = CAST(@right_number_simple AS VARCHAR(MAX))
	SET @fraction_string = CAST(@fraction_number_simple AS VARCHAR(MAX))
	SET @right_number_simple_No = LEN(@right_string)
	SET @fraction_number_simple_No = LEN(@fraction_string)
	SET @right_steps = 0
	SET @fraction_steps = 0
	IF (@final_outpot_number != '')
		SET @final_outpot_number = @right_number_front + ' و '
	
				------------ Brgin Iteration -----------------
		------------ Right Numbers -------------------
--	WHILE(@right_steps < (@right_number_simple_No/3) - 1)
--	BEGIN
--		DECLARE @temp13		VARCHAR(1)
--		DECLARE	@temp14		VARCHAR(2)
--		DECLARE @temp15		VARCHAR(MAX)
--		SET @temp13 = SUBSTRING(CAST(@right_number_simple AS VARCHAR(MAX)), (@right_steps * 3),1)
--		SET @temp14 = SUBSTRING(CAST(@right_number_simple AS VARCHAR(MAX)), (@right_steps * 3) +1 ,2)
--		SET @temp15 = dbo.arabic_convert_single(CAST(@temp13 AS INT)) + ' و ' + dbo.convert_last_two_digits(CAST(@temp14 AS INT))
--		SET @final_outpot_number = @final_outpot_number + ' و ' + @temp15
--	END
	
	




	RETURN @final_outpot_number
END

GO
/****** Object:  UserDefinedFunction [dbo].[put_zero]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Wael Refaat
-- Create date: 8-8-2007
-- Description:	take two number and return a number consists of
--				the first digit + Zeros as the count of the other digit
-- =============================================
CREATE FUNCTION [dbo].[put_zero] 
(
	@digit	VARCHAR(MAX),
	@NOZ	INT
)
RETURNS VARCHAR(MAX)
AS
BEGIN
	-- Declarations
	DECLARE @len				INT
	SET @len = @NOZ+1
	DECLARE @digit_as_string	NVARCHAR(10)
	DECLARE	@string_length		INT
	DECLARE @count				INT
	DECLARE @final_number		INT

	-- Initialization
	SET @string_length = LEN(@digit_as_string)
	SET @count = 1
	SET	@digit_as_string = @digit

	WHILE(@count <= @NOZ)
	BEGIN
		SET @digit_as_string = @digit_as_string + '0'
		SET @count = @count + 1
	END
	SET @final_number = @digit_as_string
	
	RETURN 	@final_number
END


GO
/****** Object:  UserDefinedFunction [dbo].[test_conversion]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Wael Refaat
-- Create date: 13-8-2007
-- Description:	Test conversion
-- =============================================
CREATE FUNCTION [dbo].[test_conversion] 
(
	@no1	INT
)
RETURNS  VARCHAR(MAX)
AS
BEGIN
	DECLARE		@no2	VARCHAR(MAX)
	DECLARE		@temp1	VARCHAR(1)
	DECLARE		@temp2	VARCHAR(1)
	--SET @no2 = CAST(@no1 AS VARCHAR(MAX))  (working)
	--SET @no2 = @no1	(working)
	SET @no2 = CONVERT(VARCHAR(2),@no1)
	SET @temp1 = (SELECT DISTINCT SUBSTRING(@no2,1,1) FROM [currencies])
	SET @temp2 = SUBSTRING(@no2,2,1)
	SET @no2 = @temp1 + ' test ' + @temp2
	RETURN @no2
END
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[BankCode] [varchar](10) NULL,
	[BankName] [varchar](50) NULL,
	[BankNameAra] [nvarchar](50) NULL,
	[Notes] [nvarchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CdJournal]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CdJournal](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDate] [date] NOT NULL,
	[ReferenceNo] [varchar](15) NULL,
	[Amount] [money] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[PaymentType] [char](1) NULL,
	[PayeeIdNo] [int] NULL,
	[PayeeName] [nvarchar](50) NULL,
	[ORNumber] [varchar](15) NULL,
	[DiscountTaken] [money] NULL,
	[DiscountAccountIdNo] [int] NULL,
	[Applied] [money] NULL,
	[UnApplied] [money] NULL,
	[VatNumber] [varchar](15) NULL,
	[VatAmount] [money] NULL,
	[Notes] [nvarchar](254) NULL,
	[Posted] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[Cancelled] [bit] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_CashDisbursementJournal1] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BankAccount]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankAccount](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[BankIdNo] [smallint] NOT NULL,
	[BranchName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BankAccount] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CdJournal_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[CdJournal_View]
AS
SELECT        dbo.CdJournal.IdNo, dbo.CdJournal.TransactionDate, dbo.CdJournal.ReferenceNo, dbo.CdJournal.Amount, 
                         dbo.CdJournal.AccountIdNo, dbo.CdJournal.PaymentType, dbo.CdJournal.PayeeIdNo, dbo.CdJournal.PayeeName, 
                         dbo.CdJournal.ORNumber, dbo.CdJournal.DiscountTaken, 
                         dbo.CdJournal.DiscountAccountIdNo, dbo.CdJournal.Applied, dbo.CdJournal.UnApplied, dbo.CdJournal.VatNumber, 
                         dbo.CdJournal.VatAmount, dbo.CdJournal.Notes, dbo.CdJournal.Posted, dbo.CdJournal.DateCreated, dbo.CdJournal.Cancelled, 
                         dbo.CdJournal.DateTimeStamp, dbo.currency_conversion(dbo.CdJournal.Amount) AS WordAmount, dbo.Bank.BankCode, dbo.Bank.BankNameAra, 
                         dbo.BankAccount.BranchName
FROM            dbo.CdJournal INNER JOIN
                         dbo.BankAccount ON dbo.CdJournal.AccountIdNo = dbo.BankAccount.AccountIdNo INNER JOIN
                         dbo.Bank ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo
GO
/****** Object:  Table [dbo].[GeneralJournal]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralJournal](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDate] [date] NOT NULL,
	[ReferenceNo] [nvarchar](10) NULL,
	[Notes] [nvarchar](100) NULL,
	[Posted] [bit] NULL,
	[ClosingJournal] [bit] NULL,
	[Cancelled] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_JournalIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GeneralJournalNormal_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[GeneralJournalNormal_View]
AS
SELECT        dbo.GeneralJournal.*
FROM            dbo.GeneralJournal
WHERE dbo.GeneralJournal.ClosingJournal=0
GO
/****** Object:  View [dbo].[GeneralJournalClosing_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[GeneralJournalClosing_View]
AS
SELECT        dbo.GeneralJournal.*
FROM            dbo.GeneralJournal
WHERE  dbo.GeneralJournal.ClosingJournal = 1
GO
/****** Object:  Table [dbo].[DepositType]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepositType](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[DepositTypeCode] [char](1) NOT NULL,
	[DepositTypeName] [nvarchar](30) NOT NULL,
	[DepositTypeNameAra] [nvarchar](30) NULL,
	[AccountIdNo] [smallint] NULL,
	[Rate] [decimal](8, 4) NULL,
	[WithBankCharges] [bit] NULL,
	[BankChargesAccountIdNo] [smallint] NULL,
	[BankChargesVatAccountIdNo] [smallint] NULL,
	[Notes] [nvarchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_PaymentType] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesDeposit]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesDeposit](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[SalesJournalIdNo] [int] NOT NULL,
	[Sequence] [smallint] NOT NULL,
	[DepositTypeIdNo] [smallint] NOT NULL,
	[SaleAmount] [money] NOT NULL,
	[DepositAmount] [money] NOT NULL,
	[VatAmount] [money] NULL,
 CONSTRAINT [PK_SalesDetailItemIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[SalesDeposit_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SalesDeposit_View]
AS
SELECT        dbo.SalesDeposit.IdNo, dbo.SalesDeposit.SalesJournalIdNo, dbo.SalesDeposit.Sequence, dbo.SalesDeposit.SaleAmount, dbo.SalesDeposit.DepositAmount, dbo.SalesDeposit.DepositTypeIdNo, 
                         dbo.DepositType.DepositTypeCode, dbo.DepositType.DepositTypeName, dbo.DepositType.AccountIdNo, dbo.DepositType.Rate, dbo.DepositType.BankChargesAccountIdNo, dbo.DepositType.BankChargesVatAccountIdNo, 
                         dbo.DepositType.DepositTypeNameAra, dbo.SalesDeposit.VatAmount
FROM            dbo.SalesDeposit INNER JOIN
                         dbo.DepositType ON dbo.SalesDeposit.DepositTypeIdNo = dbo.DepositType.IdNo
GO
/****** Object:  Table [dbo].[SecurityGroup]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityGroup](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[SecurityGroupName] [varchar](50) NULL,
	[ParentIdNo] [smallint] NULL,
	[Notes] [varchar](100) NULL,
	[DateTimeStamp] [timestamp] NULL,
	[SecurityGroupCode] [varchar](10) NULL,
	[SecurityGroupNameAra] [nvarchar](50) NULL,
 CONSTRAINT [PK_IDNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_SecurityGroupName] UNIQUE NONCLUSTERED 
(
	[SecurityGroupName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[SecurityGroup_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE View [dbo].[SecurityGroup_View] as 
with cte as
(
select IDNo
	  ,SecurityGroupCode
      ,SecurityGroupName
      ,SecurityGroupNameAra
      ,ParentIdNo
      ,Notes
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by ParentIdNo) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by ParentIdNo) / power(1000.0,0) as SortKey
 
from SecurityGroup
where ParentIdNo IS NULL
union all
select t.IDNo
	  ,t.SecurityGroupCode
      ,t.SecurityGroupName
      ,t.SecurityGroupNameAra
      ,t.ParentIdNo
      ,t.Notes
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.SecurityGroupName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.SecurityGroupName) / power(1000.0,levelnumber+1)
 
 from
    cte
join SecurityGroup t on cte.IdNo = t.ParentIdNo
)
   
select IDNo
	  ,SecurityGroupCode
      ,SecurityGroupName
      ,SecurityGroupNameAra
      ,ParentIdNo
      ,Notes
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte


GO
/****** Object:  Table [dbo].[PcOiItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PcOiItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[DjIdNo] [int] NOT NULL,
	[ApOpenInvoiceIdNo] [int] NOT NULL,
	[Sequence] [smallint] NOT NULL,
	[Amount] [money] NOT NULL,
	[DiscountTaken] [money] NOT NULL,
 CONSTRAINT [PK_PcsOiItemIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CkOiItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CkOiItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[DjIdNo] [int] NOT NULL,
	[ApOpenInvoiceIdNo] [int] NOT NULL,
	[Sequence] [smallint] NOT NULL,
	[Amount] [money] NOT NULL,
	[DiscountTaken] [money] NOT NULL,
 CONSTRAINT [PK_CkdOiItemIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CdOiItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CdOiItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[DjIdNo] [int] NOT NULL,
	[ApOpenInvoiceIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[DiscountTaken] [money] NOT NULL,
 CONSTRAINT [PK_CdOiItemIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ApPaymentItems_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ApPaymentItems_View] as
(SELECT [IdNo]
	  ,'CD' AS 'JournalCode'
      ,[DjIdNo] AS 'JournalIdNo'
      ,[ApOpenInvoiceIdNo] 
      ,[Sequence] 
      ,[Amount]
      ,[DiscountTaken]
  FROM [dbo].[CdOiItem]
)
union
(SELECT [IdNo] 
	  ,'CK'
      ,[DjIdNo]
      ,[ApOpenInvoiceIdNo]
      ,[Sequence]
      ,[Amount]
      ,[DiscountTaken]
  FROM [dbo].[CkOiItem]
)
UNION
(SELECT [IdNo]
	  ,'PC'
      ,[DjIdNo]
      ,[ApOpenInvoiceIdNo]
      ,[Sequence]
      ,[Amount]
      ,[DiscountTaken]
  FROM [dbo].[PcOiItem]
)
GO
/****** Object:  View [dbo].[ApPayments_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE VIEW [dbo].[ApPayments_View] AS 
SELECT [ApOpenInvoiceIdNo]
      ,Sum([Amount]) AS 'Amount'
      ,Sum([DiscountTaken]) AS 'DiscountTaken'
  FROM [dbo].[ApPaymentItems_View]
  GROUP BY apopeninvoiceidno
GO
/****** Object:  Table [dbo].[GeneralJournalItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralJournalItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [smallint] NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[Debit] [money] NOT NULL,
	[Credit] [money] NOT NULL,
	[RevCostCenterIdNo] [smallint] NOT NULL,
	[Notes] [nvarchar](300) NOT NULL,
	[Posted] [bit] NOT NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_GeneralJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PcJournal]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PcJournal](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDate] [date] NOT NULL,
	[ReferenceNo] [varchar](15) NULL,
	[Amount] [money] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[PaymentType] [char](1) NULL,
	[PayeeIdNo] [int] NULL,
	[PayeeName] [nvarchar](50) NULL,
	[CheckNumber] [varchar](10) NULL,
	[CheckDate] [date] NULL,
	[ORNumber] [varchar](15) NULL,
	[DiscountTaken] [money] NULL,
	[DiscountAccountIdNo] [smallint] NULL,
	[Applied] [money] NULL,
	[UnApplied] [money] NULL,
	[VatNumber] [varchar](15) NULL,
	[VatAmount] [money] NULL,
	[Notes] [nvarchar](254) NULL,
	[Posted] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[Cancelled] [bit] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_PcJournal1] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PcJournalItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PcJournalItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [smallint] NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[Debit] [money] NOT NULL,
	[Credit] [money] NOT NULL,
	[RevCostCenterIdNo] [smallint] NOT NULL,
	[Notes] [nvarchar](300) NOT NULL,
	[Posted] [bit] NOT NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_PcJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CdJournalItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CdJournalItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [smallint] NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[Debit] [money] NOT NULL,
	[Credit] [money] NOT NULL,
	[RevCostCenterIdNo] [smallint] NOT NULL,
	[Notes] [nvarchar](300) NOT NULL,
	[Posted] [bit] NOT NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_CashDisbursementJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CashReceiptJournalItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashReceiptJournalItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [smallint] NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[Debit] [money] NOT NULL,
	[Credit] [money] NOT NULL,
	[RevCostCenterIdNo] [smallint] NOT NULL,
	[Notes] [nvarchar](300) NOT NULL,
	[Posted] [bit] NOT NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_CashReceiptJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CashReceiptJournal]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashReceiptJournal](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDate] [date] NOT NULL,
	[ReferenceNo] [varchar](15) NULL,
	[Amount] [money] NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[PayorType] [char](1) NULL,
	[PayorIdNo] [int] NULL,
	[Payorname] [nvarchar](50) NULL,
	[CheckNumber] [varchar](10) NULL,
	[CheckDate] [date] NULL,
	[ORNumber] [varchar](15) NULL,
	[DiscountTaken] [money] NULL,
	[DiscountAccountIdNo] [smallint] NULL,
	[Applied] [money] NULL,
	[UnApplied] [money] NULL,
	[Notes] [nvarchar](255) NULL,
	[Posted] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[Cancelled] [bit] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_CashReceiptJournal] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApJournal]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApJournal](
	[IDNo] [int] IDENTITY(1,1) NOT NULL,
	[SupplierIdNo] [int] NOT NULL,
	[TransactionDate] [date] NULL,
	[ReferenceNo] [varchar](15) NULL,
	[TransactionType] [char](1) NULL,
	[Amount] [money] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[DueDate] [date] NULL,
	[SettlementDueDate] [date] NULL,
	[SettlementDiscount] [decimal](5, 2) NULL,
	[InvoiceNo] [varchar](15) NOT NULL,
	[InvoiceDate] [date] NULL,
	[VatNumber] [varchar](15) NULL,
	[VatAmount] [money] NULL,
	[Notes] [nvarchar](255) NOT NULL,
	[Posted] [bit] NULL,
	[Cancelled] [bit] NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_ApIdNo] PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesJournal]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesJournal](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDate] [date] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[ReferenceNo] [varchar](15) NULL,
	[Notes] [nvarchar](255) NULL,
	[Posted] [bit] NOT NULL,
	[Cancelled] [bit] NOT NULL,
	[DateCreated] [datetime] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_SalesJournal] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CkJournal]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CkJournal](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDate] [date] NOT NULL,
	[ReferenceNo] [varchar](15) NULL,
	[Amount] [money] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[PaymentType] [char](1) NULL,
	[PayeeIdNo] [int] NULL,
	[PayeeName] [nvarchar](50) NULL,
	[CheckNumber] [varchar](10) NULL,
	[CheckDate] [date] NULL,
	[ORNumber] [varchar](15) NULL,
	[DiscountTaken] [money] NULL,
	[DiscountAccountIdNo] [smallint] NULL,
	[Applied] [money] NULL,
	[UnApplied] [money] NULL,
	[VatNumber] [varchar](15) NULL,
	[VatAmount] [money] NULL,
	[Notes] [nvarchar](254) NULL,
	[Posted] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[Cancelled] [bit] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_ChequeDisbursementJournal1] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesJournalItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesJournalItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [smallint] NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[Notes] [nvarchar](100) NOT NULL,
	[Debit] [money] NOT NULL,
	[Credit] [money] NOT NULL,
	[RevCostCenterIdNo] [smallint] NOT NULL,
	[Posted] [bit] NOT NULL,
 CONSTRAINT [PK_SalesJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CkJournalItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CkJournalItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [smallint] NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[Debit] [money] NOT NULL,
	[Credit] [money] NOT NULL,
	[RevCostCenterIdNo] [smallint] NULL,
	[Notes] [nvarchar](300) NOT NULL,
	[Posted] [bit] NOT NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_ChequeDisbursementJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeCode] [varchar](10) NULL,
	[Title] [varchar](25) NULL,
	[EmployeeName] [varchar](75) NOT NULL,
	[EmployeeNameAra] [nvarchar](75) NULL,
	[Gender] [varchar](1) NULL,
	[BirthDate] [date] NULL,
	[MaritalStatus] [char](1) NULL,
	[NationalityCode] [char](2) NULL,
	[NationalityId] [varchar](15) NULL,
	[ReligionIdNo] [smallint] NULL,
	[ReligionId] [varchar](15) NULL,
	[NationalIdNo] [varchar](10) NULL,
	[Street] [nvarchar](50) NULL,
	[District] [nvarchar](50) NULL,
	[TownCity] [nvarchar](50) NULL,
	[ProvinceState] [nvarchar](50) NULL,
	[CountryCode] [char](2) NULL,
	[PoBox] [varchar](15) NULL,
	[ZipCode] [varchar](15) NULL,
	[Phone1] [varchar](15) NULL,
	[Phone2] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
	[DepartmentIdNo] [smallint] NULL,
	[DesignationIdNo] [smallint] NULL,
	[HiredDate] [date] NULL,
	[ReleasedDate] [date] NULL,
	[ArAccountIdNo] [int] NULL,
	[BankIdNo] [int] NULL,
	[BankAccountNo] [varchar](15) NULL,
	[IBAN] [varchar](20) NULL,
	[Notes] [varchar](300) NULL,
	[OpeningBalance] [money] NULL,
	[Balance] [money] NULL,
	[PaymentMethod] [char](1) NULL,
	[PayCycleIdNo] [tinyint] NULL,
	[PayGroupIdNo] [smallint] NULL,
	[PaySalariedOrHourly] [char](1) NULL,
	[PayRateType] [char](1) NULL,
	[PayRateAmount] [money] NULL,
	[Active] [bit] NULL,
	[Create_Date] [datetime] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApJournalItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApJournalItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [int] NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[Debit] [money] NOT NULL,
	[Credit] [money] NOT NULL,
	[RevCostCenterIdNo] [int] NOT NULL,
	[Notes] [nvarchar](300) NOT NULL,
	[Posted] [bit] NOT NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_ApJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[SupplierCode] [varchar](15) NOT NULL,
	[SupplierName] [varchar](50) NOT NULL,
	[SupplierNameAra] [nvarchar](50) NOT NULL,
	[ContactPerson] [nvarchar](50) NULL,
	[ContactDesignation] [nvarchar](15) NULL,
	[Street] [nvarchar](50) NULL,
	[District] [nvarchar](35) NULL,
	[TownCity] [nvarchar](35) NULL,
	[ProvinceState] [nvarchar](35) NULL,
	[CountryCode] [char](2) NULL,
	[POBox] [varchar](10) NULL,
	[ZipCode] [varchar](10) NULL,
	[Phone1] [varchar](15) NULL,
	[Phone2] [varchar](15) NULL,
	[Mobile] [varchar](15) NULL,
	[Fax] [varchar](15) NULL,
	[Email] [varchar](254) NULL,
	[Website] [varchar](254) NULL,
	[VATNumber] [varchar](15) NULL,
	[CRNumber] [varchar](20) NULL,
	[AccountStatus] [char](1) NULL,
	[APAccountIdNo] [smallint] NOT NULL,
	[ExpAccountIdNo] [smallint] NULL,
	[CreditLimit] [money] NULL,
	[SettlementDueDays] [smallint] NULL,
	[SettlementDiscount] [decimal](5, 2) NULL,
	[PaymentDueDays] [smallint] NULL,
	[DateAccountOpen] [datetime] NULL,
	[BankAccountName] [nvarchar](50) NULL,
	[BankAccountNo] [varchar](20) NULL,
	[BankIdNo] [smallint] NULL,
	[IBAN] [varchar](35) NULL,
	[PaymentMethod] [char](2) NULL,
	[Notes] [nvarchar](255) NULL,
	[OpeningBalance] [money] NULL,
	[Active] [bit] NULL,
	[DateCreated] [datetime2](7) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_SupplierDetailsIDNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_SupplierName] UNIQUE NONCLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_SupplierNameAra] UNIQUE NONCLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[ParentIDNo] [smallint] NULL,
	[AccountCode] [varchar](5) NOT NULL,
	[AccountName] [varchar](50) NOT NULL,
	[AccountNameAra] [nvarchar](50) NULL,
	[Notes] [varchar](255) NULL,
	[DetailAccount] [bit] NULL,
	[AccountGroup] [char](1) NULL,
	[BYDebit] [money] NULL,
	[BYCredit] [money] NULL,
	[Debit] [money] NULL,
	[Credit] [money] NULL,
	[NormalBalance] [char](1) NULL,
	[CloseDebit] [money] NULL,
	[CloseCredit] [money] NULL,
	[PayeeType] [char](1) NULL,
	[WithReconciliation] [bit] NULL,
	[IncomeExpSummary] [bit] NULL,
	[Active] [bit] NULL,
	[SpecialAccount] [char](2) NULL,
	[GroupSortOrder] [smallint] NULL,
	[CreateDate] [datetime2](7) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK__AccountIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_AccountCode] UNIQUE NONCLUSTERED 
(
	[AccountCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_AccountName] UNIQUE NONCLUSTERED 
(
	[AccountName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_AccountNameAra] UNIQUE NONCLUSTERED 
(
	[AccountNameAra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[CustomerCode] [nvarchar](50) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[CustomerNameAra] [nvarchar](50) NOT NULL,
	[ContactPerson] [nvarchar](50) NULL,
	[ContactDesignation] [nvarchar](15) NULL,
	[Street] [nvarchar](50) NULL,
	[District] [nvarchar](35) NULL,
	[TownCity] [nvarchar](35) NULL,
	[ProvinceState] [nvarchar](35) NULL,
	[CountryCode] [char](2) NULL,
	[POBox] [varchar](10) NULL,
	[ZipCode] [varchar](10) NULL,
	[Phone1] [varchar](15) NULL,
	[Phone2] [varchar](15) NULL,
	[Mobile] [varchar](15) NULL,
	[Fax] [varchar](15) NULL,
	[Email] [varchar](254) NULL,
	[Website] [varchar](254) NULL,
	[VATNumber] [varchar](15) NULL,
	[CRNumber] [varchar](20) NULL,
	[AccountStatus] [char](1) NULL,
	[ARAccountIdNo] [smallint] NULL,
	[RevAccountIdNo] [smallint] NULL,
	[DiscountSchemeIdNo] [int] NULL,
	[CreditLimit] [money] NULL,
	[SettlementDueDays] [smallint] NULL,
	[SettlementDiscount] [decimal](5, 2) NULL,
	[PaymentDueDays] [smallint] NULL,
	[DateAccountOpen] [datetime] NULL,
	[BankAccountName] [nvarchar](50) NULL,
	[BankAccountNo] [varchar](20) NULL,
	[BankIdNo] [smallint] NULL,
	[IBAN] [varchar](35) NULL,
	[PaymentMethod] [char](2) NULL,
	[Notes] [nvarchar](255) NULL,
	[OpeningBalance] [money] NULL,
	[Active] [bit] NULL,
	[DateCreated] [datetime2](7) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_CustomerDetailsIDNo2] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_CustomerName2] UNIQUE NONCLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_CustomerNameAra2] UNIQUE NONCLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArJournal]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArJournal](
	[IDNo] [int] IDENTITY(1,1) NOT NULL,
	[CustomerIdNo] [int] NOT NULL,
	[TransactionDate] [date] NULL,
	[ReferenceNo] [varchar](15) NULL,
	[TransactionType] [char](1) NULL,
	[Amount] [money] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[DueDate] [date] NULL,
	[SettlementDueDate] [date] NULL,
	[SettlementDiscount] [decimal](5, 2) NULL,
	[InvoiceNo] [varchar](15) NOT NULL,
	[InvoiceDate] [date] NULL,
	[Notes] [nvarchar](255) NOT NULL,
	[Posted] [bit] NULL,
	[Cancelled] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_ArJournal] PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArJournalItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArJournalItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [int] NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[Debit] [money] NOT NULL,
	[Credit] [money] NOT NULL,
	[RevCostCenterIdNo] [int] NOT NULL,
	[Notes] [nvarchar](300) NOT NULL,
	[Posted] [bit] NOT NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_ArJournalItem] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErJournal]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErJournal](
	[IDNo] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeIdNo] [int] NOT NULL,
	[TransactionDate] [date] NULL,
	[ReferenceNo] [varchar](15) NULL,
	[TransactionType] [char](1) NULL,
	[Amount] [money] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[Notes] [nvarchar](255) NOT NULL,
	[Posted] [bit] NULL,
	[Cancelled] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_ErIdNo] PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErJournalItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErJournalItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [smallint] NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[Debit] [money] NOT NULL,
	[Credit] [money] NOT NULL,
	[RevCostCenterIdNo] [smallint] NOT NULL,
	[Notes] [nvarchar](300) NOT NULL,
	[Posted] [bit] NOT NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_ErJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GlLedgers_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









CREATE VIEW [dbo].[GlLedgers_View]	
  AS
(SELECT 'GJ' AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.[AccountCode]
      ,a.[Debit]
      ,a.[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]  COLLATE Arabic_CI_AS AS 'Notes'
	  ,a.[Posted]
	  ,[TransactionDate] 
      ,[ReferenceNo] COLLATE Arabic_CI_AS AS 'ReferenceNo'
	  ,'' COLLATE Arabic_CI_AS AS 'DocumentNumber'
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes])) COLLATE Arabic_CI_AS AS 'PayDescription'
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes])) COLLATE Arabic_CI_AS AS 'PayDescriptionAra'
	  ,[ClosingJournal]
  FROM [dbo].[GeneralJournalItem] a
  LEFT OUTER JOIN dbo.GeneralJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
)
UNION
(SELECT 'AP' 
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
      ,[RevCostCenterIdNo]
      ,a.[Notes]
      ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo] 
	  ,[InvoiceNo] 
	  ,[SupplierName] 
	  ,[SupplierNameAra] 
	  ,CAST(0 AS BIT) 
  FROM [dbo].[ApJournalItem] a
  LEFT OUTER JOIN dbo.[ApJournal] b
  on a.JournalIdNo = b.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] c
  on b.SupplierIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
)
UNION
(SELECT 'AR' AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
      ,[RevCostCenterIdNo]
      ,a.[Notes]
      ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[InvoiceNo] AS 'DocumentNumber'
	  ,[CustomerName]
	  ,[CustomerNameAra]
	  ,CAST(0 AS BIT)
  FROM [dbo].[ArJournalItem] a
  LEFT OUTER JOIN dbo.ArJournal b
  on a.JournalIdNo = b.IdNo 
  LEFT OUTER JOIN dbo.[Customer] c
  on b.CustomerIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
)
UNION
(SELECT 'ER' 
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
      ,[RevCostCenterIdNo]
      ,a.[Notes]
      ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[ReferenceNo] AS 'DocumentNumber'
	  ,[EmployeeName]
	  ,[EmployeeNameAra]
	  ,CAST(0 AS BIT)
  FROM [dbo].[ErJournalItem] a
  LEFT OUTER JOIN dbo.ErJournal b
  on a.JournalIdNo = b.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.EmployeeIdNO = e.IdNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
)
UNION
(SELECT 'CK'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,Coalesce('Chk#' + [CheckNumber],'')
	  ,CASE
			WHEN b.PaymentType = 'A' then s.SupplierName
			WHEN b.PaymentType = 'R' then c.CustomerName
			WHEN b.PaymentType = 'S' then s.SupplierName
			WHEN b.PaymentType = 'E' then e.EmployeeName
			WHEN b.PaymentType = 'O' then b.PayeeName
			ELSE b.PayeeName
	   END
	  ,CASE
			WHEN b.PaymentType = 'A' then s.SupplierNameAra
			WHEN b.PaymentType = 'R' then c.CustomerNameAra
			WHEN b.PaymentType = 'S' then s.SupplierNameAra
			WHEN b.PaymentType = 'E' then e.EmployeeNameAra
			WHEN b.PaymentType = 'O' then b.PayeeName
			ELSE b.PayeeName
	   END
	   ,CAST(0 AS BIT)
  FROM [dbo].[CkJournalItem] a
  LEFT OUTER JOIN dbo.CkJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayeeIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayeeIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IDNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
)
UNION
(SELECT 'CD'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,'Inv#'+[ORNUMBER] 
	  ,CASE
			WHEN b.PaymentType = 'A' then s.SupplierName
			WHEN b.PaymentType = 'R' then c.CustomerName
			WHEN b.PaymentType = 'S' then s.SupplierName
			WHEN b.PaymentType = 'E' then e.EmployeeName
			WHEN b.PaymentType = 'O' then b.PayeeName
			ELSE b.PayeeName
	   END
	  ,CASE
			WHEN b.PaymentType = 'A' then s.SupplierNameAra
			WHEN b.PaymentType = 'R' then c.CustomerNameAra
			WHEN b.PaymentType = 'S' then s.SupplierNameAra
			WHEN b.PaymentType = 'E' then e.EmployeeNameAra
			WHEN b.PaymentType = 'O' then b.PayeeName
			ELSE b.PayeeName
	   END
	  ,CAST(0 AS BIT)
  FROM [dbo].[CdJournalItem] a
  LEFT OUTER JOIN dbo.CdJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayeeIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayeeIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IDNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
)
UNION
(SELECT 'CR'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,Case
		When [ORNUMBER] IS NULL AND [CheckNumber] IS NULL Then ''
		When [ORNUMBER] IS NULL Then 'Chk#'+RTrim([CheckNumber])
		ELSE 'OR# ' + RTrim([ORNUMBER]) + ' / Chk#' + RTrim([CheckNumber])
	   End
	  ,CASE
			WHEN b.PayorType = 'A' then s.SupplierName
			WHEN b.PayorType = 'C' then c.CustomerName
			WHEN b.PayorType = 'R' then c.CustomerName
			WHEN b.PayorType = 'E' then e.EmployeeName
			WHEN b.PayorType = 'O' then b.PayorName
			ELSE b.PayorName
	   END
	  ,CASE
			WHEN b.PayorType = 'A' then s.SupplierNameAra
			WHEN b.PayorType = 'C' then c.CustomerNameAra
			WHEN b.PayorType = 'R' then c.CustomerNameAra
			WHEN b.PayorType = 'E' then e.EmployeeNameAra
			WHEN b.PayorType = 'O' then b.PayorName
			ELSE b.PayorName
	   END
	  ,CAST(0 AS BIT)
  FROM [dbo].[CashReceiptJournalItem] a
  LEFT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayorIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayorIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayorIdNo = e.IDNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
)
UNION
(SELECT 'PC'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,'Inv#'+[ORNUMBER] 
	  ,CASE
			WHEN b.PaymentType = 'A' then s.SupplierName
			WHEN b.PaymentType = 'R' then c.CustomerName
			WHEN b.PaymentType = 'S' then s.SupplierName
			WHEN b.PaymentType = 'E' then e.EmployeeName
			WHEN b.PaymentType = 'O' then b.PayeeName
			ELSE b.PayeeName
	   END
	  ,CASE
			WHEN b.PaymentType = 'A' then s.SupplierNameAra
			WHEN b.PaymentType = 'R' then c.CustomerNameAra
			WHEN b.PaymentType = 'S' then s.SupplierNameAra
			WHEN b.PaymentType = 'E' then e.EmployeeNameAra
			WHEN b.PaymentType = 'O' then b.PayeeName
			ELSE b.PayeeName
	   END
	  ,CAST(0 AS BIT)
  FROM [dbo].[PcJournalItem] a
  LEFT OUTER JOIN dbo.PcJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayeeIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayeeIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IDNo 
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
)
UNION
(SELECT 'SJ'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
	  ,ch.AccountCode
      ,a.[Debit]
      ,a.[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,''
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes]))
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes]))
	  ,CAST(0 AS BIT)
  FROM [dbo].[SalesJournalItem] a
  LEFT OUTER JOIN dbo.SalesJournal b
  on a.JournalIdNo = b.Idno
  LEFT OUTER JOIN dbo.Account ch
  ON a.AccountIdNo = ch.IdNo
)
GO
/****** Object:  Table [dbo].[ApOpenInvoice]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApOpenInvoice](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[JournalCode] [varchar](100) NULL,
	[JournalIdNo] [int] NOT NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[PaidAmount] [money] NOT NULL,
	[DiscountTaken] [money] NOT NULL,
 CONSTRAINT [PK_ApOpenInvoice] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LastPosting]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LastPosting](
	[IdNo] [int] NULL,
	[LastPostingDate] [date] NULL,
	[TransactionName] [varchar](25) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DefaultAccounts]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefaultAccounts](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[AccountIdNo] [smallint] NULL,
	[SpecialAccount] [char](2) NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[APDetails_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO












CREATE VIEW [dbo].[APDetails_View]	
  AS
(SELECT 'AP' AS 'JournalCode'
	  ,ai.[IdNo]
      ,ai.[Sequence]
      ,ai.[JournalIdNo]
      ,ai.[AccountIdNo]
      ,ai.[Debit]
      ,ai.[Credit]
      ,ai.[RevCostCenterIdNo]
      ,ai.[Notes] Collate Arabic_CI_AS AS 'Notes'
      ,ai.[Posted]
	  ,b.[SupplierIdNo]
	  ,b.[InvoiceNo] Collate Arabic_CI_AS AS 'InvoiceNo'
	  ,b.[TransactionDate]
      ,b.[ReferenceNo] Collate Arabic_CI_AS AS 'ReferenceNo'
	  ,b.[TransactionType] Collate SQL_Latin1_General_CP1_CI_AS AS 'TransactionType'
	  ,b.Notes Collate Arabic_CI_AS AS 'MainNote'
  FROM [ApJournalItem] aS ai
  LEFT OUTER JOIN ApJournal AS b
  on ai.JournalIdNo = b.IDNo 
)
UNION
(SELECT 'CK'
	  ,ai.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,ai.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,ai.[Notes]
	  ,ai.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [CkJournalItem] ai
  LEFT OUTER JOIN CkJournal b
  on ai.JournalIdNo = b.IDNo
  WHERE PaymentType='A'
)
UNION
(SELECT 'CD'
	  ,ai.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,ai.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,ai.[Notes]
	  ,ai.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [CdJournalItem] ai
  LEFT OUTER JOIN dbo.CdJournal b
  on ai.JournalIdNo = b.IDNo
  WHERE PaymentType='A'
)
UNION
(SELECT 'PC'
	  ,ai.[IdNo]
      ,ai.[Sequence]
	  ,ai.[JournalIdNo]
      ,ai.[AccountIdNo]
      ,ai.[Debit]
      ,ai.[Credit]
	  ,ai.[RevCostCenterIdNo]
      ,ai.[Notes]
	  ,ai.[Posted]
	  ,b.[PayeeIdNo]
	  ,b.[ReferenceNo]
	  ,b.[TransactionDate]
      ,b.[ReferenceNo]
	  ,b.[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [PcJournalItem] as ai
  LEFT OUTER JOIN PcJournal as b
  on ai.JournalIdNo = b.IDNo
  WHERE PaymentType='A'
)
UNION
(SELECT 'CR'
	  ,ai.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,ai.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,ai.[Notes]
	  ,ai.[Posted]
	  ,[PayorIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PayorType]
	  ,b.Notes AS 'MainNote'
  FROM [CashReceiptJournalItem] as ai
  LEFT OUTER JOIN dbo.CashReceiptJournal as b
  on ai.JournalIdNo = b.IDNo
  WHERE PayorType='R'
)
UNION
(SELECT 'BB' 
	  ,IdNo
      ,1
      ,IdNo
      ,(Select AccountIdNo from DefaultAccounts where SpecialAccount='AP')
      ,case 
		when OpeningBalance < 0 then OpeningBalance * -1
		else 0
	   end 
      ,case 
		when OpeningBalance > 0 then OpeningBalance 
		else 0
	   end 
	  ,0
      ,'Beginning Balance'
      ,1
	  ,IdNo
	  ,'Beg.Bal.'
	  ,(Select LastPostingDate from LastPosting where TransactionName = 'First Record')
      ,'Beg.Bal.'
	  ,case 
		when OpeningBalance >=0 then 'C'
		else 'D'
	   end 
	  ,'Beginning Balance'
  FROM [dbo].Supplier 
)
GO
/****** Object:  View [dbo].[ApOpenInvoice_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE VIEW [dbo].[ApOpenInvoice_View]
AS
SELECT			dbo.ApOpenInvoice.IdNo,
				dbo.ApOpenInvoice.JournalCode, 
				dbo.ApOpenInvoice.JournalItemIdNo, 
				dbo.APDetails_View.Credit - dbo.APDetails_View.Debit AS Amount, 
				IsNull(dbo.ApPayments_View.Amount,0) as 'PaidAmount', 
				IsNull(dbo.ApPayments_View.DiscountTaken,0) as 'DiscountTaken', 
				dbo.APDetails_View.Credit - dbo.APDetails_View.Debit - IsNull(dbo.ApPayments_View.Amount,0) - IsNull(dbo.ApPayments_View.DiscountTaken,0) AS Balance, 
                dbo.APDetails_View.Credit - dbo.APDetails_View.Debit AS InvoiceAmount, 
				dbo.ApOpenInvoice.JournalIdNo, 
				dbo.APDetails_View.AccountIdNo, 
				dbo.APDetails_View.SupplierIdNo, 
				dbo.APDetails_View.ReferenceNo, 
                dbo.APDetails_View.TransactionType, 
				dbo.APDetails_View.TransactionDate, 
				dbo.APDetails_View.InvoiceNo, 
				dbo.APDetails_View.Notes, 
				dbo.Account.AccountCode, 
				dbo.Account.AccountName, 
				dbo.Account.AccountNameAra, 
                dbo.Account.SpecialAccount
FROM            dbo.ApOpenInvoice 
				LEFT OUTER JOIN dbo.APDetails_View 
				ON dbo.ApOpenInvoice.JournalItemIdNo = dbo.APDetails_View.IdNo AND dbo.ApOpenInvoice.JournalCode = dbo.APDetails_View.JournalCode Collate SQL_Latin1_General_CP1_CI_AS
				LEFT OUTER JOIN dbo.ApPayments_View
				ON dbo.ApOpenINvoice.IdNo = dbo.ApPayments_View.ApOpenInvoiceIdNo
				LEFT OUTER JOIN dbo.Account 
				ON dbo.APDetails_View.AccountIdNo = dbo.Account.IDNo
GO
/****** Object:  Table [dbo].[OriginalCaptions]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OriginalCaptions](
	[idno] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [varchar](128) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_Original] PRIMARY KEY CLUSTERED 
(
	[idno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TranslatedCaption]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TranslatedCaption](
	[idno] [int] IDENTITY(1,1) NOT NULL,
	[CaptionIdNo] [int] NOT NULL,
	[LanguageIdNo] [smallint] NOT NULL,
	[TranslatedCaption] [nvarchar](256) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_TranslatedIdNo] PRIMARY KEY CLUSTERED 
(
	[idno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[IdNo] [smallint] IDENTITY(0,1) NOT NULL,
	[CultureInfoCode] [varchar](15) NOT NULL,
	[Country] [varchar](50) NULL,
	[Iso2Code] [char](2) NULL,
	[Language] [varchar](30) NULL,
	[LanguageCode2] [char](3) NULL,
	[LanguageCode3] [char](3) NULL,
 CONSTRAINT [PK_LanguagesIdNo2] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Captions_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Captions_View]
AS
SELECT        dbo.TranslatedCaption.idno, dbo.TranslatedCaption.CaptionIdNo, dbo.TranslatedCaption.LanguageIdNo, dbo.TranslatedCaption.TranslatedCaption, dbo.Languages.CultureInfoCode, dbo.OriginalCaptions.Caption, dbo.Languages.LanguageCode2
FROM            dbo.TranslatedCaption 
				INNER JOIN dbo.Languages 
				ON dbo.TranslatedCaption.LanguageIdNo = dbo.Languages.IdNo 
				RIGHT OUTER JOIN dbo.OriginalCaptions
				ON dbo.TranslatedCaption.CaptionIdNo = dbo.OriginalCaptions.idno
GO
/****** Object:  Table [dbo].[RevCostCenter]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RevCostCenter](
	[IDNo] [smallint] IDENTITY(1,1) NOT NULL,
	[RevCostCenterCode] [varchar](5) NOT NULL,
	[RevCostCenterName] [varchar](50) NOT NULL,
	[RevCostCenterNameAra] [nvarchar](50) NOT NULL,
	[ParentIdNo] [smallint] NULL,
	[RCType] [char](1) NOT NULL,
	[Notes] [varchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_RevCostCenterIdNo] PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CdJournalTransaction_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

cREATE VIEW [dbo].[CdJournalTransaction_View]
AS
SELECT        dbo.CdJournal.IdNo, dbo.CdJournal.TransactionDate, dbo.CdJournal.ReferenceNo, dbo.CdJournal.Amount, dbo.CdJournal.PayeeIdNo, 
                         dbo.CdJournal.PaymentType, dbo.CdJournal.PayeeName, dbo.CdJournalItem.Sequence, dbo.CdJournalItem.Debit, dbo.CdJournalItem.Credit, 
                         dbo.CdJournalItem.RevCostCenterIdNo, dbo.CdJournalItem.Notes, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra, dbo.Customer.CustomerCode, 
                         dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierNameAra, dbo.Employee.EmployeeCode, dbo.Employee.EmployeeName, 
                         dbo.Employee.EmployeeNameAra, dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.CdJournal.Notes AS CdNote, dbo.BankAccount.BranchName, dbo.Bank.BankCode, 
                         dbo.Bank.BankName, dbo.Bank.BankNameAra
FROM            dbo.BankAccount LEFT OUTER JOIN
                         dbo.Bank ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo RIGHT OUTER JOIN
                         dbo.CdJournal ON dbo.BankAccount.AccountIdNo = dbo.CdJournal.AccountIdNo LEFT OUTER JOIN
                         dbo.Account RIGHT OUTER JOIN
                         dbo.CdJournalItem ON dbo.Account.IdNo = dbo.CdJournalItem.AccountIdNo LEFT OUTER JOIN
                         dbo.RevCostCenter ON dbo.CdJournalItem.RevCostCenterIdNo = dbo.RevCostCenter.IDNo ON dbo.CdJournal.IdNo = dbo.CdJournalItem.JournalIdNo LEFT OUTER JOIN
                         dbo.Customer ON dbo.CdJournal.PayeeIdNo = dbo.Customer.IdNo LEFT OUTER JOIN
                         dbo.Supplier ON dbo.CdJournal.PayeeIdNo = dbo.Supplier.IdNo LEFT OUTER JOIN
                         dbo.Employee ON dbo.CdJournal.PayeeIdNo = dbo.Employee.IdNo
GO
/****** Object:  View [dbo].[PcJournal_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PcJournal_View]
AS
SELECT        dbo.PcJournal.IdNo, dbo.PcJournal.TransactionDate, dbo.PcJournal.ReferenceNo, dbo.PcJournal.Amount, dbo.PcJournal.AccountIdNo, dbo.PcJournal.PaymentType, dbo.PcJournal.PayeeIdNo, dbo.PcJournal.PayeeName, 
                         dbo.PcJournal.ORNumber, dbo.PcJournal.DiscountTaken, dbo.PcJournal.DiscountAccountIdNo, dbo.PcJournal.Applied, dbo.PcJournal.UnApplied, dbo.PcJournal.VatNumber, dbo.PcJournal.VatAmount, dbo.PcJournal.Notes, 
                         dbo.PcJournal.Posted, dbo.PcJournal.DateCreated, dbo.PcJournal.Cancelled, dbo.PcJournal.DateTimeStamp, dbo.currency_conversion(dbo.PcJournal.Amount) AS WordAmount, dbo.Bank.BankCode, dbo.Bank.BankNameAra, 
                         dbo.BankAccount.BranchName
FROM            dbo.Bank LEFT OUTER JOIN
                         dbo.BankAccount ON dbo.Bank.IdNo = dbo.BankAccount.BankIdNo RIGHT OUTER JOIN
                         dbo.PcJournal ON dbo.BankAccount.AccountIdNo = dbo.PcJournal.AccountIdNo
GO
/****** Object:  View [dbo].[ARDetails_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO












CREATE VIEW [dbo].[ARDetails_View]	
  AS
(SELECT 'AR' AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
      ,[RevCostCenterIdNo]
      ,a.[Notes] COLLATE Arabic_CI_AS AS 'Notes'
      ,a.[Posted]
	  ,[CustomerIdNo]
	  ,[InvoiceNo] COLLATE Arabic_CI_AS AS 'InvoiceNo'
	  ,[TransactionDate]
      ,[ReferenceNo] COLLATE Arabic_CI_AS AS 'ReferenceNo'
	  ,[TransactionType] COLLATE SQL_Latin1_General_CP1_CI_AS AS 'TransactionType'
	  ,b.Notes COLLATE Arabic_CI_AS AS 'MainNote'
  FROM [dbo].[ArJournalItem] a
  RIGHT OUTER JOIN dbo.ArJournal b
  on a.JournalIdNo = b.IDNo 
)
UNION
(SELECT 'CR'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[PayorIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PayorType]
	  ,b.Notes AS 'MainNote'
  FROM [dbo].[CashReceiptJournalItem] A
  RIGHT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PayorType='A'
)
UNION
(SELECT 'CK'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [dbo].[CkJournalItem] A
  LEFT OUTER JOIN dbo.CkJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='R'
)
UNION
(SELECT 'CD'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [dbo].[CdJournalItem] A
  LEFT OUTER JOIN dbo.CdJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='R'
)
UNION
(SELECT 'PC'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [dbo].[PcJournalItem] A
  LEFT OUTER JOIN dbo.PcJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='R'
)
UNION
(SELECT 'BB' 
	  ,IdNo
      ,1
      ,IdNo
      ,(Select AccountIdNo from DefaultAccounts where SpecialAccount='AR')
      ,case 
		when OpeningBalance >=0 then OpeningBalance
		else 0
	   end 
      ,case 
		when OpeningBalance < 0 then OpeningBalance * -1
		else 0
	   end 
	  ,0
      ,'Beginning Balance'
      ,1
	  ,IdNo
	  ,'Beg.Bal.'
	  ,(Select LastPostingDate from LastPosting where TransactionName = 'First Record')
      ,'Beg.Bal.'
	  ,case 
		when OpeningBalance >=0 then 'D'
		else 'C'
	   end 
	  ,'Beginning Balance'
  FROM [dbo].Customer 
)
GO
/****** Object:  Table [dbo].[ArOpenInvoice]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArOpenInvoice](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[JournalCode] [char](2) NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[PaidAmount] [money] NULL,
 CONSTRAINT [PK_ArOpenInvoice] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ErJournalItem_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[ErJournalItem_View]
AS
SELECT        dbo.ErJournalItem.IdNo, dbo.ArOpenInvoice.JournalCode, dbo.ErJournalItem.JournalIdNo, dbo.ErJournalItem.AccountIdNo, dbo.ErJournalItem.Debit, dbo.ErJournalItem.Credit, dbo.ErJournalItem.RevCostCenterIdNo, 
                dbo.ErJournalItem.Notes, dbo.ErJournalItem.Posted, dbo.ErJournalItem.DateTimeStamp, dbo.Account.AccountName, dbo.ArOpenInvoice.IdNo AS OpenInvoiceIdNo, 
                dbo.ErJournalItem.Credit - dbo.ErJournalItem.Debit AS OriginalAmount, dbo.ArOpenInvoice.PaidAmount, dbo.ArOpenInvoice.DiscountTaken, dbo.Account.SpecialAccount, dbo.Account.AccountNameAra, dbo.Account.PayeeType, 
                dbo.ErJournalItem.Sequence
FROM            dbo.ErJournalItem 
				LEFT OUTER JOIN dbo.Account 
				ON dbo.ErJournalItem.AccountIdNo = dbo.Account.IDNo 
				LEFT OUTER JOIN dbo.ArOpenInvoice 
				ON dbo.ErJournalItem.IdNo = dbo.ArOpenInvoice.JournalItemIdNo AND dbo.ArOpenInvoice.JournalCode = 'ER'
GO
/****** Object:  Table [dbo].[ErOpenInvoice]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErOpenInvoice](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[JournalCode] [char](2) NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[PaidAmount] [money] NOT NULL,
	[DiscountTaken] [money] NOT NULL,
 CONSTRAINT [PK_ErOpenInvoice] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ErDetails_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE VIEW [dbo].[ErDetails_View]	
  AS
(SELECT 'ER' AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
      ,[RevCostCenterIdNo]
      ,a.[Notes] Collate Arabic_CI_AS AS 'Notes'
      ,a.[Posted] 
	  ,[EmployeeIdNo]
	  ,[ReferenceNo] Collate Arabic_CI_AS AS 'InvoiceNo'
	  ,[TransactionDate]
      ,[ReferenceNo] Collate Arabic_CI_AS AS 'ReferenceNo'
	  ,[TransactionType] Collate SQL_Latin1_General_CP1_CI_AS AS 'TransactionType'
	  ,b.Notes Collate Arabic_CI_AS AS 'MainNote'
  FROM [dbo].[ErJournalItem] a
  RIGHT OUTER JOIN dbo.ErJournal b
  on a.JournalIdNo = b.IDNo 
)
UNION
(SELECT 'CR'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[PayorIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PayorType]
	  ,b.Notes
  FROM [dbo].[CashReceiptJournalItem] A
  RIGHT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PayorType='E'
)
UNION
(SELECT 'CK'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes
  FROM [dbo].[CkJournalItem] A
  LEFT OUTER JOIN dbo.CkJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='E'
)
UNION
(SELECT 'CD'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes
  FROM [dbo].[CdJournalItem] A
  LEFT OUTER JOIN dbo.CdJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='E'
)
UNION
(SELECT 'PC'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [dbo].[PcJournalItem] A
  LEFT OUTER JOIN dbo.PcJournal b
  on a.JournalIdNo = b.IDNo
  WHERE PaymentType='E'
)
UNION
(SELECT 'BB' 
	  ,IdNo
      ,1
      ,IdNo
      ,(Select AccountIdNo from DefaultAccounts where SpecialAccount='EL')
      ,case 
		when OpeningBalance >=0 then OpeningBalance
		else 0
	   end 
      ,case 
		when OpeningBalance < 0 then OpeningBalance * -1
		else 0
	   end 
	  ,0
      ,'Beginning Balance'
      ,1
	  ,IdNo
	  ,'Beg.Bal.'
	  ,(Select LastPostingDate from LastPosting where TransactionName = 'First Record')
      ,'Beg.Bal.'
	  ,case 
		when OpeningBalance >=0 then 'D'
		else 'C'
	   end 
	  ,'Beginning Balance'
  FROM [dbo].Employee 
)
GO
/****** Object:  View [dbo].[ErOpenInvoice_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ErOpenInvoice_View]
AS
SELECT        dbo.ErOpenInvoice.IdNo, dbo.ErOpenInvoice.JournalCode, dbo.ErOpenInvoice.JournalItemIdNo, dbo.ErDetails_View.Debit - dbo.ErDetails_View.Credit AS Amount, dbo.ErOpenInvoice.PaidAmount, 
                         dbo.ErOpenInvoice.DiscountTaken, dbo.ErDetails_View.Debit - dbo.ErDetails_View.Credit - dbo.ErOpenInvoice.PaidAmount - dbo.ErOpenInvoice.DiscountTaken AS Balance, 
                         dbo.ErDetails_View.Debit - dbo.ErDetails_View.Credit AS InvoiceAmount, dbo.ErOpenInvoice.JournalIdNo, dbo.ErDetails_View.AccountIdNo, dbo.ErDetails_View.EmployeeIdNo, 
                         dbo.ErDetails_View.ReferenceNo, dbo.ErDetails_View.TransactionType, dbo.ErDetails_View.TransactionDate, dbo.ErDetails_View.InvoiceNo, dbo.ErDetails_View.Notes, dbo.Account.AccountCode, 
                         dbo.Account.AccountName, dbo.Account.AccountNameAra, dbo.Account.SpecialAccount, dbo.Customer.CustomerCode
FROM            dbo.Customer RIGHT OUTER JOIN
                         dbo.ErDetails_View ON dbo.Customer.IdNo = dbo.ErDetails_View.EmployeeIdNo RIGHT OUTER JOIN
                         dbo.ErOpenInvoice ON dbo.ErDetails_View.IdNo = dbo.ErOpenInvoice.JournalItemIdNo AND 
                         dbo.ErDetails_View.JournalCode COLLATE SQL_Latin1_General_CP1_CI_AS = dbo.ErOpenInvoice.JournalCode LEFT OUTER JOIN
                         dbo.Account ON dbo.ErDetails_View.AccountIdNo = dbo.Account.IDNo
GO
/****** Object:  View [dbo].[ARInvoices_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

















CREATE VIEW [dbo].[ARInvoices_View]	
  AS
(SELECT 'AR' AS 'JournalCode'
	  ,a.[IdNo] 
      ,a.[JournalIdNo]
      ,a.[AccountIdNo]
      ,a.[Debit]-a.[Credit] as 'Amount'
	  ,b.[CustomerIdNo]
	  ,b.[InvoiceNo] COLLATE Arabic_CI_AS AS 'InvoiceNo'
	  ,b.[TransactionDate]
      ,b.[ReferenceNo] COLLATE Arabic_CI_AS AS 'ReferenceNo'
  FROM [dbo].[ArJournalItem] a
  RIGHT OUTER JOIN dbo.ArJournal b
  on a.JournalIdNo = b.IDNo 
  LEFT Outer Join [dbo].[Account] c
  on a.AccountIdNo = c.idno
  where c.SpecialAccount='AR'
)
UNION
(SELECT 'CR'
	  ,a.[IdNo]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,a.[Debit]-a.[Credit]
	  ,[PayorIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
  FROM [dbo].[CashReceiptJournalItem] A
  RIGHT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IDNo
  LEFT Outer Join [dbo].[Account] c
  on a.AccountIdNo = c.idno 
  WHERE PayorType='A' AND B.UnApplied<>0 and (c.SpecialAccount='CA' OR c.SpecialAccount='AR')
)
UNION
(SELECT 'CK'
	  ,a.[IdNo]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,a.[Debit]-a.[Credit]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]  
  FROM [dbo].[CkJournalItem] A
  LEFT OUTER JOIN dbo.CkJournal b
  on a.JournalIdNo = b.IDNo
  LEFT Outer Join [dbo].[Account] c
  on a.AccountIdNo = c.idno
  WHERE PaymentType='R' AND C.SpecialAccount='AR'
)
UNION
(SELECT 'CD'
	  ,a.[IdNo]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,a.[Debit]-a.[Credit]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
  FROM [dbo].[CdJournalItem] A
  LEFT OUTER JOIN dbo.CdJournal b
  on a.JournalIdNo = b.IDNo
  LEFT Outer Join [dbo].[Account] c
  on a.AccountIdNo = c.idno
  WHERE PaymentType='R' AND c.SpecialAccount='AR'
)
UNION
(SELECT 'PC'
	  ,a.[IdNo]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,a.[Debit]-a.[Credit]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
  FROM [dbo].[PcJournalItem] A
  LEFT OUTER JOIN dbo.PcJournal b
  on a.JournalIdNo = b.IDNo
  LEFT Outer Join [dbo].[Account] c
  on a.AccountIdNo = c.idno
  WHERE PaymentType='R' AND c.SpecialAccount='AR'
)
UNION
(SELECT 'BB' 
	  ,IdNo
      ,1
      ,(Select AccountIdNo from DefaultAccounts where SpecialAccount='AR')
      ,OpeningBalance
	  ,IdNo
	  ,'Beg.Bal.'
	  ,(Select LastPostingDate from LastPosting where TransactionName = 'First Record')
      ,'Beg.Bal.'
   FROM [dbo].Customer 
)
GO
/****** Object:  View [dbo].[CdJournalItem_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[CdJournalItem_View]
AS
SELECT        dbo.CdJournalItem.AccountIdNo, dbo.CdJournalItem.Credit, dbo.CdJournalItem.Debit, dbo.CdJournalItem.IdNo, 
                         dbo.CdJournalItem.JournalIdNo, dbo.CdJournalItem.Notes, dbo.CdJournalItem.RevCostCenterIdNo, dbo.CdJournalItem.Sequence, 
                         dbo.Account.AccountName, dbo.CdJournalItem.Debit - dbo.CdJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.CdJournal LEFT OUTER JOIN
                         dbo.CdJournalItem ON dbo.CdJournal.IdNo = dbo.CdJournalItem.JournalIdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.CdJournalItem.AccountIdNo = dbo.Account.IDNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CdJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  Table [dbo].[CsrOiItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CsrOiItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[CsrIdNo] [int] NOT NULL,
	[ArOpenInvoiceIdNo] [int] NOT NULL,
	[Sequence] [smallint] NOT NULL,
	[Amount] [money] NOT NULL,
	[DiscountTaken] [money] NOT NULL,
 CONSTRAINT [PK_CsrOiItemIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ArCollections_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ArCollections_View] as
SELECT TOP (1000) a.[IdNo]
      ,[JournalCode]
      ,[JournalIdNo]
      ,[JournalItemIdNo]
      ,IsNull(sum(b.amount),0) as 'PaidAmount'
	  ,IsNull(sum(b.DiscountTaken) ,0) as 'DiscountTaken'
  FROM [dbo].[ArOpenInvoice] a
  left join CsrOiItem b
  on a.IdNo = b.ArOpenInvoiceIdNo
  group by a.IdNo,a.JournalCode,a.JournalIdNo, a.JournalItemIdNo
GO
/****** Object:  View [dbo].[ArOpenInvoice_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [dbo].[ArOpenInvoice_View] as
(SELECT      a.IdNo, 
			a.JournalCode, 
			a.JournalItemIdNo, 
			d.Debit - d.Credit AS Amount, 
			co.PaidAmount, 
			co.DiscountTaken, 
			d.Debit - d.Credit - co.PaidAmount - co.DiscountTaken AS 'Balance', 
			a.JournalIdNo, 
			d.AccountIdNo, 
			d.CustomerIdNo, 
            d.ReferenceNo, 
			d.TransactionType, 
			d.TransactionDate, 
			d.InvoiceNo, 
			d.Notes, 
			c.AccountCode, 
			c.AccountName, 
			c.AccountNameAra, 
			c.SpecialAccount, 
			cs.CustomerCode
FROM        dbo.ArOpenInvoice a
			Left Join dbo.ArCollections_View co
			on a.IdNo = co.IdNo
			Left Join dbo.ARDetails_View d
			ON d.IdNo = a.JournalItemIdNo AND a.JournalCode COLLATE SQL_Latin1_General_CP1_CI_AS = d.JournalCode 
			Left Join dbo.Customer cs
			ON d.CustomerIdNo = cs.IdNo
			Left Join dbo.Account c	
			ON d.AccountIdNo = c.IDNo)
GO
/****** Object:  View [dbo].[PcJournalItem_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[PcJournalItem_View]
AS
SELECT        dbo.PcJournalItem.AccountIdNo, dbo.PcJournalItem.Credit, dbo.PcJournalItem.Debit, dbo.PcJournalItem.IdNo, 
                         dbo.PcJournalItem.JournalIdNo, dbo.PcJournalItem.Notes, dbo.PcJournalItem.RevCostCenterIdNo, dbo.PcJournalItem.Sequence, 
                         dbo.Account.AccountName, dbo.PcJournalItem.Debit - dbo.PcJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.PcJournal LEFT OUTER JOIN
                         dbo.PcJournalItem ON dbo.PcJournal.IdNo = dbo.PcJournalItem.JournalIdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.PcJournalItem.AccountIdNo = dbo.Account.IDNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.PcJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  View [dbo].[ApJournal_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ApJournal_View]
AS
/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) a.[IDNo]
      ,a.[SupplierIdNo]
      ,a.[TransactionDate]
      ,a.[ReferenceNo]
      ,a.[TransactionType]
      ,a.[Amount]
      ,a.[AccountIdNo]
      ,a.[DueDate]
      ,a.[SettlementDueDate]
      ,a.[SettlementDiscount]
      ,a.[InvoiceNo]
      ,a.[InvoiceDate]
      ,a.[VatNumber]
      ,a.[VatAmount]
      ,a.[Notes]
      ,a.[Posted]
      ,a.[Cancelled]
      ,a.[DateCreated]
      ,a.[DateTimeStamp]
	  ,dbo.currency_conversion(a.Amount) AS WordAmount
	  ,s.SupplierCode
	  ,s.SupplierNameAra
  FROM [dbo].[ApJournal] a
  Left JOIN dbo.Supplier s
  ON SupplierIdNo = s.IdNo
GO
/****** Object:  UserDefinedFunction [dbo].[FuncAcctStatement]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE FUNCTION [dbo].[FuncAcctStatement] (@StartDate Date, @EndDate Date, @BegAccountCode VarChar, @EndAccountCode VarChar)
RETURNS TABLE
AS
RETURN
(   SELECT *,sum(debit-Credit) OVER (PARTITION BY AccountIdNo ORDER By TransactionDate,JournalCode,JournalIdNo,Sequence,idno) AS RTBalance
	FROM dbo.GlLedgers_View 
	WHERE transactiondate >= @StartDate AND 
		  transactiondate <= @EndDate and 
		  AccountCode >= @BegAccountCode and 
		  AccountCode <= @EndAccountCode
)
GO
/****** Object:  Table [dbo].[Payroll]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payroll](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[PayCycleIdNo] [smallint] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[PayrollName] [varchar](50) NULL,
	[PayrollNameAra] [nvarchar](50) NULL,
	[PayrollCode] [varchar](6) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK__PayrollID] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayCycle]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayCycle](
	[IdNo] [tinyint] IDENTITY(1,1) NOT NULL,
	[PayCycleCode] [varchar](5) NOT NULL,
	[PayCycleName] [varchar](50) NOT NULL,
	[PayCycleNameAra] [nvarchar](50) NOT NULL,
	[PayFrequency] [char](1) NULL,
	[Notes] [varchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK__PayCycleID] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Payroll_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Payroll_View]
AS
SELECT        dbo.PayCycle.IdNo, dbo.PayCycle.PayCycleCode, dbo.PayCycle.PayCycleName, dbo.PayCycle.PayFrequency, dbo.PayCycle.PayCycleNameAra, dbo.Payroll.IdNo AS Expr1, dbo.Payroll.StartDate, dbo.Payroll.EndDate, 
                         dbo.Payroll.PayrollName, dbo.Payroll.PayrollNameAra, dbo.Payroll.PayrollCode
FROM            dbo.PayCycle INNER JOIN
                         dbo.Payroll ON dbo.PayCycle.IdNo = dbo.Payroll.PayCycleIdNo
GO
/****** Object:  Table [dbo].[PayGroup]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayGroup](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[PayGroupCode] [varchar](5) NOT NULL,
	[PayGroupName] [varchar](50) NOT NULL,
	[ParentIdNo] [smallint] NULL,
	[PayGroupNameAra] [nvarchar](50) NOT NULL,
	[Notes] [varchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK__PayGroupID] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[PayGroup_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE View [dbo].[PayGroup_View] as 
with cte as
(
select IDNo
      ,PayGroupCode
      ,PayGroupName
      ,PayGroupNameAra
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by PayGroupName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by PayGroupName) / power(10.0,0) as SortKey
 
from PayGroup
where ParentIdNo IS NULL
union all
select t.IDNo
      ,t.PayGroupCode
      ,t.PayGroupName
      ,t.PayGroupNameAra
	  ,t.ParentIdNo
      ,t.[Notes]
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.PayGroupName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.PayGroupName) / power(10.0,levelnumber+1)
 
 from
    cte
join PayGroup t on cte.IdNo = t.ParentIdNo
)
   
select IDNo
      ,PayGroupCode
      ,PayGroupName
      ,PayGroupNameAra
	  ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte





GO
/****** Object:  View [dbo].[ApJournalItem_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ApJournalItem_View]
AS
SELECT			dbo.ApJournalItem.IdNo, dbo.ApJournalItem.Sequence, dbo.ApJournalItem.JournalIdNo, dbo.ApJournalItem.AccountIdNo, dbo.ApJournalItem.Debit, dbo.ApJournalItem.Credit, dbo.ApJournalItem.RevCostCenterIdNo, 
				dbo.ApJournalItem.Notes, dbo.ApJournalItem.Posted, dbo.ApJournalItem.DateTimeStamp, dbo.Account.AccountName, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.IdNo AS OpenInvoiceIdNo, 
				dbo.ApJournalItem.Credit - dbo.ApJournalItem.Debit AS OriginalAmount, dbo.ApOpenInvoice.PaidAmount, dbo.ApOpenInvoice.DiscountTaken, dbo.Account.SpecialAccount, dbo.Account.AccountNameAra, dbo.Account.PayeeType
FROM			dbo.ApJournalItem 
				LEFT OUTER JOIN dbo.Account 
				ON dbo.ApJournalItem.AccountIdNo = dbo.Account.IDNo 
				LEFT OUTER JOIN dbo.ApOpenInvoice 
				ON dbo.ApJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo AND DBO.ApOpenInvoice.[JournalCode] = 'AP'
GO
/****** Object:  View [dbo].[ArJournalItem_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[ArJournalItem_View]
AS
SELECT  a.IdNo, 
		o.JournalCode, 
		a.JournalIdNo, 
		a.AccountIdNo, 
		a.Debit, 
		a.Credit, 
		a.RevCostCenterIdNo, 
		a.Notes, 
		a.Posted, 
		a.DateTimeStamp, 
		c.AccountName, 
		o.IdNo AS OpenInvoiceIdNo, 
		a.Credit - a.Debit AS OriginalAmount, 
		col.PaidAmount, 
		col.DiscountTaken, 
		c.SpecialAccount, 
		c.AccountNameAra, 
		c.PayeeType, 
		a.Sequence
FROM    dbo.ArJournalItem a
		LEFT OUTER JOIN dbo.Account c
		ON a.AccountIdNo = c.IDNo 
		LEFT OUTER JOIN dbo.ArOpenInvoice o
		ON a.IdNo = o.JournalItemIdNo AND o.JournalCode = 'AR'
		LEFT OUTER JOIN dbo.ArCollections_View col
		on o.IdNo = col.IdNo
GO
/****** Object:  Table [dbo].[SecurityObject]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityObject](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[SecurityObjectCode] [varchar](10) NULL,
	[SecurityObjectName] [varchar](100) NOT NULL,
	[SecurityObjectNameAra] [nvarchar](200) NULL,
	[ParentIdNo] [smallint] NULL,
	[Notes] [varchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_SecurityObject] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[SecurityObject_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE View [dbo].[SecurityObject_View] as 
with cte as
(
select IDNo
      ,SecurityObjectName
      ,SecurityObjectNameAra
      ,ParentIdNo
      ,Notes
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by ParentIdNo) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by ParentIdNo) / power(1000.0,0) as SortKey
 
from SecurityObject
where ParentIdNo IS NULL
union all
select t.IDNo
      ,t.SecurityObjectName
      ,t.SecurityObjectNameAra
      ,t.ParentIdNo
      ,t.Notes
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.SecurityObjectName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.SecurityObjectName) / power(1000.0,levelnumber+1)
 
 from
    cte
join SecurityObject t on cte.IdNo = t.ParentIdNo
)
   
select IDNo
      ,SecurityObjectName
      ,SecurityObjectNameAra
      ,ParentIdNo
      ,Notes
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte


GO
/****** Object:  Table [dbo].[PurchaseJournalItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseJournalItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [smallint] NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[Debit] [money] NOT NULL,
	[Credit] [money] NOT NULL,
	[RevCostCenterIdNo] [smallint] NOT NULL,
	[Notes] [nvarchar](300) NOT NULL,
	[Posted] [bit] NOT NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_PurchaseJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[PurchaseJournalItem_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[PurchaseJournalItem_View]
AS
SELECT        dbo.PurchaseJournalItem.IdNo, dbo.PurchaseJournalItem.Sequence, dbo.PurchaseJournalItem.JournalIdNo, dbo.PurchaseJournalItem.AccountIdNo, dbo.PurchaseJournalItem.Debit, dbo.PurchaseJournalItem.Credit, dbo.PurchaseJournalItem.RevCostCenterIdNo, 
                         dbo.PurchaseJournalItem.Notes, dbo.PurchaseJournalItem.Posted, dbo.PurchaseJournalItem.DateTimeStamp, dbo.Account.AccountName, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.IdNo AS OpenInvoiceIdNo, 
                         dbo.PurchaseJournalItem.Credit - dbo.PurchaseJournalItem.Debit AS OriginalAmount, dbo.ApOpenInvoice.PaidAmount, dbo.Account.SpecialAccount, dbo.Account.AccountNameAra, dbo.Account.PayeeType
FROM            dbo.PurchaseJournalItem LEFT OUTER JOIN
                         dbo.Account ON dbo.PurchaseJournalItem.AccountIdNo = dbo.Account.IDNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.PurchaseJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  View [dbo].[GeneralJournalItem_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[GeneralJournalItem_View]
AS
SELECT        dbo.GeneralJournalItem.IdNo, dbo.GeneralJournalItem.Sequence, dbo.GeneralJournalItem.JournalIdNo, dbo.GeneralJournalItem.AccountIdNo, dbo.GeneralJournalItem.Debit, dbo.GeneralJournalItem.Credit, 
                         dbo.GeneralJournalItem.RevCostCenterIdNo, dbo.GeneralJournalItem.Notes, dbo.Account.AccountName, dbo.GeneralJournalItem.Debit - dbo.GeneralJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, 
                         dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.GeneralJournalItem LEFT OUTER JOIN
                         dbo.Account ON dbo.GeneralJournalItem.AccountIdNo = dbo.Account.IDNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.GeneralJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo AND dbo.ApOpenInvoice.JournalCode = 'GJ'
GO
/****** Object:  Table [dbo].[FormItems]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormItems](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[SystemViewIdNo] [smallint] NOT NULL,
	[CaptionIdNo] [int] NOT NULL,
 CONSTRAINT [PK_FormItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemForms]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemForms](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[FormName] [varchar](50) NULL,
 CONSTRAINT [PK_SystemForms] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[FormItemsOriginal_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[FormItemsOriginal_View]
AS
SELECT        dbo.FormItems.idno, dbo.FormItems.SystemViewIdNo, dbo.FormItems.CaptionIdNo, dbo.OriginalCaptions.Caption, dbo.FormItems.idno AS Expr1, dbo.FormItems.SystemViewIdNo AS Expr2, dbo.FormItems.CaptionIdNo AS Expr3, 
                         dbo.SystemForms.FormName, dbo.TranslatedCaption.TranslatedCaption, dbo.Languages.LanguageCode2, dbo.Languages.CultureInfoCode, dbo.Languages.Language, dbo.TranslatedCaption.LanguageIdNo
FROM            dbo.Languages RIGHT OUTER JOIN
                         dbo.TranslatedCaption ON dbo.Languages.IdNo = dbo.TranslatedCaption.LanguageIdNo RIGHT OUTER JOIN
                         dbo.FormItems LEFT OUTER JOIN
                         dbo.SystemForms ON dbo.FormItems.SystemViewIdNo = dbo.SystemForms.IdNo ON dbo.TranslatedCaption.CaptionIdNo = dbo.FormItems.CaptionIdNo LEFT OUTER JOIN
                         dbo.OriginalCaptions ON dbo.FormItems.CaptionIdNo = dbo.OriginalCaptions.idno
GO
/****** Object:  View [dbo].[TranslatedCaption_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TranslatedCaption_View]
AS
SELECT        dbo.TranslatedCaption.idno, dbo.TranslatedCaption.CaptionIdNo, dbo.TranslatedCaption.LanguageIdNo, dbo.TranslatedCaption.TranslatedCaption, dbo.Languages.CultureInfoCode, dbo.OriginalCaptions.Caption, 
                         dbo.Languages.LanguageCode2, dbo.TranslatedCaption.DateTimeStamp
FROM            dbo.TranslatedCaption LEFT OUTER JOIN
                         dbo.Languages ON dbo.TranslatedCaption.LanguageIdNo = dbo.Languages.IdNo RIGHT OUTER JOIN
                         dbo.OriginalCaptions ON dbo.TranslatedCaption.CaptionIdNo = dbo.OriginalCaptions.idno
GO
/****** Object:  View [dbo].[CkJournal_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[CkJournal_View]
AS
SELECT        dbo.CkJournal.IdNo, dbo.CkJournal.TransactionDate, dbo.CkJournal.ReferenceNo, dbo.CkJournal.Amount, 
                         dbo.CkJournal.AccountIdNo, dbo.CkJournal.PaymentType, dbo.CkJournal.PayeeIdNo, dbo.CkJournal.PayeeName, 
                         dbo.CkJournal.ORNumber, dbo.CkJournal.DiscountTaken, 
                         dbo.CkJournal.DiscountAccountIdNo, dbo.CkJournal.Applied, dbo.CkJournal.UnApplied, dbo.CkJournal.VatNumber, 
                         dbo.CkJournal.VatAmount, dbo.CkJournal.Notes, dbo.CkJournal.Posted, dbo.CkJournal.DateCreated, dbo.CkJournal.Cancelled, 
                         dbo.CkJournal.DateTimeStamp, dbo.currency_conversion(dbo.CkJournal.Amount) AS WordAmount, dbo.Bank.BankCode, dbo.Bank.BankNameAra, 
                         dbo.BankAccount.BranchName
FROM            dbo.CkJournal INNER JOIN
                         dbo.BankAccount ON dbo.CkJournal.AccountIdNo = dbo.BankAccount.AccountIdNo INNER JOIN
                         dbo.Bank ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo
GO
/****** Object:  Table [dbo].[PayrollDeductAccount]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayrollDeductAccount](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[DeductionIdNo] [smallint] NULL,
	[PayGroupIdNo] [smallint] NULL,
	[EmployeeIdNo] [int] NULL,
	[AccountIdNo] [smallint] NULL,
	[Sequence] [smallint] NULL,
 CONSTRAINT [PK_PayrollDeductAccount] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[PayrollDeductAccount_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[PayrollDeductAccount_View]
AS
SELECT        dbo.PayrollDeductAccount.IdNo, dbo.PayrollDeductAccount.DeductionIdNo, dbo.PayrollDeductAccount.PayGroupIdNo, dbo.PayrollDeductAccount.EmployeeIdNo, dbo.PayrollDeductAccount.AccountIdNo, dbo.Account.AccountCode, 
                         dbo.Account.AccountName, dbo.PayGroup.PayGroupCode, dbo.PayGroup.PayGroupName, dbo.PayGroup.PayGroupNameAra, dbo.Account.AccountNameAra, dbo.PayrollDeductAccount.Sequence
FROM            dbo.PayrollDeductAccount INNER JOIN
                         dbo.Account ON dbo.PayrollDeductAccount.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.PayGroup ON dbo.PayrollDeductAccount.PayGroupIdNo = dbo.PayGroup.IdNo
GO
/****** Object:  View [dbo].[CkJournalItem_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[CkJournalItem_View]
AS
SELECT        dbo.CkJournalItem.AccountIdNo, dbo.CkJournalItem.Credit, dbo.CkJournalItem.Debit, dbo.CkJournalItem.IdNo, 
                         dbo.CkJournalItem.JournalIdNo, dbo.CkJournalItem.Notes, dbo.CkJournalItem.RevCostCenterIdNo, dbo.CkJournalItem.Sequence, 
                         dbo.Account.AccountName, dbo.CkJournalItem.Debit - dbo.CkJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.CkJournal LEFT OUTER JOIN
                         dbo.CkJournalItem ON dbo.CkJournal.IdNo = dbo.CkJournalItem.JournalIdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.CkJournalItem.AccountIdNo = dbo.Account.IDNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CkJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  Table [dbo].[PhoneType]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhoneType](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[PhoneTypeCode] [varchar](5) NOT NULL,
	[PhoneTypeName] [varchar](15) NOT NULL,
	[PhoneTypeNameAra] [nvarchar](15) NULL,
	[Notes] [varchar](50) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_PhoneType] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[IDNo] [smallint] IDENTITY(1,1) NOT NULL,
	[CountryCode] [char](2) NOT NULL,
	[CountryName] [varchar](100) NOT NULL,
	[CountryNameAra] [nvarchar](200) NOT NULL,
	[Nationality] [varchar](100) NOT NULL,
	[NationalityAra] [nvarchar](200) NOT NULL,
	[Flag32] [varchar](256) NULL,
	[Flag128] [varchar](256) NULL,
	[ISOA3] [varchar](3) NULL,
	[ISON] [smallint] NULL,
	[CountryTelCode] [varchar](7) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_CountryIDNo] PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_ISOA2] UNIQUE NONCLUSTERED 
(
	[CountryCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_NameAra] UNIQUE NONCLUSTERED 
(
	[IDNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_NameEng] UNIQUE NONCLUSTERED 
(
	[CountryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeePhone]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeePhone](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeIdNo] [int] NOT NULL,
	[PhoneTypeIdNo] [smallint] NULL,
	[CountryTelIdNo] [smallint] NULL,
	[AreaCode] [varchar](5) NULL,
	[PhoneNumber] [varchar](14) NOT NULL,
	[Sequence] [tinyint] NOT NULL,
 CONSTRAINT [PK_EmployeePhone] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[EmployeePhone_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[EmployeePhone_View]
AS
SELECT        dbo.PhoneType.PhoneTypeCode, dbo.PhoneType.PhoneTypeName, dbo.PhoneType.PhoneTypeNameAra, dbo.EmployeePhone.CountryTelIdNo, dbo.EmployeePhone.IdNo, dbo.EmployeePhone.EmployeeIdNo, 
                         dbo.EmployeePhone.PhoneTypeIdNo, dbo.EmployeePhone.AreaCode, dbo.EmployeePhone.PhoneNumber, dbo.Employee.EmployeeName, dbo.Employee.EmployeeNameAra, dbo.EmployeePhone.Sequence, 
                         dbo.PhoneType.PhoneTypeName COLLATE SQL_Latin1_General_CP1_CS_AS +
						 Case 
							When dbo.EmployeePhone.CountryTelIdNo IS NULL then ' '
							Else ' ' + LTrim(dbo.Country.CountryTelCode)
						 End +
						 ' (' + dbo.EmployeePhone.AreaCode + ') ' + dbo.EmployeePhone.PhoneNumber AS FullPhone, 
                         dbo.PhoneType.PhoneTypeName COLLATE Arabic_CI_AS + 
						 Case 
							When dbo.EmployeePhone.CountryTelIdNo IS NULL then ' '
							Else ' ' + LTrim(dbo.Country.CountryTelCode)
						 End +
						 ' (' + dbo.EmployeePhone.AreaCode + ') ' + dbo.EmployeePhone.PhoneNumber AS FullPhoneAra, dbo.Country.CountryTelCode
FROM            dbo.EmployeePhone INNER JOIN
                         dbo.Employee ON dbo.EmployeePhone.EmployeeIdNo = dbo.Employee.IdNo LEFT OUTER JOIN
                         dbo.Country ON dbo.EmployeePhone.CountryTelIdNo = dbo.Country.IDNo LEFT OUTER JOIN
                         dbo.PhoneType ON dbo.EmployeePhone.PhoneTypeIdNo = dbo.PhoneType.IdNo
GO
/****** Object:  View [dbo].[CkJournalTransaction_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[CkJournalTransaction_View]
AS
SELECT        dbo.CkJournal.TransactionDate, dbo.CkJournal.ReferenceNo, dbo.CkJournal.Amount, dbo.CkJournal.PayeeName, 
                         dbo.CkJournal.CheckNumber, dbo.CkJournal.CheckDate, dbo.CkJournal.Notes, dbo.CkJournal.PaymentType, 
                         dbo.CkJournalItem.Sequence, dbo.CkJournalItem.Debit, dbo.CkJournalItem.Credit, dbo.CkJournalItem.Notes AS CkNotes, 
                         dbo.BankAccount.BranchName, dbo.Bank.BankName, dbo.Bank.BankNameAra, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Employee.EmployeeCode, dbo.Supplier.SupplierNameAra, 
                         dbo.Employee.EmployeeNameAra, dbo.Employee.EmployeeName, dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.CkJournal.IdNo, dbo.Customer.CustomerCode, 
                         dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra
FROM            dbo.CkJournal 
				LEFT OUTER JOIN dbo.CkJournalItem 
					ON dbo.CkJournal.IdNo = dbo.CkJournalItem.JournalIdNo 
				Left Outer Join dbo.Supplier 
					ON dbo.CkJournal.PayeeIdNo = dbo.Supplier.IdNo
				Left Outer Join dbo.Customer
				    ON dbo.CkJournal.PayeeIdNo = dbo.Customer.IdNo 
				Left Outer Join dbo.Employee 
					ON dbo.CkJournal.PayeeIdNo = dbo.Employee.IdNo 
				Left Outer Join dbo.BankAccount 
					ON dbo.CkJournal.AccountIdNo = dbo.BankAccount.AccountIdNo 
				LEFT OUTER JOIN dbo.Account 
					ON dbo.CkJournalItem.AccountIdNo = dbo.Account.IdNo 
				LEFT OUTER JOIN dbo.Bank 
					ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo 
				Left Outer Join dbo.RevCostCenter
					On dbo.CkJournalItem.RevCostCenterIdNo = dbo.RevCostCenter.IdNo
GO
/****** Object:  View [dbo].[CkOiItem_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[CkOiItem_View]
AS
SELECT        dbo.CkOiItem.Sequence, dbo.ApOpenInvoice_View.InvoiceNo, dbo.ApOpenInvoice_View.TransactionDate, dbo.ApOpenInvoice_View.Balance + dbo.CkOiItem.Amount + dbo.CkOiItem.DiscountTaken AS PreviousBalance, 
                         dbo.CkOiItem.Amount, dbo.CkOiItem.DiscountTaken, dbo.ApOpenInvoice_View.Balance, dbo.ApOpenInvoice_View.Amount AS InvoiceAmount, dbo.ApOpenInvoice_View.JournalCode, 
                         dbo.ApOpenInvoice_View.JournalItemIdNo AS ApJournalItemIdNo, dbo.ApOpenInvoice_View.ReferenceNo, dbo.ApOpenInvoice_View.PaidAmount, dbo.CkOiItem.IdNo, dbo.CkOiItem.ApOpenInvoiceIdNo, 
                         dbo.ApOpenInvoice_View.SupplierIdNo, dbo.ApOpenInvoice_View.AccountIdNo, dbo.ApOpenInvoice_View.JournalIdNo, dbo.CkOiItem.DjIdNo
FROM            dbo.CkOiItem LEFT OUTER JOIN
                         dbo.ApOpenInvoice_View ON dbo.CkOiItem.ApOpenInvoiceIdNo = dbo.ApOpenInvoice_View.IdNo
GO
/****** Object:  View [dbo].[ApInvoices_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ApInvoices_View]
AS
SELECT        dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.JournalItemIdNo, dbo.APDetails_View.AccountIdNo, dbo.APDetails_View.Debit, dbo.APDetails_View.Credit, dbo.APDetails_View.RevCostCenterIdNo, 
                         dbo.APDetails_View.Notes, dbo.APDetails_View.Posted, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra, dbo.APDetails_View.SupplierIdNo, dbo.APDetails_View.InvoiceNo, 
                         dbo.APDetails_View.TransactionDate, dbo.APDetails_View.ReferenceNo, dbo.APDetails_View.TransactionType, dbo.ApOpenInvoice.PaidAmount, dbo.ApOpenInvoice.DiscountTaken, dbo.Account.SpecialAccount, 
                         dbo.ApOpenInvoice.IdNo, dbo.ApOpenInvoice.JournalIdNo, dbo.Supplier.SupplierCode
FROM            dbo.Supplier RIGHT OUTER JOIN
                         dbo.APDetails_View ON dbo.Supplier.IdNo = dbo.APDetails_View.SupplierIdNo RIGHT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.APDetails_View.IdNo = dbo.ApOpenInvoice.JournalItemIdNo AND 
                         dbo.APDetails_View.JournalCode COLLATE SQL_Latin1_General_CP1_CI_AS = dbo.ApOpenInvoice.JournalCode LEFT OUTER JOIN
                         dbo.Account ON dbo.APDetails_View.AccountIdNo = dbo.Account.IDNo
GO
/****** Object:  View [dbo].[Account_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE View [dbo].[Account_View] as 
with cte as
(
select
    IdNo,
    ParentIdNo,
	AccountCode,
	AccountName,   
	AccountNameAra,
	Notes,
	DetailAccount,
	AccountGroup,
	BYDebit,
	BYCredit,
	Debit,
	Credit,
	NormalBalance,
	CloseDebit,
	CloseCredit,
	PayeeType,
	WithReconciliation,
	IncomeExpSummary,
	SpecialAccount,
	Active,
	GroupSortOrder,
	DateTimeStamp,
	CASE AccountGroup 
		WHEN 'A' THEN 1
		WHEN 'L' THEN 2
		WHEN 'E' THEN 3
		WHEN 'R' THEN 4
		WHEN 'C' THEN 5
		WHEN 'X' THEN 6
		ELSE 0
	END AS 'AccountGroupOrder',
    cast(row_number()over(partition by ParentIdNo order by ParentIdNo) as varchar(max)) as [path],
    0 as levelnumber,
    row_number() over (partition by ParentIdNo order by ParentIdNo) / power(1000.0,0) as SortKey
 
from Account
where ParentIdNo IS NULL
union all
select
    t.IdNo,
	t.ParentIdNo,
	t.AccountCode,
    t.AccountName,
	t.AccountNameAra,    
	t.Notes,
	t.DetailAccount,
	t.AccountGroup,
	t.BYDebit,
	t.BYCredit,
	t.Debit,
	t.Credit,
	t.NormalBalance,
	t.CloseDebit,
	t.CloseCredit,
	t.PayeeType,
	t.WithReconciliation,
	t.IncomeExpSummary,
	t.SpecialAccount,
	t.Active,
	t.GroupSortOrder,
	t.DateTimeStamp,
	AccountGroupOrder,
    [path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.GroupSortOrder) as varchar(max)),
    levelnumber+1,
    SortKey + row_number()over(partition by t.ParentIdNo order by t.GroupSortOrder) / power(1000.0,levelnumber+1)
 
from
    cte
join Account t on cte.IdNo = t.ParentIdNo
)
   
select
    IdNo,
	ParentIdNo,
	AccountCode,
    AccountName,
	AccountNameAra,
	Notes,
	DetailAccount,
	AccountGroup,
	BYDebit,
	BYCredit,
	Debit,
	Credit,
	NormalBalance,
	CloseDebit,
	CloseCredit,
	PayeeType,
	WithReconciliation,
	IncomeExpSummary,
	SpecialAccount,
	Active,
	LevelNumber,
	LevelNumber+1 AS PLevelNumber,
	DateTimeStamp,   
	AccountGroupOrder,
    [path],
    SortKey
from cte
GO
/****** Object:  View [dbo].[PcJournalTransaction_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


cREATE VIEW [dbo].[PcJournalTransaction_View]
AS
SELECT        dbo.PcJournal.IdNo, dbo.PcJournal.TransactionDate, dbo.PcJournal.ReferenceNo, dbo.PcJournal.Amount, dbo.PcJournal.PayeeIdNo, 
                         dbo.PcJournal.PaymentType, dbo.PcJournal.PayeeName, dbo.PcJournalItem.Sequence, dbo.PcJournalItem.Debit, dbo.PcJournalItem.Credit, 
                         dbo.PcJournalItem.RevCostCenterIdNo, dbo.PcJournalItem.Notes, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra, dbo.Customer.CustomerCode, 
                         dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierNameAra, dbo.Employee.EmployeeCode, dbo.Employee.EmployeeName, 
                         dbo.Employee.EmployeeNameAra, dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.PcJournal.Notes AS PcNote, dbo.BankAccount.BranchName, dbo.Bank.BankCode, 
                         dbo.Bank.BankName, dbo.Bank.BankNameAra
FROM            dbo.BankAccount LEFT OUTER JOIN
                         dbo.Bank ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo RIGHT OUTER JOIN
                         dbo.PcJournal ON dbo.BankAccount.AccountIdNo = dbo.PcJournal.AccountIdNo LEFT OUTER JOIN
                         dbo.Account RIGHT OUTER JOIN
                         dbo.PcJournalItem ON dbo.Account.IdNo = dbo.PcJournalItem.AccountIdNo LEFT OUTER JOIN
                         dbo.RevCostCenter ON dbo.PcJournalItem.RevCostCenterIdNo = dbo.RevCostCenter.IDNo ON dbo.PcJournal.IdNo = dbo.PcJournalItem.JournalIdNo LEFT OUTER JOIN
                         dbo.Customer ON dbo.PcJournal.PayeeIdNo = dbo.Customer.IdNo LEFT OUTER JOIN
                         dbo.Supplier ON dbo.PcJournal.PayeeIdNo = dbo.Supplier.IdNo LEFT OUTER JOIN
                         dbo.Employee ON dbo.PcJournal.PayeeIdNo = dbo.Employee.IdNo
GO
/****** Object:  View [dbo].[BalanceSheetLayout_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/****** Script for SelectTopNRows command from SSMS  ******/
  CREATE VIEW [dbo].[BalanceSheetLayout_View] as
  (SELECT IdNo,ParentIDNo,AccountCode,AccountName,AccountNameAra,DetailAccount,AccountGroup,ByDebit,BYCredit,Debit,Credit,NormalBalance,CloseDebit,CloseCredit,PayeeType,
		  WithReconciliation,IncomeExpSummary,SpecialAccount,Active,LevelNumber,Path,SortKey,
		  CASE WHEN AccountGroup='A' THEN 1 WHEN AccountGroup='L' THEN 2 WHEN AccountGroup='E' THEN 3 END AS 'AccountGroupSort'
		  FROM Account_View)
  UNION
  (SELECT [IdNo]
      ,[ParentIdNo]
      ,'XXX' AS 'AccountCode'
      ,'Total '+ [AccountName] AS 'AccountName'
      ,' مجموع '   + [AccountNameAra] AS 'AccountNameAra'
      ,'1' AS 'DetailAccount'
      ,[AccountGroup]
	  ,0
	  ,0
	  ,0
	  ,0
	  ,NormalBalance
	  ,0
	  ,0
	  ,PayeeType
	  ,WithReconciliation
	  ,IncomeExpSummary
	  ,SpecialAccount
	  ,Active
      ,[LevelNumber]+1 AS 'LevelNumber'
      ,[path]+'-A'
	  ,REPLACE(RTRIM(REPLACE(SortKey, '0', ' ')), ' ', '0')+'999'
	  ,CASE WHEN AccountGroup='A' THEN 1 WHEN AccountGroup='L' THEN 2 WHEN AccountGroup='E' THEN 3 END 
  FROM [dbo].[Account_View] WHERE NOT DetailAccount=1)
GO
/****** Object:  View [dbo].[UnpaidOpenInvoices_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UnpaidOpenInvoices_View]
AS
SELECT        dbo.ApJournalItem_View.IdNo, dbo.ApJournalItem_View.JournalIdNo, dbo.ApJournalItem_View.AccountIdNo, dbo.ApJournalItem_View.AccountName, dbo.ApJournalItem_View.AccountNameAra, 
                         dbo.ApJournalItem_View.PaidAmount, dbo.ApJournalItem_View.OpenInvoiceIdNo, dbo.ApJournalItem_View.OriginalAmount, dbo.ApJournalItem_View.OriginalAmount - dbo.ApJournalItem_View.PaidAmount AS Balance, 
                         dbo.ApJournalItem_View.SpecialAccount, dbo.ApJournal.TransactionDate, dbo.ApJournal.SupplierIdNo, dbo.ApJournal.ReferenceNo
FROM            dbo.ApJournalItem_View INNER JOIN
                         dbo.ApJournal ON dbo.ApJournalItem_View.JournalIdNo = dbo.ApJournal.IDNo
WHERE        (dbo.ApJournalItem_View.SpecialAccount = 'AP')
GO
/****** Object:  View [dbo].[SalesJournalTransaction_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[SalesJournalTransaction_View]
AS
SELECT        dbo.SalesJournalItem.Sequence, dbo.SalesJournalItem.JournalIdNo, dbo.SalesJournalItem.AccountIdNo, dbo.SalesJournalItem.Debit, dbo.SalesJournalItem.Credit, 
                         dbo.SalesJournalItem.RevCostCenterIdNo, dbo.SalesJournalItem.Notes, dbo.SalesJournalItem.Posted, dbo.SalesJournal.TransactionDate, dbo.SalesJournal.Notes AS GJNotes, 
                         dbo.SalesJournal.Cancelled, dbo.SalesJournal.ReferenceNo, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra, 
                         dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.RevCostCenter.RevCostCenterNameAra
FROM            dbo.RevCostCenter RIGHT OUTER JOIN
                         dbo.SalesJournalItem ON dbo.RevCostCenter.IdNo = dbo.SalesJournalItem.RevCostCenterIdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.SalesJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.SalesJournal ON dbo.SalesJournalItem.JournalIdNo = dbo.SalesJournal.IdNo
GO
/****** Object:  View [dbo].[GeneralLedger_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[GeneralLedger_View]
AS
SELECT        dbo.Account_View.IdNo, dbo.Account_View.AccountCode, dbo.Account_View.AccountName, dbo.Account_View.AccountNameAra, dbo.GlLedgers_View.Debit, dbo.GlLedgers_View.Credit, dbo.GlLedgers_View.TransactionDate, 
                         dbo.GlLedgers_View.Posted, dbo.GlLedgers_View.JournalCode, dbo.GlLedgers_View.IdNo AS JournalItemIdNo, dbo.GlLedgers_View.JournalIdNo, dbo.Account_View.SortKey, 
                         dbo.GlLedgers_View.ClosingJournal,dbo.Account_View.SpecialAccount
FROM            dbo.Account_View LEFT OUTER JOIN
                         dbo.GlLedgers_View ON dbo.Account_View.IdNo = dbo.GlLedgers_View.AccountIdNo
GO
/****** Object:  View [dbo].[BalanceSheet_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




Create VIEW [dbo].[BalanceSheet_View]
AS
Select idno,sum(Debit-Credit) as 'Balance',TransactionDate
from GeneralLedger_View as Gl
group by idno,TransactionDate
GO
/****** Object:  View [dbo].[GLBalanceSheet_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE VIEW [dbo].[GLBalanceSheet_View]
AS
Select idno,sum(Debit-Credit) as 'Balance',TransactionDate,ClosingJournal,Posted,SpecialAccount
from GeneralLedger_View as Gl
group by idno,TransactionDate,ClosingJournal,Posted,SpecialAccount
GO
/****** Object:  Table [dbo].[CostCenter]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostCenter](
	[IDNo] [smallint] NOT NULL,
	[CostCenterCode] [varchar](5) NOT NULL,
	[CostCenterName] [varchar](50) NOT NULL,
	[ParentIdNo] [smallint] NULL,
	[ProfitCenterIdNo] [smallint] NULL,
	[CostCenterNameAra] [nvarchar](50) NOT NULL,
	[Notes] [varchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_CostCenterIdNo] PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CostCenter_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE View [dbo].[CostCenter_View] as 
with cte as
(
select IDNo
      ,CostCenterCode
      ,CostCenterName
      ,CostCenterNameAra
      ,ParentIdNo
	  ,ProfitCenterIdNo
      ,[Notes]
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by CostCenterName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by CostCenterName) / power(10.0,0) as SortKey
 
from CostCenter
where ParentIdNo IS NULL
union all
select t.IDNo
      ,t.CostCenterCode
      ,t.CostCenterName
      ,t.CostCenterNameAra
	  ,t.ParentIdNo
	  ,t.ProfitCenterIdNo
      ,t.[Notes]
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.CostCenterName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.CostCenterName) / power(10.0,levelnumber+1)
 
 from
    cte
join CostCenter t on cte.IdNo = t.ParentIdNo
)
   
select IDNo
      ,CostCenterCode
      ,CostCenterName
      ,CostCenterNameAra
	  ,ParentIdNo
	  ,ProfitCenterIdNo
      ,[Notes]
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte





GO
/****** Object:  Table [dbo].[ProfitCenter]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfitCenter](
	[IdNo] [smallint] NOT NULL,
	[ProfitCenterCode] [varchar](5) NULL,
	[ProfitCenterName] [varchar](50) NULL,
	[ParentIdNo] [smallint] NULL,
	[ProfitCenterNameAra] [nvarchar](50) NULL,
	[ProfitCenterType] [char](1) NULL,
	[Notes] [varchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK__ProfitCenterID] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_ProfitCenterCode] UNIQUE NONCLUSTERED 
(
	[ProfitCenterCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_ProfitCenterNameAra] UNIQUE NONCLUSTERED 
(
	[ProfitCenterNameAra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ProfitCenter_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE View [dbo].[ProfitCenter_View] as 
with cte as
(
select IDNo
      ,ProfitCenterCode
      ,ProfitCenterName
      ,ProfitCenterNameAra
	  ,ProfitCenterType
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by ProfitCenterName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by ProfitCenterName) / power(10.0,0) as SortKey
 
from ProfitCenter
where ParentIdNo IS NULL
union all
select t.IDNo
      ,t.ProfitCenterCode
      ,t.ProfitCenterName
      ,t.ProfitCenterNameAra
	  ,t.ProfitCenterType
      ,t.ParentIdNo
      ,t.[Notes]
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.ProfitCenterName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.ProfitCenterName) / power(10.0,levelnumber+1)
 
 from
    cte
join ProfitCenter t on cte.IdNo = t.ParentIdNo
)
   
select IDNo
      ,ProfitCenterCode
      ,ProfitCenterName
      ,ProfitCenterNameAra
	  ,ProfitCenterType
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte





GO
/****** Object:  View [dbo].[RetainedEarnings_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE VIEW [dbo].[RetainedEarnings_View]	
  AS
(Select g.Debit-g.Credit as 'Balance',TransactionDate from  GeneralLedger_View g
left join Account c
on g.IdNo = c.IdNo
where CHARINDEX(c.AccountGroup,'XCR') > 0 )
GO
/****** Object:  View [dbo].[IncomeStatementLayout_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







/****** Script for SelectTopNRows command from SSMS  ******/
  CREATE VIEW [dbo].[IncomeStatementLayout_View] as
  (SELECT IdNo,ParentIDNo,AccountCode,AccountName,AccountNameAra,DetailAccount,AccountGroup,ByDebit,BYCredit,Debit,Credit,NormalBalance,CloseDebit,CloseCredit,PayeeType,
		  WithReconciliation,IncomeExpSummary,SpecialAccount,Active,LevelNumber,Path,SortKey	  
		  FROM Account_View)
  UNION
  (SELECT [IdNo]
      ,[ParentIdNo]
      ,'XXX' AS 'AccountCode'
      ,'Total '+ [AccountName] AS 'AccountName'
      ,'مجموع' + [AccountNameAra] AS 'AccountNameAra'
      ,'1' AS 'DetailAccount'
      ,[AccountGroup]
	  ,0
	  ,0
	  ,0
	  ,0
	  ,NormalBalance
	  ,0
	  ,0
	  ,PayeeType
	  ,WithReconciliation
	  ,IncomeExpSummary
	  ,SpecialAccount
	  ,Active
      ,[LevelNumber]+1 AS 'LevelNumber'
      ,[path]+'-A'
	  ,REPLACE(RTRIM(REPLACE(SortKey, '0', ' ')), ' ', '0')+'999'  
  FROM [dbo].[Account_View] WHERE NOT DetailAccount=1)
GO
/****** Object:  View [dbo].[RevCostCenter_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE View [dbo].[RevCostCenter_View] as 
with cte as
(
select IDNo
      ,RevCostCenterCode
      ,RevCostCenterName
      ,RevCostCenterNameAra
      ,ParentIdNo
	  ,RCType
      ,[Notes]
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by RevCostCenterName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by RevCostCenterName) / power(10.0,0) as SortKey
 
from RevCostCenter
where ParentIdNo IS NULL
union all
select t.IDNo
      ,t.RevCostCenterCode
      ,t.RevCostCenterName
      ,t.RevCostCenterNameAra
	  ,t.ParentIdNo
	  ,t.RCType
      ,t.[Notes]
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.RevCostCenterName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.RevCostCenterName) / power(10.0,levelnumber+1)
 
 from
    cte
join RevCostCenter t on cte.IdNo = t.ParentIdNo
)
   
select IDNo
      ,RevCostCenterCode
      ,RevCostCenterName
      ,RevCostCenterNameAra
	  ,ParentIdNo
	  ,RCType
      ,[Notes]
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte





GO
/****** Object:  View [dbo].[AccountBalance_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[AccountBalance_View]
AS
Select c.idno,c.parentidNo,c.AccountGroup,c.AccountName,c.LevelNumber,sum(gl.Debit-gl.Credit) as 'Balance' ,c.sortKey,gl.TransactionDate
from GeneralLedger_View as Gl
Left join Account_View as c 
on gl.idNo = c.idNo
group by c.sortkey,c.LevelNumber,c.parentidNo,c.idno,c.AccountGroup,c.AccountName,gl.TransactionDate
GO
/****** Object:  Table [dbo].[RevenueGroup]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RevenueGroup](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[RevenueGroupCode] [varchar](5) NOT NULL,
	[RevenueGroupName] [varchar](50) NOT NULL,
	[ParentIdNo] [smallint] NULL,
	[RevenueGroupNameAra] [nvarchar](50) NOT NULL,
	[Notes] [varchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK__RevenueGroupID] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RevenueGroup_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




Create View [dbo].[RevenueGroup_View] as 
with cte as
(
select IDNo
      ,RevenueGroupCode
      ,RevenueGroupName
      ,RevenueGroupNameAra
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by RevenueGroupName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by RevenueGroupName) / power(10.0,0) as SortKey
 
from RevenueGroup
where ParentIdNo IS NULL
union all
select t.IDNo
      ,t.RevenueGroupCode
      ,t.RevenueGroupName
      ,t.RevenueGroupNameAra
      ,t.ParentIdNo
      ,t.[Notes]
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.RevenueGroupName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.RevenueGroupName) / power(10.0,levelnumber+1)
 
 from
    cte
join RevenueGroup t on cte.IdNo = t.ParentIdNo
)
   
select IDNo
      ,RevenueGroupCode
      ,RevenueGroupName
      ,RevenueGroupNameAra
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte





GO
/****** Object:  View [dbo].[CurrentEarnings_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO













CREATE VIEW [dbo].[CurrentEarnings_View]	
  AS
(Select g.idno,Round(g.Debit-g.Credit,2) as 'Balance',ClosingJournal, TransactionDate from  GeneralLedger_View g
left join Account c
on g.IdNo = c.IdNo
where CHARINDEX(c.AccountGroup,'XR') > 0 )
GO
/****** Object:  View [dbo].[Earnings_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO













CREATE VIEW [dbo].[Earnings_View]	
  AS
(Select g.idno,Round(g.Debit-g.Credit,2) as 'Balance',ClosingJournal, TransactionDate from  GeneralLedger_View g
left join Account c
on g.IdNo = c.IdNo
where CHARINDEX(c.AccountGroup,'XCR') > 0 )
GO
/****** Object:  Table [dbo].[AccountReconciliationItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountReconciliationItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[AccountReconciliationIdNo] [int] NULL,
	[JournalCode] [char](2) NULL,
	[JournalItemIdNo] [int] NULL,
	[Cleared] [bit] NULL,
	[Sequence] [int] NULL,
 CONSTRAINT [PK_AccountReconciliationDetails] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reconciled]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reconciled](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[JournalCode] [char](2) NULL,
	[JournalItemIdNo] [smallint] NULL,
	[ReconciliationIdNo] [int] NULL,
 CONSTRAINT [PK_Reconciled] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountReconciliation]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountReconciliation](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[ReconciliationDate] [date] NOT NULL,
	[Balance] [money] NOT NULL,
	[Posted] [bit] NULL,
	[DateCreated] [date] NOT NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_AccountReconciliation] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AccountReconciliationItem_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   VIEW [dbo].[AccountReconciliationItem_View]
AS
SELECT        dbo.AccountReconciliationItem.IdNo, dbo.AccountReconciliationItem.Sequence, dbo.GlLedgers_View.TransactionDate, dbo.GlLedgers_View.IdNo AS JournalItemIdNo, dbo.GlLedgers_View.JournalCode, 
                         dbo.AccountReconciliationItem.AccountReconciliationIdNo, dbo.GlLedgers_View.Debit, dbo.GlLedgers_View.DocumentNumber, dbo.GlLedgers_View.Credit, dbo.AccountReconciliationItem.Cleared, dbo.GlLedgers_View.AccountIdNo, dbo.GlLedgers_View.PayDescription, 
                         dbo.GlLedgers_View.PayDescriptionAra, dbo.GlLedgers_View.ReferenceNo, dbo.GlLedgers_View.JournalIdNo, dbo.AccountReconciliation.Posted as Reconciled, dbo.AccountReconciliation.Posted
FROM            dbo.Reconciled 
			      RIGHT OUTER JOIN dbo.GlLedgers_View 
				     ON dbo.Reconciled.JournalCode = dbo.GlLedgers_View.JournalCode Collate SQL_Latin1_General_CP1_CI_AS AND dbo.Reconciled.JournalitemIdNo = dbo.GlLedgers_View.IdNo 
			      LEFT OUTER JOIN dbo.AccountReconciliationItem 
				     ON dbo.GlLedgers_View.JournalCode = dbo.AccountReconciliationItem.JournalCode Collate SQL_Latin1_General_CP1_CI_AS AND dbo.GlLedgers_View.IdNo = dbo.AccountReconciliationItem.JournalItemIdNo
				  LEFT OUTER JOIN dbo.AccountReconciliation 
					 ON dbo.AccountReconciliationItem.AccountReconciliationIdNo = dbo.AccountReconciliation.IdNo
GO
/****** Object:  UserDefinedFunction [dbo].[FuncAccountBalance]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[FuncAccountBalance] (@IdNo Integer,@StartDate Date, @EndDate Date, @LastFiscalYearEnd Date)
RETURNS TABLE
AS
RETURN
(   SELECT Sum(Balance) as 'Balance'
    FROM [GLBalanceSheet_View]
	/***WHERE (TransactionDate >= @StartDate and TransactionDate <= @EndDate ) ***/
    WHERE IdNo = @IdNo and (TransactionDate >= @StartDate and TransactionDate <= @EndDate and  closingjournal = 0) 
		   OR (Year(TransactionDate) >= Year(@LastFiscalYearEnd) and Year(TransactionDate) < Year(@EndDate) and  closingjournal = 1) 
	
)
GO
/****** Object:  Table [dbo].[AccountTypes]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountTypes](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[AccountTypes] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AccountTypesIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[InputVatAccountTypes]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[InputVatAccountTypes]
AS
SELECT        IdNo, AccountIdNo, AccountTypes, IdNo AS Expr1, AccountTypes AS Expr2, AccountIdNo AS Expr3
FROM            dbo.AccountTypes
WHERE        (AccountTypes = 'VI')
GO
/****** Object:  View [dbo].[ErStatement_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE VIEW [dbo].[ErStatement_View]
AS
SELECT        dbo.ErDetails_View.JournalCode, dbo.ErDetails_View.IdNo, dbo.ErDetails_View.Sequence, dbo.ErDetails_View.JournalIdNo, dbo.ErDetails_View.AccountIdNo, dbo.ErDetails_View.Debit, dbo.ErDetails_View.Credit, 
                         dbo.ErDetails_View.RevCostCenterIdNo, dbo.ErDetails_View.Notes, dbo.ErDetails_View.Posted, dbo.ErDetails_View.EmployeeIdNo, dbo.ErDetails_View.InvoiceNo, dbo.ErDetails_View.TransactionDate, dbo.ErDetails_View.ReferenceNo, 
                         dbo.ErDetails_View.TransactionType, dbo.Account.SpecialAccount, dbo.ErDetails_View.MainNote
FROM            dbo.ErDetails_View INNER JOIN
                         dbo.Account ON dbo.ErDetails_View.AccountIdNo = dbo.Account.IDNo
WHERE        (dbo.Account.SpecialAccount = 'EL')
GO
/****** Object:  UserDefinedFunction [dbo].[FuncGlBalanceSheet]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[FuncGlBalanceSheet] (@StartDate Date, @EndDate Date, @LastFiscalYearEnd Date)
RETURNS TABLE
AS
RETURN
(   SELECT idno, Sum(Balance) as 'Balance'
    FROM [GLBalanceSheet_View]
	/***WHERE (TransactionDate >= @StartDate and TransactionDate <= @EndDate ) ***/
    WHERE (TransactionDate >= @StartDate and TransactionDate <= @EndDate and  closingjournal = 0) 
		   OR (Year(TransactionDate) >= Year(@LastFiscalYearEnd) and Year(TransactionDate) < Year(@EndDate) and  closingjournal = 1) 
	Group By idNo
)
GO
/****** Object:  View [dbo].[GlReconciliation_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[GlReconciliation_View]
AS
SELECT			dbo.GlLedgers_View.JournalCode, dbo.GlLedgers_View.IdNo, dbo.GlLedgers_View.Sequence, dbo.GlLedgers_View.JournalIdNo, dbo.GlLedgers_View.AccountIdNo, dbo.GlLedgers_View.Debit, 
				dbo.GlLedgers_View.Credit,dbo.GlLedgers_View.DocumentNumber, dbo.GlLedgers_View.RevCostCenterIdNo, dbo.GlLedgers_View.Notes, dbo.GlLedgers_View.Posted, dbo.GlLedgers_View.TransactionDate, dbo.GlLedgers_View.ReferenceNo, 
				dbo.GlLedgers_View.PayDescription, dbo.GlLedgers_View.PayDescriptionAra, dbo.Reconciled.IdNo AS Reconciled
FROM			dbo.GlLedgers_View 
				LEFT OUTER JOIN dbo.Reconciled 
				ON dbo.GlLedgers_View.IdNo = dbo.Reconciled.JournalitemIdNo AND dbo.GlLedgers_View.JournalCode = dbo.Reconciled.JournalCode Collate SQL_Latin1_General_CP1_CI_AS
GO
/****** Object:  UserDefinedFunction [dbo].[FuncGlIncomeStatement]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[FuncGlIncomeStatement] (@StartDate Date, @EndDate Date)
RETURNS TABLE
AS
RETURN
(   SELECT idno, Sum(Balance) as 'Balance'
    FROM [GLBalanceSheet_View]
	WHERE (TransactionDate >= @StartDate and TransactionDate <= @EndDate and  closingjournal = 0 and ((SpecialAccount <> 'BI' and SpecialAccount <> 'EI') or SpecialAccount Is Null)) OR
		  (Month(TransactionDate) = Month(@StartDate) and Year(TransactionDate) = Year(@StartDate) and  closingjournal = 0  and SpecialAccount = 'BI') OR
		  (Month(TransactionDate) = Month(@EndDate) and Year(TransactionDate) = Year(@EndDate) and  closingjournal = 0  and SpecialAccount = 'EI') 
	Group By idNo
)
GO
/****** Object:  UserDefinedFunction [dbo].[FuncGlStatement]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE FUNCTION [dbo].[FuncGlStatement] (@StartDate Date, @EndDate Date, @LastFiscalYearEnd Date)
RETURNS TABLE
AS
RETURN
(   SELECT idno, Sum(Balance) as 'Balance'
    FROM [GLBalanceSheet_View]
	/***WHERE (TransactionDate >= @StartDate and TransactionDate <= @EndDate ) ***/
    WHERE (TransactionDate >= @StartDate and TransactionDate < @EndDate and (SpecialAccount is Null or (SpecialAccount <> 'BI' and SpecialAccount <> 'EI')))
		   OR 
		  (TransactionDate >= @LastFiscalYearEnd and TransactionDate < @EndDate and  closingjournal = 1 and (SpecialAccount <> 'BI' or SpecialAccount <> 'EI')) 
		   OR
		  (Month(TransactionDate) = Month(@StartDate) and Year(TransactionDate) = Year(@StartDate) and  closingjournal = 0 and SpecialAccount = 'BI')
		   OR 
		  (Month(TransactionDate) = Month(@EndDate) and Year(TransactionDate) = Year(@EndDate) and  closingjournal = 0 and SpecialAccount = 'EI')
		   OR
		  (Month(TransactionDate) = Month(@StartDate) and Year(TransactionDate) = Year(@StartDate) and  closingjournal = 1 and SpecialAccount = 'BI')
		   OR
		  (Month(TransactionDate) = Month(@EndDate) and Year(TransactionDate) = Year(@EndDate) and  closingjournal = 1 and SpecialAccount = 'EI')
	Group By idNo
)
GO
/****** Object:  Table [dbo].[TranslatedMessages]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TranslatedMessages](
	[idno] [int] IDENTITY(1,1) NOT NULL,
	[MessageIdNo] [smallint] NOT NULL,
	[LanguageIdNo] [smallint] NOT NULL,
	[TranslatedMessage] [nvarchar](512) NULL,
	[TranslatedCaption] [nvarchar](256) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_TranslatedMessagesIdNo] PRIMARY KEY CLUSTERED 
(
	[idno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OriginalMessages]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OriginalMessages](
	[idno] [smallint] IDENTITY(1,1) NOT NULL,
	[MessageKey] [varchar](50) NOT NULL,
	[Message] [varchar](256) NOT NULL,
	[Caption] [varchar](128) NULL,
	[Notes] [varchar](256) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_OriginalMessages] PRIMARY KEY CLUSTERED 
(
	[idno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[TranslatedMessages_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TranslatedMessages_View]
AS
SELECT        dbo.TranslatedMessages.idno, dbo.TranslatedMessages.MessageIdNo, dbo.TranslatedMessages.TranslatedMessage, dbo.TranslatedMessages.TranslatedCaption, dbo.TranslatedMessages.DateTimeStamp, 
                         dbo.TranslatedMessages.LanguageIdNo, dbo.OriginalMessages.MessageKey, dbo.OriginalMessages.Message, dbo.OriginalMessages.Caption, dbo.OriginalMessages.Notes, dbo.Languages.LanguageCode2, 
                         dbo.Languages.CultureInfoCode
FROM            dbo.TranslatedMessages LEFT OUTER JOIN
                         dbo.Languages ON dbo.TranslatedMessages.LanguageIdNo = dbo.Languages.IdNo RIGHT OUTER JOIN
                         dbo.OriginalMessages ON dbo.TranslatedMessages.MessageIdNo = dbo.OriginalMessages.idno
GO
/****** Object:  View [dbo].[ApStatement_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[ApStatement_View]
AS
SELECT        dbo.ApDetails_View.JournalCode, dbo.ApDetails_View.IdNo, dbo.ApDetails_View.Sequence, dbo.ApDetails_View.JournalIdNo, dbo.ApDetails_View.AccountIdNo, dbo.ApDetails_View.Debit, dbo.ApDetails_View.Credit, 
                         dbo.ApDetails_View.RevCostCenterIdNo, dbo.ApDetails_View.Notes, dbo.ApDetails_View.Posted, dbo.ApDetails_View.SupplierIdNo, dbo.ApDetails_View.InvoiceNo, dbo.ApDetails_View.TransactionDate, dbo.ApDetails_View.ReferenceNo, 
                         dbo.ApDetails_View.TransactionType, dbo.Account.SpecialAccount, dbo.APDetails_View.MainNote
FROM            dbo.ApDetails_View INNER JOIN
                         dbo.Account ON dbo.ApDetails_View.AccountIdNo = dbo.Account.IDNo
WHERE        (dbo.Account.SpecialAccount = 'AP')
GO
/****** Object:  View [dbo].[ARJournalTransaction_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[ARJournalTransaction_View]
AS
SELECT        dbo.ArJournalItem.Sequence, dbo.ArJournalItem.JournalIdNo, dbo.ArJournalItem.Debit, dbo.ArJournalItem.Credit, dbo.ArJournalItem.Notes, dbo.ArJournalItem.Posted, dbo.Customer.CustomerCode, 
                         dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, dbo.ArJournal.TransactionDate, dbo.ArJournal.ReferenceNo, dbo.ArJournal.Amount, dbo.ArJournal.InvoiceNo, dbo.ArJournal.InvoiceDate, 
                         dbo.ArJournal.Notes AS 'DetailNotes', dbo.ArJournal.Posted AS 'JOurnalPosted', dbo.ArJournal.Cancelled, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra, dbo.RevCostCenter.RevCostCenterCode
FROM            dbo.RevCostCenter RIGHT OUTER JOIN
                         dbo.ArJournalItem ON dbo.RevCostCenter.IdNo = dbo.ArJournalItem.RevCostCenterIdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.ArJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.ArJournal LEFT OUTER JOIN
                         dbo.Customer ON dbo.ArJournal.CustomerIdNo = dbo.Customer.IdNo ON dbo.ArJournalItem.JournalIdNo = dbo.ArJournal.IDNo
GO
/****** Object:  View [dbo].[PcOiItem_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PcOiItem_View]
AS
SELECT        dbo.PcOiItem.Sequence, dbo.ApOpenInvoice_View.InvoiceNo, dbo.ApOpenInvoice_View.TransactionDate, dbo.ApOpenInvoice_View.Balance + dbo.PcOiItem.Amount + dbo.PcOiItem.DiscountTaken AS PreviousBalance, 
                         dbo.PcOiItem.Amount, dbo.PcOiItem.DiscountTaken, dbo.ApOpenInvoice_View.Balance, dbo.ApOpenInvoice_View.Amount AS InvoiceAmount, dbo.PcOiItem.ApOpenInvoiceIdNo, dbo.ApOpenInvoice_View.JournalCode, 
                         dbo.ApOpenInvoice_View.JournalItemIdNo AS ApJournalItemIdNo, dbo.ApOpenInvoice_View.ReferenceNo, dbo.ApOpenInvoice_View.PaidAmount, dbo.PcOiItem.IdNo, dbo.ApOpenInvoice_View.SupplierIdNo, dbo.PcOiItem.DjIdNo, 
                         dbo.ApOpenInvoice_View.AccountIdNo, dbo.ApOpenInvoice_View.JournalIdNo
FROM            dbo.PcOiItem INNER JOIN
                         dbo.ApOpenInvoice_View ON dbo.PcOiItem.ApOpenInvoiceIdNo = dbo.ApOpenInvoice_View.IdNo
GO
/****** Object:  View [dbo].[ArStatement_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[ArStatement_View]
AS
SELECT        dbo.ARDetails_View.JournalCode, dbo.ARDetails_View.IdNo, dbo.ARDetails_View.Sequence, dbo.ARDetails_View.JournalIdNo, dbo.ARDetails_View.AccountIdNo, dbo.ARDetails_View.Debit, dbo.ARDetails_View.Credit, 
                         dbo.ARDetails_View.RevCostCenterIdNo, dbo.ARDetails_View.Notes, dbo.ARDetails_View.Posted, dbo.ARDetails_View.CustomerIdNo, dbo.ARDetails_View.InvoiceNo, dbo.ARDetails_View.TransactionDate, 
                         dbo.ARDetails_View.ReferenceNo, dbo.ARDetails_View.TransactionType, dbo.Account.SpecialAccount, dbo.ARDetails_View.MainNote, dbo.Customer.CustomerCode, dbo.Customer.CustomerName, 
                         dbo.Customer.CustomerNameAra
FROM            dbo.ARDetails_View INNER JOIN
                         dbo.Account ON dbo.ARDetails_View.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.Customer ON dbo.ARDetails_View.CustomerIdNo = dbo.Customer.IdNo
WHERE        (dbo.Account.SpecialAccount = 'AR' or dbo.Account.SpecialAccount = 'CA')
GO
/****** Object:  Table [dbo].[Department]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[IdNo] [smallint] NOT NULL,
	[DepartmentCode] [varchar](10) NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
	[DepartmentNameAra] [nvarchar](50) NOT NULL,
	[ParentIdNo] [smallint] NULL,
	[Notes] [nvarchar](250) NULL,
	[RevCostCenterIDNo] [smallint] NULL,
	[Active] [bit] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_DepartmentIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_DepartmentCode] UNIQUE NONCLUSTERED 
(
	[DepartmentCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_DepartmentName] UNIQUE NONCLUSTERED 
(
	[DepartmentName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_DepartmentNameAra] UNIQUE NONCLUSTERED 
(
	[DepartmentNameAra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Department_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE View [dbo].[Department_View] as 
with cte as
(
select IDNo
      ,DepartmentCode
      ,DepartmentName
      ,DepartmentNameAra
      ,ParentIdNo
      ,Notes
      ,RevCostCenterIDNo
      ,Active
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by DepartmentName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by DepartmentName) / power(10.0,0) as SortKey
 
from Department
where ParentIdNo IS NULL
union all
select t.IDNo
      ,t.DepartmentCode
      ,t.DepartmentName
      ,t.DepartmentNameAra
      ,t.ParentIdNo
      ,t.Notes
      ,t.RevCostCenterIdNo
      ,t.Active
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.DepartmentName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.DepartmentName) / power(10.0,levelnumber+1)
 
 from
    cte
join Department t on cte.IdNo = t.ParentIdNo
)
   
select IDNo
      ,DepartmentCode
      ,DepartmentName
      ,DepartmentNameAra
      ,ParentIdNo
      ,Notes
      ,RevCostCenterIdNo
      ,Active
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte
GO
/****** Object:  View [dbo].[JournalDetails_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE VIEW [dbo].[JournalDetails_View]	
  AS
(SELECT 'AP' AS 'JournalCode'
	  ,ai.[IdNo]
      ,ai.[Sequence]
      ,ai.[JournalIdNo]
      ,ai.[AccountIdNo]
      ,ai.[Debit]
      ,ai.[Credit]
      ,ai.[RevCostCenterIdNo]
      ,ai.[Notes] Collate Arabic_CI_AS AS 'Notes'
      ,ai.[Posted]
	  ,b.[SupplierIdNo]
	  ,b.[InvoiceNo] Collate Arabic_CI_AS AS 'InvoiceNo'
	  ,b.[TransactionDate]
      ,b.[ReferenceNo] Collate Arabic_CI_AS AS 'ReferenceNo'
	  ,b.[TransactionType] Collate SQL_Latin1_General_CP1_CI_AS AS 'TransactionType'
	  ,b.Notes Collate Arabic_CI_AS AS 'MainNote'
  FROM [ApJournalItem] aS ai
  LEFT OUTER JOIN ApJournal AS b
  on ai.JournalIdNo = b.IDNo 
)
UNION
(SELECT 'CK'
	  ,ai.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,ai.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,ai.[Notes]
	  ,ai.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [CkJournalItem] ai
  LEFT OUTER JOIN CkJournal b
  on ai.JournalIdNo = b.IDNo
  WHERE PaymentType='A'
)
UNION
(SELECT 'CD'
	  ,ai.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,ai.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,ai.[Notes]
	  ,ai.[Posted]
	  ,[PayeeIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [CdJournalItem] ai
  LEFT OUTER JOIN dbo.CdJournal b
  on ai.JournalIdNo = b.IDNo
  WHERE PaymentType='A'
)
UNION
(SELECT 'PC'
	  ,ai.[IdNo]
      ,ai.[Sequence]
	  ,ai.[JournalIdNo]
      ,ai.[AccountIdNo]
      ,ai.[Debit]
      ,ai.[Credit]
	  ,ai.[RevCostCenterIdNo]
      ,ai.[Notes]
	  ,ai.[Posted]
	  ,b.[PayeeIdNo]
	  ,b.[ReferenceNo]
	  ,b.[TransactionDate]
      ,b.[ReferenceNo]
	  ,b.[PaymentType]
	  ,b.Notes AS 'MainNote'
  FROM [PcJournalItem] as ai
  LEFT OUTER JOIN PcJournal as b
  on ai.JournalIdNo = b.IDNo
  WHERE PaymentType='A'
)
UNION
(SELECT 'CR'
	  ,ai.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,ai.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,ai.[Notes]
	  ,ai.[Posted]
	  ,[PayorIdNo]
	  ,[ReferenceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[PayorType]
	  ,b.Notes AS 'MainNote'
  FROM [CashReceiptJournalItem] as ai
  LEFT OUTER JOIN dbo.CashReceiptJournal as b
  on ai.JournalIdNo = b.IDNo
  WHERE PayorType='R'
)
GO
/****** Object:  View [dbo].[CrcJournalTransaction_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[CrcJournalTransaction_View]
AS
SELECT        dbo.CashReceiptJournal.TransactionDate, dbo.CashReceiptJournal.ReferenceNo, dbo.CashReceiptJournal.Amount, dbo.CashReceiptJournal.PayorName, 
                         dbo.CashReceiptJournal.CheckNumber, dbo.CashReceiptJournal.CheckDate, dbo.CashReceiptJournal.Notes, dbo.CashReceiptJournal.PayorType, 
                         dbo.CashReceiptJournalItem.Sequence, dbo.CashReceiptJournalItem.Debit, dbo.CashReceiptJournalItem.Credit, dbo.CashReceiptJournalItem.Notes AS CrNotes, dbo.CashReceiptJournal.ORNumber,
                         dbo.BankAccount.BranchName, dbo.Bank.BankName, dbo.Bank.BankNameAra, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Employee.EmployeeCode, dbo.Supplier.SupplierNameAra, 
                         dbo.Employee.EmployeeNameAra, dbo.Employee.EmployeeName, dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.CashReceiptJournal.IdNo, dbo.Customer.CustomerCode, 
                         dbo.Customer.CustomerName, dbo.Customer.CustomerNameAra, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra
FROM            dbo.CashReceiptJournal 
				LEFT OUTER JOIN dbo.CashReceiptJournalItem 
					ON dbo.CashReceiptJournal.IdNo = dbo.CashReceiptJournalItem.JournalIdNo 
				Left Outer Join dbo.Supplier 
					ON dbo.CashReceiptJournal.PayorIdNo = dbo.Supplier.IdNo
				Left Outer Join dbo.Customer
				    ON dbo.CashReceiptJournal.PayorIdNo = dbo.Customer.IdNo 
				Left Outer Join dbo.Employee 
					ON dbo.CashReceiptJournal.PayorIdNo = dbo.Employee.IdNo 
				Left Outer Join dbo.BankAccount 
					ON dbo.CashReceiptJournal.AccountIdNo = dbo.BankAccount.AccountIdNo 
				LEFT OUTER JOIN dbo.Account 
					ON dbo.CashReceiptJournalItem.AccountIdNo = dbo.Account.IdNo 
				LEFT OUTER JOIN dbo.Bank 
					ON dbo.BankAccount.BankIdNo = dbo.Bank.IdNo 
				Left Outer Join dbo.RevCostCenter
					On dbo.CashReceiptJournalItem.RevCostCenterIdNo = dbo.RevCostCenter.IdNo
GO
/****** Object:  View [dbo].[CashReceiptJournalItem_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CashReceiptJournalItem_View]
AS
SELECT        dbo.CashReceiptJournalItem.IdNo, dbo.CashReceiptJournalItem.Sequence, dbo.CashReceiptJournalItem.JournalIdNo, dbo.CashReceiptJournalItem.AccountIdNo, dbo.CashReceiptJournalItem.Debit, 
                         dbo.CashReceiptJournalItem.Credit, dbo.CashReceiptJournalItem.RevCostCenterIdNo, dbo.CashReceiptJournalItem.Notes, dbo.CashReceiptJournalItem.Posted, dbo.CashReceiptJournalItem.DateTimeStamp, 
                         dbo.Account.AccountName, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.IdNo AS OpenInvoiceIdNo, dbo.CashReceiptJournalItem.Credit - dbo.CashReceiptJournalItem.Debit AS OriginalAmount, 
                         dbo.ApOpenInvoice.PaidAmount, dbo.Account.SpecialAccount, dbo.Account.AccountNameAra, dbo.Account.PayeeType, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.CashReceiptJournalItem LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CashReceiptJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo AND dbo.ApOpenInvoice.JournalCode = 'AP' LEFT OUTER JOIN
                         dbo.Account ON dbo.CashReceiptJournalItem.AccountIdNo = dbo.Account.IDNo
GO
/****** Object:  Table [dbo].[GroupAccess]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupAccess](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[SecurityGroupIDNo] [smallint] NOT NULL,
	[SecurityObjectIDNo] [smallint] NOT NULL,
	[Visible] [bit] NOT NULL,
	[Editable] [bit] NOT NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_SecurityGroupAccessIDNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GroupAccess_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GroupAccess_View]
AS
SELECT        dbo.SecurityObject.IDNo, dbo.SecurityObject.SecurityObjectName, dbo.SecurityGroup.IDNo AS Expr1, dbo.GroupAccess.Visible, dbo.GroupAccess.Editable, dbo.GroupAccess.SecurityGroupIDNo, 
                         dbo.GroupAccess.SecurityObjectIDNo, dbo.GroupAccess.IDNo AS Expr2, dbo.SecurityGroup.SecurityGroupName
FROM            dbo.SecurityGroup INNER JOIN
                         dbo.GroupAccess ON dbo.SecurityGroup.IDNo = dbo.GroupAccess.SecurityGroupIDNo RIGHT OUTER JOIN
                         dbo.SecurityObject ON dbo.GroupAccess.SecurityObjectIDNo = dbo.SecurityObject.IDNo
GO
/****** Object:  View [dbo].[ErJournalTransaction_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ErJournalTransaction_View]
AS
SELECT        dbo.ErJournalItem.Sequence, dbo.ErJournalItem.JournalIdNo, dbo.ErJournalItem.Debit, dbo.ErJournalItem.Credit, dbo.ErJournalItem.Notes, dbo.ErJournalItem.Posted, dbo.Employee.EmployeeCode, 
                         dbo.ErJournal.TransactionDate, dbo.ErJournal.ReferenceNo, dbo.ErJournal.Amount, dbo.ErJournal.Notes AS ErNotes, dbo.ErJournal.Cancelled, dbo.Account.AccountCode, dbo.Account.AccountName, 
                         dbo.Account.AccountNameAra, dbo.RevCostCenter.RevCostCenterCode, dbo.Employee.EmployeeNameAra, dbo.Employee.Title, dbo.Employee.EmployeeName
FROM            dbo.RevCostCenter RIGHT OUTER JOIN
                         dbo.ErJournalItem ON dbo.RevCostCenter.IdNo = dbo.ErJournalItem.RevCostCenterIdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.ErJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.ErJournal LEFT OUTER JOIN
                         dbo.Employee ON dbo.ErJournal.EmployeeIdNo = dbo.Employee.IdNo ON dbo.ErJournalItem.JournalIdNo = dbo.ErJournal.IDNo
GO
/****** Object:  Table [dbo].[Deduction]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deduction](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[DeductionCode] [varchar](10) NULL,
	[DeductionName] [varchar](50) NULL,
	[DeductionNameAra] [nvarchar](50) NULL,
	[Frequency] [char](1) NULL,
	[AccountIdNo] [smallint] NULL,
	[DeductionType] [char](1) NULL,
	[DeductionPlace] [char](1) NULL,
	[BasePaymentIdNo] [smallint] NULL,
	[CalculationType] [char](1) NULL,
	[DefaultQuantity] [decimal](10, 4) NULL,
	[FactorValue] [decimal](10, 4) NULL,
	[FactorType] [char](1) NULL,
	[Rate] [money] NULL,
	[Unit] [char](1) NULL,
	[UsePayGroups] [bit] NULL,
	[Notes] [nvarchar](100) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_Deduction] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeDeduction]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeDeduction](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeIdNo] [smallint] NOT NULL,
	[DeductionIdNo] [smallint] NOT NULL,
	[Amount] [smallmoney] NULL,
	[Sequence] [smallint] NOT NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_EmployeeDeduction] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[EmployeeDeduction_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[EmployeeDeduction_View]
AS
SELECT        dbo.EmployeeDeduction.IdNo, dbo.EmployeeDeduction.EmployeeIdNo, dbo.EmployeeDeduction.DeductionIdNo, dbo.EmployeeDeduction.Amount, dbo.Deduction.DeductionCode, dbo.Deduction.DeductionName, 
                         dbo.Deduction.DeductionNameAra, dbo.Deduction.AccountIdNo AS Expr1, dbo.Deduction.DeductionType, dbo.Deduction.DeductionPlace, dbo.EmployeeDeduction.Sequence, dbo.Deduction.BasePaymentIdNo, 
                         dbo.Deduction.CalculationType, dbo.Deduction.DefaultQuantity, dbo.Deduction.FactorValue, dbo.Deduction.Rate, dbo.Deduction.FactorType, dbo.Deduction.Unit, dbo.Deduction.UsePayGroups
FROM            dbo.EmployeeDeduction INNER JOIN
                         dbo.Deduction ON dbo.EmployeeDeduction.DeductionIdNo = dbo.Deduction.IdNo
GO
/****** Object:  View [dbo].[GeneralJournalTransaction_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[GeneralJournalTransaction_View]
AS
SELECT        dbo.GeneralJournalItem.Sequence, dbo.GeneralJournalItem.JournalIdNo, dbo.GeneralJournalItem.AccountIdNo, dbo.GeneralJournalItem.Debit, dbo.GeneralJournalItem.Credit, 
                         dbo.GeneralJournalItem.RevCostCenterIdNo, dbo.GeneralJournalItem.Notes, dbo.GeneralJournalItem.Posted, dbo.GeneralJournal.TransactionDate, dbo.GeneralJournal.Notes AS GJNotes, 
                         dbo.GeneralJournal.ClosingJournal, dbo.GeneralJournal.Cancelled, dbo.GeneralJournal.ReferenceNo, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra, 
                         dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName, dbo.RevCostCenter.RevCostCenterNameAra
FROM            dbo.RevCostCenter RIGHT OUTER JOIN
                         dbo.GeneralJournalItem ON dbo.RevCostCenter.IdNo = dbo.GeneralJournalItem.RevCostCenterIdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.GeneralJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.GeneralJournal ON dbo.GeneralJournalItem.JournalIdNo = dbo.GeneralJournal.IdNo
GO
/****** Object:  Table [dbo].[Earning]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Earning](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[EarningCode] [varchar](10) NULL,
	[EarningName] [varchar](50) NULL,
	[EarningNameAra] [nvarchar](50) NULL,
	[Frequency] [char](1) NULL,
	[EarningType] [char](1) NULL,
	[AccountIdNo] [smallint] NULL,
	[BasePaymentIdNo] [smallint] NULL,
	[CalculationType] [char](1) NULL,
	[DefaultQuantity] [decimal](10, 4) NULL,
	[FactorValue] [decimal](10, 4) NULL,
	[FactorType] [char](1) NULL,
	[IncludeInEos] [bit] NULL,
	[Rate] [money] NULL,
	[Taxable] [bit] NULL,
	[Unit] [char](1) NULL,
	[UsePayGroups] [bit] NULL,
	[Notes] [nvarchar](100) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_Earning] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeEarning]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeEarning](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeIdNo] [int] NOT NULL,
	[EarningIdNo] [smallint] NOT NULL,
	[Amount] [smallmoney] NULL,
	[Sequence] [smallint] NOT NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK__Employee__3214EC075B264C4C] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[EmployeeEarning_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[EmployeeEarning_View]
AS
SELECT        dbo.EmployeeEarning.IdNo, dbo.EmployeeEarning.EmployeeIdNo, dbo.EmployeeEarning.EarningIdNo, dbo.EmployeeEarning.Amount, dbo.Earning.EarningCode, dbo.Earning.EarningName, dbo.Earning.EarningNameAra, 
                         dbo.Earning.Frequency, dbo.Earning.EarningType, dbo.EmployeeEarning.Sequence, dbo.Earning.CalculationType, dbo.Earning.DefaultQuantity, dbo.Earning.FactorValue, dbo.Earning.FactorType, 
                         dbo.Earning.BasePaymentIdNo, dbo.Earning.IncludeInEos, dbo.Earning.Rate, dbo.Earning.Taxable, dbo.Earning.Unit, dbo.Earning.UsePayGroups, dbo.Earning.AccountIdNo
FROM            dbo.EmployeeEarning INNER JOIN
                         dbo.Earning ON dbo.EmployeeEarning.EarningIdNo = dbo.Earning.IdNo
GO
/****** Object:  Table [dbo].[PayrollEarnAccount]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayrollEarnAccount](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[EarningIdNo] [smallint] NULL,
	[PayGroupIdNo] [smallint] NULL,
	[EmployeeIdNo] [int] NULL,
	[AccountIdNo] [smallint] NULL,
	[Sequence] [smallint] NULL,
 CONSTRAINT [PK_PayrollEarnAccount] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[PayrollEarnAccount_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PayrollEarnAccount_View]
AS
SELECT        dbo.PayrollEarnAccount.IdNo, dbo.PayrollEarnAccount.EarningIdNo, dbo.PayrollEarnAccount.PayGroupIdNo, dbo.PayrollEarnAccount.EmployeeIdNo, dbo.PayrollEarnAccount.AccountIdNo, dbo.Account.AccountCode, 
                         dbo.Account.AccountName, dbo.PayGroup.PayGroupCode, dbo.PayGroup.PayGroupName, dbo.PayGroup.PayGroupNameAra, dbo.Account.AccountNameAra, dbo.PayrollEarnAccount.Sequence
FROM            dbo.PayrollEarnAccount INNER JOIN
                         dbo.Account ON dbo.PayrollEarnAccount.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.PayGroup ON dbo.PayrollEarnAccount.PayGroupIdNo = dbo.PayGroup.IdNo
GO
/****** Object:  View [dbo].[SalesJournalItem_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[SalesJournalItem_View]
AS
SELECT        dbo.SalesJournalItem.IdNo, dbo.SalesJournalItem.Sequence, dbo.SalesJournalItem.JournalIdNo, dbo.SalesJournalItem.AccountIdNo, dbo.SalesJournalItem.Debit, dbo.SalesJournalItem.Credit, 
                         dbo.SalesJournalItem.RevCostCenterIdNo, dbo.Account.AccountName, dbo.SalesJournalItem.Debit - dbo.SalesJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, dbo.Account.SpecialAccount, dbo.SalesJournalItem.Notes, 
                         0 AS OpenInvoiceIdNo, 0 AS PaidAmount, 0 AS DiscountTaken
FROM            dbo.SalesJournalItem INNER JOIN
                         dbo.Account ON dbo.SalesJournalItem.AccountIdNo = dbo.Account.IDNo
GO
/****** Object:  Table [dbo].[EmployeeLoanJournal]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeLoanJournal](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeIdNo] [int] NOT NULL,
	[TransactionDate] [date] NULL,
	[ReferenceNo] [varchar](15) NULL,
	[TransactionType] [char](1) NULL,
	[Amount] [money] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[Notes] [nvarchar](255) NOT NULL,
	[Posted] [bit] NULL,
	[Cancelled] [bit] NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_EmployeeLoanIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeLoanJournalItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeLoanJournalItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [smallint] NULL,
	[JournalIdNo] [int] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[TransactionDate] [datetime2](7) NULL,
	[Debit] [money] NULL,
	[Credit] [money] NULL,
	[RevCostCenterIdNo] [smallint] NULL,
	[Notes] [nvarchar](100) NULL,
	[Posted] [bit] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_EmployeeLoanJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[EmployeeJournalItem_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[EmployeeJournalItem_View]
AS
SELECT        dbo.EmployeeLoanJournalItem.IdNo, dbo.EmployeeLoanJournalItem.Sequence, dbo.EmployeeLoanJournalItem.JournalIdNo, dbo.EmployeeLoanJournalItem.AccountIdNo, dbo.EmployeeLoanJournalItem.TransactionDate, dbo.EmployeeLoanJournalItem.Debit, 
                         dbo.EmployeeLoanJournalItem.Credit, dbo.EmployeeLoanJournalItem.RevCostCenterIdNo, dbo.EmployeeLoanJournalItem.Notes, dbo.EmployeeLoanJournalItem.Posted, dbo.EmployeeLoanJournalItem.DateTimeStamp, dbo.Account.AccountName
FROM            dbo.EmployeeLoanJournal INNER JOIN
                         dbo.EmployeeLoanJournalItem ON dbo.EmployeeLoanJournal.IDNo = dbo.EmployeeLoanJournalItem.JournalIdNo INNER JOIN
                         dbo.Account ON dbo.EmployeeLoanJournalItem.AccountIdNo = dbo.Account.IDNo
GO
/****** Object:  View [dbo].[SupplierInvoices]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[SupplierInvoices]
AS
SELECT        dbo.ApOpenInvoice.IdNo, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.JournalItemIdNo, dbo.ApOpenInvoice.PaidAmount, dbo.ApOpenInvoice.DiscountTaken, dbo.ApJournalItem.Debit, 
                         dbo.ApJournalItem.Credit, dbo.ApJournalItem.RevCostCenterIdNo, dbo.ApJournalItem.Notes, dbo.ApJournalItem.Posted, dbo.ApJournalItem.AccountIdNo, dbo.ApJournalItem.JournalIdNo, dbo.ApJournalItem.Sequence, 
                         dbo.ApJournal.SupplierIdNo, dbo.ApJournal.InvoiceNo, dbo.ApJournal.InvoiceDate, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierNameAra
FROM            dbo.Account INNER JOIN
                         dbo.ApJournalItem ON dbo.Account.IDNo = dbo.ApJournalItem.AccountIdNo INNER JOIN
                         dbo.ApJournal ON dbo.ApJournalItem.JournalIdNo = dbo.ApJournal.IDNo INNER JOIN
                         dbo.Supplier ON dbo.ApJournal.SupplierIdNo = dbo.Supplier.IDNo RIGHT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.ApJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  View [dbo].[CsrOiItem_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CsrOiItem_View]
AS
SELECT        dbo.CsrOiItem.Sequence, dbo.ArOpenInvoice_View.InvoiceNo, dbo.ArOpenInvoice_View.TransactionDate, 
                         dbo.ArOpenInvoice_View.Balance + dbo.CsrOiItem.Amount + dbo.CsrOiItem.DiscountTaken AS PreviousBalance, dbo.CsrOiItem.Amount, dbo.CsrOiItem.DiscountTaken, dbo.ArOpenInvoice_View.Balance, 
                         dbo.CsrOiItem.ArOpenInvoiceIdNo, dbo.ArOpenInvoice_View.Amount AS InvoiceAmount, dbo.ArOpenInvoice_View.JournalCode, dbo.ArOpenInvoice_View.JournalItemIdNo AS ArJournalItemIdNo, 
                         dbo.ArOpenInvoice_View.ReferenceNo, dbo.ArOpenInvoice_View.PaidAmount, dbo.CsrOiItem.IdNo, dbo.ArOpenInvoice_View.CustomerIdNo, dbo.ArOpenInvoice_View.IdNo AS OpenInvoiceIdNo, 
                         dbo.CsrOiItem.CsrIdNo, dbo.ArOpenInvoice_View.AccountIdNo, dbo.ArOpenInvoice_View.JournalIdNo
FROM            dbo.CsrOiItem LEFT OUTER JOIN
                         dbo.ArOpenInvoice_View ON dbo.CsrOiItem.ArOpenInvoiceIdNo = dbo.ArOpenInvoice_View.IdNo
GO
/****** Object:  View [dbo].[ApJournalTransaction_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[ApJournalTransaction_View]
AS
SELECT        dbo.ApJournalItem.JournalIdNo, dbo.ApJournalItem.AccountIdNo AS ApAccountIdNo, dbo.ApJournalItem.Debit, dbo.ApJournalItem.Credit, dbo.ApJournalItem.RevCostCenterIdNo, dbo.ApJournalItem.Notes AS ApNotes, 
                         dbo.ApJournalItem.Sequence, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.SupplierNameAra, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra, 
                         dbo.ApJournal.TransactionDate, dbo.ApJournal.ReferenceNo, dbo.ApJournal.TransactionType, dbo.ApJournal.Amount, dbo.ApJournal.AccountIdNo, dbo.ApJournal.InvoiceNo, dbo.ApJournal.InvoiceDate, 
                         dbo.ApJournal.VatNumber, dbo.ApJournal.VatAmount, dbo.ApJournal.Notes, dbo.ApJournal.DueDate, dbo.ApJournal.SettlementDueDate, dbo.ApJournal.SettlementDiscount, dbo.ApJournal.Posted, 
                         dbo.ApJournal.DateCreated, dbo.RevCostCenter.RevCostCenterNameAra, dbo.RevCostCenter.RevCostCenterCode, dbo.RevCostCenter.RevCostCenterName
FROM            dbo.ApJournalItem LEFT OUTER JOIN
                         dbo.RevCostCenter ON dbo.ApJournalItem.RevCostCenterIdNo = dbo.RevCostCenter.IdNo LEFT OUTER JOIN
                         dbo.Account ON dbo.ApJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.ApJournal INNER JOIN
                         dbo.Supplier ON dbo.ApJournal.SupplierIdNo = dbo.Supplier.IdNo ON dbo.ApJournalItem.JournalIdNo = dbo.ApJournal.IDNo
GO
/****** Object:  View [dbo].[CdOiItem_View]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CdOiItem_View]
AS
SELECT        dbo.CdOiItem.Sequence, dbo.ApOpenInvoice_View.InvoiceNo, dbo.ApOpenInvoice_View.TransactionDate, dbo.ApOpenInvoice_View.Balance + dbo.CdOiItem.Amount + dbo.CdOiItem.DiscountTaken AS PreviousBalance, 
                         dbo.CdOiItem.Amount, dbo.CdOiItem.DiscountTaken, dbo.ApOpenInvoice_View.Balance, dbo.ApOpenInvoice_View.Amount AS InvoiceAmount, dbo.ApOpenInvoice_View.JournalCode, 
                         dbo.ApOpenInvoice_View.JournalItemIdNo AS ApJournalItemIdNo, dbo.ApOpenInvoice_View.ReferenceNo, dbo.ApOpenInvoice_View.PaidAmount, dbo.CdOiItem.IdNo, dbo.CdOiItem.ApOpenInvoiceIdNo, 
                         dbo.ApOpenInvoice_View.SupplierIdNo, dbo.ApOpenInvoice_View.AccountIdNo, dbo.ApOpenInvoice_View.JournalIdNo, dbo.CdOiItem.DjIdNo
FROM            dbo.CdOiItem LEFT OUTER JOIN
                         dbo.ApOpenInvoice_View ON dbo.CdOiItem.ApOpenInvoiceIdNo = dbo.ApOpenInvoice_View.IdNo
GO
/****** Object:  Table [dbo].[AccountBalance]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountBalance](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Year] [smallint] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[Debit] [money] NULL,
	[Credit] [money] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_AccountBalance] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BankCharge]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankCharge](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[CashCode] [char](2) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[Rate] [decimal](5, 2) NULL,
 CONSTRAINT [PK_BankCharges] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BasicPay]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasicPay](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[EmpID] [varchar](15) NOT NULL,
	[Basic] [numeric](10, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[IDNo] [int] IDENTITY(1,1) NOT NULL,
	[BranchCode] [varchar](5) NOT NULL,
	[BranchName] [varchar](50) NOT NULL,
	[BranchNameAra] [nvarchar](50) NOT NULL,
	[Notes] [varchar](255) NULL,
	[Active] [bit] NULL,
	[CreateDate] [datetime2](7) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK__BranchIdNo] PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_BranchCode] UNIQUE NONCLUSTERED 
(
	[BranchCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_BranchName] UNIQUE NONCLUSTERED 
(
	[BranchName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_BranchNameAra] UNIQUE NONCLUSTERED 
(
	[BranchNameAra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CadOiItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CadOiItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[CadIdNo] [int] NOT NULL,
	[ApOpenInvoiceIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[DiscountTaken] [money] NOT NULL,
 CONSTRAINT [PK_CadOiItemIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CashCode]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashCode](
	[IdNo] [tinyint] IDENTITY(1,1) NOT NULL,
	[CashCode] [char](1) NULL,
	[CashName] [nvarchar](30) NULL,
	[CashNameAra] [nvarchar](30) NULL,
	[AccountIdNo] [int] NULL,
	[Rate] [decimal](5, 2) NULL,
	[WithBankCharges] [bit] NULL,
	[BankChargesAccountIdNo] [int] NULL,
	[BankChargesVatAccountIdNo] [int] NULL,
	[Notes] [nvarchar](255) NULL,
 CONSTRAINT [PK_CashCode] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[NameAra] [nvarchar](50) NULL,
	[Code] [varchar](5) NULL,
	[Notes] [nvarchar](255) NULL,
	[datetimestamp] [timestamp] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChartBalance]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChartBalance](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[Debit] [money] NULL,
	[Credit] [money] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_ChartBalance] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[countryf]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[countryf](
	[ID] [int] NOT NULL,
	[enabled] [tinyint] NOT NULL,
	[code3l] [varchar](3) NOT NULL,
	[code2l] [varchar](2) NOT NULL,
	[name] [varchar](64) NOT NULL,
	[name_official] [varchar](128) NULL,
	[flag_32] [varchar](255) NULL,
	[flag_128] [varchar](255) NULL,
	[latitude] [decimal](10, 8) NULL,
	[longitude] [decimal](11, 8) NULL,
	[flag032] [image] NULL,
	[flag123] [image] NULL,
	[zoom] [tinyint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CountryMaster]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CountryMaster](
	[Primary_Key] [int] NOT NULL,
	[CountryIOTA] [varchar](3) NOT NULL,
	[CountryNameEng] [varchar](35) NOT NULL,
	[CountryNameArabic] [nvarchar](35) NOT NULL,
	[Currency] [varchar](15) NOT NULL,
	[Rate] [numeric](6, 2) NOT NULL,
	[Flag] [image] NULL,
	[UserID] [varchar](15) NOT NULL,
	[Create_Date] [datetime] NOT NULL,
	[MachineID] [varchar](20) NOT NULL,
 CONSTRAINT [PK__CountryM__CE44E733DF9CCA21] PRIMARY KEY CLUSTERED 
(
	[Primary_Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[currencies]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[currencies](
	[id] [uniqueidentifier] NOT NULL,
	[number] [int] NOT NULL,
	[number_string] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_currencies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataBaseTable]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataBaseTable](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[TableName] [varchar](30) NULL,
	[TableNameCode] [char](3) NULL,
 CONSTRAINT [PK__DataBase] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DefaultFieldValue]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefaultFieldValue](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[TableName] [varchar](40) NOT NULL,
	[FieldName] [varchar](40) NOT NULL,
	[DataType] [tinyint] NOT NULL,
	[Length] [smallint] NOT NULL,
	[DecimalPart] [tinyint] NULL,
	[LinkedTable] [varchar](40) NULL,
	[LinkedFieldValue] [varchar](40) NULL,
	[LinkedField] [varchar](40) NULL,
	[DefaultValue] [varchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_DefaultFieldValue] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[DesignationCode] [varchar](5) NOT NULL,
	[DesignationName] [varchar](50) NOT NULL,
	[DesignationNameAra] [nvarchar](100) NULL,
	[Notes] [nvarchar](256) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiscountScheme]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiscountScheme](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](5) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[NameAra] [nvarchar](50) NULL,
	[Note] [nvarchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_DiscountScheme] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DistributionScheme]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DistributionScheme](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[DistributionSchemeCode] [varchar](5) NOT NULL,
	[DistributionSchemeName] [varchar](50) NOT NULL,
	[DistributionSchemeNameAra] [nvarchar](50) NOT NULL,
	[ValidityStartDate] [date] NOT NULL,
	[ValidityEndDate] [date] NOT NULL,
	[Notes] [nvarchar](256) NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_DistributionScheme] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DistributionSchemeItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DistributionSchemeItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[DistributionSchemeIdNo] [int] NULL,
	[Sequence] [smallint] NULL,
	[RevCostCenterIdNo] [smallint] NULL,
	[Percentage] [decimal](18, 2) NULL,
 CONSTRAINT [PK_DistributionSchemeItem] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[DocumentCode] [varchar](5) NOT NULL,
	[DocumentName] [varchar](50) NOT NULL,
	[DocumentNameAra] [nvarchar](50) NULL,
	[Description] [varchar](200) NULL,
	[DateTimeStamp] [timestamp] NULL,
	[DocumentType] [char](1) NULL,
	[NeedsExpiryDate] [bit] NULL,
	[NeedsIssueDate] [bit] NULL,
	[NeedsNumber] [bit] NULL,
	[ImageType] [char](1) NULL,
	[Image] [image] NULL,
	[CreateDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpEarnings]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpEarnings](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeIdNo] [smallint] NOT NULL,
	[Basic] [numeric](10, 2) NOT NULL,
	[HRA] [numeric](10, 2) NULL,
	[Food] [numeric](10, 2) NULL,
	[Transport] [numeric](10, 2) NULL,
	[OTRate] [numeric](10, 2) NULL,
	[Others] [numeric](10, 2) NULL,
	[PaymentMode] [varchar](20) NULL,
	[BankName] [varchar](50) NULL,
	[IBAN] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeAbsencesLeave]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAbsencesLeave](
	[IdNo] [int] NULL,
	[EmployeeIdNo] [int] NULL,
	[LeaveAbsenceIdNo] [smallint] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[Approved] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeActions]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeActions](
	[IdNo] [int] NULL,
	[EmployeeIdNo] [int] NULL,
	[ActionType] [char](1) NULL,
	[DateOfAction] [date] NULL,
	[DesignationIdNo] [smallint] NULL,
	[BasicPay] [money] NULL,
	[PayRateType] [char](1) NULL,
	[PayRateAmount] [money] NULL,
	[PayFrequency] [char](1) NULL,
	[Notes] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeDetails]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeDetails](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[BranchID] [varchar](4) NULL,
	[EmployeeID] [varchar](15) NOT NULL,
	[FIrstName] [varchar](40) NOT NULL,
	[FirstNameAra] [nvarchar](40) NULL,
	[BirthDate] [date] NULL,
	[DateJoined] [date] NULL,
	[DateReleased] [date] NULL,
	[Gender] [char](1) NULL,
	[NationalID] [varchar](3) NULL,
	[ReligionID] [varchar](3) NULL,
	[IQAMANo] [varchar](20) NULL,
	[Create_Date] [datetime] NULL,
 CONSTRAINT [PK_EmployeeDetails] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeLeave]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeLeave](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeIdNo] [int] NULL,
	[LeaveIdNo] [smallint] NOT NULL,
	[LeaveStart] [datetime] NULL,
	[LeaveEnd] [datetime] NULL,
	[FullDayLeave] [bit] NULL,
	[LeaveStatus] [char](1) NULL,
	[LeaveReason] [nvarchar](200) NULL,
	[DateCreated] [nchar](10) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_EmployeeLeave] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeNew]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeNew](
	[IdNo] [int] NOT NULL,
	[BranchID] [int] NULL,
	[EmployeeCode] [varchar](10) NULL,
	[Title] [varchar](25) NULL,
	[EmployeeName] [varchar](75) NOT NULL,
	[EmployeeNameAra] [nvarchar](75) NULL,
	[Gender] [varchar](1) NULL,
	[BirthDate] [date] NULL,
	[MaritalStatus] [char](1) NULL,
	[NationalityCode] [char](2) NULL,
	[NationalityId] [varchar](15) NULL,
	[ReligionIdNo] [int] NULL,
	[ReligionId] [varchar](15) NULL,
	[NationalIdNo] [varchar](10) NULL,
	[Street] [nvarchar](50) NULL,
	[District] [nvarchar](50) NULL,
	[TownCity] [nvarchar](50) NULL,
	[ProvinceState] [nvarchar](50) NULL,
	[CountryCode] [char](2) NULL,
	[PoBox] [varchar](15) NULL,
	[ZipCode] [varchar](15) NULL,
	[Phone1] [varchar](15) NULL,
	[Phone2] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
	[DepartmentIdNo] [varchar](15) NULL,
	[DesignationIdNo] [varchar](15) NULL,
	[HiredDate] [date] NULL,
	[ReleasedDate] [date] NULL,
	[ArAccountIdNo] [int] NULL,
	[BankIdNo] [int] NULL,
	[BankAccountNo] [varchar](15) NULL,
	[IBAN] [varchar](20) NULL,
	[Notes] [varchar](300) NULL,
	[OpeningBalance] [money] NULL,
	[Balance] [money] NULL,
	[Active] [bit] NULL,
	[Create_Date] [datetime] NULL,
	[DateTimeStamp] [timestamp] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeOld]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeOld](
	[IDNo] [int] IDENTITY(1,1) NOT NULL,
	[BranchID] [varchar](4) NULL,
	[EmployeeID] [varchar](15) NOT NULL,
	[FirstName] [varchar](40) NOT NULL,
	[MiddleName] [varchar](40) NULL,
	[ThirdName] [varchar](40) NULL,
	[LastName] [varchar](40) NOT NULL,
	[FirstNameAra] [varchar](40) NOT NULL,
	[MiddleNameAra] [varchar](40) NULL,
	[ThirdNameAra] [varchar](40) NULL,
	[LastNameAra] [varchar](40) NOT NULL,
	[NationalityID] [int] NULL,
	[BirthDate] [date] NULL,
	[DateJoined] [varchar](10) NULL,
	[DateReleased] [varchar](10) NULL,
	[Gender] [char](1) NULL,
	[Age] [numeric](2, 0) NULL,
	[AgeYMD] [char](1) NULL,
	[BloodGroup] [varchar](5) NULL,
	[MaritalStatus] [char](1) NULL,
	[NationalID] [varchar](3) NULL,
	[ReligionID] [int] NULL,
	[FileNo] [varchar](20) NULL,
	[DepartmentIDNo] [int] NULL,
	[DesignationIDNo] [int] NULL,
	[PayGroupIDNo] [int] NULL,
	[PayRank] [int] NULL,
	[UserID] [varchar](15) NULL,
	[MainTelephone] [varchar](15) NULL,
	[CompanyEmail] [varchar](50) NULL,
	[EmployeeTypeID] [int] NULL,
	[PassportNo] [varchar](10) NULL,
	[EmergencyName] [varchar](20) NULL,
	[EmergencyPhone] [varchar](15) NULL,
	[Photograph] [image] NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK__Employee__B87DC9ABAA40C497] PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Establishment]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Establishment](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[EstablishmentName] [nvarchar](100) NULL,
	[EstablishmentNameAra] [nvarchar](100) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[EMailAddress] [varchar](50) NULL,
	[WebSite] [varchar](50) NULL,
	[Address] [nvarchar](200) NULL,
 CONSTRAINT [PK_Establishment] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InterfaceObjectsSecurity]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InterfaceObjectsSecurity](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[LoginIDNo] [int] NOT NULL,
	[InterfaceObjectIDNo] [int] NOT NULL,
	[Editable] [bit] NOT NULL,
	[Visible] [bit] NOT NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_InterfaceObjectSecurity] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[LeaveCode] [varchar](3) NULL,
	[LeaveName] [varchar](100) NOT NULL,
	[LeaveNameAra] [nvarchar](100) NOT NULL,
	[NumberOfDays] [smallint] NULL,
	[PaidPercent] [decimal](6, 2) NULL,
	[MaxCarryOver] [smallint] NULL,
	[Cumulative] [bit] NULL,
	[MaxLimit] [decimal](7, 2) NULL,
	[Notes] [nvarchar](200) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_AbsenceLeave] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Idno] [smallint] NULL,
	[MessageCode] [varchar](50) NULL,
	[MessageText] [nvarchar](512) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NameTranslation]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NameTranslation](
	[IdNo] [bigint] IDENTITY(1,1) NOT NULL,
	[Language] [char](2) NOT NULL,
	[DatabaseTableIdNo] [smallint] NOT NULL,
	[TableIdNo] [smallint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_NameTranslation] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NumberSeries]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NumberSeries](
	[SeriesName] [varchar](25) NULL,
	[CurrentValue] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[BranchID] [varchar](15) NOT NULL,
	[Series] [varchar](2) NOT NULL,
	[RegistrationNo] [numeric](12, 0) NOT NULL,
	[GroupNo] [numeric](12, 0) NULL,
	[RegistrationDate] [varchar](10) NULL,
	[PatientType] [varchar](15) NULL,
	[BillType] [varchar](2) NOT NULL,
	[Courtesy] [varchar](10) NULL,
	[PatientName] [varchar](50) NOT NULL,
	[PatientNameAra] [nvarchar](50) NULL,
	[Address1] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[Street] [varchar](50) NULL,
	[City] [varchar](30) NULL,
	[IqamaNo] [nvarchar](10) NULL,
	[PassportNo] [nvarchar](15) NULL,
	[PhoneR] [varchar](10) NULL,
	[PhoneO] [varchar](10) NULL,
	[Mobile] [varchar](15) NULL,
	[eMail] [varchar](30) NULL,
	[Alert] [char](1) NULL,
	[DOB] [varchar](10) NULL,
	[Age] [numeric](3, 0) NULL,
	[AgeYMD] [char](1) NULL,
	[Sex] [char](1) NULL,
	[CountryIOTA] [varchar](3) NOT NULL,
	[CountryPhone] [varchar](10) NULL,
	[InsCoCode] [varchar](15) NULL,
	[DeductionCategory] [varchar](15) NULL,
	[SplConsultationDays] [numeric](10, 0) NULL,
	[LastConsDate] [varchar](10) NULL,
	[InsCardNo] [varchar](30) NULL,
	[InsCardExpiry] [varchar](10) NULL,
	[InsCardStatus] [char](1) NULL,
	[InsSoapNo] [varchar](30) NULL,
	[InsSoapCode] [varchar](30) NULL,
	[InsPolicy] [varchar](30) NULL,
	[SalesmanCode] [varchar](10) NULL,
	[Limit] [numeric](12, 2) NULL,
	[BalanceAmt] [numeric](12, 2) NULL,
	[Restricted] [varchar](1) NULL,
	[AC_Code] [varchar](15) NULL,
	[DoctorCode] [varchar](10) NULL,
	[FingureScan] [varchar](1) NULL,
	[FingureScanned] [varchar](1) NULL,
	[FaceScan] [varchar](1) NULL,
	[FaceScanned] [varchar](1) NULL,
	[Remarks] [varchar](300) NULL,
	[UserID] [varchar](15) NULL,
	[Create_Date] [datetime] NULL,
	[MachineID] [varchar](20) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_PatientDetails] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientNoGaps]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientNoGaps](
	[Start_No] [int] NULL,
	[End_No] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayInformation]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayInformation](
	[IdNo] [int] NULL,
	[EmployeeIdNo] [int] NULL,
	[FrequencyOfPay] [char](1) NULL,
	[SalariedOrHourly] [char](1) NULL,
	[Rate] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payroll]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payroll](
	[IdNo] [int] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[PayrollType] [char](1) NULL,
	[Notes] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayrollDetails]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayrollDetails](
	[IdNo] [int] NULL,
	[PayrollIdNo] [int] NULL,
	[EmployeeIdNo] [int] NULL,
	[EarningIdNo] [int] NULL,
	[Amount] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PensionProvider]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PensionProvider](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[PensionProviderCode] [varchar](15) NOT NULL,
	[PensionProviderName] [varchar](50) NOT NULL,
	[PensionProviderNameAra] [nvarchar](50) NOT NULL,
	[ContactPerson] [nvarchar](50) NULL,
	[ContactDesignation] [nvarchar](50) NULL,
	[Street] [nvarchar](50) NULL,
	[District] [nvarchar](35) NULL,
	[TownCity] [nvarchar](35) NULL,
	[ProvinceState] [nvarchar](35) NULL,
	[CountryCode] [char](2) NULL,
	[POBox] [varchar](10) NULL,
	[ZipCode] [varchar](10) NULL,
	[Phone1] [varchar](15) NULL,
	[Phone2] [varchar](15) NULL,
	[Mobile] [varchar](15) NULL,
	[Fax] [varchar](15) NULL,
	[Email] [varchar](254) NULL,
	[Website] [varchar](254) NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[BankAccountNo] [varchar](20) NULL,
	[BankIdNo] [smallint] NULL,
	[IBAN] [varchar](35) NULL,
	[PaymentMethod] [char](2) NULL,
	[Notes] [nvarchar](255) NULL,
	[Active] [bit] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_PensionProviderDetailsIDNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_PensionProviderName] UNIQUE NONCLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_PensionProviderNameAra] UNIQUE NONCLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PensionRate]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PensionRate](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[PensionSchemeIdNo] [smallint] NULL,
	[LowRange] [money] NULL,
	[HighRange] [money] NULL,
	[MaxAmount] [money] NULL,
	[EmployeeShare] [decimal](8, 2) NULL,
	[EmployerShare] [decimal](8, 2) NULL,
	[Sequence] [smallint] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_PensionRates] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PensionScheme]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PensionScheme](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[PensionSchemeCode] [varchar](10) NOT NULL,
	[PensionSchemeName] [varchar](50) NOT NULL,
	[PensionSchemeNameAra] [nvarchar](50) NOT NULL,
	[PensionProviderIdNo] [smallint] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[Notes] [nvarchar](100) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_Pension] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[ProductCategoryCode] [varchar](10) NOT NULL,
	[ProductCategoryName] [varchar](50) NOT NULL,
	[ProductCategoryNameAra] [nvarchar](100) NOT NULL,
	[Notes] [nvarchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfitCenterOld]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfitCenterOld](
	[IDNo] [smallint] IDENTITY(1,1) NOT NULL,
	[ProfitCenterCode] [varchar](5) NOT NULL,
	[ProfitCenterName] [varchar](50) NOT NULL,
	[ProfitCenterNameAra] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfitCenterOrg]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfitCenterOrg](
	[IDNo] [int] NOT NULL,
	[ParentID] [int] NULL,
	[ProfitCenterCode] [varchar](5) NOT NULL,
	[ProfitCenterName] [varchar](50) NOT NULL,
	[ProfitCenterNameAra] [nvarchar](50) NOT NULL,
	[Descripton] [varchar](50) NULL,
	[EmployeeName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseItem]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[CategoryIdNo] [smallint] NULL,
	[PurchaseitemCode] [varchar](10) NOT NULL,
	[PurchaseitemName] [varchar](50) NOT NULL,
	[PurchaseitemNameAra] [nvarchar](100) NULL,
	[Unit1] [nvarchar](20) NOT NULL,
	[Unit2] [nvarchar](20) NULL,
	[Unit3] [nvarchar](20) NULL,
	[Unit1Ara] [nvarchar](40) NULL,
	[Unit2Ara] [nvarchar](40) NULL,
	[Unit3Ara] [nvarchar](40) NULL,
	[StdPrice1] [money] NULL,
	[StdPrice2] [money] NULL,
	[StdPrice3] [money] NULL,
	[GlAccountIdNo] [smallint] NULL,
	[VatAccountIdNo] [smallint] NULL,
	[Active] [bit] NULL,
	[DateCreated] [date] NULL,
	[DateTimeStamp] [timestamp] NULL,
	[CreatedByIdNo] [smallint] NULL,
 CONSTRAINT [PK_PurchaseItem] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseJournal]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseJournal](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[SupplierIdNo] [int] NOT NULL,
	[TransactionDate] [date] NULL,
	[ReferenceNo] [varchar](15) NULL,
	[Amount] [money] NOT NULL,
	[AccountIdNo] [smallint] NOT NULL,
	[DueDate] [date] NULL,
	[SettlementDueDate] [date] NULL,
	[SettlementDiscount] [decimal](5, 2) NULL,
	[InvoiceNo] [varchar](15) NOT NULL,
	[InvoiceDate] [date] NULL,
	[VatNumber] [varchar](15) NULL,
	[VatAmount] [money] NULL,
	[Notes] [nvarchar](255) NOT NULL,
	[Posted] [bit] NULL,
	[Cancelled] [bit] NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_PurchaseIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiptDetails]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiptDetails](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[AccountIdNo] [smallint] NULL,
	[CheckPayment] [bit] NULL,
	[CheckReferenceNo] [varchar](15) NULL,
	[ORNumber] [varchar](15) NULL,
	[DiscountTaken] [money] NULL,
	[CheckReferenceDate] [date] NULL,
	[Applied] [money] NULL,
	[UnApplied] [money] NULL,
 CONSTRAINT [PK_ReceiptDetails] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reconciliation]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reconciliation](
	[IdNo] [bigint] IDENTITY(1,1) NOT NULL,
	[ReconciliationDate] [date] NULL,
	[Cleared] [bit] NULL,
	[Reconciled] [bit] NULL,
 CONSTRAINT [PK_Reconciliation] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Religion]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Religion](
	[IdNo] [tinyint] IDENTITY(1,1) NOT NULL,
	[ReligionCode] [varchar](5) NOT NULL,
	[ReligionName] [varchar](15) NOT NULL,
	[ReligionNameAra] [nvarchar](30) NULL,
	[Notes] [nvarchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_Religion] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salt]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salt](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[LoginIDNo] [int] NOT NULL,
	[Salt] [varchar](50) NULL,
	[Modified] [timestamp] NOT NULL,
 CONSTRAINT [PK_SaltIDNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Series]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Series](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[SeriesName] [varchar](20) NULL,
	[Value] [int] NULL,
	[Prefix] [varchar](10) NULL,
	[Suffix] [varchar](10) NULL,
	[MaxLength] [int] NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Series] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[IdNo] [smallint] NOT NULL,
	[Group] [varchar](10) NOT NULL,
	[SettingCode] [varchar](10) NOT NULL,
	[ValueType] [varchar](2) NULL,
	[Value] [varchar](100) NULL,
	[Notes] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SJPrefix]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SJPrefix](
	[IdNo] [tinyint] NOT NULL,
	[AccountIdNo] [smallint] NULL,
	[Prefix] [char](1) NULL,
 CONSTRAINT [PK_SJPrefix] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableName]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableName](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[DatabaseTableIdNo] [smallint] NULL,
	[TableIdNo] [smallint] NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_TableName] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdNo] [smallint] IDENTITY(18,1) NOT NULL,
	[UserName] [varchar](20) NOT NULL,
	[Password] [varchar](50) NULL,
	[SecurityGroupIDNo] [smallint] NULL,
	[FullName] [varchar](50) NULL,
	[FullNameAra] [nvarchar](50) NULL,
	[SecurityLevel] [tinyint] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_UserIDNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[xxxLoginxxx]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[xxxLoginxxx](
	[IDNo] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[Modified] [timestamp] NOT NULL,
	[SecurityGroupIDNo] [int] NULL,
 CONSTRAINT [PK_LoginIDNo] PRIMARY KEY CLUSTERED 
(
	[IDNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccountReconciliation] ADD  CONSTRAINT [DF_AccountReconciliation_Balance]  DEFAULT ((0)) FOR [Balance]
GO
ALTER TABLE [dbo].[AccountReconciliation] ADD  CONSTRAINT [DF_AccountReconciliation_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[ApJournal] ADD  CONSTRAINT [DF_ApJournal_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[ApJournalItem] ADD  CONSTRAINT [DF_ApJournalItem_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO
ALTER TABLE [dbo].[ApJournalItem] ADD  CONSTRAINT [DF_ApJournalItem_JournalIdNo]  DEFAULT ((0)) FOR [JournalIdNo]
GO
ALTER TABLE [dbo].[ApJournalItem] ADD  CONSTRAINT [DF_ApJournalItem_AccountIdNo]  DEFAULT ((0)) FOR [AccountIdNo]
GO
ALTER TABLE [dbo].[ApJournalItem] ADD  CONSTRAINT [DF_ApJournalItem_Debit]  DEFAULT ((0)) FOR [Debit]
GO
ALTER TABLE [dbo].[ApJournalItem] ADD  CONSTRAINT [DF_ApJournalItem_Credit]  DEFAULT ((0)) FOR [Credit]
GO
ALTER TABLE [dbo].[ApJournalItem] ADD  CONSTRAINT [DF_ApJournalItem_ProfitCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
GO
ALTER TABLE [dbo].[ApJournalItem] ADD  CONSTRAINT [DF_ApJournalItem_Posted]  DEFAULT ((0)) FOR [Posted]
GO
ALTER TABLE [dbo].[ApOpenInvoice] ADD  CONSTRAINT [DF_ApOpenInvoice_PaidAmount]  DEFAULT ((0)) FOR [PaidAmount]
GO
ALTER TABLE [dbo].[ApOpenInvoice] ADD  CONSTRAINT [DF_ApOpenInvoice_DiscountTaken]  DEFAULT ((0)) FOR [DiscountTaken]
GO
ALTER TABLE [dbo].[ArJournal] ADD  CONSTRAINT [DF_ArJournal_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[ArJournalItem] ADD  CONSTRAINT [DF_ArJournalItem_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO
ALTER TABLE [dbo].[ArJournalItem] ADD  CONSTRAINT [DF_ArJournalItem_JournalIdNo]  DEFAULT ((0)) FOR [JournalIdNo]
GO
ALTER TABLE [dbo].[ArJournalItem] ADD  CONSTRAINT [DF_ArJournalItem_AccountIdNo]  DEFAULT ((0)) FOR [AccountIdNo]
GO
ALTER TABLE [dbo].[ArJournalItem] ADD  CONSTRAINT [DF_ArJournalItem_Debit]  DEFAULT ((0)) FOR [Debit]
GO
ALTER TABLE [dbo].[ArJournalItem] ADD  CONSTRAINT [DF_ArJournalItem_Credit]  DEFAULT ((0)) FOR [Credit]
GO
ALTER TABLE [dbo].[ArJournalItem] ADD  CONSTRAINT [DF_ArJournalItem_ProfitCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
GO
ALTER TABLE [dbo].[ArJournalItem] ADD  CONSTRAINT [DF_ArJournalItem_Posted]  DEFAULT ((0)) FOR [Posted]
GO
ALTER TABLE [dbo].[CashReceiptJournal] ADD  CONSTRAINT [DF_CashReceiptJournal_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[CashReceiptJournalItem] ADD  CONSTRAINT [DF_CashReceiptJournalItem_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO
ALTER TABLE [dbo].[CashReceiptJournalItem] ADD  CONSTRAINT [DF_CashReceiptJournalItem_JournalIdNo]  DEFAULT ((0)) FOR [JournalIdNo]
GO
ALTER TABLE [dbo].[CashReceiptJournalItem] ADD  CONSTRAINT [DF_CashReceiptJournalItem_AccountIdNo]  DEFAULT ((0)) FOR [AccountIdNo]
GO
ALTER TABLE [dbo].[CashReceiptJournalItem] ADD  CONSTRAINT [DF_CashReceiptJournalItem_Debit]  DEFAULT ((0)) FOR [Debit]
GO
ALTER TABLE [dbo].[CashReceiptJournalItem] ADD  CONSTRAINT [DF_CashReceiptJournalItem_Credit]  DEFAULT ((0)) FOR [Credit]
GO
ALTER TABLE [dbo].[CashReceiptJournalItem] ADD  CONSTRAINT [DF_CashReceiptJournalItem_ProfitCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
GO
ALTER TABLE [dbo].[CashReceiptJournalItem] ADD  CONSTRAINT [DF_CashReceiptJournalItem_Posted]  DEFAULT ((0)) FOR [Posted]
GO
ALTER TABLE [dbo].[CdJournal] ADD  CONSTRAINT [DF_CashDisbursementJournal_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[CdJournalItem] ADD  CONSTRAINT [DF_CashDisbursementJournalItem_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO
ALTER TABLE [dbo].[CdJournalItem] ADD  CONSTRAINT [DF_CashDisbursementJournalItem_JournalIdNo]  DEFAULT ((0)) FOR [JournalIdNo]
GO
ALTER TABLE [dbo].[CdJournalItem] ADD  CONSTRAINT [DF_CashDisbursementJournalItem_AccountIdNo]  DEFAULT ((0)) FOR [AccountIdNo]
GO
ALTER TABLE [dbo].[CdJournalItem] ADD  CONSTRAINT [DF_CashDisbursementJournalItem_Debit]  DEFAULT ((0)) FOR [Debit]
GO
ALTER TABLE [dbo].[CdJournalItem] ADD  CONSTRAINT [DF_CashDisbursementJournalItem_Credit]  DEFAULT ((0)) FOR [Credit]
GO
ALTER TABLE [dbo].[CdJournalItem] ADD  CONSTRAINT [DF_CashDisbursementJournalItem_ProfitCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
GO
ALTER TABLE [dbo].[CdJournalItem] ADD  CONSTRAINT [DF_CashDisbursementJournalItem_Posted]  DEFAULT ((0)) FOR [Posted]
GO
ALTER TABLE [dbo].[CkJournal] ADD  CONSTRAINT [DF_ChequeDisbursementJournal1_DateAdded]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[CkJournalItem] ADD  CONSTRAINT [DF_ChequeDisbursementJournalItem_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO
ALTER TABLE [dbo].[CkJournalItem] ADD  CONSTRAINT [DF_ChequeDisbursementJournalItem_JournalIdNo]  DEFAULT ((0)) FOR [JournalIdNo]
GO
ALTER TABLE [dbo].[CkJournalItem] ADD  CONSTRAINT [DF_ChequeDisbursementJournalItem_AccountIdNo]  DEFAULT ((0)) FOR [AccountIdNo]
GO
ALTER TABLE [dbo].[CkJournalItem] ADD  CONSTRAINT [DF_ChequeDisbursementJournalItem_Debit]  DEFAULT ((0)) FOR [Debit]
GO
ALTER TABLE [dbo].[CkJournalItem] ADD  CONSTRAINT [DF_ChequeDisbursementJournalItem_Credit]  DEFAULT ((0)) FOR [Credit]
GO
ALTER TABLE [dbo].[CkJournalItem] ADD  CONSTRAINT [DF_ChequeDisbursementJournalItem_ProfitCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
GO
ALTER TABLE [dbo].[CkJournalItem] ADD  CONSTRAINT [DF_ChequeDisbursementJournalItem_Posted]  DEFAULT ((0)) FOR [Posted]
GO
ALTER TABLE [dbo].[CkOiItem] ADD  CONSTRAINT [DF_CkdOiItem_Amount]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[CkOiItem] ADD  CONSTRAINT [DF_CkdOiItem_DiscountTaken]  DEFAULT ((0)) FOR [DiscountTaken]
GO
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF__Countries__count__2A4B4B5E]  DEFAULT ('') FOR [CountryCode]
GO
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF__Countries__count__2B3F6F97]  DEFAULT ('') FOR [CountryName]
GO
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF__Countries__count__2C3393D0]  DEFAULT ('') FOR [CountryNameAra]
GO
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF__Countries__count__2D27B809]  DEFAULT ('') FOR [Nationality]
GO
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF__Countries__count__2E1BDC42]  DEFAULT ('') FOR [NationalityAra]
GO
ALTER TABLE [dbo].[countryf] ADD  CONSTRAINT [DF__countryf__enable__44FF419A]  DEFAULT ('1') FOR [enabled]
GO
ALTER TABLE [dbo].[countryf] ADD  CONSTRAINT [DF__countryf__name_o__45F365D3]  DEFAULT (NULL) FOR [name_official]
GO
ALTER TABLE [dbo].[countryf] ADD  CONSTRAINT [DF__countryf__flag_3__46E78A0C]  DEFAULT (NULL) FOR [flag_32]
GO
ALTER TABLE [dbo].[countryf] ADD  CONSTRAINT [DF__countryf__flag_1__47DBAE45]  DEFAULT (NULL) FOR [flag_128]
GO
ALTER TABLE [dbo].[countryf] ADD  CONSTRAINT [DF__countryf__latitu__48CFD27E]  DEFAULT (NULL) FOR [latitude]
GO
ALTER TABLE [dbo].[countryf] ADD  CONSTRAINT [DF__countryf__longit__49C3F6B7]  DEFAULT (NULL) FOR [longitude]
GO
ALTER TABLE [dbo].[countryf] ADD  CONSTRAINT [DF__countryf__zoom__4AB81AF0]  DEFAULT (NULL) FOR [zoom]
GO
ALTER TABLE [dbo].[CountryMaster] ADD  CONSTRAINT [DF_Date]  DEFAULT (getdate()) FOR [Create_Date]
GO
ALTER TABLE [dbo].[CsrOiItem] ADD  CONSTRAINT [DF_CsrOiItem_Amount]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[CsrOiItem] ADD  CONSTRAINT [DF_CsrOiItem_DiscountTaken]  DEFAULT ((0)) FOR [DiscountTaken]
GO
ALTER TABLE [dbo].[currencies] ADD  CONSTRAINT [DF_currencies_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer2_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[EmployeeEarning] ADD  CONSTRAINT [DF__EmployeeF__Amoun__3FFB60B2]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[EmployeeLoanJournal] ADD  CONSTRAINT [DF_EmployeeLoanJournal_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[EmployeeOld] ADD  CONSTRAINT [DF__Employee__Branch__5B438874]  DEFAULT ('0001') FOR [BranchID]
GO
ALTER TABLE [dbo].[EmployeeOld] ADD  CONSTRAINT [DF__Employee__Gender__5C37ACAD]  DEFAULT ('M') FOR [Gender]
GO
ALTER TABLE [dbo].[EmployeeOld] ADD  CONSTRAINT [DF__Employee__UserID__5D2BD0E6]  DEFAULT ('Admin') FOR [UserID]
GO
ALTER TABLE [dbo].[ErJournal] ADD  CONSTRAINT [DF_ErJournal_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[ErJournalItem] ADD  CONSTRAINT [DF_ErJournalItem_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO
ALTER TABLE [dbo].[ErJournalItem] ADD  CONSTRAINT [DF_ErJournalItem_JournalIdNo]  DEFAULT ((0)) FOR [JournalIdNo]
GO
ALTER TABLE [dbo].[ErJournalItem] ADD  CONSTRAINT [DF_ErJournalItem_AccountIdNo]  DEFAULT ((0)) FOR [AccountIdNo]
GO
ALTER TABLE [dbo].[ErJournalItem] ADD  CONSTRAINT [DF_ErJournalItem_Debit]  DEFAULT ((0)) FOR [Debit]
GO
ALTER TABLE [dbo].[ErJournalItem] ADD  CONSTRAINT [DF_ErJournalItem_Credit]  DEFAULT ((0)) FOR [Credit]
GO
ALTER TABLE [dbo].[ErJournalItem] ADD  CONSTRAINT [DF_ErJournalItem_ProfitCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
GO
ALTER TABLE [dbo].[ErJournalItem] ADD  CONSTRAINT [DF_ErJournalItem_Posted]  DEFAULT ((0)) FOR [Posted]
GO
ALTER TABLE [dbo].[ErOpenInvoice] ADD  CONSTRAINT [DF_ErOpenInvoice_PaidAmount]  DEFAULT ((0)) FOR [PaidAmount]
GO
ALTER TABLE [dbo].[GeneralJournal] ADD  CONSTRAINT [DF_GeneralJournal_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[GeneralJournalItem] ADD  CONSTRAINT [DF_GeneralJournalItem_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO
ALTER TABLE [dbo].[GeneralJournalItem] ADD  CONSTRAINT [DF_GeneralJournalItem_JournalIdNo]  DEFAULT ((0)) FOR [JournalIdNo]
GO
ALTER TABLE [dbo].[GeneralJournalItem] ADD  CONSTRAINT [DF_GeneralJournalItem_AccountIdNo]  DEFAULT ((0)) FOR [AccountIdNo]
GO
ALTER TABLE [dbo].[GeneralJournalItem] ADD  CONSTRAINT [DF_GeneralJournalItem_Debit]  DEFAULT ((0)) FOR [Debit]
GO
ALTER TABLE [dbo].[GeneralJournalItem] ADD  CONSTRAINT [DF_GeneralJournalItem_Credit]  DEFAULT ((0)) FOR [Credit]
GO
ALTER TABLE [dbo].[GeneralJournalItem] ADD  CONSTRAINT [DF_GeneralJournalItem_ProfitCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
GO
ALTER TABLE [dbo].[GeneralJournalItem] ADD  CONSTRAINT [DF_GeneralJournalItem_Posted]  DEFAULT ((0)) FOR [Posted]
GO
ALTER TABLE [dbo].[PcJournal] ADD  CONSTRAINT [DF_PcJournal_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[PcJournalItem] ADD  CONSTRAINT [DF_PcJournalItem_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO
ALTER TABLE [dbo].[PcJournalItem] ADD  CONSTRAINT [DF_PcJournalItem_JournalIdNo]  DEFAULT ((0)) FOR [JournalIdNo]
GO
ALTER TABLE [dbo].[PcJournalItem] ADD  CONSTRAINT [DF_PcJournalItem_AccountIdNo]  DEFAULT ((0)) FOR [AccountIdNo]
GO
ALTER TABLE [dbo].[PcJournalItem] ADD  CONSTRAINT [DF_PcJournalItem_Debit]  DEFAULT ((0)) FOR [Debit]
GO
ALTER TABLE [dbo].[PcJournalItem] ADD  CONSTRAINT [DF_PcJournalItem_Credit]  DEFAULT ((0)) FOR [Credit]
GO
ALTER TABLE [dbo].[PcJournalItem] ADD  CONSTRAINT [DF_PcJournalItem_ProfitCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
GO
ALTER TABLE [dbo].[PcJournalItem] ADD  CONSTRAINT [DF_PcJournalItem_Posted]  DEFAULT ((0)) FOR [Posted]
GO
ALTER TABLE [dbo].[PurchaseItem] ADD  CONSTRAINT [DF_Purchaseitem_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[PurchaseJournal] ADD  CONSTRAINT [DF_PurchaseJournal_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[PurchaseJournalItem] ADD  CONSTRAINT [DF_PurchaseJournalItem_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO
ALTER TABLE [dbo].[PurchaseJournalItem] ADD  CONSTRAINT [DF_PurchaseJournalItem_JournalIdNo]  DEFAULT ((0)) FOR [JournalIdNo]
GO
ALTER TABLE [dbo].[PurchaseJournalItem] ADD  CONSTRAINT [DF_PurchaseJournalItem_AccountIdNo]  DEFAULT ((0)) FOR [AccountIdNo]
GO
ALTER TABLE [dbo].[PurchaseJournalItem] ADD  CONSTRAINT [DF_PurchaseJournalItem_Debit]  DEFAULT ((0)) FOR [Debit]
GO
ALTER TABLE [dbo].[PurchaseJournalItem] ADD  CONSTRAINT [DF_PurchaseJournalItem_Credit]  DEFAULT ((0)) FOR [Credit]
GO
ALTER TABLE [dbo].[PurchaseJournalItem] ADD  CONSTRAINT [DF_PurchaseJournalItem_ProfitCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
GO
ALTER TABLE [dbo].[PurchaseJournalItem] ADD  CONSTRAINT [DF_PurchaseJournalItem_Posted]  DEFAULT ((0)) FOR [Posted]
GO
ALTER TABLE [dbo].[SalesDeposit] ADD  CONSTRAINT [DF_SalesDetailItem_SaleAmount]  DEFAULT ((0)) FOR [SaleAmount]
GO
ALTER TABLE [dbo].[SalesDeposit] ADD  CONSTRAINT [DF_SalesDetailItem_CashAmount]  DEFAULT ((0)) FOR [DepositAmount]
GO
ALTER TABLE [dbo].[SalesJournal] ADD  CONSTRAINT [DF_SalesJournal_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[SalesJournalItem] ADD  CONSTRAINT [DF_SalesJournalItem_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO
ALTER TABLE [dbo].[SalesJournalItem] ADD  CONSTRAINT [DF_SalesJournalItem_JournalIdNo]  DEFAULT ((0)) FOR [JournalIdNo]
GO
ALTER TABLE [dbo].[SalesJournalItem] ADD  CONSTRAINT [DF_SalesJournalItem_AccountIdNo]  DEFAULT ((0)) FOR [AccountIdNo]
GO
ALTER TABLE [dbo].[SalesJournalItem] ADD  CONSTRAINT [DF_SalesJournalItem_Debit]  DEFAULT ((0)) FOR [Debit]
GO
ALTER TABLE [dbo].[SalesJournalItem] ADD  CONSTRAINT [DF_SalesJournalItem_Credit]  DEFAULT ((0)) FOR [Credit]
GO
ALTER TABLE [dbo].[SalesJournalItem] ADD  CONSTRAINT [DF_SalesJournalItem_ProfitCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
GO
ALTER TABLE [dbo].[SalesJournalItem] ADD  CONSTRAINT [DF_SalesJournalItem_Posted]  DEFAULT ((0)) FOR [Posted]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Account]  WITH NOCHECK ADD  CONSTRAINT [FK__Account__ParentId] FOREIGN KEY([ParentIDNo])
REFERENCES [dbo].[Account] ([IdNo])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK__Account__ParentId]
GO
ALTER TABLE [dbo].[ProfitCenter]  WITH CHECK ADD  CONSTRAINT [FK__ProfitCen__Paren__6BAEFA67] FOREIGN KEY([ParentIdNo])
REFERENCES [dbo].[ProfitCenter] ([IdNo])
GO
ALTER TABLE [dbo].[ProfitCenter] CHECK CONSTRAINT [FK__ProfitCen__Paren__6BAEFA67]
GO
ALTER TABLE [dbo].[ProfitCenterOrg]  WITH CHECK ADD FOREIGN KEY([ParentID])
REFERENCES [dbo].[ProfitCenterOrg] ([IDNo])
GO
ALTER TABLE [dbo].[SecurityObject]  WITH CHECK ADD  CONSTRAINT [FK__SecurityObject__ParentId] FOREIGN KEY([ParentIdNo])
REFERENCES [dbo].[SecurityObject] ([IdNo])
GO
ALTER TABLE [dbo].[SecurityObject] CHECK CONSTRAINT [FK__SecurityObject__ParentId]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_User] FOREIGN KEY([IdNo])
REFERENCES [dbo].[User] ([IdNo])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_User]
GO
/****** Object:  StoredProcedure [dbo].[InsertAccountReconciliationItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE   PROC [dbo].[InsertAccountReconciliationItemTVP]
  @MParam AccountReconciliationItemInsert READONLY
AS 
INSERT  INTO AccountReconciliationItem ( AccountReconciliationIdNo, Cleared, JournalCode, JournalItemIdNo, Sequence )
        SELECT  AccountReconciliationIdNo, Cleared, JournalCode, JournalItemIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.AccountReconciliationItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertApJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROC [dbo].[InsertApJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO ApJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.ApJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertArJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROC [dbo].[InsertArJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO ArJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.ArJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertCashReceiptJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROC [dbo].[InsertCashReceiptJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO CashReceiptJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CashReceiptJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertCdJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





cREATE PROC [dbo].[InsertCdJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO CdJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CdJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertCdOiItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROC [dbo].[InsertCdOiItemTVP]
  @MParam CdOiItemInsert READONLY
AS 
INSERT  INTO CdOiItem ( Amount, ApOpenInvoiceIdNo, DiscountTaken, DjIdNo, Sequence )
        SELECT  Amount, ApOpenInvoiceIdNo, DiscountTaken, DjIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CdOiItem ON;
GO
/****** Object:  StoredProcedure [dbo].[InsertCkJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






cREATE PROC [dbo].[InsertCkJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO CkJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CkJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertCkOiItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









CREATE PROC [dbo].[InsertCkOiItemTVP]
  @MParam CkOiItemInsert READONLY
AS 
INSERT  INTO CkOiItem ( Amount, ApOpenInvoiceIdNo, DiscountTaken, DjIdNo, Sequence )
        SELECT  Amount, ApOpenInvoiceIdNo, DiscountTaken, DjIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CkOiItem ON;
GO
/****** Object:  StoredProcedure [dbo].[InsertCsrOiItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROC [dbo].[InsertCsrOiItemTVP]
  @MParam CsrOiItemInsert READONLY
AS 
INSERT  INTO CsrOiItem ( Amount, ArOpenInvoiceIdNo, CsrIdNo, DiscountTaken, [Sequence] )
        SELECT  Amount, ArOpenInvoiceIdNo, CsrIdNo, DiscountTaken, [Sequence]
        FROM    @MParam
SET IDENTITY_INSERT DBO.CsrOiItem ON;
GO
/****** Object:  StoredProcedure [dbo].[InsertDistributionSchemeItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROC [dbo].[InsertDistributionSchemeItemTVP]
  @MParam DistributionSchemeItemInsert READONLY
AS 
INSERT  INTO DistributionSchemeItem (DistributionSchemeIdNo, [Sequence], RevCostCenteridNo, [Percentage])
        SELECT  DistributionSchemeIdNo, [Sequence], RevCostCenteridNo, [Percentage]
        FROM    @MParam
SET IDENTITY_INSERT DBO.DistributionSchemeItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertEmployeeDeductionTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROC [dbo].[InsertEmployeeDeductionTVP]
  @MParam EmployeeDeductionInsert READONLY
AS 
INSERT  INTO EmployeeDeduction ( Amount, DeductionIdNo, EmployeeIdNo, Sequence )
        SELECT  Amount, DeductionIdNo, EmployeeIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeDeduction ON;
GO
/****** Object:  StoredProcedure [dbo].[InsertEmployeeEarningTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROC [dbo].[InsertEmployeeEarningTVP]
  @MParam EmployeeEarningInsert READONLY
AS 
INSERT  INTO EmployeeEarning ( Amount, EarningIdNo, EmployeeIdNo, Sequence )
        SELECT  Amount, EarningIdNo, EmployeeIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeEarning ON;
GO
/****** Object:  StoredProcedure [dbo].[InsertEmployeeLoanJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROC [dbo].[InsertEmployeeLoanJournalItemTVP]
  @MParam EmployeeLoanJournalItemInsert READONLY
AS 
INSERT  INTO EmployeeLoanJournalItem (JournalIdNo, Sequence, AccountIdNo, Debit, Credit, RevCostCenterIdNo, Notes)
        SELECT  JournalIdNo, Sequence, AccountIdNo, Debit, Credit, RevCostCenteridNo, Notes
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeLoanJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertEmployeePhoneTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









CREATE PROC [dbo].[InsertEmployeePhoneTVP]
  @MParam EmployeePhoneInsert READONLY
AS 
INSERT  INTO EmployeePhone (AreaCode, EmployeeIdNo, CountryTelIdNo, PhoneTypeIdNo, PhoneNumber, Sequence)
        SELECT  AreaCode, EmployeeIdNo, CountryTelIdNo, PhoneTypeIdNo, PhoneNumber, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeePhone ON;
GO
/****** Object:  StoredProcedure [dbo].[InsertErJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










CREATE PROC [dbo].[InsertErJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO ErJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.ErJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertGeneralJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROC [dbo].[InsertGeneralJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO GeneralJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.GeneralJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertGroupAccessTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[InsertGroupAccessTVP]
  @MParam groupAccessInsert READONLY
AS 
INSERT  INTO GroupAccess (SecurityGroupIDNo, SecurityObjectIDNo, Visible, Editable)
        SELECT  SecurityGroupIDNo, SecurityObjectIDNo, Visible, Editable
        FROM    @MParam
SET IDENTITY_INSERT DBO.GroupAccess ON;
GO
/****** Object:  StoredProcedure [dbo].[InsertPayrollDeductAccountTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROC [dbo].[InsertPayrollDeductAccountTVP]
  @MParam PayrollDeductAccountInsert READONLY
AS 
INSERT  INTO PayrollDeductAccount (AccountIdNo, DeductionIdNo, PayGroupIdNo, Sequence)
        SELECT  AccountIdNo, DeductionIdNo, PayGroupIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PayrollDeductAccount ON;
GO
/****** Object:  StoredProcedure [dbo].[InsertPayrollEarnAccountTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROC [dbo].[InsertPayrollEarnAccountTVP]
  @MParam PayrollEarnAccountInsert READONLY
AS 
INSERT  INTO PayrollEarnAccount (AccountIdNo, EarningIdNo, PayGroupIdNo, Sequence)
        SELECT  AccountIdNo, EarningIdNo, PayGroupIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PayrollEarnAccount ON;
GO
/****** Object:  StoredProcedure [dbo].[InsertPcJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROC [dbo].[InsertPcJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO PcJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PcJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertPcOiItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









CREATE PROC [dbo].[InsertPcOiItemTVP]
  @MParam PcOiItemInsert READONLY
AS 
INSERT  INTO PcOiItem ( Amount, ApOpenInvoiceIdNo, DiscountTaken, DjIdNo, Sequence )
        SELECT  Amount, ApOpenInvoiceIdNo, DiscountTaken, DjIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PcOiItem ON;
GO
/****** Object:  StoredProcedure [dbo].[InsertPensionRateTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROC [dbo].[InsertPensionRateTVP]
  @MParam PensionRateInsert READONLY
AS 
INSERT  INTO PensionRate (EmployeeShare, EmployerShare, HighRange, LowRange, MaxAmount, PensionSchemeIdNo, Sequence)
        SELECT  EmployeeShare, EmployerShare, HighRange, LowRange, MaxAmount, PensionSchemeIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PensionRate ON;
GO
/****** Object:  StoredProcedure [dbo].[InsertPurchaseJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROC [dbo].[InsertPurchaseJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO PurchaseJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PurchaseJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertReconciledTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










CREATE   PROC [dbo].[InsertReconciledTVP]
  @MParam ReconciledInsert READONLY
AS 
INSERT  INTO Reconciled ( JournalCode, JournalItemIdNo, ReconciliationIdNo)
        SELECT  JournalCode, JournalItemIdNo, ReconciliationIdNo
        FROM    @MParam
SET IDENTITY_INSERT DBO.Reconciled ON;
GO
/****** Object:  StoredProcedure [dbo].[InsertSalesDepositTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[InsertSalesDepositTVP]
  @MParam SalesDepositInsert READONLY
AS 
INSERT  INTO SalesDeposit ( DepositTypeIdNo, DepositAmount, SaleAmount, SalesJournalIdNo, Sequence, VatAmount)
        SELECT  DepositTypeIdNo, DepositAmount, SaleAmount, SalesJournalIdNo, Sequence, VatAmount
        FROM    @MParam
SET IDENTITY_INSERT DBO.SalesDeposit ON;
GO
/****** Object:  StoredProcedure [dbo].[InsertSalesJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROC [dbo].[InsertSalesJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO SalesJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenteridNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.SalesJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[UpdateAccountReconciliationItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









CREATE   PROCEDURE  [dbo].[UpdateAccountReconciliationItemTVP]
  @MParam AccountReconciliationItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE a
FROM [DBO].AccountReconciliationItem a WHERE a.AccountReconciliationIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = a.IdNo )

-- Update existing AccountReconciliationItems
UPDATE a 
SET a.[AccountReconciliationIdNo] = @GroupIdNo,
	a.[Cleared]= b.[Cleared],
	a.[JournalCode] = b.[JournalCode],
	a.[JournalItemIdNo] = b.[JournalItemIdNo],
    a.[Sequence] = b.[Sequence]
from AccountReconciliationItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateApJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE  [dbo].[UpdateApJournalItemTVP]
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].ApJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing ApJournalItems
UPDATE a 
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from ApJournalItem a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateArJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









CREATE PROCEDURE  [dbo].[UpdateArJournalItemTVP]
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].ArJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing ArJournalItems
UPDATE a 
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from ArJournalItem a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateCashReceiptJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE  [dbo].[UpdateCashReceiptJournalItemTVP]
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].CashReceiptJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing CashReceiptJournalItems
UPDATE a 
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from CashReceiptJournalItem a
JOIN @MParam b
on a.IDNo = b.IDNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCdJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










CREATE PROCEDURE  [dbo].[UpdateCdJournalItemTVP]
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].CdJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing CdJournalItems
UPDATE a 
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from CdJournalItem a
JOIN @MParam b
on a.IDNo = b.IDNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCdOiItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE  [dbo].[UpdateCdOiItemTVP]
  @MParam CdOiItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].CdOiItem A WHERE A.DjIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing CdOiItems
UPDATE a 
SET a.Amount = B.Amount,
	a.ApOpenInvoiceIdNo = B.ApOpenInvoiceIdNo,
	a.DiscountTaken = B.DiscountTaken,
	a.DjIdNo = @GroupIdNo,
    a.[Sequence] = B.[Sequence]
from CdOiItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCkJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











CREATE PROCEDURE  [dbo].[UpdateCkJournalItemTVP]
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].CkJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing CkJournalItems
UPDATE a 
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from CkJournalItem a
JOIN @MParam b
on a.IDNo = b.IDNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCkOiItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE  [dbo].[UpdateCkOiItemTVP]
  @MParam CkOiItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].CkOiItem A WHERE A.DjIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing CkOiItems
UPDATE a 
SET a.Amount = B.Amount,
	a.ApOpenInvoiceIdNo = B.ApOpenInvoiceIdNo,
	a.DiscountTaken = B.DiscountTaken,
	a.DjIdNo = @GroupIdNo,
    a.[Sequence] = B.[Sequence]
from CkOiItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCsrOiItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE  [dbo].[UpdateCsrOiItemTVP]
  @MParam CsrOiItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].CsrOiItem A WHERE A.CsrIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing CsrOiItems
UPDATE a 
SET a.Amount = B.Amount,
	a.ArOpenInvoiceIdNo= B.ArOpenInvoiceIdNo,
	a.CsrIdNo = @GroupIdNo,
	a.DiscountTaken = B.DiscountTaken,
    a.[Sequence] = B.[Sequence]
from CsrOiItem a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateDistributionSchemeItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- Declare @MParam As DistributionSchemeItemMerge;

CREATE PROCEDURE  [dbo].[UpdateDistributionSchemeItemTVP] 
  @MParam DistributionSchemeItemUpdate READONLY, @GroupIdNo as INT
AS 
BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].DistributionSchemeItem A WHERE A.DistributionSchemeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )


-- Update existing DistributionSchemeItems
UPDATE A
SET A.DistributionSchemeIdNo = @GroupIdNo,
    A.[Sequence] = B.[Sequence],
	A.RevCostCenteridNo = B.RevCostCenterIdNo,
	A.Percentage = B.Percentage
from [dbo].DistributionSchemeItem A INNER JOIN @MParam As B
	ON A.IDNo = B.IDNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployeeDeductionTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE  [dbo].[UpdateEmployeeDeductionTVP]
  @MParam EmployeeDeductionUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].EmployeeDeduction A WHERE A.EmployeeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing Deductions
UPDATE a 
SET a.Amount = B.Amount,
	a.EmployeeIdNo = @GroupIdNo,
	a.DeductionIdNo = B.DeductionIdNo,
	a.[Sequence] = B.[Sequence]
from EmployeeDeduction a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployeeEarningTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE  [dbo].[UpdateEmployeeEarningTVP]
  @MParam EmployeeEarningUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].EmployeeEarning A WHERE A.EmployeeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing Earnings
UPDATE a 
SET a.Amount = B.Amount,
	a.EmployeeIdNo = @GroupIdNo,
	a.EarningIdNo = B.EarningIdNo,
	a.[Sequence] = B.[Sequence]
from EmployeeEarning a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployeeLoanJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE  [dbo].[UpdateEmployeeLoanJournalItemTVP]
  @MParam EmployeeLoanJournalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].EmployeeLoanJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing EmployeeLoanJournalItems
UPDATE a 
SET a.JournalIdNo = @GroupIdNo,
    a.[Sequence] = B.[Sequence],
	a.AccountIdNo = B.AccountIdNo,
	a.Debit = B.Debit,
	a.Credit = B.Credit,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.Notes = B.Notes
from EmployeeLoanJournalItem a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployeePhoneTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE  [dbo].[UpdateEmployeePhoneTVP]
  @MParam EmployeePhoneUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].EmployeePhone A WHERE A.EmployeeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing Phones
UPDATE a 
SET a.AreaCode = B.AreaCode,
	a.EmployeeIdNo = @GroupIdNo,
	a.CountryTelIdNo = B.CountryTelIdNo,
	a.PhoneTypeIdNo = B.PhoneTypeIdNo,
	a.PhoneNumber = B.PhoneNumber,
	a.[Sequence] = B.[Sequence]
from EmployeePhone a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateErJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










CREATE PROCEDURE  [dbo].[UpdateErJournalItemTVP]
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].ErJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing ErJournalItems
UPDATE a 
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from ErJournalItem a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateGeneralJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









-- Declare @MParam As GeneralJournalItemMerge;

CREATE PROCEDURE  [dbo].[UpdateGeneralJournalItemTVP] 
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 
BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].GeneralJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )


-- Update existing GeneralJournalItems
UPDATE A
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from [dbo].GeneralJournalItem A INNER JOIN @MParam As B
	ON A.IDNo = B.IDNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateGroupAccessTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE  [dbo].[UpdateGroupAccessTVP]
  @MParam GroupAccessUpdate READONLY, @GroupIdNo as INT
AS 
BEGIN
-- Delete non existent records
DELETE A
FROM [DBO].GroupAccess A WHERE A.SecurityGroupIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

UPDATE a 
SET a.SecurityGroupIDNo = @GroupIdNo ,
    a.SecurityObjectIDNo = B.SecurityObjectIDNo ,
	a.Visible = B.Visible ,
	a.Editable = B.Editable
from GroupAccess a INNER JOIN @MParam as B
on a.IDNo = b.IDNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePayrollDeductAccountTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










-- Declare @MParam As PayrollDeductAccountMerge;

CREATE PROCEDURE  [dbo].[UpdatePayrollDeductAccountTVP] 
  @MParam PayrollDeductAccountUpdate READONLY, @GroupIdNo as INT
AS 
BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PayrollDeductAccount A WHERE A.DeductionIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )


-- Update existing PayrollDeductAccounts
UPDATE A
SET a.AccountIdNo = B.AccountIdNo,
	a.DeductionIdNo = @GroupIdNo,
	a.PayGroupIdNo = B.PayGroupIdNo,
	a.Sequence = b.Sequence
from [dbo].PayrollDeductAccount A INNER JOIN @MParam As B
	ON A.IdNo = B.IdNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePayrollEarnAccountTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










-- Declare @MParam As PayrollEarnAccountMerge;

CREATE PROCEDURE  [dbo].[UpdatePayrollEarnAccountTVP] 
  @MParam PayrollEarnAccountUpdate READONLY, @GroupIdNo as INT
AS 
BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PayrollEarnAccount A WHERE A.EarningIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )


-- Update existing PayrollEarnAccounts
UPDATE A
SET a.AccountIdNo = B.AccountIdNo,
	a.EarningIdNo = @GroupIdNo,
	a.PayGroupIdNo = B.PayGroupIdNo,
	a.Sequence = B.Sequence
from [dbo].PayrollEarnAccount A INNER JOIN @MParam As B
	ON A.IDNo = B.IDNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePcJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











CREATE PROCEDURE  [dbo].[UpdatePcJournalItemTVP]
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PcJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing PcJournalItems
UPDATE a 
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from PcJournalItem a
JOIN @MParam b
on a.IDNo = b.IDNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePcOiItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE  [dbo].[UpdatePcOiItemTVP]
  @MParam PcOiItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PcOiItem A WHERE A.DjIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing PcOiItems
UPDATE a 
SET a.Amount = B.Amount,
	a.ApOpenInvoiceIdNo = B.ApOpenInvoiceIdNo,
	a.DiscountTaken = B.DiscountTaken,
	a.DjIdNo = @GroupIdNo,
    a.[Sequence] = B.[Sequence]
from PcOiItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePensionRateTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









CREATE PROCEDURE  [dbo].[UpdatePensionRateTVP]
  @MParam PensionRateUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PensionRate A WHERE A.PensionSchemeIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing PensionRates
UPDATE a 
SET a.EmployerShare = B.EmployerShare,
	a.EmployeeShare = B.EmployeeShare,
	a.HighRange = B.HighRange,
	a.LowRange = B.LowRange,
	a.MaxAmount = B.MaxAmount,
	a.PensionSchemeIdNo = @GroupIdNo,
	a.[Sequence] = B.[Sequence]
from PensionRate a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePurchaseJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE  [dbo].[UpdatePurchaseJournalItemTVP]
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].PurchaseJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing PurchaseJournalItems
UPDATE a 
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from PurchaseJournalItem a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateSalesDepositTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE  [dbo].[UpdateSalesDepositTVP]
  @MParam SalesDepositUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].SalesDeposit A WHERE A.SalesJournalIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing SalesDeposits
UPDATE a 
SET a.DepositTypeIdNo = B.DepositTypeIdNo,
	a.DepositAmount = b.DepositAmount,
	a.SaleAmount = B.SaleAmount,
	a.SalesJournalIdNo = B.SalesJournalIdNo,
    a.[Sequence] = B.[Sequence],
	a.VatAmount = B.VatAmount
from SalesDeposit a INNER JOIN @MParam As b
on a.IDNo = b.IDNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateSalesJournalItemTVP]    Script Date: 02/12/2020 15:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










-- Declare @MParam As SalesJournalItemMerge;

CREATE PROCEDURE  [dbo].[UpdateSalesJournalItemTVP] 
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 
BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].SalesJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )


-- Update existing SalesJournalItems
UPDATE A
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from [dbo].SalesJournalItem A INNER JOIN @MParam As B
	ON A.IDNo = B.IDNo

END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Country Name (English)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountryMaster', @level2type=N'COLUMN',@level2name=N'CountryNameEng'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[61] 4[11] 3[6] 2) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ApOpenInvoice"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 255
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "APDetails_View"
            Begin Extent = 
               Top = 36
               Left = 280
               Bottom = 504
               Right = 459
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Account"
            Begin Extent = 
               Top = 6
               Left = 603
               Bottom = 335
               Right = 801
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "Supplier"
            Begin Extent = 
               Top = 6
               Left = 839
               Bottom = 519
               Right = 1033
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 4470
         Alias = 900
         Table = 3780
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ApInvoices_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ApInvoices_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ApJournalTransaction_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ApJournalTransaction_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ApStatement_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ARJournalTransaction_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ARJournalTransaction_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArStatement_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CashReceiptJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ApOpenInvoice_View"
            Begin Extent = 
               Top = 6
               Left = 255
               Bottom = 335
               Right = 457
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CdOiItem"
            Begin Extent = 
               Top = 6
               Left = 23
               Bottom = 296
               Right = 235
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CdOiItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CdOiItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CkJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[28] 2[13] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CsrOiItem"
            Begin Extent = 
               Top = 5
               Left = 23
               Bottom = 255
               Right = 200
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ArOpenInvoice_View"
            Begin Extent = 
               Top = 0
               Left = 251
               Bottom = 289
               Right = 435
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 5475
         Alias = 2040
         Table = 2775
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CsrOiItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CsrOiItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "EmployeeDeduction"
            Begin Extent = 
               Top = 6
               Left = 30
               Bottom = 286
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Deduction"
            Begin Extent = 
               Top = 6
               Left = 255
               Bottom = 335
               Right = 440
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3240
         Alias = 900
         Table = 3525
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EmployeeDeduction_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EmployeeDeduction_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "EmployeeEarning"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 284
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Earning"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 272
               Right = 427
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EmployeeEarning_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EmployeeEarning_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "EmployeePhone"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 304
               Right = 213
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employee"
            Begin Extent = 
               Top = 0
               Left = 334
               Bottom = 292
               Right = 532
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PhoneType"
            Begin Extent = 
               Top = 35
               Left = 1031
               Bottom = 263
               Right = 1229
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Country"
            Begin Extent = 
               Top = 127
               Left = 590
               Bottom = 316
               Right = 772
            End
            DisplayFlags = 280
            TopColumn = 5
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 4815
         Alias = 1680
         Table = 5280
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EmployeePhone_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EmployeePhone_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ErJournalTransaction_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ErJournalTransaction_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "GeneralJournal"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 213
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GeneralJournalNormal_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GeneralJournalNormal_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GeneralJournalTransaction_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Account_View"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 331
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 9
         End
         Begin Table = "GlLedgers_View"
            Begin Extent = 
               Top = 6
               Left = 274
               Bottom = 335
               Right = 463
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GeneralLedger_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GeneralLedger_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SecurityObject"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 265
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GroupAccess"
            Begin Extent = 
               Top = 6
               Left = 274
               Bottom = 335
               Right = 467
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SecurityGroup"
            Begin Extent = 
               Top = 0
               Left = 709
               Bottom = 275
               Right = 923
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GroupAccess_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GroupAccess_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AccountTypes"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'InputVatAccountTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'InputVatAccountTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PayCycle"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 307
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Payroll"
            Begin Extent = 
               Top = 75
               Left = 249
               Bottom = 281
               Right = 441
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Payroll_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Payroll_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PayrollEarnAccount_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PcJournal"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 335
               Right = 245
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BankAccount"
            Begin Extent = 
               Top = 6
               Left = 283
               Bottom = 329
               Right = 453
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Bank"
            Begin Extent = 
               Top = 18
               Left = 607
               Bottom = 278
               Right = 780
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PcJournal_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PcJournal_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PcOiItem"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 335
               Right = 235
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApOpenInvoice_View"
            Begin Extent = 
               Top = 6
               Left = 273
               Bottom = 136
               Right = 457
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PcOiItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PcOiItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SalesDeposit"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 292
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DepositType"
            Begin Extent = 
               Top = 8
               Left = 319
               Bottom = 138
               Right = 565
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SalesDeposit_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SalesDeposit_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[31] 2[9] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TranslatedMessages"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 261
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Languages"
            Begin Extent = 
               Top = 127
               Left = 375
               Bottom = 312
               Right = 552
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OriginalMessages"
            Begin Extent = 
               Top = 45
               Left = 696
               Bottom = 281
               Right = 870
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3135
         Alias = 2925
         Table = 2730
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TranslatedMessages_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TranslatedMessages_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[36] 2[5] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ApJournalItem_View"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 309
               Right = 222
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApJournal"
            Begin Extent = 
               Top = 13
               Left = 323
               Bottom = 336
               Right = 516
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UnpaidOpenInvoices_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UnpaidOpenInvoices_View'
GO

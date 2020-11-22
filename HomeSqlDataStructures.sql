USE [master]
GO
/****** Object:  Database [ISPDATA]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE DATABASE [ISPDATA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ISPDATA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ISPDATA.mdf' , SIZE = 81984KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ISPDATA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ISPDATA_log.ldf' , SIZE = 199296KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ISPDATA] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ISPDATA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ISPDATA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ISPDATA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ISPDATA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ISPDATA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ISPDATA] SET ARITHABORT OFF 
GO
ALTER DATABASE [ISPDATA] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ISPDATA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ISPDATA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ISPDATA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ISPDATA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ISPDATA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ISPDATA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ISPDATA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ISPDATA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ISPDATA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ISPDATA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ISPDATA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ISPDATA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ISPDATA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ISPDATA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ISPDATA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ISPDATA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ISPDATA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ISPDATA] SET  MULTI_USER 
GO
ALTER DATABASE [ISPDATA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ISPDATA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ISPDATA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ISPDATA] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ISPDATA] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ISPDATA', N'ON'
GO
ALTER DATABASE [ISPDATA] SET QUERY_STORE = OFF
GO
USE [ISPDATA]
GO
/****** Object:  User [May]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE USER [May] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [MARCELO-DELL\MAY]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE USER [MARCELO-DELL\MAY] FOR LOGIN [MARCELO-DELL\MAY] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [iGroupAdmin]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE USER [iGroupAdmin] FOR LOGIN [iGroupAdmin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [Arnel]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE USER [Arnel] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [May]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [May]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [May]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [May]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [May]
GO
ALTER ROLE [db_datareader] ADD MEMBER [May]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [May]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [May]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [May]
GO
ALTER ROLE [db_owner] ADD MEMBER [MARCELO-DELL\MAY]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [MARCELO-DELL\MAY]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [MARCELO-DELL\MAY]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [MARCELO-DELL\MAY]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [MARCELO-DELL\MAY]
GO
ALTER ROLE [db_datareader] ADD MEMBER [MARCELO-DELL\MAY]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [MARCELO-DELL\MAY]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [MARCELO-DELL\MAY]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [MARCELO-DELL\MAY]
GO
ALTER ROLE [db_owner] ADD MEMBER [iGroupAdmin]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [iGroupAdmin]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [iGroupAdmin]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [iGroupAdmin]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [iGroupAdmin]
GO
ALTER ROLE [db_datareader] ADD MEMBER [iGroupAdmin]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [iGroupAdmin]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [iGroupAdmin]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [iGroupAdmin]
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
/****** Object:  UserDefinedTableType [dbo].[AccountReconciliationItemInsert]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[AccountReconciliationItemInsert] AS TABLE(
	[AccountReconciliationIdNo] [int] NULL,
	[Cleared] [bit] NULL,
	[JournalCode] [char](2) NULL,
	[JournalItemIdNo] [int] NULL,
	[Sequence] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[AccountReconciliationItemUpdate]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  UserDefinedTableType [dbo].[CadOiItemInsert]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[CadOiItemInsert] AS TABLE(
	[Amount] [money] NULL,
	[CadIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[CadOiItemUpdate]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[CadOiItemUpdate] AS TABLE(
	[Amount] [money] NULL,
	[CadIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[IdNo] [int] NOT NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[CkdOiItemInsert]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[CkdOiItemInsert] AS TABLE(
	[Amount] [money] NULL,
	[CkdIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[CkdOiItemUpdate]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[CkdOiItemUpdate] AS TABLE(
	[Amount] [money] NULL,
	[CkdIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[IdNo] [int] NOT NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[CsrOiItemInsert]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[CsrOiItemInsert] AS TABLE(
	[Amount] [money] NULL,
	[CsrIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[CsrOiItemUpdate]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[CsrOiItemUpdate] AS TABLE(
	[Amount] [money] NULL,
	[CsrIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[IdNo] [int] NOT NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[DeptTableType]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[DeptTableType] AS TABLE(
	[DNAME] [varchar](20) NULL,
	[LOC] [varchar](20) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[DistributionSchemeItemInsert]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[DistributionSchemeItemInsert] AS TABLE(
	[DistributionSchemeIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[RevCostCenterIdNo] [int] NOT NULL,
	[Percentage] [decimal](6, 2) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[DistributionSchemeItemMerge]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[DistributionSchemeItemMerge] AS TABLE(
	[IdNo] [int] NOT NULL,
	[Sequence] [int] NULL,
	[DistributionSchemeIdNo] [int] NOT NULL,
	[RevCostCenterIdNo] [int] NOT NULL,
	[Percentage] [decimal](6, 2) NULL,
	PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[DistributionSchemeItemUpdate]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[DistributionSchemeItemUpdate] AS TABLE(
	[IdNo] [int] NOT NULL,
	[DistributionSchemeIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[RevCostCenterIdNo] [int] NOT NULL,
	[Percentage] [decimal](6, 2) NULL,
	PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[EmployeeLoanJournalItemInsert]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[EmployeeLoanJournalItemInsert] AS TABLE(
	[JournalIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[Debit] [money] NULL,
	[Credit] [money] NULL,
	[RevCostCenterIdNo] [int] NULL,
	[Notes] [nvarchar](100) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[EmployeeLoanJournalItemUpdate]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[EmployeeLoanJournalItemUpdate] AS TABLE(
	[IdNo] [int] NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[Debit] [money] NULL,
	[Credit] [money] NULL,
	[RevCostCenterIdNo] [int] NULL,
	[Notes] [nvarchar](100) NULL,
	PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[GroupAccessInsert]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[GroupAccessInsert] AS TABLE(
	[SecurityGroupIdNo] [int] NOT NULL,
	[SecurityObjectIdNo] [int] NOT NULL,
	[Visible] [bit] NOT NULL,
	[Selectable] [bit] NOT NULL,
	[Viewable] [bit] NOT NULL,
	[Editable] [bit] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[GroupAccessUpdate]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[GroupAccessUpdate] AS TABLE(
	[IdNo] [int] NOT NULL,
	[SecurityGroupIdNo] [int] NOT NULL,
	[SecurityObjectIdNo] [int] NOT NULL,
	[Visible] [bit] NOT NULL,
	[Selectable] [bit] NOT NULL,
	[Viewable] [bit] NOT NULL,
	[Editable] [bit] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[JournalItemInsert]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[JournalItemInsert] AS TABLE(
	[AccountIdNo] [int] NOT NULL,
	[Credit] [money] NOT NULL,
	[Debit] [money] NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[Notes] [nvarchar](100) NOT NULL,
	[RevCostCenterIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[JournalItemUpdate]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[JournalItemUpdate] AS TABLE(
	[AccountIdNo] [int] NOT NULL,
	[Credit] [money] NOT NULL,
	[Debit] [money] NOT NULL,
	[IdNo] [int] NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[Notes] [nvarchar](100) NOT NULL,
	[RevCostCenterIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[PcsOiItemInsert]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[PcsOiItemInsert] AS TABLE(
	[Amount] [money] NULL,
	[PcsIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[PcsOiItemUpdate]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[PcsOiItemUpdate] AS TABLE(
	[Amount] [money] NULL,
	[PtcIdNo] [int] NOT NULL,
	[DiscountTaken] [money] NULL,
	[IdNo] [int] NOT NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[ReconciledInsert]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[ReconciledInsert] AS TABLE(
	[JournalCode] [char](2) NULL,
	[JournalItemIdNo] [int] NULL,
	[ReconciliationIdNo] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[SalesDepositInsert]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[SalesDepositInsert] AS TABLE(
	[CashCode] [char](1) NOT NULL,
	[DepositAmount] [money] NULL,
	[SaleAmount] [money] NULL,
	[SalesJournalIdNo] [int] NULL,
	[Sequence] [int] NOT NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[SalesDepositUpdate]    Script Date: 3/28/2020 6:33:04 AM ******/
CREATE TYPE [dbo].[SalesDepositUpdate] AS TABLE(
	[CashCode] [char](1) NOT NULL,
	[DepositAmount] [money] NULL,
	[IdNo] [int] NOT NULL,
	[SaleAmount] [money] NULL,
	[SalesJournalIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedFunction [dbo].[arabic_convert_single]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  UserDefinedFunction [dbo].[convert_handreds]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  UserDefinedFunction [dbo].[convert_last_two_digits]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  UserDefinedFunction [dbo].[currency_conversion]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  UserDefinedFunction [dbo].[dot_position]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  UserDefinedFunction [dbo].[number_conversation]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  UserDefinedFunction [dbo].[put_zero]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  UserDefinedFunction [dbo].[test_conversion]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[IdNo] [int] NOT NULL,
	[ParentIdNo] [int] NULL,
	[AccountCode] [varchar](5) NOT NULL,
	[AccountName] [varchar](50) NOT NULL,
	[AccountNameAra] [nvarchar](50) NOT NULL,
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
/****** Object:  Table [dbo].[ApOpenInvoice]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApOpenInvoice](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[JournalCode] [varchar](100) NULL,
	[JournalIdNo] [int] NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[PaidAmount] [money] NOT NULL,
	[DiscountTaken] [money] NOT NULL,
 CONSTRAINT [PK_ApOpenInvoice] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CashDisbursementJournal]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashDisbursementJournal](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDate] [date] NOT NULL,
	[ReferenceNo] [varchar](15) NULL,
	[Amount] [money] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[PaymentType] [char](1) NULL,
	[PayeeIdNo] [int] NULL,
	[PayeeName] [nvarchar](50) NULL,
	[CheckNumber] [varchar](10) NULL,
	[CheckDate] [date] NULL,
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
/****** Object:  Table [dbo].[CashDisbursementJournalItem]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashDisbursementJournalItem](
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
 CONSTRAINT [PK_CashDisbursementJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CashDisbursementJournalItem_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[CashDisbursementJournalItem_View]
AS
SELECT        dbo.CashDisbursementJournalItem.AccountIdNo, dbo.CashDisbursementJournalItem.Credit, dbo.CashDisbursementJournalItem.Debit, dbo.CashDisbursementJournalItem.IdNo, 
                         dbo.CashDisbursementJournalItem.JournalIdNo, dbo.CashDisbursementJournalItem.Notes, dbo.CashDisbursementJournalItem.RevCostCenterIdNo, dbo.CashDisbursementJournalItem.Sequence, 
                         dbo.Account.AccountName, dbo.CashDisbursementJournalItem.Debit - dbo.CashDisbursementJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.CashDisbursementJournal INNER JOIN
                         dbo.CashDisbursementJournalItem ON dbo.CashDisbursementJournal.IdNo = dbo.CashDisbursementJournalItem.JournalIdNo INNER JOIN
                         dbo.Account ON dbo.CashDisbursementJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CashDisbursementJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  View [dbo].[Account_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create View [dbo].[Account_View] as 
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
	DateTimeStamp,
    cast(row_number()over(partition by ParentIdNo order by AccountName) as varchar(max)) as [path],
    0 as levelnumber,
    row_number() over (partition by ParentIdNo order by AccountName) / power(1000.0,0) as SortKey
 
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
	t.DateTimeStamp,
    [path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.AccountName) as varchar(max)),
    levelnumber+1,
    SortKey + row_number()over(partition by t.ParentIdNo order by t.AccountName) / power(1000.0,levelnumber+1)
 
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
	DateTimeStamp,   
    [path],
    SortKey
from cte



GO
/****** Object:  Table [dbo].[ArJournalItem]    Script Date: 3/28/2020 6:33:04 AM ******/
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
 CONSTRAINT [PK_ArJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArOpenInvoice]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArOpenInvoice](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[JournalCode] [char](2) NOT NULL,
	[JournalIdNo] [int] NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[PaidAmount] [money] NOT NULL,
	[DiscountTaken] [money] NOT NULL,
 CONSTRAINT [PK_ArOpenInvoice] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ArJournalItem_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ArJournalItem_View]
AS
SELECT        dbo.ArJournalItem.IdNo, dbo.ArOpenInvoice.JournalCode, dbo.ArJournalItem.JournalIdNo, dbo.ArJournalItem.AccountIdNo, dbo.ArJournalItem.Debit, dbo.ArJournalItem.Credit, dbo.ArJournalItem.RevCostCenterIdNo, 
                         dbo.ArJournalItem.Notes, dbo.ArJournalItem.Posted, dbo.ArJournalItem.DateTimeStamp, dbo.Account.AccountName, dbo.ArOpenInvoice.IdNo AS OpenInvoiceIdNo, 
                         dbo.ArJournalItem.Credit - dbo.ArJournalItem.Debit AS OriginalAmount, dbo.ArOpenInvoice.PaidAmount, dbo.ArOpenInvoice.DiscountTaken, dbo.Account.SpecialAccount, dbo.Account.AccountNameAra, dbo.Account.PayeeType, 
                         dbo.ArJournalItem.Sequence
FROM            dbo.ArJournalItem INNER JOIN
                         dbo.Account ON dbo.ArJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.ArOpenInvoice ON dbo.ArJournalItem.IdNo = dbo.ArOpenInvoice.JournalItemIdNo
GO
/****** Object:  Table [dbo].[CheckDisbursementJournal]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckDisbursementJournal](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDate] [date] NOT NULL,
	[ReferenceNo] [varchar](15) NULL,
	[Amount] [money] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[PaymentType] [char](1) NULL,
	[PayeeIdNo] [int] NULL,
	[PayeeName] [nvarchar](50) NULL,
	[CheckNumber] [varchar](10) NULL,
	[CheckDate] [date] NULL,
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
 CONSTRAINT [PK_ChequeDisbursementJournal1] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CheckDisbursementJournalItem]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckDisbursementJournalItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [int] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[Debit] [money] NOT NULL,
	[Credit] [money] NOT NULL,
	[Notes] [nvarchar](300) NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[RevCostCenterIdNo] [int] NOT NULL,
	[Posted] [bit] NOT NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_ChequeDisbursementJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CheckDisbursementJournalItem_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[CheckDisbursementJournalItem_View]
AS
SELECT        dbo.CheckDisbursementJournalItem.AccountIdNo, dbo.CheckDisbursementJournalItem.Credit, dbo.CheckDisbursementJournalItem.Debit, dbo.CheckDisbursementJournalItem.IdNo, 
                         dbo.CheckDisbursementJournalItem.JournalIdNo, dbo.CheckDisbursementJournalItem.Notes, dbo.CheckDisbursementJournalItem.RevCostCenterIdNo, dbo.CheckDisbursementJournalItem.Sequence, 
                         dbo.Account.AccountName, dbo.CheckDisbursementJournalItem.Debit - dbo.CheckDisbursementJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 
                         0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.CheckDisbursementJournal INNER JOIN
                         dbo.CheckDisbursementJournalItem ON dbo.CheckDisbursementJournal.IdNo = dbo.CheckDisbursementJournalItem.JournalIdNo INNER JOIN
                         dbo.Account ON dbo.CheckDisbursementJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CheckDisbursementJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  Table [dbo].[OriginalCaptions]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OriginalCaptions](
	[idno] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [varchar](128) NULL,
 CONSTRAINT [PK_Original] PRIMARY KEY CLUSTERED 
(
	[idno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TranslatedCaption]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TranslatedCaption](
	[idno] [int] IDENTITY(1,1) NOT NULL,
	[CaptionIdNo] [int] NOT NULL,
	[LanguageIdNo] [smallint] NOT NULL,
	[Translated] [nvarchar](256) NULL,
 CONSTRAINT [PK_TranslatedIdNo] PRIMARY KEY CLUSTERED 
(
	[idno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[TranslatedCaption_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[TranslatedCaption_View]
AS
SELECT        dbo.TranslatedCaption.idno, dbo.TranslatedCaption.CaptionIdNo, dbo.TranslatedCaption.LanguageIdNo, dbo.TranslatedCaption.Translated, dbo.Languages.CultureInfoCode, dbo.OriginalCaptions.Caption, dbo.Languages.LanguageCode2
FROM            dbo.TranslatedCaption INNER JOIN
                         dbo.Languages ON dbo.TranslatedCaption.LanguageIdNo = dbo.Languages.IdNo INNER JOIN
                         dbo.OriginalCaptions ON dbo.TranslatedCaption.CaptionIdNo = dbo.OriginalCaptions.idno
GO
/****** Object:  Table [dbo].[SystemForms]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemForms](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[FormName] [varchar](50) NULL,
 CONSTRAINT [PK_SystemForms] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormItems]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormItems](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[FormIdNo] [int] NOT NULL,
	[CaptionIdNo] [int] NOT NULL,
 CONSTRAINT [PK_FormItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[FormItemsOriginal_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[FormItemsOriginal_View]
AS
SELECT        dbo.FormItems.idno, dbo.FormItems.formIdNo, dbo.FormItems.CaptionIdNo, dbo.OriginalCaptions.Caption, dbo.FormItems.idno AS Expr1, dbo.FormItems.formIdNo AS Expr2, dbo.FormItems.CaptionIdNo AS Expr3, 
                         dbo.SystemForms.FormName, dbo.TranslatedCaption.Translated, dbo.Languages.LanguageCode2, dbo.Languages.CultureInfoCode, dbo.Languages.Language, dbo.TranslatedCaption.LanguageIdNo
FROM            dbo.Languages RIGHT OUTER JOIN
                         dbo.TranslatedCaption ON dbo.Languages.IdNo = dbo.TranslatedCaption.LanguageIdNo RIGHT OUTER JOIN
                         dbo.FormItems LEFT OUTER JOIN
                         dbo.SystemForms ON dbo.FormItems.formIdNo = dbo.SystemForms.IdNo ON dbo.TranslatedCaption.CaptionIdNo = dbo.FormItems.CaptionIdNo LEFT OUTER JOIN
                         dbo.OriginalCaptions ON dbo.FormItems.CaptionIdNo = dbo.OriginalCaptions.idno
GO
/****** Object:  Table [dbo].[ApJournalItem]    Script Date: 3/28/2020 6:33:04 AM ******/
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
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_ApJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApJournal]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApJournal](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
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
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_ApIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[APDetails_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE VIEW [dbo].[APDetails_View]	
  AS
(SELECT 'AP' AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
      ,[RevCostCenterIdNo]
      ,a.[Notes]
      ,a.[Posted]
	  ,[SupplierIdNo]
	  ,[InvoiceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[TransactionType]
  FROM [ISPDATA].[dbo].[ApJournalItem] a
  RIGHT OUTER JOIN dbo.ApJournal b
  on a.JournalIdNo = b.IdNo 
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
  FROM [ISPDATA].[dbo].[CheckDisbursementJournalItem] A
  RIGHT OUTER JOIN dbo.CheckDisbursementJournal b
  on a.JournalIdNo = b.IdNo
  WHERE PaymentType='A'
)
GO
/****** Object:  Table [dbo].[TranslatedMessages]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TranslatedMessages](
	[idno] [int] IDENTITY(1,1) NOT NULL,
	[MessageIdNo] [int] NOT NULL,
	[LanguageIdNo] [smallint] NOT NULL,
	[TranslatedMessage] [nvarchar](256) NOT NULL,
	[TranslatedCaption] [nchar](128) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_TranslatedMessages] PRIMARY KEY CLUSTERED 
(
	[idno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OriginalMessages]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OriginalMessages](
	[idno] [int] IDENTITY(1,1) NOT NULL,
	[MessageKey] [varchar](50) NOT NULL,
	[Message] [varchar](256) NOT NULL,
	[Caption] [varchar](128) NULL,
	[Notes] [varchar](256) NULL,
	[Buttons] [tinyint] NULL,
	[Icon] [tinyint] NULL,
	[DefaultButton] [tinyint] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_OriginalMessages] PRIMARY KEY CLUSTERED 
(
	[idno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[TranslatedMessages_View]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  Table [dbo].[GeneralJournalItem]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralJournalItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [int] NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[Debit] [money] NOT NULL,
	[Credit] [money] NOT NULL,
	[RevCostCenterIdNo] [int] NOT NULL,
	[Notes] [nvarchar](300) NOT NULL,
	[Posted] [bit] NOT NULL,
	[Timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_GeneralJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralJournal]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralJournal](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDate] [date] NOT NULL,
	[ReferenceNo] [nvarchar](10) NULL,
	[TransactionType] [char](1) NULL,
	[Amount] [money] NULL,
	[Notes] [nvarchar](100) NULL,
	[Posted] [nchar](10) NULL,
	[Cancelled] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_JournalIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GeneralJournalItem_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GeneralJournalItem_View]
AS
SELECT        dbo.GeneralJournalItem.IdNo, dbo.GeneralJournalItem.Sequence, dbo.GeneralJournalItem.JournalIdNo, dbo.GeneralJournalItem.AccountIdNo, dbo.GeneralJournalItem.Debit, dbo.GeneralJournalItem.Credit, 
                         dbo.GeneralJournalItem.RevCostCenterIdNo, dbo.GeneralJournalItem.Notes, dbo.Account.AccountName, dbo.GeneralJournalItem.Debit - dbo.GeneralJournalItem.Credit AS OriginalAmount, dbo.Account.PayeeType, 
                         dbo.Account.SpecialAccount, 0 AS OpenInvoiceIdNo, 0 AS PaidAmount, dbo.ApOpenInvoice.PaidAmount AS Expr1, dbo.ApOpenInvoice.DiscountTaken
FROM            dbo.GeneralJournal INNER JOIN
                         dbo.GeneralJournalItem ON dbo.GeneralJournal.IdNo = dbo.GeneralJournalItem.JournalIdNo INNER JOIN
                         dbo.Account ON dbo.GeneralJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.GeneralJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  Table [dbo].[CashReceiptJournalItem]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashReceiptJournalItem](
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
 CONSTRAINT [PK_CashReceiptJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CashReceiptJournalItem_View]    Script Date: 3/28/2020 6:33:04 AM ******/
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
                         dbo.Account ON dbo.CashReceiptJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.CashReceiptJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  Table [dbo].[PcJournal]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PcJournal](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDate] [date] NOT NULL,
	[ReferenceNo] [varchar](15) NULL,
	[Amount] [money] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[PaymentType] [char](1) NULL,
	[PayeeIdNo] [int] NULL,
	[PayeeName] [nvarchar](50) NULL,
	[CheckNumber] [varchar](10) NULL,
	[CheckDate] [date] NULL,
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
 CONSTRAINT [PK_PcJournal1] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PcJournalItem]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PcJournalItem](
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
 CONSTRAINT [PK_PcJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[PcJournalItem_View]    Script Date: 3/28/2020 6:33:04 AM ******/
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
FROM            dbo.PcJournal INNER JOIN
                         dbo.PcJournalItem ON dbo.PcJournal.IdNo = dbo.PcJournalItem.JournalIdNo INNER JOIN
                         dbo.Account ON dbo.PcJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.PcJournalItem.JournalIdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  Table [dbo].[PurchaseJournalItem]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseJournalItem](
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
 CONSTRAINT [PK_PurchaseJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[PurchaseJournalItem_View]    Script Date: 3/28/2020 6:33:04 AM ******/
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
                         dbo.Account ON dbo.PurchaseJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.PurchaseJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  Table [dbo].[ArJournal]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArJournal](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
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
	[DateCreated] [datetime] NOT NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_ArIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CashReceiptJournal]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashReceiptJournal](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDate] [date] NOT NULL,
	[ReferenceNo] [varchar](15) NULL,
	[Amount] [money] NULL,
	[AccountIdNo] [int] NOT NULL,
	[PayorType] [char](1) NULL,
	[PayorIdNo] [int] NULL,
	[Payorname] [nvarchar](50) NULL,
	[CheckNumber] [varchar](10) NULL,
	[CheckDate] [date] NULL,
	[ORNumber] [varchar](15) NULL,
	[DiscountTaken] [money] NULL,
	[DiscountAccountIdNo] [int] NULL,
	[Applied] [money] NULL,
	[UnApplied] [money] NULL,
	[Notes] [nvarchar](255) NULL,
	[Posted] [bit] NULL,
	[Cancelled] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_CashReceiptJournal] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ARDetails_View]    Script Date: 3/28/2020 6:33:04 AM ******/
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
      ,a.[Notes]
      ,a.[Posted]
	  ,[CustomerIdNo]
	  ,[InvoiceNo]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[TransactionType]
  FROM [ISPDATA].[dbo].[ArJournalItem] a
  RIGHT OUTER JOIN dbo.ArJournal b
  on a.JournalIdNo = b.IdNo 
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
  FROM [ISPDATA].[dbo].[CashReceiptJournalItem] A
  RIGHT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IdNo
  WHERE PayorType='A'
)
GO
/****** Object:  View [dbo].[ArOpenInvoice_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ArOpenInvoice_View]
AS
SELECT			dbo.ArOpenInvoice.IdNo, dbo.ArOpenInvoice.JournalCode, dbo.ArOpenInvoice.JournalItemIdNo, dbo.ARDetails_View.Debit - dbo.ARDetails_View.Credit AS Amount, dbo.ArOpenInvoice.PaidAmount, 
                dbo.ArOpenInvoice.DiscountTaken, dbo.ARDetails_View.Debit - dbo.ARDetails_View.Credit - dbo.ArOpenInvoice.PaidAmount - dbo.ArOpenInvoice.DiscountTaken AS Balance, 
                dbo.ARDetails_View.Debit - dbo.ARDetails_View.Credit AS InvoiceAmount, dbo.ArOpenInvoice.JournalIdNo, dbo.ARDetails_View.AccountIdNo, dbo.ARDetails_View.CustomerIdNo, 
                dbo.ARDetails_View.ReferenceNo, dbo.ARDetails_View.TransactionType, dbo.ARDetails_View.TransactionDate, dbo.ARDetails_View.InvoiceNo, dbo.ARDetails_View.Notes, dbo.Account.AccountCode, 
                dbo.Account.AccountName, dbo.Account.AccountNameAra, dbo.Account.SpecialAccount
FROM            dbo.ARDetails_View 
				INNER JOIN dbo.Account 
				ON dbo.ARDetails_View.AccountIdNo = dbo.Account.IdNo 
				RIGHT OUTER JOIN dbo.ArOpenInvoice 
				ON dbo.ARDetails_View.IdNo = dbo.ArOpenInvoice.JournalItemIdNo AND dbo.ARDetails_View.JournalCode = dbo.ArOpenInvoice.JournalCode Collate SQL_Latin1_General_CP1_CI_AS
GO
/****** Object:  View [dbo].[Captions_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[Captions_View]
AS
SELECT        dbo.TranslatedCaption.idno, dbo.TranslatedCaption.CaptionIdNo, dbo.TranslatedCaption.LanguageIdNo, dbo.TranslatedCaption.Translated, dbo.Languages.CultureInfoCode, dbo.OriginalCaptions.Caption, dbo.Languages.LanguageCode2
FROM            dbo.TranslatedCaption 
				INNER JOIN dbo.Languages 
				ON dbo.TranslatedCaption.LanguageIdNo = dbo.Languages.IdNo 
				RIGHT OUTER JOIN dbo.OriginalCaptions
				ON dbo.TranslatedCaption.CaptionIdNo = dbo.OriginalCaptions.idno
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 3/28/2020 6:33:04 AM ******/
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
	[Street] [varchar](50) NULL,
	[District] [varchar](50) NULL,
	[TownCity] [varchar](50) NULL,
	[ProvinceState] [varchar](50) NULL,
	[CountryCode] [char](2) NULL,
	[POBox] [varchar](10) NULL,
	[ZipCode] [varchar](10) NULL,
	[Phone1] [varchar](50) NULL,
	[Phone2] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Website] [varchar](50) NULL,
	[VATNumber] [varchar](15) NULL,
	[CRNumber] [varchar](20) NULL,
	[AccountStatus] [char](1) NULL,
	[APAccountIdNo] [int] NULL,
	[ExpAccountIdNo] [int] NULL,
	[CreditLimit] [money] NULL,
	[SettlementDueDays] [smallint] NULL,
	[SettlementDiscount] [decimal](5, 2) NOT NULL,
	[PaymentDueDays] [smallint] NULL,
	[DateAccountOpen] [datetime] NULL,
	[BankAccountName] [nvarchar](50) NULL,
	[BankAccountNo] [varchar](20) NULL,
	[BankIdNo] [int] NULL,
	[IBAN] [varchar](20) NULL,
	[PaymentMethod] [char](2) NULL,
	[Notes] [varchar](255) NULL,
	[OpeningBalance] [money] NULL,
	[Active] [bit] NULL,
	[DateCreated] [datetime2](7) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_SupplierDetailsIdNo2] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_SupplierName2] UNIQUE NONCLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_SupplierNameAra2] UNIQUE NONCLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[SupplierInvoices]    Script Date: 3/28/2020 6:33:04 AM ******/
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
                         dbo.ApJournalItem ON dbo.Account.IdNo = dbo.ApJournalItem.AccountIdNo INNER JOIN
                         dbo.ApJournal ON dbo.ApJournalItem.JournalIdNo = dbo.ApJournal.IdNo INNER JOIN
                         dbo.Supplier ON dbo.ApJournal.SupplierIdNo = dbo.Supplier.IdNo RIGHT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.ApJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  Table [dbo].[PcsOiItem]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PcsOiItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[PcsIdNo] [int] NOT NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[DiscountTaken] [money] NOT NULL,
 CONSTRAINT [PK_PcsOiItemIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ApOpenInvoice_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ApOpenInvoice_View]
AS
SELECT      dbo.ApOpenInvoice.IdNo, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.JournalItemIdNo, dbo.APDetails_View.Credit - dbo.APDetails_View.Debit AS Amount, dbo.ApOpenInvoice.PaidAmount, 
            dbo.ApOpenInvoice.DiscountTaken, dbo.APDetails_View.Credit - dbo.APDetails_View.Debit - dbo.ApOpenInvoice.PaidAmount - dbo.ApOpenInvoice.DiscountTaken AS Balance, 
            dbo.APDetails_View.Credit - dbo.APDetails_View.Debit AS InvoiceAmount, dbo.ApOpenInvoice.JournalIdNo, dbo.APDetails_View.AccountIdNo, dbo.APDetails_View.SupplierIdNo, dbo.APDetails_View.ReferenceNo, 
            dbo.APDetails_View.TransactionType, dbo.APDetails_View.TransactionDate, dbo.APDetails_View.InvoiceNo, dbo.APDetails_View.Notes, dbo.Account.AccountName, dbo.Account.AccountNameAra, 
            dbo.Account.SpecialAccount, dbo.Account.AccountCode
FROM        dbo.ApOpenInvoice 
			LEFT OUTER JOIN dbo.APDetails_View 
			ON dbo.ApOpenInvoice.JournalItemIdNo = dbo.APDetails_View.IdNo AND dbo.ApOpenInvoice.JournalCode = dbo.APDetails_View.JournalCode Collate SQL_Latin1_General_CP1_CI_AS
			LEFT OUTER JOIN dbo.Account 
			ON dbo.APDetails_View.AccountIdNo = dbo.Account.IdNo
GO
/****** Object:  View [dbo].[PcsOiItem_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[PcsOiItem_View]
AS
SELECT        dbo.PcsOiItem.Sequence, dbo.ApOpenInvoice_View.InvoiceNo, dbo.ApOpenInvoice_View.TransactionDate, 
                         dbo.ApOpenInvoice_View.Balance + dbo.PcsOiItem.Amount + dbo.PcsOiItem.DiscountTaken AS PreviousBalance, dbo.PcsOiItem.Amount, dbo.PcsOiItem.DiscountTaken, dbo.ApOpenInvoice_View.Balance, 
                         dbo.PcsOiItem.JournalItemIdNo, dbo.ApOpenInvoice_View.Amount AS InvoiceAmount, dbo.ApOpenInvoice_View.JournalCode, dbo.ApOpenInvoice_View.JournalItemIdNo AS ApJournalItemIdNo, 
                         dbo.ApOpenInvoice_View.ReferenceNo, dbo.ApOpenInvoice_View.PaidAmount, dbo.PcsOiItem.IdNo, dbo.ApOpenInvoice_View.SupplierIdNo, dbo.ApOpenInvoice_View.IdNo AS OpenInvoiceIdNo, 
                         dbo.PcsOiItem.PcsIdNo, dbo.ApOpenInvoice_View.AccountIdNo, dbo.ApOpenInvoice_View.JournalIdNo
FROM            dbo.PcsOiItem LEFT OUTER JOIN
                         dbo.ApOpenInvoice_View ON dbo.PcsOiItem.JournalItemIdNo = dbo.ApOpenInvoice_View.JournalItemIdNo
GO
/****** Object:  View [dbo].[ApInvoices_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ApInvoices_View]
AS
SELECT        dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.JournalItemIdNo, dbo.APDetails_View.AccountIdNo, dbo.APDetails_View.Debit, dbo.APDetails_View.Credit, dbo.APDetails_View.RevCostCenterIdNo, dbo.APDetails_View.Notes, 
                         dbo.APDetails_View.Posted, dbo.Account.AccountCode, dbo.Account.AccountName, dbo.Account.AccountNameAra, dbo.APDetails_View.SupplierIdNo, dbo.APDetails_View.InvoiceNo, dbo.APDetails_View.TransactionDate, 
                         dbo.APDetails_View.ReferenceNo, dbo.APDetails_View.TransactionType, dbo.ApOpenInvoice.PaidAmount, dbo.ApOpenInvoice.DiscountTaken, dbo.Account.SpecialAccount, dbo.ApOpenInvoice.IdNo, 
                         dbo.ApOpenInvoice.JournalIdNo
FROM            dbo.ApOpenInvoice 
			LEFT OUTER JOIN dbo.APDetails_View 
			ON dbo.ApOpenInvoice.JournalItemIdNo = dbo.APDetails_View.IdNo AND dbo.ApOpenInvoice.JournalCode = dbo.APDetails_View.JournalCode COLLATE SQL_Latin1_General_CP1_CI_AS 
			LEFT OUTER JOIN dbo.Account 
			ON dbo.APDetails_View.AccountIdNo = dbo.Account.IdNo 
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[CustomerCode] [varchar](15) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[CustomerNameAra] [nvarchar](50) NOT NULL,
	[ContactPerson] [nvarchar](50) NULL,
	[ContactDesignation] [nvarchar](15) NULL,
	[Street] [varchar](50) NULL,
	[District] [varchar](50) NULL,
	[TownCity] [varchar](50) NULL,
	[ProvinceState] [varchar](50) NULL,
	[CountryCode] [char](2) NULL,
	[POBox] [varchar](10) NULL,
	[ZipCode] [varchar](10) NULL,
	[Phone1] [varchar](50) NULL,
	[Phone2] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Website] [varchar](50) NULL,
	[VATNumber] [varchar](10) NULL,
	[CRNumber] [varchar](20) NULL,
	[AccountStatus] [char](1) NULL,
	[ARAccountIdNo] [int] NULL,
	[RevAccountIdNo] [int] NULL,
	[DiscountSchemeIdNo] [int] NULL,
	[CreditLimit] [money] NULL,
	[SettlementDueDays] [int] NULL,
	[SettlementDiscount] [decimal](5, 2) NULL,
	[PaymentDueDays] [int] NULL,
	[DateAccountOpen] [datetime] NULL,
	[BankAccountName] [nvarchar](50) NULL,
	[BankAccountNo] [varchar](20) NULL,
	[BankIdNo] [int] NULL,
	[IBAN] [varchar](20) NULL,
	[PaymentMethod] [char](2) NULL,
	[Notes] [varchar](255) NULL,
	[OpeningBalance] [money] NULL,
	[Active] [bit] NULL,
	[DateCreated] [datetime2](7) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_CustomerDetailsIdNo2] PRIMARY KEY CLUSTERED 
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
/****** Object:  Table [dbo].[Employee]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[BranchID] [int] NULL,
	[EmployeeCode] [varchar](10) NULL,
	[Title] [varchar](25) NULL,
	[EmployeeName] [varchar](75) NULL,
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
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesJournal]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesJournal](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDate] [date] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[ReferenceNo] [varchar](15) NULL,
	[Notes] [nvarchar](255) NULL,
	[Posted] [bit] NOT NULL,
	[Cancelled] [bit] NOT NULL,
	[DateCreated] [datetime] NULL,
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_SalesJournal] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesJournalItem]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesJournalItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [int] NOT NULL,
	[JournalIdNo] [int] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[Notes] [nvarchar](100) NOT NULL,
	[Debit] [money] NOT NULL,
	[Credit] [money] NOT NULL,
	[RevCostCenterIdNo] [int] NOT NULL,
	[Posted] [bit] NOT NULL,
 CONSTRAINT [PK_SalesJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GlLedgers_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO














CREATE   VIEW [dbo].[GlLedgers_View]	
  AS
(SELECT 'AP' AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
      ,[RevCostCenterIdNo]
      ,a.[Notes]
      ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[InvoiceNo] AS 'DocumentNumber'
	  ,[SupplierName] AS 'PayDescription'
	  ,[SupplierNameAra] AS 'PayDescriptionAra'
  FROM [ISPDATA].[dbo].[ApJournalItem] a
  LEFT OUTER JOIN dbo.[ApJournal] b
  on a.JournalIdNo = b.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] c
  on b.SupplierIdNo = c.IdNo 
)
UNION
(SELECT 'AR' AS 'JournalCode'
	  ,a.[IdNo]
      ,[Sequence]
      ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
      ,[RevCostCenterIdNo]
      ,a.[Notes]
      ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,[InvoiceNo] AS 'DocumentNumber'
	  ,[CustomerName]
	  ,[CustomerNameAra]
  FROM [ISPDATA].[dbo].[ArJournalItem] a
  LEFT OUTER JOIN dbo.ArJournal b
  on a.JournalIdNo = b.IdNo 
  LEFT OUTER JOIN dbo.[Customer] c
  on b.CustomerIdNo = c.IdNo 
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
  FROM [ISPDATA].[dbo].[CheckDisbursementJournalItem] a
  LEFT OUTER JOIN dbo.CheckDisbursementJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayeeIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayeeIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IdNo 
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
  FROM [ISPDATA].[dbo].[CashDisbursementJournalItem] a
  LEFT OUTER JOIN dbo.CashDisbursementJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayeeIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayeeIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IdNo 
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
			WHEN b.PayorType = 'R' then s.SupplierName
			WHEN b.PayorType = 'E' then e.EmployeeName
			WHEN b.PayorType = 'O' then b.PayorName
			ELSE b.PayorName
	   END
	  ,CASE
			WHEN b.PayorType = 'A' then s.SupplierNameAra
			WHEN b.PayorType = 'C' then c.CustomerNameAra
			WHEN b.PayorType = 'R' then s.SupplierNameAra
			WHEN b.PayorType = 'E' then e.EmployeeNameAra
			WHEN b.PayorType = 'O' then b.PayorName
			ELSE b.PayorName
	   END
  FROM [ISPDATA].[dbo].[CashReceiptJournalItem] a
  LEFT OUTER JOIN dbo.CashReceiptJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayorIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayorIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayorIdNo = e.IdNo 
)
UNION
(SELECT 'GJ'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,''
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes]))
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes]))
  FROM [ISPDATA].[dbo].[GeneralJournalItem] a
  LEFT OUTER JOIN dbo.GeneralJournal b
  on a.JournalIdNo = b.IdNo
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
  FROM [ISPDATA].[dbo].[PcJournalItem] a
  LEFT OUTER JOIN dbo.PcJournal b
  on a.JournalIdNo = b.IdNo
  LEFT OUTER JOIN dbo.[Customer] c
  on b.PayeeIdNo = c.IdNo 
  LEFT OUTER JOIN dbo.[Supplier] s
  on b.PayeeIdNo = s.IdNo 
  LEFT OUTER JOIN dbo.[Employee] e
  on b.PayeeIdNo = e.IdNo 
)
UNION
(SELECT 'SJ'
	  ,a.[IdNo]
      ,[Sequence]
	  ,[JournalIdNo]
      ,a.[AccountIdNo]
      ,[Debit]
      ,[Credit]
	  ,[RevCostCenterIdNo]
      ,a.[Notes]
	  ,a.[Posted]
	  ,[TransactionDate]
      ,[ReferenceNo]
	  ,''
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes]))
	  ,LTrim(Coalesce(a.[Notes],' ', b.[Notes]))
  FROM [ISPDATA].[dbo].[SalesJournalItem] a
  LEFT OUTER JOIN dbo.SalesJournal b
  on a.JournalIdNo = b.Idno
)
GO
/****** Object:  Table [dbo].[RevCostCenter]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RevCostCenter](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[RevCostCenterCode] [varchar](5) NOT NULL,
	[RevCostCenterName] [varchar](50) NOT NULL,
	[ParentIdNo] [int] NULL,
	[RevCostCenterNameAra] [nvarchar](50) NOT NULL,
	[RevCostCenterType] [varchar](10) NULL,
	[Notes] [varchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK__RevCostCenterID] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_RevCostCenterCode] UNIQUE NONCLUSTERED 
(
	[RevCostCenterCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_RevCostCenterNameAra] UNIQUE NONCLUSTERED 
(
	[RevCostCenterNameAra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RevCostCenter_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE View [dbo].[RevCostCenter_View] as 
with cte as
(
select IdNo
      ,RevCostCenterCode
      ,RevCostCenterName
      ,RevCostCenterNameAra
	  ,RevCostCenterType
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by RevCostCenterName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by RevCostCenterName) / power(10.0,0) as SortKey
 
from RevCostCenter
where ParentIdNo IS NULL
union all
select t.IdNo
      ,t.RevCostCenterCode
      ,t.RevCostCenterName
      ,t.RevCostCenterNameAra
	  ,t.RevCostCenterType
      ,t.ParentIdNo
      ,t.[Notes]
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.RevCostCenterName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.RevCostCenterName) / power(10.0,levelnumber+1)
 
 from
    cte
join RevCostCenter t on cte.IdNo = t.ParentIdNo
)
   
select IdNo
      ,RevCostCenterCode
      ,RevCostCenterName
      ,RevCostCenterNameAra
	  ,RevCostCenterType
      ,ParentIdNo
      ,[Notes]
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte





GO
/****** Object:  View [dbo].[ApJournalItem_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ApJournalItem_View]
AS
SELECT        dbo.ApJournalItem.IdNo, dbo.ApJournalItem.Sequence, dbo.ApJournalItem.JournalIdNo, dbo.ApJournalItem.AccountIdNo, dbo.ApJournalItem.Debit, dbo.ApJournalItem.Credit, dbo.ApJournalItem.RevCostCenterIdNo, 
                         dbo.ApJournalItem.Notes, dbo.ApJournalItem.Posted, dbo.ApJournalItem.DateTimeStamp, dbo.Account.AccountName, dbo.ApOpenInvoice.JournalCode, dbo.ApOpenInvoice.IdNo AS OpenInvoiceIdNo, 
                         dbo.ApJournalItem.Credit - dbo.ApJournalItem.Debit AS OriginalAmount, dbo.ApOpenInvoice.PaidAmount, dbo.ApOpenInvoice.DiscountTaken, dbo.Account.SpecialAccount, dbo.Account.AccountNameAra, dbo.Account.PayeeType
FROM            dbo.ApJournalItem LEFT OUTER JOIN
                         dbo.Account ON dbo.ApJournalItem.AccountIdNo = dbo.Account.IdNo LEFT OUTER JOIN
                         dbo.ApOpenInvoice ON dbo.ApJournalItem.IdNo = dbo.ApOpenInvoice.JournalItemIdNo
GO
/****** Object:  View [dbo].[UnpaidOpenInvoices_View]    Script Date: 3/28/2020 6:33:04 AM ******/
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
                         dbo.ApJournal ON dbo.ApJournalItem_View.JournalIdNo = dbo.ApJournal.IdNo
WHERE        (dbo.ApJournalItem_View.SpecialAccount = 'AP')
GO
/****** Object:  Table [dbo].[RevCostCenter]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RevCostCenter](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[RevCostCenterCode] [varchar](5) NOT NULL,
	[RevCostCenterName] [varchar](50) NOT NULL,
	[ParentIdNo] [smallint] NULL,
	[RevCostCenterIdNo] [int] NULL,
	[RevCostCenterNameAra] [varchar](50) NOT NULL,
	[Notes] [varchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_RevCostCenterIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RevCostCenter_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE View [dbo].[RevCostCenter_View] as 
with cte as
(
select IdNo
      ,RevCostCenterCode
      ,RevCostCenterName
      ,RevCostCenterNameAra
      ,ParentIdNo
	  ,RevCostCenterIdNo
      ,[Notes]
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by RevCostCenterName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by RevCostCenterName) / power(10.0,0) as SortKey
 
from RevCostCenter
where ParentIdNo IS NULL
union all
select t.IdNo
      ,t.RevCostCenterCode
      ,t.RevCostCenterName
      ,t.RevCostCenterNameAra
	  ,t.ParentIdNo
	  ,t.RevCostCenterIdNo
      ,t.[Notes]
      ,t.DateTimeStamp
      ,[path] +'-'+ cast(row_number()over(partition by t.ParentIdNo order by t.RevCostCenterName) as varchar(max))
      ,levelnumber+1
      ,SortKey + row_number()over(partition by t.ParentIdNo order by t.RevCostCenterName) / power(10.0,levelnumber+1)
 
 from
    cte
join RevCostCenter t on cte.IdNo = t.ParentIdNo
)
   
select IdNo
      ,RevCostCenterCode
      ,RevCostCenterName
      ,RevCostCenterNameAra
	  ,ParentIdNo
	  ,RevCostCenterIdNo
      ,[Notes]
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte





GO
/****** Object:  Table [dbo].[RevenueGroup]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RevenueGroup](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[RevenueGroupCode] [varchar](5) NOT NULL,
	[RevenueGroupName] [varchar](50) NOT NULL,
	[ParentIdNo] [int] NULL,
	[RevenueGroupNameAra] [nvarchar](50) NOT NULL,
	[Notes] [varchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK__RevenueGroupID] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RevenueGroup_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




Create View [dbo].[RevenueGroup_View] as 
with cte as
(
select IdNo
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
select t.IdNo
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
   
select IdNo
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
/****** Object:  Table [dbo].[AccountReconciliationItem]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  Table [dbo].[AccountReconciliation]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  Table [dbo].[Reconciled]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reconciled](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[JournalCode] [char](2) NULL,
	[JournalItemIdNo] [int] NULL,
	[ReconciliationIdNo] [int] NULL,
 CONSTRAINT [PK_Reconciled] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AccountReconciliationItem_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[AccountReconciliationItem_View]
AS
SELECT      dbo.AccountReconciliationItem.IdNo, dbo.AccountReconciliationItem.Sequence, dbo.GlLedgers_View.TransactionDate, dbo.GlLedgers_View.IdNo AS JournalItemIdNo, dbo.GlLedgers_View.JournalCode, 
            dbo.AccountReconciliationItem.AccountReconciliationIdNo, dbo.GlLedgers_View.Debit, dbo.GlLedgers_View.DocumentNumber, dbo.GlLedgers_View.Credit, dbo.AccountReconciliationItem.Cleared, dbo.GlLedgers_View.AccountIdNo, dbo.GlLedgers_View.PayDescription, 
            dbo.GlLedgers_View.PayDescriptionAra, dbo.GlLedgers_View.ReferenceNo, dbo.GlLedgers_View.JournalIdNo, dbo.AccountReconciliation.Posted as Reconciled, dbo.AccountReconciliation.Posted
FROM        dbo.Reconciled 
			RIGHT OUTER JOIN dbo.GlLedgers_View 
			ON dbo.Reconciled.JournalCode = dbo.GlLedgers_View.JournalCode Collate SQL_Latin1_General_CP1_CI_AS AND dbo.Reconciled.JournalitemIdNo = dbo.GlLedgers_View.IdNo 
			LEFT OUTER JOIN dbo.AccountReconciliationItem 
			ON dbo.GlLedgers_View.JournalCode = dbo.AccountReconciliationItem.JournalCode Collate SQL_Latin1_General_CP1_CI_AS AND dbo.GlLedgers_View.IdNo = dbo.AccountReconciliationItem.JournalItemIdNo 
			LEFT OUTER JOIN dbo.AccountReconciliation 
			ON dbo.AccountReconciliationItem.AccountReconciliationIdNo = dbo.AccountReconciliation.IdNo
GO
/****** Object:  Table [dbo].[AccountTypes]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountTypes](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[AccountTypes] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AccountTypesIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[InputVatAccountTypes]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  View [dbo].[GlReconciliation_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[GlReconciliation_View]
AS
SELECT			dbo.GlLedgers_View.JournalCode, dbo.GlLedgers_View.IdNo, dbo.GlLedgers_View.Sequence, dbo.GlLedgers_View.JournalIdNo, dbo.GlLedgers_View.AccountIdNo, dbo.GlLedgers_View.Debit, 
                dbo.GlLedgers_View.Credit,dbo.GlLedgers_View.DocumentNumber, dbo.GlLedgers_View.RevCostCenterIdNo, dbo.GlLedgers_View.Notes, dbo.GlLedgers_View.Posted, dbo.GlLedgers_View.TransactionDate, dbo.GlLedgers_View.ReferenceNo, 
                dbo.GlLedgers_View.PayDescription, dbo.GlLedgers_View.PayDescriptionAra, dbo.Reconciled.IdNo AS Reconciled
FROM            dbo.GlLedgers_View 
				LEFT OUTER JOIN dbo.Reconciled 
				ON dbo.GlLedgers_View.IdNo = dbo.Reconciled.JournalitemIdNo AND dbo.GlLedgers_View.JournalCode = dbo.Reconciled.JournalCode Collate SQL_Latin1_General_CP1_CI_AS
GO
/****** Object:  Table [dbo].[CkdOiItem]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CkdOiItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[CkdIdNo] [int] NOT NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[DiscountTaken] [money] NOT NULL,
 CONSTRAINT [PK_CkdOiItemIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CkdOiItem_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CkdOiItem_View]
AS
SELECT        dbo.CkdOiItem.Sequence, dbo.ApOpenInvoice_View.InvoiceNo, dbo.ApOpenInvoice_View.TransactionDate, 
                         dbo.ApOpenInvoice_View.Balance + dbo.CkdOiItem.Amount + dbo.CkdOiItem.DiscountTaken AS PreviousBalance, dbo.CkdOiItem.Amount, dbo.CkdOiItem.DiscountTaken, dbo.ApOpenInvoice_View.Balance, 
                         dbo.CkdOiItem.JournalItemIdNo, dbo.ApOpenInvoice_View.Amount AS InvoiceAmount, dbo.ApOpenInvoice_View.JournalCode, dbo.ApOpenInvoice_View.JournalItemIdNo AS ApJournalItemIdNo, 
                         dbo.ApOpenInvoice_View.ReferenceNo, dbo.ApOpenInvoice_View.PaidAmount, dbo.CkdOiItem.IdNo, dbo.ApOpenInvoice_View.SupplierIdNo, dbo.ApOpenInvoice_View.IdNo AS OpenInvoiceIdNo, 
                         dbo.CkdOiItem.CkdIdNo, dbo.ApOpenInvoice_View.AccountIdNo, dbo.ApOpenInvoice_View.JournalIdNo
FROM            dbo.CkdOiItem LEFT OUTER JOIN
                         dbo.ApOpenInvoice_View ON dbo.CkdOiItem.JournalItemIdNo = dbo.ApOpenInvoice_View.JournalItemIdNo
GO
/****** Object:  Table [dbo].[Department]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[DepartmentCode] [varchar](10) NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
	[DepartmentNameAra] [nvarchar](50) NOT NULL,
	[ParentIdNo] [smallint] NULL,
	[Notes] [nvarchar](250) NULL,
	[RevCostCenterIdNo] [smallint] NULL,
	[RevCostCenterIdNo] [smallint] NULL,
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
/****** Object:  View [dbo].[Department_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create View [dbo].[Department_View] as 
with cte as
(
select IdNo
      ,DepartmentCode
      ,DepartmentName
      ,DepartmentNameAra
      ,ParentIdNo
      ,Notes
      ,RevCostCenterIdNo
      ,RevCostCenterIdNo
      ,Active
      ,DateTimeStamp
      ,cast(row_number()over(partition by ParentIdNo order by DepartmentName) as varchar(max)) as [path]
      ,0 as levelnumber
      ,row_number() over (partition by ParentIdNo order by DepartmentName) / power(10.0,0) as SortKey
 
from Department
where ParentIdNo IS NULL
union all
select t.IdNo
      ,t.DepartmentCode
      ,t.DepartmentName
      ,t.DepartmentNameAra
      ,t.ParentIdNo
      ,t.Notes
      ,t.RevCostCenterIdNo
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
   
select IdNo
      ,DepartmentCode
      ,DepartmentName
      ,DepartmentNameAra
      ,ParentIdNo
      ,Notes
      ,RevCostCenterIdNo
      ,RevCostCenterIdNo
      ,Active
      ,DateTimeStamp
	  ,LevelNumber
      ,[path]
      ,SortKey
from cte



GO
/****** Object:  Table [dbo].[SecurityObject]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityObject](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[SecurityObjectName] [varchar](100) NOT NULL,
	[SecurityObjectNameAra] [nvarchar](200) NULL,
	[Notes] [varchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_SecurityObjectIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupAccess]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupAccess](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[SecurityGroupIdNo] [int] NOT NULL,
	[SecurityObjectIdNo] [int] NOT NULL,
	[Visible] [bit] NOT NULL,
	[Viewable] [bit] NOT NULL,
	[Selectable] [bit] NOT NULL,
	[Editable] [bit] NOT NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_SecurityGroupAccessIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SecurityGroup]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityGroup](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[SecurityGroupName] [varchar](50) NULL,
	[Notes] [varchar](100) NULL,
	[DateTimeStamp] [timestamp] NULL,
	[SecurityGroupCode] [varchar](10) NULL,
	[SecurityGroupNameAra] [nvarchar](50) NULL,
 CONSTRAINT [PK_IdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_SecurityGroupName] UNIQUE NONCLUSTERED 
(
	[SecurityGroupName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[GroupAccess_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GroupAccess_View]
AS
SELECT        dbo.SecurityObject.IdNo, dbo.SecurityObject.SecurityObjectName, dbo.SecurityGroup.IdNo AS Expr1, dbo.GroupAccess.Visible, dbo.GroupAccess.Editable, dbo.GroupAccess.SecurityGroupIdNo, 
                         dbo.GroupAccess.SecurityObjectIdNo, dbo.GroupAccess.IdNo AS Expr2, dbo.SecurityGroup.SecurityGroupName
FROM            dbo.SecurityGroup INNER JOIN
                         dbo.GroupAccess ON dbo.SecurityGroup.IdNo = dbo.GroupAccess.SecurityGroupIdNo RIGHT OUTER JOIN
                         dbo.SecurityObject ON dbo.GroupAccess.SecurityObjectIdNo = dbo.SecurityObject.IdNo
GO
/****** Object:  View [dbo].[APStatement_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[APStatement_View]
AS
SELECT        dbo.ApDetails_View.JournalCode, dbo.ApDetails_View.IdNo, dbo.ApDetails_View.Sequence, dbo.ApDetails_View.JournalIdNo, dbo.ApDetails_View.AccountIdNo, dbo.ApDetails_View.Debit, dbo.ApDetails_View.Credit, 
                         dbo.ApDetails_View.RevCostCenterIdNo, dbo.ApDetails_View.Notes, dbo.ApDetails_View.Posted, dbo.ApDetails_View.SupplierIdNo, dbo.ApDetails_View.InvoiceNo, dbo.ApDetails_View.TransactionDate, dbo.ApDetails_View.ReferenceNo, 
                         dbo.ApDetails_View.TransactionType, dbo.Account.SpecialAccount
FROM            dbo.ApDetails_View INNER JOIN
                         dbo.Account ON dbo.ApDetails_View.AccountIdNo = dbo.Account.IdNo
WHERE        (dbo.Account.SpecialAccount = 'AP')
GO
/****** Object:  View [dbo].[SalesJournalItem_View]    Script Date: 3/28/2020 6:33:04 AM ******/
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
                         dbo.Account ON dbo.SalesJournalItem.AccountIdNo = dbo.Account.IdNo
GO
/****** Object:  Table [dbo].[EmployeeLoanJournalItem]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeLoanJournalItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [int] NULL,
	[JournalIdNo] [int] NOT NULL,
	[AccountIdNo] [int] NOT NULL,
	[TransactionDate] [datetime2](7) NULL,
	[Debit] [money] NULL,
	[Credit] [money] NULL,
	[RevCostCenterIdNo] [int] NULL,
	[Notes] [nvarchar](100) NULL,
	[Posted] [bit] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_EmployeeLoanJournalItemsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeLoanJournal]    Script Date: 3/28/2020 6:33:04 AM ******/
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
	[AccountIdNo] [int] NOT NULL,
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
/****** Object:  View [dbo].[EmployeeJournalItem_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[EmployeeJournalItem_View]
AS
SELECT        dbo.EmployeeLoanJournalItem.IdNo, dbo.EmployeeLoanJournalItem.Sequence, dbo.EmployeeLoanJournalItem.JournalIdNo, dbo.EmployeeLoanJournalItem.AccountIdNo, dbo.EmployeeLoanJournalItem.TransactionDate, dbo.EmployeeLoanJournalItem.Debit, 
                         dbo.EmployeeLoanJournalItem.Credit, dbo.EmployeeLoanJournalItem.RevCostCenterIdNo, dbo.EmployeeLoanJournalItem.Notes, dbo.EmployeeLoanJournalItem.Posted, dbo.EmployeeLoanJournalItem.DateTimeStamp, dbo.Account.AccountName
FROM            dbo.EmployeeLoanJournal INNER JOIN
                         dbo.EmployeeLoanJournalItem ON dbo.EmployeeLoanJournal.IdNo = dbo.EmployeeLoanJournalItem.JournalIdNo INNER JOIN
                         dbo.Account ON dbo.EmployeeLoanJournalItem.AccountIdNo = dbo.Account.IdNo 
GO
/****** Object:  Table [dbo].[CsrOiItem]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CsrOiItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[CsrIdNo] [int] NOT NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[DiscountTaken] [money] NOT NULL,
 CONSTRAINT [PK_CsrOiItemIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CsrOiItem_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[CsrOiItem_View]
AS
SELECT        dbo.CsrOiItem.Sequence, dbo.ArOpenInvoice_View.InvoiceNo, dbo.ArOpenInvoice_View.TransactionDate, 
                         dbo.ArOpenInvoice_View.Balance + dbo.CsrOiItem.Amount + dbo.CsrOiItem.DiscountTaken AS PreviousBalance, dbo.CsrOiItem.Amount, dbo.CsrOiItem.DiscountTaken, dbo.ArOpenInvoice_View.Balance, 
                         dbo.CsrOiItem.JournalItemIdNo, dbo.ArOpenInvoice_View.Amount AS InvoiceAmount, dbo.ArOpenInvoice_View.JournalCode, dbo.ArOpenInvoice_View.JournalItemIdNo AS ArJournalItemIdNo, 
                         dbo.ArOpenInvoice_View.ReferenceNo, dbo.ArOpenInvoice_View.PaidAmount, dbo.CsrOiItem.IdNo, dbo.ArOpenInvoice_View.CustomerIdNo, dbo.ArOpenInvoice_View.IdNo AS OpenInvoiceIdNo, 
                         dbo.CsrOiItem.CsrIdNo, dbo.ArOpenInvoice_View.AccountIdNo, dbo.ArOpenInvoice_View.JournalIdNo
FROM            dbo.CsrOiItem LEFT OUTER JOIN
                         dbo.ArOpenInvoice_View ON dbo.CsrOiItem.JournalItemIdNo = dbo.ArOpenInvoice_View.JournalItemIdNo
GO
/****** Object:  Table [dbo].[CadOiItem]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CadOiItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[CadIdNo] [int] NOT NULL,
	[JournalItemIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[DiscountTaken] [money] NOT NULL,
 CONSTRAINT [PK_CadOiItemIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CadOiItem_View]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[CadOiItem_View]
AS
SELECT        dbo.CadOiItem.Sequence, dbo.ApOpenInvoice_View.InvoiceNo, dbo.ApOpenInvoice_View.TransactionDate, 
                         dbo.ApOpenInvoice_View.Balance + dbo.CadOiItem.Amount + dbo.CadOiItem.DiscountTaken AS PreviousBalance, dbo.CadOiItem.Amount, dbo.CadOiItem.DiscountTaken, dbo.ApOpenInvoice_View.Balance, 
                         dbo.CadOiItem.JournalItemIdNo, dbo.ApOpenInvoice_View.Amount AS InvoiceAmount, dbo.ApOpenInvoice_View.JournalCode, dbo.ApOpenInvoice_View.JournalItemIdNo AS ApJournalItemIdNo, 
                         dbo.ApOpenInvoice_View.ReferenceNo, dbo.ApOpenInvoice_View.PaidAmount, dbo.CadOiItem.IdNo, dbo.ApOpenInvoice_View.SupplierIdNo, dbo.ApOpenInvoice_View.IdNo AS OpenInvoiceIdNo, 
                         dbo.CadOiItem.CadIdNo, dbo.ApOpenInvoice_View.AccountIdNo, dbo.ApOpenInvoice_View.JournalIdNo
FROM            dbo.CadOiItem LEFT OUTER JOIN
                         dbo.ApOpenInvoice_View ON dbo.CadOiItem.JournalItemIdNo = dbo.ApOpenInvoice_View.JournalItemIdNo
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[BankCode] [varchar](10) NULL,
	[BankName] [varchar](50) NULL,
	[BankNameAra] [nchar](50) NULL,
	[Notes] [nvarchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BankCharges]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankCharges](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[Branch]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[BranchCode] [varchar](5) NOT NULL,
	[BranchName] [varchar](50) NOT NULL,
	[BranchNameAra] [nvarchar](50) NOT NULL,
	[Notes] [varchar](255) NULL,
	[Active] [bit] NULL,
	[CreateDate] [datetime2](7) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK__BranchIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
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
/****** Object:  Table [dbo].[CashCode]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashCode](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[Category]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[CategoryCode] [varchar](10) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
	[CategoryNameAra] [nvarchar](100) NOT NULL,
	[Notes] [nvarchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[CountryCode] [varchar](2) NOT NULL,
	[CountryName] [varchar](100) NOT NULL,
	[CountryNameAra] [varchar](100) NOT NULL,
	[Nationality] [varchar](100) NOT NULL,
	[NationalityAra] [varchar](100) NOT NULL,
	[Flag32] [varchar](256) NULL,
	[Flag128] [varchar](256) NULL,
	[ISOA3] [varchar](3) NULL,
	[ISON] [int] NULL,
	[PhoneCode] [varchar](4) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_CountryIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_CountryCode] UNIQUE NONCLUSTERED 
(
	[CountryCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_NameAra] UNIQUE NONCLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_NameEng] UNIQUE NONCLUSTERED 
(
	[CountryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[countryf]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  Table [dbo].[CountryMaster]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  Table [dbo].[currencies]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  Table [dbo].[DefaultFieldValue]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefaultFieldValue](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [varchar](40) NOT NULL,
	[FieldName] [varchar](40) NOT NULL,
	[DataType] [tinyint] NOT NULL,
	[Length] [tinyint] NOT NULL,
	[DecimalPart] [tinyint] NULL,
	[LinkedTable] [varchar](40) NULL,
	[LinkedFieldValue] [varchar](40) NULL,
	[LinkedFieldName] [varchar](40) NULL,
	[DefaultValue] [varchar](255) NULL,
 CONSTRAINT [PK_DefaultFieldValue] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[DesignationCode] [varchar](5) NOT NULL,
	[DesignationName] [varchar](50) NOT NULL,
	[DesignationNameAra] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DistributionScheme]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  Table [dbo].[DistributionSchemeItem]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DistributionSchemeItem](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[DistributionSchemeIdNo] [int] NULL,
	[Sequence] [int] NULL,
	[RevCostCenterIdNo] [int] NULL,
	[Percentage] [decimal](18, 2) NULL,
 CONSTRAINT [PK_DistributionSchemeItem] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[IdNo] [tinyint] IDENTITY(1,1) NOT NULL,
	[DocumentCode] [varchar](5) NOT NULL,
	[DocumentName] [varchar](50) NOT NULL,
	[DocumentNameAra] [varchar](50) NULL,
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
/****** Object:  Table [dbo].[EmployeeDetails]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  Table [dbo].[EmployeeOld]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeOld](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
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
	[DepartmentIdNo] [int] NULL,
	[DesignationIdNo] [int] NULL,
	[PayGroupIdNo] [int] NULL,
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
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InterfaceObjectsSecurity]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InterfaceObjectsSecurity](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[LoginIdNo] [int] NOT NULL,
	[InterfaceObjectIdNo] [int] NOT NULL,
	[Editable] [bit] NOT NULL,
	[Visible] [bit] NOT NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_InterfaceObjectSecurity] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Idno] [smallint] NULL,
	[MessageCode] [varchar](50) NULL,
	[MessageText] [nvarchar](512) NULL,
	[DateTimeStamp] [timestamp] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NumberSeries]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NumberSeries](
	[SeriesName] [varchar](25) NULL,
	[CurrentValue] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 3/28/2020 6:33:04 AM ******/
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
/****** Object:  Table [dbo].[PhoneType]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhoneType](
	[IdNo] [tinyint] IDENTITY(1,1) NOT NULL,
	[PhoneTypeCode] [varchar](5) NOT NULL,
	[PhoneTypeName] [varchar](15) NOT NULL,
	[PhoneTypeNameAra] [varchar](15) NULL,
	[Notes] [varchar](50) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_PhoneType] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RevCostCenterOld]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RevCostCenterOld](
	[IdNo] [smallint] IDENTITY(1,1) NOT NULL,
	[RevCostCenterCode] [varchar](5) NOT NULL,
	[RevCostCenterName] [varchar](50) NOT NULL,
	[RevCostCenterNameAra] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RevCostCenterOrg]    Script Date: 3/28/2020 6:33:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RevCostCenterOrg](
	[IdNo] [int] NOT NULL,
	[ParentID] [int] NULL,
	[RevCostCenterCode] [varchar](5) NOT NULL,
	[RevCostCenterName] [varchar](50) NOT NULL,
	[RevCostCenterNameAra] [nvarchar](50) NOT NULL,
	[Descripton] [varchar](50) NULL,
	[EmployeeName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseItem]    Script Date: 3/28/2020 6:33:04 AM ******/
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
	[GlAccountIdNo] [int] NULL,
	[VatAccountIdNo] [int] NULL,
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
/****** Object:  Table [dbo].[PurchaseJournal]    Script Date: 3/28/2020 6:33:04 AM ******/
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
	[DateTimeStamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_PurchaseIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiptDetails]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiptDetails](
	[IdNo] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountIdNo] [int] NULL,
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
/****** Object:  Table [dbo].[Reconciliation]    Script Date: 3/28/2020 6:33:05 AM ******/
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
/****** Object:  Table [dbo].[Religion]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Religion](
	[IdNo] [tinyint] IDENTITY(1,1) NOT NULL,
	[ReligionCode] [varchar](5) NOT NULL,
	[ReligionName] [nvarchar](30) NOT NULL,
	[ReligionNameAra] [nvarchar](60) NULL,
	[Notes] [nvarchar](100) NULL,
	[DateTimeStamp] [timestamp] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesDeposit]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesDeposit](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[SalesJournalIdNo] [int] NOT NULL,
	[Sequence] [int] NOT NULL,
	[CashCode] [char](1) NOT NULL,
	[SaleAmount] [money] NOT NULL,
	[DepositAmount] [money] NOT NULL,
 CONSTRAINT [PK_SalesDetailItemIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salt]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salt](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[LoginIdNo] [int] NOT NULL,
	[Salt] [varchar](50) NULL,
	[Modified] [timestamp] NOT NULL,
 CONSTRAINT [PK_SaltIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Series]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Series](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[SJPrefix]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SJPrefix](
	[IdNo] [tinyint] NOT NULL,
	[AccountIdNo] [int] NULL,
	[Prefix] [char](1) NULL,
 CONSTRAINT [PK_SJPrefix] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier2]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier2](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[BranchID] [varchar](15) NULL,
	[SupplierID] [varchar](15) NOT NULL,
	[Courtesy] [varchar](15) NULL,
	[SupplierName] [varchar](50) NOT NULL,
	[SupplierNameAra] [nvarchar](50) NULL,
	[Contact_Person] [nvarchar](50) NULL,
	[DesignationID] [nvarchar](15) NULL,
	[Address1] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[Street] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Country] [char](3) NULL,
	[POBox] [varchar](10) NULL,
	[Zip] [varchar](10) NULL,
	[Phone1] [varchar](50) NULL,
	[Phone2] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[fax] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[web] [varchar](50) NULL,
	[CR_no] [varchar](20) NULL,
	[AC_Code] [varchar](10) NULL,
	[Blocked] [varchar](3) NULL,
	[SupplierType] [varchar](20) NULL,
	[AgentID] [varchar](15) NULL,
	[PriceCategory] [varchar](20) NULL,
	[CreditStatus] [varchar](20) NULL,
	[CreditDays] [decimal](3, 0) NULL,
	[CreditLimit] [decimal](12, 2) NULL,
	[CreditDiscount] [decimal](12, 2) NULL,
	[Remarks] [varchar](150) NULL,
	[CreateDate] [varchar](10) NULL,
	[UserId] [varchar](10) NULL,
	[MachineId] [varchar](20) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_SupplierDetailsIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdNo] [int] IDENTITY(18,1) NOT NULL,
	[UserName] [varchar](20) NOT NULL,
	[Password] [varchar](50) NULL,
	[SecurityGroupIdNo] [int] NULL,
	[FullName] [varchar](50) NULL,
	[FullNameAra] [nvarchar](50) NULL,
	[SecurityLevel] [tinyint] NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_UserIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[xxxLoginxxx]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[xxxLoginxxx](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[Modified] [timestamp] NOT NULL,
	[SecurityGroupIdNo] [int] NULL,
 CONSTRAINT [PK_LoginIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_AccountTypesAcctIdNo]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_AccountTypesAcctIdNo] ON [dbo].[AccountTypes]
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ApOpenInvoiceJournalCode]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_ApOpenInvoiceJournalCode] ON [dbo].[ApOpenInvoice]
(
	[JournalCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ApOpenInvoiceJournalItemIdNo]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_ApOpenInvoiceJournalItemIdNo] ON [dbo].[ApOpenInvoice]
(
	[JournalItemIdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RevCostCenterCode]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_RevCostCenterCode] ON [dbo].[RevCostCenter]
(
	[RevCostCenterCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RevCostCenterName]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_RevCostCenterName] ON [dbo].[RevCostCenter]
(
	[RevCostCenterName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RevCostCenterNameAra]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_RevCostCenterNameAra] ON [dbo].[RevCostCenter]
(
	[RevCostCenterNameAra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DistributionScheme]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_DistributionScheme] ON [dbo].[DistributionScheme]
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JournalDate]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_JournalDate] ON [dbo].[GeneralJournal]
(
	[TransactionDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_JournalReferenceNo]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_JournalReferenceNo] ON [dbo].[GeneralJournal]
(
	[ReferenceNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupAccessSGIDSOID]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_GroupAccessSGIDSOID] ON [dbo].[GroupAccess]
(
	[SecurityGroupIdNo] ASC,
	[SecurityObjectIdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupsSecurity]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_GroupsSecurity] ON [dbo].[GroupAccess]
(
	[SecurityGroupIdNo] ASC,
	[SecurityObjectIdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IntObjLoginIdNo]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_IntObjLoginIdNo] ON [dbo].[InterfaceObjectsSecurity]
(
	[LoginIdNo] ASC,
	[InterfaceObjectIdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RevCostCenterName]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_RevCostCenterName] ON [dbo].[RevCostCenter]
(
	[RevCostCenterName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RevCostCenterParent]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_RevCostCenterParent] ON [dbo].[RevCostCenter]
(
	[ParentIdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PurchaseInvoiceNo]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseInvoiceNo] ON [dbo].[PurchaseJournal]
(
	[InvoiceNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PurchaseReferenceNo]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseReferenceNo] ON [dbo].[PurchaseJournal]
(
	[ReferenceNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PurchaseSupplierIdNo]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseSupplierIdNo] ON [dbo].[PurchaseJournal]
(
	[SupplierIdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LoginIdNo]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_LoginIdNo] ON [dbo].[Salt]
(
	[LoginIdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SecurityObjectName]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_SecurityObjectName] ON [dbo].[SecurityObject]
(
	[SecurityObjectName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_LoginName]    Script Date: 3/28/2020 6:33:05 AM ******/
CREATE NONCLUSTERED INDEX [IX_LoginName] ON [dbo].[xxxLoginxxx]
(
	[LoginName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
ALTER TABLE [dbo].[ApJournalItem] ADD  CONSTRAINT [DF_ApJournalItem_RevCostCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
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
ALTER TABLE [dbo].[ArJournalItem] ADD  CONSTRAINT [DF_ArJournalItem_RevCostCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
GO
ALTER TABLE [dbo].[ArJournalItem] ADD  CONSTRAINT [DF_ArJournalItem_Posted]  DEFAULT ((0)) FOR [Posted]
GO
ALTER TABLE [dbo].[ArOpenInvoice] ADD  CONSTRAINT [DF_ArOpenInvoice_PaidAmount]  DEFAULT ((0)) FOR [PaidAmount]
GO
ALTER TABLE [dbo].[CashDisbursementJournalItem] ADD  CONSTRAINT [DF_CashDisbursementJournalItem_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO
ALTER TABLE [dbo].[CashDisbursementJournalItem] ADD  CONSTRAINT [DF_CashDisbursementJournalItem_JournalIdNo]  DEFAULT ((0)) FOR [JournalIdNo]
GO
ALTER TABLE [dbo].[CashDisbursementJournalItem] ADD  CONSTRAINT [DF_CashDisbursementJournalItem_AccountIdNo]  DEFAULT ((0)) FOR [AccountIdNo]
GO
ALTER TABLE [dbo].[CashDisbursementJournalItem] ADD  CONSTRAINT [DF_CashDisbursementJournalItem_Debit]  DEFAULT ((0)) FOR [Debit]
GO
ALTER TABLE [dbo].[CashDisbursementJournalItem] ADD  CONSTRAINT [DF_CashDisbursementJournalItem_Credit]  DEFAULT ((0)) FOR [Credit]
GO
ALTER TABLE [dbo].[CashDisbursementJournalItem] ADD  CONSTRAINT [DF_CashDisbursementJournalItem_RevCostCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
GO
ALTER TABLE [dbo].[CashDisbursementJournalItem] ADD  CONSTRAINT [DF_CashDisbursementJournalItem_Posted]  DEFAULT ((0)) FOR [Posted]
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
ALTER TABLE [dbo].[CashReceiptJournalItem] ADD  CONSTRAINT [DF_CashReceiptJournalItem_RevCostCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
GO
ALTER TABLE [dbo].[CashReceiptJournalItem] ADD  CONSTRAINT [DF_CashReceiptJournalItem_Posted]  DEFAULT ((0)) FOR [Posted]
GO
ALTER TABLE [dbo].[CheckDisbursementJournal] ADD  CONSTRAINT [DF_ChequeDisbursementJournal1_DateAdded]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[CheckDisbursementJournalItem] ADD  CONSTRAINT [DF_ChequeDisbursementJournalItem_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO
ALTER TABLE [dbo].[CheckDisbursementJournalItem] ADD  CONSTRAINT [DF_ChequeDisbursementJournalItem_AccountIdNo]  DEFAULT ((0)) FOR [AccountIdNo]
GO
ALTER TABLE [dbo].[CheckDisbursementJournalItem] ADD  CONSTRAINT [DF_ChequeDisbursementJournalItem_Debit]  DEFAULT ((0)) FOR [Debit]
GO
ALTER TABLE [dbo].[CheckDisbursementJournalItem] ADD  CONSTRAINT [DF_ChequeDisbursementJournalItem_Credit]  DEFAULT ((0)) FOR [Credit]
GO
ALTER TABLE [dbo].[CheckDisbursementJournalItem] ADD  CONSTRAINT [DF_ChequeDisbursementJournalItem_JournalIdNo]  DEFAULT ((0)) FOR [JournalIdNo]
GO
ALTER TABLE [dbo].[CheckDisbursementJournalItem] ADD  CONSTRAINT [DF_ChequeDisbursementJournalItem_RevCostCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
GO
ALTER TABLE [dbo].[CheckDisbursementJournalItem] ADD  CONSTRAINT [DF_ChequeDisbursementJournalItem_Posted]  DEFAULT ((0)) FOR [Posted]
GO
ALTER TABLE [dbo].[CkdOiItem] ADD  CONSTRAINT [DF_CkdOiItem_Amount]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[CkdOiItem] ADD  CONSTRAINT [DF_CkdOiItem_DiscountTaken]  DEFAULT ((0)) FOR [DiscountTaken]
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
ALTER TABLE [dbo].[EmployeeLoanJournal] ADD  CONSTRAINT [DF_EmployeeLoanJournal_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[EmployeeOld] ADD  CONSTRAINT [DF__Employee__Branch__5B438874]  DEFAULT ('0001') FOR [BranchID]
GO
ALTER TABLE [dbo].[EmployeeOld] ADD  CONSTRAINT [DF__Employee__Gender__5C37ACAD]  DEFAULT ('M') FOR [Gender]
GO
ALTER TABLE [dbo].[EmployeeOld] ADD  CONSTRAINT [DF__Employee__UserID__5D2BD0E6]  DEFAULT ('Admin') FOR [UserID]
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
ALTER TABLE [dbo].[GeneralJournalItem] ADD  CONSTRAINT [DF_GeneralJournalItem_RevCostCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
GO
ALTER TABLE [dbo].[GeneralJournalItem] ADD  CONSTRAINT [DF_GeneralJournalItem_Posted]  DEFAULT ((0)) FOR [Posted]
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
ALTER TABLE [dbo].[PcJournalItem] ADD  CONSTRAINT [DF_PcJournalItem_RevCostCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
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
ALTER TABLE [dbo].[PurchaseJournalItem] ADD  CONSTRAINT [DF_PurchaseJournalItem_RevCostCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
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
ALTER TABLE [dbo].[SalesJournalItem] ADD  CONSTRAINT [DF_SalesJournalItem_RevCostCenterIdNo]  DEFAULT ((0)) FOR [RevCostCenterIdNo]
GO
ALTER TABLE [dbo].[SalesJournalItem] ADD  CONSTRAINT [DF_SalesJournalItem_Posted]  DEFAULT ((0)) FOR [Posted]
GO
ALTER TABLE [dbo].[Supplier] ADD  CONSTRAINT [DF_Supplier2_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK__Account__ParentId] FOREIGN KEY([ParentIdNo])
REFERENCES [dbo].[Account] ([IdNo])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK__Account__ParentId]
GO
ALTER TABLE [dbo].[RevCostCenter]  WITH CHECK ADD  CONSTRAINT [FK__ProfitCen__Paren__6BAEFA67] FOREIGN KEY([ParentIdNo])
REFERENCES [dbo].[RevCostCenter] ([IdNo])
GO
ALTER TABLE [dbo].[RevCostCenter] CHECK CONSTRAINT [FK__ProfitCen__Paren__6BAEFA67]
GO
ALTER TABLE [dbo].[RevCostCenterOrg]  WITH CHECK ADD FOREIGN KEY([ParentID])
REFERENCES [dbo].[RevCostCenterOrg] ([IdNo])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_User] FOREIGN KEY([IdNo])
REFERENCES [dbo].[User] ([IdNo])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_User]
GO
/****** Object:  StoredProcedure [dbo].[InsertAccountReconciliationItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
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
/****** Object:  StoredProcedure [dbo].[InsertApJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






create PROC [dbo].[InsertApJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO ApJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.ApJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertArJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








create PROC [dbo].[InsertArJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO ArJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.ArJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertCadOiItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROC [dbo].[InsertCadOiItemTVP]
  @MParam CadOiItemInsert READONLY
AS 
INSERT  INTO CadOiItem ( Amount, CadIdNo, DiscountTaken, JournalItemIdNo, Sequence )
        SELECT  Amount, CadIdNo, DiscountTaken, JournalItemIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CadOiItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertCashDisbursementJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROC [dbo].[InsertCashDisbursementJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO CashDisbursementJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CashDisbursementJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertCashReceiptJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROC [dbo].[InsertCashReceiptJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO CashReceiptJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CashReceiptJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertCheckDisbursementJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







Create PROC [dbo].[InsertCheckDisbursementJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO CheckDisbursementJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CheckDisbursementJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertCkdOiItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROC [dbo].[InsertCkdOiItemTVP]
  @MParam CkdOiItemInsert READONLY
AS 
INSERT  INTO CkdOiItem ( Amount, CkdIdNo, DiscountTaken, JournalItemIdNo, Sequence )
        SELECT  Amount, CkdIdNo, DiscountTaken, JournalItemIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CkdOiItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertCsrOiItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROC [dbo].[InsertCsrOiItemTVP]
  @MParam CsrOiItemInsert READONLY
AS 
INSERT  INTO CsrOiItem ( Amount, CsrIdNo, DiscountTaken, JournalItemIdNo, Sequence )
        SELECT  Amount, CsrIdNo, DiscountTaken, JournalItemIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.CsrOiItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertDistributionSchemeItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





create PROC [dbo].[InsertDistributionSchemeItemTVP]
  @MParam DistributionSchemeItemInsert READONLY
AS 
INSERT  INTO DistributionSchemeItem (DistributionSchemeIdNo, [Sequence], RevCostCenterIdNo, [Percentage])
        SELECT  DistributionSchemeIdNo, [Sequence], RevCostCenterIdNo, [Percentage]
        FROM    @MParam
SET IDENTITY_INSERT DBO.DistributionSchemeItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertEmployeeLoanJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






create PROC [dbo].[InsertEmployeeLoanJournalItemTVP]
  @MParam EmployeeLoanJournalItemInsert READONLY
AS 
INSERT  INTO EmployeeLoanJournalItem (JournalIdNo, Sequence, AccountIdNo, Debit, Credit, RevCostCenterIdNo, Notes)
        SELECT  JournalIdNo, Sequence, AccountIdNo, Debit, Credit, RevCostCenterIdNo, Notes
        FROM    @MParam
SET IDENTITY_INSERT DBO.EmployeeLoanJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertGeneralJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






create PROC [dbo].[InsertGeneralJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO GeneralJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.GeneralJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertGroupAccessTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[InsertGroupAccessTVP]
  @MParam groupAccessInsert READONLY
AS 
INSERT  INTO GroupAccess (SecurityGroupIdNo, SecurityObjectIdNo, Visible,Selectable, Viewable, Editable)
        SELECT  SecurityGroupIdNo, SecurityObjectIdNo, Visible, Selectable, Viewable, Editable
        FROM    @MParam
SET IDENTITY_INSERT DBO.GroupAccess ON;
GO
/****** Object:  StoredProcedure [dbo].[InsertJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROC [dbo].[InsertJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO JournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.JournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertPcsOiItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROC [dbo].[InsertPcsOiItemTVP]
  @MParam PcsOiItemInsert READONLY
AS 
INSERT  INTO PcsOiItem ( Amount, PcsIdNo, DiscountTaken, JournalItemIdNo, Sequence )
        SELECT  Amount, PcsIdNo, DiscountTaken, JournalItemIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PcsOiItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertPcJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
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
/****** Object:  StoredProcedure [dbo].[InsertPurchaseJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





create PROC [dbo].[InsertPurchaseJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO PurchaseJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.PurchaseJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertReconciledTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
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
/****** Object:  StoredProcedure [dbo].[InsertSalesDepositTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[InsertSalesDepositTVP]
  @MParam SalesDepositInsert READONLY
AS 
INSERT  INTO SalesDeposit ( CashCode, DepositAmount, SaleAmount, SalesJournalIdNo, Sequence )
        SELECT  CashCode, DepositAmount, SaleAmount, SalesJournalIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.SalesDeposit ON;

GO
/****** Object:  StoredProcedure [dbo].[InsertSalesJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







create PROC [dbo].[InsertSalesJournalItemTVP]
  @MParam JournalItemInsert READONLY
AS 
INSERT  INTO SalesJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence)
        SELECT  AccountIdNo,Credit, Debit, JournalIdNo, Notes, RevCostCenterIdNo, Sequence
        FROM    @MParam
SET IDENTITY_INSERT DBO.SalesJournalItem ON;

GO
/****** Object:  StoredProcedure [dbo].[UpdateAccountReconciliationItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateApJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
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
on a.IdNo = b.IdNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateArJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
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
on a.IdNo = b.IdNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateCadOiItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE  [dbo].[UpdateCadOiItemTVP]
  @MParam CadOiItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].CadOiItem A WHERE A.CadIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing CadOiItems
UPDATE a 
SET a.Amount = B.Amount,
	a.CadIdNo = @GroupIdNo,
	a.DiscountTaken = B.DiscountTaken,
	a.JournalItemIdNo = B.JournalItemIdNo,
    a.[Sequence] = B.[Sequence]
from CadOiItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateCashDisbursementJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE  [dbo].[UpdateCashDisbursementJournalItemTVP]
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].CashDisbursementJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing CashDisbursementJournalItems
UPDATE a 
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from CashDisbursementJournalItem a
JOIN @MParam b
on a.IdNo = b.IdNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCashReceiptJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
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
on a.IdNo = b.IdNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCheckDisbursementJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE  [dbo].[UpdateCheckDisbursementJournalItemTVP]
  @MParam JournalItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].CheckDisbursementJournalItem A WHERE A.JOURNALIDNO = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing CheckDisbursementJournalItems
UPDATE a 
SET a.AccountIdNo = B.AccountIdNo,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = @GroupIdNo,
	a.Notes = B.Notes,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
	a.[Sequence] = B.[Sequence]
from CheckDisbursementJournalItem a
JOIN @MParam b
on a.IdNo = b.IdNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCkdOiItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE  [dbo].[UpdateCkdOiItemTVP]
  @MParam CkdOiItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE A
FROM [DBO].CkdOiItem A WHERE A.CkdIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing CkdOiItems
UPDATE a 
SET a.Amount = B.Amount,
	a.CkdIdNo = @GroupIdNo,
	a.DiscountTaken = B.DiscountTaken,
	a.JournalItemIdNo = B.JournalItemIdNo,
    a.[Sequence] = B.[Sequence]
from CkdOiItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateCsrOiItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
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
	a.CsrIdNo = @GroupIdNo,
	a.DiscountTaken = B.DiscountTaken,
	a.JournalItemIdNo = B.JournalItemIdNo,
    a.[Sequence] = B.[Sequence]
from CsrOiItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateDistributionSchemeItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
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
	A.RevCostCenterIdNo = B.RevCostCenterIdNo,
	A.Percentage = B.Percentage
from [dbo].DistributionSchemeItem A INNER JOIN @MParam As B
	ON A.IdNo = B.IdNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployeeLoanJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
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
on a.IdNo = b.IdNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateGeneralJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
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
	ON A.IdNo = B.IdNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateGroupAccessTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
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
SET a.SecurityGroupIdNo = @GroupIdNo ,
    a.SecurityObjectIdNo = B.SecurityObjectIdNo ,
	a.Visible = B.Visible ,
	a.Selectable = B.Selectable ,
	a.Viewable = B.Viewable ,
	a.Editable = B.Editable
from GroupAccess a INNER JOIN @MParam as B
on a.IdNo = b.IdNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









CREATE PROCEDURE  [dbo].[UpdateJournalItemTVP]
  @MParam JournalItemUpdate READONLY
AS 
UPDATE a 
SET a.AccountIdNo = B.AccountIdNo ,
	a.Credit = B.Credit,
	a.Debit = B.Debit,
	a.JournalIdNo = B.JournalIdNo ,
	a.Notes = B.Notes,
	a.RevCostCenterIdNo = B.RevCostCenterIdNo,
    a.[Sequence] = B.[Sequence]
from JournalItem a
JOIN @MParam b
on a.IdNo = b.IdNo

GO
/****** Object:  StoredProcedure [dbo].[UpdatePcsOiItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE  [dbo].[UpdatePcsOiItemTVP]
  @MParam PcsOiItemUpdate READONLY, @GroupIdNo as INT
AS 

BEGIN

-- Delete non existent records
DELETE a
FROM [DBO].PcsOiItem A WHERE a.PcsIdNo = @GroupIdNo and NOT EXISTS (SELECT * FROM @MParam where IdNo = A.IdNo )

-- Update existing PtcOIItems
UPDATE a 
SET a.Amount = b.Amount,
	a.PcsIdNo = @GroupIdNo,
	a.DiscountTaken = b.DiscountTaken,
	a.JournalItemIdNo = b.JournalItemIdNo,
    a.[Sequence] = b.[Sequence]
from PcsOiItem a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdatePcJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
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
on a.IdNo = b.IdNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePurchaseJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
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
on a.IdNo = b.IdNo

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateSalesDepositTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
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
SET a.CashCode = B.CashCode,
	a.DepositAmount = b.DepositAmount,
	a.SaleAmount = B.SaleAmount,
	a.SalesJournalIdNo = B.SalesJournalIdNo,
    a.[Sequence] = B.[Sequence]
from SalesDeposit a INNER JOIN @MParam As b
on a.IdNo = b.IdNo

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateSalesJournalItemTVP]    Script Date: 3/28/2020 6:33:05 AM ******/
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
	ON A.IdNo = B.IdNo

END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Country Name (English)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountryMaster', @level2type=N'COLUMN',@level2name=N'CountryNameEng'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[42] 4[29] 3[6] 2) )"
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
               Top = 24
               Left = 386
               Bottom = 339
               Right = 565
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
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[49] 4[28] 2[6] 3) )"
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
         Begin Table = "ApJournalItem"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 156
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "Account"
            Begin Extent = 
               Top = 0
               Left = 269
               Bottom = 130
               Right = 467
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApOpenInvoice"
            Begin Extent = 
               Top = 0
               Left = 644
               Bottom = 188
               Right = 821
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
         Column = 7905
         Alias = 2400
         Table = 2250
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ApJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ApJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[42] 2[11] 3) )"
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
               Top = 17
               Left = 19
               Bottom = 391
               Right = 196
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "APDetails_View"
            Begin Extent = 
               Top = 30
               Left = 262
               Bottom = 363
               Right = 441
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Account"
            Begin Extent = 
               Top = 20
               Left = 513
               Bottom = 485
               Right = 712
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
         Column = 11205
         Alias = 2940
         Table = 3975
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ApOpenInvoice_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ApOpenInvoice_View'
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
         Begin Table = "ApDetails_View"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 298
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Account"
            Begin Extent = 
               Top = 6
               Left = 255
               Bottom = 298
               Right = 454
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'APStatement_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'APStatement_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[27] 4[53] 2[11] 3) )"
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
         Begin Table = "ArJournalItem"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Account"
            Begin Extent = 
               Top = 6
               Left = 255
               Bottom = 136
               Right = 454
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ArOpenInvoice"
            Begin Extent = 
               Top = 10
               Left = 575
               Bottom = 201
               Right = 752
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
         Alias = 3345
         Table = 3495
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[34] 2[6] 3) )"
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
         Begin Table = "ARDetails_View"
            Begin Extent = 
               Top = 5
               Left = 467
               Bottom = 271
               Right = 786
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "ArOpenInvoice"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 332
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Account"
            Begin Extent = 
               Top = 47
               Left = 974
               Bottom = 328
               Right = 1172
            End
            DisplayFlags = 280
            TopColumn = 9
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
         Column = 2655
         Alias = 2715
         Table = 2175
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArOpenInvoice_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArOpenInvoice_View'
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
         Begin Table = "CashReceiptJournalItem"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Account"
            Begin Extent = 
               Top = 6
               Left = 255
               Bottom = 136
               Right = 454
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApOpenInvoice"
            Begin Extent = 
               Top = 88
               Left = 523
               Bottom = 279
               Right = 700
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CashReceiptJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CashReceiptJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[60] 4[12] 2[20] 3) )"
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
         Begin Table = "ChequeDisbursementJournal"
            Begin Extent = 
               Top = 71
               Left = 1042
               Bottom = 335
               Right = 1296
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "ChequeDisbursementJournalItem"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 247
               Right = 338
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Account"
            Begin Extent = 
               Top = 20
               Left = 724
               Bottom = 297
               Right = 922
            End
            DisplayFlags = 280
            TopColumn = 10
         End
         Begin Table = "ApOpenInvoice"
            Begin Extent = 
               Top = 208
               Left = 479
               Bottom = 466
               Right = 656
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
         Column = 2670
         Alias = 3345
         Table = 2955
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CheckDisbursementJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CheckDisbursementJournalItem_View'
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
         Begin Table = "CkdOiItem"
            Begin Extent = 
               Top = 5
               Left = 23
               Bottom = 255
               Right = 200
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApOpenInvoice_View"
            Begin Extent = 
               Top = 0
               Left = 251
               Bottom = 289
               Right = 627
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CkdOiItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CkdOiItem_View'
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
            TopColumn = 8
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
         Configuration = "(H (1[62] 4[3] 2[17] 3) )"
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
         Begin Table = "Languages"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 335
               Right = 631
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Translated"
            Begin Extent = 
               Top = 136
               Left = 253
               Bottom = 266
               Right = 423
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FormItems"
            Begin Extent = 
               Top = 37
               Left = 8
               Bottom = 366
               Right = 178
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SystemForms"
            Begin Extent = 
               Top = 8
               Left = 235
               Bottom = 113
               Right = 405
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Original"
            Begin Extent = 
               Top = 284
               Left = 252
               Bottom = 446
               Right = 422
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
       ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FormItemsOriginal_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FormItemsOriginal_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FormItemsOriginal_View'
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
               Bottom = 249
               Right = 213
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GeneralJournalItem"
            Begin Extent = 
               Top = 6
               Left = 251
               Bottom = 136
               Right = 430
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Account"
            Begin Extent = 
               Top = 0
               Left = 485
               Bottom = 130
               Right = 684
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApOpenInvoice"
            Begin Extent = 
               Top = 117
               Left = 720
               Bottom = 296
               Right = 897
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GeneralJournalItem_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GeneralJournalItem_View'
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
         Begin Table = "ApOpenInvoice"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 273
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApJournalItem"
            Begin Extent = 
               Top = 6
               Left = 253
               Bottom = 292
               Right = 432
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Account"
            Begin Extent = 
               Top = 6
               Left = 470
               Bottom = 136
               Right = 668
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApJournal"
            Begin Extent = 
               Top = 6
               Left = 706
               Bottom = 335
               Right = 899
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Supplier"
            Begin Extent = 
               Top = 6
               Left = 937
               Bottom = 136
               Right = 1131
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
         Table = 2040
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
        ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SupplierInvoices'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SupplierInvoices'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SupplierInvoices'
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
         Begin Table = "Translated"
            Begin Extent = 
               Top = 0
               Left = 17
               Bottom = 313
               Right = 187
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Languages"
            Begin Extent = 
               Top = 150
               Left = 270
               Bottom = 335
               Right = 447
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Original"
            Begin Extent = 
               Top = 21
               Left = 256
               Bottom = 117
               Right = 426
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TranslatedCaption_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TranslatedCaption_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[13] 4[49] 2[19] 3) )"
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
         Top = -192
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TranslatedMessages"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 227
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Languages"
            Begin Extent = 
               Top = 6
               Left = 265
               Bottom = 136
               Right = 442
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OriginalMessages"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 211
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
         Column = 3870
         Alias = 900
         Table = 3345
         Output = 2340
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
USE [master]
GO
ALTER DATABASE [ISPDATA] SET  READ_WRITE 
GO

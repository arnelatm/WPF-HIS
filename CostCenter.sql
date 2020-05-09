USE [ISPDATA]
GO

/****** Object:  Table [dbo].[CostCenter]    Script Date: 3/9/2020 7:52:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CostCenter](
	[IdNo] [int] IDENTITY(1,1) NOT NULL,
	[CostCenterCode] [varchar](5) NOT NULL,
	[CostCenterName] [varchar](50) NOT NULL,
	[ParentIdNo] [smallint] NULL,
	[ProfitCenterIdNo] [int] NULL,
	[CostCenterNameAra] [varchar](50) NOT NULL,
	[Notes] [varchar](255) NULL,
	[DateTimeStamp] [timestamp] NULL,
 CONSTRAINT [PK_CostCenterIdNo] PRIMARY KEY CLUSTERED 
(
	[IdNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [DBDEMO]
GO
/****** Object:  Table [dbo].[tblStudent_Fee]    Script Date: 04-06-2020 14:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStudent_Fee](
	[intStudFee_id] [int] IDENTITY(1,1) NOT NULL,
	[intStudent_id] [int] NULL,
	[intStandard_id] [int] NULL,
	[intDivision_id] [int] NULL,
	[intRoll_no] [int] NULL,
	[vchDiscount] [varchar](50) NULL,
	[vchNet_amt] [varchar](50) NULL,
	[vchRemark] [varchar](50) NULL,
	[ModeOfPayment] [varchar](50) NULL,
	[vchCheque_no] [varchar](50) NULL,
	[vchBank_name] [varchar](150) NULL,
	[intSchool_id] [int] NULL,
	[intAcademic_id] [int] NULL,
	[intActive_flg] [int] NULL,
	[intInserted_by] [int] NULL,
	[dtInserted_date] [datetime] NULL,
	[vchInserted_ip] [varchar](100) NULL,
 CONSTRAINT [PK_tblStudent_Fee] PRIMARY KEY CLUSTERED 
(
	[intStudFee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [DBDEMO]
GO
/****** Object:  Table [dbo].[tblStudentFee_details]    Script Date: 04-06-2020 14:22:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStudentFee_details](
	[intStudFee_DetailId] [int] IDENTITY(1,1) NOT NULL,
	[intStudFee_id] [int] NULL,
	[intFeemaster_id] [int] NULL,
	[intNoOf_month] [int] NULL,
	[intMonth_id] [varchar](15) NULL,
	[vchAmount] [varchar](50) NULL,
	[vchLate_charges] [varchar](10) NULL,
	[intConcession_amt] [varchar](50) NULL,
	[vchNetDetail_amt] [varchar](50) NULL,
	[intSchool_id] [int] NULL,
	[intAcademic_id] [int] NULL,
	[intActive_flg] [int] NULL,
	[dtpaid_date] [datetime] NULL,
 CONSTRAINT [PK_tblStudentFee_details] PRIMARY KEY CLUSTERED 
(
	[intStudFee_DetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblStudentFee_details]  WITH CHECK ADD  CONSTRAINT [FK_tblStudentFee_details_tblStudent_Fee] FOREIGN KEY([intStudFee_id])
REFERENCES [dbo].[tblStudent_Fee] ([intStudFee_id])
GO
ALTER TABLE [dbo].[tblStudentFee_details] CHECK CONSTRAINT [FK_tblStudentFee_details_tblStudent_Fee]
GO
ALTER TABLE [dbo].[tblStudentFee_details]  WITH CHECK ADD  CONSTRAINT [FK_tblStudentFee_details_tblStudentFee_details] FOREIGN KEY([intStudFee_DetailId])
REFERENCES [dbo].[tblStudentFee_details] ([intStudFee_DetailId])
GO
ALTER TABLE [dbo].[tblStudentFee_details] CHECK CONSTRAINT [FK_tblStudentFee_details_tblStudentFee_details]
GO

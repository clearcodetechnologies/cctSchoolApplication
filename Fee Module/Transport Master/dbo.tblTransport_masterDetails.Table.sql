USE [DBDEMO]
GO
/****** Object:  Table [dbo].[tblTransport_masterDetails]    Script Date: 04-06-2020 14:14:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTransport_masterDetails](
	[intID] [int] IDENTITY(1,1) NOT NULL,
	[intTransport_id] [int] NULL,
	[dtStart_date] [datetime] NULL,
	[dtEnd_date] [datetime] NULL,
	[IsConcession] [int] NULL,
	[numAmout] [varchar](50) NULL,
	[Startday] [int] NULL,
	[Dueday] [int] NULL,
	[intActive_flg] [int] NULL,
 CONSTRAINT [PK_tblTransport_masterDetails] PRIMARY KEY CLUSTERED 
(
	[intID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [DBDEMO]
GO
/****** Object:  Table [dbo].[tblTransport_master]    Script Date: 04-06-2020 14:14:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTransport_master](
	[intTransport_id] [int] IDENTITY(1,1) NOT NULL,
	[intArea_Id] [int] NULL,
	[intSchool_Id] [int] NULL,
	[intAcademic_id] [int] NULL,
	[intActiveFlg] [int] NULL,
	[dtInsertedDt] [datetime] NULL,
	[vchInsertedIP] [varchar](50) NULL,
	[intInsertedBy] [int] NULL,
	[vchDeletedIP] [varchar](50) NULL,
	[dtDeletedDate] [datetime] NULL,
	[intDeletedBy] [int] NULL,
	[dtUpdatedDate] [datetime] NULL,
	[vchUpdatedIp] [varchar](50) NULL,
	[intUpdatedBy] [int] NULL,
 CONSTRAINT [PK_tblTransport_master] PRIMARY KEY CLUSTERED 
(
	[intTransport_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

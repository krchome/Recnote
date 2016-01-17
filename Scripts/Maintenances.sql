


/****** Object:  Table [dbo].[Maintenances]    Script Date: 07/16/2015 14:19:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Maintenances](
	[MaintenanceId] [int] IDENTITY(1,1) NOT NULL,
	[MaintenanceTypeId] [int] NOT NULL,
	[WorkDescription] [nvarchar](500) NULL,
	[InvoiceAmount] [smallmoney] NULL,
	[InvoiceDetails] [nvarchar](500) NULL,
	[Provider] [nvarchar](250) NULL,
	[Comments] [nvarchar](500) NULL,
	[DateDone] [date] NULL,
	[NextDue] [date] NULL,
 CONSTRAINT [PK_MaintenanceHistory] PRIMARY KEY CLUSTERED 
(
	[MaintenanceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Maintenances]  WITH CHECK ADD  CONSTRAINT [FK_MaintenanceHistory_Maintenance] FOREIGN KEY([MaintenanceTypeId])
REFERENCES [dbo].[MaintenanceType] ([MaintenanceTypeId])
GO

ALTER TABLE [dbo].[Maintenances] CHECK CONSTRAINT [FK_MaintenanceHistory_Maintenance]
GO


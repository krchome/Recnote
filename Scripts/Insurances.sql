USE [Expenses]
GO

/****** Object:  Table [dbo].[Insurances]    Script Date: 07/16/2015 14:16:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Insurances](
	[InsuranceId] [int] IDENTITY(1,1) NOT NULL,
	[InsuranceTypeId] [int] NOT NULL,
	[CustomerNo] [nvarchar](20) NULL,
	[PolicyNo] [nvarchar](20) NULL,
	[PolicyType] [nvarchar](50) NULL,
	[StartDate] [date] NULL,
	[ExpiryDate] [date] NULL,
	[InsuredName] [nvarchar](50) NULL,
	[Premium] [smallmoney] NULL,
	[PaymentType] [nvarchar](20) NULL,
	[PaymentMethod] [nvarchar](20) NULL,
	[Bank] [nvarchar](20) NULL,
	[Comments] [nvarchar](500) NULL,
 CONSTRAINT [PK_Insurances] PRIMARY KEY CLUSTERED 
(
	[InsuranceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Insurances]  WITH CHECK ADD  CONSTRAINT [FK_InsuranceType_Insurance] FOREIGN KEY([InsuranceTypeId])
REFERENCES [dbo].[InsuranceType] ([InsuranceTypeId])
GO

ALTER TABLE [dbo].[Insurances] CHECK CONSTRAINT [FK_InsuranceType_Insurance]
GO


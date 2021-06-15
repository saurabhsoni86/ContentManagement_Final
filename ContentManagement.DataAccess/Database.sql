Create Database ContactsDetails
Go

USE [ContactsDetails]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 06/14/2021 16:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

GO
CREATE TABLE [dbo].[ContactNumbers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [int] NOT NULL,
	[ContactNumber] [nvarchar](50) NOT NULL,
	[IsPrimary] [bit] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ContactNumbers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ContactNumbers]  WITH CHECK ADD  CONSTRAINT [FK_ContactID] FOREIGN KEY([ContactId] )
REFERENCES [dbo].[Contacts] ([ID])
GO

ALTER TABLE [dbo].[ContactNumbers] CHECK CONSTRAINT [FK_ContactID]
GO
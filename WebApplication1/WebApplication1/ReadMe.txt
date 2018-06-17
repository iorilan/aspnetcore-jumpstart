Include:

1. CRUD of aspnetcore application

2. host in IIS (windows)
2-1 download and install SDK
https://www.microsoft.com/net/download/all

2.2 if you using razor view. need to install nuget package :
Microsoft.AspNetCore.Mvc.Razor.ViewCompilation

2.3 install :http://go.microsoft.com/fwlink/?LinkId=798480
make sure apsnetcoremodule appears in IIs Server -> Modules

2.4 publish -> folder -> select a folder 

2.5 iis point to that folder



install EFCore nugets:
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design

script to create testing table :
USE [Employee]
GO

/****** Object:  Table [dbo].[Person]    Script Date: 17/6/2018 5:57:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Person](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IdNumber] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[Address] [nvarchar](255) NULL,
	[JoinDate] [datetime2](7) NULL,
	[Photo] [image] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


then generate the model (replace the connection string)
Scaffold-DbContext "Server=DESKTOP-HDR4IFR;Database=Employee;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DbModels
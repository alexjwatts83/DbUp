/****** Object:  Table [dbo].[$TableName$]    Script Date: 31/07/2021 4:46:41 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[$TableName$]') AND type in (N'U'))
DROP TABLE [dbo].$TableName$
GO

/****** Object:  Table [dbo].[$TableName$]    Script Date: 31/07/2021 4:46:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].$TableName$ (
	[Id] [nvarchar](3) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[State] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL
) ON [PRIMARY]
GO
USE [MusicStreaming]
GO

/****** Object:  Table [dbo].[UserCollection]    Script Date: 15-07-2022 00:03:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserCollection](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserCollection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserCollection]  WITH CHECK ADD  CONSTRAINT [FK_User_UserCollection] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[UserCollection] CHECK CONSTRAINT [FK_User_UserCollection]
GO


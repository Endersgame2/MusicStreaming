USE [MusicStreaming]
GO

/****** Object:  Table [dbo].[Order]    Script Date: 27-07-2022 18:16:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[SongId] [int] NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[Rating] [tinyint] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Song_Order] FOREIGN KEY([SongId])
REFERENCES [dbo].[Song] ([Id])
GO

ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Song_Order]
GO

ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_User_Order] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_User_Order]
GO


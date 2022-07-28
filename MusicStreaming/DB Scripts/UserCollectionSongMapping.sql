USE [MusicStreaming]
GO

/****** Object:  Table [dbo].[UserCollectionSongMapping]    Script Date: 15-07-2022 00:03:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserCollectionSongMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserCollectionId] [int] NOT NULL,
	[SongId] [int] NOT NULL,
 CONSTRAINT [PK_CollectionSongMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserCollectionSongMapping]  WITH CHECK ADD  CONSTRAINT [FK_Song_UserCollectionSongMapping] FOREIGN KEY([SongId])
REFERENCES [dbo].[Song] ([Id])
GO

ALTER TABLE [dbo].[UserCollectionSongMapping] CHECK CONSTRAINT [FK_Song_UserCollectionSongMapping]
GO

ALTER TABLE [dbo].[UserCollectionSongMapping]  WITH CHECK ADD  CONSTRAINT [FK_UserCollection_UserCollectionSongMapping] FOREIGN KEY([UserCollectionId])
REFERENCES [dbo].[UserCollection] ([Id])
GO

ALTER TABLE [dbo].[UserCollectionSongMapping] CHECK CONSTRAINT [FK_UserCollection_UserCollectionSongMapping]
GO


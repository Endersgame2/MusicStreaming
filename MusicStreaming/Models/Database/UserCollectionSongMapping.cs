using System;
using System.Collections.Generic;

#nullable disable

namespace MusicStreaming.Models.Database
{
    public partial class UserCollectionSongMapping
    {
        public int Id { get; set; }
        public int UserCollectionId { get; set; }
        public int SongId { get; set; }

        public virtual Song Song { get; set; }
        public virtual UserCollection UserCollection { get; set; }
    }
}

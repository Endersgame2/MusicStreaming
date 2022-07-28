using System;
using System.Collections.Generic;

#nullable disable

namespace MusicStreaming.Models.Database
{
    public partial class Song
    {
        public Song()
        {
            Orders = new HashSet<Order>();
            UserCollectionSongMappings = new HashSet<UserCollectionSongMapping>();
        }

        public int Id { get; set; }
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<UserCollectionSongMapping> UserCollectionSongMappings { get; set; }
    }
}

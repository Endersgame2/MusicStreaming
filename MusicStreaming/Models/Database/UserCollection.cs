using System;
using System.Collections.Generic;

#nullable disable

namespace MusicStreaming.Models.Database
{
    public partial class UserCollection
    {
        public UserCollection()
        {
            UserCollectionSongMappings = new HashSet<UserCollectionSongMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<UserCollectionSongMapping> UserCollectionSongMappings { get; set; }
    }
}

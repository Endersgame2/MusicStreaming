using System;
using System.Collections.Generic;

#nullable disable

namespace MusicStreaming.Models.Database
{
    public partial class Order
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int SongId { get; set; }
        public DateTime TimeStamp { get; set; }
        public byte? Rating { get; set; }

        public virtual Song Song { get; set; }
        public virtual User User { get; set; }
    }
}

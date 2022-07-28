using System.Collections.Generic;

namespace MusicStreaming.Models.ViewModel
{
    public class StoreView
    {
        public List<SongItem> SongItems { get; set; }
    }
    public class SongItem
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public bool IsOrdered { get; set; }
        public bool IsRefundAvailable { get; set; }
    }
}

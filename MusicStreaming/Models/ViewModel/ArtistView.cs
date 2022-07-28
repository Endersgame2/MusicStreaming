using System.Collections.Generic;

namespace MusicStreaming.Models.ViewModel
{
    public class ArtistView
    {
        public List<KeyValuePair<int, string>> Artists { get; set; }
        public List<ArtistViewItem> ArtistViewItems { get; set; }
    }

    public class ArtistViewItem
    {
        public string SongName { get; set; }
        public int AddedToCollectionCount { get; set; }
    }
}

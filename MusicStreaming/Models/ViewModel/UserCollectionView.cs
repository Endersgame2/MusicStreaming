using System.Collections.Generic;

namespace MusicStreaming.Models.ViewModel
{
    public class UserCollectionView
    {
        public UserCollectionView()
        {
            Users = new List<KeyValuePair<int, string>>();
            UserCollectionItems = new List<UserCollectionItem>();
        }
        public List<KeyValuePair<int, string>> Users { get; set; }
        public List<UserCollectionItem> UserCollectionItems { get; set; }
    }

    public class UserCollectionItem
    {
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public string CollectionName { get; set; }
    }
}

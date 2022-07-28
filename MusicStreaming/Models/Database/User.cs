using System;
using System.Collections.Generic;

#nullable disable

namespace MusicStreaming.Models.Database
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            UserCollections = new HashSet<UserCollection>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal? Balance { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<UserCollection> UserCollections { get; set; }
    }
}

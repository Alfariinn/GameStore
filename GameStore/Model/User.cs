using System;
using System.Collections.Generic;

namespace GameStore
{
    public partial class User
    {
        public User()
        {
            Purchases = new HashSet<Purchase>();
        }

        public long UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual Library? Library { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace GameStore
{
    public partial class Category
    {
        public Category()
        {
            Games = new HashSet<Game>();
        }

        public long CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Game> Games { get; set; }
    }
}

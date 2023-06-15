using System;
using System.Collections.Generic;

namespace GameStore.MVVM.Model
{
    public partial class Game
    {
        public Game()
        {
            Purchases = new HashSet<Purchase>();
        }

        public long GameId { get; set; }
        public string Title { get; set; } = null!;
        public long? CategoryId { get; set; }
        public string? ReleaseDate { get; set; }
        public double Price { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}

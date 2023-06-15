using System;
using System.Collections.Generic;

namespace GameStore
{
    public partial class GamesInLibrary
    {
        public long? LibraryId { get; set; }
        public long? GameId { get; set; }

        public virtual Game? Game { get; set; }
        public virtual Library? Library { get; set; }
    }
}

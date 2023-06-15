using System;
using System.Collections.Generic;

namespace GameStore.MVVM.Model
{
    public partial class GamesInLibrary
    {
        public long? LibraryId { get; set; }
        public long? GameId { get; set; }

        public virtual Game? Game { get; set; }
        public virtual Library? Library { get; set; }
    }
}

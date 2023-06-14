using System;
using System.Collections.Generic;

namespace GameStore
{
    public partial class Purchase
    {
        public long PurchaseId { get; set; }
        public long? UserId { get; set; }
        public long? GameId { get; set; }
        public string PurchaseDate { get; set; } = null!;

        public virtual Game? Game { get; set; }
        public virtual User? User { get; set; }
    }
}

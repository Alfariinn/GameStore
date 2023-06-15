using System;
using System.Collections.Generic;

namespace GameStore
{
    public partial class Library
    {
        public long LibraryId { get; set; }
        public long? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}

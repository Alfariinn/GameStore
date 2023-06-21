using System;
using System.Collections.Generic;

namespace GameStore.MVVM.Model
{
    public partial class Library
    {
        public long LibraryId { get; set; }
        public long? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace VocableMVC.Models.Entities
{
    public partial class Categories
    {
        public Categories()
        {
            Dictionary = new HashSet<Dictionary>();
        }

        public int Id { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Dictionary> Dictionary { get; set; }
    }
}

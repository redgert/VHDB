using System;
using System.Collections.Generic;

namespace VocableMVC.Models.Entities
{
    public partial class Languages
    {
        public Languages()
        {
            Dictionary = new HashSet<Dictionary>();
        }

        public int Id { get; set; }
        public string Language { get; set; }

        public virtual ICollection<Dictionary> Dictionary { get; set; }
    }
}

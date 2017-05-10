using System;
using System.Collections.Generic;

namespace VocableMVC.Models.Entities
{
    public partial class Languages
    {
        public Languages()
        {
            VocableDictionary = new HashSet<VocableDictionary>();
        }

        public int Id { get; set; }
        public string Language { get; set; }

        public virtual ICollection<VocableDictionary> VocableDictionary { get; set; }
    }
}

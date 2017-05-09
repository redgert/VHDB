using System;
using System.Collections.Generic;

namespace VocableMVC.Models.Entities
{
    public partial class Categories
    {
        public Categories()
        {
            VocableDictionary = new HashSet<VocableDictionary>();
        }

        public int Id { get; set; }
        public string Category { get; set; }

        public virtual ICollection<VocableDictionary> VocableDictionary { get; set; }
    }
}

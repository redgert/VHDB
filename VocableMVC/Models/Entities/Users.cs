using System;
using System.Collections.Generic;

namespace VocableMVC.Models.Entities
{
    public partial class Users
    {
        public Users()
        {
            VocableDictionary = new HashSet<VocableDictionary>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<VocableDictionary> VocableDictionary { get; set; }
    }
}

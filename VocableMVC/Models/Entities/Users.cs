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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Aspid { get; set; }

        public virtual ICollection<VocableDictionary> VocableDictionary { get; set; }
        public virtual AspNetUsers Asp { get; set; }
    }
}

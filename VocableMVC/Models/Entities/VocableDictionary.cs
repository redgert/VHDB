using System;
using System.Collections.Generic;

namespace VocableMVC.Models.Entities
{
    public partial class VocableDictionary
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public Guid JoinId { get; set; }
        public int Cid { get; set; }
        public int Uid { get; set; }
        public int Lid { get; set; }

        public virtual Categories C { get; set; }
        public virtual Languages L { get; set; }
        public virtual Users U { get; set; }
    }
}

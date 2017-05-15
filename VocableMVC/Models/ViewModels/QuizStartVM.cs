using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VocableMVC.Models.ViewModels
{
    public class VocableWord
    {
        public string Word { get; set; }
        public Guid JoinId { get; set; }
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
    }

    public class QuizStartVM
    {
        public VocableWord MasterWord { get; set; }
        public SvarsOrd[] SvarsOrden { get; set; }
    }

    public class SvarsOrd
    {
        public VocableWord AWord { get; set; }
        public bool SelectedByUser { get; set; }
    }
}

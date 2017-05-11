using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VocableMVC.Models.ViewModels
{
    public class QuizStartVM
    {
        public string Word { get; set; }
        public Guid JoinId { get; set; }
        public string CategoryId { get; set; }
        public string LanguageId { get; set; }


    }
}

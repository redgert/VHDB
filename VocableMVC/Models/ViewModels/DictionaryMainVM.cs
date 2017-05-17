using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VocableMVC.Models.ViewModels
{
    //public class DictionaryMainVM
    //{
    //    public string MotherWord { get; set; }

    //    public string ForeignWord { get; set; }

    //    public string Category { get; set; }

    //    public string MotherLanguage { get; set; }

    //    public string ForeignLanguage { get; set; }

    //}

    public class DictionaryWord
    {
        public string MotherWord { get; set; }

        public int LanguageId { get; set; }

        public int CategoryId { get; set; }

        public Guid JoinId { get; set; }

        public ForeignWord ForeignWord { get; set; }
    }

    public class ForeignWord
    {
        public string AnswerWord { get; set; }

        public int LangugageId { get; set; }

        public Guid JoinId { get; set; }
    }
    
    //public static List<DictionaryWord> dictionaryWords = new List<DictionaryWord>();
        
}

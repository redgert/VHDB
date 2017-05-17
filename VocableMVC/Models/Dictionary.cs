using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocableMVC.Models.Entities;
using VocableMVC.Models.ViewModels;

namespace VocableMVC.Models
{
    public class Dictionary
    {
        Random random = new Random();

        private VHDBContext _VHDBContext;

        public Dictionary(VHDBContext vhdbContext)
        {
            _VHDBContext = vhdbContext;
        }

        public DictionaryMainVM GetDictionaryFromVHDB(int toLanguageId, int categoryId)
        {
            DictionaryMainVM dictionaryMainVM = new DictionaryMainVM();

            //Bygg en lista av ord på valt språk
            var q1 = _VHDBContext.VocableDictionary
                .Where(w => w.Cid == categoryId && w.Lid == 1)
                .Select(w => new
                {
                    OrgWord = w.Word,
                    TransWord = _VHDBContext.VocableDictionary
                        .Where(w2 => w2.JoinId == w.JoinId && w2.Lid == toLanguageId)
                        .Select(w2 => w2.Word)
                        .SingleOrDefault()
                })
                .ToArray();

            int i = 0;
            //foreach (var item in q1)
            //{
            //    item.JoinId
            //}


            //Bygg en lista av ord på svenska
            var q2 = _VHDBContext.VocableDictionary
                .Where(w => w.Cid == categoryId && w.Lid == 1)
                .ToList();

            return dictionaryMainVM;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocableMVC.Models.Entities;

namespace VocableMVC.Models
{
    public class Quiz
    {
        private VHDBContext _VHDBContext;

        public Quiz(VHDBContext vhdbContext)
        {
            _VHDBContext = vhdbContext;
        }

        //List<VocableDictionary> vd
        public string GetWordFromVHDB()
        {

            //ta ut ord från databasen och visa på sidan
            ////var w => Entities.VocableDictionary
            //string word = "";
            //    word = vd
            //        .Where(w => w.Cid == 1)
            //        .Where(l => l.Lid == 1)
            //        .FirstOrDefault().ToString();
            //return word;
            ////string Word = "";
            //Guid JoinId;
            //string[] q = _VHDBContext.VocableDictionary.Where(w => w.Cid == 1).Where(l => l.Lid == 1).FirstOrDefault().{ Word = q.Word, JoinId = q.JoinId }.ToArray();

            var q = _VHDBContext.VocableDictionary.Where(w => w.Cid == 1).Where(w => w.Lid == 1).FirstOrDefault().Word.ToString();



            return q;


        }

        public static void MatchWord()
        {
            //matcha ordet som användaren har klickat på mot det ord som hämtats från databasen


        }

        

    }
}

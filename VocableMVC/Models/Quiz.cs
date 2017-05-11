using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocableMVC.Models.Entities;

namespace VocableMVC.Models
{
    public class Quiz
    {
        public string GetWordFromVHDB()
        {
            //ta ut ord från databasen och visa på sidan
            //var w => Entities.VocableDictionary
            var word = "";

            using (VHDBContext context = new VHDBContext())
            {

                word = context.VocableDictionary
                    .Where(w => w.Cid == 1)
                    .Where(l => l.Lid == 1)
                    .FirstOrDefault().ToString();
            }
            return word;
        }

        public void MatchWord()
        {
            //matcha ordet som användaren har klickat på mot det ord som hämtats från databasen


        }

        

    }
}

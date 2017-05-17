using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocableMVC.Models.Entities;
using VocableMVC.Models.ViewModels;

namespace VocableMVC.Models
{
    public class Quiz
    {
        Random random = new Random();

        private VHDBContext _VHDBContext;

        public Quiz(VHDBContext vhdbContext)
        {
            _VHDBContext = vhdbContext;
        }

        //List<VocableDictionary> vd
        public QuizStartVM GetWordFromVHDB(int fromLanguageId, int toLanguageId, int categoryId)
        {
            var masterWord = _VHDBContext.VocableDictionary
                .Where(w => w.Cid == categoryId && w.Lid == fromLanguageId)
                .Select(w => new VocableWord
                {
                    Id = w.Id,
                    CategoryId = w.Cid,
                    JoinId = w.JoinId,
                    LanguageId = w.Lid,
                    Word = w.Word

                })
                .OrderBy(w => Guid.NewGuid())
                .FirstOrDefault()
                ;
            
            // TODO Hantera First() med try/catch eventuallt?!
            var tmpCorrect = _VHDBContext.VocableDictionary
                .First(w => w.Lid == toLanguageId && w.JoinId == masterWord.JoinId);

            VocableWord correctWord = new VocableWord()
            {
                CategoryId = tmpCorrect.Cid,
                JoinId = tmpCorrect.JoinId,
                LanguageId = tmpCorrect.Lid,
                Word = tmpCorrect.Word
            };

            var possibleAnswers = _VHDBContext.VocableDictionary
                .Where(w => w.Lid == toLanguageId && w.JoinId != masterWord.JoinId && w.Cid == categoryId)
                .ToList();

            int random1 = random.Next(0, possibleAnswers.Count());
            var tmpPossibleOne = possibleAnswers[random1];

            int random2;
            
            do
            {
                random2 = random.Next(0, possibleAnswers.Count());
            } while (random2 == random1);

            var tmpPossibleTwo = possibleAnswers[random2];


            VocableWord possibleWordOne = new VocableWord()
            {
                CategoryId = tmpPossibleOne.Cid,
                JoinId = tmpPossibleOne.JoinId,
                LanguageId = tmpPossibleOne.Lid,
                Word = tmpPossibleOne.Word
            };

            VocableWord possibleWordTwo = new VocableWord()
            {
                CategoryId = tmpPossibleTwo.Cid,
                JoinId = tmpPossibleTwo.JoinId,
                LanguageId = tmpPossibleTwo.Lid,
                Word = tmpPossibleTwo.Word
            };


            //var exclude = random1;
            //var range = Enumerable.Range(1, possibleAnswers.Count()).Where(i => !exclude.Contains(i));

            //int random2 = random.Next(0, possibleAnswers.Count());
            //var tmpPossibleTwo = possibleAnswers[random1];

            //Här får vi en lista med möjliga svar, kolla längden av denna och gör 2 random sva
            //Det andra svaret får inte ha samma värde som första (se håkans random ovan), när vi har 2 svar skjut in dem i vymodellen

            QuizStartVM quizStartVM = new QuizStartVM();

            quizStartVM.MasterWord = masterWord;


            quizStartVM.SvarsOrden = new SvarsOrd[3];
            for (int i = 0; i < quizStartVM.SvarsOrden.Length; i++)
            {
                quizStartVM.SvarsOrden[i] = new SvarsOrd();
            }

            //Slump för placering av rätt svar
            int random3 = random.Next(0, 3);
            
            quizStartVM.SvarsOrden[random3].AWord = correctWord;

            if (random3 == 0)
            {
                quizStartVM.SvarsOrden[1].AWord = possibleWordOne;
                quizStartVM.SvarsOrden[2].AWord = possibleWordTwo;
            }
            else if (random3 == 1)
            {
                quizStartVM.SvarsOrden[0].AWord = possibleWordOne;
                quizStartVM.SvarsOrden[2].AWord = possibleWordTwo;
            }
            else if (random3 == 2)
            {
                quizStartVM.SvarsOrden[1].AWord = possibleWordOne;
                quizStartVM.SvarsOrden[0].AWord = possibleWordTwo;
            }

            return quizStartVM;
        }
        
        public bool MatchWord(Guid answer, int vocableDictionaryId)
        {
            var recreatedMasterWord = _VHDBContext.VocableDictionary
                .First(w => w.Id == vocableDictionaryId);
           
            return answer == recreatedMasterWord.JoinId;
        }
        
        //matcha ordet som användaren har klickat på mot det ord som hämtats från databasen


        ////ta ut ord från databasen och visa på sidan
        //////var w => Entities.VocableDictionary
        //string word = "";
        //    word = vd
        //        .Where(w => w.Cid == 1)
        //        .Where(l => l.Lid == 1)
        //        .FirstOrDefault().ToString();
        //return word;
        ////string Word = "";
        ////Guid JoinId;
        ////string[] q = _VHDBContext.VocableDictionary.Where(w => w.Cid == 1).Where(l => l.Lid == 1).FirstOrDefault().{ Word = q.Word, JoinId = q.JoinId }.ToArray();

        //quizStartVM.SvarsOrden[random.Next(0, quizStartVM.SvarsOrden.Length)] = correctWord;

        //string[] queryWordInfo = new string[3];

        ////var q1 = _VHDBContext.VocableDictionary.Where(w => w.Cid == 1).Where(w => w.Lid == 1).FirstOrDefault().Word.ToString();
        //var q1 = _VHDBContext.VocableDictionary.Where(w => w.Cid == categoryId && w.Lid == languageId).FirstOrDefault().Word.ToString();
        ////här hämtas ordet word (QueryWord = ordet som frågas om)
        //var q2 = _VHDBContext.VocableDictionary.Where(w => w.Cid == 1).Where(w => w.Lid == 1).FirstOrDefault().JoinId;
        ////här hämtas samma ord som word q1 men dess join ID
        //var q3 = _VHDBContext.VocableDictionary.Where(w => w.JoinId == q2).Where(w => w.Lid == 2).FirstOrDefault().Word.ToString();
        ////här hämtas samma join ID men med nytt LID (AnswerWord = ordet som är rätt svar på QueryWord)

        //queryWordInfo[0] = q1;
        //queryWordInfo[1] = q3;
                
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VocableMVC.Models.ViewModels;
using VocableMVC.Models.Entities;
using VocableMVC.Models;
using Microsoft.AspNetCore.Http;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VocableMVC.Controllers
{
    public class QuizController : Controller
    {
        VHDBContext context;
        public QuizController(VHDBContext context)
        {
            HttpContext.Session.SetString("AnswerCounter", "0");
            HttpContext.Session.SetString("CorrectAnswers", "0");

            this.context = context;
        }
        // GET: /<controller>/
        public IActionResult Quiz()
        {   

            return View();
        }

        [HttpGet]
        public IActionResult Start()
        {
            Quiz quiz = new Quiz(context);//funkar men kan ställa till problem beronde på hur vi löser logiken men det funkar

            QuizStartVM newVM = quiz.GetWordFromVHDB(1, 2, 1);           
        
            return View(newVM);
        }

        [HttpGet]
        public IActionResult GetAnswer(Guid answer, int vocableDictionaryId)
        {
            Quiz quiz = new Quiz(context);


            bool correctAnswer = quiz.MatchWord(answer, vocableDictionaryId);

            string returnJson = "";

            if (correctAnswer)
                returnJson = "Rätt svar!";
            else
                returnJson = "Fel, försök igen";
                      
            return Json(returnJson);
        }

    }
}

//[HttpPost]
//public IActionResult Start(QuizStartVM model)
//{
//    model.Word = Models.Quiz.GetWordFromVHDB();
//    return View();
//}



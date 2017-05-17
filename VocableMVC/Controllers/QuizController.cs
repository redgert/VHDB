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

            int? answers = HttpContext.Session.GetInt32("AnswerCounter");

            if (answers.HasValue)
            {
                answers++;
                HttpContext.Session.SetInt32("AnswerCounter", answers.Value);
            }
            else
            {
                HttpContext.Session.SetInt32("AnswerCounter", 1);
            }

            int? correctAnswers = HttpContext.Session.GetInt32("CorrectAnswers");
            if (correctAnswers == null)
            {
                correctAnswers = 0;
            }

            bool correctAnswer = quiz.MatchWord(answer, vocableDictionaryId);

            if (correctAnswer)
            {
                correctAnswers++;
                HttpContext.Session.SetInt32("CorrectAnswers", correctAnswers.Value);
            }


            string returnJson = "";

            if (correctAnswer)
                returnJson = "Rätt svar!";
            else
                returnJson = "Fel, försök igen";

            return Json(returnJson);
        }


        [HttpGet]
        public IActionResult GetScore()
        {
            int? answers = HttpContext.Session.GetInt32("AnswerCounter");
            int? correctAnswers = HttpContext.Session.GetInt32("CorrectAnswers");
            string returnJson = "";

            if (answers.HasValue)
            {
                returnJson += $"du har svarat {answers} gånger,";
            }

            if (correctAnswers == null)
            {
                correctAnswers = 0;
            }
            if(correctAnswers == 0)
            {
                returnJson += "";
            }
            else
            {
                returnJson += $" och har haft {correctAnswers} rätt.";
            }



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



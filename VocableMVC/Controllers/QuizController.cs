using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VocableMVC.Models.ViewModels;
using VocableMVC.Models.Entities;
using VocableMVC.Models;


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

            QuizStartVM newVM = new QuizStartVM()
            {
                //Word = VocableMVC.Models.Quiz.GetWordFromVHDB(context.VocableDictionary.ToList())
                Word = quiz.GetWordFromVHDB()

            };
            return View(newVM);
        }
    }
}

//[HttpPost]
//public IActionResult Start(QuizStartVM model)
//{
//    model.Word = Models.Quiz.GetWordFromVHDB();
//    return View();
//}



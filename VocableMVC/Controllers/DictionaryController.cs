using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VocableMVC.Models;
using VocableMVC.Models.Entities;
using VocableMVC.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VocableMVC.Controllers
{
    public class DictionaryController : Controller
    {
        VHDBContext context;

        public DictionaryController(VHDBContext context)
        {
            this.context = context;
        }

        // GET: /<controller>/
        public IActionResult Main()
        {

            return View();
        }

        [HttpGet]
        public IActionResult GetDictionary(int toLanguageID, int categoryId)
        {
            Dictionary dictionary = new Dictionary (context);

            DictionaryMainVM newVM = dictionary.GetDictionaryFromVHDB(2,1);

            return View(newVM);
        }


    }
}

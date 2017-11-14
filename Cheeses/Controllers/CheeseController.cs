using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        static private Dictionary<string, string> Cheeses = new Dictionary<string, string>()
        {
            {"American", "Delicious"},
            {"Cheddar","Yellow"}
        };

        // GET: /<controller>/
        public IActionResult Index()
        {

            //passing the data to the view
            ViewBag.cheeses = Cheeses;

            return View();  //List of Cheeses
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]  //because of this we dont need an action in the form in Add.cshtml's form.
        public IActionResult NewCheese(string name, string description)
        {
            
            //foreach (char i in name)
            //{
            //    if (!char.IsLetter(i))
            //    {
            //        bool errorMessage = false;
                    
            //        ViewBag.errorMessage = errorMessage;

            //        return Redirect("/Cheese/Add");
            //    }
            //}

            // this should allow the description to be left blank on submission
            
            // Add the new cheese to my existing cheeses

            Cheeses.Add(name, description);

            return Redirect("/Cheese");

        }

        [HttpGet]
        [Route("/Cheese/Remove")]
        public IActionResult Remove()
        {
            ViewBag.cheeses = Cheeses;

            return View();

        }


        [HttpPost]
        [Route("/Cheese/Remove")]
        public IActionResult GoneCheese(List<string> name)
        {

            // Remove the new cheese to my existing cheeses
            
            

            foreach (var slice in name)
            {
                Cheeses.Remove(slice);
            }

            return Redirect("/Cheese");

        }

    }
}

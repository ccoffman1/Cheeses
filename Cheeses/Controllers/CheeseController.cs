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
        public IActionResult GoneCheese(string name)
        {

            // Remove the new cheese to my existing cheeses
            
            Cheeses.Remove(name);
            
            return Redirect("/Cheese");

        }

    }
}

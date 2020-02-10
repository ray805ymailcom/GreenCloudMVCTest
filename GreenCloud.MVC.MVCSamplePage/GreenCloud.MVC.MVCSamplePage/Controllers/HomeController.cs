using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GreenCloud.MVC.MVCSamplePage.Models;

namespace GreenCloud.MVC.MVCSamplePage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult NumberForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult NumberForm(UserInput userInput)
        {
            if (ModelState.IsValid)
            {
                if (System.Int32.TryParse(userInput.NumberEntered, out int numberEnteredInt))
                {
                    if (((numberEnteredInt % 3) == 0) || ((numberEnteredInt % 5) == 0))
                    {
                        if ((numberEnteredInt % 3) == 0)
                        {
                            ViewBag.Result = "Green";
                        }

                        if ((numberEnteredInt % 5) == 0)
                        {
                            ViewBag.Result += (ViewBag.Result == null) ? "Cloud" : " Cloud";
                        }
                    }
                    else
                    {
                        ViewBag.Result = userInput.NumberEntered;
                    }

                    return View();
                }
                else
                {
                    //this is only in case for whatever reason the Int32 parsing fails even after data annotation validation
                    ModelState.AddModelError("","Error processing value");
                    return View();
                }
            }
            else
                return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

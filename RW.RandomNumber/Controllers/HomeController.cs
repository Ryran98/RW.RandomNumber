using System;
using System.Web.Mvc;
using RW.RandomNumber.Models;
using RW.RandomNumber.Models.Difficulty;

namespace RW.RandomNumber.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Start(FormCollection collection)
        {
            Difficulties difficulty = (Difficulties)Enum.Parse(typeof(Difficulties), collection["Difficulty"]);
            Game game = new Game(difficulty);

            Session["Game"] = game;

            return View("Index", game);
        }

        public ActionResult Guess(FormCollection collection)
        {
            Game game = (Game)Session["Game"];
            game.Win = game.Guess(int.Parse(collection["Guess"].ToString()));

            return View("Index", game);
        }
    }
}
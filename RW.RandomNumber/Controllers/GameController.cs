using RW.RandomNumber.Models;
using RW.RandomNumber.Models.Difficulty;
using System;
using System.Web.Mvc;

namespace RW.RandomNumber.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Start(FormCollection collection)
        {
            Difficulties difficulty = (Difficulties)Enum.Parse(typeof(Difficulties), collection["Difficulty"]);
            Game game = new Game(difficulty);

            return View("Index", game);
        }

        public ActionResult Guess(FormCollection collection)
        {
            string diffCollection = collection["Difficulty"];
            string difficultySelection = diffCollection.Substring(diffCollection.LastIndexOf('.') + 1);

            Difficulties difficultyType = (Difficulties)Enum.Parse(typeof(Difficulties), difficultySelection);
            Base difficulty = Factory.Difficulty(difficultyType);

            Game game = new Game(difficulty, int.Parse(collection["RandomNumber"].ToString()), int.Parse(collection["RemainingGuesses"].ToString()));
            game.Win = game.Guess(int.Parse(collection["Guess"].ToString()));

            return View("Index", game);
        }
    }
}
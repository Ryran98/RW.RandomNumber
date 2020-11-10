using System;
using System.Linq;
using System.Web.Mvc;
using RW.RandomNumber.Models;

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
            _ResetError();
            Game game = (Game)Session["Game"];

            try
            {
                game.Win = game.Guess(int.Parse(collection["Guess"].ToString()));
                game.NewHighscore = Highscore.Check(game);
            }
            catch (Exception e)
            {
                Session["Error"] = e.Message;
            }

            return View("Index", game);
        }

        [HttpGet]
        public double GetProgress()
        {
            Game game = (Game)Session["Game"];

            double numberOfGuesses = (double) game.Difficulty.NumberOfGuesses;
            double remainingGuesses = (double) game.RemainingGuesses;

            double guessesUsed = numberOfGuesses - remainingGuesses;
            return guessesUsed / numberOfGuesses * 100;
        }

        private void _ResetError()
        {
            Session["Error"] = null;
        }
    }
}
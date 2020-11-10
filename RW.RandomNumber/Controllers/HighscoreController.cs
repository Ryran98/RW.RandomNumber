using System;
using System.Web.Mvc;
using RW.RandomNumber.Models;

namespace RW.RandomNumber.Controllers
{
    public class HighscoreController : Controller
    {
        public ActionResult Index()
        {
            _ResetError();
            
            return View();
        }

        public ActionResult Detail(int difficultyId)
        {
            try
            {
                Highscore highscore = new Highscore(difficultyId);
                return View(highscore);
            }
            catch (Exception e)
            {
                Session["Error"] = e.Message;
                return View("Index");
            }
        }

        public ActionResult New()
        {
            try
            {
                Game game = (Game)Session["Game"];

                if (!Highscore.Check(game))
                    throw new Exception($"No new highscore could be found");

                Highscore.New(game);

                return Detail(game.Difficulty.Id);
            }
            catch (Exception e)
            {
                Session["Error"] = e.Message;
                return View("Index");
            }
        }

        private void _ResetError()
        {
            Session["Error"] = null;
        }
    }
}
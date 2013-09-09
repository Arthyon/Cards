using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Cards.Messaging.Pipeline;
using Cards.Presentation.Core;

namespace Cards.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var game = Get.CurrentPlayer.CurrentGame;
            return game.IsSuccessful ? View("Game", game.Result) : View();
        }

        public ActionResult Game()
        {
            var game = Get.CurrentPlayer.CurrentGame;
            return game.IsSuccessful ? View(game.Result) : View("Error");
        }

        public ActionResult Documentation()
        {
            var pipelineDocumentations = Locate<IPipelineLocator>.Instance.AllPipeLines().Select(pipelines => pipelines.WhatDoIDo().Replace("\n", "<br />")).ToList();

            return View(pipelineDocumentations);
        }
    }
}
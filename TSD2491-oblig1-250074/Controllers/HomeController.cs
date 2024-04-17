using System;
using Microsoft.AspNetCore.Mvc;
using TSD2491_OBLIG1_250074.Models;

namespace TSD2491_oblig1_250074.Controllers
{
    public class HomeController : Controller
    {
        private readonly static MatchingGameModul _matchingGameModel = new MatchingGameModul();

        public IActionResult Index()
        {
            var shuffledEmojiList = _matchingGameModel.ShuffledEmoji;
            return View(shuffledEmojiList);
        }
    }
}
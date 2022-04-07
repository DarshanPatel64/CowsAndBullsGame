﻿using Cow_and_Bulls_game.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cow_and_Bulls_game.Controllers
{
    public class GameController : Controller
    {
        public IActionResult GamePage()
        {
            return View();
        }
        public IActionResult GameResult(GameData gd)
        {
            int bulls = 0;
            int cows = 0;
            var day = DateTime.Now.ToString("dd");
            var Hour = DateTime.Now.ToString("hh");
            string _gd = gd.number;
            string _dayhour = $"{day}{Hour}";

            GameData result = new GameData();
            if (int.Parse(_gd) == int.Parse(_dayhour))
            {
                result.isWon = true;
                result.msg = "You Win";
                result.bulls = 4; 
                return View(result);
            }
            else
            {
                result.isWon = false;
                for (int i = 0; i < 4; i++)
                {
                    if (_gd[i] == _dayhour[i])
                    {
                        _dayhour.Remove(_dayhour.IndexOf(_dayhour[i]));
                        _gd.Remove(_gd.IndexOf(_gd[i]));
                        bulls++;
                    }

                }
                foreach (char c in _gd)
                {
                    if (_dayhour.Contains(c))
                    {
                        cows++;
                        _dayhour.Remove(_dayhour.IndexOf(c));
                    }
                }
                result.msg = "Better Luck Next Time";
               
                result.bulls = bulls;
                result.cows = cows;
                return View(result);
            }
        }
    }
}

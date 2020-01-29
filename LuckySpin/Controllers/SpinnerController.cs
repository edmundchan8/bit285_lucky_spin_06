using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LuckySpin.Models;
using LuckySpin.ViewModels;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        Random random;
        Repository _repository;

        /***
         * Controller Constructor
         */
        public SpinnerController(Repository repository) //Pass respository as parameter as we have address Repository as a singleton, as long as we have registered this in the startup file
        {
            random = new Random();
            //TODO: Inject the Repository singleton
            _repository = repository;
        }

        /***
         * Entry Page Action
         **/
        [HttpGet]
        public IActionResult Index()
        {
                return View();
        }
        [HttpPost]
        public IActionResult Index(Player player)
        {
            if (!ModelState.IsValid) { return View(); }

            // TODO: Add the Player to the Repository
            _repository._player = player;

            // TODO: Build a new SpinItViewModel object with data from the Player and pass it to the View
            SpinViewModel spinVM = new SpinViewModel();
            spinVM.FirstName = _repository._player.FirstName;
            spinVM.CurrentBalance = _repository._player.StartingBalance;
            spinVM.Luck = _repository._player.Luck;
            _repository._player.Balance = spinVM.CurrentBalance;


            return RedirectToAction("SpinIt", spinVM);
        }

        /***
         * Spin Action - Game Play
         **/
        public IActionResult SpinIt(SpinViewModel spinVM) //TODO: replace the parameter with a ViewModel
        {
            SpinViewModel spin = new SpinViewModel
            {
                Luck = spinVM.Luck,
                A = random.Next(1, 10),
                B = random.Next(1, 10),
                C = random.Next(1, 10)
            };


            spin.Winner = (spin.A == spin.Luck || spin.B == spin.Luck || spin.C == spin.Luck);
            if (spin.Winner)
                _repository._player.CollectWinnings();
            
            //Add to Spin Repository
            _repository.AddSpin(spin);

            //TODO: Clean up ViewBag using a SpinIt ViewModel instead
            ViewBag.ImgDisplay = (spin.Winner) ? "block" : "none";
            ViewBag.FirstName = spinVM.FirstName;
            ViewBag.Balance = _repository._player.Balance;

            if (_repository._player.ChargeSpin())
                return View("SpinIt", spin);
            else
                return RedirectToAction("LuckList");
        }

        /***
         * LuckList Action - End of Game
         **/
        public IActionResult LuckList()
        {
            return View(_repository.PlayerSpins);
        }
    }
}
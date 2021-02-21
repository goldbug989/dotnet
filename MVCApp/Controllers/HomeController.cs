using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MVCApp.Models;
using MVCApp.Models.Repos;
using MVCApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IPersonRepo _personRepo;



        public HomeController(ILogger<HomeController> logger, IPersonRepo personRepo)
        {
            _logger = logger;
            _personRepo = personRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult list()
        {
            var personListViewModel = new PersonListViewModel
            {
                People = _personRepo.GetPeople()
            };

        return View(personListViewModel);
            
        }

        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                _personRepo.AddPerson(person);
                return RedirectToAction("list");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            //TODO :getbyid from repo
            //create viewmodel for edit 
            //pass viewmodel into view then in cshtml use @Model.
            var person = _personRepo.GetPersonById(id);
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _personRepo.Edit(person);
                return RedirectToAction("list");
            }

            return View();
        }







        public IActionResult Remove(int id)
        {
            _personRepo.Remove(id);
            return RedirectToAction("list");
        }


        public IActionResult Privacy()
        {
            return View();
        }

    }
}

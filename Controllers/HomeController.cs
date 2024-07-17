using FinalMission_pthoma24.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FinalMission_pthoma24.Controllers
{
    public class HomeController : Controller
    {
        private EntertainersDbContext _context { get; set; }
        
        // Constructor
        public HomeController(EntertainersDbContext context)
        {
            _context = context;
        }

        // Return Index page view
        public IActionResult Index()
        {
            return View();
        }

        // Return List of entertainers
        public IActionResult EntertainerList()
        {
            var temp = _context.Entertainers.ToList();

            return View(temp);
        }

        // Return Details page view for a specified entertainer
        public IActionResult Details(int entertainerid)
        {
            var entertainer = _context.Entertainers.Single(x => x.EntertainerID == entertainerid);

            return View(entertainer);
        }

        [HttpGet]

        // Return the AddEntertainer view
        public IActionResult AddEntertainer()
        {
            return View();
        }

        [HttpPost]

        // Given a valid Entertainer, add the Entertainer to the database _context and return the Confirmation view along with the Entertainer name
        public IActionResult AddEntertainer(Entertainer ent)
        {
            if (ModelState.IsValid) // If entry is valid
            {
                _context.Add(ent);
                _context.SaveChanges();

                return View("Confirmation", ent);
            }
            else // If entry is invalid
            {
                return View(ent);
            }
        }

        // Function to edit table row (Get)
        [HttpGet]
        public IActionResult Edit(int entertainerid)
        {
            var entertainer = _context.Entertainers.Single(x => x.EntertainerID == entertainerid);

            return View("AddEntertainer", entertainer); // return the "AddEntertainer" page view along with the record for the single Entertainer
        }

        // Function to edit table row (Post)
        [HttpPost]
        public IActionResult Edit(Entertainer ent)
        {
            _context.Update(ent);
            _context.SaveChanges();

            return RedirectToAction("EntertainerList"); // Go back to the "EntertainerList" action and rerun the process to print out all the results. Simply returning the page view here results in an error
        }

        // Function to delete table row (Get)
        [HttpGet]
        public IActionResult Delete(int entertainerid)
        {
            var entertainer = _context.Entertainers.Single(x => x.EntertainerID == entertainerid);

            return View("DeleteEntertainer", entertainer);
        }

        // Function to delete table row (Post)
        [HttpPost]
        public IActionResult Delete(Entertainer ent)
        {
            _context.Entertainers.Remove(ent);
            _context.SaveChanges();

            return RedirectToAction("EntertainerList");
        }
    }
}

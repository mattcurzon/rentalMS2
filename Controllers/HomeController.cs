using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using rentalMS2.Models;
using rentalMS2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace rentalMS2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRentalRepository repo;

        public HomeController(ILogger<HomeController> logger, IRentalRepository temp)
        {
            repo = temp;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AllUnits()
        {

            var buildings = repo.Buildings.
                Include(b => b.Units)
                .ToList();

            return View(buildings);
        }
        public IActionResult AllTasks()
        {
            var tasks = repo.MaitenanceTasks.ToList();

            return View(tasks);
        }
        public IActionResult AllChores()
        {
            var chores = repo.Chores
                .Include(c => c.Manager)
                .Include(c => c.Unit)
                .ToList();

            return View(chores);
        }
        public IActionResult UnitDetails(int unitId)
        {
            var unit = repo.Units
                .Include(u => u.UnitDeepCleans)
                .Include(u => u.MaitenanceTasks)
                .Include(u => u.Chores)
                .FirstOrDefault(u => u.UnitId == unitId);

            return View(unit);
        }
        [HttpGet]
        public IActionResult AddDeepClean()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddDeepClean(UnitDeepClean newClean)
        {
            if (ModelState.IsValid)
            {
                repo.AddDeepClean(newClean);
            } else
            {
                return View();
            }
            
            return RedirectToAction("Dashboard");
        }
        public IActionResult Dashboard()
        {
            var ViewModel = new DashboardViewModel
            {
                MaitenanceTasks = repo.GetAllMaitenanceTasks(),
                Chores = repo.GetAllChores(),
                UnitsNeedingDeepClean = repo.GetUnitsNeedingDeepClean(),
                UnitsEarlyCheckIn = repo.GetEarlyCheckIns(),
                UnitsLateCheckOut = repo.GetLateCheckOuts()
            };
            return View(ViewModel);
        }
        public IActionResult NeedsDeepClean()
        {
            var units = repo.GetUnitsNeedingDeepClean();

            return View(units);
        }
        [HttpGet]
        public IActionResult AddEarlyCheckIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEarlyCheckIn(EarlyCheckIn newCheckin)
        {
            if (ModelState.IsValid)
            {
                repo.AddEarlyCheckIn(newCheckin);
            } else
            {
                return View();
            }
            

            return RedirectToAction("Dashboard");
        }
        [HttpGet]
        public IActionResult AddLateCheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddLateCheckOut(LateCheckOut newCheckout)
        {
            if (ModelState.IsValid)
            {
                repo.AddLateCheckOut(newCheckout);
            } else
            {
                return View();
            }
            
            return RedirectToAction("Dashboard");
        }
        [HttpGet]
        public IActionResult AddMaitenanceTask()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMaitenanceTask(MaitenanceTask newTask)
        {
            if (ModelState.IsValid)
            {
                repo.AddMaitenanceTask(newTask);
            } else
            {
                return View();
            }

            return RedirectToAction("Dashboard");
        }
        [HttpGet]
        public IActionResult EditTask()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditTask(MaitenanceTask taskToEdit)
        {
            return RedirectToAction("Dashboard");
        }
        [HttpGet]
        public IActionResult AddChore()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddChore(Chore newChore)
        {

            if (ModelState.IsValid)
            {
                repo.AddChore(newChore);
            } else
            {
                return View();
            }
            
            return RedirectToAction("Dashboard");
        }
        [HttpGet]
        public IActionResult EditChore()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditChore(Chore choreToEdit)
        {
            return RedirectToAction("Dashboard");
        }
        public IActionResult ChoreDetails(int choreId)
        {
            var chore = repo.Chores
                .Include(c => c.Unit)
                .FirstOrDefault(c => c.ChoreId == choreId);

            return View(chore);
        }
        public IActionResult MaitenanceDetails(int taskId)
        {
            var task = repo.MaitenanceTasks
                .Include(t => t.Unit)
                .FirstOrDefault(t => t.MaitenanceId == taskId);

            return View(task);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

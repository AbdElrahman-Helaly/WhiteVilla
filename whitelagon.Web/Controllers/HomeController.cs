using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using whitelagon.Web.ViewModel;
using Whitelagon.admin.Entities;
using Whitelagon.Application.Common;

namespace whitelagon.Web.Controllers
{
    public class HomeController : Controller
    {
        private Iunitofwork Unit;
        
        public HomeController(Iunitofwork _Unit)
        {
            Unit = _Unit;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                VillaList = Unit.Villa.GetAll(null,includeproperties: "VillaAmenities"),
                CheckinDate = DateOnly.FromDateTime(DateTime.Now),
                CheckoutDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                nights = 1,
            };
            return View(homeVM);
        }
        [HttpPost]
        public IActionResult Index(HomeVM homeVM)
        { 
            homeVM.VillaList = Unit.Villa.GetAll(null, includeproperties: "VillaAmenities");
       foreach(var villa in homeVM.VillaList)
            {
                if (villa.Id % 2 == 0)
                {
                    villa.IsAvailable = true;
                }
            }
            return View(homeVM);
        }
       public IActionResult GetVillasbyDate(int nights,DateOnly dateOnly)
        {
            var villalist = Unit.Villa.GetAll(null,includeproperties: "VillaAmenities").ToList();
            foreach (var villa in villalist)
            {
                if (villa.Id % 2 == 0)
                {
                    villa.IsAvailable = true;
                }

            }
            HomeVM homeVM = new HomeVM()
            {
                CheckinDate = dateOnly,
                VillaList = villalist,
                nights = nights
            };
            return PartialView("_VillaList", homeVM);
        }

       public IActionResult Details()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}

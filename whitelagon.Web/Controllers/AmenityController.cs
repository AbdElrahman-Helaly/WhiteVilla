using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Whitelagon.admin.Entities;
using Whitelagon.Application.Common;

namespace whitelagon.Web.Controllers
{
    [Authorize]
    public class AmenityController : Controller
    {
       private Iunitofwork Unit;
        private readonly IWebHostEnvironment webHost;
        public AmenityController(Iunitofwork _Unit, IWebHostEnvironment _webHost)
        {
            Unit = _Unit;
            webHost = _webHost;
        }
        public IActionResult Index()
        {
         var Am= Unit.Amenity.GetAll(null, null);
            return View(Am);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Amenity amenity)
        {
        
            if (ModelState.IsValid)
            {
           
                Unit.Amenity.Add(amenity);
                Unit.Save();
                return RedirectToAction("Index");
            }
            return View(amenity);
        }

    }
}
